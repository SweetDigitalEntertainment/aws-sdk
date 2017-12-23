#if !UNITY_EDITOR && UNITY_WEBGL
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using AOT;
using UnityEngine;
using UnityEngine.Events;

namespace Sweet.Unity.Amazon.Javascript
{
    public sealed class WebGLCognitoIdentityCredentials : ICognitoIdentityCredentials
    {
        private static readonly Dictionary<int, Delegate> _Callbacks = new Dictionary<int, Delegate>();
        private static int _CallbackId;
        private int _nativeId;



        
        public WebGLCognitoIdentityCredentials(string identityPoolId, string region)
        {
            _nativeId = CognitoIdentityCredentials_Construct(identityPoolId, region);
        }

        ~WebGLCognitoIdentityCredentials()
        {
            CognitoIdentityCredentials_Destroy(_nativeId);
        }



        
        [DllImport("__Internal")]
        private static extern int CognitoIdentityCredentials_Construct(string identityPoolId, string region);

        [DllImport("__Internal")]
        private static extern void CognitoIdentityCredentials_Destroy(int nativeId);

        [DllImport("__Internal")]
        private static extern void CognitoIdentityCredentials_GetCredentials(int nativeId, int callbackId, UnityAction<int, IntPtr, IntPtr, IntPtr> successCallback, UnityAction<int, IntPtr, IntPtr> errorCallback);
        
        [MonoPInvokeCallback(typeof(UnityAction<int, IntPtr, IntPtr ,IntPtr>))]
        private static void GetCredentialsOnSuccess(int callbackId, IntPtr accessKeyStrPtr, IntPtr secretKeyStrPtr, IntPtr tokenStrPtr)
        {
            var callback = (UnityAction<ICognitoIdentityResult<ICredentials>>)_Callbacks[callbackId];
            _Callbacks.Remove(callbackId);

            string accessKey = Marshal.PtrToStringAuto(accessKeyStrPtr);
            string secretKey = Marshal.PtrToStringAuto(secretKeyStrPtr);
            string token = Marshal.PtrToStringAuto(tokenStrPtr);
            
            callback(new CognitoIdentityResult<ICredentials>(
                new Credentials(accessKey, secretKey, token)
            ));
        } [
            
            
        MonoPInvokeCallback(typeof(UnityAction<int, IntPtr, IntPtr>))]
        private static void GetCredentialsOnError(int callbackId, IntPtr codeStrPtr, IntPtr messageStrPtr)
        {
            var callback = (UnityAction<ICognitoIdentityResult<ICredentials>>)_Callbacks[callbackId];
            _Callbacks.Remove(callbackId);

            string code = Marshal.PtrToStringAuto(codeStrPtr);
            string message = Marshal.PtrToStringAuto(messageStrPtr);
            
            Debug.LogError(string.Format("GetCredentials Error - Code: {0}, Message: {1}", code, message));
        }

        public void GetCredentialsAsync(UnityAction<ICognitoIdentityResult<ICredentials>> callback)
        {
            _Callbacks[_CallbackId] = callback;
            CognitoIdentityCredentials_GetCredentials(_nativeId, _CallbackId++, GetCredentialsOnSuccess, GetCredentialsOnError);
        }
    }
}
#endif