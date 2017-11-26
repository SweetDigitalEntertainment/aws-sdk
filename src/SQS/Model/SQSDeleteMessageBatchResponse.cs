using System.Collections.Generic;

namespace Sweet.Game.Amazon
{
    public sealed class SQSDeleteMessageBatchResponse : ServiceResponse
    {
        public List<SQSBatchResultErrorEntry> Failed { get; set; }
        public List<SQSDeleteMessageBatchResultEntry> Successful { get; set; }
    }
}