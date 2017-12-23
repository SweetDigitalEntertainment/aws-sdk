using System;

namespace Sweet.Unity.Amazon
{
    public interface ICognitoIdentityResult<TResponse>
    {
        Exception Exception { get; }

        TResponse Response { get; }
    }


    public sealed class CognitoIdentityResult<TResponse> : ICognitoIdentityResult<TResponse>
    {
        public Exception Exception
        {
            get; private set;
        }

        public TResponse Response
        {
            get; private set;
        }




        public CognitoIdentityResult(Exception exception)
        {
            Exception = exception;
            Response = default(TResponse);
        }

        public CognitoIdentityResult(TResponse response)
        {
            Exception = null;
            Response = response;
        }
    }
}