using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iComercio.Models
{
    class TransConfirmarSolicitudDeFondo:Operacion
    {
        public TransConfirmarSolicitudDeFondo()
        { 
        }

        public TransConfirmarSolicitudDeFondo(int OperacionID, string Nombre, string Descripcion) :
                                        base(OperacionID, Nombre, Descripcion)
        {

        }

        public async override Task<bool> Enviar(BusinessLayer bl, Transmision tran)
        {
            int solfonID = System.Convert.ToInt32(tran.EntidadID);
            SolicitudFondo sf = bl.Get<SolicitudFondo>(tran.EmpresaID,s => s.EmpresaID == tran.Empresa.EmpresaID
                                                          && s.ComercioID == tran.Comercio.ComercioID
                                                          && s.SolicitudFondoID == solfonID).FirstOrDefault();
            if (sf != null)
            {
                var aut = await bl.ConfirmarSolicitudDeFondo(sf);
                if (aut != null && aut.AutorizacionID != null)
                {
                    Autorizacion autAux = bl.Get<Autorizacion>(tran.EmpresaID,a => a.EmpresaID == aut.EmpresaID && a.ComercioID == aut.ComercioID && a.AutorizacionID == aut.AutorizacionID).SingleOrDefault();
                    if (autAux == null)
                    {
                        bl.Agregar<Autorizacion>(aut);
                        return true;
                    }                        
                }                    
            }
            return false;
        }

   
    }
}
