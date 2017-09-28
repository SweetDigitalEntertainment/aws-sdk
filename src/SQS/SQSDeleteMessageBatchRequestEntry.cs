namespace Sweet.Game.Amazon
{
    public sealed class SQSDeleteMessageBatchRequestEntry
    {
        public string Id { get; set; }
        public string ReceiptHandle { get; set; }
    }
}