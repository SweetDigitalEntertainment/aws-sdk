/*
 * Copyright 2017 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 * 
 * Licensed under the Apache License, Version 2.0 (the "License").
 * You may not use this file except in compliance with the License.
 * A copy of the License is located at
 * 
 *  http://aws.amazon.com/apache2.0
 * 
 * or in the "license" file accompanying this file. This file is distributed
 * on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either
 * express or implied. See the License for the specific language governing
 * permissions and limitations under the License.
 */

using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Collections.Generic;

using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Amazon.CognitoIdentity;

using Amazon.Extensions.CognitoAuthentication.ThirdParty;
using Sweet.Unity.Amazon;

namespace Amazon.Extensions.CognitoAuthentication
{
    partial class CognitoUser
    {
        /// <summary>
        /// Initiates the asynchronous SRP authentication flow
        /// </summary>
        /// <param name="srpRequest">InitiateSrpAuthRequest object containing the necessary parameters to
        /// create an InitiateAuthAsync API call for SRP authentication</param>
        /// <returns>Returns the AuthFlowResponse object that can be used to respond to the next challenge, 
        /// if one exists</returns>
        public void StartWithSrpAuthAsync(InitiateSrpAuthRequest srpRequest, AsyncCallback<AuthFlowResponse> callback = null)
        {
            if (srpRequest == null || string.IsNullOrEmpty(srpRequest.Password))
            {
                throw new ArgumentNullException("Password required for authentication.", "srpRequest");
            }

            Tuple<BigInteger, BigInteger> tupleAa = AuthenticationHelper.CreateAaTuple();
            InitiateAuthRequest initiateRequest = CreateSrpAuthRequest(tupleAa);

            Provider.InitiateAuthAsync(initiateRequest, initResult =>
            {
                if (initResult.Exception != null)
                {
                    callback?.Invoke(new AsyncResult<AuthFlowResponse>(null, initResult.Exception));
                    return;
                }

                UpdateUsernameAndSecretHash(initResult.Response.ChallengeParameters);

                RespondToAuthChallengeRequest challengeRequest =
                    CreateSrpPasswordVerifierAuthRequest(initResult.Response, srpRequest.Password, tupleAa);

                bool challengeResponsesValid = challengeRequest != null && challengeRequest.ChallengeResponses != null;
                bool deviceKeyValid = Device != null && !string.IsNullOrEmpty(Device.DeviceKey);

                if (challengeResponsesValid && deviceKeyValid)
                {
                    challengeRequest.ChallengeResponses.Add(CognitoConstants.ChlgParamDeviceKey, Device.DeviceKey);
                }


                Provider.RespondToAuthChallengeAsync(challengeRequest, respondResult =>
                {
                    if (respondResult.Exception != null)
                    {
                        callback?.Invoke(new AsyncResult<AuthFlowResponse>(null, respondResult.Exception));
                        return;
                    }

                    RespondToAuthChallengeResponse verifierResponse = respondResult.Response;
                    UpdateSessionIfAuthenticationComplete(verifierResponse.ChallengeName, verifierResponse.AuthenticationResult);

                    callback?.Invoke(new AsyncResult<AuthFlowResponse>(new AuthFlowResponse()
                    {
                        SessionID = verifierResponse.Session,
                        ChallengeName = verifierResponse.ChallengeName,
                        AuthenticationResult = verifierResponse.AuthenticationResult,
                        ChallengeParameters = verifierResponse.ChallengeParameters,
                        ClientMetadata = new Dictionary<string, string>(verifierResponse.ResponseMetadata.Metadata)
                    }, null));
                });
            });
        }

        /// <summary>
        /// Initiates the asynchronous custom authentication flow
        /// </summary>
        /// <param name="customRequest">InitiateCustomAuthRequest object containing the necessary parameters to
        /// create an InitiateAuthAsync API call for custom authentication</param>
        /// <returns>Returns the AuthFlowResponse object that can be used to respond to the next challenge, 
        /// if one exists</returns>
        public void StartWithCustomAuthAsync(InitiateCustomAuthRequest customRequest, AsyncCallback<AuthFlowResponse> callback = null)
        {
            InitiateAuthRequest authRequest = new InitiateAuthRequest()
            {
                AuthFlow = AuthFlowType.CUSTOM_AUTH,
                AuthParameters = new Dictionary<string, string>(customRequest.AuthParameters),
                ClientId = ClientID,
                ClientMetadata = new Dictionary<string, string>(customRequest.ClientMetadata)
            };

            Provider.InitiateAuthAsync(authRequest, r =>
            {
                if (r.Exception != null)
                {
                    callback?.Invoke(new AsyncResult<AuthFlowResponse>(null, r.Exception));
                    return;
                }

                InitiateAuthResponse initiateResponse = r.Response;
                UpdateUsernameAndSecretHash(initiateResponse.ChallengeParameters);

                UpdateSessionIfAuthenticationComplete(initiateResponse.ChallengeName, initiateResponse.AuthenticationResult);

                callback?.Invoke(new AsyncResult<AuthFlowResponse>(new AuthFlowResponse()
                {
                    SessionID = initiateResponse.Session,
                    ChallengeName = initiateResponse.ChallengeName,
                    AuthenticationResult = initiateResponse.AuthenticationResult,
                    ChallengeParameters = initiateResponse.ChallengeParameters,
                    ClientMetadata = new Dictionary<string, string>(initiateResponse.ResponseMetadata.Metadata)
                }, null));
            });
        }

        /// <summary>
        /// Uses the properties of the RespondToCustomChallengeRequest object to respond to the current 
        /// custom authentication challenge using an asynchronous call
        /// </summary>
        /// <param name="customRequest">RespondToCustomChallengeRequest object containing the necessary parameters to
        /// respond to the current custom authentication challenge</param>
        /// <returns>Returns the AuthFlowResponse object that can be used to respond to the next challenge, 
        /// if one exists</returns>
        public void RespondToCustomAuthAsync(RespondToCustomChallengeRequest customRequest, AsyncCallback<AuthFlowResponse> callback = null)
        {
            RespondToAuthChallengeRequest request = new RespondToAuthChallengeRequest()
            {
                ChallengeName = ChallengeNameType.CUSTOM_CHALLENGE,
                ClientId = ClientID,
                ChallengeResponses = new Dictionary<string, string>(customRequest.ChallengeParameters),
                Session = customRequest.SessionID
            };

            Provider.RespondToAuthChallengeAsync(request, r =>
            {
                if (r.Exception != null)
                {
                    callback?.Invoke(new AsyncResult<AuthFlowResponse>(null, r.Exception));
                    return;
                }

                RespondToAuthChallengeResponse authResponse = r.Response;
                UpdateSessionIfAuthenticationComplete(authResponse.ChallengeName, authResponse.AuthenticationResult);

                callback?.Invoke(new AsyncResult<AuthFlowResponse>(new AuthFlowResponse()
                {
                    SessionID = authResponse.Session,
                    ChallengeName = authResponse.ChallengeName,
                    AuthenticationResult = authResponse.AuthenticationResult,
                    ChallengeParameters = authResponse.ChallengeParameters,
                    ClientMetadata = new Dictionary<string, string>(authResponse.ResponseMetadata.Metadata)
                }, null));
            });

        }

        /// <summary>
        /// Uses the properties of the RespondToSmsMfaRequest object to respond to the current MFA 
        /// authentication challenge using an asynchronous call
        /// </summary>
        /// <param name="smsMfaRequest">RespondToSmsMfaRequest object containing the necessary parameters to
        /// respond to the current SMS MFA authentication challenge</param>
        /// <returns>Returns the AuthFlowResponse object that can be used to respond to the next challenge, 
        /// if one exists</returns>
        public void RespondToSmsMfaAuthAsync(RespondToSmsMfaRequest smsMfaRequest, AsyncCallback<AuthFlowResponse> callback = null)
        {
            RespondToAuthChallengeRequest challengeRequest = new RespondToAuthChallengeRequest
            {
                ChallengeResponses = new Dictionary<string, string>
                    {
                        { CognitoConstants.ChlgParamSmsMfaCode, smsMfaRequest.MfaCode},
                        { CognitoConstants.ChlgParamUsername, Username }
                    },
                Session = smsMfaRequest.SessionID,
                ClientId = ClientID,
                ChallengeName = ChallengeNameType.SMS_MFA
            };

            if (!string.IsNullOrEmpty(SecretHash))
            {
                challengeRequest.ChallengeResponses.Add(CognitoConstants.ChlgParamSecretHash, SecretHash);
            }

            Provider.RespondToAuthChallengeAsync(challengeRequest, r =>
            {
                if (r.Exception != null)
                {
                    callback?.Invoke(new AsyncResult<AuthFlowResponse>(null, r.Exception));
                    return;
                }

                RespondToAuthChallengeResponse challengeResponse = r.Response;
                UpdateSessionIfAuthenticationComplete(challengeResponse.ChallengeName, challengeResponse.AuthenticationResult);

                callback?.Invoke(new AsyncResult<AuthFlowResponse>(new AuthFlowResponse()
                {
                    SessionID = challengeResponse.Session,
                    ChallengeName = challengeResponse.ChallengeName,
                    AuthenticationResult = challengeResponse.AuthenticationResult,
                    ChallengeParameters = challengeResponse.ChallengeParameters,
                    ClientMetadata = new Dictionary<string, string>(challengeResponse.ResponseMetadata.Metadata)
                }, null));
            });
        }

        /// <summary>
        /// Uses the properties of the RespondToNewPasswordRequiredRequest object to respond to the current new 
        /// password required authentication challenge using an asynchronous call
        /// </summary>
        /// <param name="newPasswordRequest">RespondToNewPasswordRequiredRequest object containing the necessary 
        /// parameters to respond to the current SMS MFA authentication challenge</param>
        /// <returns>Returns the AuthFlowResponse object that can be used to respond to the next challenge, 
        /// if one exists</returns>
        public void RespondToNewPasswordRequiredAsync(RespondToNewPasswordRequiredRequest newPasswordRequest, AsyncCallback<AuthFlowResponse> callback = null)
        {
            RespondToAuthChallengeRequest challengeRequest = new RespondToAuthChallengeRequest
            {
                ChallengeResponses = new Dictionary<string, string>
                    {
                        { CognitoConstants.ChlgParamNewPassword, newPasswordRequest.NewPassword},
                        { CognitoConstants.ChlgParamUsername, Username }
                    },
                Session = newPasswordRequest.SessionID,
                ClientId = ClientID,
                ChallengeName = ChallengeNameType.NEW_PASSWORD_REQUIRED
            };

            if (!string.IsNullOrEmpty(SecretHash))
            {
                challengeRequest.ChallengeResponses.Add(CognitoConstants.ChlgParamSecretHash, SecretHash);
            }

            Provider.RespondToAuthChallengeAsync(challengeRequest, r =>
            {
                if (r.Exception != null)
                {
                    callback?.Invoke(new AsyncResult<AuthFlowResponse>(null, r.Exception));
                    return;
                }

                RespondToAuthChallengeResponse challengeResponse = r.Response;
                UpdateSessionIfAuthenticationComplete(challengeResponse.ChallengeName, challengeResponse.AuthenticationResult);

                callback?.Invoke(new AsyncResult<AuthFlowResponse>(new AuthFlowResponse()
                {
                    SessionID = challengeResponse.Session,
                    ChallengeName = challengeResponse.ChallengeName,
                    AuthenticationResult = challengeResponse.AuthenticationResult,
                    ChallengeParameters = challengeResponse.ChallengeParameters,
                    ClientMetadata = new Dictionary<string, string>(challengeResponse.ResponseMetadata.Metadata)
                }, null));
            });
        }

        /// <summary>
        /// Initiates the asynchronous refresh token authentication flow
        /// </summary>
        /// <param name="refreshTokenRequest">InitiateRefreshTokenAuthRequest object containing the necessary 
        /// parameters to initiate the refresh token authentication flow</param>
        /// <returns>Returns the AuthFlowResponse object that can be used to respond to the next challenge, 
        /// if one exists</returns>
        public void StartWithRefreshTokenAuthAsync(InitiateRefreshTokenAuthRequest refreshTokenRequest, AsyncCallback<AuthFlowResponse> callback = null)
        {
            InitiateAuthRequest initiateAuthRequest = CreateRefreshTokenAuthRequest(refreshTokenRequest.AuthFlowType);

            Provider.InitiateAuthAsync(initiateAuthRequest, r =>
            {
                if (r.Exception != null)
                {
                    callback?.Invoke(new AsyncResult<AuthFlowResponse>(null, r.Exception));
                    return;
                }

                InitiateAuthResponse initiateResponse = r.Response;
                UpdateSessionIfAuthenticationComplete(initiateResponse.ChallengeName, initiateResponse.AuthenticationResult);

                callback?.Invoke(new AsyncResult<AuthFlowResponse>(new AuthFlowResponse()
                {
                    SessionID = initiateResponse.Session,
                    ChallengeName = initiateResponse.ChallengeName,
                    AuthenticationResult = initiateResponse.AuthenticationResult,
                    ChallengeParameters = initiateResponse.ChallengeParameters,
                    ClientMetadata = new Dictionary<string, string>(initiateResponse.ResponseMetadata.Metadata)
                }, null));
            });
        }

        /// <summary>
        /// Initiates the asynchronous ADMIN_NO_SRP_AUTH authentication flow
        /// </summary>
        /// <param name="adminAuthRequest">InitiateAdminNoSrpAuthRequest object containing the necessary 
        /// parameters to initiate the ADMIN_NO_SRP_AUTH authentication flow</param>
        /// <returns>Returns the AuthFlowResponse object that can be used to respond to the next challenge, 
        /// if one exists</returns>
        public void StartWithAdminNoSrpAuthAsync(InitiateAdminNoSrpAuthRequest adminAuthRequest, AsyncCallback<AuthFlowResponse> callback = null)
        {
            AdminInitiateAuthRequest initiateAuthRequest = CreateAdminAuthRequest(adminAuthRequest);

            Provider.AdminInitiateAuthAsync(initiateAuthRequest, r =>
            {
                if (r.Exception != null)
                {
                    callback?.Invoke(new AsyncResult<AuthFlowResponse>(null, r.Exception));
                    return;
                }

                AdminInitiateAuthResponse initiateResponse = r.Response;
                UpdateSessionIfAuthenticationComplete(initiateResponse.ChallengeName, initiateResponse.AuthenticationResult);

                callback?.Invoke(new AsyncResult<AuthFlowResponse>(new AuthFlowResponse()
                {
                    SessionID = initiateResponse.Session,
                    ChallengeName = initiateResponse.ChallengeName,
                    AuthenticationResult = initiateResponse.AuthenticationResult,
                    ChallengeParameters = initiateResponse.ChallengeParameters,
                    ClientMetadata = new Dictionary<string, string>(initiateResponse.ResponseMetadata.Metadata)
                }, null));
            });
        }

        /// <summary>
        /// Internal method for updating the CognitoUser SessionTokens property if properly authenticated
        /// </summary>
        private void UpdateSessionIfAuthenticationComplete(ChallengeNameType challengeName, AuthenticationResultType authResult)
        {
            if (string.IsNullOrEmpty(challengeName))
            {
                CognitoUserSession cognitoUserSession = GetCognitoUserSession(authResult);
                this.SessionTokens = cognitoUserSession;
            }
        }

        /// <summary>
        /// Interal method which creates the InitiateAuthRequest for an SRP authentication flow
        /// </summary>
        /// <param name="tupleAa">Tuple containing the A,a pair for SRP authentication</param>
        /// <returns>Returns the InitiateAuthRequest for an SRP authentication flow</returns>
        private InitiateAuthRequest CreateSrpAuthRequest(Tuple<BigInteger, BigInteger> tupleAa)
        {
            InitiateAuthRequest initiateAuthRequest = new InitiateAuthRequest()
            {
                AuthFlow = AuthFlowType.USER_SRP_AUTH,
                ClientId = ClientID,
                AuthParameters = new Dictionary<string, string>(StringComparer.Ordinal)
                {
                    { CognitoConstants.ChlgParamUsername, Username },
                    { CognitoConstants.ChlgParamSrpA, tupleAa.Item1.ToString(16) }
                }
            };

            if (!string.IsNullOrEmpty(ClientSecret))
            {
                initiateAuthRequest.AuthParameters.Add(CognitoConstants.ChlgParamSecretHash,
                                                    Util.GetUserPoolSecretHash(Username, ClientID, ClientSecret));
            }

            if (Device != null && !string.IsNullOrEmpty(Device.DeviceKey))
            {
                initiateAuthRequest.AuthParameters.Add(CognitoConstants.ChlgParamDeviceKey, Device.DeviceKey);
            }

            return initiateAuthRequest;
        }

        /// <summary>
        /// Internal mehtod which updates CognitoUser's username, secret hash, and device key from challege parameters
        /// </summary>
        /// <param name="challengeParameters">Dictionary containing the key-value pairs for challenge parameters</param>
        private void UpdateUsernameAndSecretHash(IDictionary<string, string> challengeParameters)
        {
            bool canSetUsername = string.IsNullOrEmpty(Username) || string.Equals(UserID, Username, StringComparison.Ordinal);
            bool challengeParamIsUsername = challengeParameters != null && challengeParameters.ContainsKey(CognitoConstants.ChlgParamUsername);
            bool shouldUpdate = canSetUsername || challengeParamIsUsername;

            if (!shouldUpdate)
            {
                return;
            }

            if (challengeParameters.ContainsKey(CognitoConstants.ChlgParamUsername))
            {
                Username = challengeParameters[CognitoConstants.ChlgParamUsername];
            }

            if (!string.IsNullOrEmpty(ClientSecret))
            {
                SecretHash = Util.GetUserPoolSecretHash(Username, ClientID, ClientSecret);
            }
        }

        private AdminInitiateAuthRequest CreateAdminAuthRequest(InitiateAdminNoSrpAuthRequest adminRequest)
        {
            AdminInitiateAuthRequest returnRequest = new AdminInitiateAuthRequest()
            {
                AuthFlow = AuthFlowType.ADMIN_NO_SRP_AUTH,
                ClientId = ClientID,
                UserPoolId = UserPool.PoolID,
                AuthParameters = new Dictionary<string, string>()
                {
                    { CognitoConstants.ChlgParamUsername, Username },
                    {CognitoConstants.ChlgParamPassword, adminRequest.Password }
                }
            };

            if (Device != null && !string.IsNullOrEmpty(Device.DeviceKey))
            {
                returnRequest.AuthParameters.Add(CognitoConstants.ChlgParamDeviceKey, Device.DeviceKey);
            }

            if (!string.IsNullOrEmpty(SecretHash))
            {
                returnRequest.AuthParameters.Add(CognitoConstants.ChlgParamSecretHash, SecretHash);
            }

            if (adminRequest.ClientMetadata != null)
            {
                returnRequest.ClientMetadata = new Dictionary<string, string>(adminRequest.ClientMetadata);
            }

            return returnRequest;
        }

        private InitiateAuthRequest CreateRefreshTokenAuthRequest(AuthFlowType authFlowType)
        {
            EnsureUserAuthenticated();

            if (authFlowType != AuthFlowType.REFRESH_TOKEN && authFlowType != AuthFlowType.REFRESH_TOKEN_AUTH)
            {
                throw new ArgumentException("authFlowType must be either \"REFRESH_TOKEN\" or \"REFRESH_TOKEN_AUTH\"", "authFlowType");
            }

            InitiateAuthRequest initiateAuthRequest = new InitiateAuthRequest()
            {
                AuthFlow = authFlowType,
                ClientId = ClientID,
                AuthParameters = new Dictionary<string, string>()
                {
                    {CognitoConstants.ChlgParamUsername, Username },
                    {CognitoConstants.ChlgParamRefreshToken, SessionTokens.RefreshToken }
                }
            };

            if (Device != null && !string.IsNullOrEmpty(Device.DeviceKey))
            {
                initiateAuthRequest.AuthParameters.Add(CognitoConstants.ChlgParamDeviceKey, Device.DeviceKey);
            }

            if (!string.IsNullOrEmpty(SecretHash))
            {
                initiateAuthRequest.AuthParameters.Add(CognitoConstants.ChlgParamSecretHash, SecretHash);
            }

            return initiateAuthRequest;
        }

        /// <summary>
        /// Internal method which responds to the PASSWORD_VERIFIER challenge in SRP authentication
        /// </summary>
        /// <param name="challenge">Response from the InitiateAuth challenge</param>
        /// <param name="password">Password for the CognitoUser, needed for authentication</param>
        /// <param name="tupleAa">Tuple of BigIntegers containing the A,a pair for the SRP protocol flow</param>
        /// <returns>Returns the RespondToAuthChallengeRequest for an SRP authentication flow</returns>
        private RespondToAuthChallengeRequest CreateSrpPasswordVerifierAuthRequest(InitiateAuthResponse challenge,
                                                                                   string password,
                                                                                   Tuple<BigInteger, BigInteger> tupleAa)
        {
            string username = challenge.ChallengeParameters[CognitoConstants.ChlgParamUsername];
            string poolName = PoolName;
            string secretBlock = challenge.ChallengeParameters[CognitoConstants.ChlgParamSecretBlock];
            string salt = challenge.ChallengeParameters[CognitoConstants.ChlgParamSalt];
            BigInteger srpb = new BigInteger(challenge.ChallengeParameters[CognitoConstants.ChlgParamSrpB], 16);

            if (srpb.Mod(AuthenticationHelper.N).Equals(BigInteger.Zero))
            {
                throw new ArgumentException("SRP error, B mod N cannot be zero.", "challenge");
            }

            DateTime timestamp = DateTime.UtcNow;
            string timeStr = timestamp.ToString("ddd MMM d HH:mm:ss \"UTC\" yyyy", CultureInfo.InvariantCulture);

            byte[] claim = AuthenticationHelper.AuthenticateUser(username, password, poolName, tupleAa, salt,
                challenge.ChallengeParameters[CognitoConstants.ChlgParamSrpB], secretBlock, timeStr);
            string claimBase64 = Convert.ToBase64String(claim);

            Dictionary<string, string> srpAuthResponses = new Dictionary<string, string>(StringComparer.Ordinal)
            {
                {CognitoConstants.ChlgParamPassSecretBlock, secretBlock},
                {CognitoConstants.ChlgParamPassSignature, claimBase64},
                {CognitoConstants.ChlgParamUsername, username },
                {CognitoConstants.ChlgParamTimestamp, timeStr },
            };

            if (!string.IsNullOrEmpty(ClientSecret))
            {
                SecretHash = Util.GetUserPoolSecretHash(Username, ClientID, ClientSecret);
                srpAuthResponses.Add(CognitoConstants.ChlgParamSecretHash, SecretHash);
            }

            if (Device != null && !string.IsNullOrEmpty(Device.DeviceKey))
            {
                srpAuthResponses.Add(CognitoConstants.ChlgParamDeviceKey, Device.DeviceKey);
            }

            RespondToAuthChallengeRequest authChallengeRequest = new RespondToAuthChallengeRequest()
            {
                ChallengeName = challenge.ChallengeName,
                ClientId = ClientID,
                Session = challenge.Session,
                ChallengeResponses = srpAuthResponses
            };

            return authChallengeRequest;
        }

        /// <summary>
        /// Creates the CognitoAWSCredentials for accessing AWS resources. Should only be called with an authenticated user.
        /// </summary>
        /// <param name="identityPoolID">The poolID of the identity pool the user belongs to</param>
        /// <param name="identityPoolRegion">The region of the identity pool the user belongs to</param>
        /// <returns>Returns the CognitoAWSCredentials for the user to be able to access AWS resources</returns>
        public ICognitoAWSCredentials GetCognitoAWSCredentials(string identityPoolID, RegionEndpoint identityPoolRegion, IAWSSDK sdk)
        {
            EnsureUserAuthenticated();

            string poolRegion = UserPool.PoolID.Substring(0, UserPool.PoolID.IndexOf("_"));
            string providerName = "cognito-idp." + poolRegion + ".amazonaws.com/" + UserPool.PoolID;

            ICognitoAWSCredentials credentials = sdk.CreateCognitoAWSCredentials(identityPoolID, identityPoolRegion.SystemName);

            credentials.Clear();
            credentials.AddLogin(providerName, SessionTokens.IdToken);

            return credentials;
        }
    }
}
