using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iComercio.Auxiliar;
using iComercio.Rest.RestModels;

using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace iComercio.Models
{
    public class Cobranza:ITransmitible
    {
        public int CobranzaID { get; set; } //anumcob
        public int CuotaID { get; set; } //anumcuota
        public virtual Cuota Cuota { get; set; }
        public int CreditoID { get; set; } //Acredito
        public virtual Credito Credito { get; set; }
        public int ComercioID { get; set; } //AComercio
        public virtual Comercio Comercio { get; set; }
        public int EmpresaID { get; set; }
        public virtual Empresa Empresa { get; set; }
        public int Documento { get; set; }
        public virtual Cliente Cliente { get; set; }
        public string TipoDocumentoID { get; set; } 
        
        public decimal ImportePago { get; set; } //Importe pagado total de la cobranza aimppago
        public decimal ImportePagoPunitorios { get; set; }  // aimppuni
        public decimal Interes { get; set; } //es el interes de la cobranza aimppinte
        public decimal? PunitoriosCalc { get; set; } //son los punitorios calculados  apunicalc
        public DateTime FechaPago { get; set; } //afechapago
        public DateTime FechaVencimiento { get; set; } //afechavenci
        public string TipoPagoID { get; set; } //apago
        public virtual TipoPago TipoPago { get; set; }
        public string TipoBonificacionID { get; set; } //tipoboni
        public virtual TipoBonificacion TipoBonificacion { get; set; } 
        public decimal? PorcentajeBonificacion { get; set; } //porboni

        public bool PagoRev { get; set; } //apagorev
        public DateTime? FechaRev { get; set; } //fecharev
        public int? CobranzaIDRev { get; set; }

        [MaxLength(100)]
        public string Motivo { get; set; }

        public int GestionEmpresaID { get; set; }
        public int GestionID { get; set; } //Agestion quien lo cobro comercio,abogado,cobrador
        public virtual Comercio Gestion { get; set; }
        
        public int RefinanciacionCobranzaID { get; set; }//numRef  Es el numero correspondiente a la cobranza de la refinanciacion que compensa esta cobranza
        
        public int UsuarioID { get; set; } //usuario
        public virtual Usuario Usuario { get; set; } //Usuario
        public string PcComer { get; set; } //PC_comer

        public decimal ImporteTotal
        {
            get { return ImportePago + ImportePagoPunitorios; }
            private set { }
        }
        public decimal ImporteCapital
        {
            get { return ImportePago - Interes; }
            set { }
        }
        
        public ObservableListSource<NotasCD> NotasCD { get; set; }
        public ObservableListSource<Nota> Notas { get; set; }

        public string NotasBoni {get;set;}

        public Cobranza()
        {
            Notas = new ObservableListSource<Nota>();
            NotasCD = new ObservableListSource<NotasCD>();
        }


        /*Transmision*/
       
        public InfoTransmision InfoTransmision()
        {
            return new InfoTransmision(EmpresaID.ToString(), ComercioID.ToString(), CreditoID.ToString(),CuotaID.ToString(),CobranzaID.ToString());
        }

        public Dictionary<string, Object> ApiParam(Comercio com)
        {
            Dictionary<string, Object> ApiParam = new Dictionary<string, object>();
            ApiParam.Add("EmpresaID", this.EmpresaID);
            ApiParam.Add("ComercioID", this.ComercioID);
            ApiParam.Add("CreditoID", this.CreditoID);
            ApiParam.Add("CuotaID", this.CuotaID);
            ApiParam.Add("CobranzaID", this.CobranzaID);
            return ApiParam;
        }

        public void ApiActualizarDesdeRemoto(BusinessLayer bl,object c)
        {
            //Cliente cli = (Cliente)c;
            //this.Documento = cli.Documento;
            //this.TipoDocumentoID = cli.TipoDocumentoID;
            //bl.Actualizar<Credito>((Credito)c);
        }

        public Expression<Func<Transmision, bool>> ExpresionDeBusqueda(Transmision tran, Operacion op)
        {
            string empID = EmpresaID.ToString();
            string comID = Comercio.ToString();
            string credID = CreditoID.ToString();
            string cuoID = CuotaID.ToString();
            string cobID = CobranzaID.ToString();
            return t => t.GrupoTransmision == tran.GrupoTransmision && t.OperacionID == op.OperacionID 
                  && t.EntidadID == empID && t.EntidadID2 == comID && t.EntidadID3 == credID
                  && t.EntidadID4 == cuoID && t.EntidadID5 == cobID;
        }
    }
  
}
