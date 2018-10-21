using System;
using System.Security.Cryptography;
using System.Text;

namespace StandardWebsite.Common
{
    public static class Util
    {
        public static string HashStringUsingSHA512(string input)
        {
            string result = string.Empty;

            try
            {
                if (!string.IsNullOrEmpty(input))
                {
                    SHA512Managed sha512 = new SHA512Managed();
                    byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                    byte[] hash = sha512.ComputeHash(inputBytes);

                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < hash.Length; i++)
                    {
                        sb.Append(hash[i].ToString("x2"));
                    }

                    result = sb.ToString();
                }
            }
            catch (Exception exception)
            {
                
            }

            return result;
        }
    }
}