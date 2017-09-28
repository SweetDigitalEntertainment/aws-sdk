using System.Collections.Generic;

namespace Sweet.Game.Amazon
{
    public class SQSMessage
    {
        public Dictionary<string, string> Attributes { get; set; }
        public string Body { get; set; }
        public string MD5OfBody { get; set; }
        public string MD5OfMessageAttributes { get; set; }
        public Dictionary<string, SQSMessageAttributeValue> MessageAttributes { get; set; }
        public string MessageId { get; set; }
        public string ReceiptHandle { get; set; }
    }
}