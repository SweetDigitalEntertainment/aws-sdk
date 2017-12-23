using System;
using Amazon.CognitoIdentityProvider;
using Amazon.GameLift;
using Amazon.Kinesis;
using Amazon.Lambda;
using Amazon.MobileAnalytics;
using Amazon.S3;
using Amazon.SimpleNotificationService;
using Amazon.SQS;

namespace Sweet.Unity.Amazon
{
    public interface IAWSSDK
    {
        IAnonymousAWSCredentials CreateAnonymousAWSCredentials();
        ICognitoAWSCredentials CreateCognitoAWSCredentials(string identityPoolId, string region);
        IAmazonSQS CreateSQSClient(IAWSCredentials credentials, string region);
        IAmazonSQS CreateSQSClient(string awsAccessKeyId, string awsSecretAccessKey, string awsSessionToken, string region);
        IAmazonS3 CreateS3Client(IAWSCredentials credentials, string region);
        IAmazonS3 CreateS3Client(string awsAccessKeyId, string awsSecretAccessKey, string awsSessionToken, string region);
        IAmazonCognitoIdentityProvider CreateCognitoIdentityProviderClient(IAWSCredentials credentials, string region);
        IAmazonCognitoIdentityProvider CreateCognitoIdentityProviderClient(string awsAccessKeyId, string awsSecretAccessKey, string awsSessionToken, string region);
        IAmazonSimpleNotificationService CreateSimpleNotificationServiceClient(IAWSCredentials credentials, string region);
        IAmazonSimpleNotificationService CreateSimpleNotificationServiceClient(string awsAccessKeyId, string awsSecretAccessKey, string awsSessionToken, string region);
        IAmazonGameLift CreateGameLiftClient(IAWSCredentials credentials, string region);
        IAmazonGameLift CreateGameLiftClient(string awsAccessKeyId, string awsSecretAccessKey, string awsSessionToken, string region);
        IAmazonKinesis CreateKinesisClient(IAWSCredentials credentials, string region);
        IAmazonKinesis CreateKinesisClient(string awsAccessKeyId, string awsSecretAccessKey, string awsSessionToken, string region);
        IAmazonLambda CreateLambdaClient(IAWSCredentials credentials, string region);
        IAmazonLambda CreateLambdaClient(string awsAccessKeyId, string awsSecretAccessKey, string awsSessionToken, string region);
        IAmazonMobileAnalytics CreateMobileAnalyticsClient(IAWSCredentials credentials, string region);
        IAmazonMobileAnalytics CreateMobileAnalyticsClient(string awsAccessKeyId, string awsSecretAccessKey, string awsSessionToken, string region);
    }
}