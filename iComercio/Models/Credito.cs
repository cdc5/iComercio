using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iComercio.DAL;
using iComercio.Auxiliar;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq.Expressions;
using iComercio.Rest.RestModels;


namespace iComercio.Models
{
    public class Credito:ITransmitible
    {
        public int CreditoID { get; set; } //kcredito
        public int ComercioID { get; set; } //kcomercio
        public virtual Comercio Comercio { get; set; } 
        public int EmpresaID { get; set; }
        public virtual Empresa Empresa { get; set; } 
        public int Documento { get; set; } //kdocumento
        public string TipoDocumentoID { get; set; } //CodDocu
        public virtual Cliente Cliente { get; set; }
               
        
        public decimal ValorNominal { get; set; } //kvalornom
        public decimal ValorCuota { get; set; } //kvalorcuota
        public DateTime FechaSolicitud { get; set; } //kfechsoli

        public decimal Total { get { return ValorNominal + Interes; } set { ;} } //Es para mostrar en el pagaré, puede ser util para otra cosa, por eso esta acá
        public string sTotal { get { return String.Format("{0:0.00}", Total); } set { ;} } //Es para mostrar en el pagaré, puede ser util para otra cosa, por eso esta acá
        
        public decimal AdelantadaGastos {
            get
            {
                if (TipoCuotaID == "A") //Es para mostrar en el pagaré, puede ser util para otra cosa, por eso esta acá
                    return ValorCuota + Gasto;
                else
                    return Gasto;
            }
            set {; }
        }
        public string sAdelantadaGastos { get { return String.Format("{0:0.00}", AdelantadaGastos); } set {; } } //Es para mostrar en el pagaré, puede ser util para otra cosa, por eso esta acá

        public decimal Interes { get; set; } //KInteresImp
        public decimal Gasto { get; set; }  //KGastoImp
        public decimal Comision { get; set; } //KComisionImp
        
        public bool Cancelado { get; set; } //Kcancelado
        
       
        public int? Garante1 { get; set; } //KGarante1
        public string TipoDocumentoIDG1 { get; set; } //KCodDocuG1
        public virtual Cliente Gar1 { get; set; }
        public int? Garante2 { get; set; } //KGarante2
        public string TipoDocumentoIDG2 { get; set; } //KCodDocuG2
        public virtual Cliente Gar2 { get; set; }
        public int? Garante3 { get; set; } //KGarante3
        public string TipoDocumentoIDG3 { get; set; } //KCodDocuG3
        public virtual Cliente Gar3 { get; set; }
        public int? Adicional { get; set; } //DocuAdi
        public string TipoDocumentoIDAdi { get; set; } //CodAdi
        public virtual Cliente Adi { get; set; }

        public bool Avalado { get; set; } //queAvalo hace la funcoin de avalado y es nnnn
        
        public int? usuarioAvalID { get; set; } //usuAval
        public virtual Usuario UsuarioAval { get; set; }
        public string UsuarioAvalAnt { get; set; } //usuAval anterior para preservar usuario, a futuro crear usuarios correspondientes  y quitar este campo
       
        public string TipoCuotaID { get; set; } //ktipcuota
        public virtual TipoCuota TipoCuota { get; set; }
        public int CantidadCuotas { get; set; } //kcuotas
        public int? NroInformeContel { get; set; } //NroInforme

        public int? AbogadoID { get; set; } //kAbogado
        public virtual Comercio Abogado { get; set; }
        public DateTime FechaAbogado { get; set; }  //kFechaAbo
        
        public int UsuarioID { get; set; } //usuAval
        public virtual Usuario Usuario { get; set; } //Usuario
        public string UsuarioAnt { get; set; } //Usuario anterior para preservar usuario, a futuro crear usuarios correspondientes  y quitar este campo

        public string PcComer { get; set; } //PC_comer
        public DateTime FechaComer { get; set; } //hora_comer

        public string TipoBonificacionID { get; set; } //TipoBoni
        public virtual TipoBonificacion TipoBonificacion { get; set; } //PorBoni
        public decimal? PorcentajeBonificacion {get;set;}
        public decimal? ValorBonificacion { get; set; }
        //planes, revisar
        //public int VencimientoID { get; set; }  //kvtopp
        //public int PlanID { get; set; } //kcodplan
        
        public decimal TasaPlan { get; set; }
        public decimal IncrementoPlan { get; set; }
        public decimal GastoPlan { get; set; }
        public decimal GastoIncrementoPlan { get; set; }
        public bool GastoFijo { get; set; }
        public decimal ComisionPlan { get; set; }
        public decimal ComisionIncrementoPlan { get; set; }
        public string TipoRetencionPlanID { get; set; }
        public string NombrePlan { get; set; }
        public decimal? Puntaje { get; set; }
        
        public int DiasVenciPrimerCuota { get; set; } //kVenci

        public int? RefinanciacionID { get; set; } //NroRefinan
        //public int? RefinanciacionID { get; set; } //NroRefinan
        //public virtual Refinanciacion Refinanciacion { get; set; }

        public int? AvisoDePagoID { get; set; }
	
	    public int Corte { get; set; }
        public DateTime FechaAviso { get; set; }

        public string NumCuentaBancaria { get; set; }
        public DateTime FechaDesdeDebito { get; set; }

        //public virtual ObservableListSource<Refinanciacion> Refinanciaciones { get; set; }
        public virtual ObservableListSource<Refinanciacion> Refinanciaciones { get; set; }
        public virtual ObservableListSource<Cuota> Cuotas { get; set; }
        public virtual ObservableListSource<Nota> Notas { get; set; }
        public virtual ObservableListSource<CreditoAval> CreditoAvales { get; set; }
        public virtual ObservableListSource<Cobranza> Cobranzas { get; set; }
        //public virtual ObservableListSource<TipoAval> Avales { get; set; }
        //public ObservableListSource<NotasCD> NotasCD { get; set; }
        
        public Credito()
        {
          // Avales = new ObservableListSource<TipoAval>();
           Notas = new ObservableListSource<Nota>();
           Refinanciaciones = new ObservableListSource<Refinanciacion>();
           Cuotas = new ObservableListSource<Cuota>();
           CreditoAvales = new ObservableListSource<CreditoAval>();
           Cobranzas = new ObservableListSource<Cobranza>();
            //NotasCD = new ObservableListSource<NotasCD>();
        }


        /*Transmision*/
        public string EntidadID()
        {
            return EmpresaID.ToString();
        }

        public string EntidadID2()
        {
            return ComercioID.ToString();
        }

        public string EntidadID3()
        {
            return CreditoID.ToString();
        }

        public InfoTransmision InfoTransmision()
        {
            return new InfoTransmision(EntidadID(), EntidadID2(),EntidadID3());
        }

        public Dictionary<string, Object> ApiParam(Comercio com)
        {
            Dictionary<string, Object> ApiParam = new Dictionary<string, object>();
            ApiParam.Add("EmpresaID", this.EmpresaID);
            ApiParam.Add("ComercioID", this.ComercioID);
            ApiParam.Add("CreditoID", this.CreditoID);
            return ApiParam;
        }

        public void ApiActualizarDesdeRemoto(BusinessLayer bl,object c)
        {
            //Cliente cli = (Cliente)c;
            //this.Documento = cli.Documento;
            //this.TipoDocumentoID = cli.TipoDocumentoID;
            //bl.Actualizar<Credito>((Credito)c);
        }

        public Expression<Func<Transmision, bool>> ExpresionDeBusqueda(Transmision tran,Operacion op) 
        {
            string empID = EmpresaID.ToString();
            string comID = Comercio.ToString();
            string credID = CreditoID.ToString();
            return t => t.GrupoTransmision == tran.GrupoTransmision && t.OperacionID == op.OperacionID && t.EntidadID == empID && t.EntidadID2 == comID && t.EntidadID3 == credID;
        }





        



        



                        
                        
                        
                        













        
        
        
        

        
    }
}
