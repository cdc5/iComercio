using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using iComercio.Models;
using iComercio.Rest.RestModels;
using iComercio.Auxiliar;
using iComercio.ViewModels;

namespace iComercio.Configuration
{
    class MapperConfig
    {
        static public void Configurar()
        {
            CrearMapaSolicitudFondo();
        }

        static private void CrearMapaSolicitudFondo()
        {
            Mapper.CreateMap<SolicitudFondo, SolicitudFondoRestModel>()
                .ForMember(dest => dest.Empresa, opt => opt.Ignore())
                .ForMember(dest => dest.Comercio, opt => opt.Ignore())
                .ForMember(dest => dest.MedioDePago, opt => opt.Ignore())
                .ForMember(dest => dest.ConceptoFondos, opt => opt.Ignore())
                .ForMember(dest => dest.Estado, opt => opt.Ignore())
                .ForMember(dest => dest.EmpleadoSolicitante, opt => opt.Ignore())
                .ForMember(dest => dest.EmpleadoRealizador, opt => opt.Ignore())
                //.ForMember(dest => dest.SolicitudFondoConceptoGastosProveedor, opt => opt.Ignore())
                .ForMember(dest => dest.TipoSolicitud, opt => opt.Ignore())
                .ForMember(dest => dest.OrdenDePago, opt => opt.Ignore())
                .ForMember(dest => dest.Moneda, opt => opt.Ignore())
                .ForMember(dest => dest.Cheque, opt => opt.Ignore())
                .ForMember(dest => dest.GeneradoPorComercio, opt => opt.Ignore())
                .ForMember(dest => dest.GeneradoPorDepartamento, opt => opt.Ignore());
            /* .ForMember(dest => dest.SolicitudFondoID, opt => opt.MapFrom(src => src.solfon_id))
                .ForMember(dest => dest.FechaPago, opt => opt.MapFrom(src => src.solfon_fecha_pago))
                .ForMember(dest => dest.FechaRealizacion, opt => opt.MapFrom(src => src.solfon_fecha_realizacion))
                .ForMember(dest => dest.Importe, opt => opt.MapFrom(src => src.solfon_importe))
                .ForMember(dest => dest.MedioDePagoID, opt => opt.MapFrom(src => src.medpag_id))
                .ForMember(dest => dest.MedioDePago, opt => opt.Ignore())
                .ForMember(dest => dest.ConceptoFondosID, opt => opt.MapFrom(src => src.confon_id))
                .ForMember(dest => dest.ConceptoFondos, opt => opt.Ignore())
                .ForMember(dest => dest.ComercioID, opt => opt.MapFrom(src => src.com_id))
                .ForMember(dest => dest.Comercio, opt => opt.Ignore())
                .ForMember(dest => dest.EmpresaID, opt => opt.MapFrom(src => src.emp_id))
                .ForMember(dest => dest.Empresa, opt => opt.Ignore())
                .ForMember(dest => dest.TransferenciasDepositosID, opt => opt.MapFrom(src => src.trandep_id))
                .ForMember(dest => dest.TransferenciasDepositosEmpId, opt => opt.MapFrom(src => src.trandep_emp_id))
                .ForMember(dest => dest.TransferenciasDepositos, opt => opt.Ignore())
                .ForMember(dest => dest.ClaseCuentaBancariaID, opt => opt.MapFrom(src => src.ccb_id))
                .ForMember(dest => dest.CuentaBancariaID, opt => opt.MapFrom(src => src.cb_id))
                .ForMember(dest => dest.NumChequera, opt => opt.MapFrom(src => src.cheq_num_chequera))
                .ForMember(dest => dest.NumCheque, opt => opt.MapFrom(src => src.che_num_cheque))
                .ForMember(dest => dest.Cheque, opt => opt.Ignore())
                .ForMember(dest => dest.EstadoID, opt => opt.MapFrom(src => src.est_id))
                .ForMember(dest => dest.Estado, opt => opt.Ignore())
                .ForMember(dest => dest.MonedaID, opt => opt.MapFrom(src => src.mon_id))
                .ForMember(dest => dest.Moneda, opt => opt.Ignore())
                .ForMember(dest => dest.Motivo, opt => opt.MapFrom(src => src.solfon_motivo))
                .ForMember(dest => dest.FechaDispComienzo, opt => opt.MapFrom(src => src.solfon_fecha_disp_comienzo))
                .ForMember(dest => dest.FechaDispFinal, opt => opt.MapFrom(src => src.solfon_fecha_disp_final))
                .ForMember(dest => dest.GeneradoPorComercioID, opt => opt.MapFrom(src => src.generadoPorComercio))
                .ForMember(dest => dest.GeneradoPorComercio, opt => opt.Ignore())
                .ForMember(dest => dest.GeneradoPorDepartamentoID, opt => opt.MapFrom(src => src.generadoPorDepartamento))
                .ForMember(dest => dest.GeneradoPorDepartamento, opt => opt.Ignore())
                .ForMember(dest => dest.TipoSolicitudID, opt => opt.MapFrom(src => src.tps_id))
                .ForMember(dest => dest.TipoSolicitud, opt => opt.Ignore())
                .ForMember(dest => dest.FechaConfComercio, opt => opt.MapFrom(src => src.solfon_fecha_conf_comer))
                .ForMember(dest => dest.EmpleadoConfComercio, opt => opt.MapFrom(src => src.solfon_emp_conf_comer))
                .ForMember(dest => dest.notas, opt => opt.MapFrom(src => src.notas))
                .ForMember(dest => dest.EmpleadoSolicitanteID, opt => opt.MapFrom(src => src.empl_solicitante))
                .ForMember(dest => dest.EmpleadoSolicitante, opt => opt.Ignore())
                .ForMember(dest => dest.EmpleadoRealizadorID, opt => opt.MapFrom(src => src.empl_realizador))
                .ForMember(dest => dest.EmpleadoRealizador, opt => opt.Ignore())
                .ForMember(dest => dest.EmpleadoRealizador, opt => opt.Ignore())
                .ForMember(dest => dest.ConceptoGastosProveedorID, opt => opt.MapFrom(src => src.cgp_id))
                .ForMember(dest => dest.ConceptoGastosProveedor, opt => opt.Ignore())
                .ForMember(dest => dest.ConceptoGastosID, opt => opt.MapFrom(src => src.congas_id))
                .ForMember(dest => dest.ProveedorSucursalID, opt => opt.MapFrom(src => src.provsuc_id))
                .ForMember(dest => dest.ProveedorID, opt => opt.MapFrom(src => src.prov_id))
                .ForMember(dest => dest.LiquidacionID, opt => opt.MapFrom(src => src.liq_id))
                .ForMember(dest => dest.OrdenDePagoID, opt => opt.MapFrom(src => src.ordpag_id))
                .ForMember(dest => dest.OrdenDePago, opt => opt.Ignore())
                .ForMember(dest => dest.CajaID, opt => opt.MapFrom(src => src.caja_id));*/
           
            Mapper.CreateMap<SolicitudFondoRestModel, SolicitudFondo>()
                .ForMember(dest => dest.SolicitudFondoID, opt => opt.MapFrom(src => src.SolicitudFondoIDRemoto))
                .ForMember(dest => dest.SolicitudFondoIDRemoto, opt => opt.MapFrom(src => src.SolicitudFondoID))
                .ForMember(dest => dest.FechaPagoSF, opt => opt.Ignore())
                .ForMember(dest => dest.InfoParaRecibos, opt => opt.Ignore())
                .ForMember(dest => dest.sDetalleSolFon, opt => opt.Ignore())
                .ForMember(dest => dest.SolicitudFondoConceptoGastosProveedor, opt => opt.Ignore())
                .ForMember(dest => dest.AvisoDePago, opt => opt.Ignore());

            Mapper.CreateMap<SolicitudFondoConceptoGastosProveedor, SolicitudFondoConceptoGastosProveedorRestModel>()
                .ForMember(dest => dest.ConceptoGastoID, opt => opt.MapFrom(src=>src.ConceptoGastosProveedor.ConceptoGastosID))
                .ForMember(dest => dest.ProveedorID, opt => opt.MapFrom(src=>src.ConceptoGastosProveedor.ProveedorID));

            Mapper.CreateMap<SolicitudFondoConceptoGastosProveedorRestModel,SolicitudFondoConceptoGastosProveedor>()
               .ForMember(dest => dest.Comercio, opt => opt.Ignore())
               .ForMember(dest => dest.ConceptoGastosProveedor, opt => opt.Ignore())
               .ForMember(dest => dest.Empresa, opt => opt.Ignore())
               .ForMember(dest => dest.sConceptoGastosProveedor, opt => opt.Ignore())
               .ForMember(dest => dest.SolicitudFondo, opt => opt.Ignore());
                
            
            Mapper.CreateMap<Proveedor, ProveedorRestModel>()
                .ForMember(dest => dest.Estado, opt => opt.Ignore())
                .ForMember(dest => dest.Localidad, opt => opt.Ignore())
                .ForMember(dest => dest.Provincia, opt => opt.Ignore())
                .ForMember(dest => dest.Pais, opt => opt.Ignore())
                .ForMember(dest => dest.Sucursales, opt => opt.Ignore());

            Mapper.CreateMap<ConceptoGastosProveedor, ConceptoGastoProveedorRestModel>()
                .ForMember(dest => dest.Estado, opt => opt.Ignore())
                .ForMember(dest => dest.ConceptoGastos, opt => opt.Ignore())
                .ForMember(dest => dest.Proveedor, opt => opt.Ignore())
                .ForMember(dest => dest.ProveedorSucursal, opt => opt.Ignore());
           // Mapper.CreateMap<IEnumerable<ConceptoGastosProveedor>, IEnumerable<ConceptoGastoProveedorRestModel>>();
           
            Mapper.CreateMap<ConceptoGastoProveedorRestModel,ConceptoGastosProveedor>()
                .ForMember(dest => dest.Estado, opt => opt.Ignore())
                .ForMember(dest => dest.ConceptoGastos, opt => opt.Ignore())
                .ForMember(dest => dest.Proveedor, opt => opt.Ignore())
                .ForMember(dest => dest.ProveedorSucursal, opt => opt.Ignore()); ;

            //Mapper.CreateMap<ProveedorRestModel, Proveedor>().ForMember(dest => dest.ConceptoGastosProveedor, opt => opt.Ignore());
            Mapper.CreateMap<ProveedorRestModel, Proveedor>()
            .ForMember(dest => dest.ProveedorID, opt => opt.MapFrom(src => src.ProveedorIDRemoto))
            .ForMember(dest => dest.ProveedorIDRemoto, opt => opt.MapFrom(src => src.ProveedorID));

            Mapper.CreateMap<ProveedorSucursal, ProveedorSucursalRestModel>()
               .ForMember(dest => dest.Estado, opt => opt.Ignore())
               .ForMember(dest => dest.Localidad, opt => opt.Ignore())
               .ForMember(dest => dest.Provincia, opt => opt.Ignore())
               .ForMember(dest => dest.Pais, opt => opt.Ignore())
               .ForMember(dest => dest.Proveedor, opt => opt.Ignore());
               
            Mapper.CreateMap<ProveedorSucursalRestModel, ProveedorSucursal>()
            .ForMember(dest => dest.ProveedorSucursalID, opt => opt.MapFrom(src => src.ProveedorSucursalIDRemoto))
            .ForMember(dest => dest.ProveedorSucursalIDRemoto, opt => opt.MapFrom(src => src.ProveedorSucursalID));


            Mapper.CreateMap<int?, IntRestModel>();
            //         .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value));
            Mapper.CreateMap<IntRestModel, int?>();


            Mapper.CreateMap<ConceptoGastos, ConceptoGastosRestModel>()
                .ForMember(dest => dest.Estado, opt => opt.Ignore())
                .ForMember(dest => dest.ConceptoGastoPadre, opt => opt.Ignore());

            Mapper.CreateMap<ConceptoGastosRestModel, ConceptoGastos>()
                .ForMember(dest => dest.ConceptoGastosID, opt => opt.MapFrom(src => src.ConceptoGastosIDRemoto))
                .ForMember(dest => dest.ConceptoGastosIDRemoto, opt => opt.MapFrom(src => src.ConceptoGastosID))
                .ForMember(dest => dest.Estado, opt => opt.Ignore()).
                ForMember(dest => dest.NombreCompleto, opt => opt.Ignore()); ;

            Mapper.CreateMap<Cliente, ClienteRestModel>();

            Mapper.CreateMap<ClienteRestModel, Cliente>()
            .ForMember(dest => dest.UsuarioModificacion, opt => opt.Ignore())
            .ForMember(dest => dest.TipoComoConocio, opt => opt.Ignore())
            .ForMember(dest => dest.TipoDocumento, opt => opt.Ignore())
            .ForMember(dest => dest.NombreCompleto, opt => opt.Ignore())
            .ForMember(dest => dest.UltimoDomicilioCliente, opt => opt.Ignore())
            .ForMember(dest => dest.UltimoDomicilioEmpresa, opt => opt.Ignore())
            .ForMember(dest => dest.UltimoTelefonoCliente, opt => opt.Ignore())
            .ForMember(dest => dest.UltimoTelefonoEmpresa, opt => opt.Ignore())
            .ForMember(dest => dest.UltimoMailCliente, opt => opt.Ignore())
            .ForMember(dest => dest.UltimoMailEmpresa, opt => opt.Ignore())
            .ForMember(dest => dest.Profesion, opt => opt.MapFrom(src => src.Profesion))
            .ForMember(dest => dest.Sexo, opt => opt.MapFrom(src => src.Sexo))
            .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Estado))
             .ForMember(dest => dest.UltimaNota, opt => opt.Ignore());
            //.ForMember(dest => dest.Creditos, opt => opt.ResolveUsing<CreditoListResolver>().FromMember(s => s.Creditos))
            //.ForMember(dest => dest.CreditosAdi, opt => opt.ResolveUsing<CreditoListResolver>().FromMember(s => s.CreditosAdi))
            //.ForMember(dest => dest.CreditosGar1, opt => opt.ResolveUsing<NullListResolver<CreditoRestModel>>().FromMember(s => s.CreditosGar1))
            //.ForMember(dest => dest.CreditosGar2, opt => opt.ResolveUsing<NullListResolver<CreditoRestModel>>().FromMember(s => s.CreditosGar2))
            //.ForMember(dest => dest.CreditosGar3, opt => opt.ResolveUsing<NullListResolver<CreditoRestModel>>().FromMember(s => s.CreditosGar3))
            //.ForMember(dest => dest.Refinanciaciones, opt => opt.ResolveUsing<NullListResolver<RefinanciacionRestModel>>().FromMember(s => s.Refinanciaciones))
            //.ForMember(dest => dest.Mails, opt => opt.ResolveUsing<NullListResolver<MailRestModel>>().FromMember(s => s.Mails))
            //.ForMember(dest => dest.Domicilios, opt => opt.ResolveUsing<NullListResolver<DomicilioRestModel>>().FromMember(s => s.Domicilios))
            //.ForMember(dest => dest.Notas, opt => opt.ResolveUsing<NullListResolver<NotaRestModel>>().FromMember(s => s.Notas))
            //.ForMember(dest => dest.Telefonos, opt => opt.ResolveUsing<NullListResolver<TelefonoRestModel>>().FromMember(s => s.Telefonos));


            Mapper.CreateMap<Credito, CreditoAnulado>()
               .ForMember(dest => dest.CreditoAnuladoID, opt => opt.Ignore())
               .ForMember(dest => dest.UsuarioIDAnula, opt => opt.Ignore())
               .ForMember(dest => dest.PcComerAnula, opt => opt.Ignore())
               .ForMember(dest => dest.FechaComercioAnula, opt => opt.Ignore())
               .ForMember(dest => dest.Motivo, opt => opt.Ignore())
               .ForMember(dest => dest.TipoAnulacionID, opt => opt.Ignore())
               .ForMember(dest => dest.TipoAnulacion, opt => opt.Ignore());

            Mapper.CreateMap<CreditoAnulado, Credito>()
               .ForMember(dest => dest.TipoCuota, opt => opt.Ignore())
               .ForMember(dest => dest.Total, opt => opt.Ignore())
               .ForMember(dest => dest.sTotal, opt => opt.Ignore())
               .ForMember(dest => dest.Cancelado, opt => opt.Ignore())
               .ForMember(dest => dest.Gar1, opt => opt.Ignore())
               .ForMember(dest => dest.Gar2, opt => opt.Ignore())
               .ForMember(dest => dest.Gar3, opt => opt.Ignore())
               .ForMember(dest => dest.Adi, opt => opt.Ignore())
               .ForMember(dest => dest.UsuarioAval, opt => opt.Ignore())
               .ForMember(dest => dest.UsuarioAvalAnt, opt => opt.Ignore())
               .ForMember(dest => dest.Abogado, opt => opt.Ignore())
               .ForMember(dest => dest.Usuario, opt => opt.Ignore())
               .ForMember(dest => dest.UsuarioAnt, opt => opt.Ignore())
               .ForMember(dest => dest.TipoBonificacion, opt => opt.Ignore())
               .ForMember(dest => dest.Refinanciaciones, opt => opt.Ignore())
               .ForMember(dest => dest.Cuotas, opt => opt.Ignore())
               .ForMember(dest => dest.Notas, opt => opt.Ignore())
               .ForMember(dest => dest.CreditoAvales, opt => opt.Ignore())
               .ForMember(dest => dest.Cobranzas, opt => opt.Ignore())
               .ForMember(dest => dest.AdelantadaGastos, opt => opt.Ignore())
               .ForMember(dest => dest.sAdelantadaGastos, opt => opt.Ignore());

            
            Mapper.CreateMap<CreditoAnulado, CreditoAnuladoRestModel>()
                .ForMember(dest => dest.NombreUsuario, opt => opt.MapFrom(src => src.Usuario != null ? src.Usuario.usuario : String.Empty)); ;
            Mapper.CreateMap<CreditoAnuladoRestModel, CreditoAnulado>()
                .ForMember(dest => dest.Usuario, opt => opt.Ignore())
                .ForMember(dest => dest.Empresa, opt => opt.Ignore())
                .ForMember(dest => dest.Comercio, opt => opt.Ignore())
                .ForMember(dest => dest.Cliente, opt => opt.Ignore())
                .ForMember(dest => dest.TipoAnulacion, opt => opt.Ignore());
            
            Mapper.CreateMap<Credito, CreditoRestModel>()
            .ForMember(dest => dest.EmpresaNombre, opt => opt.MapFrom(src => src.Empresa != null ? src.Empresa.ToString() : String.Empty))
                .ForMember(dest => dest.ComercioNombre, opt => opt.MapFrom(src => src.Comercio != null ? src.Comercio.ToString() : String.Empty))
                .ForMember(dest => dest.Garante1Nombre, opt => opt.MapFrom(src => src.Garante1 != null ? src.Garante1.ToString() : String.Empty))
                .ForMember(dest => dest.AdicionalNombre, opt => opt.MapFrom(src => src.Adi != null ? src.Adi.ToString() : String.Empty))
                .ForMember(dest => dest.NombreUsuario, opt => opt.MapFrom(src => src.Usuario != null ? src.Usuario.usuario : String.Empty));
             
            
            Mapper.CreateMap<CreditoRestModel, Credito>()
                  .ForMember(dest => dest.Adi, opt => opt.Ignore())
                  .ForMember(dest => dest.Gar1, opt => opt.Ignore())
                  .ForMember(dest => dest.Gar2, opt => opt.Ignore())
                  .ForMember(dest => dest.Gar3, opt => opt.Ignore())
                  .ForMember(dest => dest.Comercio, opt => opt.Ignore())
                  //.ForMember(dest => dest.Refinanciacion, opt => opt.Ignore())
                  .ForMember(dest => dest.TipoBonificacion, opt => opt.Ignore())
                  .ForMember(dest => dest.TipoCuotaID, opt => opt.Ignore())
                  .ForMember(dest => dest.Usuario, opt => opt.Ignore())
                  .ForMember(dest => dest.UsuarioAval, opt => opt.Ignore())
                  .ForMember(dest => dest.Empresa, opt => opt.Ignore())
                  .ForMember(dest => dest.Cliente, opt => opt.Ignore())
                  .ForMember(dest => dest.TipoCuota, opt => opt.Ignore())
                  .ForMember(dest => dest.Abogado, opt => opt.Ignore())
                  .ForMember(dest => dest.Notas, opt => opt.Ignore())
                  .ForMember(dest => dest.Total, opt => opt.Ignore())
                  .ForMember(dest => dest.sTotal, opt => opt.Ignore())
                  .ForMember(dest => dest.AdelantadaGastos, opt => opt.Ignore())
                  .ForMember(dest => dest.sAdelantadaGastos, opt => opt.Ignore());

            Mapper.CreateMap<Cuota, Cuota>();

            Mapper.CreateMap<Cuota, CuotaRestModel>();
            Mapper.CreateMap<CuotaRestModel, Cuota>()
                //.ForMember(dest => dest.TipoBonificacion, opt => opt.Ignore())
                .ForMember(dest => dest.TipoCuota, opt => opt.Ignore())
                //.ForMember(dest => dest.TipoPago, opt => opt.Ignore())
                .ForMember(dest => dest.Cliente, opt => opt.Ignore())
                .ForMember(dest => dest.Credito, opt => opt.Ignore())
                .ForMember(dest => dest.Comercio, opt => opt.Ignore())
                .ForMember(dest => dest.Empresa, opt => opt.Ignore());

            Mapper.CreateMap<Cobranza, Cobranza>();
            Mapper.CreateMap<Cobranza, CobranzaRestModel>()
            .ForMember(dest => dest.NombreUsuario, opt => opt.MapFrom(src => src.Usuario != null ? src.Usuario.usuario : String.Empty));

            Mapper.CreateMap<CobranzaRestModel, Cobranza>()
                .ForMember(dest => dest.TipoBonificacion, opt => opt.Ignore())
                .ForMember(dest => dest.TipoPago, opt => opt.Ignore())
                .ForMember(dest => dest.Cliente, opt => opt.Ignore())
                .ForMember(dest => dest.Comercio, opt => opt.Ignore())
                .ForMember(dest => dest.Usuario, opt => opt.Ignore())
                .ForMember(dest => dest.Cuota, opt => opt.Ignore())
                .ForMember(dest => dest.Credito, opt => opt.Ignore())
                .ForMember(dest => dest.Empresa, opt => opt.Ignore())
                .ForMember(dest => dest.Gestion, opt => opt.Ignore())
                .ForMember(dest => dest.ImporteTotal, opt => opt.Ignore())
                .ForMember(dest => dest.ImporteCapital, opt => opt.Ignore())
                ;

            Mapper.CreateMap<NotasCD, NotasCDRestModel>();

            Mapper.CreateMap<NotasCDRestModel, NotasCD>()
                .ForMember(dest => dest.Cobranza, opt => opt.Ignore())
                .ForMember(dest => dest.Usuario, opt => opt.Ignore());
              


            Mapper.CreateMap<Refinanciacion, RefinanciacionRestModel>()
                .ForMember(dest => dest.RefinanciacionesCuotas, opt => opt.MapFrom(src => src.RefinanciacionCuotas))
                .ForMember(dest => dest.NombreUsuario, opt => opt.MapFrom(src => src.Usuario != null ? src.Usuario.usuario : String.Empty));
            Mapper.CreateMap<RefinanciacionRestModel, Refinanciacion>()
                .ForMember(dest => dest.Credito, opt => opt.Ignore())
                .ForMember(dest => dest.Comercio, opt => opt.Ignore())
                .ForMember(dest => dest.Empresa, opt => opt.Ignore())
                .ForMember(dest => dest.Cliente, opt => opt.Ignore())
                .ForMember(dest => dest.Usuario, opt => opt.Ignore())
                .ForMember(dest => dest.Estado, opt => opt.Ignore())
                .ForMember(dest => dest.RefinanciacionCuotas, opt => opt.MapFrom(src => src.RefinanciacionesCuotas));
                //.ForMember(dest => dest.UsuarioAutorizo, opt => opt.Ignore());

            Mapper.CreateMap<RefinanciacionCuota, RefinanciacionCuotaRestModel>();

            Mapper.CreateMap<RefinanciacionCuotaRestModel, RefinanciacionCuota>()
                  .ForMember(dest => dest.Cliente, opt => opt.Ignore())
                //.ForMember(dest => dest.TipoCuotaID, opt => opt.Ignore())
                  .ForMember(dest => dest.Refinanciacion, opt => opt.Ignore())
                  .ForMember(dest => dest.Comercio, opt => opt.Ignore())
                  .ForMember(dest => dest.Empresa, opt => opt.Ignore())
                  .ForMember(dest => dest.Deuda, opt => opt.Ignore());

            Mapper.CreateMap<RefinanciacionCobranza, RefinanciacionCobranzaRestModel>();                
            Mapper.CreateMap<RefinanciacionCobranzaRestModel, RefinanciacionCobranza>()
                  .ForMember(dest => dest.Cliente, opt => opt.Ignore())
                  .ForMember(dest => dest.TipoPago, opt => opt.Ignore())
                  .ForMember(dest => dest.RefinanciacionCuota, opt => opt.Ignore())
                  .ForMember(dest => dest.Refinanciacion, opt => opt.Ignore())
                  .ForMember(dest => dest.Comercio, opt => opt.Ignore())
                  .ForMember(dest => dest.Empresa, opt => opt.Ignore())
                  .ForMember(dest => dest.Gestion, opt => opt.Ignore());


            Mapper.CreateMap<TipoBonificacion, TipoBonificacionRestModel>();

            Mapper.CreateMap<TipoBonificacionRestModel, TipoBonificacion>();
                 
            Mapper.CreateMap<TipoCuota, TipoCuotaRestModel>();
            Mapper.CreateMap<TipoCuotaRestModel, TipoCuota>();
                 
            Mapper.CreateMap<TipoRetencionPlan, TipoRetencionPlanRestModel>();
            Mapper.CreateMap<TipoRetencionPlanRestModel, TipoRetencionPlan>();
                

            Mapper.CreateMap<Nota, NotaRestModel>();
            Mapper.CreateMap<NotaRestModel, Nota>()
                .ForMember(dest => dest.Usuario, opt => opt.Ignore());
             

            Mapper.CreateMap<TipoAval, TipoAvalRestModel>();
            Mapper.CreateMap<TipoAvalRestModel, TipoAval>();



            Mapper.CreateMap<Domicilio, DomicilioRestModel>()
                  .ForMember(dest => dest.LocalidadCP, opt => opt.MapFrom(src => src.Localidad != null ? src.Localidad.CodPostal : null));
            Mapper.CreateMap<DomicilioRestModel, Domicilio>()
                .ForMember(dest => dest.ClaseDato, opt => opt.Ignore())
                .ForMember(dest => dest.Estado, opt => opt.Ignore())
                .ForMember(dest => dest.Localidad, opt => opt.Ignore())
                .ForMember(dest => dest.Provincia, opt => opt.Ignore())
                .ForMember(dest => dest.Pais, opt => opt.Ignore())
                .ForMember(dest => dest.Cliente, opt => opt.Ignore())
                .ForMember(dest => dest.Usuario, opt => opt.Ignore())
                .ForMember(dest => dest.DomicilioCompleto, opt => opt.Ignore());


            Mapper.CreateMap<Telefono, TelefonoRestModel>();
            Mapper.CreateMap<TelefonoRestModel, Telefono>()
                .ForMember(dest => dest.ClaseDato, opt => opt.Ignore())
                .ForMember(dest => dest.Estado, opt => opt.Ignore())
                .ForMember(dest => dest.Cliente, opt => opt.Ignore())
                .ForMember(dest => dest.Usuario, opt => opt.Ignore())
                .ForMember(dest => dest.TelefonoCompleto, opt => opt.Ignore());

            Mapper.CreateMap<Mail, MailRestModel>();
            Mapper.CreateMap<MailRestModel, Mail>()
                .ForMember(dest => dest.ClaseDato, opt => opt.Ignore())
                .ForMember(dest => dest.Estado, opt => opt.Ignore())
                .ForMember(dest => dest.Cliente, opt => opt.Ignore())
                .ForMember(dest => dest.Usuario, opt => opt.Ignore());

            Mapper.CreateMap<Camara, CamaraRestModel>();
            Mapper.CreateMap<CamaraRestModel, Camara>();

            Mapper.CreateMap<InfoCliente, InfoClienteRestModel>();
            Mapper.CreateMap<InfoClienteRestModel, InfoCliente>();

            Mapper.CreateMap<Estado, EstadoRestModel>();
            Mapper.CreateMap<EstadoRestModel, Estado>();

            Mapper.CreateMap<TipoEstado, TipoEstadoRestModel>();
            Mapper.CreateMap<TipoEstadoRestModel, TipoEstado>();

            Mapper.CreateMap<Profesion, ProfesionRestModel>()
                .ForMember(dest => dest.ProfesionPadre, opt => opt.Ignore())
                .ForMember(dest => dest.SubProfesiones, opt => opt.Ignore());
            Mapper.CreateMap<ProfesionRestModel, Profesion>()
                .ForMember(dest => dest.ProfesionPadre, opt => opt.Ignore())
                .ForMember(dest => dest.SubProfesiones, opt => opt.Ignore());

            Mapper.CreateMap<Sexo, SexoRestModel>();
            Mapper.CreateMap<SexoRestModel, Sexo>();


            Mapper.CreateMap<CreditoAval, CreditoAvalRestModel>();
            Mapper.CreateMap<CreditoAvalRestModel, CreditoAval>()
                .ForMember(dest => dest.Comercio, opt => opt.Ignore())
                .ForMember(dest => dest.Credito, opt => opt.Ignore())
                .ForMember(dest => dest.Empresa, opt => opt.Ignore())
                .ForMember(dest => dest.Tipoaval, opt => opt.Ignore())
                .ForMember(dest => dest.Usuario, opt => opt.Ignore());

            Mapper.CreateMap<CuentaCorriente, CuentaCorrienteRestModel>();
            Mapper.CreateMap<CuentaCorrienteRestModel, CuentaCorriente>()
                .ForMember(dest => dest.CuentaCorrienteID, opt => opt.MapFrom(src => src.IDRemoto))
                .ForMember(dest => dest.IDRemoto, opt => opt.MapFrom(src => src.CuentaCorrienteID))
                .ForMember(dest => dest.Comercio, opt => opt.Ignore())
                .ForMember(dest => dest.Credito, opt => opt.Ignore())
                .ForMember(dest => dest.Empresa, opt => opt.Ignore())
                .ForMember(dest => dest.Cuota, opt => opt.Ignore())
                .ForMember(dest => dest.Cobranza, opt => opt.Ignore())
                .ForMember(dest => dest.NotaCD, opt => opt.Ignore())
                .ForMember(dest => dest.SolicitudFondo, opt => opt.Ignore())
                .ForMember(dest => dest.TipoMovimiento, opt => opt.Ignore())
                .ForMember(dest => dest.Recibo, opt => opt.Ignore())
                .ForMember(dest => dest.TransferenciasDepositos, opt => opt.Ignore())
                .ForMember(dest => dest.Gasto, opt => opt.Ignore())
                .ForMember(dest => dest.Pago, opt => opt.Ignore());

            Mapper.CreateMap<Recibo, ReciboRestModel>()
                .ForMember(dest => dest.NombreUsuario, opt => opt.MapFrom(src => src.Usuario != null ? src.Usuario.usuario : String.Empty));
            Mapper.CreateMap<ReciboRestModel, Recibo>()
                .ForMember(dest => dest.Comercio, opt => opt.Ignore())
                .ForMember(dest => dest.Empresa, opt => opt.Ignore())
                .ForMember(dest => dest.SolucitudFondo, opt => opt.Ignore())
                .ForMember(dest => dest.Usuario, opt => opt.Ignore())
                .ForMember(dest => dest.TransferenciasDepositos, opt => opt.Ignore())
                .ForMember(dest => dest.TipoMovimiento, opt => opt.Ignore())
                .ForMember(dest => dest.Estado, opt => opt.Ignore())
                .ForMember(dest => dest.ComercioAdherido, opt => opt.Ignore());

            Mapper.CreateMap<TransferenciasDepositos, TransferenciasDepositosRestModel>()
                .ForMember(dest => dest.NombreUsuario, opt => opt.MapFrom(src => src.Usuario != null ? src.Usuario.usuario : String.Empty)); ;
            Mapper.CreateMap<TransferenciasDepositosRestModel, TransferenciasDepositos>()
                .ForMember(dest => dest.Comercio, opt => opt.Ignore())
                .ForMember(dest => dest.Empresa, opt => opt.Ignore())
                .ForMember(dest => dest.cheque, opt => opt.Ignore())
                .ForMember(dest => dest.ComercioEmpresa, opt => opt.Ignore())
                .ForMember(dest => dest.CuentaDestino, opt => opt.Ignore())
                .ForMember(dest => dest.CuentaOrigen, opt => opt.Ignore())
                .ForMember(dest => dest.EmpleadoRegistrador, opt => opt.Ignore())
                .ForMember(dest => dest.MedioDePago, opt => opt.Ignore())
                .ForMember(dest => dest.Moneda, opt => opt.Ignore())
                .ForMember(dest => dest.Persona, opt => opt.Ignore())
                .ForMember(dest => dest.ProveedorSucursal, opt => opt.Ignore())
                .ForMember(dest => dest.Usuario, opt => opt.Ignore())
                .ForMember(dest => dest.TipoTransferenciaDeposito, opt => opt.Ignore())
                .ForMember(dest => dest.Estado, opt => opt.Ignore());

            Mapper.CreateMap<Credito, CreditoCobranzaViewModel>()
                .ForMember(dest => dest.Credito, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.Cobranzas, opt => opt.MapFrom(src => src.Cuotas.SelectMany(c=>c.Cobranzas)));



            Mapper.CreateMap<Cap, CapRestModel>()
                .ForMember(dest => dest.SolicitudFondoRestModel, opt => opt.MapFrom(src => src.SolicitudFondo)); 
            Mapper.CreateMap<CapRestModel, Cap>()
                .ForMember(dest => dest.SolicitudFondo, opt => opt.MapFrom(src => src.SolicitudFondoRestModel))
                .ForMember(dest => dest.Comercio, opt => opt.Ignore())
                .ForMember(dest => dest.Empresa, opt => opt.Ignore())
                .ForMember(dest => dest.SolicitudFondo, opt => opt.Ignore())
                .ForMember(dest => dest.Estado, opt => opt.Ignore())
                .ForMember(dest => dest.sCapDescripcion, opt => opt.Ignore());

            Mapper.CreateMap<CapDetalle, CapDetalleRestModel>();
            Mapper.CreateMap<CapDetalleRestModel, CapDetalle>()
                .ForMember(dest => dest.Cap, opt => opt.Ignore())
                .ForMember(dest => dest.sDetalleCapDescripcion, opt => opt.Ignore());

            Mapper.CreateMap<FF, FFRestModel>()
                .ForMember(dest => dest.SolicitudFondoRestModel, opt => opt.MapFrom(src => src.SolicitudFondo));
            Mapper.CreateMap<FFRestModel, FF>()
                .ForMember(dest => dest.SolicitudFondo, opt => opt.MapFrom(src => src.SolicitudFondoRestModel))
                .ForMember(dest => dest.Comercio, opt => opt.Ignore())
                .ForMember(dest => dest.Empresa, opt => opt.Ignore())
                .ForMember(dest => dest.SolicitudFondo, opt => opt.Ignore())
                .ForMember(dest => dest.Estado, opt => opt.Ignore())
                .ForMember(dest => dest.sFFDescripcion, opt => opt.Ignore());

            Mapper.CreateMap<FFDetalle, FFDetalleRestModel>();
            Mapper.CreateMap<FFDetalleRestModel, FFDetalle>()
                .ForMember(dest => dest.sDetalleFFDescripcion, opt => opt.Ignore())
                .ForMember(dest => dest.FF, opt => opt.Ignore());

            Mapper.CreateMap<Gasto, GastoRestModel>();
                
            Mapper.CreateMap<GastoRestModel, Gasto>()
                .ForMember(dest => dest.Comercio, opt => opt.Ignore())
                .ForMember(dest => dest.Empresa, opt => opt.Ignore())
                .ForMember(dest => dest.SolicitudFondo, opt => opt.Ignore())
                .ForMember(dest => dest.Estado, opt => opt.Ignore())
                .ForMember(dest => dest.Departamento, opt => opt.Ignore())
                .ForMember(dest => dest.Proveedor, opt => opt.Ignore())
                .ForMember(dest => dest.ProveedorSucursal, opt => opt.Ignore())
                .ForMember(dest => dest.ConceptoGastos, opt => opt.Ignore())
                .ForMember(dest => dest.ConceptoGastosProveedor, opt => opt.Ignore());
                

            Mapper.CreateMap<Pago, PagoRestModel>();
            Mapper.CreateMap<PagoRestModel, Pago>()
                .ForMember(dest => dest.Comercio, opt => opt.Ignore())
                .ForMember(dest => dest.Empresa, opt => opt.Ignore())
                .ForMember(dest => dest.SolicitudFondo, opt => opt.Ignore())
                .ForMember(dest => dest.CapDetalle, opt => opt.Ignore())
                .ForMember(dest => dest.FFDetalle, opt => opt.Ignore())
                .ForMember(dest => dest.Estado, opt => opt.Ignore())
                .ForMember(dest => dest.sPagoDescripcion, opt => opt.Ignore());

            Mapper.CreateMap<CuentaBancariaCliente, CuentaBancariaClienteRestModel>();
            Mapper.CreateMap<CuentaBancariaClienteRestModel, CuentaBancariaCliente>()
                .ForMember(dest => dest.TipoDocumento, opt => opt.Ignore())
                .ForMember(dest => dest.SucursalBanco, opt => opt.Ignore())
                .ForMember(dest => dest.Banco, opt => opt.Ignore())
                .ForMember(dest => dest.moneda, opt => opt.Ignore())
                .ForMember(dest => dest.Estado, opt => opt.Ignore())
                .ForMember(dest => dest.sCuentaBancaria, opt => opt.Ignore())
                .ForMember(dest => dest.Cliente, opt => opt.Ignore()); 
               



            Mapper.AssertConfigurationIsValid();
        }

        public class CreditoListResolver : ValueResolver<ObservableListSource<CreditoRestModel>, ObservableListSource<CreditoRestModel>> 
        {
            protected override ObservableListSource<CreditoRestModel> ResolveCore(ObservableListSource<CreditoRestModel> source)
            {
                return source.Count() == 0 ? null : source;
            }

        }

        public class NullListResolver<T> : ValueResolver<IEnumerable<T>, IEnumerable<T>> where T : class
        {
            protected override IEnumerable<T> ResolveCore(IEnumerable<T> source)
            {
                return source.Count() == 0 ? null : source;
            }
        }
    }
}
