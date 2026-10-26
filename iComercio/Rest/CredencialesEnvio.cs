using System;
using System.Configuration;
using iComercio.Auxiliar;

namespace iComercio.Rest
{
    internal static class CredencialesEnvio
    {
        private const string ClaveUsuario = "EnvioUsuario";
        private const string ClaveClave = "EnvioClave";

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly object candado = new object();
        private static bool cargado;
        private static string usuario;
        private static string clave;

        public static bool Configuradas
        {
            get
            {
                Cargar();
                return !string.IsNullOrEmpty(usuario) && !string.IsNullOrEmpty(clave);
            }
        }

        public static string Usuario
        {
            get { Cargar(); return usuario; }
        }

        public static string Clave
        {
            get { Cargar(); return clave; }
        }

        private static void Cargar()
        {
            if (cargado)
                return;
            lock (candado)
            {
                if (cargado)
                    return;
                try
                {
                    string usuCifrado = ConfigurationManager.AppSettings[ClaveUsuario];
                    string claveCifrada = ConfigurationManager.AppSettings[ClaveClave];
                    if (string.IsNullOrWhiteSpace(usuCifrado) || string.IsNullOrWhiteSpace(claveCifrada))
                    {
                        log.Error("Falta '" + ClaveUsuario + "' o '" + ClaveClave + "' en el archivo de configuracion (appSettings). Los envios usaran el usuario logueado y pueden ser rechazados por el servidor.");
                    }
                    else
                    {
                        usuario = CryptMd5Utils.Decrypt(usuCifrado);
                        clave = CryptMd5Utils.Decrypt(claveCifrada);
                    }
                }
                catch (Exception ex)
                {
                    usuario = null;
                    clave = null;
                    log.Error("No se pudo leer el usuario de envio del archivo de configuracion: " + ex.Message, ex);
                }
                cargado = true;
            }
        }
    }
}
