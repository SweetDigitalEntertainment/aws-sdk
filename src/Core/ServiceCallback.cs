namespace Sweet.Unity.Amazon
{
    public delegate void ServiceCallback<TRequest, TResponse>(ServiceResult<TRequest, TResponse> result)
        where TRequest : ServiceRequest
        where TResponse : ServiceResponse;
}