using System.Collections.Generic;
using Amazon.Runtime;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;

namespace Sweet.Unity.Amazon.JavaScript
{
    public sealed class JavaScriptSimpleNotificationServiceClient : IAmazonSimpleNotificationService
    {
        public IClientConfig Config
        {
            get { throw new global::System.NotImplementedException(); }
        }

        public void AddPermissionAsync(string topicArn, string label, List<string> awsAccountId, List<string> actionName, AmazonServiceCallback<AddPermissionRequest, AddPermissionResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void AddPermissionAsync(AddPermissionRequest request, AmazonServiceCallback<AddPermissionRequest, AddPermissionResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void CheckIfPhoneNumberIsOptedOutAsync(CheckIfPhoneNumberIsOptedOutRequest request, AmazonServiceCallback<CheckIfPhoneNumberIsOptedOutRequest, CheckIfPhoneNumberIsOptedOutResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void ConfirmSubscriptionAsync(string topicArn, string token, string authenticateOnUnsubscribe, AmazonServiceCallback<ConfirmSubscriptionRequest, ConfirmSubscriptionResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void ConfirmSubscriptionAsync(string topicArn, string token, AmazonServiceCallback<ConfirmSubscriptionRequest, ConfirmSubscriptionResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void ConfirmSubscriptionAsync(ConfirmSubscriptionRequest request, AmazonServiceCallback<ConfirmSubscriptionRequest, ConfirmSubscriptionResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void CreatePlatformApplicationAsync(CreatePlatformApplicationRequest request, AmazonServiceCallback<CreatePlatformApplicationRequest, CreatePlatformApplicationResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void CreatePlatformEndpointAsync(CreatePlatformEndpointRequest request, AmazonServiceCallback<CreatePlatformEndpointRequest, CreatePlatformEndpointResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void CreateTopicAsync(string name, AmazonServiceCallback<CreateTopicRequest, CreateTopicResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void CreateTopicAsync(CreateTopicRequest request, AmazonServiceCallback<CreateTopicRequest, CreateTopicResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteEndpointAsync(DeleteEndpointRequest request, AmazonServiceCallback<DeleteEndpointRequest, DeleteEndpointResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void DeletePlatformApplicationAsync(DeletePlatformApplicationRequest request, AmazonServiceCallback<DeletePlatformApplicationRequest, DeletePlatformApplicationResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteTopicAsync(string topicArn, AmazonServiceCallback<DeleteTopicRequest, DeleteTopicResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteTopicAsync(DeleteTopicRequest request, AmazonServiceCallback<DeleteTopicRequest, DeleteTopicResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void GetEndpointAttributesAsync(GetEndpointAttributesRequest request, AmazonServiceCallback<GetEndpointAttributesRequest, GetEndpointAttributesResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void GetPlatformApplicationAttributesAsync(GetPlatformApplicationAttributesRequest request, AmazonServiceCallback<GetPlatformApplicationAttributesRequest, GetPlatformApplicationAttributesResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void GetSMSAttributesAsync(GetSMSAttributesRequest request, AmazonServiceCallback<GetSMSAttributesRequest, GetSMSAttributesResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void GetSubscriptionAttributesAsync(string subscriptionArn, AmazonServiceCallback<GetSubscriptionAttributesRequest, GetSubscriptionAttributesResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void GetSubscriptionAttributesAsync(GetSubscriptionAttributesRequest request, AmazonServiceCallback<GetSubscriptionAttributesRequest, GetSubscriptionAttributesResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void GetTopicAttributesAsync(string topicArn, AmazonServiceCallback<GetTopicAttributesRequest, GetTopicAttributesResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void GetTopicAttributesAsync(GetTopicAttributesRequest request, AmazonServiceCallback<GetTopicAttributesRequest, GetTopicAttributesResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void ListEndpointsByPlatformApplicationAsync(ListEndpointsByPlatformApplicationRequest request, AmazonServiceCallback<ListEndpointsByPlatformApplicationRequest, ListEndpointsByPlatformApplicationResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void ListPhoneNumbersOptedOutAsync(ListPhoneNumbersOptedOutRequest request, AmazonServiceCallback<ListPhoneNumbersOptedOutRequest, ListPhoneNumbersOptedOutResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void ListPlatformApplicationsAsync(ListPlatformApplicationsRequest request, AmazonServiceCallback<ListPlatformApplicationsRequest, ListPlatformApplicationsResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void ListSubscriptionsAsync(string nextToken, AmazonServiceCallback<ListSubscriptionsRequest, ListSubscriptionsResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void ListSubscriptionsAsync(ListSubscriptionsRequest request, AmazonServiceCallback<ListSubscriptionsRequest, ListSubscriptionsResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void ListSubscriptionsByTopicAsync(string topicArn, string nextToken, AmazonServiceCallback<ListSubscriptionsByTopicRequest, ListSubscriptionsByTopicResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void ListSubscriptionsByTopicAsync(string topicArn, AmazonServiceCallback<ListSubscriptionsByTopicRequest, ListSubscriptionsByTopicResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void ListSubscriptionsByTopicAsync(ListSubscriptionsByTopicRequest request, AmazonServiceCallback<ListSubscriptionsByTopicRequest, ListSubscriptionsByTopicResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void ListTopicsAsync(string nextToken, AmazonServiceCallback<ListTopicsRequest, ListTopicsResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void ListTopicsAsync(ListTopicsRequest request, AmazonServiceCallback<ListTopicsRequest, ListTopicsResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void OptInPhoneNumberAsync(OptInPhoneNumberRequest request, AmazonServiceCallback<OptInPhoneNumberRequest, OptInPhoneNumberResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void PublishAsync(string topicArn, string message, AmazonServiceCallback<PublishRequest, PublishResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void PublishAsync(string topicArn, string message, string subject, AmazonServiceCallback<PublishRequest, PublishResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void PublishAsync(PublishRequest request, AmazonServiceCallback<PublishRequest, PublishResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void RemovePermissionAsync(string topicArn, string label, AmazonServiceCallback<RemovePermissionRequest, RemovePermissionResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void RemovePermissionAsync(RemovePermissionRequest request, AmazonServiceCallback<RemovePermissionRequest, RemovePermissionResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void SetEndpointAttributesAsync(SetEndpointAttributesRequest request, AmazonServiceCallback<SetEndpointAttributesRequest, SetEndpointAttributesResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void SetPlatformApplicationAttributesAsync(SetPlatformApplicationAttributesRequest request, AmazonServiceCallback<SetPlatformApplicationAttributesRequest, SetPlatformApplicationAttributesResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void SetSMSAttributesAsync(SetSMSAttributesRequest request, AmazonServiceCallback<SetSMSAttributesRequest, SetSMSAttributesResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void SetSubscriptionAttributesAsync(string subscriptionArn, string attributeName, string attributeValue, AmazonServiceCallback<SetSubscriptionAttributesRequest, SetSubscriptionAttributesResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void SetSubscriptionAttributesAsync(SetSubscriptionAttributesRequest request, AmazonServiceCallback<SetSubscriptionAttributesRequest, SetSubscriptionAttributesResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void SetTopicAttributesAsync(string topicArn, string attributeName, string attributeValue, AmazonServiceCallback<SetTopicAttributesRequest, SetTopicAttributesResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void SetTopicAttributesAsync(SetTopicAttributesRequest request, AmazonServiceCallback<SetTopicAttributesRequest, SetTopicAttributesResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void SubscribeAsync(string topicArn, string protocol, string endpoint, AmazonServiceCallback<SubscribeRequest, SubscribeResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void SubscribeAsync(SubscribeRequest request, AmazonServiceCallback<SubscribeRequest, SubscribeResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void UnsubscribeAsync(string subscriptionArn, AmazonServiceCallback<UnsubscribeRequest, UnsubscribeResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void UnsubscribeAsync(UnsubscribeRequest request, AmazonServiceCallback<UnsubscribeRequest, UnsubscribeResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls
        private ICognitoAWSCredentials credentials;
        private string region;

        public JavaScriptSimpleNotificationServiceClient(ICognitoAWSCredentials credentials, string region)
        {
            this.credentials = credentials;
            this.region = region;
        }

        void Dispose(bool disposing)
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
        // ~JavaScriptSimpleNotificationServiceClient() {
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