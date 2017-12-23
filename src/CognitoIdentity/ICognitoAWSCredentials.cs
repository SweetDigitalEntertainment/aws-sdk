using Amazon.CognitoIdentity;
using Amazon.Runtime;
using UnityEngine.Events;

namespace Sweet.Unity.Amazon
{
    public interface ICognitoAWSCredentials : IAWSCredentials
    {
        void GetCredentialsAsync(AmazonCognitoIdentityCallback<ImmutableCredentials> callback, AsyncOptions options = null);

        ImmutableCredentials GetCredentials();

        void AddLogin(string provider, string token);
    }
}