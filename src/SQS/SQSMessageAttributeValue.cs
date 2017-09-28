using System.Collections.Generic;
using System.IO;

namespace Sweet.Game.Amazon
{
    public class SQSMessageAttributeValue
    {
        public List<MemoryStream> BinaryListValues { get; set; }
        public MemoryStream BinaryValue { get; set; }
        public string DataType { get; set; }
        public List<string> StringListValues { get; set; }
        public string StringValue { get; set; }
    }
}