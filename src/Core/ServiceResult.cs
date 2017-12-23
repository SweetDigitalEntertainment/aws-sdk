using System;

namespace Sweet.Unity.Amazon
{
    public class ServiceResult<TRequest, TResponse>
        where TRequest : ServiceRequest
        where TResponse : ServiceResponse
    {
        public TRequest Request { get; private set; }
        public TResponse Response { get; private set; }
        public Exception Exception { get; private set; }


        public ServiceResult(TRequest request, TResponse response, Exception exception)
        {
            Request = request;
            Response = response;
            Exception = exception;
        }
    }
}