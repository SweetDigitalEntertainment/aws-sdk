#if UNITY_EDITOR || !UNITY_WEBGL
using System;
using System.Collections.Generic;
using System.Net;
using Amazon;
using Amazon.Runtime;
using Amazon.SQS;
using Amazon.SQS.Model;
using AmazonMessage = Amazon.SQS.Model.Message;

namespace Sweet.Game.Amazon.Unity
{
    public class UnitySQSClient : ISQSClient
    {
        private static readonly List<SQSDeleteMessageBatchResultEntry> _EmptyDeleteMessageBatchResultEntries = new List<SQSDeleteMessageBatchResultEntry>(0);
        private static readonly List<SQSBatchResultErrorEntry> _EmptyBatchResultErrorEntries = new List<SQSBatchResultErrorEntry>(0);
        private static readonly List<DeleteMessageBatchRequestEntry> _EmptyDeleteMessageBatchEntries = new List<DeleteMessageBatchRequestEntry>(0);
        private static readonly List<SQSMessage> _EmptyMessages = new List<SQSMessage>(0);
        private static readonly Dictionary<string, SQSMessageAttributeValue> _EmptyMessageAttributes = new Dictionary<string, SQSMessageAttributeValue>(0);
        private AmazonSQSClient _client;




        public UnitySQSClient(ICredentials credentials, string region)
        {
            _client = new AmazonSQSClient(
                credentials.AccessKey,
                credentials.SecretKey,
                credentials.Token,
                RegionEndpoint.GetBySystemName(region)
            );
        }




        public void ReceiveMessageAsync(SQSReceiveMessageRequest request, ServiceCallback<SQSReceiveMessageRequest, SQSReceiveMessageResponse> callback)
        {
            var req = new ReceiveMessageRequest();
            req.AttributeNames = request.AttributeNames;
            req.MaxNumberOfMessages = request.MaxNumberOfMessages;
            req.MessageAttributeNames = request.MessageAttributeNames;
            req.QueueUrl = request.QueueUrl;
            req.ReceiveRequestAttemptId = request.ReceiveRequestAttemptId;
            req.VisibilityTimeout = request.VisibilityTimeout;
            req.WaitTimeSeconds = request.WaitTimeSeconds;

            _client.ReceiveMessageAsync(req,
                (result) =>
                {
                    if (result.Exception != null)
                    {
                        callback(new ServiceResult<SQSReceiveMessageRequest, SQSReceiveMessageResponse>(
                            request,
                            null,
                            result.Exception)
                        );

                        return;
                    }

                    var response = new SQSReceiveMessageResponse();

                    UnityAWSUtility.CopyResponse(response, result.Response);
                    ReceiveMessageResponse r = result.Response;

                    if (r.Messages != null)
                    {
                        if (r.Messages.Count == 0)
                        {
                            response.Messages = _EmptyMessages;
                        }
                        else
                        {
                            response.Messages = new List<SQSMessage>(r.Messages.Count);

                            for (int i = 0; i < result.Response.Messages.Count; i++)
                            {
                                AmazonMessage amazonMessage = result.Response.Messages[i];
                                SQSMessage serviceMessage = new SQSMessage();

                                serviceMessage.Attributes = amazonMessage.Attributes;
                                serviceMessage.Body = amazonMessage.Body;
                                serviceMessage.MD5OfBody = amazonMessage.MD5OfBody;
                                serviceMessage.MD5OfMessageAttributes = amazonMessage.MD5OfMessageAttributes;
                                serviceMessage.MessageId = amazonMessage.MessageId;
                                serviceMessage.ReceiptHandle = amazonMessage.ReceiptHandle;

                                if (amazonMessage.MessageAttributes != null)
                                {
                                    if (amazonMessage.MessageAttributes.Count == 0)
                                    {
                                        serviceMessage.MessageAttributes = _EmptyMessageAttributes;
                                    }
                                    else
                                    {
                                        serviceMessage.MessageAttributes = new Dictionary<string, SQSMessageAttributeValue>(amazonMessage.MessageAttributes.Count);

                                        foreach (var amazonMessageAttribute in amazonMessage.MessageAttributes)
                                        {
                                            var serviceMessageAttribute = new SQSMessageAttributeValue();

                                            serviceMessageAttribute.BinaryListValues = amazonMessageAttribute.Value.BinaryListValues;
                                            serviceMessageAttribute.BinaryValue = amazonMessageAttribute.Value.BinaryValue;
                                            serviceMessageAttribute.DataType = amazonMessageAttribute.Value.DataType;
                                            serviceMessageAttribute.StringListValues = amazonMessageAttribute.Value.StringListValues;
                                            serviceMessageAttribute.StringValue = amazonMessageAttribute.Value.StringValue;

                                            serviceMessage.MessageAttributes[amazonMessageAttribute.Key] = serviceMessageAttribute;
                                        }
                                    }
                                }
                                response.Messages.Add(serviceMessage);
                            }
                        }
                    }

                    callback(new ServiceResult<SQSReceiveMessageRequest, SQSReceiveMessageResponse>(
                        request,
                        response,
                        null)
                    );
                }
            );
        }


        public void DeleteMessageAsync(SQSDeleteMessageRequest request, ServiceCallback<SQSDeleteMessageRequest, SQSDeleteMessageResponse> callback)
        {
            var req = new DeleteMessageRequest();
            req.ReceiptHandle = request.ReceiptHandle;
            req.QueueUrl = request.QueueUrl;

            _client.DeleteMessageAsync(
                req,
                (result) =>
                {
                    if (result.Exception != null)
                    {
                        callback(new ServiceResult<SQSDeleteMessageRequest, SQSDeleteMessageResponse>(
                            request,
                            null,
                            result.Exception)
                        );

                        return;
                    }

                    var response = new SQSDeleteMessageResponse();
                    UnityAWSUtility.CopyResponse(response, result.Response);

                    callback(new ServiceResult<SQSDeleteMessageRequest, SQSDeleteMessageResponse>(
                        request,
                        response,
                        null)
                    );
                }
            );
        }


        public void DeleteMessageBatchAsync(SQSDeleteMessageBatchRequest request, ServiceCallback<SQSDeleteMessageBatchRequest, SQSDeleteMessageBatchResponse> callback)
        {
            var req = new DeleteMessageBatchRequest();
            req.QueueUrl = request.QueueUrl;

            if (request.Entries != null)
            {
                if (request.Entries.Count == 0)
                {
                    req.Entries = _EmptyDeleteMessageBatchEntries;
                }
                else
                {
                    req.Entries = new List<DeleteMessageBatchRequestEntry>(request.Entries.Count);

                    for (int i = 0; i < request.Entries.Count; i++)
                    {
                        SQSDeleteMessageBatchRequestEntry e = request.Entries[i];
                        var entry = new DeleteMessageBatchRequestEntry();

                        entry.Id = e.Id;
                        entry.ReceiptHandle = e.ReceiptHandle;

                        req.Entries.Add(entry);
                    }
                }
            }

            _client.DeleteMessageBatchAsync(
                req,
                (result) =>
                {
                    if (result.Exception != null)
                    {
                        callback(new ServiceResult<SQSDeleteMessageBatchRequest, SQSDeleteMessageBatchResponse>(
                            request,
                            null,
                            result.Exception)
                        );

                        return;
                    }

                    var response = new SQSDeleteMessageBatchResponse();
                    UnityAWSUtility.CopyResponse(response, result.Response);
                    DeleteMessageBatchResponse r = result.Response;

                    if (r.Failed != null)
                    {
                        if (r.Failed.Count == 0)
                        {
                            response.Failed = _EmptyBatchResultErrorEntries;
                        }
                        else
                        {
                            response.Failed = new List<SQSBatchResultErrorEntry>(r.Failed.Count);

                            for (int i = 0; i < r.Failed.Count; i++)
                            {
                                BatchResultErrorEntry e = r.Failed[i];
                                var entry = new SQSBatchResultErrorEntry();

                                entry.Code = e.Code;
                                entry.Id = e.Id;
                                entry.Message = e.Message;
                                entry.SenderFault = e.SenderFault;

                                response.Failed.Add(entry);
                            }
                        }
                    }

                    if (r.Successful != null)
                    {
                        if (r.Successful.Count == 0)
                        {
                            response.Successful = _EmptyDeleteMessageBatchResultEntries;
                        }
                        else
                        {
                            response.Successful = new List<SQSDeleteMessageBatchResultEntry>(r.Successful.Count);

                            for (int i = 0; i < r.Successful.Count; i++)
                            {
                                DeleteMessageBatchResultEntry e = r.Successful[i];
                                var entry = new SQSDeleteMessageBatchResultEntry();

                                entry.Id = e.Id;

                                response.Successful.Add(entry);
                            }
                        }
                    }

                    callback(new ServiceResult<SQSDeleteMessageBatchRequest, SQSDeleteMessageBatchResponse>(
                        request,
                        response,
                        null)
                    );
                }
            );
        }
    }
}
#endif