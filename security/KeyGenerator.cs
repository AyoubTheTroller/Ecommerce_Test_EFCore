using System;
using System.Text;

namespace Ecommerce.security
{
    public class KeyGenerator
    {
        public static void Main()
        {
            var key = new byte[32]; // 256 bits
            using (var generator = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                generator.GetBytes(key);
                Console.WriteLine(Convert.ToBase64String(key)); 
            }
        }
    }
    
}