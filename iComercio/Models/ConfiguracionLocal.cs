using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Westwind.Utilities.Configuration;

namespace iComercio.Models
{
    public class ConfiguracionLocal : Westwind.Utilities.Configuration.AppConfiguration
    {
        /* Autorizaciones */
        public string rutaPdfAutorizacionRetCob { get; set; }
        public string rutaPdfAutorizacionExtBan { get; set; }
        public string rutaPdfAutorizacionGuardado { get; set; }
        //public string encriptado { get; set; }
        

    // Must implement public default constructor
        public ConfiguracionLocal()
        {
        
        /* Autorizaciones */
        rutaPdfAutorizacionRetCob = System.IO.Directory.GetCurrentDirectory() + "\\resources\\FormatoAutorizacion.pdf";
        rutaPdfAutorizacionExtBan = System.IO.Directory.GetCurrentDirectory() + "\\resources\\FormatoAutorizacionExtBan.pdf";
        rutaPdfAutorizacionGuardado = System.IO.Directory.GetCurrentDirectory() + "\\Documentos\\Autorizaciones\\";
        //encriptado = "1585";
        }

        protected override IConfigurationProvider OnCreateDefaultProvider(string sectionName, object configData)
        {
            var provider = new ConfigurationFileConfigurationProvider<ConfiguracionLocal>()
            {
                //ConfigurationFile = "CustomConfiguration.config",
                ConfigurationSection = sectionName,
                EncryptionKey = "ultra-seekrit",  // use a generated value here
                PropertiesToEncrypt = ""
            };

            return provider;
        }

        // Optional - provider overload with config file
        public void Initialize(string NombreSeccion)
        {
            base.Initialize(sectionName: NombreSeccion);
        }

        // Optional - provider overload with config file
        //public void Initialize(string xmlFile)
        //{
        //    base.Initialize(configData: xmlFile);
        //}
    }
}
