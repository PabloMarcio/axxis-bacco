using System.Text;

namespace axxis.bacco.backend.infra.extensions
{
    public static class StringExtensions
    {
        public static string FromBase64(this string value)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(value));
        }
    }
}