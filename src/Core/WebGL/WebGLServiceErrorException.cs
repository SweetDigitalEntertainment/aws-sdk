#if !UNITY_EDITOR && UNITY_WEBGL
using System;

namespace Sweet.Game.Amazon.WebGL
{
    public sealed class WebGLServiceErrorException : Exception
    {
        private WebGLServiceError _error;




        public override string StackTrace 
        {
             get { return _error.Stack; }
        }


        public override string Message
        {
             get { return _error.Message; }
        }




        public WebGLServiceErrorException(WebGLServiceError error)
        {
            _error = error;
        }




        public override string ToString()
        {
            if (string.IsNullOrEmpty(StackTrace))
            {
                return string.Format("{0}Exception: {1}", _error.Code, _error.Message);
            }

            return string.Format("{0}Exception: {1}\n{2}", _error.Code, _error.Message, StackTrace);
        }
    }
}
#endif