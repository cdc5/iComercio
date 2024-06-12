using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace iComercio.Auxiliar
{
    public static class CryptMd5Utils
    {

        private static string GetKey()
        {
            return "QkL2TPp3S3iJ7+gR6nJzy0xBzKwWzO+";
        }

        public static string Encrypt(string text, string key = null)
        {
            try
            {
                string hash = key ?? GetKey();
                byte[] data = Encoding.UTF8.GetBytes(text);

                MD5 md5 = MD5.Create();
                TripleDES tripleDes = TripleDES.Create();

                tripleDes.Key = md5.ComputeHash(Encoding.UTF8.GetBytes(hash));
                tripleDes.Mode = CipherMode.ECB;

                ICryptoTransform transform = tripleDes.CreateEncryptor();
                byte[] result = transform.TransformFinalBlock(data, 0, data.Length);

                return Convert.ToBase64String(result);
            }
            catch (Exception ex)
            {
                throw new CryptographicException(ex.Message);
            }

        }

        public static string Decrypt(string text, string key = null)
        {
            try
            {
                string hash = key ?? GetKey();
                byte[] data = Convert.FromBase64String(text);

                MD5 md5 = MD5.Create();
                TripleDES tripleDes = TripleDES.Create();

                tripleDes.Key = md5.ComputeHash(Encoding.UTF8.GetBytes(hash));
                tripleDes.Mode = CipherMode.ECB;

                ICryptoTransform transform = tripleDes.CreateDecryptor();
                byte[] result = transform.TransformFinalBlock(data, 0, data.Length);

                return UTF8Encoding.UTF8.GetString(result);
            }
            catch (Exception ex)
            {
                throw new CryptographicException(ex.Message);
            }
        }

        public static string GetHash(string data, int hashBytesSize = 16)
        {
            var salt = Encoding.ASCII.GetBytes("Salt1ngB4nking");
            DeriveBytes deriveBytes = new Rfc2898DeriveBytes(data, salt);
            byte[] key = deriveBytes.GetBytes(hashBytesSize);
            string keyBase64 = Convert.ToBase64String(key);

            return keyBase64;
        }
    }
}
