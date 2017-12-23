using Amazon.MobileAnalytics;
using Amazon.MobileAnalytics.Model;
using Amazon.Runtime;

namespace Sweet.Unity.Amazon.JavaScript
{
    public class JavaScriptMobileAnalyticsClient : IAmazonMobileAnalytics
    {
        public IClientConfig Config
        {
            get { throw new global::System.NotImplementedException(); }
        }

        public void PutEventsAsync(PutEventsRequest request, AmazonServiceCallback<PutEventsRequest, PutEventsResponse> callback, AsyncOptions options = null)
        {
            throw new System.NotImplementedException();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls
        private ICognitoAWSCredentials credentials;
        private string region;

        public JavaScriptMobileAnalyticsClient(ICognitoAWSCredentials credentials, string region)
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
        // ~JavaScriptMobileAnalyticsClient() {
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