namespace Sweet.Game.Amazon
{
    public interface ICredentials
    {
        string AccessKey { get; }

        string SecretKey { get; }

        string Token { get; }
    }


    public sealed class Credentials : ICredentials
    {
        public string AccessKey 
        {
            get; private set;
        }

        public string SecretKey
        {
            get; private set;
        }

        public string Token 
        {
            get; private set;
        }


        public Credentials(string accessKey, string secretKey, string token)
        {
            AccessKey = accessKey;
            SecretKey = secretKey;
            Token = token;
        }
    }
}