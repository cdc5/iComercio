using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iComercio.Models
{
    class Prueba
    {       
        
       //Esto va debajo de  AnulaCobranza(regCuota, regCobMod, nRefNvo,ref ltrans); en Baja_Cuota_Cobranza(int nID, int nRefNvo,int nRefCuotaCobr,ref List<Transmision> ltrans) en Anula_Cobranza_Refinanciada()

            //int nCobraIDNvo = 1;
            //Buscame_de_todo("Cobranza_S",0 ,nRefCuotaCobr,0,nID);
            
            //Buscame_de_todo("Cuota",0,0,0,regCobMod.CuotaID);
            //if (regCuota.Importe < (regCuota.ImportePago - regCobMod.ImportePago))
            //{
            //    MessageBox.Show("ERROR - No se puede anular la cobranza" + Environment.NewLine + "(error : BCCB-00001)", this.Text);
            //    return 0 ;
            //}
            //nCobraIDNvo = Busca_Ultimo_ID_Cobranza(false,0);
            //regCuota.ImportePago = regCuota.ImportePago - regCobMod.ImportePago;
            //regCuota.ImportePagoPunitorios = regCuota.ImportePagoPunitorios - regCobMod.ImportePagoPunitorios;
            //Cobranza regCobNvo = new Cobranza();
            ////cobranza
            //regCobNvo.EmpresaID = regCobMod.EmpresaID;
            //regCobNvo.ComercioID = regCobMod.ComercioID;
            //regCobNvo.CreditoID = regCobMod.CreditoID;
            //regCobNvo.CuotaID = regCobMod.CuotaID;
            //regCobNvo.CobranzaID = nCobraIDNvo;
            //regCobNvo.Documento = nDocumento;
            //regCobNvo.TipoDocumentoID = cDocumento;
            //regCobNvo.ImportePago = regCobMod.ImportePago * -1;
            //if (regCobMod.ImportePagoPunitorios > 0) regCobNvo.ImportePagoPunitorios = regCobMod.ImportePagoPunitorios * -1;
            //else regCobNvo.ImportePagoPunitorios = 0;
            //regCobNvo.Interes = regCobMod.Interes * -1;
            //regCobNvo.PunitoriosCalc = regCobMod.PunitoriosCalc * -1;
            //regCobNvo.FechaPago = DateTime.Now;  // regCobMod.FechaPago;
            //regCobNvo.FechaVencimiento = regCobMod.FechaVencimiento;
            //regCobNvo.TipoPagoID = "N";
            //regCobNvo.TipoBonificacionID = regCobMod.TipoBonificacionID;
            //regCobNvo.PorcentajeBonificacion = regCobMod.PorcentajeBonificacion;
            //regCobNvo.Motivo = txtBajaMotivo.Text;
            //regCobNvo.PagoRev = true;
            //regCobNvo.FechaRev = DateTime.Now;
            //regCobNvo.GestionEmpresaID = bl.pGlob.Comercio.EmpresaID;
            //regCobNvo.GestionID = bl.pGlob.Comercio.ComercioID;
            //regCobNvo.RefinanciacionCobranzaID = nRefNvo; // regCobMod.RefinanciacionCobranzaID;  
            //regCobNvo.UsuarioID = p.usu.UsuarioID;
            //regCobNvo.PcComer = System.Environment.MachineName;
            //regCobNvo.CobranzaIDRev = regCobMod.CobranzaID;

            //regCobMod.PagoRev = true;
            //regCobMod.FechaRev = DateTime.Now;

            //bl.ActualizarTransaccional<Cuota>(regCuota);
            //bl.AgregarTransaccional<Cobranza>(regCobNvo);
            //bl.ActualizarTransaccional<Cobranza>(regCobMod);
            ////Hay que agregar los movimientos de cuenta corriente aca
            //CuentaCorriente cc = bl.ImputarAnulacionCobranzaACuentaCorriente(regCobNvo);
            //bl.Grabar();

            ////No cambiar el orden porque sino bajarefinanciacioncobranza no lo va a leer bien.
            //ltrans = bl.Transmision<Cuota>(ltrans, regCuota, bl.pGlob.Comercio, bl.pGlob.TransActualizarCuota, bl.pGlob.UriAltaCobranza);
            //ltrans = bl.Transmision<Cobranza>(ltrans, regCobNvo, bl.pGlob.Comercio, bl.pGlob.TransAltaCobranza, bl.pGlob.UriAltaCobranza);
            //ltrans = bl.Transmision<Cobranza>(ltrans, regCobMod, bl.pGlob.Comercio, bl.pGlob.TransActualizarCobranza, bl.pGlob.UriAltaCobranza);
            //ltrans = bl.Transmision<CuentaCorriente>(ltrans, cc, bl.pGlob.Comercio, bl.pGlob.TransImputacionCC, bl.pGlob.UriAltaCobranza);


            // ESto iba en vez de AnulaCobranza(regCuota, regCobMod, regCobMod.RefinanciacionCobranzaID, ref ltrans); en frmBajaCobranza Anula_Cobranza
            
            ////cuota
            //int nCobraID = 1;
            ////Cobranza regCobNvo = bl.dal.context.Cobranzas.Where(c => c.EmpresaID == nEmpre &&
            ////    c.ComercioID == nComer && c.CreditoID == nCred && c.CuotaID == nCuota &&
            ////    c.GestionID == bl.pGlob.Comercio.ComercioID).OrderByDescending(o => o.CobranzaID).FirstOrDefault();
            ////Cobranza regCobNvo = bl.dal.context.Cobranzas.Where(c => c.EmpresaID == nEmpre &&
            ////    c.ComercioID == nComer &&  //c.CreditoID == nCred && c.CuotaID == nCuota &&
            ////    c.GestionID == bl.pGlob.Comercio.ComercioID).OrderByDescending(o => o.CobranzaID).FirstOrDefault();
            ////if (regCobNvo != null) nCobraID = regCobNvo.CobranzaID + 1;
            //nCobraID = Busca_Ultimo_ID_Cobranza(false, 0);
            
            //regCuota.ImportePago = regCuota.ImportePago - regCobMod.ImportePago;
            //regCuota.ImportePagoPunitorios = regCuota.ImportePagoPunitorios - regCobMod.ImportePagoPunitorios;
            
          
            ////cobranza
            //Cobranza regCobNvo = new Cobranza();
            //regCobNvo.EmpresaID = regCobMod.EmpresaID;
            //regCobNvo.ComercioID = regCobMod.ComercioID;
            //regCobNvo.CreditoID = regCobMod.CreditoID;
            //regCobNvo.CuotaID = regCobMod.CuotaID;
            //regCobNvo.CobranzaID = nCobraID;
            //regCobNvo.Documento = nDocumento;
            //regCobNvo.TipoDocumentoID = cDocumento;
            //regCobNvo.ImportePago = regCobMod.ImportePago * -1;
            //if (regCobMod.ImportePagoPunitorios > 0) regCobNvo.ImportePagoPunitorios = regCobMod.ImportePagoPunitorios * -1;
            //else regCobNvo.ImportePagoPunitorios = 0;
            //regCobNvo.Interes = regCobMod.Interes * -1;
            //regCobNvo.PunitoriosCalc = regCobMod.PunitoriosCalc * -1;
            //regCobNvo.FechaPago = DateTime.Now;  // regCobMod.FechaPago;
            //regCobNvo.FechaVencimiento = regCobMod.FechaVencimiento;
            //regCobNvo.TipoPagoID = "N";
            //regCobNvo.TipoBonificacionID = regCobMod.TipoBonificacionID;
            //regCobNvo.PorcentajeBonificacion = regCobMod.PorcentajeBonificacion;
            //regCobNvo.Motivo = txtBajaMotivo.Text;
            //regCobNvo.PagoRev = true;
            //regCobNvo.FechaRev = DateTime.Now;
            //regCobNvo.GestionEmpresaID = bl.pGlob.Comercio.EmpresaID;
            //regCobNvo.GestionID = bl.pGlob.Comercio.ComercioID;
            //regCobNvo.RefinanciacionCobranzaID = regCobMod.RefinanciacionCobranzaID;   //ACA no, nvo nro
            //regCobNvo.UsuarioID = p.usu.UsuarioID;
            //regCobNvo.PcComer = System.Environment.MachineName;
            //regCobNvo.CobranzaIDRev = regCobMod.CobranzaID;
           

            //regCobMod.PagoRev = true;
            //regCobMod.FechaRev = DateTime.Now;

            //bl.ActualizarTransaccional<Cuota>(regCuota);
            //bl.AgregarTransaccional<Cobranza>(regCobNvo);
            //bl.ActualizarTransaccional<Cobranza>(regCobMod);
    }
}
