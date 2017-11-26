namespace Sweet.Game.Amazon
{
    public sealed class SQSBatchResultErrorEntry
    {
        public string Code { get; set; }
        public string Id { get; set; }
        public string Message { get; set; }
        public bool SenderFault { get; set; }
    }
}