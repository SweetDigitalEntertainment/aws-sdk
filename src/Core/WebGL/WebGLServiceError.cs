#if !UNITY_EDITOR && UNITY_WEBGL
namespace Sweet.Game.Amazon.WebGL
{
    public sealed class WebGLServiceError
    {
        public string Message { get; set; }
        public string Code { get; set; }
        public string Time { get; set; }
        public string Stack { get; set; }
        public string RequestId {get; set; }
        public int StatusCode { get; set; }
    }
}
#endif