using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iComercio.Auxiliar;
using System.Drawing;

namespace iComercio.Models
{
    public class Empresa
    {
        public int? EmpresaID { get; set; }
                
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        
        public string NombreBase { get; set; }
        public string Mail { get; set; }
        public string MailCont { get; set; }
        public string MailNotificaciones { get; set; }
        public string MailNotificacionesCont { get; set; }
        public string ServidorCorreo { get; set; }
        public string EmpresaDiminutivo { get; set; }

        public string Cuit { get; set; }
        public string IIBB { get; set; }
        public string IA { get; set; }
        public string Domicilio { get; set; }
        public string Localidad { get; set; }
        public string Provincia { get; set; }
        public string CP { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Telefono3 { get; set; }
        public string Telefonos { get; set; }

                        
        public ObservableListSource<CuentaBancaria> CuentasBancarias { get; set; }
      //  public ObservableListSource<Comercio> Comercios { get; set; }

        public override string ToString()
        {
            return Nombre;
        }

    }
}
