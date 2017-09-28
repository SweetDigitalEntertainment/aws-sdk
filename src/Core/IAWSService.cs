using System;

namespace Sweet.Game.Amazon
{
    public interface IAWSService
    {
        ICognitoIdentityCredentials CreateCognitoIdentityCredentials(string identityPoolId, string region);


        ISQSClient CreateSQSClient(ICredentials credentials, string region);
    }
}