using Amazon.CognitoIdentityProvider;
using Amazon.GameLift;
using Amazon.Kinesis;
using Amazon.Lambda;
using Amazon.MobileAnalytics;
using Amazon.S3;
using Amazon.SimpleNotificationService;
using Amazon.SQS;
using UnityEngine;

namespace Sweet.Unity.Amazon
{
    public sealed class AWSSDK : MonoBehaviour, IAWSSDK
    {
        private IAWSSDK _sdk;



        private void Awake()
        {
#if !UNITY_EDITOR && UNITY_WEBGL
            _service = gameObject.AddComponent<WebGL.WebGLAWSService>();
#else
            _sdk = gameObject.AddComponent<Dotnet.DotnetAWSSDK>();
#endif
        }


        public ICognitoAWSCredentials CreateCognitoAWSCredentials(string identityPoolId, string region)
        {
            return _sdk.CreateCognitoAWSCredentials(identityPoolId, region);
        }

        public IAmazonSQS CreateSQSClient(IAWSCredentials credentials, string region)
        {
            return _sdk.CreateSQSClient(credentials, region);
        }

        public IAmazonS3 CreateS3Client(IAWSCredentials credentials, string region)
        {
            return _sdk.CreateS3Client(credentials, region);
        }

        public IAmazonCognitoIdentityProvider CreateCognitoIdentityProviderClient(IAWSCredentials credentials, string region)
        {
            return _sdk.CreateCognitoIdentityProviderClient(credentials, region);
        }

        public IAmazonSimpleNotificationService CreateSimpleNotificationServiceClient(IAWSCredentials credentials, string region)
        {
            return _sdk.CreateSimpleNotificationServiceClient(credentials, region);
        }

        public IAmazonGameLift CreateGameLiftClient(IAWSCredentials credentials, string region)
        {
            return _sdk.CreateGameLiftClient(credentials, region);
        }

        public IAmazonKinesis CreateKinesisClient(IAWSCredentials credentials, string region)
        {
            return _sdk.CreateKinesisClient(credentials, region);
        }

        public IAmazonLambda CreateLambdaClient(IAWSCredentials credentials, string region)
        {
            return _sdk.CreateLambdaClient(credentials, region);
        }

        public IAmazonMobileAnalytics CreateMobileAnalyticsClient(IAWSCredentials credentials, string region)
        {
            return _sdk.CreateMobileAnalyticsClient(credentials, region);
        }

        public IAmazonSQS CreateSQSClient(string awsAccessKeyId, string awsSecretAccessKey, string awsSessionToken, string region)
        {
            return _sdk.CreateSQSClient(awsAccessKeyId, awsSecretAccessKey, awsSessionToken, region);
        }

        public IAmazonS3 CreateS3Client(string awsAccessKeyId, string awsSecretAccessKey, string awsSessionToken, string region)
        {
            return _sdk.CreateS3Client(awsAccessKeyId, awsSecretAccessKey, awsSessionToken, region);
        }

        public IAmazonCognitoIdentityProvider CreateCognitoIdentityProviderClient(string awsAccessKeyId, string awsSecretAccessKey, string awsSessionToken, string region)
        {
            return _sdk.CreateCognitoIdentityProviderClient(awsAccessKeyId, awsSecretAccessKey, awsSessionToken, region);
        }

        public IAmazonSimpleNotificationService CreateSimpleNotificationServiceClient(string awsAccessKeyId, string awsSecretAccessKey, string awsSessionToken, string region)
        {
            return _sdk.CreateSimpleNotificationServiceClient(awsAccessKeyId, awsSecretAccessKey, awsSessionToken, region);
        }

        public IAmazonGameLift CreateGameLiftClient(string awsAccessKeyId, string awsSecretAccessKey, string awsSessionToken, string region)
        {
            return _sdk.CreateGameLiftClient(awsAccessKeyId, awsSecretAccessKey, awsSessionToken, region);
        }

        public IAmazonKinesis CreateKinesisClient(string awsAccessKeyId, string awsSecretAccessKey, string awsSessionToken, string region)
        {
            return _sdk.CreateKinesisClient(awsAccessKeyId, awsSecretAccessKey, awsSessionToken, region);
        }

        public IAmazonLambda CreateLambdaClient(string awsAccessKeyId, string awsSecretAccessKey, string awsSessionToken, string region)
        {
            return _sdk.CreateLambdaClient(awsAccessKeyId, awsSecretAccessKey, awsSessionToken, region);
        }

        public IAmazonMobileAnalytics CreateMobileAnalyticsClient(string awsAccessKeyId, string awsSecretAccessKey, string awsSessionToken, string region)
        {
            return _sdk.CreateMobileAnalyticsClient(awsAccessKeyId, awsSecretAccessKey, awsSessionToken, region);
        }

        public IAnonymousAWSCredentials CreateAnonymousAWSCredentials()
        {
            return _sdk.CreateAnonymousAWSCredentials();
        }
    }
}