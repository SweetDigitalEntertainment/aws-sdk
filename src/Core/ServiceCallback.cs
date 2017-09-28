namespace Sweet.Game.Amazon
{
    public delegate void ServiceCallback<TRequest, TResponse>(ServiceResult<TRequest, TResponse> responseObject)
        where TRequest : ServiceRequest
        where TResponse : ServiceResponse;
}