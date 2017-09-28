using System.Collections.Generic;

namespace Sweet.Game.Amazon
{
    public sealed class SQSRecieveMessageRequest : ServiceRequest
    {
        public List<string> AttributeNames { get; set; }
        public int MaxNumberOfMessages { get; set; }
        public List<string> MessageAttributeNames { get; set; }
        public string QueueUrl { get; set; }
        public string ReceiveRequestAttemptId { get; set; }
        public int VisibilityTimeout { get; set; }
        public int WaitTimeSeconds { get; set; }
    }
}