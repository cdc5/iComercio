using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iComercio.Models;
using iComercio.Auxiliar;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace iComercio.Models
{
    public class CargaBD
    {
        public void LlenarConDatos(int BaseIDbd,iComercio.DAL.ComercioContext context)
        {
            //if (System.Diagnostics.Debugger.IsAttached == false)
            //    System.Diagnostics.Debugger.Launch();
            //try
            //{
            if (context.Empresas.Count() == 0)
            {

                BusinessLayer.CargarScriptPaisesProvinciasLocalidades(context,System.IO.Directory.GetCurrentDirectory() + "\\Documentos\\BD\\Scritp paises, provincias, localidades Argentina solo datos.sql");

                var perfiles = new List<Perfil>
                    {
                    new Perfil{nombre="Admin",descripcion="Admin",creacion=DateTime.Parse("2005-09-01"),activo=true,Permisos = new ObservableListSource<Permiso>()},
                    new Perfil{nombre="Usuario",descripcion="usuario",creacion=DateTime.Parse("2005-09-01"),activo=true, Permisos = new ObservableListSource<Permiso>()},
                    new Perfil{nombre="Encargado Receptoría",descripcion="Encargado Receptoría",creacion=DateTime.Parse("2005-09-01"),activo=true, Permisos = new ObservableListSource<Permiso>()},
                    new Perfil{nombre="Empleado Receptoría",descripcion="Empleado Receptoría",creacion=DateTime.Parse("2005-09-01"),activo=true, Permisos = new ObservableListSource<Permiso>()},
                    new Perfil{nombre="Encargado Comercio",descripcion="Encargado Comercio",creacion=DateTime.Parse("2005-09-01"),activo=true, Permisos = new ObservableListSource<Permiso>()},
                    new Perfil{nombre="Empleado Comercio",descripcion="Empleado Comercio",creacion=DateTime.Parse("2005-09-01"),activo=true, Permisos = new ObservableListSource<Permiso>()}
                    };
                perfiles.ForEach(s => context.Perfiles.Add(s));
                context.SaveChanges();


                var usuarios = new List<Usuario>
                    {
                        new Usuario{usuario="admin",nombre="Admin",apellido="Admin",pass="p0p0t3",creacion=DateTime.Parse("2005-09-01"),activo=true,Perfiles = new ObservableListSource<Perfil>()},
                        //  por edu
                       // new Usuario{usuario="e",nombre="e",apellido="e",pass="e",creacion=DateTime.Parse("2005-09-01"),activo=true,Perfiles = new ObservableListSource<Perfil>()},
                   
                    
                        // new Usuario{usuario="cdc",nombre="Christian Damian",apellido="Cristofano",pass="1234",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    };

                usuarios.ForEach(s => context.Usuarios.Add(s));
                context.SaveChanges();

                Usuario usu = context.Usuarios.SingleOrDefault(x => x.nombre == "Admin");
                ObservableListSource<Perfil> pers = usu.Perfiles;
                Perfil perf = context.Perfiles.SingleOrDefault(p => p.nombre == "Admin");
                pers.Add(perf);
                context.SaveChanges();

                /*var usuariosPerfiles = new List<UsuarioPerfil>
                {
                new UsuarioPerfil{UsuarioID=0,PerfilID=0},
                new UsuarioPerfil{UsuarioID=0,PerfilID=1},
                new UsuarioPerfil{UsuarioID=0,PerfilID=2},
                new UsuarioPerfil{UsuarioID=1,PerfilID=0},
                new UsuarioPerfil{UsuarioID=1,PerfilID=1},
                };
                usuariosPerfiles.ForEach(s => context.UsuariosPerfiles.Add(s));
                context.SaveChanges();*/


                var permisos = new List<Permiso>
                    {
                    new Permiso{nombre="Admin",descripcion="Admin",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="Estadistcas",descripcion="Estadistcas",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="Altas",descripcion="Altas",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuFondos",descripcion="mnuFondos",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuConfiguracion",descripcion="mnuConfiguracion",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuAdminUsuarios",descripcion="mnuAdminUsuarios",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuSolicitarFondos",descripcion="mnuSolicitarFondos",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuUsuarios",descripcion="mnuUsuarios",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuAdminPerfiles",descripcion="mnuAdminPerfiles",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuPerfiles",descripcion="mnuPerfiles",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuAsignarPerfilesUsuarios",descripcion="mnuAsignarPerfilesUsuarios",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuPermisos",descripcion="mnuPermisos",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuOpciones",descripcion="mnuOpciones",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuAsignarPermisosPerfiles",descripcion="mnuAsignarPermisosPerfiles",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuCuentaCorriente",descripcion="mnuCuentaCorriente",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuVerCuentaCorriente",descripcion="mnuVerCuentaCorriente",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuProveedores",descripcion="mnuProveedores",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuListadoDeProveedores",descripcion="mnuListadoDeProveedores",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuABMProveedores",descripcion="mnuABMProveedores",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuABM",descripcion="mnuABM",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuABMConcpGst",descripcion="mnuABMConcpGst",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuCreditos",descripcion="mnuCreditos",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuCreditosAlta",descripcion="mnuCreditosAlta",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuBD",descripcion="mnuBD",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuBDMigracion",descripcion="mnuBDMigracion",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuBDMigracionClientes",descripcion="mnuBDMigracionClientes",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuBDMigracionCreditos",descripcion="mnuBDMigracionCreditos",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuBDMigracionCuotas",descripcion="mnuBDMigracionCuotas",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuBDMigracionCobranzas",descripcion="mnuBDMigracionCobranzas",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuBDMigracionRefinanciaciones",descripcion="mnuBDMigracionRefinanciaciones",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuPlanes",descripcion="mnuPlanes",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuPuntajes",descripcion="mnuPuntajes",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuCobranzas",descripcion="mnuCobranzas",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuClientePorNombre",descripcion="mnuClientePorNombre",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuClientePorDocumento",descripcion="mnuClientePorDocumento",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuClienteModificar",descripcion="mnuClienteModificar",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuClienteNuevo",descripcion="mnuClienteNuevo",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuCobranzasConsulta",descripcion="mnuCobranzasConsulta",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuCobranzasAnulacion",descripcion="mnuCobranzasAnulacion",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="Avalar",descripcion="Avalar",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="refinancia",descripcion="refinancia",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="Cancelarefinanciacion",descripcion="Cancelarefinanciacion",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="cobranza",descripcion="cobranza",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuRecibos",descripcion="mnuRecibos",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuConsAltaCred",descripcion="mnuConsAltaCred",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuListados",descripcion="mnuListados",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuReimpresiones",descripcion="mnuReimpresiones",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuCap",descripcion="mnuCap",creacion=DateTime.Parse("2005-09-01"),activo=true},                   
                    new Permiso{nombre="mnuClientes",descripcion="mnuClientes",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuConsultas",descripcion="mnuConsultas",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuConsListados",descripcion="mnuConsListados",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuConsListadosListados",descripcion="mnuConsListadosListados",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuPlanesABM",descripcion="mnuPlanesABM",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuAnulCred",descripcion="mnuAnulCred",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuCapABM",descripcion="mnuCapABM",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuCapListado",descripcion="mnuCapListado",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuFFABM",descripcion="mnuFFListado",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuFFListado",descripcion="mnuFFListado",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuRefiACred",descripcion="mnuRefiACred",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuPlanesConsulta",descripcion="mnuPlanesConsulta",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuCuentaCorrienteAnulacion",descripcion="mnuCuentaCorrienteAnulacion",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuCuentaCorrienteComercio",descripcion="mnuCuentaCorrienteComercio",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuGastos",descripcion="mnuGastos",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuTransmisiones",descripcion="mnuTransmisiones",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuArreglarCuotas",descripcion="mnuArreglarCuotas",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuArreglarImporteCuotas",descripcion="mnuArreglarImporteCuotas",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuCuentaCorrienteDiaria",descripcion="mnuCuentaCorrienteDiaria",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="CambiaMinimo",descripcion="CambiaMinimo",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="mnuActualizaciones",descripcion="mnuActualizaciones",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="HabilitaPagoNormalDebitoDirecto",descripcion="HabilitaPagoNormalDebitoDirecto",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="permPagoAnticipado",descripcion="permPagoAnticipado",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="permCambiaPunitorios",descripcion="permCambiaPunitorios",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="permArregloPagos",descripcion="permArregloPagos",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="permQuitaPunitorios",descripcion="permQuitaPunitorios",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="permPermiteBonificar",descripcion="permPermiteBonificar",creacion=DateTime.Parse("2005-09-01"),activo=true},
                    new Permiso{nombre="pagoAbogado",descripcion="pagoAbogado",creacion=DateTime.Parse("2005-09-01"),activo=true}                    
                    };

                permisos.ForEach(s => context.Permisos.Add(s));
                context.SaveChanges();

                perf = context.Perfiles.SingleOrDefault(x => x.nombre == "Admin");
                permisos.ForEach(s => perf.Permisos.Add(s));
                context.SaveChanges();

                perf = context.Perfiles.SingleOrDefault(x => x.nombre == "Encargado Receptoría");
                var perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuFondos");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuSolicitarFondos");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuAlta");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuCobranzas");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuClientePorNombre");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuClientePorDocumento");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuClienteModificar");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuClienteNuevo");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuCobranzasConsulta");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuConsAltaCred");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuCobranzasAnulacion");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "Avalar");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "refinancia");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "Cancelarefinanciacion");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuCreditos");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuCreditosAlta");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuReimpresiones");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuClientes");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuConsultas");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuConsListados");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuCap");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuRecibos");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuCapABM");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuCapListado");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuFFABM");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuFFListado");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "Altas");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuCuentaCorriente");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuVerCuentaCorriente");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuPlanes");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "cobranza");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuListados");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuAnulCred");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuRefiACred");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuPlanesConsulta");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuCuentaCorrienteAnulacion");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuGastos");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuCuentaCorrienteDiaria");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "CambiaMinimo");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "permPagoAnticipado");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "permCambiaPunitorios");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "permArregloPagos");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "permQuitaPunitorios");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "permPermiteBonificar");
                perf.Permisos.Add(perm);

                context.SaveChanges();

                var perf2 = context.Perfiles.SingleOrDefault(x => x.nombre == "Empleado Receptoría");
                perf2.Permisos = perf.Permisos;
                context.SaveChanges();

                perf = context.Perfiles.SingleOrDefault(x => x.nombre == "Encargado Comercio");
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuAlta");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuCobranzas");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuClientePorNombre");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuClientePorDocumento");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuClienteModificar");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuClienteNuevo");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuCobranzasConsulta");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuConsAltaCred");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuCobranzasAnulacion");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "Avalar");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "refinancia");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "Cancelarefinanciacion");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuCreditos");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuCreditosAlta");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuReimpresiones");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuClientes");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuConsultas");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuConsListados");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuRecibos");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "Altas");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuCuentaCorriente");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuVerCuentaCorriente");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "cobranza");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuListados");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuAnulCred");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuRefiACred");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuCuentaCorrienteAnulacion");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuGastos");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "mnuCuentaCorrienteDiaria");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "CambiaMinimo");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "permPagoAnticipado");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "permCambiaPunitorios");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "permArregloPagos");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "permQuitaPunitorios");
                perf.Permisos.Add(perm);
                perm = context.Permisos.SingleOrDefault(x => x.nombre == "permPermiteBonificar");
                perf.Permisos.Add(perm);
                context.SaveChanges();

                perf2 = context.Perfiles.SingleOrDefault(x => x.nombre == "Empleado Comercio");
                perf2.Permisos = perf.Permisos;
                context.SaveChanges();

                List<Empresa> Empresas = new List<Empresa>();
                if (BaseIDbd == 1 || BaseIDbd == 2 || BaseIDbd == 3){
                    Empresas.Add(new Empresa{EmpresaID = 1,Nombre = "Credin S.A.",Descripcion = "Credin S.A.",EmpresaDiminutivo = "CD",CP = "(C1431FCT)",Cuit = "30-65920657-5", Domicilio = "Avda. Triunvirato 5350", IA = "Responsable Inscripto - 03/1993", IIBB = "C.M.901-990030-5", Localidad = "CABA", Telefono1 = "4544-2224", Telefono2 = "4544-1871", Telefono3 = "4544-1994",Telefonos = "4544-2224/1871/1994", Mail = "info@credin.com.ar"});
                    Empresas.Add(new Empresa { EmpresaID = 2, Nombre = "ACuatro S.A.", Descripcion = "ACuatro S.A.", EmpresaDiminutivo = "A4", CP = "(C1431FCT)", Cuit = "30-70914487-8", Domicilio = "Avda. Triunvirato 5350", IA = "Responsable Inscripto - 04/2005", IIBB = "C.M.901-210802-0", Localidad = "CABA", Telefono1 = "4544-2224", Telefono2 = "4544-1871", Telefono3 = "4544-1994", Telefonos = "4544-2224/1871/1994", Mail = "info@credin.com.ar" });
                    Empresas.Add(new Empresa { EmpresaID = 3, Nombre = "Crédito del Valle S.A.", Descripcion = "Crédito del Valle S.A.", EmpresaDiminutivo = "CDV", CP = "(C1431FCT)",Cuit = "30-69099739-4", Domicilio = "Avda. Triunvirato 5350", IA = "Responsable Inscripto - 03/2005", IIBB = "C.M.901-191598-5", Localidad = "CABA", Telefono1 = "4544-2224", Telefono2 = "4544-1871", Telefono3 = "4544-1994",Telefonos = "4544-2224/1871/1994",Mail = "info@credin.com.ar"});
                } 
                else if (BaseIDbd == 99){
                    Empresas.Add(new Empresa { EmpresaID = 99, Nombre = "NC S.A.", Descripcion = "NC S.A.", EmpresaDiminutivo = "NC" });
                };                
                                                
                Empresas.ForEach(e => context.Empresas.Add(e));
                context.SaveChanges();

                var TiposComercios = new List<TipoComercio>
                    {
                        new TipoComercio{TipoComercioID = 1,Nombre = "Comercio",Descripcion = "Comercio"},
                        new TipoComercio{TipoComercioID = 2,Nombre = "Receptoría",Descripcion = "Receptoría"},
                        new TipoComercio{TipoComercioID = 3,Nombre = "Cobrador",Descripcion = "Cobrador"},
                        new TipoComercio{TipoComercioID = 4,Nombre = "Abogado",Descripcion = "Abogado"},
                        new TipoComercio{TipoComercioID = 5,Nombre = "Receptorías antiguas",Descripcion = "Receptorías antiguas"},
                        new TipoComercio{TipoComercioID = 6,Nombre = "Comercios antiguos",Descripcion = "Comercios antiguos"},
                        new TipoComercio{TipoComercioID = 7,Nombre = "Casa Central",Descripcion = "Casa Central"},
                        new TipoComercio{TipoComercioID = 8,Nombre = "Receptoría Ambulante",Descripcion = "Receptoría Ambulante"}
                    };

                TiposComercios.ForEach(c => context.TiposComercios.Add(c));
                context.SaveChanges();
                List<Comercio> Comercios = new List<Comercio>();

                 if (BaseIDbd == 1 || BaseIDbd == 2 || BaseIDbd == 3){
                    Comercios.Add(new Comercio{ComercioID = 801,Nombre = "Receptoría Rivadavia",Descripcion = "Receptoría Rivadavia",EmpresaID = 1,Principal = true,Por30=0.0081m,Por30M=0.0081m,PorSueldo = 30,TipoComercioID = 2,PuedeCobrar = true,IntRef = 30,Tolerancia = 6,ToleranciaBoni = 0});
                    Comercios.Add(new Comercio { ComercioID = 999, Nombre = "Casa Central", Descripcion = "Casa Central", EmpresaID = 1, Principal = false, TipoComercioID = 7, Por30 = 0.0081m, Por30M = 0.0081m, PorSueldo = 30, PuedeCobrar = true, IntRef = 30, Tolerancia = 6, ToleranciaBoni = 0 });
                 }
                 else if (BaseIDbd == 99){
                     Comercios.Add(new Comercio { ComercioID = 3799, Nombre = "Receptoría NC", Descripcion = "Receptoría NC", EmpresaID = 99, Principal = true, Por30 = 0.0081m, Por30M = 0.0081m, PorSueldo = 30, TipoComercioID = 2, PuedeCobrar = true, IntRef = 30, Tolerancia = 6, ToleranciaBoni = 0 });
                     Comercios.Add(new Comercio { ComercioID = 999, Nombre = "NC", Descripcion = "NC", EmpresaID = 99, Principal = false, TipoComercioID = 7, Por30 = 0.0081m, Por30M = 0.0081m, PorSueldo = 30, PuedeCobrar = true, IntRef = 30, Tolerancia = 6, ToleranciaBoni = 0 });
                 }

                Comercios.ForEach(c => context.Comercios.Add(c));
                context.SaveChanges();

                var TiposTransferenciasDepositos = new List<TipoTransferenciaDeposito>
                    {
                        new TipoTransferenciaDeposito{TipoTransferenciaDepositoID = 1,Nombre = "Financiera",Descripcion = "Financiera"},
                        new TipoTransferenciaDeposito{TipoTransferenciaDepositoID = 2,Nombre = "Comercio",Descripcion = "Comercio"}                     
                    };

                TiposTransferenciasDepositos.ForEach(c => context.TipoTransferenciaDeposito.Add(c));
                context.SaveChanges();

                var TipoEstados = new List<TipoEstado>
                    {
                        new TipoEstado{TipoEstadoID=1,Nombre = "EstadoCuentasBancariasEmpleados",Descripcion = "EstadoCuentasBancariasEmpleados"},
                        new TipoEstado{TipoEstadoID=2,Nombre = "EstadoCuentasBancariasEmpresas",Descripcion = "EstadoCuentasBancariasEmpresas"},
                        new TipoEstado{TipoEstadoID=3,Nombre = "EstadoChequeras",Descripcion = "EstadoChequeras"},
                        new TipoEstado{TipoEstadoID=4,Nombre = "EstadoMensajes",Descripcion = "EstadoMensajes"},
                        new TipoEstado{TipoEstadoID=5,Nombre = "EstadoAlertas",Descripcion = "EstadoAlertas"},
                        new TipoEstado{TipoEstadoID=6,Nombre = "EstadoSolicitudesFondos",Descripcion = "EstadoSolicitudesFondos"},
                        new TipoEstado{TipoEstadoID=7,Nombre = "EstadoAutorizaciones",Descripcion = "EstadoAutorizaciones"},
                        new TipoEstado{TipoEstadoID=8,Nombre = "EstadoOrdenesDePago",Descripcion = "EstadoOrdenesDePago"},
                        new TipoEstado{TipoEstadoID=9,Nombre = "EstadoEmpleados",Descripcion = "EstadoEmpleados"},
                        new TipoEstado{TipoEstadoID=10,Nombre = "EstadoUsuarios",Descripcion = "EstadoUsuarios"},
                        new TipoEstado{TipoEstadoID=11,Nombre = "EstadoCreditos",Descripcion = "EstadoCreditos"},
                        new TipoEstado{TipoEstadoID=12,Nombre = "EstadoCheques",Descripcion = "EstadoCheques"},
                        new TipoEstado{TipoEstadoID=13,Nombre = "EstadoProveedores",Descripcion = "EstadoProveedores"},
                        new TipoEstado{TipoEstadoID=14,Nombre = "EstadoProveedoresSucursales",Descripcion = "EstadoProveedoresSucursales"},
                        new TipoEstado{TipoEstadoID=15,Nombre = "EstadoConceptoGastos",Descripcion = "EstadoConceptoGastos"},
                        new TipoEstado{TipoEstadoID=16,Nombre = "EstadoConceptoGastosProveedor",Descripcion = "EstadoConceptoGastosProveedor"},
                        new TipoEstado{TipoEstadoID=17,Nombre = "EstadoCliente",Descripcion = "EstadoCliente"},
                        new TipoEstado{TipoEstadoID=18,Nombre = "EstadoGeneral",Descripcion = "EstadoGeneral"},
                        new TipoEstado{TipoEstadoID=19,Nombre = "EstadoOrdenPago",Descripcion = "EstadoOrdenPago"},
                        new TipoEstado{TipoEstadoID=20,Nombre = "EstadoRecibo",Descripcion = "EstadoRecibo"},
                        new TipoEstado{TipoEstadoID=21,Nombre = "EstadoTransferenciaDeposito",Descripcion = "EstadoTransferenciaDeposito"}

                    };
                TipoEstados.ForEach(c => context.TiposEstados.Add(c));
                context.SaveChanges();

                var Estados = new List<Estado>
                    {
                        new Estado{EstadoID = 1,Nombre="Habilitada",Descripcion="Habilitada",TipoEstadoID=1,est_color = "WHITE"},  
                        new Estado{EstadoID = 2,Nombre="Inhabilitada",Descripcion="Inhabilitada",TipoEstadoID=1,est_color = "WHITE"},
                        new Estado{EstadoID = 3,Nombre="Habilitada",Descripcion="Habilitada",TipoEstadoID=2,est_color = "WHITE"},
                        new Estado{EstadoID = 4,Nombre="Inhabilitada",Descripcion="Inhabilitada",TipoEstadoID=2,est_color = "WHITE"},
                        new Estado{EstadoID = 5,Nombre="Habilitada",Descripcion="Habilitada",TipoEstadoID=3,est_color = "WHITE"},
                        new Estado{EstadoID = 6,Nombre="Inhabilitada",Descripcion="Inhabilitada",TipoEstadoID=3,est_color = "WHITE"},
                        new Estado{EstadoID = 7,Nombre="Enviado",Descripcion="Enviado",TipoEstadoID=4,est_color = "WHITE"},
                        new Estado{EstadoID = 8,Nombre="En espera",Descripcion="En espera",TipoEstadoID=4,est_color = "WHITE"},
                        new Estado{EstadoID = 9,Nombre="Recibido",Descripcion="Recibido",TipoEstadoID=4,est_color = "WHITE"},
                        new Estado{EstadoID = 10,Nombre="Leido",Descripcion="Leido",TipoEstadoID=4,est_color = "WHITE"},
                        new Estado{EstadoID = 11,Nombre="No Leido",Descripcion="No Leido",TipoEstadoID=4,est_color = "WHITE"},
                        new Estado{EstadoID = 12,Nombre="Destacado",Descripcion="Destacado",TipoEstadoID=4,est_color = "WHITE"},
                        new Estado{EstadoID = 13,Nombre="Importante",Descripcion="Importante",TipoEstadoID=4,est_color = "WHITE"},
                        new Estado{EstadoID = 14,Nombre="Enviada",Descripcion="Enviada",TipoEstadoID=5,est_color = "WHITE"},
                        new Estado{EstadoID = 15,Nombre="En espera",Descripcion="En espera",TipoEstadoID=5,est_color = "WHITE"},
                        new Estado{EstadoID = 16,Nombre="Recibida",Descripcion="Recibida",TipoEstadoID=5,est_color = "WHITE"},
                        new Estado{EstadoID = 17,Nombre="Leida",Descripcion="Leida",TipoEstadoID=5,est_color = "WHITE"},
                        new Estado{EstadoID = 18,Nombre="No Leida",Descripcion="No Leida",TipoEstadoID=5,est_color = "WHITE"},
                        new Estado{EstadoID = 19,Nombre="Destacada",Descripcion="Destacada",TipoEstadoID=5,est_color = "WHITE"},
                        new Estado{EstadoID = 20,Nombre="Importante",Descripcion="Importante",TipoEstadoID=5,est_color = "WHITE"},
                        new Estado{EstadoID = 21,Nombre="Inicial",Descripcion="Inicial",TipoEstadoID=6,est_color = "WHITE"},
                        new Estado{EstadoID = 22,Nombre="Pendiente de resolución en tesorería",Descripcion="Pendiente de resolución en tesorería",TipoEstadoID=6,est_color = "WHITE"},
                        new Estado{EstadoID = 23,Nombre="Rechazada en tesorería",Descripcion="Rechazada en tesorería",TipoEstadoID=6,est_color = "WHITE"},
                        new Estado{EstadoID = 24,Nombre="Pendiente de resolución en gerencia",Descripcion="Pendiente de resolución en gerencia",TipoEstadoID=6,est_color = "WHITE"},
                        new Estado{EstadoID = 25,Nombre="Autorizada en gerencia",Descripcion="Autorizada en gerencia",TipoEstadoID=6,est_color = "WHITE"},
                        new Estado{EstadoID = 26,Nombre="Rechazada en gerencia",Descripcion="Rechazada en gerencia",TipoEstadoID=6,est_color = "WHITE"},
                        new Estado{EstadoID = 28,Nombre="Autorizada",Descripcion="Autorizada",TipoEstadoID=6,est_color = "WHITE"},
                        new Estado{EstadoID = 33,Nombre="Confirmada",Descripcion="Confirmada",TipoEstadoID=6,est_color = "WHITE"},
                        new Estado{EstadoID = 34,Nombre="Aceptada",Descripcion="Aceptada",TipoEstadoID=7,est_color = "WHITE"},
                        new Estado{EstadoID = 35,Nombre="En espera",Descripcion="En espera",TipoEstadoID=7,est_color = "WHITE"},
                        new Estado{EstadoID = 36,Nombre="Rechazada",Descripcion="Rechazada",TipoEstadoID=7,est_color = "WHITE"},
                        new Estado{EstadoID = 37,Nombre="Anulada",Descripcion="Anulada",TipoEstadoID=7,est_color = "WHITE"},
                        new Estado{EstadoID = 38,Nombre="Conformada",Descripcion="Conformada",TipoEstadoID=7,est_color = "WHITE"},
                        new Estado{EstadoID = 39,Nombre="Aceptada",Descripcion="Aceptada",TipoEstadoID=8,est_color = "WHITE"},
                        new Estado{EstadoID = 40,Nombre="En espera",Descripcion="En espera",TipoEstadoID=8,est_color = "WHITE"},
                        new Estado{EstadoID = 41,Nombre="Rechazada",Descripcion="Rechazada",TipoEstadoID=8,est_color = "WHITE"},
                        new Estado{EstadoID = 42,Nombre="Anulada",Descripcion="Anulada",TipoEstadoID=8,est_color = "WHITE"},
                        new Estado{EstadoID = 43,Nombre="Pagada",Descripcion="Pagada",TipoEstadoID=8,est_color = "WHITE"},
                        new Estado{EstadoID = 44,Nombre="Emitida",Descripcion="Emitida",TipoEstadoID=8,est_color = "WHITE"},
                        new Estado{EstadoID = 45,Nombre="Conformada",Descripcion="Conformada",TipoEstadoID=8,est_color = "WHITE"},
                        new Estado{EstadoID = 46,Nombre="Activo",Descripcion="Activo",TipoEstadoID=9,est_color = "WHITE"},
                        new Estado{EstadoID = 47,Nombre="Desvinculado",Descripcion="Desvinculado",TipoEstadoID=9,est_color = "WHITE"},
                        new Estado{EstadoID = 48,Nombre="Activo",Descripcion="Activo",TipoEstadoID=10,est_color = "WHITE"},
                        new Estado{EstadoID = 49,Nombre="Inactivo",Descripcion="Inactivo",TipoEstadoID=10,est_color = "WHITE"},
                        new Estado{EstadoID = 50,Nombre="Moroso",Descripcion="Moroso",TipoEstadoID=11,est_color = "WHITE"},
                        new Estado{EstadoID = 51,Nombre="Activo",Descripcion="Activo",TipoEstadoID=11,est_color = "WHITE"},
                        new Estado{EstadoID = 52,Nombre="Cancelado",Descripcion="Cancelado",TipoEstadoID=11,est_color = "WHITE"},
                        new Estado{EstadoID = 53,Nombre="Habilitado",Descripcion="Habilitado",TipoEstadoID=12,est_color = "WHITE"},
                        new Estado{EstadoID = 54,Nombre="Inhabilitado",Descripcion="Inhabilitado",TipoEstadoID=12,est_color = "WHITE"},
                        new Estado{EstadoID = 56,Nombre="Anulado",Descripcion="Anulado",TipoEstadoID=12,est_color = "WHITE"},
                        new Estado{EstadoID = 58,Nombre="Utilizado",Descripcion="Utilizado",TipoEstadoID=12,est_color = "WHITE"},
                        new Estado{EstadoID = 59,Nombre="Anulada",Descripcion="Anulada",TipoEstadoID=6,est_color = "WHITE"},
                        new Estado{EstadoID = 60,Nombre="Inicial",Descripcion="Inicial",TipoEstadoID=13,est_color = "WHITE"},
                        new Estado{EstadoID = 61,Nombre="Autorizado",Descripcion="Autorizado",TipoEstadoID=13,est_color = "WHITE"},
                        new Estado{EstadoID = 62,Nombre="Habilitado",Descripcion="Habilitado",TipoEstadoID=13,est_color = "WHITE"},
                        new Estado{EstadoID = 63,Nombre="Inhabilitado",Descripcion="Inhabilitado",TipoEstadoID=13,est_color = "WHITE"},
                        new Estado{EstadoID = 64,Nombre="Inicial",Descripcion="Inicial",TipoEstadoID=14,est_color = "WHITE"},
                        new Estado{EstadoID = 65,Nombre="Autorizada",Descripcion="Autorizada",TipoEstadoID=14,est_color = "WHITE"},
                        new Estado{EstadoID = 66,Nombre="Habilitada",Descripcion="Habilitada",TipoEstadoID=14,est_color = "WHITE"},
                        new Estado{EstadoID = 67,Nombre="Inhabilitada",Descripcion="Inhabilitada",TipoEstadoID=14,est_color = "WHITE"},
                        new Estado{EstadoID = 68,Nombre="Eliminada",Descripcion="Eliminada",TipoEstadoID=14,est_color = "WHITE"},
                        new Estado{EstadoID = 69,Nombre="Inicial",Descripcion="Inicial",TipoEstadoID=15,est_color = "WHITE"},
                        new Estado{EstadoID = 70,Nombre="Autorizada",Descripcion="Autorizada",TipoEstadoID=15,est_color = "WHITE"},
                        new Estado{EstadoID = 71,Nombre="Habilitada",Descripcion="Habilitada",TipoEstadoID=15,est_color = "WHITE"},
                        new Estado{EstadoID = 72,Nombre="Inhabilitada",Descripcion="Inhabilitada",TipoEstadoID=15,est_color = "WHITE"},
                        new Estado{EstadoID = 73,Nombre="Eliminada",Descripcion="Eliminada",TipoEstadoID=15,est_color = "WHITE"},
                        new Estado{EstadoID = 74,Nombre="Inicial",Descripcion="Inicial",TipoEstadoID=16,est_color = "WHITE"},
                        new Estado{EstadoID = 75,Nombre="Autorizada",Descripcion="Autorizada",TipoEstadoID=16,est_color = "WHITE"},
                        new Estado{EstadoID = 76,Nombre="Habilitada",Descripcion="Habilitada",TipoEstadoID=16,est_color = "WHITE"},
                        new Estado{EstadoID = 77,Nombre="Inhabilitada",Descripcion="Inhabilitada",TipoEstadoID=16,est_color = "WHITE"},
                        new Estado{EstadoID = 78,Nombre="Eliminada",Descripcion="Eliminada",TipoEstadoID=16,est_color = "WHITE"},
                        new Estado{EstadoID = 79,Nombre="Autorizado en CAP",Descripcion="Autorizado en CAP",TipoEstadoID=6,est_color = "WHITE"},
                        new Estado{EstadoID = 80,Nombre="Rechazado en CAP",Descripcion="Rechazado en CAP",TipoEstadoID=6,est_color = "WHITE"},
                        new Estado{EstadoID = 81,Nombre="Pendiente de Autorización en CAP",Descripcion="Pendiente de Autorización en CAP",TipoEstadoID=6,est_color = "WHITE"},
                        new Estado{EstadoID = 82,Nombre="Cliente Nuevo",Descripcion="Cliente Nuevo",TipoEstadoID=17,est_color = "WHITE"},
                        new Estado{EstadoID = 83,Nombre="Cliente Renovador",Descripcion="Cliente Renovador",TipoEstadoID=17,est_color = "WHITE"},
                        new Estado{EstadoID = 84,Nombre="Cliente Importado Sistema Anterior",Descripcion="Cliente Importado Sistema Anterior",TipoEstadoID=17,est_color = "WHITE"},
                        new Estado{EstadoID = 85,Nombre="Vigente",Descripcion="Vigente",TipoEstadoID=18,est_color = "WHITE"},
                        new Estado{EstadoID = 86,Nombre="No Vigente",Descripcion="No Vigente",TipoEstadoID=18,est_color = "WHITE"},
                        new Estado{EstadoID = 87,Nombre="Eliminado",Descripcion="Eliminado",TipoEstadoID=18,est_color = "WHITE"},
                        new Estado{EstadoID = 88,Nombre="Inicial",Descripcion="Inicial",TipoEstadoID=19,est_color = "WHITE"},
                        new Estado{EstadoID = 89,Nombre="Anulada",Descripcion="Anulada",TipoEstadoID=19,est_color = "WHITE"},
                        new Estado{EstadoID = 90,Nombre="Paga",Descripcion="Paga",TipoEstadoID=19,est_color = "WHITE"},
                        new Estado{EstadoID = 91,Nombre="Rechazada",Descripcion="Rechazada",TipoEstadoID=19,est_color = "WHITE"},
                        new Estado{EstadoID = 92,Nombre="Autorizada",Descripcion="Autorizada",TipoEstadoID=19,est_color = "WHITE"},
                        new Estado{EstadoID = 93,Nombre="Confirmada Y Fondos Retirados",Descripcion="Confirmada Y Fondos Retirados",TipoEstadoID=6,est_color = "WHITE"},
                        new Estado{EstadoID = 94,Nombre="Provisorio",Descripcion="Provisorio",TipoEstadoID=20,est_color = "WHITE"},
                        new Estado{EstadoID = 95,Nombre="Confirmado",Descripcion="Confirmado",TipoEstadoID=21,est_color = "WHITE"},
                        new Estado{EstadoID = 96,Nombre="Pendiente",Descripcion="Pendiente",TipoEstadoID=20,est_color = "WHITE"},
                        new Estado{EstadoID = 97,Nombre="Acreditado",Descripcion="Acreditado",TipoEstadoID=21,est_color = "WHITE"},
                        new Estado{EstadoID = 98,Nombre="Anulado",Descripcion="Anulado",TipoEstadoID=18,est_color = "WHITE"},
                        new Estado{EstadoID = 99,Nombre="Aceptada",Descripcion="Aceptada",TipoEstadoID=21,est_color = "WHITE"},
                        new Estado{EstadoID = 100,Nombre="En Espera",Descripcion="En Espera",TipoEstadoID=21,est_color = "WHITE"},
                        new Estado{EstadoID = 101,Nombre="Rechazada",Descripcion="Rechazada",TipoEstadoID=21,est_color = "WHITE"},
                        new Estado{EstadoID = 102,Nombre="Anulada",Descripcion="Anulada",TipoEstadoID=21,est_color = "WHITE"},
                        new Estado{EstadoID = 103,Nombre="Conformada",Descripcion="Conformada",TipoEstadoID=21,est_color = "WHITE"}
                        //new Estado{EstadoID = 63,Nombre="Inicial",Descripcion="Inicial",TipoEstadoID=13,est_color = "WHITE"},

                    };
                Estados.ForEach(c => context.Estados.Add(c));
                context.SaveChanges();


                var MediosDePago = new List<MedioDePago>
                    {
                        new MedioDePago{MedioDePagoID=1,Nombre = "Efectivo",Descripcion = "Efectivo" },
                        new MedioDePago{MedioDePagoID=2,Nombre = "Cheque",Descripcion = "Cheque" },
                        new MedioDePago{MedioDePagoID=3,Nombre = "Transferencia Bancaria",Descripcion = "Transferencia Bancaria" }
                    };
                MediosDePago.ForEach(m => context.MediosDePagos.Add(m));
                context.SaveChanges();


              

                var ConceptoFondos = new List<ConceptoFondos>
                    {
                        new ConceptoFondos{ConceptoFondosID=1,Nombre = "Retención de Cobranzas",Descripcion = "Retención de Cobranzas",MedioDePagoID =1 },
                        new ConceptoFondos{ConceptoFondosID=2,Nombre = "Extración bancaria",Descripcion = "Extración bancaria",MedioDePagoID =2 },
                        new ConceptoFondos{ConceptoFondosID=4,Nombre = "Retención de Valores a Rendir",Descripcion = "Retención de Valores a Rendir",MedioDePagoID =1 }

                    };
                ConceptoFondos.ForEach(c => context.ConceptoFondos.Add(c));
                context.SaveChanges();

                var TiposSolicitud = new List<TipoSolicitud>
                    {
                        new TipoSolicitud{TipoSolicitudID=1,Nombre = "Ventas",Descripcion = "Ventas" },
                        new TipoSolicitud{TipoSolicitudID=2,Nombre = "Cuentas a pagar",Descripcion = "Cuentas a pagar" },
                        new TipoSolicitud{TipoSolicitudID=3,Nombre = "Fondo Fijo",Descripcion = "Fondo Fijo" },
                        new TipoSolicitud{TipoSolicitudID=4,Nombre = "Venta Anticipada",Descripcion = "Venta Anticipada" },
                        new TipoSolicitud{TipoSolicitudID=5,Nombre = "Deposito A Comercio",Descripcion = "Deposito A Comercio" }
                    };
                TiposSolicitud.ForEach(t => context.TiposSolicitud.Add(t));
                context.SaveChanges();

                var EstadosTransmision = new List<EstadoTransmision>
                    {
                        new EstadoTransmision{EstadoTransmisionID=1,Nombre = "Enviado",Descripcion = "Enviado" },
                        new EstadoTransmision{EstadoTransmisionID=2,Nombre = "Pendiente de envío",Descripcion = "Pendiente de envío" },
                        new EstadoTransmision{EstadoTransmisionID=3,Nombre = "Recibido",Descripcion = "Recibido" },
                        new EstadoTransmision{EstadoTransmisionID=4,Nombre = "Erronea",Descripcion = "Erronea" },
                        new EstadoTransmision{EstadoTransmisionID=5,Nombre = "Envío en grupo",Descripcion = "Envío en grupo" },
                        new EstadoTransmision{EstadoTransmisionID=6,Nombre = "RevisadaSistema",Descripcion = "RevisadaSistema" }
                    };
                EstadosTransmision.ForEach(t => context.EstadoTransmisiones.Add(t));
                context.SaveChanges();

                var Operaciones = new List<Operacion>
                    {
                        new TransEnviarSolicitudDeFondo{OperacionID=1,Nombre = "Enviar Solicitud De Fondo",Descripcion = "Enviar Solicitud De Fondo" },
                        new TransConfirmarSolicitudDeFondo{OperacionID=2,Nombre = "Confirmar Solicitud De Fondo",Descripcion = "Confirmar Solicitud De Fondo" },
                        new TransAgregarProveedor{OperacionID=3,Nombre = "Agregar Proveedor",Descripcion = "Agregar proveedor" },
                        new TransActualizarProveedor{OperacionID=4,Nombre = "Actualizar Proveedor",Descripcion = "Actualizar Proveedor" },
                        new TransEliminarProveedor{OperacionID=5,Nombre = "Eliminar Proveedor",Descripcion = "Eliminar Proveedor" },
                        new TransAgregarProveedorSucursal{OperacionID=6,Nombre = "Agregar Sucursal Proveedor",Descripcion = "Agregar Sucursal Proveedor" },
                        new TransActualizarProveedorSucursal{OperacionID=7,Nombre = "Modificar Sucursal Proveedor",Descripcion = "Modificar Sucursal Proveedor" },
                        new TransEliminarProveedorSucursal{OperacionID=8,Nombre = "Eliminar Sucursal Proveedor",Descripcion = "Eliminar Sucursal Proveedor" },
                        new TransAgregarConceptoGastos{OperacionID=9,Nombre = "Agregar Concepto Gasto",Descripcion = "Agregar Concepto Gasto" },
                        new TransActualizarConceptoGastos{OperacionID=10,Nombre = "Modificar Concepto Gasto",Descripcion = "Modificar Concepto Gasto" },
                        new TransEliminarConceptoGastos{OperacionID=11,Nombre = "Eliminar Concepto Gasto",Descripcion = "Eliminar Concepto Gasto" },
                        new TransAgregarConceptoGastoProveedor{OperacionID=12,Nombre = "Agregar Concepto Gasto Proveedor",Descripcion = "Agregar Concepto Gasto Proveedor" },
                        new TransEliminarConceptoGastoProveedor{OperacionID=13,Nombre = "Eliminar Concepto Gasto Proveedor",Descripcion = "Modificar Concepto Gasto Proveedor" },
                        new TransAgregarCliente{OperacionID=14,Nombre = "Agregar Cliente",Descripcion = "Agregar Cliente" },
                        new TransActualizarCliente{OperacionID=15,Nombre = "Actualizar Cliente",Descripcion = "Actualizar Cliente" },
                        new TransEliminarCliente{OperacionID=16,Nombre = "Eliminar Cliente",Descripcion = "Eliminar Cliente" },
                        new TransAltaCredito{OperacionID=17,Nombre = "Alta Credito",Descripcion = "Alta Credito" },
                        new TransBajaCredito{OperacionID=18,Nombre = "Baja Credito",Descripcion = "Baja Credito" },
                        new TransAltaCobranza{OperacionID=19,Nombre = "Alta Cobranza",Descripcion = "Alta Cobranza" },
                        new TransBajaCobranza{OperacionID=20,Nombre = "Baja Cobranza",Descripcion = "Baja Cobranza" },
                        new TransBajaRefinanciacionCobranza{OperacionID=21,Nombre = "Baja Refinanciacion Cobranza",Descripcion = "Baja Refinanciacion Cobranza" },
                        new TransActualizarRefinanciacionCuota{OperacionID=22,Nombre = "Actualizar Refinanciacion Cuota",Descripcion = "Actualizar Refinanciacion Cuota" },
                        new TransActualizarRefinanciacionCobranza{OperacionID=23,Nombre = "Actualizar Refinanciacion Cobranza",Descripcion = "Actualizar Refinanciacion Cobranza" },
                        new TransActualizarCuota{OperacionID=24,Nombre = "Actualizar Cuota",Descripcion = "Actualizar Cuota" },
                        new TransAgregarCobranza{OperacionID=25,Nombre = "Agregar Cobranza",Descripcion = "Agregar Cobranza" },
                        new TransActualizarCobranza{OperacionID=26,Nombre = "Actualizar Cobranza",Descripcion = "Actualizar Cobranza" },
                        new TransAltaNotaCD{OperacionID=27,Nombre = "Alta NotaCD",Descripcion = "Alta NotaCD" },
                        new TransAltaArregloCancelacion{OperacionID=28,Nombre = "Alta Arreglo Cancelación",Descripcion = "Alta Arreglo Cancelación" },
                        new TransAltaPagoAnticipado{OperacionID=29,Nombre = "Alta Pago Anticipado",Descripcion = "Alta Pago Anticipado" },
                        new TransAltaRefinanciacion{OperacionID=30,Nombre = "Alta Refinanciación",Descripcion = "Alta Refinanciación" },
                        new TransAltaRefinanciacionCobranza{OperacionID=31,Nombre = "Alta Refinanciación Cobranza",Descripcion = "Alta Refinanciación Cobranza" },
                        new TransActualizarCredito{OperacionID=32,Nombre = "Actualizar Credito",Descripcion = "Actualizar Credito" },
                        new TransAltaRefinanciacionCuota{OperacionID=33,Nombre = "Alta RefinanciacionCuota",Descripcion = "Alta RefinanciacionCuota" },
                        new TransBajaNotaCD{OperacionID=34,Nombre = "Baja Nota de Crédito",Descripcion = "Baja Nota de Crédito" },
                        new TransPagoAnticipadoNotaCD{OperacionID=35,Nombre = "Pago Anticipado Nota CD",Descripcion = "Pago Anticipado Nota CD" } , 
                        new TransImputacionCC{OperacionID=36,Nombre = "Imputación de Cuenta Corriente",Descripcion = "Imputación de Cuenta Corriente" },  
                        new TransBajaRefinanciacion{OperacionID=37,Nombre = "Baja Refinanciación",Descripcion = "Baja Refinanciación" },
                        new TransArchivo{OperacionID=38,Nombre = "Trans Archivo",Descripcion = "Trans Archivo" } , 
                        new TransAltaRecibo{OperacionID=39,Nombre = "Trans Alta Recibo",Descripcion = "Trans Alta Recibo" }  ,
                        new TransBajaRecibo{OperacionID=59,Nombre = "Trans Baja Recibo",Descripcion = "Trans Baja Recibo" }  ,
                        new TransAltaTransDep{OperacionID=40,Nombre = "Trans Alta TransDep",Descripcion = "Trans Alta TransDep" }  ,
                        new TransControlDiario{OperacionID=41,Nombre = "Trans Control Diario",Descripcion = "Trans Control Diario" } ,
                        new TransActualizarSolicitudDeFondo{OperacionID=42,Nombre = "Trans Actualizar Solicitud De Fondo",Descripcion = "Trans Actualizar Solicitud De Fondo" },
                        new TransAltaFF{OperacionID=43,Nombre = "Trans Alta FF",Descripcion = "Trans Alta FF" },
                        new TransBajaFF{OperacionID=44,Nombre = "Trans Baja FF",Descripcion = "Trans Baja FF" },
                        new TransActualizarFF{OperacionID=45,Nombre = "Trans Actualizar FF",Descripcion = "Trans Actualizar FF" },
                        new TransAltaCap{OperacionID=46,Nombre = "Trans Alta Cap",Descripcion = "Trans Alta Cap" },
                        new TransBajaCap{OperacionID=47,Nombre = "Trans Baja Cap",Descripcion = "Trans Baja Cap" },
                        new TransActualizarCap{OperacionID=48,Nombre = "Trans Actualizar Cap",Descripcion = "Trans Actualizar Cap" },
                        new TransAltaPago{OperacionID=49,Nombre = "Trans Alta Pago",Descripcion = "Trans Alta Pago" },
                        new TransBajaPago{OperacionID=50,Nombre = "Trans Baja Pago",Descripcion = "Trans Baja Pago" },
                        new TransActualizarPago{OperacionID=51,Nombre = "Trans Actualizar Pago",Descripcion = "Trans Actualizar Pago" },
                        new TransAltaComprobante{OperacionID=52,Nombre = "Trans Alta Comprobante",Descripcion = "Trans Alta Comprobante" },
                        new TransBajaComprobante{OperacionID=53,Nombre = "Trans Baja Comprobante",Descripcion = "Trans Baja Comprobante" },
                        new TransActualizarComprobante{OperacionID=54,Nombre = "Trans Actualizar Comprobante",Descripcion = "Trans Actualizar Comprobante" },               
                        new TransAltaCobranzas{OperacionID=55,Nombre = "Alta Cobranzas",Descripcion = "Alta Cobranzas" },
                        new TransAltaGasto{OperacionID=56,Nombre = "Alta Gasto",Descripcion = "Alta Gasto" },
                        new TransBajaGasto{OperacionID=57,Nombre = "Baja Gasto",Descripcion = "Baja Gasto" },
                        new TransInfoAct{OperacionID=58,Nombre = "Trans Info Act",Descripcion = "Trans Info Act" }
                    };
                Operaciones.ForEach(t => context.Operaciones.Add(t));
                context.SaveChanges();

                var ClasesMovimiento = new List<ClaseMovimiento>
                    {
                        new Ingreso{ClaseMovimientoID=1,Nombre = "Ingreso",Descripcion = "Ingreso" },
                        new Egreso{ClaseMovimientoID=2,Nombre = "Egreso",Descripcion = "Egreso" }

                    };
                ClasesMovimiento.ForEach(t => context.ClasesMovimientos.Add(t));
                context.SaveChanges();

                var TiposMovimiento = new List<TipoMovimiento>
                    {
                        new TipoMovimiento{TipoMovimientoID = 101, Nombre = "Ajuste Positivo Caja",Descripcion = "Ajuste Positivo Caja" ,Cod = "", ClaseMovimientoID=1,CodInter = "M",TipoMovIDAnula = 0},
                        new TipoMovimiento{TipoMovimientoID = 014, Nombre = "Ajuste Negativo Caja",Descripcion = "Ajuste Negativo Caja" ,Cod = "", ClaseMovimientoID=2,CodInter = "M",TipoMovIDAnula = 0},
                        new TipoMovimiento{TipoMovimientoID = 020, Nombre = "Créditos Otorgados en Efectivo",Descripcion = "Créditos Otorgados en Efectivo" ,Cod = "", ClaseMovimientoID=2,CodInter = "S",TipoMovIDAnula = 0},
                        new TipoMovimiento{TipoMovimientoID = 011, Nombre = "Descuento Cobranza por Cancelación Anticipada",Descripcion = "Descuento Cobranza por Cancelación Anticipada" ,Cod = "", ClaseMovimientoID=2,CodInter = "S",TipoMovIDAnula = 0},
                        new TipoMovimiento{TipoMovimientoID = 013, Nombre = "Anulación Cobranza",Descripcion = "Anulación Cobranza" ,Cod = "", ClaseMovimientoID=2,CodInter = "S",TipoMovIDAnula = 0},
                        new TipoMovimiento{TipoMovimientoID = 201, Nombre = "Anulación Créditos Otorgados en Efectivo",Descripcion = "Anulación Créditos Otorgados en Efectivo" ,Cod = "", ClaseMovimientoID=1,CodInter = "S",TipoMovIDAnula = 0},
                        new TipoMovimiento{TipoMovimientoID = 012, Nombre = "Descuento Cobranza por Promoción Bonificada",Descripcion = "Descuento Cobranza por Promoción Bonificada" ,Cod = "", ClaseMovimientoID=2,CodInter = "S",TipoMovIDAnula = 0},
                        new TipoMovimiento{TipoMovimientoID = 100, Nombre = "Cobranza",Descripcion = "Cobranza" ,Cod = "", ClaseMovimientoID=1,CodInter = "S",TipoMovIDAnula = 0},
                        new TipoMovimiento{TipoMovimientoID = 200, Nombre = "Gastos Descontados a Creditos Otorgados",Descripcion = "Gastos Descontados a Creditos Otorgados" ,Cod = "", ClaseMovimientoID=1,CodInter = "S",TipoMovIDAnula = 0},
                        new TipoMovimiento{TipoMovimientoID = 021, Nombre = "Anulación Gastos de Creditos Otorgados",Descripcion = "Anulación Gastos de Creditos Otorgados" ,Cod = "", ClaseMovimientoID=2,CodInter = "S",TipoMovIDAnula = 0},
                        new TipoMovimiento{TipoMovimientoID = 120, Nombre = "Cobranza de Comercio Adherido",Descripcion = "Cobranza de Comercio Adherido" ,Cod = "", ClaseMovimientoID=1,CodInter = "S",TipoMovIDAnula = 0},
                        new TipoMovimiento{TipoMovimientoID = 230, Nombre = "Cuota Adelantada",Descripcion = "Cuota Adelantada" ,Cod = "", ClaseMovimientoID=1,CodInter = "S",TipoMovIDAnula = 0},
                        new TipoMovimiento{TipoMovimientoID = 233, Nombre = "Anulacion de Cuota Adelantada",Descripcion = "Anulacion de Cuota Adelantada" ,Cod = "", ClaseMovimientoID=2,CodInter = "S",TipoMovIDAnula = 0},
                        new TipoMovimiento{TipoMovimientoID = 022, Nombre = "Anulacion descuento Anticipada",Descripcion = "Anulacion descuento Anticipada" ,Cod = "", ClaseMovimientoID=1,CodInter = "S",TipoMovIDAnula = 0},
                        new TipoMovimiento{TipoMovimientoID = 300, Nombre = "Cancelación Gs. por nosotros",Descripcion = "Cancelación Gs. por nosotros" ,Cod = "CGN", ClaseMovimientoID=2,CodInter = " M",TipoMovIDAnula = 0},
                        new TipoMovimiento{TipoMovimientoID = 301, Nombre = "Devolución cheque propio",Descripcion = "Devolución cheque propio" ,Cod = "DCH", ClaseMovimientoID=2,CodInter = " M",TipoMovIDAnula = 0},
                        new TipoMovimiento{TipoMovimientoID = 302, Nombre = "Descuento punitório",Descripcion = "Descuento punitório" ,Cod = "DCP", ClaseMovimientoID=2,CodInter = " M",TipoMovIDAnula = 0},
                        new TipoMovimiento{TipoMovimientoID = 303, Nombre = "Intereses no cobrados",Descripcion = "Intereses no cobrados" ,Cod = "INC", ClaseMovimientoID=2,CodInter = " M",TipoMovIDAnula = 0},
                        new TipoMovimiento{TipoMovimientoID = 304, Nombre = "Ajuste redondéo negativo",Descripcion = "Ajuste redondéo negativo" ,Cod = "AR-", ClaseMovimientoID=2,CodInter = " M",TipoMovIDAnula = 0},
                        new TipoMovimiento{TipoMovimientoID = 305, Nombre = "Recibo",Descripcion = "Recibo" ,Cod = "REC", ClaseMovimientoID=2,CodInter = " M",TipoMovIDAnula = 0},
                        new TipoMovimiento{TipoMovimientoID = 306, Nombre = "Intereses a Comercio",Descripcion = "Intereses a Comercio" ,Cod = "INT", ClaseMovimientoID=1,CodInter = " M",TipoMovIDAnula = 0},
                        new TipoMovimiento{TipoMovimientoID = 307, Nombre = "Ajuste redondeo positivo",Descripcion = "Ajuste redondeo positivo" ,Cod = "AR+", ClaseMovimientoID=1,CodInter = " M",TipoMovIDAnula = 0},
                        new TipoMovimiento{TipoMovimientoID = 308, Nombre = "Teléfono",Descripcion = "Teléfono" ,Cod = "TEL", ClaseMovimientoID=1,CodInter = " M",TipoMovIDAnula = 0},
                        new TipoMovimiento{TipoMovimientoID = 309, Nombre = "Varios",Descripcion = "Varios" ,Cod = "VAR", ClaseMovimientoID=1,CodInter = " M",TipoMovIDAnula = 0},
                        new TipoMovimiento{TipoMovimientoID = 310, Nombre = "Por Cta y Orden VALLE",Descripcion = "Por Cta y Orden VALLE" ,Cod = "CDV", ClaseMovimientoID=1,CodInter = " M",TipoMovIDAnula = 0},
                        new TipoMovimiento{TipoMovimientoID = 36, Nombre = "Nota de Crédito",Descripcion = "Nota de Crédito" ,Cod = "CREDITO", ClaseMovimientoID=2,CodInter = "S",TipoMovIDAnula = 0},  //EX cod =CREDITO
                        new TipoMovimiento{TipoMovimientoID = 37, Nombre = "Nota de Débito",Descripcion = "Nota de Débito" ,Cod = "DEBITO", ClaseMovimientoID=1,CodInter = "S",TipoMovIDAnula = 0}, //EX cod =DEBITO
                       
                        new TipoMovimiento{TipoMovimientoID = 701, Nombre = "Valores a Depositar a Banco",Descripcion = "Valores a Depositar a Banco" ,Cod = "NREC-FUT", ClaseMovimientoID=2,CodInter = " M",TipoMovIDAnula = 0},
                        new TipoMovimiento{TipoMovimientoID = 55, Nombre = "Anulación Valores a Depositar a Banco",Descripcion = "Anulación Valores a Depositar a Banco" ,Cod = "ANREC-FUT", ClaseMovimientoID=1,CodInter = "M",TipoMovIDAnula = 701} ,
                        new TipoMovimiento{TipoMovimientoID = 400, Nombre = "Retiro de Bco A Caja",Descripcion = "Retiro de Bco A Caja" ,Cod = "NREC", ClaseMovimientoID=1,CodInter = " M",TipoMovIDAnula = 0},
                        new TipoMovimiento{TipoMovimientoID = 52, Nombre = "Anulación Retiro de Bco A Caja",Descripcion = "Anulación Retiro de Bco A Caja" ,Cod = "ANREC", ClaseMovimientoID=2,CodInter = "M",TipoMovIDAnula = 400} ,
                        new TipoMovimiento{TipoMovimientoID = 620, Nombre = "Deposito Cobr. Com Adherido",Descripcion = "Deposito Cobr. Com Adherido" ,Cod = "NREC", ClaseMovimientoID=2,CodInter = "M",TipoMovIDAnula = 0},
                        new TipoMovimiento{TipoMovimientoID = 54, Nombre = "Anulación Deposito Cobr. Com Adherido",Descripcion = "Anulación Deposito Cobr. Com Adherido" ,Cod = "ANREC", ClaseMovimientoID=1,CodInter = "M",TipoMovIDAnula = 620} ,
                        new TipoMovimiento{TipoMovimientoID = 48, Nombre = "Depósito en cuenta propia",Descripcion = "Depósito en cuenta propia" ,Cod = "NREC-FUT", ClaseMovimientoID=2,CodInter = "M",TipoMovIDAnula = 0},
                        new TipoMovimiento{TipoMovimientoID = 49, Nombre = "Anulación Depósito en cuenta propia",Descripcion = "Anulación Depósito en cuenta propia" ,Cod = "ANREC-FUT", ClaseMovimientoID=1,CodInter = "M",TipoMovIDAnula = 48},
                        new TipoMovimiento{TipoMovimientoID = 50, Nombre = "Retiro de cuenta propia a Caja",Descripcion = "Retiro de cuenta propia a Caja" ,Cod = "NREC-FUT", ClaseMovimientoID=1,CodInter = "M",TipoMovIDAnula = 0},
                        new TipoMovimiento{TipoMovimientoID = 51, Nombre = "Anulación  Retiro de cuenta propia a Caja",Descripcion = "Anulación  Retiro de cuenta propia a Caja" ,Cod = "ANREC-FUT", ClaseMovimientoID=2,CodInter = "M",TipoMovIDAnula = 50} ,
                        new TipoMovimiento{TipoMovimientoID = 610, Nombre = "Depósito Cobranza Receptoría",Descripcion = "Depósito Cobranza Receptoría" ,Cod = "NREC", ClaseMovimientoID=2,CodInter = " M",TipoMovIDAnula = 0},
                        new TipoMovimiento{TipoMovimientoID = 611, Nombre = "Anulación Depósito Cobranza Receptoría",Descripcion = "Anulación Depósito Cobranza Receptoría" ,Cod = "ANREC", ClaseMovimientoID=1,CodInter = " M",TipoMovIDAnula = 610},
                        new TipoMovimiento{TipoMovimientoID = 56, Nombre = "Compensación",Descripcion = "Compensación" ,Cod = "NFIN", ClaseMovimientoID=2,CodInter = "M",TipoMovIDAnula = 0} ,
                        new TipoMovimiento{TipoMovimientoID = 57, Nombre = "Anulación Compensación",Descripcion = "Anulación Compensación" ,Cod = "ANFIN", ClaseMovimientoID=1,CodInter = "M",TipoMovIDAnula = 56} ,
                        new TipoMovimiento{TipoMovimientoID = 58, Nombre = "Deposito a Comercio",Descripcion = "Deposito a Comercio" ,Cod = "NFIN", ClaseMovimientoID=2,CodInter = "M",TipoMovIDAnula = 0},
                        new TipoMovimiento{TipoMovimientoID = 59, Nombre = "Anulación Deposito a Comercio",Descripcion = "Anulación Deposito a Comercio" ,Cod = "ANFIN", ClaseMovimientoID=1,CodInter = "M",TipoMovIDAnula = 58} ,
                        new TipoMovimiento{TipoMovimientoID = 60, Nombre = "Depósito Cobranza Comercio",Descripcion = "Depósito Cobranza Comercio" ,Cod = "NCOM", ClaseMovimientoID=2,CodInter = "M",TipoMovIDAnula = 50},
                        new TipoMovimiento{TipoMovimientoID = 61, Nombre = "Anulación Depósito Cobranza Comercio",Descripcion = "Anulación Depósito Cobranza Comercio" ,Cod = "ANCOM", ClaseMovimientoID=1,CodInter = "M",TipoMovIDAnula = 60},
                        new TipoMovimiento{TipoMovimientoID = 720, Nombre = "Cobranza por Débito",Descripcion = "Cobranza por Débito" ,Cod = "NREC-FUT", ClaseMovimientoID=2,CodInter = "M",TipoMovIDAnula = 0} ,
                        new TipoMovimiento{TipoMovimientoID = 722, Nombre = "Anulación Cobranza por Débito",Descripcion = "Anulación Cobranza por Débito" ,Cod = "ANREC-FUT", ClaseMovimientoID=1,CodInter = "M",TipoMovIDAnula = 0},
                        new TipoMovimiento{TipoMovimientoID = 45, Nombre = "Anulación Nota de Crédito",Descripcion = "Anulación Nota de Crédito" ,Cod = "CREDITO", ClaseMovimientoID=2,CodInter = "S",TipoMovIDAnula = 0}, 
                        new TipoMovimiento{TipoMovimientoID = 46, Nombre = "Anulación Nota de Débito",Descripcion = "Anulación Nota de Débito" ,Cod = "DEBITO", ClaseMovimientoID=1,CodInter = "S",TipoMovIDAnula = 0},
                        new TipoMovimiento{TipoMovimientoID = 47, Nombre = "Anulación Descuento Cobranza Bonificada",Descripcion ="Anulación Descuento Cobranza Bonificada"  ,Cod ="" , ClaseMovimientoID=1,CodInter = "M",TipoMovIDAnula = 0},

                        new TipoMovimiento{TipoMovimientoID = 810, Nombre = "Gastos Fondo Fijo",Descripcion ="Gastos Fondo Fijo"  ,Cod ="" , ClaseMovimientoID=2,CodInter = " M",TipoMovIDAnula = 0},
                        new TipoMovimiento{TipoMovimientoID = 811, Nombre = "Anulación Gastos Fondo Fijo",Descripcion ="Anulación Gastos Fondo Fijo"  ,Cod ="" , ClaseMovimientoID=1,CodInter = " M",TipoMovIDAnula = 810},
                        new TipoMovimiento{TipoMovimientoID = 820, Nombre = "Gastos Cuentas a Pagar",Descripcion ="Gastos Cuentas a Pagar"  ,Cod ="" , ClaseMovimientoID=2,CodInter = " M",TipoMovIDAnula = 0},
                        new TipoMovimiento{TipoMovimientoID = 821, Nombre = "Anulación Gastos Cuentas a Pagar",Descripcion ="Anulación Gastos Cuentas a Pagar"  ,Cod ="" , ClaseMovimientoID=1,CodInter = " M",TipoMovIDAnula = 821},

                        new TipoMovimiento{TipoMovimientoID = 822, Nombre = "Comisión Créditos Otorgados en Efectivo",Descripcion ="Comisión Créditos Otorgados en Efectivo"  ,Cod ="" , ClaseMovimientoID=2,CodInter = "S",TipoMovIDAnula = 0},
                        new TipoMovimiento{TipoMovimientoID = 823, Nombre = "Anulación Comisión Créditos Otorgados en Efectivo",Descripcion ="Anulación Comisión Créditos Otorgados en Efectivo"  ,Cod ="" , ClaseMovimientoID=1,CodInter = " S",TipoMovIDAnula = 822},

                        new TipoMovimiento{TipoMovimientoID = 723, Nombre = "Cobranza por Depósito/Transferencia Bancaria",Descripcion = "Cobranza por Depósito/Transferencia Bancaria" ,Cod = "NREC", ClaseMovimientoID=2,CodInter = "M",TipoMovIDAnula = 0} ,
                        new TipoMovimiento{TipoMovimientoID = 724, Nombre = "Anulación por Depósito/Transferencia Bancaria",Descripcion = "Anulación por Depósito/Transferencia Bancaria" ,Cod = "ANREC", ClaseMovimientoID=1,CodInter = "M",TipoMovIDAnula = 0},

                        new TipoMovimiento{TipoMovimientoID = 725, Nombre = "Ingreso Cobranza de comercio Adherido",Descripcion = "Ingreso Cobranza de comercio Adherido" ,Cod = "NREC", ClaseMovimientoID=1, CodInter = "M",TipoMovIDAnula = 0},
                        new TipoMovimiento{TipoMovimientoID = 726, Nombre = "Anulación Ingreso Cobranza de comercio Adherido",Descripcion = "Anulación Ingreso Cobranza de comercio Adherido" ,Cod = "ANREC", ClaseMovimientoID=2,CodInter = "M",TipoMovIDAnula = 0},
                        
                        new TipoMovimiento{TipoMovimientoID = 23, Nombre = "Retiro en efectivo de Caja",Descripcion = "Retiro en efectivo de Caja" ,Cod = "NREC", ClaseMovimientoID=2, CodInter = "M",TipoMovIDAnula = 24},
                        new TipoMovimiento{TipoMovimientoID = 24, Nombre = "Anulación Retiro en efectivo de Caja",Descripcion = "Anulación Retiro en efectivo de Caja" ,Cod = "ANREC", ClaseMovimientoID=1,CodInter = "M",TipoMovIDAnula = 0},

                        new TipoMovimiento{TipoMovimientoID = 38, Nombre = "Nota de Crédito Provisoria",Descripcion = "Nota de Crédito Provisoriaa" ,Cod = "", ClaseMovimientoID=2,CodInter = "M",TipoMovIDAnula = 0},
                        new TipoMovimiento{TipoMovimientoID = 39, Nombre = "Nota de Débito Provisoria",Descripcion = "Nota de Débito Provisoria" ,Cod = "", ClaseMovimientoID=1,CodInter = "M",TipoMovIDAnula = 0},
                        new TipoMovimiento{TipoMovimientoID = 40, Nombre = "Gastos Provisorios",Descripcion = "Gastos Provisorios" ,Cod = "", ClaseMovimientoID=2,CodInter = "M",TipoMovIDAnula = 0},
                        new TipoMovimiento{TipoMovimientoID = 41, Nombre = "Aviso de pago negativo provisorio",Descripcion = "Aviso de pago negativo provisorio" ,Cod = "", ClaseMovimientoID=2,CodInter = "M",TipoMovIDAnula = 0},
                        new TipoMovimiento{TipoMovimientoID = 42, Nombre = "Aviso provisorio",Descripcion = "Aviso provisorio" ,Cod = "", ClaseMovimientoID=2,CodInter = "M",TipoMovIDAnula = 0},
                        new TipoMovimiento{TipoMovimientoID = 43, Nombre = "Minuta provisoria",Descripcion = "Minuta provisoria" ,Cod = "", ClaseMovimientoID=1,CodInter = "M",TipoMovIDAnula = 0},
                        new TipoMovimiento{TipoMovimientoID = 44, Nombre = "Recibo provisorio",Descripcion = "Recibo provisorio" ,Cod = "", ClaseMovimientoID=2,CodInter = "M",TipoMovIDAnula = 0},
                        

                        new TipoMovimiento{TipoMovimientoID = 62, Nombre = "Descuento Punitorios por pago Refinanciación",Descripcion = "Descuento Punitorios por pago Refinanciación" ,Cod = "", ClaseMovimientoID=2,CodInter = "S",TipoMovIDAnula = 0},
                        new TipoMovimiento{TipoMovimientoID = 63, Nombre = "Anulación Descuento Punitorios por pago Refinanciación",Descripcion = "Anulación Descuento Punitorios por pago Refinanciación" ,Cod = "", ClaseMovimientoID=1,CodInter = "S",TipoMovIDAnula = 62},
                        
                        new TipoMovimiento{TipoMovimientoID = 727, Nombre = "Pago a Comercio",Descripcion = "Pago a Comercio" ,Cod = "NREC", ClaseMovimientoID=2,CodInter = "M",TipoMovIDAnula = 0} ,
                        new TipoMovimiento{TipoMovimientoID = 728, Nombre = "Anulación Pago a Comercio",Descripcion = "Anulación Pago a Comercio" ,Cod = "ANREC", ClaseMovimientoID=1,CodInter = "M",TipoMovIDAnula = 0},

                    };

                TiposMovimiento.ForEach(t => context.TiposMovimientos.Add(t));
                context.SaveChanges();

                var Monedas = new List<Moneda>
                    {
                        new Moneda{ Descripcion="Peso argentino", mon_simbolo="$",Nombre="Peso Argentino", PaisId=5},
                        new Moneda{ Descripcion="Dolar Estadounidense", mon_simbolo="U$D",Nombre="Dolar Estadounidense", PaisId=55},
                    };
                Monedas.ForEach(t => context.Monedas.Add(t));
                context.SaveChanges();

                var tiposDocumento = new List<TipoDocumento>
                    {
                        new TipoDocumento{ Descripcion="Documento Nacional de Identidad", Nombre="Documento Nacional de Identidad", TipoDocumentoID="DNI"},
                        new TipoDocumento{ Descripcion="Cédula de Identidad", Nombre="Cédula de Identidad", TipoDocumentoID="CI"},
                        new TipoDocumento{ Descripcion="Libreta Cívica", Nombre="Libreta Cívica", TipoDocumentoID="LC"},
                        new TipoDocumento{ Descripcion="Libreta de Enrolamiento", Nombre="Libreta de Enrolamiento", TipoDocumentoID="LE"},
                        new TipoDocumento{ Descripcion="Documento Único", Nombre="Documento Único", TipoDocumentoID="DU"},
                    };
                tiposDocumento.ForEach(t => context.TiposDocumento.Add(t));
                context.SaveChanges();

                var profesiones = new List<Profesion>
                    {
                        new Profesion{ProfesionID = "JUB",Nombre="JUBILADO" },
                        new Profesion{ProfesionID = "PUB",Nombre="EMPLEADO PUBLICO" },
                        new Profesion{ProfesionID = "PRI",Nombre="EMPLEADO PRIVADO"},
                        new Profesion{ProfesionID = "S/N",Nombre="SIN EMPLEO"},     
                        new Profesion{ProfesionID = "COM",Nombre="Comercio" },
                        new Profesion{ProfesionID = "REV",Nombre="REVISAR" },
                        new Profesion{ProfesionID = "AP",Nombre="APODERADO",ProfesionPadreID="JUB" },
                        new Profesion{ProfesionID = "JU",Nombre="JUBILADO A",ProfesionPadreID="JUB" },
                        new Profesion{ProfesionID = "PE",Nombre="PENSIONADO",ProfesionPadreID="JUB" },
                        new Profesion{ProfesionID = "DO",Nombre="DOCENTE",ProfesionPadreID="PUB" },
                        new Profesion{ProfesionID = "EJ",Nombre="EJERCITO",ProfesionPadreID="PUB" },
                        new Profesion{ProfesionID = "MU",Nombre="MUNICIPAL",ProfesionPadreID="PUB" },
                        new Profesion{ProfesionID = "PO",Nombre="POLICIA",ProfesionPadreID="PUB" },
                        new Profesion{ProfesionID = "PR",Nombre="PRIVADO",ProfesionPadreID="PRI" },
                        new Profesion{ProfesionID = "AM",Nombre="AMA DE CASA",ProfesionPadreID="S/N" },
                        new Profesion{ProfesionID = "AU",Nombre="AUTONOMO",ProfesionPadreID="S/N" },
                        new Profesion{ProfesionID = "DJ",Nombre="DEPOSITO JUDICIAL",ProfesionPadreID="S/N" },
                        new Profesion{ProfesionID = "ED",Nombre="EMPLEADO DOMESTICO",ProfesionPadreID="S/N" },
                        new Profesion{ProfesionID = "PT",Nombre="PLAN TRABAJAR",ProfesionPadreID="S/N" },
                        new Profesion{ProfesionID = "SD",Nombre="SOLO DNI",ProfesionPadreID="S/N" },
                        new Profesion{ProfesionID = "SU",Nombre="SUBSIDIO DE DESEMPLEO",ProfesionPadreID="S/N" },
                        new Profesion{ProfesionID = "PU",Nombre="PLAN UNIVERSAL",ProfesionPadreID="S/N" },
                        new Profesion{ProfesionID = "CO",Nombre="COMERCIO A",ProfesionPadreID="COM" },
                        new Profesion{ProfesionID = "CH",Nombre="CHANGARIN",ProfesionPadreID="S/N" }
                    };
                profesiones.ForEach(t => context.Profesiones.Add(t));
                context.SaveChanges();

                var Sexo = new List<Sexo>
                    {
                        new Sexo{SexoID = "M",Nombre="Masculino", Descripcion="Masculino" },
                        new Sexo{SexoID = "F",Nombre="Femenino",Descripcion="Femenino" },
                        
                    };
                Sexo.ForEach(t => context.Sexos.Add(t));
                context.SaveChanges();

                var ClaseDato = new List<ClaseDato>
                    {
                        new ClaseDato{Nombre="Cliente",Descripcion="Cliente"},
                        new ClaseDato{Nombre="Empresa",Descripcion="Empresa"}
                        
                    };
                ClaseDato.ForEach(t => context.ClasesDato.Add(t));
                context.SaveChanges();

                var TipoComoConocio = new List<TipoComoConocio>
                    {
                        new TipoComoConocio{TipoComoConocioID="A", Nombre="RADIO",Descripcion="RADIO"},
                        new TipoComoConocio{TipoComoConocioID="B", Nombre="TELEVISION",Descripcion="TELEVISION"},
                        new TipoComoConocio{TipoComoConocioID="C", Nombre="CARTEL DEL LOCAL",Descripcion="CARTEL DEL LOCAL"},
                        new TipoComoConocio{TipoComoConocioID="D", Nombre="DIARIOS",Descripcion="DIARIOS"},
                        new TipoComoConocio{TipoComoConocioID="E", Nombre="COMENTARIO CLIENTE O CODEUDOR",Descripcion="COMENTARIO CLIENTE O CODEUDOR"},
                        new TipoComoConocio{TipoComoConocioID="F", Nombre="FOLLETOS O VOLANTES VIA PUBLIC",Descripcion="FOLLETOS O VOLANTES VIA PUBLIC"},
                        new TipoComoConocio{TipoComoConocioID="G", Nombre="COMERCIOS ADHERIDOS",Descripcion="COMERCIOS ADHERIDOS"},
                        new TipoComoConocio{TipoComoConocioID="H", Nombre="MAILING",Descripcion="MAILING"},
                        new TipoComoConocio{TipoComoConocioID="I", Nombre="RENOVACION",Descripcion="RENOVACION"},
                        new TipoComoConocio{TipoComoConocioID="J", Nombre="OTROS",Descripcion="OTROS"},
                        new TipoComoConocio{TipoComoConocioID="K", Nombre="SMS",Descripcion="SMS"},
                        new TipoComoConocio{TipoComoConocioID="L", Nombre="TELEVENTA",Descripcion="TELEVENTA"},
                        new TipoComoConocio{TipoComoConocioID="M", Nombre="PROMOCION",Descripcion="PROMOCION"},                    
                        new TipoComoConocio{TipoComoConocioID="N", Nombre="N",Descripcion="N"}  
                    };
                TipoComoConocio.ForEach(t => context.TipoComoConocio.Add(t));
                context.SaveChanges();

                var TipoAval = new List<TipoAval>
                    {
                        new TipoAval{TipoAvalID=1, Nombre="Sueldo",Descripcion="Sueldo"},
                        new TipoAval{TipoAvalID=2, Nombre="Cámara",Descripcion="Cámara"},
                        new TipoAval{TipoAvalID=3, Nombre="Crédito anterior",Descripcion="Crédito anterior"},
                        new TipoAval{TipoAvalID=4, Nombre="Renueva",Descripcion="Renueva"},
                        new TipoAval{TipoAvalID=5, Nombre="Crédito moroso",Descripcion="Crédito moroso"},
                        new TipoAval{TipoAvalID=6, Nombre="Cambia Plan",Descripcion="Cambia Plan"}
                    };
                TipoAval.ForEach(t => context.TipoAval.Add(t));
                context.SaveChanges();

                var TipoRetencionPlan = new List<TipoRetencionPlan>
                    {
                        new TipoRetencionPlan{TipoRetencionPlanID="C", Nombre="Cuota",Descripcion="Cuota"},
                        new TipoRetencionPlan{TipoRetencionPlanID="G", Nombre="Gastos",Descripcion="Gastos"},
                        new TipoRetencionPlan{TipoRetencionPlanID="A", Nombre="Cuota y gastos",Descripcion="Cuota y gastos"},
                        new TipoRetencionPlan{TipoRetencionPlanID="N", Nombre="Nada",Descripcion="Nada "}
                    };
                TipoRetencionPlan.ForEach(t => context.TipoRetencionPlan.Add(t));
                context.SaveChanges();

                var TipoBonificacion = new List<TipoBonificacion>
                    {
                        new TipoBonificacion{TipoBonificacionID="C", Nombre="Sobre Cuota",Descripcion="Sobre Cuota"},
                        new TipoBonificacion{TipoBonificacionID="V", Nombre="Sobre Valor nominal",Descripcion="Sobre Valor nominal"},
                        new TipoBonificacion{TipoBonificacionID="N", Nombre="Nula",Descripcion="Nula"},
                        new TipoBonificacion{TipoBonificacionID="X", Nombre="CUOTAS",Descripcion="CUOTAS"}
                    };
                TipoBonificacion.ForEach(t => context.TipoBonificacion.Add(t));
                context.SaveChanges();

                var TipoCuota = new List<TipoCuota>
                    {
                        new TipoCuota{TipoCuotaID="A", Nombre="Adelantada"},
                        new TipoCuota{TipoCuotaID="V", Nombre="Vencida"}
                    };
                TipoCuota.ForEach(t => context.TipoCuota.Add(t));
                context.SaveChanges();


                var TipoPago = new List<TipoPago>
                    {
                        new TipoPago{TipoPagoID="A", Nombre="A Cuenta", Descripcion = "A Cuenta"},
                        new TipoPago{TipoPagoID="B", Nombre="Bonificada", Descripcion = "Bonificada"},
                        new TipoPago{TipoPagoID="C", Nombre="Cuota", Descripcion = "Cuota"},
                        new TipoPago{TipoPagoID="D", Nombre="Adelanto de Refinanciacion", Descripcion = "Adelanto de Refinanciacion"},
                        new TipoPago{TipoPagoID="E",Nombre = "Débito Directo",Descripcion ="Débito Directo" },
                        new TipoPago{TipoPagoID="F",Nombre = "Tarjeta de Débito",Descripcion ="Tarjeta de Débito" },
                        new TipoPago{TipoPagoID="G", Nombre="Arreglo", Descripcion = "Arreglo"},
                        new TipoPago{TipoPagoID="H",Nombre = "Tarjeta de Crédito",Descripcion ="Tarjeta de Crédito" },
                        new TipoPago{TipoPagoID="N", Nombre="Anulada", Descripcion = "Anulada"},
                        new TipoPago{TipoPagoID="P", Nombre="Punitorios bajados", Descripcion = "Punitorios bajados"},
                        new TipoPago{TipoPagoID="Q", Nombre="Punitorios quitados", Descripcion = "Punitorios quitados"},
                        new TipoPago{TipoPagoID="R", Nombre="Refinanciación", Descripcion = "Refinanciación"},
                        new TipoPago{TipoPagoID="S", Nombre="Abogado", Descripcion = "Abogado"},
                        new TipoPago{TipoPagoID="T", Nombre="Anticipado", Descripcion = "Anticipado"},
                        new TipoPago{TipoPagoID = "X",Nombre = "AGREGADO POR SISTEMA; REVISAR Y UNIFICAR TIPOPAGO",Descripcion ="AGREGADO POR SISTEMA; REVISAR Y UNIFICAR TIPOPAGO" }
                    };
                TipoPago.ForEach(t => context.TipoPago.Add(t));
                context.SaveChanges();
                
                var TipoImpresion = new List<TipoImpresion>
                    {
                        new TipoImpresion{Nombre = "ALTAS" },
                        new TipoImpresion{Nombre = "AVISOS" },
                        new TipoImpresion{Nombre = "CANCELADOS" },
                        new TipoImpresion{Nombre = "CARNET" },
                        new TipoImpresion{Nombre = "COBRANZAS" },
                        new TipoImpresion{Nombre = "COBRERROR" },
                        new TipoImpresion{Nombre = "MINUTA" },
                        new TipoImpresion{Nombre = "OTROS" },
                        new TipoImpresion{Nombre = "PLANES" },
                        new TipoImpresion{Nombre = "PLANESC" },
                        new TipoImpresion{Nombre = "FACTURA" },
                        new TipoImpresion{Nombre = "FACTURA A" },
                        new TipoImpresion{Nombre = "FACTURA B" },
                        new TipoImpresion{Nombre = "CHEQUERA" },
                        new TipoImpresion{Nombre = "IMPRESION DEBITO" }
                    };
                TipoImpresion.ForEach(t => context.TipoImpresion.Add(t));
                context.SaveChanges();

                var TipoCuentaBancaria = new List<TipoCuentaBancaria>
                    {
                        new TipoCuentaBancaria{TipoCuentaBancariaID = 1, Nombre = "Cuenta Corriente" ,Descripcion = "Cuenta Corriente"},
                        new TipoCuentaBancaria{TipoCuentaBancariaID = 2, Nombre = "Caja de ahorro" ,Descripcion = "Caja de ahorro"},
                        new TipoCuentaBancaria{TipoCuentaBancariaID = 3, Nombre = "Cuenta Sueldo" ,Descripcion = "Cuenta Sueldo"}                        
                    };
                TipoCuentaBancaria.ForEach(t => context.TiposCuentasBancarias.Add(t));
                context.SaveChanges();

                var ClaseCuentaBancaria = new List<ClaseCuentaBancaria>
                    {
                        new ClaseCuentaBancaria{ClaseCuentaBancariaID = 1, Nombre = "Cuenta Bancaria de empresa" ,Descripcion = "Cuenta Bancaria de empresa"},
                        new ClaseCuentaBancaria{ClaseCuentaBancariaID = 2, Nombre = "Cuenta Bancaria de comercio" ,Descripcion = "Cuenta Bancaria de comercio"},
                        new ClaseCuentaBancaria{ClaseCuentaBancariaID = 3, Nombre = "Cuenta Bancaria de empleado" ,Descripcion = "Cuenta Bancaria de empleado"},                
                        new ClaseCuentaBancaria{ClaseCuentaBancariaID = 4, Nombre = "Cuenta Bancaria de proveedor" ,Descripcion = "Cuenta Bancaria de proveedor"}
                    };
                ClaseCuentaBancaria.ForEach(t => context.ClaseCuentasBancarias.Add(t));
                context.SaveChanges();

                 var TipoImagen = new List<TipoImagen>
                    {
                        new TipoImagen{Nombre = "Documento" , Sufijo = "_DOC_01", Orden = 1},
                        new TipoImagen{Nombre = "Documento" , Sufijo = "_DOC_02", Orden = 2},
                        new TipoImagen{Nombre = "Servicio" , Sufijo = "_SER_01", Orden = 3},
                        new TipoImagen{Nombre = "Servicio" , Sufijo = "_SER_02", Orden = 4},
                        new TipoImagen{Nombre = "Servicio" , Sufijo = "_SER_03", Orden = 5},
                        new TipoImagen{Nombre = "Recibo" , Sufijo = "_REC_01", Orden = 6},
                        new TipoImagen{Nombre = "Recibo" , Sufijo = "_REC_02", Orden = 7},
                        new TipoImagen{Nombre = "Recibo" , Sufijo = "_REC_03", Orden = 8},
                        new TipoImagen{Nombre = "Solicitud" , Sufijo = "_SOL_01", Orden = 9},
                        new TipoImagen{Nombre = "Solicitud" , Sufijo = "_SOL_02", Orden = 10},
                        new TipoImagen{Nombre = "Solicitud" , Sufijo = "_SOL_03", Orden = 11},
                        new TipoImagen{Nombre = "Solicitud" , Sufijo = "_SOL_04", Orden = 12},
                        new TipoImagen{Nombre = "Solicitud" , Sufijo = "_SOL_05", Orden = 13},
                        new TipoImagen{Nombre = "Solicitud" , Sufijo = "_SOL_06", Orden = 14},
                        new TipoImagen{Nombre = "Solicitud" , Sufijo = "_SOL_07", Orden = 15},
                        new TipoImagen{Nombre = "Solicitud" , Sufijo = "_SOL_08", Orden = 16},
                        new TipoImagen{Nombre = "Firma" , Sufijo = "_FIR_01", Orden = 17},
                        new TipoImagen{Nombre = "Firma" , Sufijo = "_FIR_02", Orden = 18},
                        new TipoImagen{Nombre = "Firma" , Sufijo = "_FIR_03", Orden = 19},
                        new TipoImagen{Nombre = "Otros" , Sufijo = "_OTR_01", Orden = 20},
                        new TipoImagen{Nombre = "Otros" , Sufijo = "_OTR_02", Orden = 21}
                        
                    };
                TipoImagen.ForEach(t => context.TipoImagen.Add(t));
                context.SaveChanges();

            }
            //}
            //  catch (DbEntityValidationException e)
            //  {
            //      foreach (var eve in e.EntityValidationErrors)
            //      {
            //          Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
            //              eve.Entry.Entity.GetType().Name, eve.Entry.State);
            //          foreach (var ve in eve.ValidationErrors)
            //          {
            //              Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
            //                  ve.PropertyName, ve.ErrorMessage);
            //          }
            //      }
            //      throw;
            //  }
            //  catch (Exception eve)
            //  {
            //          Debug.WriteLine(eve.Message);
            //          Exception innerEx = eve.InnerException;
            //          while (eve.InnerException != null)
            //          { 
            //              Debug.WriteLine(eve.InnerException.Message);
            //              innerEx = eve.InnerException;
            //          }
            //  }

            //Para actualizar la base, hay que hacer publica la clase configuration y ejecutar esto en alguna clase
            //Configuration configuration = new Configuration();
            //configuration.ContextType = typeof(YourContextClassHere);
            //var migrator = new DbMigrator(configuration);

            ////This will get the SQL script which will update the DB and write it to debug
            //var scriptor = new MigratorScriptingDecorator(migrator);
            //string script = scriptor.ScriptUpdate(sourceMigration: null, targetMigration: null).ToString();
            //Debug.Write(script);

            ////This will run the migration update script and will run Seed() method
            //migrator.Update();

            //Otra forma

            //Answering Question #2: Extract all the code from the Seed() method to another class. Then call that from within the Seed() method from the Configuration class:

            //protected override void Seed(DbContext ctx)
            //{
            //    new DatabaseSeed().Seed(ctx);
            //}
            //Then you can call it from anywhere:

            //new DatabaseSeed().Seed(new DbContext());
        }
    }
}
