using SecureIdentity.Password;

namespace PortalNews.Util.SecureIdentity
{
    public static class PasswordHashedUtil
    {
        
        public static string GeneratePassword()
        {
            var password = PasswordGenerator.Generate(25);
            return password;
        }

        public static string GeneratePasswordHashed(string password)
        {
            var passwordHashed = PasswordHasher.Hash(password);
            return passwordHashed;
        }

        public static bool Compare(string hash , string password)
        {
            return PasswordHasher.Verify(hash, password);
        }
    }
}
