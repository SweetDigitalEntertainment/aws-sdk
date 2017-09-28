namespace Sweet.Game.Amazon
{
    public interface ISQSClient
    {
        void ReceiveMessageAsync(SQSRecieveMessageRequest request, ServiceCallback<SQSRecieveMessageRequest, SQSReceiveMessageResponse> callback);


        void DeleteMessageAsync(SQSDeleteMessageRequest request, ServiceCallback<SQSDeleteMessageRequest, SQSDeleteMessageResponse> callback);


        void DeleteMessageBatchAsync(SQSDeleteMessageBatchRequest request, ServiceCallback<SQSDeleteMessageBatchRequest, SQSDeleteMessageBatchResponse> callback);
    }
}