using System;
using System.Threading.Tasks;
using Sweet.Unity.Amazon;
using UnityEngine.Events;

namespace Sweet.Game.Web
{
    public abstract class AuthenticationMethod
    {
        public abstract Task<ICognitoAWSCredentials> Authenticate();
    }
}