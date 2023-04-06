using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iComercio.Models;
using iComercio.DAL;
using iComercio.Auxiliar;

namespace iComercio.Rest.RestModels
{
    public class ClienteRestModel
    {
        public int Documento { get; set; }
        public string TipoDocumentoID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string ProfesionID { get; set; }
        public ProfesionRestModel Profesion { get; set; }
        public string EmpresaLaboral { get; set; }
        public decimal? Sueldo { get; set; }
        public string Legajo { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string SexoID { get; set; }
        public SexoRestModel Sexo { get; set; }
        public DateTime FechaAlta { get; set; }
        public string TipoComoConocioID { get; set; }
        public decimal Puntaje { get; set; } //Podria ser ultimo puntaje, creo que  el puntaje debe ser dinamica
        public bool? Tarjeta { get; set; }
        public DateTime? FechaAltaTarjeta { get; set; }
        public DateTime? FechaVencimientoTarjeta { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int? UsuarioModificacionID { get; set; }
        public int EstadoID { get; set; }
        public EstadoRestModel Estado { get; set; }
        public string Zona { get; set; }
        public string Cod1 { get; set; }
        public string Cod2 { get; set; }

        public string Cuit { get; set; }
      


        public List<DomicilioRestModel> Domicilios { get; set; }
        public List<TelefonoRestModel> Telefonos { get; set; }
        public List<MailRestModel> Mails { get; set; }
        public List<NotaRestModel> Notas { get; set; }
        public List<CreditoRestModel> Creditos { get; set; }
        public List<CreditoRestModel> CreditosGar1 { get; set; }
        public List<CreditoRestModel> CreditosGar2 { get; set; }
        public List<CreditoRestModel> CreditosGar3 { get; set; }
        public List<CreditoRestModel> CreditosAdi { get; set; }
        public List<RefinanciacionRestModel> Refinanciaciones { get; set; }
        public List<CuentaBancariaClienteRestModel> CuentasBancariasCliente { get; set; }

    }
}
