using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iComercio.Models
{
    public class Pago :ITransmitible
    {
        public int EmpresaID { get; set; }
        public virtual Empresa Empresa { get; set; }
        public int ComercioID { get; set; }
        public virtual Comercio Comercio { get; set; }
        public int PagoID { get; set; }
        public long? SolicitudFondoID { get; set; }
        public virtual SolicitudFondo SolicitudFondo { get; set; }
        public int? CapID { get; set; }
        public int? CapDetalleID { get; set; }
        public virtual CapDetalle CapDetalle { get; set; }
        public int? FFID { get; set; }
        public int? FFDetalleID { get; set; }
        public virtual FFDetalle FFDetalle { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Importe { get; set; }
        public int EstadoID { get; set; }
        public virtual Estado Estado { get; set; }

        public Pago()
        {

        }

        public Pago(int EmpresaID,int ComercioID,long? SolicitudFondoID,int? CapID,int? CapDetalleID,int? FFID,
                    int? FFDetalleID,DateTime Fecha,decimal Importe,int EstadoID)
        {
            this.EmpresaID = EmpresaID;
            this.ComercioID = ComercioID;
            this.SolicitudFondoID = SolicitudFondoID;
            this.CapID = CapID;
            this.CapDetalleID = CapDetalleID;
            this.FFID = FFID;
            this.FFDetalleID = FFDetalleID;
            this.Importe = Importe;
            this.Fecha = Fecha;
            this.EstadoID = EstadoID;
        }

        public Dictionary<string, Object> ApiParam(Comercio com)
        {
            Dictionary<string, Object> ApiParam = new Dictionary<string, object>();
            ApiParam.Add("EmpresaID", this.EmpresaID);
            ApiParam.Add("ComercioID", this.ComercioID);
            ApiParam.Add("PagoID", this.PagoID);
            return ApiParam;
        }

        public void ApiActualizarDesdeRemoto(BusinessLayer bl, object c)
        {

        }

        public InfoTransmision InfoTransmision()
        {
            return new InfoTransmision(this.PagoID.ToString());
        }

        public string PagoDescripcion()
        {
            return string.Format("Pago:{0} - {1} - Importe:${2}", PagoID, Fecha, Importe);
        }

        public string sPagoDescripcion
        {
            get { return PagoDescripcion(); }
            set { ;}
        }
    } 
}     
              