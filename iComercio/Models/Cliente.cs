using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using iComercio.DAL;
using iComercio.Auxiliar;
using iComercio.Rest.RestModels;


namespace iComercio.Models
{
    public class Cliente : ITransmitible
    {
        public int Documento { get; set; }
        public string TipoDocumentoID { get; set; }
        public virtual TipoDocumento TipoDocumento { get; set; }

        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public string ProfesionID { get; set; }
        public virtual Profesion Profesion { get; set; }

        public string EmpresaLaboral { get; set; }
        public decimal? Sueldo { get; set; }
        public string  Legajo { get; set; }

        public DateTime? FechaNacimiento { get; set; }
        
        public string SexoID { get; set; }
        public virtual Sexo Sexo { get; set; }
        public DateTime FechaAlta { get; set; }
        
        public string TipoComoConocioID { get; set; }
        public virtual TipoComoConocio TipoComoConocio{ get; set; }
        public decimal? Puntaje { get; set; } //Podria ser ultimo puntaje, creo que  el puntaje debe ser dinamica

        public bool? Tarjeta { get; set; }
        public DateTime? FechaAltaTarjeta { get; set; }
        public DateTime? FechaVencimientoTarjeta { get; set; }

        public DateTime? FechaModificacion { get; set; }
        public int? UsuarioModificacionID { get; set; }
        public Usuario UsuarioModificacion { get; set; }

        public int EstadoID { get; set; }
        public Estado Estado { get; set; }

        public string Zona { get; set; }
        public string Cod1 { get; set; }
        public string Cod2 { get; set; }
        
        public string Cuit { get; set; }



        public virtual ObservableListSource<Domicilio> Domicilios { get; set; }
        public virtual ObservableListSource<Telefono> Telefonos { get; set; }
        public virtual ObservableListSource<Mail> Mails { get; set; }
        public virtual ObservableListSource<Credito> Creditos { get; set; }
        public virtual ObservableListSource<Credito> CreditosGar1 { get; set; }
        public virtual ObservableListSource<Credito> CreditosGar2 { get; set; }
        public virtual ObservableListSource<Credito> CreditosGar3 { get; set; }
        public virtual ObservableListSource<Credito> CreditosAdi { get; set; }
        public virtual ObservableListSource<Refinanciacion> Refinanciaciones { get; set; }
        public virtual ObservableListSource<Nota> Notas { get; set; }
        public virtual ObservableListSource<CuentaBancariaCliente> CuentasBancariasCliente { get; set; }

        

        public Cliente()
        {
            Domicilios = new ObservableListSource<Domicilio>();
            Telefonos = new ObservableListSource<Telefono>();
            Mails = new ObservableListSource<Mail>();
            Notas = new ObservableListSource<Nota>();
            Creditos = new ObservableListSource<Credito>();
            CreditosGar1 = new ObservableListSource<Credito>();
            CreditosGar2 = new ObservableListSource<Credito>();
            CreditosGar3 = new ObservableListSource<Credito>();
            CreditosAdi = new ObservableListSource<Credito>();
            Refinanciaciones = new ObservableListSource<Refinanciacion>();
            CuentasBancariasCliente = new ObservableListSource<CuentaBancariaCliente>();
        }

        public override string ToString()
        {
            return NombreCompleto;
        }

        public string NombreCompleto
        {
            get { return string.Format("{0} {1}", Apellido, Nombre); }
            set { ;}
        }

        //Implementar los estados para tomar el ultimo domicilio vigente , no tomar solo el ultimo
        public Domicilio UltimoDomicilioCliente
        {
            get {
                    return UltimoDomicilio(ParametrosGlobales.EstadoVigenteID, ParametrosGlobales.ClaseDatoClienteID);
                }
            set { ;}
        }

        //Implementar los estados para tomar el ultimo domicilio vigente , no tomar solo el ultimo
        public Telefono UltimoTelefonoCliente
        {
            get
            {
                return UltimoTelefono(ParametrosGlobales.EstadoVigenteID, ParametrosGlobales.ClaseDatoClienteID);
            }
            set { ;}
        }
        public string UltimoTelefonoSTR(int EstadoID, int ClaseDatoID)  
        {
            if (Telefonos != null && Telefonos.Count > 0)
            {
                Telefono tel = Telefonos.Where(d => d.EstadoID == EstadoID && d.ClaseDatoID == ClaseDatoID).OrderByDescending(d => d.Fecha).FirstOrDefault();
                if (tel != null) return tel.CodArea + " " + tel.Numero;
            }
            return "";
        }
        public Mail UltimoMailCliente
        {
            get
            {
                return UltimoMail(ParametrosGlobales.EstadoVigenteID, ParametrosGlobales.ClaseDatoClienteID);
            }
            set { ;}
        }


        //Implementar los estados para tomar el ultimo domicilio vigente , no tomar solo el ultimo
        public Domicilio UltimoDomicilioEmpresa
        {
            get
            {
                return UltimoDomicilio(ParametrosGlobales.EstadoVigenteID, ParametrosGlobales.ClaseDatoEmpresaID);
            }
            set { ;}
        }

        //Implementar los estados para tomar el ultimo domicilio vigente , no tomar solo el ultimo
        public Telefono UltimoTelefonoEmpresa
        {
            get
            {
                return UltimoTelefono(ParametrosGlobales.EstadoVigenteID, ParametrosGlobales.ClaseDatoEmpresaID);
            }
            set { ;}
        }

        public Mail UltimoMailEmpresa
        {
            get
            {
                return UltimoMail(ParametrosGlobales.EstadoVigenteID, ParametrosGlobales.ClaseDatoEmpresaID);
            }
            set { ;}
        }

        private Domicilio UltimoDomicilio(int EstadoID,int ClaseDatoID)
        {
            if (Domicilios != null && Domicilios.Count > 0)
            {
                return Domicilios.Where(d => d.EstadoID == EstadoID && d.ClaseDatoID == ClaseDatoID).OrderByDescending(d => d.DomicilioID).FirstOrDefault();
            }
            return null;
        }

        private Telefono UltimoTelefono(int EstadoID, int ClaseDatoID)
        {
            if (Telefonos != null && Telefonos.Count > 0)   
            {
                return Telefonos.Where(d => d.EstadoID == EstadoID && d.ClaseDatoID == ClaseDatoID).OrderByDescending(d => d.TelefonoID).FirstOrDefault();
            }
            return null;
        }

        private Mail UltimoMail(int EstadoID, int ClaseDatoID)
        {
            if (Mails != null && Mails.Count > 0)
            {
                return Mails.Where(d => d.EstadoID == EstadoID && d.ClaseDatoID == ClaseDatoID).OrderByDescending(d => d.MailID).FirstOrDefault();
            }
            return null;
        }
        public Nota UltimaNota 
        {
            get
            {
                return Notas.Where(n => n.Detalle != null).OrderByDescending(o => o.Fecha).FirstOrDefault();
            }
            set {; }
        }

        /*Transmision*/

        public string EntidadID()
        {
            return Documento.ToString();
        }

        public string EntidadID2()
        {
            return TipoDocumentoID;
        }

        public string EntidadID3()
        {
            return null;
        }

        public InfoTransmision InfoTransmision()
        {
            return new InfoTransmision(EntidadID(), EntidadID2());
        }

        public Dictionary<string, Object> ApiParam(Comercio com)
        {
            Dictionary<string, Object> ApiParam = new Dictionary<string, object>();
            ApiParam.Add("EmpresaID", com.EmpresaID);
            ApiParam.Add("ComercioID", com.ComercioID);
            ApiParam.Add("Documento", this.Documento);
            ApiParam.Add("TipoDocumentoID", this.TipoDocumentoID);
            return ApiParam;
        }

        public void ApiActualizarDesdeRemoto(BusinessLayer bl,object c)
        {
            //Cliente cli = (Cliente)c;
            //this.Documento = cli.Documento;
            //this.TipoDocumentoID = cli.TipoDocumentoID;
            //bl.Actualizar<Cliente>((Cliente)c);
        }

        public Expression<Func<Transmision, bool>> ExpresionDeBusqueda(Transmision tran, Operacion op)
        {
            return null;
        }
    }
}
