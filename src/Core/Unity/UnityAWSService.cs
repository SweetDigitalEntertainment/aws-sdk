#if UNITY_EDITOR || !UNITY_WEBGL
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using AOT;
using UnityEngine;
using UnityEngine.Events;
using Amazon;
using Amazon.CognitoIdentity;

namespace Sweet.Game.Amazon.Unity
{
    public sealed class UnityAWSService : MonoBehaviour, IAWSService
    {
        private void Awake()
        {
            UnityInitializer.AttachToGameObject(gameObject);
            AWSConfigs.HttpClient = AWSConfigs.HttpClientOption.UnityWebRequest;
        }


        public ICognitoIdentityCredentials CreateCognitoIdentityCredentials(string identityPoolId, string region)
        {
            return new UnityCognitoIdentityCredentials(identityPoolId, region);
        }


        public ISQSClient CreateSQSClient(ICredentials credentials, string region)
        {
            return new UnitySQSClient(credentials, region);
        }
    }
}
#endif