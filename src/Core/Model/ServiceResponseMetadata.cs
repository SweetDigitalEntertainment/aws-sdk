using System.Collections.Generic;

namespace Sweet.Unity.Amazon
{
    public sealed class ServiceResponseMetadata
    {
        public IDictionary<string, string> Metadata { get; internal set; }
        public string RequestId { get; internal set; }
    }
}