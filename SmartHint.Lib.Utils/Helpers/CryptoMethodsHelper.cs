using SmartHint.Lib.Utils.CustomExceptions;
using System.Security.Cryptography;
using System.Text;

namespace SmartHint.Lib.Utils.Helpers
{
    public abstract class CryptoMethodsHelper
    {
        public static string GetMD5Hash(string input)
        {
            try
            {
                using (MD5 md5 = MD5.Create())
                {
                    byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                    byte[] hashBytes = md5.ComputeHash(inputBytes);

                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < hashBytes.Length; i++)
                    {
                        sb.Append(hashBytes[i].ToString("x2"));
                    }
                    return sb.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new ServiceException($"MD5: Falha inesperada ao tratar dados de sistema", ex);
            }
        }

        public static bool CompareHashWithString(string md5, string input)
        {
            try
            {
                string md5Input = GetMD5Hash(input);
                return md5 == md5Input;
            }
            catch (Exception ex)
            {
                throw new ServiceException($"MD5: Falha inesperada ao comparar dados de sistema", ex);
            }
        }
    }
}
