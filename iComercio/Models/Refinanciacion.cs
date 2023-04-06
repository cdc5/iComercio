using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using iComercio.DAL;
using iComercio.Auxiliar;
using iComercio.Rest.RestModels;


namespace iComercio.Models
{
    public class Refinanciacion : ITransmitible
    {
        public int RefinanciacionID { get; set; }
        public int CreditoID { get; set; }
        public virtual Credito Credito { get; set; }

        public int ComercioID { get; set; }
        public virtual Comercio Comercio { get; set; }

        public int EmpresaID { get; set; }
        public virtual Empresa Empresa { get; set; }

        public int Documento { get; set; } //kdocumento
        public virtual Cliente Cliente { get; set; }
        public string TipoDocumentoID { get; set; } //CodDocu


        public decimal ValorNominal { get; set; } //kvalornom
        public decimal ValorCuota { get; set; } //kvalorcuota
        public decimal ValorAdelanto { get; set; }
        public DateTime FechaSolicitud { get; set; } //kfechsoli

        public decimal Interes { get; set; } //KInteresImp
        //  public decimal Gasto { get; set; }  //KGastoImp
        //public decimal Comision { get; set; } //KComisionImp

        //public string TipoCuotaID { get; set; } //ktipcuota
        public int CantidadCuotas { get; set; } //kcuotas

        public int UsuarioID { get; set; } //usuAval
        public virtual Usuario Usuario { get; set; } //Usuario

        public string PcComer { get; set; } //PC_comer
        public DateTime FechaComerAnula { get; set; } //hora_comer

        //financiera
        //public int UsuarioAutorizoID { get; set; } //usario que hablo con el cliente en central
        //public virtual Usuario UsuarioAutorizo { get; set; } //No se si es necesario tener en la base del comercio
        //los usuarios de central. Solo poner el ID del usuario
        //para que caundo venga a central lo podamos identificar

        public int EstadoID { get; set; }                               //***edu
        public virtual Estado Estado { get; set; }        
        
        public DateTime? FechaCreacion { get; set; }  //fecha de creacion en central
        public virtual ObservableListSource<RefinanciacionCuota> RefinanciacionCuotas { get; set; }


        /*Transmision*/
       
        public InfoTransmision InfoTransmision()
        {
            return new InfoTransmision(EmpresaID.ToString(), ComercioID.ToString(), CreditoID.ToString(), RefinanciacionID.ToString());
        }

        public Dictionary<string, Object> ApiParam(Comercio com)
        {
            Dictionary<string, Object> ApiParam = new Dictionary<string, object>();
            ApiParam.Add("EmpresaID", this.EmpresaID);
            ApiParam.Add("ComercioID", this.ComercioID);
            ApiParam.Add("CreditoID", this.CreditoID);
            ApiParam.Add("RefinanciacionID", this.RefinanciacionID);
            return ApiParam;
        }

        public void ApiActualizarDesdeRemoto(BusinessLayer bl, object c)
        {
           
        }

    }
}
