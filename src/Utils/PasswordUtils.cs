using System.Security.Cryptography;
using System.Text;

namespace sda_onsite_2_csharp_backend_teamwork.src.Utils
{
    public class PasswordUtils
    {
        public static void HashPassword(string plainPassword, out string hashedPassword, byte[] pepper)
        {
            var algo = new HMACSHA256(pepper);
            var passToByte = Encoding.UTF8.GetBytes(plainPassword);

            hashedPassword = BitConverter.ToString(algo.ComputeHash(passToByte));
        }
        public static bool VarifyPassword(string plainPassword, string hashedPassword, byte[] pepper)
        {
            HashPassword(plainPassword, out string hashToCompare, pepper);
            return hashToCompare == hashedPassword;
        }
    }
}