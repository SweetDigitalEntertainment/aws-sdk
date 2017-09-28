using UnityEngine.Events;

namespace Sweet.Game.Amazon
{
    public interface ICognitoIdentityCredentials
    {
        void GetCredentialsAsync(UnityAction<ICognitoIdentityResult<ICredentials>> callback);
    }
}