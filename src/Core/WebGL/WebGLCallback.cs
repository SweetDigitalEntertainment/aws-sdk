#if !UNITY_EDITOR && UNITY_WEBGL
namespace Sweet.Game.Amazon.WebGL
{
    public delegate void WebGLCallback(int callId, string response, int isError);
}
#endif