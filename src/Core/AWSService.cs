using UnityEngine;

namespace Sweet.Game.Amazon
{
    public sealed class AWSService : MonoBehaviour, IAWSService
    {
        private IAWSService _service;



        private void Awake()
        {
#if !UNITY_EDITOR && UNITY_WEBGL
            _service = gameObject.AddComponent<WebGL.WebGLAWSService>();
#else
            _service = gameObject.AddComponent<Unity.UnityAWSService>();
#endif
        }


        public ICognitoIdentityCredentials CreateCognitoIdentityCredentials(string identityPoolId, string region)
        {
            return _service.CreateCognitoIdentityCredentials(identityPoolId, region);
        }

        public ISQSClient CreateSQSClient(ICredentials credentials, string region)
        {
            return _service.CreateSQSClient(credentials, region);
        }
    }
}