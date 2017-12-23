#if !UNITY_EDITOR && UNITY_WEBGL
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Amazon.CognitoIdentityProvider;
using Amazon.GameLift;
using Amazon.Kinesis;
using Amazon.Lambda;
using Amazon.MobileAnalytics;
using Amazon.S3;
using Amazon.SimpleNotificationService;
using Amazon.SQS;
using AOT;
using UnityEngine;
using UnityEngine.Events;

namespace Sweet.Unity.Amazon.JavaScript
{
    public sealed class JavaScriptAWSSDK : MonoBehaviour, IAWSSDK
    {
        private void Awake()
        {
            AWS_Initialize();
        }


        [DllImport("__Internal")]
        private static extern void AWS_Initialize();


        ICognitoAWSCredentials IAWSSDK.CreateCognitoIdentityCredentials(string identityPoolId, string region)
        {
            throw new NotImplementedException();
        }

        public IAmazonSQS CreateSQSClient(IAWSCredentials credentials, string region)
        {
            return new JavaScriptSQSClient(credentials, region);
        }

        public IAmazonS3 CreateS3Client(IAWSCredentials credentials, string region)
        {
            return new JavaScriptS3Client(credentials, region);
        }

        public IAmazonCognitoIdentityProvider CreateCognitoIdentityProviderClient(IAWSCredentials credentials, string region)
        {
            return new JavaScriptCognitoIdentityProviderClient(credentials, region);
        }

        public IAmazonSimpleNotificationService CreateSimpleNotificationServiceClient(IAWSCredentials credentials, string region)
        {
            return new JavaScriptSimpleNotificationServiceClient(credentials, region);
        }

        public IAmazonGameLift CreateGameLiftClient(IAWSCredentials credentials, string region)
        {
            return new JavaScriptGameLiftClient(credentials, region);
        }

        public IAmazonKinesis CreateKinesisClient(IAWSCredentials credentials, string region)
        {
            return new JavaScriptKinesisClient(credentials, region);
        }

        public IAmazonLambda CreateLambdaClient(IAWSCredentials credentials, string region)
        {
            return new JavaScriptLambdaClient(credentials, region);
        }

        public IAmazonMobileAnalytics CreateMobileAnalyticsClient(IAWSCredentials credentials, string region)
        {
            return new JavaScriptMobileAnalyticsClient(credentials, region);
        }
    }
}
#endif