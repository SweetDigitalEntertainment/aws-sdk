#if !UNITY_EDITOR && UNITY_WEBGL
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using AOT;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Sweet.Game.Amazon.WebGL
{
    public sealed class WebGLSQSClient : ISQSClient
    {
        private static readonly JsonSerializerSettings _ErrorSerializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
        private static readonly Dictionary<int, CallParameters> _CallParameters = new Dictionary<int, CallParameters>();
        private static int _CallId;
        private int _nativeId;




        public WebGLSQSClient(ICredentials credentials, string region)
        {
            _nativeId = SQS_Construct(
                credentials.AccessKey,
                credentials.SecretKey,
                credentials.Token,
                region);
        }

        
        ~WebGLSQSClient()
        {
            SQS_Destroy(_nativeId);
        }



        [DllImport("__Internal")]
        private static extern int SQS_Construct(string accessKey, string secretKey, string token, string region);
        
        [DllImport("__Internal")]
        private static extern void SQS_Destroy(int nativeId);

        [DllImport("__Internal")]
        private static extern void SQS_DeleteMessageAsync(int nativeId, string request, WebGLCallback callback, int callId);

        [DllImport("__Internal")]
        private static extern void SQS_DeleteMessageBatchAsync(int nativeId, string request, WebGLCallback callback, int callId);

        [DllImport("__Internal")]
        private static extern void SQS_ReceiveMessageAsync(int nativeId, string request, WebGLCallback callback, int callId);


        public void DeleteMessageAsync(SQSDeleteMessageRequest request, ServiceCallback<SQSDeleteMessageRequest, SQSDeleteMessageResponse> callback)
        {
            string requestJson = JsonConvert.SerializeObject(request);
            _CallParameters[_CallId] = new CallParameters { Request = request, Callback = callback };
            SQS_DeleteMessageAsync(_nativeId, requestJson, DeleteMessageCallback, _CallId++);
        }

        [MonoPInvokeCallback(typeof(WebGLCallback))]
        private static void DeleteMessageCallback(int callId, string result, int isError)
        {
            CallParameters callParameters = _CallParameters[callId];
            _CallParameters.Remove(callId);
            var request = (SQSDeleteMessageRequest)callParameters.Request;
            var callback = (ServiceCallback<SQSDeleteMessageRequest, SQSDeleteMessageResponse>)callParameters.Callback;

            callback(new ServiceResult<SQSDeleteMessageRequest, SQSDeleteMessageResponse>(
                request,
                isError == 1 ? null : JsonConvert.DeserializeObject<SQSDeleteMessageResponse>(result),
                isError == 1 ? new WebGLServiceErrorException(JsonConvert.DeserializeObject<WebGLServiceError>(result, _ErrorSerializerSettings)) : null
            ));
        }

        public void DeleteMessageBatchAsync(SQSDeleteMessageBatchRequest request, ServiceCallback<SQSDeleteMessageBatchRequest, SQSDeleteMessageBatchResponse> callback)
        {
            string requestJson = JsonConvert.SerializeObject(request);
            _CallParameters[_CallId] = new CallParameters { Request = request, Callback = callback };
            SQS_DeleteMessageBatchAsync(_nativeId, requestJson, DeleteMessageBatchCallback, _CallId++);
        }

        [MonoPInvokeCallback(typeof(WebGLCallback))]
        private static void DeleteMessageBatchCallback(int callId, string result, int isError)
        {
            CallParameters callParameters = _CallParameters[callId];
            _CallParameters.Remove(callId);
            var request = (SQSDeleteMessageBatchRequest)callParameters.Request;
            var callback = (ServiceCallback<SQSDeleteMessageBatchRequest, SQSDeleteMessageBatchResponse>)callParameters.Callback;

            callback(new ServiceResult<SQSDeleteMessageBatchRequest, SQSDeleteMessageBatchResponse>(
                request,
                isError == 1 ? null : JsonConvert.DeserializeObject<SQSDeleteMessageBatchResponse>(result),
                isError == 1 ? new WebGLServiceErrorException(JsonConvert.DeserializeObject<WebGLServiceError>(result, _ErrorSerializerSettings)) : null
            ));
        }

        public void ReceiveMessageAsync(SQSRecieveMessageRequest request, ServiceCallback<SQSRecieveMessageRequest, SQSReceiveMessageResponse> callback)
        {
            string requestJson = JsonConvert.SerializeObject(request);
            _CallParameters[_CallId] = new CallParameters { Request = request, Callback = callback };
            SQS_ReceiveMessageAsync(_nativeId, requestJson, ReceiveMessageCallback, _CallId++);
        }

        [MonoPInvokeCallback(typeof(WebGLCallback))]
        private static void ReceiveMessageCallback(int callId, string result, int isError)
        {
            CallParameters callParameters = _CallParameters[callId];
            _CallParameters.Remove(callId);
            var request = (SQSRecieveMessageRequest)callParameters.Request;
            var callback = (ServiceCallback<SQSRecieveMessageRequest, SQSReceiveMessageResponse>)callParameters.Callback;

            callback(new ServiceResult<SQSRecieveMessageRequest, SQSReceiveMessageResponse>(
                request,
                isError == 1 ? null : JsonConvert.DeserializeObject<SQSReceiveMessageResponse>(result),
                isError == 1 ? new WebGLServiceErrorException(JsonConvert.DeserializeObject<WebGLServiceError>(result, _ErrorSerializerSettings)) : null
            ));
        }




        private struct CallParameters
        {
            public ServiceRequest Request;
            public Delegate Callback;
        }
    }
}
#endif