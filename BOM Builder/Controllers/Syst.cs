using System;
using System.Security.Cryptography;
using System.Text;

namespace BOM_Builder.Controllers
{
    class Syst
    {
        public string GetDateTime()
        {
            return DateTime.Now.ToString();
        }

        public string GetDate()
        {
            return DateTime.Now.ToString("dddd, dd/MM/yyyy");
        }

        public string GetDateForLog()
        {
            return DateTime.Now.ToString("dd-MM-yyyy");
        }

        public string GetTime()
        {
            return DateTime.Now.ToString("hh:mm tt");
        }

        public string hash(string text)
        {
            byte[] pass = Encoding.ASCII.GetBytes(text);
            var sha = new SHA1CryptoServiceProvider();
            var sha_data = sha.ComputeHash(pass);
            string password = Encoding.Default.GetString(sha_data);

            return password;
        }
    }
}
