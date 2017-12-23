var SQS = {
    SQS_Construct__deps: ['NativeObject_Register'],
    SQS_Construct: function (accessKey, secretKey, token, regionParam) {
        var instance =  new Module['AWS'].SQS({
            accessKeyId: Pointer_stringify(accessKey),
            secretAccessKey: Pointer_stringify(secretKey),
            sessionToken: Pointer_stringify(token),
            region: Pointer_stringify(regionParam)
        });

        return _NativeObject_Register(instance);
    },

    SQS_Destroy__deps: ['NativeObject_Release'],
    SQS_Destroy: function (nativeId) {
        _NativeObject_Release(nativeId);
    },

    SQS_DeleteMessageAsync__deps: ['NativeObject_Get', 'Utility_InvokeWebGLCallback'],
    SQS_DeleteMessageAsync: function (nativeId, request, callback, callId) {
        var instance = _NativeObject_Get(nativeId);
        var r = JSON.parse(Pointer_stringify(request));

        instance.deleteMessage(r, function(err, data){
            if (err) {
                _Utility_InvokeWebGLCallback(callback, callId, JSON.stringify(err), 1);
            }
            else {
                _Utility_InvokeWebGLCallback(callback, callId, JSON.stringify(data), 0);
            }
        });
    },
    
    SQS_DeleteMessageBatchAsync__deps: ['NativeObject_Get', 'Utility_InvokeWebGLCallback'],
    SQS_DeleteMessageBatchAsync: function (nativeId, request, callback, callId) {
        var instance = _NativeObject_Get(nativeId);
        var r = JSON.parse(Pointer_stringify(request));

        instance.deleteMessageBatch(r, function(err, data){
            if (err) {
                _Utility_InvokeWebGLCallback(callback, callId, JSON.stringify(err), 1);
            }
            else {
                _Utility_InvokeWebGLCallback(callback, callId, JSON.stringify(data), 0);
            }
        });
    },
    
    SQS_ReceiveMessageAsync__deps: ['NativeObject_Get', 'Utility_InvokeWebGLCallback'],
    SQS_ReceiveMessageAsync: function (nativeId, request, callback, callId) {
        var instance = _NativeObject_Get(nativeId);
        var r = JSON.parse(Pointer_stringify(request));

        instance.receiveMessage(r, function(err, data){
            if (err) {
                _Utility_InvokeWebGLCallback(callback, callId, JSON.stringify(err), 1);
            }
            else {
                _Utility_InvokeWebGLCallback(callback, callId, JSON.stringify(data), 0);
            }
        });
    },
};

mergeInto(LibraryManager.library, SQS);