namespace CrowfoundingHn.Common.Authentication
{
    public class EncryptedPassword
    {
        public string Password { get; set; }

        public EncryptedPassword(string password)
        {
            Password = password;
            
        }
    }
}