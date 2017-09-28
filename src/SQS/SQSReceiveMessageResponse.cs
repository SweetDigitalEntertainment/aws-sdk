using System.Collections.Generic;

namespace Sweet.Game.Amazon
{
    public sealed class SQSReceiveMessageResponse : ServiceResponse
    {
        public List<SQSMessage> Messages { get; set; }
    }
}