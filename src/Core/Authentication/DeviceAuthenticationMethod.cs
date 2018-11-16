using System;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Amazon.Extensions.CognitoAuthentication;
using Sweet.Game.Preferences;
using Sweet.Unity.Amazon;
using UnityEngine.Events;
using UnityEngine;
using Amazon.Runtime.Internal;

namespace Sweet.Game.Web
{
    public sealed class DeviceAuthenticationMethod : AuthenticationMethod
    {
        private static readonly string _DeviceIdKey = "deviceId";
        private static readonly string _DevicePasswordKey = "devicePassword";
        private IDevicePreferences _preferences;
        private ILogger _logger;
        private IAWSSDK _aws;
        private IAmazonCognitoIdentityProvider _cipClient;
        private string _region;
        private string _userPoolId;
        private string _clientId;
        private string _identityPoolId;


        public DeviceAuthenticationMethod(ILogger logger, IDevicePreferences preferences, IAWSSDK aws, string region, string userPoolId, string clientId, string identityPoolId)
        {
            _logger = logger;
            _preferences = preferences;
            _aws = aws;
            _region = region;
            _userPoolId = userPoolId;
            _clientId = clientId;
            _identityPoolId = identityPoolId;

            _cipClient = _aws.CreateCognitoIdentityProviderClient(
                _aws.CreateAnonymousAWSCredentials(),
                _region
            );
        }


        public override Task<ICognitoAWSCredentials> Authenticate()
        {
            var promise = new TaskCompletionSource<ICognitoAWSCredentials>();
            string deviceId;
            string devicePassword;

            if (!_preferences.TryGetValue(_DeviceIdKey, out deviceId) ||
                string.IsNullOrEmpty(deviceId) ||
                !_preferences.TryGetValue(_DevicePasswordKey, out devicePassword) ||
                string.IsNullOrEmpty(devicePassword))
            {
                using (var generator = RNGCryptoServiceProvider.Create())
                {
                    byte[] buffer = new byte[33];
                    generator.GetBytes(buffer);
                    deviceId = Convert.ToBase64String(buffer);
                    generator.GetBytes(buffer);
                    devicePassword = Convert.ToBase64String(buffer);
                }

                var signUpRequest = new SignUpRequest();
                signUpRequest.Username = deviceId;
                signUpRequest.Password = devicePassword;
                signUpRequest.ClientId = _clientId;

                _logger.Log($"SignUp with new credentials for user {deviceId}");
                _cipClient.SignUpAsync(signUpRequest, signUpResult =>
                {
                    if (signUpResult.Exception != null)
                    {
                        promise.SetException(signUpResult.Exception);
                        return;
                    }

                    _logger.Log("SignUp success!");

                    if (signUpResult.Response != null)
                    {
                        _logger.Log("UserSub:" + signUpResult.Response.UserSub);
                    }

                    _preferences.SetValue(_DeviceIdKey, deviceId);
                    _preferences.SetValue(_DevicePasswordKey, devicePassword);
                    OnSignedUp(deviceId, devicePassword, promise);
                });

            }
            else
            {
                _logger.Log("Already signed up!");
                OnSignedUp(deviceId, devicePassword, promise);
            }

            return promise.Task;
        }

        private void OnSignedUp(string deviceId, string devicePassword, TaskCompletionSource<ICognitoAWSCredentials> promise)
        {
            var userPool = new CognitoUserPool(_userPoolId, _clientId, _cipClient);
            var user = new CognitoUser(deviceId, userPool.ClientID, userPool, _cipClient);

            var srpRequest = new InitiateSrpAuthRequest();
            srpRequest.Password = devicePassword;

            _logger.Log($"Authenticating for user {deviceId}");
            user.StartWithSrpAuthAsync(srpRequest, srpResult =>
            {
                if (srpResult.Exception != null)
                {
                    if (srpResult.Exception is UserNotFoundException)
                    {
                        var signUpRequest = new SignUpRequest();
                        signUpRequest.Username = deviceId;
                        signUpRequest.Password = devicePassword;
                        signUpRequest.ClientId = _clientId;

                        _logger.Log($"SignUp with new credentials for user {deviceId}");
                        _cipClient.SignUpAsync(signUpRequest, signUpResult =>
                        {
                            if (signUpResult.Exception != null)
                            {
                                promise.SetException(signUpResult.Exception);
                                return;
                            }

                            _logger.Log("SignUp success!");
                            if (signUpResult.Response != null)
                            {
                                _logger.Log("UserSub:" + signUpResult.Response.UserSub);
                            }

                            _preferences.SetValue(_DeviceIdKey, deviceId);
                            _preferences.SetValue(_DevicePasswordKey, devicePassword);
                            OnSignedUp(deviceId, devicePassword, promise);
                        });
                        return;
                    }

                    promise.SetException(srpResult.Exception);
                    return;
                }

                _logger.Log("Authentication success!");
                ICognitoAWSCredentials credentials = user.GetCognitoAWSCredentials(
                    _identityPoolId,
                    RegionEndpoint.GetBySystemName(_region),
                    _aws);

                promise.SetResult(credentials);
            });
        }
    }
}