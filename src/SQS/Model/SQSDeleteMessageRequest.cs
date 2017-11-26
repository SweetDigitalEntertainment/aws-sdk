namespace Sweet.Game.Amazon
{

    public sealed class SQSDeleteMessageRequest : ServiceRequest
    {
        public string ReceiptHandle { get; set; }
        public string QueueUrl { get; set; }
    }
}