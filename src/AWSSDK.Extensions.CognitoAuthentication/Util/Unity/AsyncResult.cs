using System;

namespace Amazon.Extensions.CognitoAuthentication
{
    public class AsyncResult
    {
        public Exception Exception { get; private set; }


        public AsyncResult(Exception exception)
        {
            Exception = exception;
        }


        public void ThrowIfException()
        {
            if (Exception != null)
            {
                throw Exception;
            }
        }
    }


    public class AsyncResult<TResult> : AsyncResult
    {
        private TResult _result;


        public TResult Result
        {
            get
            {
                ThrowIfException();
                return _result;
            }
        }


        public AsyncResult(TResult result, Exception exception)
            : base(exception)
        {
            _result = result;
        }
    }


    public delegate void AsyncCallback(AsyncResult result);


    public delegate void AsyncCallback<TResult>(AsyncResult<TResult> result);
}