using System.Security.Cryptography;
using System.Text;

namespace ASP_MVP_23._03
{
    public class Global
    {
        public static String md5(string input)
        {
            return Convert.ToBase64String(
                System.Security.Cryptography.MD5.HashData(
                    System.Text.Encoding.UTF8.GetBytes(input)));
        }
    }
}
