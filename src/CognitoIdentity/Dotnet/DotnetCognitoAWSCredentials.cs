#if UNITY_EDITOR || !UNITY_WEBGL
using Amazon;
using Amazon.CognitoIdentity;
using Amazon.Runtime;
using Amazon.SecurityToken;
using UnityEngine;
using UnityEngine.Events;

namespace Sweet.Unity.Amazon.Dotnet
{
    public sealed class DotnetCognitoAWSCredentials : CognitoAWSCredentials, ICognitoAWSCredentials
    {
        public DotnetCognitoAWSCredentials(string identityPoolId, RegionEndpoint region) : base(identityPoolId, region)
        {
        }

        public DotnetCognitoAWSCredentials(string accountId, string identityPoolId, string unAuthRoleArn, string authRoleArn, RegionEndpoint region) : base(accountId, identityPoolId, unAuthRoleArn, authRoleArn, region)
        {
        }

        public DotnetCognitoAWSCredentials(string accountId, string identityPoolId, string unAuthRoleArn, string authRoleArn, IAmazonCognitoIdentity cibClient, IAmazonSecurityTokenService stsClient) : base(accountId, identityPoolId, unAuthRoleArn, authRoleArn, cibClient, stsClient)
        {
        }
    }
}
#endif