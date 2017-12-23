using System.Collections.Generic;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;

namespace Sweet.Unity.Amazon.JavaScript
{
    public class JavaScriptS3Client : IAmazonS3
    {
        public IClientConfig Config
        {
            get { throw new global::System.NotImplementedException(); }
        }

        public void AbortMultipartUploadAsync(string bucketName, string key, string uploadId, AmazonServiceCallback<AbortMultipartUploadRequest, AbortMultipartUploadResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void AbortMultipartUploadAsync(AbortMultipartUploadRequest request, AmazonServiceCallback<AbortMultipartUploadRequest, AbortMultipartUploadResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void CompleteMultipartUploadAsync(CompleteMultipartUploadRequest request, AmazonServiceCallback<CompleteMultipartUploadRequest, CompleteMultipartUploadResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void CopyObjectAsync(string sourceBucket, string sourceKey, string destinationBucket, string destinationKey, AmazonServiceCallback<CopyObjectRequest, CopyObjectResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void CopyObjectAsync(string sourceBucket, string sourceKey, string sourceVersionId, string destinationBucket, string destinationKey, AmazonServiceCallback<CopyObjectRequest, CopyObjectResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void CopyObjectAsync(CopyObjectRequest request, AmazonServiceCallback<CopyObjectRequest, CopyObjectResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void CopyPartAsync(string sourceBucket, string sourceKey, string destinationBucket, string destinationKey, string uploadId, AmazonServiceCallback<CopyPartRequest, CopyPartResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void CopyPartAsync(string sourceBucket, string sourceKey, string sourceVersionId, string destinationBucket, string destinationKey, string uploadId, AmazonServiceCallback<CopyPartRequest, CopyPartResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void CopyPartAsync(CopyPartRequest request, AmazonServiceCallback<CopyPartRequest, CopyPartResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteBucketAnalyticsConfigurationAsync(DeleteBucketAnalyticsConfigurationRequest request, AmazonServiceCallback<DeleteBucketAnalyticsConfigurationRequest, DeleteBucketAnalyticsConfigurationResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteBucketAsync(string bucketName, AmazonServiceCallback<DeleteBucketRequest, DeleteBucketResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteBucketAsync(DeleteBucketRequest request, AmazonServiceCallback<DeleteBucketRequest, DeleteBucketResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteBucketEncryptionAsync(DeleteBucketEncryptionRequest request, AmazonServiceCallback<DeleteBucketEncryptionRequest, DeleteBucketEncryptionResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteBucketInventoryConfigurationAsync(DeleteBucketInventoryConfigurationRequest request, AmazonServiceCallback<DeleteBucketInventoryConfigurationRequest, DeleteBucketInventoryConfigurationResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteBucketMetricsConfigurationAsync(DeleteBucketMetricsConfigurationRequest request, AmazonServiceCallback<DeleteBucketMetricsConfigurationRequest, DeleteBucketMetricsConfigurationResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteBucketPolicyAsync(string bucketName, AmazonServiceCallback<DeleteBucketPolicyRequest, DeleteBucketPolicyResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteBucketPolicyAsync(DeleteBucketPolicyRequest request, AmazonServiceCallback<DeleteBucketPolicyRequest, DeleteBucketPolicyResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteBucketReplicationAsync(DeleteBucketReplicationRequest request, AmazonServiceCallback<DeleteBucketReplicationRequest, DeleteBucketReplicationResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteBucketTaggingAsync(string bucketName, AmazonServiceCallback<DeleteBucketTaggingRequest, DeleteBucketTaggingResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteBucketTaggingAsync(DeleteBucketTaggingRequest request, AmazonServiceCallback<DeleteBucketTaggingRequest, DeleteBucketTaggingResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteBucketWebsiteAsync(string bucketName, AmazonServiceCallback<DeleteBucketWebsiteRequest, DeleteBucketWebsiteResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteBucketWebsiteAsync(DeleteBucketWebsiteRequest request, AmazonServiceCallback<DeleteBucketWebsiteRequest, DeleteBucketWebsiteResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCORSConfigurationAsync(string bucketName, AmazonServiceCallback<DeleteCORSConfigurationRequest, DeleteCORSConfigurationResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCORSConfigurationAsync(DeleteCORSConfigurationRequest request, AmazonServiceCallback<DeleteCORSConfigurationRequest, DeleteCORSConfigurationResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteLifecycleConfigurationAsync(string bucketName, AmazonServiceCallback<DeleteLifecycleConfigurationRequest, DeleteLifecycleConfigurationResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteLifecycleConfigurationAsync(DeleteLifecycleConfigurationRequest request, AmazonServiceCallback<DeleteLifecycleConfigurationRequest, DeleteLifecycleConfigurationResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteObjectAsync(string bucketName, string key, AmazonServiceCallback<DeleteObjectRequest, DeleteObjectResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteObjectAsync(string bucketName, string key, string versionId, AmazonServiceCallback<DeleteObjectRequest, DeleteObjectResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteObjectAsync(DeleteObjectRequest request, AmazonServiceCallback<DeleteObjectRequest, DeleteObjectResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteObjectsAsync(DeleteObjectsRequest request, AmazonServiceCallback<DeleteObjectsRequest, DeleteObjectsResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteObjectTaggingAsync(DeleteObjectTaggingRequest request, AmazonServiceCallback<DeleteObjectTaggingRequest, DeleteObjectTaggingResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void GetACLAsync(string bucketName, AmazonServiceCallback<GetACLRequest, GetACLResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void GetACLAsync(GetACLRequest request, AmazonServiceCallback<GetACLRequest, GetACLResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void GetBucketAccelerateConfigurationAsync(string bucketName, AmazonServiceCallback<GetBucketAccelerateConfigurationRequest, GetBucketAccelerateConfigurationResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void GetBucketAccelerateConfigurationAsync(GetBucketAccelerateConfigurationRequest request, AmazonServiceCallback<GetBucketAccelerateConfigurationRequest, GetBucketAccelerateConfigurationResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void GetBucketAnalyticsConfigurationAsync(GetBucketAnalyticsConfigurationRequest request, AmazonServiceCallback<GetBucketAnalyticsConfigurationRequest, GetBucketAnalyticsConfigurationResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void GetBucketEncryptionAsync(GetBucketEncryptionRequest request, AmazonServiceCallback<GetBucketEncryptionRequest, GetBucketEncryptionResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void GetBucketInventoryConfigurationAsync(GetBucketInventoryConfigurationRequest request, AmazonServiceCallback<GetBucketInventoryConfigurationRequest, GetBucketInventoryConfigurationResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void GetBucketLocationAsync(string bucketName, AmazonServiceCallback<GetBucketLocationRequest, GetBucketLocationResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void GetBucketLocationAsync(GetBucketLocationRequest request, AmazonServiceCallback<GetBucketLocationRequest, GetBucketLocationResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void GetBucketLoggingAsync(string bucketName, AmazonServiceCallback<GetBucketLoggingRequest, GetBucketLoggingResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void GetBucketLoggingAsync(GetBucketLoggingRequest request, AmazonServiceCallback<GetBucketLoggingRequest, GetBucketLoggingResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void GetBucketMetricsConfigurationAsync(GetBucketMetricsConfigurationRequest request, AmazonServiceCallback<GetBucketMetricsConfigurationRequest, GetBucketMetricsConfigurationResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void GetBucketNotificationAsync(string bucketName, AmazonServiceCallback<GetBucketNotificationRequest, GetBucketNotificationResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void GetBucketNotificationAsync(GetBucketNotificationRequest request, AmazonServiceCallback<GetBucketNotificationRequest, GetBucketNotificationResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void GetBucketPolicyAsync(string bucketName, AmazonServiceCallback<GetBucketPolicyRequest, GetBucketPolicyResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void GetBucketPolicyAsync(GetBucketPolicyRequest request, AmazonServiceCallback<GetBucketPolicyRequest, GetBucketPolicyResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void GetBucketReplicationAsync(GetBucketReplicationRequest request, AmazonServiceCallback<GetBucketReplicationRequest, GetBucketReplicationResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void GetBucketRequestPaymentAsync(string bucketName, AmazonServiceCallback<GetBucketRequestPaymentRequest, GetBucketRequestPaymentResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void GetBucketRequestPaymentAsync(GetBucketRequestPaymentRequest request, AmazonServiceCallback<GetBucketRequestPaymentRequest, GetBucketRequestPaymentResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void GetBucketTaggingAsync(GetBucketTaggingRequest request, AmazonServiceCallback<GetBucketTaggingRequest, GetBucketTaggingResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void GetBucketVersioningAsync(string bucketName, AmazonServiceCallback<GetBucketVersioningRequest, GetBucketVersioningResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void GetBucketVersioningAsync(GetBucketVersioningRequest request, AmazonServiceCallback<GetBucketVersioningRequest, GetBucketVersioningResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void GetBucketWebsiteAsync(string bucketName, AmazonServiceCallback<GetBucketWebsiteRequest, GetBucketWebsiteResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void GetBucketWebsiteAsync(GetBucketWebsiteRequest request, AmazonServiceCallback<GetBucketWebsiteRequest, GetBucketWebsiteResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void GetCORSConfigurationAsync(string bucketName, AmazonServiceCallback<GetCORSConfigurationRequest, GetCORSConfigurationResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void GetCORSConfigurationAsync(GetCORSConfigurationRequest request, AmazonServiceCallback<GetCORSConfigurationRequest, GetCORSConfigurationResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void GetLifecycleConfigurationAsync(string bucketName, AmazonServiceCallback<GetLifecycleConfigurationRequest, GetLifecycleConfigurationResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void GetLifecycleConfigurationAsync(GetLifecycleConfigurationRequest request, AmazonServiceCallback<GetLifecycleConfigurationRequest, GetLifecycleConfigurationResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void GetObjectAsync(string bucketName, string key, AmazonServiceCallback<GetObjectRequest, GetObjectResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void GetObjectAsync(string bucketName, string key, string versionId, AmazonServiceCallback<GetObjectRequest, GetObjectResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void GetObjectAsync(GetObjectRequest request, AmazonServiceCallback<GetObjectRequest, GetObjectResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void GetObjectMetadataAsync(string bucketName, string key, AmazonServiceCallback<GetObjectMetadataRequest, GetObjectMetadataResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void GetObjectMetadataAsync(string bucketName, string key, string versionId, AmazonServiceCallback<GetObjectMetadataRequest, GetObjectMetadataResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void GetObjectMetadataAsync(GetObjectMetadataRequest request, AmazonServiceCallback<GetObjectMetadataRequest, GetObjectMetadataResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void GetObjectTaggingAsync(GetObjectTaggingRequest request, AmazonServiceCallback<GetObjectTaggingRequest, GetObjectTaggingResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void GetObjectTorrentAsync(string bucketName, string key, AmazonServiceCallback<GetObjectTorrentRequest, GetObjectTorrentResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void GetObjectTorrentAsync(GetObjectTorrentRequest request, AmazonServiceCallback<GetObjectTorrentRequest, GetObjectTorrentResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void InitiateMultipartUploadAsync(string bucketName, string key, AmazonServiceCallback<InitiateMultipartUploadRequest, InitiateMultipartUploadResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void InitiateMultipartUploadAsync(InitiateMultipartUploadRequest request, AmazonServiceCallback<InitiateMultipartUploadRequest, InitiateMultipartUploadResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void ListBucketAnalyticsConfigurationsAsync(ListBucketAnalyticsConfigurationsRequest request, AmazonServiceCallback<ListBucketAnalyticsConfigurationsRequest, ListBucketAnalyticsConfigurationsResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void ListBucketInventoryConfigurationsAsync(ListBucketInventoryConfigurationsRequest request, AmazonServiceCallback<ListBucketInventoryConfigurationsRequest, ListBucketInventoryConfigurationsResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void ListBucketMetricsConfigurationsAsync(ListBucketMetricsConfigurationsRequest request, AmazonServiceCallback<ListBucketMetricsConfigurationsRequest, ListBucketMetricsConfigurationsResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void ListBucketsAsync(ListBucketsRequest request, AmazonServiceCallback<ListBucketsRequest, ListBucketsResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void ListMultipartUploadsAsync(string bucketName, AmazonServiceCallback<ListMultipartUploadsRequest, ListMultipartUploadsResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void ListMultipartUploadsAsync(string bucketName, string prefix, AmazonServiceCallback<ListMultipartUploadsRequest, ListMultipartUploadsResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void ListMultipartUploadsAsync(ListMultipartUploadsRequest request, AmazonServiceCallback<ListMultipartUploadsRequest, ListMultipartUploadsResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void ListObjectsAsync(string bucketName, AmazonServiceCallback<ListObjectsRequest, ListObjectsResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void ListObjectsAsync(string bucketName, string prefix, AmazonServiceCallback<ListObjectsRequest, ListObjectsResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void ListObjectsAsync(ListObjectsRequest request, AmazonServiceCallback<ListObjectsRequest, ListObjectsResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void ListObjectsV2Async(ListObjectsV2Request request, AmazonServiceCallback<ListObjectsV2Request, ListObjectsV2Response> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void ListPartsAsync(string bucketName, string key, string uploadId, AmazonServiceCallback<ListPartsRequest, ListPartsResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void ListPartsAsync(ListPartsRequest request, AmazonServiceCallback<ListPartsRequest, ListPartsResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void ListVersionsAsync(string bucketName, AmazonServiceCallback<ListVersionsRequest, ListVersionsResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void ListVersionsAsync(string bucketName, string prefix, AmazonServiceCallback<ListVersionsRequest, ListVersionsResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void ListVersionsAsync(ListVersionsRequest request, AmazonServiceCallback<ListVersionsRequest, ListVersionsResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void PostObjectAsync(PostObjectRequest request, AmazonServiceCallback<PostObjectRequest, PostObjectResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void PutACLAsync(PutACLRequest request, AmazonServiceCallback<PutACLRequest, PutACLResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void PutBucketAccelerateConfigurationAsync(PutBucketAccelerateConfigurationRequest request, AmazonServiceCallback<PutBucketAccelerateConfigurationRequest, PutBucketAccelerateConfigurationResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void PutBucketAnalyticsConfigurationAsync(PutBucketAnalyticsConfigurationRequest request, AmazonServiceCallback<PutBucketAnalyticsConfigurationRequest, PutBucketAnalyticsConfigurationResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void PutBucketAsync(string bucketName, AmazonServiceCallback<PutBucketRequest, PutBucketResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void PutBucketAsync(PutBucketRequest request, AmazonServiceCallback<PutBucketRequest, PutBucketResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void PutBucketEncryptionAsync(PutBucketEncryptionRequest request, AmazonServiceCallback<PutBucketEncryptionRequest, PutBucketEncryptionResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void PutBucketInventoryConfigurationAsync(PutBucketInventoryConfigurationRequest request, AmazonServiceCallback<PutBucketInventoryConfigurationRequest, PutBucketInventoryConfigurationResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void PutBucketLoggingAsync(PutBucketLoggingRequest request, AmazonServiceCallback<PutBucketLoggingRequest, PutBucketLoggingResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void PutBucketMetricsConfigurationAsync(PutBucketMetricsConfigurationRequest request, AmazonServiceCallback<PutBucketMetricsConfigurationRequest, PutBucketMetricsConfigurationResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void PutBucketNotificationAsync(PutBucketNotificationRequest request, AmazonServiceCallback<PutBucketNotificationRequest, PutBucketNotificationResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void PutBucketPolicyAsync(string bucketName, string policy, AmazonServiceCallback<PutBucketPolicyRequest, PutBucketPolicyResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void PutBucketPolicyAsync(string bucketName, string policy, string contentMD5, AmazonServiceCallback<PutBucketPolicyRequest, PutBucketPolicyResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void PutBucketPolicyAsync(PutBucketPolicyRequest request, AmazonServiceCallback<PutBucketPolicyRequest, PutBucketPolicyResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void PutBucketReplicationAsync(PutBucketReplicationRequest request, AmazonServiceCallback<PutBucketReplicationRequest, PutBucketReplicationResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void PutBucketRequestPaymentAsync(string bucketName, RequestPaymentConfiguration requestPaymentConfiguration, AmazonServiceCallback<PutBucketRequestPaymentRequest, PutBucketRequestPaymentResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void PutBucketRequestPaymentAsync(PutBucketRequestPaymentRequest request, AmazonServiceCallback<PutBucketRequestPaymentRequest, PutBucketRequestPaymentResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void PutBucketTaggingAsync(string bucketName, List<Tag> tagSet, AmazonServiceCallback<PutBucketTaggingRequest, PutBucketTaggingResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void PutBucketTaggingAsync(PutBucketTaggingRequest request, AmazonServiceCallback<PutBucketTaggingRequest, PutBucketTaggingResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void PutBucketVersioningAsync(PutBucketVersioningRequest request, AmazonServiceCallback<PutBucketVersioningRequest, PutBucketVersioningResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void PutBucketWebsiteAsync(string bucketName, WebsiteConfiguration websiteConfiguration, AmazonServiceCallback<PutBucketWebsiteRequest, PutBucketWebsiteResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void PutBucketWebsiteAsync(PutBucketWebsiteRequest request, AmazonServiceCallback<PutBucketWebsiteRequest, PutBucketWebsiteResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void PutCORSConfigurationAsync(string bucketName, CORSConfiguration configuration, AmazonServiceCallback<PutCORSConfigurationRequest, PutCORSConfigurationResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void PutCORSConfigurationAsync(PutCORSConfigurationRequest request, AmazonServiceCallback<PutCORSConfigurationRequest, PutCORSConfigurationResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void PutLifecycleConfigurationAsync(string bucketName, LifecycleConfiguration configuration, AmazonServiceCallback<PutLifecycleConfigurationRequest, PutLifecycleConfigurationResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void PutLifecycleConfigurationAsync(PutLifecycleConfigurationRequest request, AmazonServiceCallback<PutLifecycleConfigurationRequest, PutLifecycleConfigurationResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void PutObjectAsync(PutObjectRequest request, AmazonServiceCallback<PutObjectRequest, PutObjectResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void PutObjectTaggingAsync(PutObjectTaggingRequest request, AmazonServiceCallback<PutObjectTaggingRequest, PutObjectTaggingResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void RestoreObjectAsync(string bucketName, string key, AmazonServiceCallback<RestoreObjectRequest, RestoreObjectResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void RestoreObjectAsync(string bucketName, string key, int days, AmazonServiceCallback<RestoreObjectRequest, RestoreObjectResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void RestoreObjectAsync(string bucketName, string key, string versionId, AmazonServiceCallback<RestoreObjectRequest, RestoreObjectResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void RestoreObjectAsync(string bucketName, string key, string versionId, int days, AmazonServiceCallback<RestoreObjectRequest, RestoreObjectResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void RestoreObjectAsync(RestoreObjectRequest request, AmazonServiceCallback<RestoreObjectRequest, RestoreObjectResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void UploadPartAsync(UploadPartRequest request, AmazonServiceCallback<UploadPartRequest, UploadPartResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls
        private ICognitoAWSCredentials credentials;
        private string region;

        public JavaScriptS3Client(ICognitoAWSCredentials credentials, string region)
        {
            this.credentials = credentials;
            this.region = region;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~JavaScriptS3Client() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}