#if !UNITY_EDITOR && UNITY_WEBGL
namespace Sweet.Unity.Amazon.Javascript
{
    public delegate void WebGLCallback(int callId, string response, int isError);
}
#endif