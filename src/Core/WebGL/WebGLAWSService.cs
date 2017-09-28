#if !UNITY_EDITOR && UNITY_WEBGL
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using AOT;
using UnityEngine;
using UnityEngine.Events;

namespace Sweet.Game.Amazon.WebGL
{
    public sealed class WebGLAWSService : MonoBehaviour, IAWSService
    {
        private void Awake()
        {
            AWS_Initialize();
        }


        [DllImport("__Internal")]
        private static extern void AWS_Initialize();
        
        public ICognitoIdentityCredentials CreateCognitoIdentityCredentials(string identityPoolId, string region)
        {
            return new WebGLCognitoIdentityCredentials(identityPoolId, region);
        }


        public ISQSClient CreateSQSClient(ICredentials credentials, string region)
        {
            return new WebGLSQSClient(credentials, region);
        }
    }
}
#endif