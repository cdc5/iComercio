using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iComercio.Models;
using iComercio.Auxiliar;

namespace iComercio.DAL
{
    class ComercioInitializer :System.Data.Entity. DropCreateDatabaseIfModelChanges<ComercioContext>
    {
        protected override void Seed(ComercioContext context)
        {
                       
            //var perfiles = new List<Perfil>
            //{
            //new Perfil{nombre="Admin",descripcion="Admin",creacion=DateTime.Parse("2005-09-01"),activo=true},
            //new Perfil{nombre="Usuario",descripcion="usuario",creacion=DateTime.Parse("2005-09-01"),activo=true},
            //new Perfil{nombre="Encargado",descripcion="Encargado",creacion=DateTime.Parse("2005-09-01"),activo=true},
            //};
            //perfiles.ForEach(s => context.Perfiles.Add(s));
            //context.SaveChanges();


            //var usuarios = new List<Usuario>
            //{
            //    new Usuario{usuario="admin",nombre="Admin",apellido="Admin",pass="1234",creacion=DateTime.Parse("2005-09-01"),activo=true,Perfiles = new ObservableListSource<Perfil>()},
            //    new Usuario{usuario="cdc",nombre="Christian Damian",apellido="Cristofano",pass="1234",creacion=DateTime.Parse("2005-09-01"),activo=true},
            //};

            //usuarios.ForEach(s => context.Usuarios.Add(s));
            //context.SaveChanges();

            //context.Usuarios.SingleOrDefault(x => x.nombre == "Admin").Perfiles.Add(context.Perfiles.SingleOrDefault(p => p.nombre == "Admin"));
            //context.SaveChanges();
            ///*var usuariosPerfiles = new List<UsuarioPerfil>
            //{
            //new UsuarioPerfil{UsuarioID=0,PerfilID=0},
            //new UsuarioPerfil{UsuarioID=0,PerfilID=1},
            //new UsuarioPerfil{UsuarioID=0,PerfilID=2},
            //new UsuarioPerfil{UsuarioID=1,PerfilID=0},
            //new UsuarioPerfil{UsuarioID=1,PerfilID=1},
            
            //};
            //usuariosPerfiles.ForEach(s => context.UsuariosPerfiles.Add(s));
            //context.SaveChanges();*/
            

            //var permisos = new List<Permiso>
            //{
            //new Permiso{nombre="Admin",descripcion="Admin",creacion=DateTime.Parse("2005-09-01"),activo=true},
            //new Permiso{nombre="Estadistcas",descripcion="Estadistcas",creacion=DateTime.Parse("2005-09-01"),activo=true},
            //new Permiso{nombre="Altas",descripcion="Altas",creacion=DateTime.Parse("2005-09-01"),activo=true},
            
            //};
            //permisos.ForEach(s => context.Permisos.Add(s));
            //context.SaveChanges();

            //var Empresas = new List<Empresa>
            //{
            //new Empresa{EmpresaID = 1,Nombre = "Credin S.A.",Descripcion = "Credin S.A."},
            //new Empresa{EmpresaID = 2,Nombre = "ACuatro S.A.",Descripcion = "ACuatro S.A."},
            //new Empresa{EmpresaID = 3,Nombre = "Crédito del Valle S.A.",Descripcion = "Crédito del Valle S.A."},
            //};
            //Empresas.ForEach(e => context.Empresas.Add(e));
            //context.SaveChanges();
            
            //var Comercios = new List<Comercio>
            //{
            //    new Comercio{ComercioID = 801,Nombre = "Receptoría Rivadavia",Descripcion = "Receptoría Rivadavia",EmpresaID = 1}
            //};
            //Comercios.ForEach(c => context.Comercios.Add(c));
            //context.SaveChanges();


            //var TipoEstados = new List<TipoEstado>
            //{
            //    new TipoEstado{TipoEstadoID=1,Nombre = "EstadoCuentasBancariasEmpleados",Descripcion = "EstadoCuentasBancariasEmpleados"},
            //    new TipoEstado{TipoEstadoID=2,Nombre = "EstadoCuentasBancariasEmpresas",Descripcion = "EstadoCuentasBancariasEmpresas"},
            //    new TipoEstado{TipoEstadoID=3,Nombre = "EstadoChequeras",Descripcion = "EstadoChequeras"},
            //    new TipoEstado{TipoEstadoID=4,Nombre = "EstadoMensajes",Descripcion = "EstadoMensajes"},
            //    new TipoEstado{TipoEstadoID=5,Nombre = "EstadoAlertas",Descripcion = "EstadoAlertas"},
            //    new TipoEstado{TipoEstadoID=6,Nombre = "EstadoSolicitudesFondos",Descripcion = "EstadoSolicitudesFondos"},
            //    new TipoEstado{TipoEstadoID=7,Nombre = "EstadoAutorizaciones",Descripcion = "EstadoAutorizaciones"},
            //    new TipoEstado{TipoEstadoID=8,Nombre = "EstadoOrdenesDePago",Descripcion = "EstadoOrdenesDePago"},
            //    new TipoEstado{TipoEstadoID=9,Nombre = "EstadoEmpleados",Descripcion = "EstadoEmpleados"},
            //    new TipoEstado{TipoEstadoID=10,Nombre = "EstadoUsuarios",Descripcion = "EstadoUsuarios"},
            //    new TipoEstado{TipoEstadoID=11,Nombre = "EstadoCreditos",Descripcion = "EstadoCreditos"},
            //    new TipoEstado{TipoEstadoID=12,Nombre = "EstadoCheques",Descripcion = "EstadoCheques"}
            //};
            //TipoEstados.ForEach(c => context.TiposEstados.Add(c));
            //context.SaveChanges();

            //var Estados = new List<Estado>
            //{
            //    new Estado{EstadoID = 1,Nombre="Habilitada",Descripcion="Habilitada",TipoEstadoID=1,est_color = "WHITE"},  
            //    new Estado{EstadoID = 2,Nombre="Inhabilitada",Descripcion="Inhabilitada",TipoEstadoID=1,est_color = "WHITE"},
            //    new Estado{EstadoID = 3,Nombre="Habilitada",Descripcion="Habilitada",TipoEstadoID=2,est_color = "WHITE"},
            //    new Estado{EstadoID = 4,Nombre="Inhabilitada",Descripcion="Inhabilitada",TipoEstadoID=2,est_color = "WHITE"},
            //    new Estado{EstadoID = 5,Nombre="Habilitada",Descripcion="Habilitada",TipoEstadoID=3,est_color = "WHITE"},
            //    new Estado{EstadoID = 6,Nombre="Inhabilitada",Descripcion="Inhabilitada",TipoEstadoID=3,est_color = "WHITE"},
            //    new Estado{EstadoID = 7,Nombre="Enviado",Descripcion="Enviado",TipoEstadoID=4,est_color = "WHITE"},
            //    new Estado{EstadoID = 8,Nombre="En espera",Descripcion="En espera",TipoEstadoID=4,est_color = "WHITE"},
            //    new Estado{EstadoID = 9,Nombre="Recibido",Descripcion="Recibido",TipoEstadoID=4,est_color = "WHITE"},
            //    new Estado{EstadoID = 10,Nombre="Leido",Descripcion="Leido",TipoEstadoID=4,est_color = "WHITE"},
            //    new Estado{EstadoID = 11,Nombre="No Leido",Descripcion="No Leido",TipoEstadoID=4,est_color = "WHITE"},
            //    new Estado{EstadoID = 12,Nombre="Destacado",Descripcion="Destacado",TipoEstadoID=4,est_color = "WHITE"},
            //    new Estado{EstadoID = 13,Nombre="Importante",Descripcion="Importante",TipoEstadoID=4,est_color = "WHITE"},
            //    new Estado{EstadoID = 14,Nombre="Enviada",Descripcion="Enviada",TipoEstadoID=5,est_color = "WHITE"},
            //    new Estado{EstadoID = 15,Nombre="En espera",Descripcion="En espera",TipoEstadoID=5,est_color = "WHITE"},
            //    new Estado{EstadoID = 16,Nombre="Recibida",Descripcion="Recibida",TipoEstadoID=5,est_color = "WHITE"},
            //    new Estado{EstadoID = 17,Nombre="Leida",Descripcion="Leida",TipoEstadoID=5,est_color = "WHITE"},
            //    new Estado{EstadoID = 18,Nombre="No Leida",Descripcion="No Leida",TipoEstadoID=5,est_color = "WHITE"},
            //    new Estado{EstadoID = 19,Nombre="Destacada",Descripcion="Destacada",TipoEstadoID=5,est_color = "WHITE"},
            //    new Estado{EstadoID = 20,Nombre="Importante",Descripcion="Importante",TipoEstadoID=5,est_color = "WHITE"},
            //    new Estado{EstadoID = 21,Nombre="Inicial",Descripcion="Inicial",TipoEstadoID=6,est_color = "WHITE"},
            //    new Estado{EstadoID = 22,Nombre="Pendiente de resolución en tesorería",Descripcion="Pendiente de resolución en tesorería",TipoEstadoID=6,est_color = "WHITE"},
            //    new Estado{EstadoID = 23,Nombre="Rechazada en tesorería",Descripcion="Rechazada en tesorería",TipoEstadoID=6,est_color = "WHITE"},
            //    new Estado{EstadoID = 24,Nombre="Pendiente de resolución en gerencia",Descripcion="Pendiente de resolución en gerencia",TipoEstadoID=6,est_color = "WHITE"},
            //    new Estado{EstadoID = 25,Nombre="Autorizada en gerencia",Descripcion="Autorizada en gerencia",TipoEstadoID=6,est_color = "WHITE"},
            //    new Estado{EstadoID = 26,Nombre="Rechazada en gerencia",Descripcion="Rechazada en gerencia",TipoEstadoID=6,est_color = "WHITE"},
            //    new Estado{EstadoID = 28,Nombre="Autorizada",Descripcion="Autorizada",TipoEstadoID=6,est_color = "WHITE"},
            //    new Estado{EstadoID = 33,Nombre="Confirmada",Descripcion="Confirmada",TipoEstadoID=6,est_color = "WHITE"},
            //    new Estado{EstadoID = 34,Nombre="Aceptada",Descripcion="Aceptada",TipoEstadoID=7,est_color = "WHITE"},
            //    new Estado{EstadoID = 35,Nombre="En espera",Descripcion="En espera",TipoEstadoID=7,est_color = "WHITE"},
            //    new Estado{EstadoID = 36,Nombre="Rechazada",Descripcion="Rechazada",TipoEstadoID=7,est_color = "WHITE"},
            //    new Estado{EstadoID = 37,Nombre="Anulada",Descripcion="Anulada",TipoEstadoID=7,est_color = "WHITE"},
            //    new Estado{EstadoID = 38,Nombre="Conformada",Descripcion="Conformada",TipoEstadoID=7,est_color = "WHITE"},
            //    new Estado{EstadoID = 39,Nombre="Aceptada",Descripcion="Aceptada",TipoEstadoID=8,est_color = "WHITE"},
            //    new Estado{EstadoID = 40,Nombre="En espera",Descripcion="En espera",TipoEstadoID=8,est_color = "WHITE"},
            //    new Estado{EstadoID = 41,Nombre="Rechazada",Descripcion="Rechazada",TipoEstadoID=8,est_color = "WHITE"},
            //    new Estado{EstadoID = 42,Nombre="Anulada",Descripcion="Anulada",TipoEstadoID=8,est_color = "WHITE"},
            //    new Estado{EstadoID = 43,Nombre="Pagada",Descripcion="Pagada",TipoEstadoID=8,est_color = "WHITE"},
            //    new Estado{EstadoID = 44,Nombre="Emitida",Descripcion="Emitida",TipoEstadoID=8,est_color = "WHITE"},
            //    new Estado{EstadoID = 45,Nombre="Conformada",Descripcion="Conformada",TipoEstadoID=8,est_color = "WHITE"},
            //    new Estado{EstadoID = 46,Nombre="Activo",Descripcion="Activo",TipoEstadoID=9,est_color = "WHITE"},
            //    new Estado{EstadoID = 47,Nombre="Desvinculado",Descripcion="Desvinculado",TipoEstadoID=9,est_color = "WHITE"},
            //    new Estado{EstadoID = 48,Nombre="Activo",Descripcion="Activo",TipoEstadoID=10,est_color = "WHITE"},
            //    new Estado{EstadoID = 49,Nombre="Inactivo",Descripcion="Inactivo",TipoEstadoID=10,est_color = "WHITE"},
            //    new Estado{EstadoID = 50,Nombre="Moroso",Descripcion="Moroso",TipoEstadoID=11,est_color = "WHITE"},
            //    new Estado{EstadoID = 51,Nombre="Activo",Descripcion="Activo",TipoEstadoID=11,est_color = "WHITE"},
            //    new Estado{EstadoID = 52,Nombre="Cancelado",Descripcion="Cancelado",TipoEstadoID=11,est_color = "WHITE"},
            //    new Estado{EstadoID = 53,Nombre="Habilitado",Descripcion="Habilitado",TipoEstadoID=12,est_color = "WHITE"},
            //    new Estado{EstadoID = 54,Nombre="Inhabilitado",Descripcion="Inhabilitado",TipoEstadoID=12,est_color = "WHITE"},
            //    new Estado{EstadoID = 56,Nombre="Anulado",Descripcion="Anulado",TipoEstadoID=12,est_color = "WHITE"},
            //    new Estado{EstadoID = 58,Nombre="Utilizado",Descripcion="Utilizado",TipoEstadoID=12,est_color = "WHITE"},

            //};
            //Estados.ForEach(c => context.Estados.Add(c));
            //context.SaveChanges();


            //var MediosDePago = new List<MedioDePago>
            //{
            //    new MedioDePago{MedioDePagoID=1,Nombre = "Efectivo",Descripcion = "Efectivo" },
            //    new MedioDePago{MedioDePagoID=2,Nombre = "Cheque",Descripcion = "Cheque" },
            //    new MedioDePago{MedioDePagoID=3,Nombre = "Transferencia Bancaria",Descripcion = "Transferencia Bancaria" }
            //};
            //MediosDePago.ForEach(m => context.MediosDePagos.Add(m));
            //context.SaveChanges();

            //var ConceptoFondos = new List<ConceptoFondos>
            //{
            //    new ConceptoFondos{ConceptoFondosID=1,Nombre = "Retención de Cobranzas",Descripcion = "Retención de Cobranzas",MedioDePagoID =1 },
            //    new ConceptoFondos{ConceptoFondosID=2,Nombre = "Extración bancaria",Descripcion = "Extración bancaria",MedioDePagoID =2 },
            //    new ConceptoFondos{ConceptoFondosID=4,Nombre = "Retención de Valores a Rendir",Descripcion = "Retención de Valores a Rendir",MedioDePagoID =1 }
                
            //};
            //ConceptoFondos.ForEach(c => context.ConceptoFondos.Add(c));
            //context.SaveChanges();

           

            //var TiposSolicitud = new List<TipoSolicitud>
            //{
            //    new TipoSolicitud{TipoSolicitudID=1,Nombre = "Ventas",Descripcion = "Ventas" },
            //    new TipoSolicitud{TipoSolicitudID=2,Nombre = "Cuentas a pagar",Descripcion = "Cuentas a pagar" },
            //    new TipoSolicitud{TipoSolicitudID=3,Nombre = "Fondo Fijo",Descripcion = "Fondo Fijo" },
            //    new TipoSolicitud{TipoSolicitudID=4,Nombre = "Venta Anticipada",Descripcion = "Venta Anticipada" },
            //};
            //TiposSolicitud.ForEach(t => context.TiposSolicitud.Add(t));
            //context.SaveChanges();

            //var EstadosTransmision = new List<EstadoTransmision>
            //{
            //    new EstadoTransmision{EstadoTransmisionID=1,Nombre = "Enviado",Descripcion = "Enviado" },
            //    new EstadoTransmision{EstadoTransmisionID=2,Nombre = "Pendiente de envío",Descripcion = "Pendiente de envío" },
            //    new EstadoTransmision{EstadoTransmisionID=3,Nombre = "Recibido",Descripcion = "Recibido" }
                
            //};
            //EstadosTransmision.ForEach(t => context.EstadoTransmisiones.Add(t));
            //context.SaveChanges();




        }
    }
}
