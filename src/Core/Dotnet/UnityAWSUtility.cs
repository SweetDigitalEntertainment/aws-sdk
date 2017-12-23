#if UNITY_EDITOR || !UNITY_WEBGL
using Amazon.Runtime;

namespace Sweet.Unity.Amazon.Dotnet
{
    public static class UnityAWSUtility
    {
        public static void CopyResponse(ServiceResponse serviceResponse, AmazonWebServiceResponse amazonResponse)
        {
            serviceResponse.ContentLength = amazonResponse.ContentLength;
            serviceResponse.HttpStatusCode = amazonResponse.HttpStatusCode;

            var metadata = new ServiceResponseMetadata();
            metadata.Metadata = amazonResponse.ResponseMetadata.Metadata;
            metadata.RequestId = amazonResponse.ResponseMetadata.RequestId;
            serviceResponse.ResponseMetadata = metadata;
        }
    }
}
#endif