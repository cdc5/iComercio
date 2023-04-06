using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace iComercio.Models
{
    public class TransActualizarSolicitudDeFondo : Operacion
    {
        public TransActualizarSolicitudDeFondo()             
        {
        }


        public TransActualizarSolicitudDeFondo(int OperacionID, string Nombre, string Descripcion) :
                                     base(OperacionID,Nombre,Descripcion)
        {
           
        }
        

        public async override Task<bool> Enviar(BusinessLayer bl,Transmision tran)
        {
           int SolfonID = System.Convert.ToInt32(tran.EntidadID);
           SolicitudFondo sf = bl.Get<SolicitudFondo>(tran.EmpresaID,s=>s.EmpresaID == tran.Empresa.EmpresaID
                                                         && s.ComercioID == tran.Comercio.ComercioID
                                                         && s.SolicitudFondoID == SolfonID).FirstOrDefault();
           if (sf != null)
           {
               var sfr = await bl.TransActualizarSolicitudDeFondo(sf);
               if (sfr != null)
               { 
                    bl.Actualizar<SolicitudFondo>(tran.EmpresaID,sf);
                    return true;
               }
           }
           return false;
        }

    }
}
