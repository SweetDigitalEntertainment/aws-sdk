using System;
using System.Threading.Tasks;
using Facebook.Unity;
using Sweet.Unity.Amazon;
using UnityEngine.Events;

namespace Sweet.Game.Web
{
    public sealed class FacebookAuthenticationMethod : AuthenticationMethod
    {
        private IAWSSDK _aws;
        private string _identityPoolId;
        private string _region;


        public FacebookAuthenticationMethod(IAWSSDK aws, string identityPoolId, string region)
        {
            _aws = aws;
            _identityPoolId = identityPoolId;
            _region = region;
        }


        public override Task<ICognitoAWSCredentials> Authenticate()
        {
            var promise = new TaskCompletionSource<ICognitoAWSCredentials>();

            if (!FB.IsInitialized)
            {
                FB.Init(() => OnInitialized(promise));
            }

            OnInitialized(promise);
            return promise.Task;
        }

        private void OnInitialized(TaskCompletionSource<ICognitoAWSCredentials> promise)
        {
            if (!FB.IsLoggedIn)
            {
                FB.LogInWithReadPermissions(
                    null,
                    loginResult =>
                    {
                        if (string.IsNullOrEmpty(loginResult.Error))
                        {
                            promise.SetException(new Exception(loginResult.Error));
                            return;
                        }

                        OnLogIn(loginResult.AccessToken, promise);
                    }
                );
            }

            OnLogIn(AccessToken.CurrentAccessToken, promise);
        }

        private void OnLogIn(AccessToken accessToken, TaskCompletionSource<ICognitoAWSCredentials> promise)
        {
            ICognitoAWSCredentials credentials = _aws.CreateCognitoAWSCredentials(_identityPoolId, _region);
            credentials.AddLogin("graph.facebook.com", accessToken.TokenString);
            promise.SetResult(credentials);
        }
    }
}