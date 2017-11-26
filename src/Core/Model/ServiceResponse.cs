using System.Net;

namespace Sweet.Game.Amazon
{
    public abstract class ServiceResponse
    {
        public ServiceResponseMetadata ResponseMetadata { get; set; }
        public long ContentLength { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
    }
}