using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using iComercio.Rest.RestModels;

namespace iComercio.Models
{
    public class CuentaCorriente : ITransmitible
    {
        public long? CuentaCorrienteID { get; set; }
        public int? EmpresaID { get; set; }
        public virtual Empresa Empresa { get; set; }
        public int? ComercioID { get; set; }
        public virtual Comercio Comercio { get; set; }
        public long? IDRemoto { get; set; }
        public int? TipoMovimientoID { get; set; }
        public virtual TipoMovimiento TipoMovimiento { get; set; }
        public DateTime Fecha { get; set; }
        public long? SolicitudFondoID { get; set; }
        public virtual SolicitudFondo SolicitudFondo { get; set; }
        public int? CreditoID { get; set; }
        public virtual Credito Credito { get; set; }
        public int? CuotaID { get; set; }
        public virtual Cuota Cuota { get; set; }
        public int? CobranzaID { get; set; }
        public virtual Cobranza Cobranza { get; set; }
        public int? NotaCDID { get; set; }
        public virtual NotasCD NotaCD { get; set; }
        public long? TransferenciaDepositoID { get; set; }
        public virtual TransferenciasDepositos TransferenciasDepositos { get; set; }
        public int? ReciboID { get; set; }
        public virtual Recibo Recibo { get; set; }
        public decimal Importe { get; set;}
        public int? GestionID { get; set; }
        
        public int? GastoID { get; set; }
        public virtual Gasto Gasto { get; set; }

        public int? PagoID { get; set; }
        public virtual Pago Pago { get; set; }

        public DateTime? FechaAviso { get; set; } //eduardo cambio
        public int? CreditoNro { get; set; }



        //GestionID se usa como identificador de comercio de cuenta corriente ya que en el realmente esta todo lo del comercio, el campo comercioID correspondeo al credito/cuota/cobranza, etc
     
        public CuentaCorriente()
        {
            
        }

        public CuentaCorriente(Comercio com,Recibo rec ,TransferenciasDepositos td ,TipoMovimiento tm, decimal importe)
        {
            if (rec.ComercioAdheridoEmpresaID != null)
                this.EmpresaID = rec.ComercioAdheridoEmpresaID;
            else
                this.EmpresaID = rec.EmpresaID;

            if (rec.ComercioAdheridoComercioID != null  )
                this.ComercioID = rec.ComercioAdheridoComercioID; 
            else
                this.ComercioID = rec.ComercioID;

            this.Recibo = rec;

            if (rec.CreditoID != null)
            {
                this.CreditoID = rec.CreditoID;
                this.CreditoNro = rec.CreditoID;
            }
                
            if (rec.CuotaID != null)
                this.CuotaID = rec.CuotaID;
            if (rec.CobranzaID != null)
                this.CobranzaID = rec.CobranzaID;

            this.TransferenciasDepositos = td;
            TipoMovimientoID = tm.TipoMovimientoID;
            this.GestionID = com.ComercioID;
            Fecha = rec.Fecha.Value;
            FechaAviso = Fecha;
            Importe = importe;
        }

      
        public CuentaCorriente(int EmpresaID,int ComercioID, TipoMovimiento tm, decimal importe)
        {
            this.EmpresaID = EmpresaID;
            this.ComercioID = ComercioID;
            TipoMovimientoID = tm.TipoMovimientoID;
            Fecha = DateTime.Now;
            FechaAviso = Fecha;
            this.GestionID = ComercioID;
            Importe = importe;
        }


        public CuentaCorriente(SolicitudFondo sf,TipoMovimiento tm, decimal importe)
        {
            EmpresaID = sf.EmpresaID;
            ComercioID = sf.ComercioID;
            SolicitudFondoID = sf.SolicitudFondoID;
            TipoMovimientoID = tm.TipoMovimientoID;
            this.GestionID = sf.ComercioID;
            Fecha = DateTime.Now;
            FechaAviso = Fecha;
            Importe = importe;            
        }


        public CuentaCorriente(Credito cred, TipoMovimiento tm, decimal importe, DateTime NvaFecha)//eduardo cambio
        {
            EmpresaID = cred.EmpresaID;
            ComercioID = cred.ComercioID;
            CreditoID = cred.CreditoID;     //edu sacar2022
            GestionID = cred.ComercioID;
            TipoMovimientoID = tm.TipoMovimientoID;
            Fecha = cred.FechaSolicitud; // DateTime.Now;
            Importe = importe;
            FechaAviso = NvaFecha; // cred.FechaAviso;//eduardo cambio
            CreditoNro = cred.CreditoID;//eduardo cambio
        }

        public CuentaCorriente(Credito cred,TipoMovimiento tm, decimal importe)
        {
            EmpresaID = cred.EmpresaID;
            ComercioID = cred.ComercioID;
            CreditoID = cred.CreditoID;
            GestionID = cred.ComercioID;
            TipoMovimientoID = tm.TipoMovimientoID;
            Fecha = DateTime.Now;
            Importe = importe;
            FechaAviso = cred.FechaAviso;//eduardo cambio
            CreditoNro = cred.CreditoID;//eduardo cambio
        }

        public CuentaCorriente(Credito cre, TipoMovimiento tm, DateTime fFechaNva)
        {
            EmpresaID = cre.EmpresaID;
            ComercioID = cre.ComercioID;
            CreditoID = cre.CreditoID;    //edu sacar2022
            GestionID = cre.ComercioID;
            TipoMovimientoID = tm.TipoMovimientoID;
            Fecha = DateTime.Now;
            Importe = cre.ValorCuota;
            FechaAviso = fFechaNva; // cred.FechaSolicitud;//eduardo cambio
            CreditoNro = cre.CreditoID;//eduardo cambio

        }
        public CuentaCorriente(Credito cred,Cuota CuotaAdelantada, TipoMovimiento tm, decimal importe, DateTime fFechaNva)
        {
            EmpresaID = CuotaAdelantada.EmpresaID;
            ComercioID = CuotaAdelantada.ComercioID;
            CreditoID = CuotaAdelantada.CreditoID;
            //CuotaID = CuotaAdelantada.CuotaID; //edu202109
            GestionID = CuotaAdelantada.ComercioID; 
            TipoMovimientoID = tm.TipoMovimientoID;
            Fecha = DateTime.Now;
            Importe = importe;
            FechaAviso = fFechaNva; // cred.FechaSolicitud;//eduardo cambio
            CreditoNro = cred.CreditoID;//eduardo cambio
        }

     

        public CuentaCorriente(Cobranza cob, TipoMovimiento tm, decimal importe)
        {
            EmpresaID = cob.EmpresaID;
            ComercioID = cob.ComercioID;
            CreditoID = cob.CreditoID;
            CuotaID = cob.CuotaID;
            CobranzaID = cob.CobranzaID;
            GestionID = cob.GestionID;
            TipoMovimientoID = tm.TipoMovimientoID;
            Fecha = DateTime.Now;
            Importe = importe;
            FechaAviso = cob.FechaPago;
            CreditoNro = cob.CreditoID;//eduardo cambio
         
            
        }
        public CuentaCorriente(NotasCD NotaCD, TipoMovimiento tm, decimal importe, DateTime NvaFecha)//eduardo cambio
        {
            EmpresaID = NotaCD.EmpresaID;
            ComercioID = NotaCD.ComercioID;
            CreditoID = NotaCD.CreditoID;
            CuotaID = NotaCD.CuotaID;
            CobranzaID = NotaCD.CobranzaID;
            NotaCDID = NotaCD.NotaCDID;
            TipoMovimientoID = tm.TipoMovimientoID;
            this.GestionID = NotaCD.GestionID;
            Fecha = DateTime.Now;
            Importe = importe;
            FechaAviso = NvaFecha; //eduardo cambio
            CreditoNro = NotaCD.CreditoID;//eduardo cambio
        }

        public CuentaCorriente(NotasCD NotaCD, TipoMovimiento tm, decimal importe)
        {
            EmpresaID = NotaCD.EmpresaID;
            ComercioID = NotaCD.ComercioID;
            CreditoID = NotaCD.CreditoID;
            CuotaID = NotaCD.CuotaID;
            CobranzaID = NotaCD.CobranzaID;
            NotaCDID = NotaCD.NotaCDID;
            TipoMovimientoID = tm.TipoMovimientoID;
            this.GestionID = NotaCD.GestionID;
            Fecha = DateTime.Now;
            Importe = importe;
            FechaAviso = NotaCD.Fecha; //eduardo cambio
            CreditoNro = NotaCD.CreditoID;//eduardo cambio
        }

        public CuentaCorriente(TipoMovimiento tm,int EmpresaID, int ComercioID,int CreditoID,int CuotaID,int CobranzaID,decimal importe)
        {
            this.EmpresaID = EmpresaID;
            this.ComercioID = ComercioID;
            this.CreditoID = CreditoID;
            this.CuotaID = CuotaID;
            this.CobranzaID = CobranzaID;
            this.GestionID = ComercioID;
            Importe = importe;
            CreditoNro = CreditoID;//eduardo cambio
            Fecha = DateTime.Now;
            FechaAviso = Fecha;
        }

        public CuentaCorriente(FF ff, TipoMovimiento tm)
        {
            this.EmpresaID = ff.EmpresaID;
            this.ComercioID = ff.ComercioID;
            this.GestionID = ff.ComercioID;
            this.Importe = ff.TotalGastos;
            Fecha = ff.Fecha;
            FechaAviso = Fecha;
            this.TipoMovimientoID = tm.TipoMovimientoID;
        }

        public CuentaCorriente(Gasto g, TipoMovimiento tm)
        {
            this.EmpresaID = g.EmpresaID;
            this.ComercioID = g.ComercioID;
            this.GestionID = g.ComercioID;
            this.Importe = g.Importe;
            this.GastoID = g.GastoID;
            Fecha = g.Fecha;
            FechaAviso = Fecha;
            this.TipoMovimientoID = tm.TipoMovimientoID;
        }
        
        public CuentaCorriente(Cap cap, TipoMovimiento tm, decimal importe)
        {
            EmpresaID = cap.EmpresaID;
            ComercioID = cap.ComercioID;
            SolicitudFondoID = cap.SolicitudFondoID;
            TipoMovimientoID = tm.TipoMovimientoID;
            this.GestionID = cap.ComercioID;
            Fecha = cap.Fecha;
            FechaAviso = Fecha;
            Importe = importe;
        }

        public CuentaCorriente(Pago Pago, TipoMovimiento tm, decimal importe)
        {
            EmpresaID = Pago.EmpresaID;
            ComercioID = Pago.ComercioID;
            SolicitudFondoID = Pago.SolicitudFondoID;
            TipoMovimientoID = tm.TipoMovimientoID;
            this.GestionID = Pago.ComercioID;
            this.PagoID = Pago.PagoID;
            Fecha = DateTime.Now;
            FechaAviso = Fecha;
            Importe = importe;
        }


        /*Transmision*/
        public Dictionary<string, Object> ApiParam(Comercio com)
        {
            Dictionary<string, Object> ApiParam = new Dictionary<string, object>();
            ApiParam.Add("EmpresaID", EmpresaID);
            ApiParam.Add("ComercioID", ComercioID);
            ApiParam.Add("CuentaCorrienteID", CuentaCorrienteID);
            return ApiParam;
        }

        public void ApiActualizarDesdeRemoto(BusinessLayer bl, object c)
        {
            CuentaCorrienteRestModel ccrm = (CuentaCorrienteRestModel)c;
            if (ccrm != null)
            {
                CuentaCorriente cc = bl.Get<CuentaCorriente>(ccrm.EmpresaID.Value, x => x.EmpresaID == ccrm.EmpresaID
                                            && x.ComercioID == ccrm.ComercioID && x.CuentaCorrienteID == ccrm.CuentaCorrienteID).SingleOrDefault();
                if (cc != null)
                {
                    cc.IDRemoto = ccrm.IDRemoto;
                }
                bl.Actualizar<CuentaCorriente>(cc);                
            }
        }

        public InfoTransmision InfoTransmision()
        {
            return new InfoTransmision(EmpresaID.ToString(),
                                       ComercioID.ToString(),
                                       CuentaCorrienteID.ToString());
        }

        public Expression<Func<Transmision, bool>> ExpresionDeBusqueda(Transmision tran, Operacion op)
        {
            string empID = EmpresaID.ToString();
            string comID = ComercioID.ToString();
            string ccID = CuentaCorrienteID.ToString();

            return t => t.GrupoTransmision == tran.GrupoTransmision && t.OperacionID == op.OperacionID
                  && t.EntidadID == empID && t.EntidadID2 == comID && t.EntidadID3 == ccID;
        }

        public decimal? ImporteSignado
        {
            get
            {
                if (TipoMovimiento != null && TipoMovimiento.ClaseMovimiento != null)
                {
                    return Importe * TipoMovimiento.ClaseMovimiento.Modificador;
                }
                return null;
            }
        }
    }
}
