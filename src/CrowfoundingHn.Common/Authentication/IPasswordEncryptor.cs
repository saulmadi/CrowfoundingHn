namespace CrowfoundingHn.Common.Authentication
{
    public interface IPasswordEncryptor
    {
        EncryptedPassword EncryptPassword(string password);
    }
}