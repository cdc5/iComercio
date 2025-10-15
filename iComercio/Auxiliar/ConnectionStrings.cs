using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace iComercio.Auxiliar
{
    static class ConnectionStrings
    {

        public static string Encrypt(string e)
        {
            return CryptMd5Utils.Encrypt(e);
        }

        public static string Decrypt(string e)
        {
            return CryptMd5Utils.Decrypt(e);
        }

        public static string GetDecryptedConnectionString(string nombreBase)
        {
            string connectionstring = ConfigurationManager.ConnectionStrings[nombreBase].ConnectionString;
            string encryptedpassword = ConnectionStrings.GetPasswordFromConnectionString(connectionstring);
            string decryptedpassword = CryptMd5Utils.Decrypt(encryptedpassword);
            decryptedpassword = "comer";
            string decryptedconnectionstring = ConnectionStrings.ReplacePasswordInConnectionString(connectionstring, decryptedpassword);
            return decryptedconnectionstring;
        }


        public static string GetPasswordFromConnectionString(string connectionString)
        {
            Regex regex = new Regex("password=([^;]+)");
            Match match = regex.Match(connectionString);
            if (match.Success)
            {
                return match.Groups[1].Value;
            }
            else
            {
                throw new ArgumentException("No se pudo encontrar la contraseña en la cadena de conexión.");
            }
        }

        public static string ReplacePasswordInConnectionString(string connectionString, string newPassword)
        {
            Regex regex = new Regex("password=([^;]+)");
            string newConnectionString = regex.Replace(connectionString, "password=" + newPassword);

            return newConnectionString;
        }
    }
    
   
}
