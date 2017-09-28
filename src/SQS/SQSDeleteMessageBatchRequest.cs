using System.Collections.Generic;

namespace Sweet.Game.Amazon
{
    public sealed class SQSDeleteMessageBatchRequest : ServiceRequest
    {
        public List<SQSDeleteMessageBatchRequestEntry> Entries { get; set; }
        public string QueueUrl { get; set; }
    }
}