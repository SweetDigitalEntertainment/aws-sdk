#if UNITY_EDITOR || !UNITY_WEBGL
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using AOT;
using UnityEngine;
using UnityEngine.Events;
using Amazon;
using Amazon.CognitoIdentity;
using Amazon.SQS;
using Amazon.SimpleNotificationService;
using Amazon.CognitoIdentityProvider;
using Amazon.S3;
using Amazon.Runtime;
using Amazon.GameLift;
using Amazon.Kinesis;
using Amazon.Lambda;
using Amazon.MobileAnalytics;

namespace Sweet.Unity.Amazon.Dotnet
{
    public sealed class DotnetAWSSDK : MonoBehaviour, IAWSSDK
    {
        private void Awake()
        {
            UnityInitializer.AttachToGameObject(gameObject);
            AWSConfigs.HttpClient = AWSConfigs.HttpClientOption.UnityWebRequest;
        }


        public IAnonymousAWSCredentials CreateAnonymousAWSCredentials()
        {
            return new DotnetAnonymousAWSCredentials();
        }
        public ICognitoAWSCredentials CreateCognitoAWSCredentials(string identityPoolId, string region)
        {
            return new DotnetCognitoAWSCredentials(identityPoolId, RegionEndpoint.GetBySystemName(region));
        }

        public IAmazonSQS CreateSQSClient(IAWSCredentials credentials, string region)
        {
            return new AmazonSQSClient((AWSCredentials)credentials, RegionEndpoint.GetBySystemName(region));
        }

        public IAmazonSQS CreateSQSClient(string awsAccessKeyId, string awsSecretAccessKey, string awsSessionToken, string region)
        {
            return new AmazonSQSClient(awsAccessKeyId, awsSecretAccessKey, awsSessionToken, RegionEndpoint.GetBySystemName(region));
        }

        public IAmazonS3 CreateS3Client(IAWSCredentials credentials, string region)
        {
            return new AmazonS3Client((AWSCredentials)credentials, RegionEndpoint.GetBySystemName(region));
        }

        public IAmazonS3 CreateS3Client(string awsAccessKeyId, string awsSecretAccessKey, string awsSessionToken, string region)
        {
            return new AmazonS3Client(awsAccessKeyId, awsSecretAccessKey, awsSessionToken, RegionEndpoint.GetBySystemName(region));
        }

        public IAmazonCognitoIdentityProvider CreateCognitoIdentityProviderClient(IAWSCredentials credentials, string region)
        {
            return new AmazonCognitoIdentityProviderClient((AWSCredentials)credentials, RegionEndpoint.GetBySystemName(region));
        }

        public IAmazonCognitoIdentityProvider CreateCognitoIdentityProviderClient(string awsAccessKeyId, string awsSecretAccessKey, string awsSessionToken, string region)
        {
            return new AmazonCognitoIdentityProviderClient(awsAccessKeyId, awsSecretAccessKey, awsSessionToken, RegionEndpoint.GetBySystemName(region));
        }

        public IAmazonSimpleNotificationService CreateSimpleNotificationServiceClient(IAWSCredentials credentials, string region)
        {
            return new AmazonSimpleNotificationServiceClient((AWSCredentials)credentials, RegionEndpoint.GetBySystemName(region));
        }

        public IAmazonSimpleNotificationService CreateSimpleNotificationServiceClient(string awsAccessKeyId, string awsSecretAccessKey, string awsSessionToken, string region)
        {
            return new AmazonSimpleNotificationServiceClient(awsAccessKeyId, awsSecretAccessKey, awsSessionToken, RegionEndpoint.GetBySystemName(region));
        }

        public IAmazonGameLift CreateGameLiftClient(IAWSCredentials credentials, string region)
        {
            return new AmazonGameLiftClient((AWSCredentials)credentials, RegionEndpoint.GetBySystemName(region));
        }

        public IAmazonGameLift CreateGameLiftClient(string awsAccessKeyId, string awsSecretAccessKey, string awsSessionToken, string region)
        {
            return new AmazonGameLiftClient(awsAccessKeyId, awsSecretAccessKey, awsSessionToken, RegionEndpoint.GetBySystemName(region));
        }

        public IAmazonKinesis CreateKinesisClient(IAWSCredentials credentials, string region)
        {
            return new AmazonKinesisClient((AWSCredentials)credentials, RegionEndpoint.GetBySystemName(region));
        }

        public IAmazonKinesis CreateKinesisClient(string awsAccessKeyId, string awsSecretAccessKey, string awsSessionToken, string region)
        {
            return new AmazonKinesisClient(awsAccessKeyId, awsSecretAccessKey, awsSessionToken, RegionEndpoint.GetBySystemName(region));
        }

        public IAmazonLambda CreateLambdaClient(IAWSCredentials credentials, string region)
        {
            return new AmazonLambdaClient((AWSCredentials)credentials, RegionEndpoint.GetBySystemName(region));
        }

        public IAmazonLambda CreateLambdaClient(string awsAccessKeyId, string awsSecretAccessKey, string awsSessionToken, string region)
        {
            return new AmazonLambdaClient(awsAccessKeyId, awsSecretAccessKey, awsSessionToken, RegionEndpoint.GetBySystemName(region));
        }

        public IAmazonMobileAnalytics CreateMobileAnalyticsClient(IAWSCredentials credentials, string region)
        {
            return new AmazonMobileAnalyticsClient((AWSCredentials)credentials, RegionEndpoint.GetBySystemName(region));
        }

        public IAmazonMobileAnalytics CreateMobileAnalyticsClient(string awsAccessKeyId, string awsSecretAccessKey, string awsSessionToken, string region)
        {
            return new AmazonMobileAnalyticsClient(awsAccessKeyId, awsSecretAccessKey, awsSessionToken, RegionEndpoint.GetBySystemName(region));
        }
    }
}
#endif