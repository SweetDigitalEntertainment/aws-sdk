namespace Sweet.Game.Amazon
{
    public interface ISQSClient
    {
        void ReceiveMessageAsync(SQSReceiveMessageRequest request, ServiceCallback<SQSReceiveMessageRequest, SQSReceiveMessageResponse> callback);


        void DeleteMessageAsync(SQSDeleteMessageRequest request, ServiceCallback<SQSDeleteMessageRequest, SQSDeleteMessageResponse> callback);


        void DeleteMessageBatchAsync(SQSDeleteMessageBatchRequest request, ServiceCallback<SQSDeleteMessageBatchRequest, SQSDeleteMessageBatchResponse> callback);
    }
}