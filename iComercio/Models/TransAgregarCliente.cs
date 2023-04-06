using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iComercio.Rest.RestModels;
using iComercio.Auxiliar;
using System.ComponentModel;


namespace iComercio.Models
{
    public class TransAgregarCliente:Operacion
    {
         public TransAgregarCliente()             
         {
         }


         public TransAgregarCliente(int OperacionID, string Nombre, string Descripcion) :
                                     base(OperacionID,Nombre,Descripcion)
         {
           
         }

         public async override Task<bool> Enviar(BusinessLayer bl, Transmision tran)
         {
             int dni = System.Convert.ToInt32(tran.EntidadID);
             Cliente cliente = bl.Get<Cliente>(tran.EmpresaID,c => c.Documento == dni && c.TipoDocumentoID == tran.EntidadID2).FirstOrDefault();

             //Envío solo los ultimos Domicilio,Mail y telefonos agregados
             Domicilio domCliente = cliente.Domicilios.OrderByDescending(d => d.DomicilioID).Where(d => d.ClaseDatoID == ParametrosGlobales.ClaseDatoClienteID).FirstOrDefault();
             Domicilio domEmpresa = cliente.Domicilios.OrderByDescending(d => d.DomicilioID).Where(d => d.ClaseDatoID == ParametrosGlobales.ClaseDatoEmpresaID).FirstOrDefault();

             DateTime UltiFechaDesde;
             DateTime UltiFechaHasta;
             ObservableListSource<Telefono> Telefonos = new ObservableListSource<Telefono>();

             List<Telefono> telCliente = cliente.Telefonos.Where(d => d.ClaseDatoID == ParametrosGlobales.ClaseDatoClienteID).ToList();
             if ( telCliente != null && telCliente.Count> 0)
             {
                 UltiFechaDesde = telCliente.Max(c => c.Fecha).Date;
                 UltiFechaHasta = UltiFechaDesde;
                 DateTimeExtensions.ExtremarFechas(ref UltiFechaDesde, ref UltiFechaHasta);
                 telCliente = telCliente.OrderByDescending(d => d.TelefonoID).Where(d => d.ClaseDatoID == ParametrosGlobales.ClaseDatoClienteID
                                                                               && d.Fecha >= UltiFechaDesde && d.Fecha <= UltiFechaHasta).ToList<Telefono>();

                 foreach (Telefono tel in telCliente)
                 {
                     Telefonos.Add(tel);
                 }
             }
             
             List<Telefono> telEmpresa = cliente.Telefonos.Where(d => d.ClaseDatoID == ParametrosGlobales.ClaseDatoEmpresaID).ToList();

             if (telEmpresa != null && telEmpresa.Count>0)
             {
                 UltiFechaDesde = telEmpresa.Max(c => c.Fecha).Date;
                 UltiFechaHasta = UltiFechaDesde;
                 DateTimeExtensions.ExtremarFechas(ref UltiFechaDesde, ref UltiFechaHasta);

                 telEmpresa = cliente.Telefonos.OrderByDescending(d => d.TelefonoID).Where(d => d.ClaseDatoID == ParametrosGlobales.ClaseDatoEmpresaID
                                                                              && d.Fecha >= UltiFechaDesde && d.Fecha <= UltiFechaHasta).ToList<Telefono>();
                 foreach (Telefono tel in telEmpresa)
                 {
                     Telefonos.Add(tel);
                 }
             }

             ObservableListSource<Mail> Mails = new ObservableListSource<Mail>();
             List<Mail> mailCliente = cliente.Mails.Where(d => d.ClaseDatoID == ParametrosGlobales.ClaseDatoClienteID).ToList();
             if (mailCliente != null && mailCliente.Count > 0)
             {
                 UltiFechaDesde = cliente.Mails.Max(c => c.Fecha).Date;
                 UltiFechaHasta = UltiFechaDesde;
                 DateTimeExtensions.ExtremarFechas(ref UltiFechaDesde, ref UltiFechaHasta);
                 mailCliente = mailCliente.OrderByDescending(d => d.MailID).Where(d => d.ClaseDatoID == ParametrosGlobales.ClaseDatoClienteID
                                                                          && d.Fecha >= UltiFechaDesde && d.Fecha <= UltiFechaHasta).ToList();
                 foreach (Mail mail in mailCliente)
                 {
                     Mails.Add(mail);
                 }
             }
             

             List<Mail> mailEmpresa = cliente.Mails.OrderByDescending(d => d.MailID).Where(d => d.ClaseDatoID == ParametrosGlobales.ClaseDatoEmpresaID).ToList();
             if (mailEmpresa != null && mailEmpresa.Count > 0)
             {
                 UltiFechaDesde = cliente.Mails.Max(c => c.Fecha).Date;
                 UltiFechaHasta = UltiFechaDesde;
                 DateTimeExtensions.ExtremarFechas(ref UltiFechaDesde, ref UltiFechaHasta);
                 mailCliente = cliente.Mails.OrderByDescending(d => d.MailID).Where(d => d.ClaseDatoID == ParametrosGlobales.ClaseDatoEmpresaID
                                                                          && d.Fecha >= UltiFechaDesde && d.Fecha <= UltiFechaHasta).ToList();

                 foreach (Mail mail in mailEmpresa)
                 {
                     Mails.Add(mail);
                 }
             }

             ObservableListSource<CuentaBancariaCliente> cbs = new ObservableListSource<CuentaBancariaCliente>();
             List<CuentaBancariaCliente> cbsCliente = cliente.CuentasBancariasCliente.ToList();             
             foreach (CuentaBancariaCliente cb in cbsCliente)
             {
                 cbs.Add(cb);
             }

             ObservableListSource<Nota> Notas = new ObservableListSource<Nota>();
             
             if (cliente.Notas != null && cliente.Notas.Count > 0)
             {
                 UltiFechaDesde = cliente.Notas.Max(c => c.Fecha).Date;
                 UltiFechaHasta = UltiFechaDesde;
                 DateTimeExtensions.ExtremarFechas(ref UltiFechaDesde, ref UltiFechaHasta);
                 List<Nota> notas = cliente.Notas.Where(c => c.Fecha >= UltiFechaDesde && c.Fecha <= UltiFechaHasta).ToList();
                 foreach (Nota nota in notas)
                 {
                     Notas.Add(nota);
                 }
             }
             

             bl.Desacoplar<Cliente>(tran.EmpresaID, cliente);

             cliente.Domicilios.Clear();
             cliente.Telefonos.Clear();
             cliente.Mails.Clear();
             cliente.CuentasBancariasCliente.Clear();
             cliente.Notas.Clear();

             if (domCliente != null) cliente.Domicilios.Add(domCliente);
             if (domEmpresa != null) cliente.Domicilios.Add(domEmpresa);
             if (Telefonos != null)
                 cliente.Telefonos = Telefonos;
             if (Mails != null)
                 cliente.Mails = Mails;
             if (cbs != null)
                 cliente.CuentasBancariasCliente = cbs;
             if (Notas != null)
                 cliente.Notas = Notas;

             
             //No quiero enviar creditos, adicionales, refis, porque el cliente es nuevo, puede pasar que se envien porque en comercio
             //puede ser que se cargue un cliente, inmediatamente un credito y el sistema  al cargar el registro de cliente lo cargue.
             cliente.Creditos = null;
             cliente.CreditosAdi = null;
             cliente.CreditosGar1 = null;
             cliente.CreditosGar2 = null;
             cliente.CreditosGar3 = null;
             

             return await this.Post<Cliente, ClienteRestModel>(bl, tran, cliente);
         }       
    }
}
