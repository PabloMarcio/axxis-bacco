using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace axxis.bacco.backend.infra.extensions
{
    public static class StringExtensions
    {
        public static string FromBase64(this string value)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(value));
        }

        public static string ToBase64(this string value) 
        {
            byte[] bytes = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(bytes);
        }

        public static string SHA256(this string value)
        {
            StringBuilder builder = new StringBuilder();

            using (SHA256 hash = System.Security.Cryptography.SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (byte b in result)
                    builder.Append(b.ToString("x2"));
            }
            return builder.ToString();
        }

        public static bool IsValidEmail(this string value)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(value, pattern);
        }

        public static bool IsNotValidEmail(this string value)
        {
            return (value.IsValidEmail() == false);
        }
    }
}