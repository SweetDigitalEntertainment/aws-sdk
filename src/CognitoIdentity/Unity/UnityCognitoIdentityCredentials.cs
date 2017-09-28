#if UNITY_EDITOR || !UNITY_WEBGL
using Amazon;
using Amazon.CognitoIdentity;
using UnityEngine;
using UnityEngine.Events;

namespace Sweet.Game.Amazon.Unity
{
    public sealed class UnityCognitoIdentityCredentials : ICognitoIdentityCredentials
    {
        private CognitoAWSCredentials _cognitoIdentityCredentials;




        public UnityCognitoIdentityCredentials(string identityPoolId, string region)
        {
            _cognitoIdentityCredentials = new CognitoAWSCredentials(
                identityPoolId,
                RegionEndpoint.GetBySystemName(region)
            );
        }

        public void GetCredentialsAsync(UnityAction<ICognitoIdentityResult<ICredentials>> callback)
        {
            _cognitoIdentityCredentials.GetCredentialsAsync(t => {
                if (t.Exception != null)
                {
                    Debug.LogException(t.Exception);
                }
                else
                {
                    callback(new CognitoIdentityResult<ICredentials>(new Credentials(
                        t.Response.AccessKey,
                        t.Response.SecretKey,
                        t.Response.Token)));
                }
            });
        }
    }
}
#endif