using Amazon.Kinesis;
using Amazon.Kinesis.Model;
using Amazon.Runtime;

namespace Sweet.Unity.Amazon.JavaScript
{
    public class JavaScriptKinesisClient : IAmazonKinesis
    {
        public IClientConfig Config
        {
            get { throw new global::System.NotImplementedException(); }
        }


        public void AddTagsToStreamAsync(AddTagsToStreamRequest request, AmazonServiceCallback<AddTagsToStreamRequest, AddTagsToStreamResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void CreateStreamAsync(CreateStreamRequest request, AmazonServiceCallback<CreateStreamRequest, CreateStreamResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void DecreaseStreamRetentionPeriodAsync(string streamName, int retentionPeriodHours, AmazonServiceCallback<DecreaseStreamRetentionPeriodRequest, DecreaseStreamRetentionPeriodResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void DecreaseStreamRetentionPeriodAsync(DecreaseStreamRetentionPeriodRequest request, AmazonServiceCallback<DecreaseStreamRetentionPeriodRequest, DecreaseStreamRetentionPeriodResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteStreamAsync(DeleteStreamRequest request, AmazonServiceCallback<DeleteStreamRequest, DeleteStreamResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void DescribeLimitsAsync(DescribeLimitsRequest request, AmazonServiceCallback<DescribeLimitsRequest, DescribeLimitsResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void DescribeStreamAsync(DescribeStreamRequest request, AmazonServiceCallback<DescribeStreamRequest, DescribeStreamResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void DescribeStreamSummaryAsync(DescribeStreamSummaryRequest request, AmazonServiceCallback<DescribeStreamSummaryRequest, DescribeStreamSummaryResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void DisableEnhancedMonitoringAsync(DisableEnhancedMonitoringRequest request, AmazonServiceCallback<DisableEnhancedMonitoringRequest, DisableEnhancedMonitoringResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void EnableEnhancedMonitoringAsync(EnableEnhancedMonitoringRequest request, AmazonServiceCallback<EnableEnhancedMonitoringRequest, EnableEnhancedMonitoringResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void GetRecordsAsync(GetRecordsRequest request, AmazonServiceCallback<GetRecordsRequest, GetRecordsResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void GetShardIteratorAsync(GetShardIteratorRequest request, AmazonServiceCallback<GetShardIteratorRequest, GetShardIteratorResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void IncreaseStreamRetentionPeriodAsync(string streamName, int retentionPeriodHours, AmazonServiceCallback<IncreaseStreamRetentionPeriodRequest, IncreaseStreamRetentionPeriodResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void IncreaseStreamRetentionPeriodAsync(IncreaseStreamRetentionPeriodRequest request, AmazonServiceCallback<IncreaseStreamRetentionPeriodRequest, IncreaseStreamRetentionPeriodResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void ListStreamsAsync(ListStreamsRequest request, AmazonServiceCallback<ListStreamsRequest, ListStreamsResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void ListTagsForStreamAsync(ListTagsForStreamRequest request, AmazonServiceCallback<ListTagsForStreamRequest, ListTagsForStreamResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void MergeShardsAsync(MergeShardsRequest request, AmazonServiceCallback<MergeShardsRequest, MergeShardsResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void PutRecordAsync(PutRecordRequest request, AmazonServiceCallback<PutRecordRequest, PutRecordResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void PutRecordsAsync(PutRecordsRequest request, AmazonServiceCallback<PutRecordsRequest, PutRecordsResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveTagsFromStreamAsync(RemoveTagsFromStreamRequest request, AmazonServiceCallback<RemoveTagsFromStreamRequest, RemoveTagsFromStreamResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void SplitShardAsync(SplitShardRequest request, AmazonServiceCallback<SplitShardRequest, SplitShardResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void StartStreamEncryptionAsync(StartStreamEncryptionRequest request, AmazonServiceCallback<StartStreamEncryptionRequest, StartStreamEncryptionResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void StopStreamEncryptionAsync(StopStreamEncryptionRequest request, AmazonServiceCallback<StopStreamEncryptionRequest, StopStreamEncryptionResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateShardCountAsync(UpdateShardCountRequest request, AmazonServiceCallback<UpdateShardCountRequest, UpdateShardCountResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls
        private ICognitoAWSCredentials credentials;
        private string region;

        public JavaScriptKinesisClient(ICognitoAWSCredentials credentials, string region)
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
        // ~JavaScriptKinesisClient() {
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