namespace iComercio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Autorizacion",
                c => new
                    {
                        EmpresaID = c.Int(nullable: false),
                        ComercioID = c.Int(nullable: false),
                        AutorizacionID = c.Long(nullable: false),
                        SolicitudFondoID = c.Long(),
                        EstadoID = c.Int(),
                        Motivo = c.String(),
                        Fecha = c.DateTime(precision: 7, storeType: "datetime2"),
                        PersonaID = c.Int(),
                        EmpresaNombre = c.String(),
                        ConceptoFondosNombre = c.String(),
                        TipoSolicitudNombre = c.String(),
                        ComercioNombreNum = c.String(),
                        OrdenDePagoID = c.Long(nullable: false),
                        SolicitudFondoFechaPago = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ChequeNumCheque = c.String(),
                        CuentaBancaria = c.String(),
                        CuentaContable = c.String(),
                        Importe = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Observaciones = c.String(),
                        NumCajaImpCont = c.String(),
                    })
                .PrimaryKey(t => new { t.EmpresaID, t.ComercioID, t.AutorizacionID })
                .ForeignKey("dbo.Comercio", t => new { t.EmpresaID, t.ComercioID }, cascadeDelete: true)
                .ForeignKey("dbo.Empresa", t => t.EmpresaID, cascadeDelete: true)
                .ForeignKey("dbo.Estado", t => t.EstadoID)
                .ForeignKey("dbo.Persona", t => t.PersonaID)
                .Index(t => new { t.EmpresaID, t.ComercioID })
                .Index(t => t.EstadoID)
                .Index(t => t.PersonaID);
            
            CreateTable(
                "dbo.Comercio",
                c => new
                    {
                        EmpresaID = c.Int(nullable: false),
                        ComercioID = c.Int(nullable: false),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        Domicilio = c.String(),
                        Barrio = c.String(),
                        TipoComercioID = c.Int(),
                        LocalidadID = c.Int(),
                        ProvinciaID = c.Int(),
                        PaisId = c.Int(),
                        Telefono1 = c.String(),
                        Telefono2 = c.String(),
                        Recorrido = c.Int(),
                        Cuit = c.String(),
                        Mail1 = c.String(),
                        Mail2 = c.String(),
                        CodPromo = c.String(),
                        PorPromo = c.Decimal(precision: 18, scale: 2),
                        PagaBanco = c.Boolean(),
                        Venci = c.Int(),
                        Corte = c.Int(),
                        Habilitado = c.Boolean(),
                        Por30 = c.Decimal(precision: 19, scale: 4),
                        Por30M = c.Decimal(precision: 19, scale: 4),
                        Clave = c.String(),
                        Compu = c.Boolean(),
                        Fanta = c.String(),
                        Categoria = c.String(),
                        Tolerancia = c.Int(),
                        NumCredito = c.Int(),
                        NumCliente = c.Int(),
                        NumRendi = c.Int(),
                        FechaIngreso = c.DateTime(),
                        FechaPRendi = c.DateTime(),
                        Contacto1ID = c.Int(),
                        Contacto2ID = c.Int(),
                        Titular1ID = c.Int(),
                        Titular2ID = c.Int(),
                        Rubro = c.String(),
                        CanLoc = c.Int(),
                        CanPer = c.Int(),
                        CanVid = c.Int(),
                        CtaDep = c.String(),
                        ForPag = c.String(),
                        OrdCheq = c.String(),
                        PerFinan = c.String(),
                        LlevaGar = c.Int(),
                        Notas = c.String(),
                        Cuenta = c.Int(),
                        CredPri = c.Decimal(precision: 18, scale: 2),
                        CredSeg = c.Decimal(precision: 18, scale: 2),
                        Consolid = c.Int(),
                        Trab = c.Boolean(),
                        Refinancia = c.Boolean(),
                        IntRef = c.Decimal(precision: 18, scale: 2),
                        IntAde = c.Decimal(precision: 18, scale: 2),
                        IntArr = c.Decimal(precision: 18, scale: 2),
                        PorSueldo = c.Decimal(precision: 18, scale: 2),
                        Llp = c.Boolean(),
                        Pm = c.Boolean(),
                        ImpCi = c.Decimal(precision: 18, scale: 2),
                        FechaCi = c.DateTime(),
                        ImpCiVta = c.Decimal(precision: 18, scale: 2),
                        CiVtaFecha = c.DateTime(),
                        Principal = c.Boolean(nullable: false),
                        PuedeCobrar = c.Boolean(nullable: false),
                        Contacto1_PersonaID = c.Int(),
                        Contacto2_PersonaID = c.Int(),
                        Titular1_PersonaID = c.Int(),
                        Titular2_PersonaID = c.Int(),
                    })
                .PrimaryKey(t => new { t.EmpresaID, t.ComercioID })
                .ForeignKey("dbo.Persona", t => t.Contacto1_PersonaID)
                .ForeignKey("dbo.Persona", t => t.Contacto2_PersonaID)
                .ForeignKey("dbo.Empresa", t => t.EmpresaID)
                .ForeignKey("dbo.Localidad", t => new { t.PaisId, t.ProvinciaID, t.LocalidadID })
                .ForeignKey("dbo.Pais", t => t.PaisId)
                .ForeignKey("dbo.Provincia", t => new { t.PaisId, t.ProvinciaID })
                .ForeignKey("dbo.TipoComercio", t => t.TipoComercioID)
                .ForeignKey("dbo.Persona", t => t.Titular1_PersonaID)
                .ForeignKey("dbo.Persona", t => t.Titular2_PersonaID)
                .Index(t => t.EmpresaID)
                .Index(t => t.TipoComercioID)
                .Index(t => new { t.PaisId, t.ProvinciaID, t.LocalidadID })
                .Index(t => t.Contacto1_PersonaID)
                .Index(t => t.Contacto2_PersonaID)
                .Index(t => t.Titular1_PersonaID)
                .Index(t => t.Titular2_PersonaID);
            
            CreateTable(
                "dbo.Persona",
                c => new
                    {
                        PersonaID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Documento = c.Int(),
                        Domicilio = c.String(),
                        Fotografia = c.String(),
                        LocalidadID = c.Int(),
                        ProvinciaID = c.Int(),
                        PaisID = c.Int(),
                        Telefono1 = c.String(),
                        Telefono2 = c.String(),
                        Mail1 = c.String(),
                        Mail2 = c.String(),
                        Cel = c.String(),
                        Edad = c.Int(),
                        FechaNacimiento = c.DateTime(),
                        TiposDocumentoID = c.String(),
                        TiposDocumento_TipoDocumentoID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.PersonaID)
                .ForeignKey("dbo.Localidad", t => new { t.PaisID, t.ProvinciaID, t.LocalidadID })
                .ForeignKey("dbo.Pais", t => t.PaisID)
                .ForeignKey("dbo.Provincia", t => new { t.PaisID, t.ProvinciaID })
                .ForeignKey("dbo.TipoDocumento", t => t.TiposDocumento_TipoDocumentoID)
                .Index(t => new { t.PaisID, t.ProvinciaID, t.LocalidadID })
                .Index(t => t.TiposDocumento_TipoDocumentoID);
            
            CreateTable(
                "dbo.Localidad",
                c => new
                    {
                        PaisId = c.Int(nullable: false),
                        ProvinciaID = c.Int(nullable: false),
                        LocalidadID = c.Int(nullable: false),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        CodPostal = c.String(),
                        CodTel = c.String(),
                        X = c.Decimal(precision: 18, scale: 2),
                        Y = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.PaisId, t.ProvinciaID, t.LocalidadID })
                .ForeignKey("dbo.Provincia", t => new { t.PaisId, t.ProvinciaID })
                .ForeignKey("dbo.Pais", t => t.PaisId, cascadeDelete: true)
                .Index(t => new { t.PaisId, t.ProvinciaID });
            
            CreateTable(
                "dbo.Pais",
                c => new
                    {
                        PaisID = c.Int(nullable: false),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        CodIsoNumerico = c.Int(),
                        CodIso2 = c.String(),
                        CodIso3 = c.String(),
                        DirImaBandera = c.String(),
                        CodTel = c.String(),
                        X = c.Decimal(precision: 18, scale: 2),
                        Y = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PaisID);
            
            CreateTable(
                "dbo.Provincia",
                c => new
                    {
                        PaisId = c.Int(nullable: false),
                        ProvinciaID = c.Int(nullable: false),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        CodIso = c.String(),
                        DirImaEscudo = c.String(),
                        CodTel = c.String(),
                        X = c.Decimal(precision: 18, scale: 2),
                        Y = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.PaisId, t.ProvinciaID })
                .ForeignKey("dbo.Pais", t => t.PaisId)
                .Index(t => t.PaisId);
            
            CreateTable(
                "dbo.TipoDocumento",
                c => new
                    {
                        TipoDocumentoID = c.String(nullable: false, maxLength: 128),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.TipoDocumentoID);
            
            CreateTable(
                "dbo.Empresa",
                c => new
                    {
                        EmpresaID = c.Int(nullable: false),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        NombreBase = c.String(),
                        Mail = c.String(),
                        MailCont = c.String(),
                        MailNotificaciones = c.String(),
                        MailNotificacionesCont = c.String(),
                        ServidorCorreo = c.String(),
                        EmpresaDiminutivo = c.String(),
                        Cuit = c.String(),
                        IIBB = c.String(),
                        IA = c.String(),
                        Domicilio = c.String(),
                        Localidad = c.String(),
                        Provincia = c.String(),
                        CP = c.String(),
                        Telefono1 = c.String(),
                        Telefono2 = c.String(),
                        Telefono3 = c.String(),
                        Telefonos = c.String(),
                    })
                .PrimaryKey(t => t.EmpresaID);
            
            CreateTable(
                "dbo.CuentaBancaria",
                c => new
                    {
                        EmpresaID = c.Int(nullable: false),
                        CuentaBancariaID = c.Int(nullable: false),
                        NumCuenta = c.String(),
                        Cbu = c.String(),
                        Descripcion = c.String(),
                        Notas = c.String(),
                        FechaAlta = c.DateTime(),
                        ComercioID = c.Int(),
                        ClaseCuentaBancariaID = c.Int(),
                        TipoCuentaBancariaID = c.Int(),
                        SucursalBancoID = c.Int(nullable: false),
                        BancoID = c.Int(nullable: false),
                        MonedaID = c.Int(),
                        EmiteCheque = c.Boolean(nullable: false),
                        CuentaContable = c.String(),
                        EstadoID = c.Int(),
                        PersonaID = c.Int(),
                        prov_id = c.Int(),
                        provsuc_id = c.Int(),
                        Proveedor_ProveedorID = c.Int(),
                        ProveedorSucursal_ProveedorSucursalID = c.Int(),
                    })
                .PrimaryKey(t => new { t.EmpresaID, t.CuentaBancariaID })
                .ForeignKey("dbo.Banco", t => t.BancoID, cascadeDelete: true)
                .ForeignKey("dbo.ClaseCuentaBancaria", t => t.ClaseCuentaBancariaID)
                .ForeignKey("dbo.Comercio", t => new { t.EmpresaID, t.ComercioID })
                .ForeignKey("dbo.Estado", t => t.EstadoID)
                .ForeignKey("dbo.Moneda", t => t.MonedaID)
                .ForeignKey("dbo.Persona", t => t.PersonaID)
                .ForeignKey("dbo.Proveedor", t => t.Proveedor_ProveedorID)
                .ForeignKey("dbo.ProveedorSucursal", t => t.ProveedorSucursal_ProveedorSucursalID)
                .ForeignKey("dbo.SucursalBanco", t => new { t.BancoID, t.SucursalBancoID }, cascadeDelete: true)
                .ForeignKey("dbo.TipoCuentaBancaria", t => t.TipoCuentaBancariaID)
                .ForeignKey("dbo.Empresa", t => t.EmpresaID, cascadeDelete: true)
                .Index(t => new { t.EmpresaID, t.ComercioID })
                .Index(t => t.ClaseCuentaBancariaID)
                .Index(t => t.TipoCuentaBancariaID)
                .Index(t => new { t.BancoID, t.SucursalBancoID })
                .Index(t => t.BancoID)
                .Index(t => t.MonedaID)
                .Index(t => t.EstadoID)
                .Index(t => t.PersonaID)
                .Index(t => t.Proveedor_ProveedorID)
                .Index(t => t.ProveedorSucursal_ProveedorSucursalID);
            
            CreateTable(
                "dbo.Banco",
                c => new
                    {
                        BancoID = c.Int(nullable: false),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.BancoID);
            
            CreateTable(
                "dbo.Chequera",
                c => new
                    {
                        EmpresaID = c.Int(nullable: false),
                        CuentaBancariaID = c.Int(nullable: false),
                        ChequeraID = c.String(nullable: false, maxLength: 128),
                        NumTalonario = c.String(),
                        NumDesde = c.String(),
                        NumHasta = c.String(),
                        NumProx = c.String(),
                        FechaAlta = c.DateTime(),
                        EstadoID = c.Int(),
                    })
                .PrimaryKey(t => new { t.EmpresaID, t.CuentaBancariaID, t.ChequeraID })
                .ForeignKey("dbo.Estado", t => t.EstadoID)
                .ForeignKey("dbo.CuentaBancaria", t => new { t.EmpresaID, t.CuentaBancariaID }, cascadeDelete: true)
                .Index(t => new { t.EmpresaID, t.CuentaBancariaID })
                .Index(t => t.EstadoID);
            
            CreateTable(
                "dbo.Cheque",
                c => new
                    {
                        EmpresaID = c.Int(nullable: false),
                        CuentaBancariaID = c.Int(nullable: false),
                        ChequeraID = c.String(nullable: false, maxLength: 128),
                        ChequeID = c.String(nullable: false, maxLength: 128),
                        Monto = c.Decimal(precision: 18, scale: 2),
                        TipoChequeID = c.Int(),
                        EstadoID = c.Int(),
                    })
                .PrimaryKey(t => new { t.EmpresaID, t.CuentaBancariaID, t.ChequeraID, t.ChequeID })
                .ForeignKey("dbo.Estado", t => t.EstadoID)
                .ForeignKey("dbo.TipoCheque", t => t.TipoChequeID)
                .ForeignKey("dbo.Chequera", t => new { t.EmpresaID, t.CuentaBancariaID, t.ChequeraID }, cascadeDelete: true)
                .Index(t => new { t.EmpresaID, t.CuentaBancariaID, t.ChequeraID })
                .Index(t => t.TipoChequeID)
                .Index(t => t.EstadoID);
            
            CreateTable(
                "dbo.Estado",
                c => new
                    {
                        EstadoID = c.Int(nullable: false),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        TipoEstadoID = c.Int(),
                        est_color = c.String(),
                    })
                .PrimaryKey(t => t.EstadoID)
                .ForeignKey("dbo.TipoEstado", t => t.TipoEstadoID)
                .Index(t => t.TipoEstadoID);
            
            CreateTable(
                "dbo.TipoEstado",
                c => new
                    {
                        TipoEstadoID = c.Int(nullable: false),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.TipoEstadoID);
            
            CreateTable(
                "dbo.TipoCheque",
                c => new
                    {
                        TipoChequeID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TipoChequeID);
            
            CreateTable(
                "dbo.ClaseCuentaBancaria",
                c => new
                    {
                        ClaseCuentaBancariaID = c.Int(nullable: false),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.ClaseCuentaBancariaID);
            
            CreateTable(
                "dbo.Moneda",
                c => new
                    {
                        MonedaID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        PaisId = c.Int(),
                        mon_simbolo = c.String(),
                    })
                .PrimaryKey(t => t.MonedaID)
                .ForeignKey("dbo.Pais", t => t.PaisId)
                .Index(t => t.PaisId);
            
            CreateTable(
                "dbo.Proveedor",
                c => new
                    {
                        ProveedorID = c.Int(nullable: false, identity: true),
                        ProveedorIDRemoto = c.Int(),
                        NombreFantasia = c.String(),
                        RazonSocial = c.String(),
                        Cuit = c.String(),
                        IngresosBrutos = c.String(),
                        Domicilio = c.String(),
                        Telefono1 = c.String(),
                        Telefono2 = c.String(),
                        Descripcion = c.String(),
                        LocalidadID = c.Int(),
                        ProvinciaID = c.Int(),
                        PaisId = c.Int(),
                        Cp = c.String(),
                        Fax = c.String(),
                        Mail1 = c.String(),
                        Mail2 = c.String(),
                        Mail3 = c.String(),
                        Web1 = c.String(),
                        Web2 = c.String(),
                        Tel3 = c.String(),
                        Web3 = c.String(),
                        CodigoContable = c.String(),
                        EstadoID = c.Int(nullable: false),
                        CondIva = c.Int(),
                        FechaAlta = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.ProveedorID)
                .ForeignKey("dbo.Estado", t => t.EstadoID, cascadeDelete: true)
                .ForeignKey("dbo.Localidad", t => new { t.PaisId, t.ProvinciaID, t.LocalidadID })
                .ForeignKey("dbo.Pais", t => t.PaisId)
                .ForeignKey("dbo.Provincia", t => new { t.PaisId, t.ProvinciaID })
                .Index(t => new { t.PaisId, t.ProvinciaID, t.LocalidadID })
                .Index(t => t.EstadoID);
            
            CreateTable(
                "dbo.ConceptoGastosProveedor",
                c => new
                    {
                        ConceptoGastosProveedorID = c.Int(nullable: false, identity: true),
                        ConceptoGastosID = c.Int(),
                        ProveedorID = c.Int(),
                        ProveedorSucursalID = c.Int(),
                        Periodicidad = c.Int(),
                        EstadoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ConceptoGastosProveedorID)
                .ForeignKey("dbo.ConceptoGastos", t => t.ConceptoGastosID)
                .ForeignKey("dbo.Estado", t => t.EstadoID, cascadeDelete: true)
                .ForeignKey("dbo.Proveedor", t => t.ProveedorID)
                .ForeignKey("dbo.ProveedorSucursal", t => t.ProveedorSucursalID)
                .Index(t => t.ConceptoGastosID)
                .Index(t => t.ProveedorID)
                .Index(t => t.ProveedorSucursalID)
                .Index(t => t.EstadoID);
            
            CreateTable(
                "dbo.ConceptoGastos",
                c => new
                    {
                        ConceptoGastosID = c.Int(nullable: false),
                        ConceptoGastosIDRemoto = c.Int(),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        EstadoID = c.Int(nullable: false),
                        Nivel = c.Int(),
                        NivelFinal = c.Boolean(nullable: false),
                        ConceptoGastoPadreID = c.Int(),
                    })
                .PrimaryKey(t => t.ConceptoGastosID)
                .ForeignKey("dbo.ConceptoGastos", t => t.ConceptoGastoPadreID)
                .ForeignKey("dbo.Estado", t => t.EstadoID, cascadeDelete: true)
                .Index(t => t.EstadoID)
                .Index(t => t.ConceptoGastoPadreID);
            
            CreateTable(
                "dbo.ProveedorSucursal",
                c => new
                    {
                        ProveedorSucursalID = c.Int(nullable: false, identity: true),
                        ProveedorID = c.Int(),
                        ProveedorSucursalIDRemoto = c.Int(),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        Domicilio = c.String(),
                        LocalidadID = c.Int(),
                        ProvinciaID = c.Int(),
                        PaisID = c.Int(),
                        Telefono1 = c.String(),
                        Telefono2 = c.String(),
                        Telefono3 = c.String(),
                        Mail1 = c.String(),
                        Mail2 = c.String(),
                        Mail3 = c.String(),
                        Fax = c.String(),
                        Web2 = c.String(),
                        Web1 = c.String(),
                        Web3 = c.String(),
                        Cp = c.String(),
                        EstadoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProveedorSucursalID)
                .ForeignKey("dbo.Estado", t => t.EstadoID, cascadeDelete: true)
                .ForeignKey("dbo.Localidad", t => new { t.PaisID, t.ProvinciaID, t.LocalidadID })
                .ForeignKey("dbo.Pais", t => t.PaisID)
                .ForeignKey("dbo.Proveedor", t => t.ProveedorID)
                .ForeignKey("dbo.Provincia", t => new { t.PaisID, t.ProvinciaID })
                .Index(t => t.ProveedorID)
                .Index(t => new { t.PaisID, t.ProvinciaID, t.LocalidadID })
                .Index(t => t.EstadoID);
            
            CreateTable(
                "dbo.SucursalBanco",
                c => new
                    {
                        BancoID = c.Int(nullable: false),
                        SucursalBancoID = c.Int(nullable: false),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        Domicilio = c.String(),
                        Numsuc = c.String(),
                        LocalidadID = c.Int(),
                        ProvinciaID = c.Int(),
                        PaisId = c.Int(),
                    })
                .PrimaryKey(t => new { t.BancoID, t.SucursalBancoID })
                .ForeignKey("dbo.Banco", t => t.BancoID)
                .ForeignKey("dbo.Localidad", t => new { t.PaisId, t.ProvinciaID, t.LocalidadID })
                .ForeignKey("dbo.Pais", t => t.PaisId)
                .ForeignKey("dbo.Provincia", t => new { t.PaisId, t.ProvinciaID })
                .Index(t => t.BancoID)
                .Index(t => new { t.PaisId, t.ProvinciaID, t.LocalidadID });
            
            CreateTable(
                "dbo.TipoCuentaBancaria",
                c => new
                    {
                        TipoCuentaBancariaID = c.Int(nullable: false),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.TipoCuentaBancariaID);
            
            CreateTable(
                "dbo.TipoComercio",
                c => new
                    {
                        TipoComercioID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.TipoComercioID);
            
            CreateTable(
                "dbo.AvisoDePago",
                c => new
                    {
                        EmpresaID = c.Int(nullable: false),
                        ComercioID = c.Int(nullable: false),
                        AvisoDePagoID = c.Int(nullable: false),
                        FechaPagoAviso = c.DateTime(nullable: false),
                        Importe = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Retencion = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Comision = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Pagado = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FechaPagado = c.DateTime(nullable: false),
                        CantSolicitudes = c.Int(nullable: false),
                        FechaActualizacion = c.DateTime(nullable: false),
                        Notas = c.String(),
                    })
                .PrimaryKey(t => new { t.EmpresaID, t.ComercioID, t.AvisoDePagoID })
                .ForeignKey("dbo.Comercio", t => new { t.EmpresaID, t.ComercioID }, cascadeDelete: true)
                .ForeignKey("dbo.Empresa", t => t.EmpresaID, cascadeDelete: true)
                .Index(t => new { t.EmpresaID, t.ComercioID });
            
            CreateTable(
                "dbo.Credito",
                c => new
                    {
                        EmpresaID = c.Int(nullable: false),
                        ComercioID = c.Int(nullable: false),
                        CreditoID = c.Int(nullable: false),
                        Documento = c.Int(nullable: false),
                        TipoDocumentoID = c.String(nullable: false, maxLength: 128),
                        ValorNominal = c.Decimal(nullable: false, precision: 19, scale: 2),
                        ValorCuota = c.Decimal(nullable: false, precision: 19, scale: 2),
                        FechaSolicitud = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Total = c.Decimal(nullable: false, precision: 19, scale: 2),
                        Interes = c.Decimal(nullable: false, precision: 19, scale: 2),
                        Gasto = c.Decimal(nullable: false, precision: 19, scale: 2),
                        Comision = c.Decimal(nullable: false, precision: 19, scale: 2),
                        Cancelado = c.Boolean(nullable: false),
                        Garante1 = c.Int(),
                        TipoDocumentoIDG1 = c.String(maxLength: 128),
                        Garante2 = c.Int(),
                        TipoDocumentoIDG2 = c.String(maxLength: 128),
                        Garante3 = c.Int(),
                        TipoDocumentoIDG3 = c.String(maxLength: 128),
                        Adicional = c.Int(),
                        TipoDocumentoIDAdi = c.String(maxLength: 128),
                        Avalado = c.Boolean(nullable: false),
                        usuarioAvalID = c.Int(),
                        UsuarioAvalAnt = c.String(),
                        TipoCuotaID = c.String(maxLength: 128),
                        CantidadCuotas = c.Int(nullable: false),
                        NroInformeContel = c.Int(),
                        AbogadoID = c.Int(),
                        FechaAbogado = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UsuarioID = c.Int(nullable: false),
                        UsuarioAnt = c.String(),
                        PcComer = c.String(),
                        FechaComer = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        TipoBonificacionID = c.String(maxLength: 128),
                        PorcentajeBonificacion = c.Decimal(precision: 19, scale: 2),
                        ValorBonificacion = c.Decimal(precision: 18, scale: 2),
                        TasaPlan = c.Decimal(nullable: false, precision: 19, scale: 2),
                        IncrementoPlan = c.Decimal(nullable: false, precision: 19, scale: 2),
                        GastoPlan = c.Decimal(nullable: false, precision: 19, scale: 2),
                        GastoIncrementoPlan = c.Decimal(nullable: false, precision: 19, scale: 2),
                        GastoFijo = c.Boolean(nullable: false),
                        ComisionPlan = c.Decimal(nullable: false, precision: 19, scale: 2),
                        ComisionIncrementoPlan = c.Decimal(nullable: false, precision: 19, scale: 2),
                        TipoRetencionPlanID = c.String(),
                        NombrePlan = c.String(maxLength: 50),
                        Puntaje = c.Decimal(precision: 18, scale: 2),
                        DiasVenciPrimerCuota = c.Int(nullable: false),
                        RefinanciacionID = c.Int(),
                        AvisoDePagoID = c.Int(),
                        Corte = c.Int(nullable: false),
                        FechaAviso = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => new { t.EmpresaID, t.ComercioID, t.CreditoID })
                .ForeignKey("dbo.Comercio", t => new { t.EmpresaID, t.AbogadoID })
                .ForeignKey("dbo.Cliente", t => new { t.Documento, t.TipoDocumentoID })
                .ForeignKey("dbo.Cliente", t => new { t.Adicional, t.TipoDocumentoIDAdi })
                .ForeignKey("dbo.Cliente", t => new { t.Garante1, t.TipoDocumentoIDG1 })
                .ForeignKey("dbo.Cliente", t => new { t.Garante2, t.TipoDocumentoIDG2 })
                .ForeignKey("dbo.Cliente", t => new { t.Garante3, t.TipoDocumentoIDG3 })
                .ForeignKey("dbo.Comercio", t => new { t.EmpresaID, t.ComercioID })
                .ForeignKey("dbo.Empresa", t => t.EmpresaID)
                .ForeignKey("dbo.TipoBonificacion", t => t.TipoBonificacionID)
                .ForeignKey("dbo.TipoCuota", t => t.TipoCuotaID)
                .ForeignKey("dbo.Usuario", t => t.UsuarioID)
                .ForeignKey("dbo.Usuario", t => t.usuarioAvalID)
                .ForeignKey("dbo.AvisoDePago", t => new { t.EmpresaID, t.ComercioID, t.AvisoDePagoID })
                .Index(t => new { t.EmpresaID, t.AbogadoID })
                .Index(t => new { t.EmpresaID, t.ComercioID })
                .Index(t => new { t.EmpresaID, t.ComercioID, t.AvisoDePagoID })
                .Index(t => new { t.Documento, t.TipoDocumentoID })
                .Index(t => new { t.Garante1, t.TipoDocumentoIDG1 })
                .Index(t => new { t.Garante2, t.TipoDocumentoIDG2 })
                .Index(t => new { t.Garante3, t.TipoDocumentoIDG3 })
                .Index(t => new { t.Adicional, t.TipoDocumentoIDAdi })
                .Index(t => t.usuarioAvalID)
                .Index(t => t.TipoCuotaID)
                .Index(t => t.UsuarioID)
                .Index(t => t.TipoBonificacionID);
            
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        Documento = c.Int(nullable: false),
                        TipoDocumentoID = c.String(nullable: false, maxLength: 128),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        ProfesionID = c.String(maxLength: 128),
                        EmpresaLaboral = c.String(),
                        Sueldo = c.Decimal(precision: 18, scale: 2),
                        Legajo = c.String(),
                        FechaNacimiento = c.DateTime(precision: 7, storeType: "datetime2"),
                        SexoID = c.String(maxLength: 128),
                        FechaAlta = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        TipoComoConocioID = c.String(maxLength: 128),
                        Puntaje = c.Decimal(precision: 18, scale: 2),
                        Tarjeta = c.Boolean(),
                        FechaAltaTarjeta = c.DateTime(precision: 7, storeType: "datetime2"),
                        FechaVencimientoTarjeta = c.DateTime(precision: 7, storeType: "datetime2"),
                        FechaModificacion = c.DateTime(precision: 7, storeType: "datetime2"),
                        UsuarioModificacionID = c.Int(),
                        EstadoID = c.Int(nullable: false),
                        NombreCompleto = c.String(),
                    })
                .PrimaryKey(t => new { t.Documento, t.TipoDocumentoID })
                .ForeignKey("dbo.Estado", t => t.EstadoID, cascadeDelete: true)
                .ForeignKey("dbo.Profesion", t => t.ProfesionID)
                .ForeignKey("dbo.Sexo", t => t.SexoID)
                .ForeignKey("dbo.TipoComoConocio", t => t.TipoComoConocioID)
                .ForeignKey("dbo.TipoDocumento", t => t.TipoDocumentoID, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.UsuarioModificacionID)
                .Index(t => t.TipoDocumentoID)
                .Index(t => t.ProfesionID)
                .Index(t => t.SexoID)
                .Index(t => t.TipoComoConocioID)
                .Index(t => t.UsuarioModificacionID)
                .Index(t => t.EstadoID);
            
            CreateTable(
                "dbo.Domicilio",
                c => new
                    {
                        DomicilioID = c.Int(nullable: false, identity: true),
                        Direccion = c.String(),
                        Numero = c.String(),
                        Piso = c.String(),
                        Departamento = c.String(),
                        Complemento = c.String(),
                        NotasDomicilio = c.String(),
                        LocalidadID = c.Int(),
                        ProvinciaID = c.Int(),
                        PaisId = c.Int(),
                        ClaseDatoID = c.Int(nullable: false),
                        EstadoID = c.Int(nullable: false),
                        EmpresaID = c.Int(),
                        ComercioID = c.Int(),
                        Documento = c.Int(nullable: false),
                        TipoDocumentoID = c.String(maxLength: 128),
                        Fecha = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UsuarioID = c.Int(nullable: false),
                        PcComer = c.String(),
                        DomicilioCompleto = c.String(),
                    })
                .PrimaryKey(t => t.DomicilioID)
                .ForeignKey("dbo.ClaseDato", t => t.ClaseDatoID, cascadeDelete: true)
                .ForeignKey("dbo.Cliente", t => new { t.Documento, t.TipoDocumentoID })
                .ForeignKey("dbo.Estado", t => t.EstadoID, cascadeDelete: true)
                .ForeignKey("dbo.Localidad", t => new { t.PaisId, t.ProvinciaID, t.LocalidadID })
                .ForeignKey("dbo.Pais", t => t.PaisId)
                .ForeignKey("dbo.Provincia", t => new { t.PaisId, t.ProvinciaID })
                .ForeignKey("dbo.Usuario", t => t.UsuarioID, cascadeDelete: true)
                .Index(t => new { t.PaisId, t.ProvinciaID, t.LocalidadID })
                .Index(t => t.ClaseDatoID)
                .Index(t => t.EstadoID)
                .Index(t => new { t.Documento, t.TipoDocumentoID })
                .Index(t => t.UsuarioID);
            
            CreateTable(
                "dbo.ClaseDato",
                c => new
                    {
                        ClaseDatoID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.ClaseDatoID);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        UsuarioID = c.Int(nullable: false, identity: true),
                        usuario = c.String(),
                        nombre = c.String(),
                        apellido = c.String(),
                        pass = c.String(),
                        creacion = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioID);
            
            CreateTable(
                "dbo.Perfil",
                c => new
                    {
                        PerfilID = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        descripcion = c.String(),
                        creacion = c.DateTime(nullable: false),
                        activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PerfilID);
            
            CreateTable(
                "dbo.Permiso",
                c => new
                    {
                        PermisoID = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        descripcion = c.String(),
                        creacion = c.DateTime(nullable: false),
                        activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PermisoID);
            
            CreateTable(
                "dbo.Mail",
                c => new
                    {
                        MailID = c.Int(nullable: false, identity: true),
                        Direccion = c.String(),
                        ClaseDatoID = c.Int(nullable: false),
                        EstadoID = c.Int(nullable: false),
                        Documento = c.Int(nullable: false),
                        TipoDocumentoID = c.String(nullable: false, maxLength: 128),
                        EmpresaID = c.Int(),
                        ComercioID = c.Int(),
                        Fecha = c.DateTime(nullable: false),
                        Nota = c.String(),
                        UsuarioID = c.Int(nullable: false),
                        PcComer = c.String(),
                    })
                .PrimaryKey(t => t.MailID)
                .ForeignKey("dbo.ClaseDato", t => t.ClaseDatoID, cascadeDelete: true)
                .ForeignKey("dbo.Estado", t => t.EstadoID, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.UsuarioID, cascadeDelete: true)
                .ForeignKey("dbo.Cliente", t => new { t.Documento, t.TipoDocumentoID })
                .Index(t => t.ClaseDatoID)
                .Index(t => t.EstadoID)
                .Index(t => new { t.Documento, t.TipoDocumentoID })
                .Index(t => t.UsuarioID);
            
            CreateTable(
                "dbo.Nota",
                c => new
                    {
                        NotaID = c.Int(nullable: false, identity: true),
                        EmpresaID = c.Int(nullable: false),
                        Documento = c.Int(),
                        TipoDocumentoID = c.String(maxLength: 128),
                        ComercioID = c.Int(),
                        CreditoID = c.Int(),
                        CuotaID = c.Int(),
                        CobranzaID = c.Int(),
                        Detalle = c.String(),
                        UsuarioID = c.Int(),
                        Fecha = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.NotaID)
                .ForeignKey("dbo.Usuario", t => t.UsuarioID)
                .ForeignKey("dbo.Cliente", t => new { t.Documento, t.TipoDocumentoID })
                .ForeignKey("dbo.Cuota", t => new { t.EmpresaID, t.ComercioID, t.CreditoID, t.CuotaID })
                .ForeignKey("dbo.Cobranza", t => new { t.EmpresaID, t.ComercioID, t.CreditoID, t.CuotaID, t.CobranzaID })
                .ForeignKey("dbo.Credito", t => new { t.EmpresaID, t.ComercioID, t.CreditoID })
                .Index(t => new { t.EmpresaID, t.ComercioID, t.CreditoID, t.CuotaID })
                .Index(t => new { t.EmpresaID, t.ComercioID, t.CreditoID, t.CuotaID, t.CobranzaID })
                .Index(t => new { t.Documento, t.TipoDocumentoID })
                .Index(t => t.UsuarioID);
            
            CreateTable(
                "dbo.Profesion",
                c => new
                    {
                        ProfesionID = c.String(nullable: false, maxLength: 128),
                        Nombre = c.String(),
                        ProfesionPadreID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ProfesionID)
                .ForeignKey("dbo.Profesion", t => t.ProfesionPadreID)
                .Index(t => t.ProfesionPadreID);
            
            CreateTable(
                "dbo.Refinanciacion",
                c => new
                    {
                        EmpresaID = c.Int(nullable: false),
                        ComercioID = c.Int(nullable: false),
                        CreditoID = c.Int(nullable: false),
                        RefinanciacionID = c.Int(nullable: false),
                        Documento = c.Int(nullable: false),
                        TipoDocumentoID = c.String(nullable: false, maxLength: 128),
                        ValorNominal = c.Decimal(nullable: false, precision: 19, scale: 2),
                        ValorCuota = c.Decimal(nullable: false, precision: 19, scale: 2),
                        ValorAdelanto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FechaSolicitud = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Interes = c.Decimal(nullable: false, precision: 19, scale: 2),
                        CantidadCuotas = c.Int(nullable: false),
                        UsuarioID = c.Int(nullable: false),
                        PcComer = c.String(),
                        EstadoID = c.Int(nullable: false),
                        FechaCreacion = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.EmpresaID, t.ComercioID, t.CreditoID, t.RefinanciacionID })
                .ForeignKey("dbo.Comercio", t => new { t.EmpresaID, t.ComercioID })
                .ForeignKey("dbo.Credito", t => new { t.EmpresaID, t.ComercioID, t.CreditoID })
                .ForeignKey("dbo.Empresa", t => t.EmpresaID)
                .ForeignKey("dbo.Estado", t => t.EstadoID, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.UsuarioID)
                .ForeignKey("dbo.Cliente", t => new { t.Documento, t.TipoDocumentoID })
                .Index(t => new { t.EmpresaID, t.ComercioID })
                .Index(t => new { t.EmpresaID, t.ComercioID, t.CreditoID })
                .Index(t => new { t.Documento, t.TipoDocumentoID })
                .Index(t => t.UsuarioID)
                .Index(t => t.EstadoID);
            
            CreateTable(
                "dbo.RefinanciacionCuota",
                c => new
                    {
                        EmpresaID = c.Int(nullable: false),
                        ComercioID = c.Int(nullable: false),
                        CreditoID = c.Int(nullable: false),
                        RefinanciacionID = c.Int(nullable: false),
                        RefinanciacionCuotaID = c.Int(nullable: false),
                        Documento = c.Int(nullable: false),
                        TipoDocumentoID = c.String(nullable: false, maxLength: 128),
                        CantidadCuotas = c.Int(nullable: false),
                        Importe = c.Decimal(nullable: false, precision: 19, scale: 2),
                        ImportePago = c.Decimal(nullable: false, precision: 19, scale: 2),
                        ImportePagoPunitorios = c.Decimal(nullable: false, precision: 19, scale: 2),
                        FechaVencimiento = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        FechaUltimoPago = c.DateTime(precision: 7, storeType: "datetime2"),
                        Deuda = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.EmpresaID, t.ComercioID, t.CreditoID, t.RefinanciacionID, t.RefinanciacionCuotaID })
                .ForeignKey("dbo.Cliente", t => new { t.Documento, t.TipoDocumentoID })
                .ForeignKey("dbo.Comercio", t => new { t.EmpresaID, t.ComercioID })
                .ForeignKey("dbo.Empresa", t => t.EmpresaID)
                .ForeignKey("dbo.Refinanciacion", t => new { t.EmpresaID, t.ComercioID, t.CreditoID, t.RefinanciacionID })
                .Index(t => new { t.EmpresaID, t.ComercioID })
                .Index(t => new { t.EmpresaID, t.ComercioID, t.CreditoID, t.RefinanciacionID })
                .Index(t => new { t.Documento, t.TipoDocumentoID });
            
            CreateTable(
                "dbo.RefinanciacionCobranza",
                c => new
                    {
                        EmpresaID = c.Int(nullable: false),
                        ComercioID = c.Int(nullable: false),
                        CreditoID = c.Int(nullable: false),
                        RefinanciacionID = c.Int(nullable: false),
                        RefinanciacionCuotaID = c.Int(nullable: false),
                        RefinanciacionCobranzaID = c.Int(nullable: false),
                        Documento = c.Int(nullable: false),
                        TipoDocumentoID = c.String(nullable: false, maxLength: 128),
                        ImportePago = c.Decimal(nullable: false, precision: 19, scale: 2),
                        ImportePagoPunitorios = c.Decimal(nullable: false, precision: 19, scale: 2),
                        PunitoriosCalc = c.Decimal(nullable: false, precision: 19, scale: 2),
                        FechaPago = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        FechaVencimiento = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        TipoPagoID = c.String(maxLength: 128),
                        PagoRev = c.Boolean(nullable: false),
                        FechaRev = c.DateTime(precision: 7, storeType: "datetime2"),
                        RefinanciacionCobranzaIDRev = c.Int(),
                        GestionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EmpresaID, t.ComercioID, t.CreditoID, t.RefinanciacionID, t.RefinanciacionCuotaID, t.RefinanciacionCobranzaID })
                .ForeignKey("dbo.Cliente", t => new { t.Documento, t.TipoDocumentoID })
                .ForeignKey("dbo.Comercio", t => new { t.EmpresaID, t.ComercioID })
                .ForeignKey("dbo.Empresa", t => t.EmpresaID)
                .ForeignKey("dbo.Refinanciacion", t => new { t.EmpresaID, t.ComercioID, t.CreditoID, t.RefinanciacionID })
                .ForeignKey("dbo.RefinanciacionCuota", t => new { t.EmpresaID, t.ComercioID, t.CreditoID, t.RefinanciacionID, t.RefinanciacionCuotaID })
                .ForeignKey("dbo.TipoPago", t => t.TipoPagoID)
                .Index(t => new { t.EmpresaID, t.ComercioID })
                .Index(t => new { t.EmpresaID, t.ComercioID, t.CreditoID, t.RefinanciacionID })
                .Index(t => new { t.EmpresaID, t.ComercioID, t.CreditoID, t.RefinanciacionID, t.RefinanciacionCuotaID })
                .Index(t => new { t.Documento, t.TipoDocumentoID })
                .Index(t => t.TipoPagoID);
            
            CreateTable(
                "dbo.TipoPago",
                c => new
                    {
                        TipoPagoID = c.String(nullable: false, maxLength: 128),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.TipoPagoID);
            
            CreateTable(
                "dbo.Sexo",
                c => new
                    {
                        SexoID = c.String(nullable: false, maxLength: 128),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.SexoID);
            
            CreateTable(
                "dbo.Telefono",
                c => new
                    {
                        TelefonoID = c.Int(nullable: false, identity: true),
                        CodArea = c.String(),
                        Numero = c.String(),
                        esCelular = c.Boolean(),
                        EstadoID = c.Int(nullable: false),
                        ClaseDatoID = c.Int(nullable: false),
                        Documento = c.Int(nullable: false),
                        TipoDocumentoID = c.String(maxLength: 128),
                        EmpresaID = c.Int(),
                        ComercioID = c.Int(),
                        Fecha = c.DateTime(nullable: false),
                        Nota = c.String(),
                        UsuarioID = c.Int(),
                        PcComer = c.String(),
                        TelefonoCompleto = c.String(),
                    })
                .PrimaryKey(t => t.TelefonoID)
                .ForeignKey("dbo.ClaseDato", t => t.ClaseDatoID, cascadeDelete: true)
                .ForeignKey("dbo.Cliente", t => new { t.Documento, t.TipoDocumentoID })
                .ForeignKey("dbo.Estado", t => t.EstadoID, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.UsuarioID)
                .Index(t => t.EstadoID)
                .Index(t => t.ClaseDatoID)
                .Index(t => new { t.Documento, t.TipoDocumentoID })
                .Index(t => t.UsuarioID);
            
            CreateTable(
                "dbo.TipoComoConocio",
                c => new
                    {
                        TipoComoConocioID = c.String(nullable: false, maxLength: 128),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.TipoComoConocioID);
            
            CreateTable(
                "dbo.Cobranza",
                c => new
                    {
                        EmpresaID = c.Int(nullable: false),
                        ComercioID = c.Int(nullable: false),
                        CreditoID = c.Int(nullable: false),
                        CuotaID = c.Int(nullable: false),
                        CobranzaID = c.Int(nullable: false),
                        Documento = c.Int(nullable: false),
                        TipoDocumentoID = c.String(nullable: false, maxLength: 128),
                        ImportePago = c.Decimal(nullable: false, precision: 19, scale: 2),
                        ImportePagoPunitorios = c.Decimal(nullable: false, precision: 19, scale: 2),
                        Interes = c.Decimal(nullable: false, precision: 19, scale: 2),
                        PunitoriosCalc = c.Decimal(precision: 19, scale: 2),
                        FechaPago = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        FechaVencimiento = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        TipoPagoID = c.String(maxLength: 128),
                        TipoBonificacionID = c.String(maxLength: 128),
                        PorcentajeBonificacion = c.Decimal(precision: 19, scale: 2),
                        PagoRev = c.Boolean(nullable: false),
                        FechaRev = c.DateTime(precision: 7, storeType: "datetime2"),
                        CobranzaIDRev = c.Int(),
                        Motivo = c.String(maxLength: 100),
                        GestionEmpresaID = c.Int(nullable: false),
                        GestionID = c.Int(nullable: false),
                        RefinanciacionCobranzaID = c.Int(nullable: false),
                        UsuarioID = c.Int(nullable: false),
                        PcComer = c.String(),
                        ImporteTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImporteCapital = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.EmpresaID, t.ComercioID, t.CreditoID, t.CuotaID, t.CobranzaID })
                .ForeignKey("dbo.Cliente", t => new { t.Documento, t.TipoDocumentoID })
                .ForeignKey("dbo.Comercio", t => new { t.EmpresaID, t.ComercioID })
                .ForeignKey("dbo.Credito", t => new { t.EmpresaID, t.ComercioID, t.CreditoID })
                .ForeignKey("dbo.Cuota", t => new { t.EmpresaID, t.ComercioID, t.CreditoID, t.CuotaID })
                .ForeignKey("dbo.Empresa", t => t.EmpresaID)
                .ForeignKey("dbo.TipoBonificacion", t => t.TipoBonificacionID)
                .ForeignKey("dbo.TipoPago", t => t.TipoPagoID)
                .ForeignKey("dbo.Usuario", t => t.UsuarioID, cascadeDelete: true)
                .Index(t => new { t.EmpresaID, t.ComercioID })
                .Index(t => new { t.EmpresaID, t.ComercioID, t.CreditoID })
                .Index(t => new { t.EmpresaID, t.ComercioID, t.CreditoID, t.CuotaID })
                .Index(t => new { t.Documento, t.TipoDocumentoID })
                .Index(t => t.TipoPagoID)
                .Index(t => t.TipoBonificacionID)
                .Index(t => t.UsuarioID);
            
            CreateTable(
                "dbo.Cuota",
                c => new
                    {
                        EmpresaID = c.Int(nullable: false),
                        ComercioID = c.Int(nullable: false),
                        CreditoID = c.Int(nullable: false),
                        CuotaID = c.Int(nullable: false),
                        Documento = c.Int(nullable: false),
                        TipoDocumentoID = c.String(nullable: false, maxLength: 128),
                        Importe = c.Decimal(nullable: false, precision: 19, scale: 2),
                        Interes = c.Decimal(nullable: false, precision: 19, scale: 2),
                        ImportePago = c.Decimal(nullable: false, precision: 19, scale: 2),
                        ImportePagoPunitorios = c.Decimal(nullable: false, precision: 19, scale: 2),
                        FechaVencimiento = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        FechaUltimoPago = c.DateTime(precision: 7, storeType: "datetime2"),
                        TipoCuotaID = c.String(maxLength: 128),
                        CantidadCuotas = c.Int(nullable: false),
                        ValorBonificacion = c.Decimal(nullable: false, precision: 19, scale: 2),
                        Deuda = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.EmpresaID, t.ComercioID, t.CreditoID, t.CuotaID })
                .ForeignKey("dbo.Cliente", t => new { t.Documento, t.TipoDocumentoID })
                .ForeignKey("dbo.Comercio", t => new { t.EmpresaID, t.ComercioID })
                .ForeignKey("dbo.Credito", t => new { t.EmpresaID, t.ComercioID, t.CreditoID })
                .ForeignKey("dbo.Empresa", t => t.EmpresaID)
                .ForeignKey("dbo.TipoCuota", t => t.TipoCuotaID)
                .Index(t => new { t.EmpresaID, t.ComercioID })
                .Index(t => new { t.EmpresaID, t.ComercioID, t.CreditoID })
                .Index(t => new { t.Documento, t.TipoDocumentoID })
                .Index(t => t.TipoCuotaID);
            
            CreateTable(
                "dbo.TipoCuota",
                c => new
                    {
                        TipoCuotaID = c.String(nullable: false, maxLength: 128),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.TipoCuotaID);
            
            CreateTable(
                "dbo.NotasCD",
                c => new
                    {
                        EmpresaID = c.Int(nullable: false),
                        ComercioID = c.Int(nullable: false),
                        CreditoID = c.Int(nullable: false),
                        CuotaID = c.Int(nullable: false),
                        CobranzaID = c.Int(nullable: false),
                        NotaCDID = c.Int(nullable: false),
                        TipoNota = c.String(),
                        Importe = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fecha = c.DateTime(nullable: false),
                        Documento = c.Int(nullable: false),
                        TipoDocumentoID = c.String(),
                        Detalle = c.String(),
                        GestionID = c.Int(nullable: false),
                        UsuarioID = c.Int(nullable: false),
                        PcComer = c.String(),
                        Notas = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => new { t.EmpresaID, t.ComercioID, t.CreditoID, t.CuotaID, t.CobranzaID, t.NotaCDID })
                .ForeignKey("dbo.Usuario", t => t.UsuarioID, cascadeDelete: true)
                .ForeignKey("dbo.Cobranza", t => new { t.EmpresaID, t.ComercioID, t.CreditoID, t.CuotaID, t.CobranzaID })
                .Index(t => new { t.EmpresaID, t.ComercioID, t.CreditoID, t.CuotaID, t.CobranzaID })
                .Index(t => t.UsuarioID);
            
            CreateTable(
                "dbo.TipoBonificacion",
                c => new
                    {
                        TipoBonificacionID = c.String(nullable: false, maxLength: 128),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.TipoBonificacionID);
            
            CreateTable(
                "dbo.CreditoAval",
                c => new
                    {
                        CreditoAvalID = c.Int(nullable: false, identity: true),
                        CreditoID = c.Int(nullable: false),
                        ComercioID = c.Int(nullable: false),
                        EmpresaID = c.Int(nullable: false),
                        TipoAvalID = c.Int(nullable: false),
                        UsuarioID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CreditoAvalID)
                .ForeignKey("dbo.Comercio", t => new { t.EmpresaID, t.ComercioID }, cascadeDelete: true)
                .ForeignKey("dbo.Credito", t => new { t.EmpresaID, t.ComercioID, t.CreditoID }, cascadeDelete: true)
                .ForeignKey("dbo.Empresa", t => t.EmpresaID, cascadeDelete: true)
                .ForeignKey("dbo.TipoAval", t => t.TipoAvalID, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.UsuarioID, cascadeDelete: true)
                .Index(t => new { t.EmpresaID, t.ComercioID, t.CreditoID })
                .Index(t => new { t.EmpresaID, t.ComercioID })
                .Index(t => t.TipoAvalID)
                .Index(t => t.UsuarioID);
            
            CreateTable(
                "dbo.TipoAval",
                c => new
                    {
                        TipoAvalID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.TipoAvalID);
            
            CreateTable(
                "dbo.Cargo",
                c => new
                    {
                        CargoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        SueldoBasico = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.CargoId);
            
            CreateTable(
                "dbo.ClaseMovimiento",
                c => new
                    {
                        ClaseMovimientoID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ClaseMovimientoID);
            
            CreateTable(
                "dbo.ConceptoFondos",
                c => new
                    {
                        ConceptoFondosID = c.Int(nullable: false),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        MedioDePagoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ConceptoFondosID)
                .ForeignKey("dbo.MedioDePago", t => t.MedioDePagoID, cascadeDelete: true)
                .Index(t => t.MedioDePagoID);
            
            CreateTable(
                "dbo.MedioDePago",
                c => new
                    {
                        MedioDePagoID = c.Int(nullable: false),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.MedioDePagoID);
            
            CreateTable(
                "dbo.Departamento",
                c => new
                    {
                        DepartamentoID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        ConceptoFondos_ConceptoFondosID = c.Int(),
                    })
                .PrimaryKey(t => t.DepartamentoID)
                .ForeignKey("dbo.ConceptoFondos", t => t.ConceptoFondos_ConceptoFondosID)
                .Index(t => t.ConceptoFondos_ConceptoFondosID);
            
            CreateTable(
                "dbo.ConceptoGastosDepartamento",
                c => new
                    {
                        ConceptoGastosDepartamentoID = c.Int(nullable: false, identity: true),
                        ConceptoGastosID = c.Int(),
                        DepartamentoID = c.Int(),
                        presupuesto = c.Int(nullable: false),
                        EstadoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ConceptoGastosDepartamentoID)
                .ForeignKey("dbo.ConceptoGastos", t => t.ConceptoGastosID)
                .ForeignKey("dbo.Departamento", t => t.DepartamentoID)
                .ForeignKey("dbo.Estado", t => t.EstadoID, cascadeDelete: true)
                .Index(t => t.ConceptoGastosID)
                .Index(t => t.DepartamentoID)
                .Index(t => t.EstadoID);
            
            CreateTable(
                "dbo.CuentaCorrienteCorte",
                c => new
                    {
                        EmpresaID = c.Int(nullable: false),
                        ComercioID = c.Int(nullable: false),
                        CuentaCorrienteCorteID = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        Saldo = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.EmpresaID, t.ComercioID, t.CuentaCorrienteCorteID });
            
            CreateTable(
                "dbo.CreditoAnulado",
                c => new
                    {
                        EmpresaID = c.Int(nullable: false),
                        ComercioID = c.Int(nullable: false),
                        CreditoAnuladoID = c.Int(nullable: false, identity: true),
                        CreditoID = c.Int(nullable: false),
                        Documento = c.Int(nullable: false),
                        TipoDocumentoID = c.String(nullable: false, maxLength: 128),
                        ValorNominal = c.Decimal(nullable: false, precision: 19, scale: 2),
                        ValorCuota = c.Decimal(nullable: false, precision: 19, scale: 2),
                        FechaSolicitud = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Interes = c.Decimal(nullable: false, precision: 19, scale: 2),
                        Gasto = c.Decimal(nullable: false, precision: 19, scale: 2),
                        Comision = c.Decimal(nullable: false, precision: 19, scale: 2),
                        Garante1 = c.Int(),
                        TipoDocumentoIDG1 = c.String(),
                        Garante2 = c.Int(),
                        TipoDocumentoIDG2 = c.String(),
                        Garante3 = c.Int(),
                        TipoDocumentoIDG3 = c.String(),
                        Adicional = c.Int(),
                        TipoDocumentoIDAdi = c.String(),
                        Avalado = c.Boolean(nullable: false),
                        usuarioAvalID = c.Int(),
                        TipoCuotaID = c.String(),
                        CantidadCuotas = c.Int(nullable: false),
                        NroInformeContel = c.Int(),
                        AbogadoID = c.Int(),
                        FechaAbogado = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UsuarioID = c.Int(nullable: false),
                        PcComer = c.String(),
                        FechaComer = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        TipoBonificacionID = c.String(),
                        PorcentajeBonificacion = c.Decimal(precision: 19, scale: 2),
                        ValorBonificacion = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TasaPlan = c.Decimal(nullable: false, precision: 19, scale: 2),
                        IncrementoPlan = c.Decimal(nullable: false, precision: 19, scale: 2),
                        GastoPlan = c.Decimal(nullable: false, precision: 19, scale: 2),
                        GastoIncrementoPlan = c.Decimal(nullable: false, precision: 19, scale: 2),
                        GastoFijo = c.Boolean(nullable: false),
                        ComisionPlan = c.Decimal(nullable: false, precision: 19, scale: 2),
                        ComisionIncrementoPlan = c.Decimal(nullable: false, precision: 19, scale: 2),
                        TipoRetencionPlanID = c.String(),
                        NombrePlan = c.String(maxLength: 50),
                        Puntaje = c.Decimal(precision: 18, scale: 2),
                        DiasVenciPrimerCuota = c.Int(nullable: false),
                        RefinanciacionID = c.Int(),
                        UsuarioIDAnula = c.Int(nullable: false),
                        PcComerAnula = c.String(),
                        FechaComercioAnula = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Motivo = c.String(maxLength: 250),
                        TipoAnulacionID = c.String(maxLength: 2),
                        AvisoDePagoID = c.Int(),
                        Corte = c.Int(nullable: false),
                        FechaAviso = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => new { t.EmpresaID, t.ComercioID, t.CreditoAnuladoID })
                .ForeignKey("dbo.Cliente", t => new { t.Documento, t.TipoDocumentoID })
                .ForeignKey("dbo.Comercio", t => new { t.EmpresaID, t.ComercioID })
                .ForeignKey("dbo.Empresa", t => t.EmpresaID)
                .ForeignKey("dbo.TipoAnulacion", t => t.TipoAnulacionID)
                .ForeignKey("dbo.Usuario", t => t.UsuarioID)
                .Index(t => new { t.EmpresaID, t.ComercioID })
                .Index(t => new { t.Documento, t.TipoDocumentoID })
                .Index(t => t.UsuarioID)
                .Index(t => t.TipoAnulacionID);
            
            CreateTable(
                "dbo.TipoAnulacion",
                c => new
                    {
                        TipoAnulacionID = c.String(nullable: false, maxLength: 2),
                        Descripcion = c.String(),
                        QueAnula = c.String(),
                    })
                .PrimaryKey(t => t.TipoAnulacionID);
            
            CreateTable(
                "dbo.CuentaCorriente",
                c => new
                    {
                        EmpresaID = c.Int(nullable: false),
                        ComercioID = c.Int(nullable: false),
                        CuentaCorrienteID = c.Long(nullable: false, identity: true),
                        IDRemoto = c.Long(),
                        TipoMovimientoID = c.Int(),
                        Fecha = c.DateTime(nullable: false),
                        SolicitudFondoID = c.Long(),
                        CreditoID = c.Int(),
                        CuotaID = c.Int(),
                        CobranzaID = c.Int(),
                        NotaCDID = c.Int(),
                        TransferenciaDepositoID = c.Long(),
                        ReciboID = c.Int(),
                        Importe = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GestionID = c.Int(),
                        FechaAviso = c.DateTime(),
                        CreditoNro = c.Int(),
                    })
                .PrimaryKey(t => new { t.EmpresaID, t.ComercioID, t.CuentaCorrienteID })
                .ForeignKey("dbo.Cobranza", t => new { t.EmpresaID, t.ComercioID, t.CreditoID, t.CuotaID, t.CobranzaID })
                .ForeignKey("dbo.Comercio", t => new { t.EmpresaID, t.ComercioID }, cascadeDelete: true)
                .ForeignKey("dbo.Credito", t => new { t.EmpresaID, t.ComercioID, t.CreditoID })
                .ForeignKey("dbo.Cuota", t => new { t.EmpresaID, t.ComercioID, t.CreditoID, t.CuotaID })
                .ForeignKey("dbo.Empresa", t => t.EmpresaID, cascadeDelete: true)
                .ForeignKey("dbo.NotasCD", t => new { t.EmpresaID, t.ComercioID, t.CreditoID, t.CuotaID, t.CobranzaID, t.NotaCDID })
                .ForeignKey("dbo.Recibo", t => new { t.EmpresaID, t.ComercioID, t.ReciboID })
                .ForeignKey("dbo.SolicitudFondo", t => new { t.EmpresaID, t.ComercioID, t.SolicitudFondoID })
                .ForeignKey("dbo.TipoMovimiento", t => t.TipoMovimientoID)
                .ForeignKey("dbo.TransferenciasDepositos", t => new { t.EmpresaID, t.TransferenciaDepositoID })
                .Index(t => new { t.EmpresaID, t.ComercioID, t.CreditoID, t.CuotaID, t.CobranzaID })
                .Index(t => new { t.EmpresaID, t.ComercioID, t.CreditoID, t.CuotaID, t.CobranzaID, t.NotaCDID })
                .Index(t => new { t.EmpresaID, t.ComercioID, t.ReciboID })
                .Index(t => new { t.EmpresaID, t.ComercioID, t.SolicitudFondoID })
                .Index(t => new { t.EmpresaID, t.TransferenciaDepositoID })
                .Index(t => t.TipoMovimientoID);
            
            CreateTable(
                "dbo.Recibo",
                c => new
                    {
                        EmpresaID = c.Int(nullable: false),
                        ComercioID = c.Int(nullable: false),
                        ReciboID = c.Int(nullable: false, identity: true),
                        ReciboIDRemoto = c.Int(),
                        Fecha = c.DateTime(precision: 7, storeType: "datetime2"),
                        FechaIngreso = c.DateTime(precision: 7, storeType: "datetime2"),
                        Importe = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Comprobante = c.Int(nullable: false),
                        Notas = c.String(),
                        TipoMovimientoID = c.Int(nullable: false),
                        TransferenciasDepositosEmpId = c.Int(),
                        TransferenciasDepositosID = c.Long(),
                        SolicitudFondoID = c.Long(),
                        Imputado = c.Decimal(precision: 18, scale: 2),
                        Migrado = c.Boolean(),
                        Conformado = c.Boolean(),
                        Host = c.String(),
                        UsuarioID = c.Int(nullable: false),
                        EstadoID = c.Int(nullable: false),
                        ComercioAdheridoComercioID = c.Int(),
                        ComercioAdheridoEmpresaID = c.Int(),
                        ReciboIDAnula = c.Int(),
                        CobranzaID = c.Int(),
                    })
                .PrimaryKey(t => new { t.EmpresaID, t.ComercioID, t.ReciboID })
                .ForeignKey("dbo.Comercio", t => new { t.EmpresaID, t.ComercioID })
                .ForeignKey("dbo.Comercio", t => new { t.ComercioAdheridoEmpresaID, t.ComercioAdheridoComercioID })
                .ForeignKey("dbo.Empresa", t => t.EmpresaID)
                .ForeignKey("dbo.Estado", t => t.EstadoID, cascadeDelete: true)
                .ForeignKey("dbo.SolicitudFondo", t => new { t.EmpresaID, t.ComercioID, t.SolicitudFondoID })
                .ForeignKey("dbo.TipoMovimiento", t => t.TipoMovimientoID, cascadeDelete: true)
                .ForeignKey("dbo.TransferenciasDepositos", t => new { t.EmpresaID, t.TransferenciasDepositosID })
                .ForeignKey("dbo.Usuario", t => t.UsuarioID, cascadeDelete: true)
                .Index(t => new { t.EmpresaID, t.ComercioID })
                .Index(t => new { t.EmpresaID, t.ComercioID, t.SolicitudFondoID })
                .Index(t => new { t.EmpresaID, t.TransferenciasDepositosID })
                .Index(t => t.TipoMovimientoID)
                .Index(t => t.UsuarioID)
                .Index(t => t.EstadoID)
                .Index(t => new { t.ComercioAdheridoEmpresaID, t.ComercioAdheridoComercioID });
            
            CreateTable(
                "dbo.SolicitudFondo",
                c => new
                    {
                        EmpresaID = c.Int(nullable: false),
                        ComercioID = c.Int(nullable: false),
                        SolicitudFondoID = c.Long(nullable: false, identity: true),
                        SolicitudFondoIDRemoto = c.Long(),
                        FechaPago = c.DateTime(precision: 7, storeType: "datetime2"),
                        FechaPagoSF = c.String(),
                        FechaRealizacion = c.DateTime(precision: 7, storeType: "datetime2"),
                        Importe = c.Decimal(precision: 18, scale: 2),
                        Motivo = c.String(),
                        LiquidacionID = c.Int(),
                        FechaDispComienzo = c.DateTime(precision: 7, storeType: "datetime2"),
                        FechaDispFinal = c.DateTime(precision: 7, storeType: "datetime2"),
                        GeneradoPorComercioID = c.Int(),
                        GeneradoPorDepartamentoID = c.Int(),
                        MedioDePagoID = c.Int(),
                        ConceptoFondosID = c.Int(),
                        TransferenciasDepositosEmpId = c.Int(),
                        TransferenciasDepositosID = c.Long(),
                        ClaseCuentaBancariaID = c.Int(),
                        CuentaBancariaID = c.Int(),
                        NumChequera = c.String(maxLength: 128),
                        NumCheque = c.String(maxLength: 128),
                        EstadoID = c.Int(),
                        MonedaID = c.Int(),
                        OrdenDePago = c.Int(),
                        TipoSolicitudID = c.Int(),
                        FechaConfComercio = c.DateTime(precision: 7, storeType: "datetime2"),
                        EmpleadoConfComercio = c.Int(),
                        notas = c.String(),
                        EmpleadoSolicitanteID = c.Int(),
                        EmpleadoRealizadorID = c.Int(),
                        CajaID = c.Int(),
                        AvisoDePagoID = c.Int(),
                    })
                .PrimaryKey(t => new { t.EmpresaID, t.ComercioID, t.SolicitudFondoID })
                .ForeignKey("dbo.AvisoDePago", t => new { t.EmpresaID, t.ComercioID, t.AvisoDePagoID })
                .ForeignKey("dbo.Cheque", t => new { t.EmpresaID, t.CuentaBancariaID, t.NumChequera, t.NumCheque })
                .ForeignKey("dbo.Comercio", t => new { t.EmpresaID, t.ComercioID })
                .ForeignKey("dbo.ConceptoFondos", t => t.ConceptoFondosID)
                .ForeignKey("dbo.Empleado", t => t.EmpleadoRealizadorID)
                .ForeignKey("dbo.Empleado", t => t.EmpleadoSolicitanteID)
                .ForeignKey("dbo.Empresa", t => t.EmpresaID)
                .ForeignKey("dbo.Estado", t => t.EstadoID)
                .ForeignKey("dbo.Departamento", t => t.GeneradoPorDepartamentoID)
                .ForeignKey("dbo.MedioDePago", t => t.MedioDePagoID)
                .ForeignKey("dbo.Moneda", t => t.MonedaID)
                .ForeignKey("dbo.TipoSolicitud", t => t.TipoSolicitudID)
                .ForeignKey("dbo.TransferenciasDepositos", t => new { t.EmpresaID, t.TransferenciasDepositosID })
                .Index(t => new { t.EmpresaID, t.ComercioID, t.AvisoDePagoID })
                .Index(t => new { t.EmpresaID, t.CuentaBancariaID, t.NumChequera, t.NumCheque })
                .Index(t => new { t.EmpresaID, t.TransferenciasDepositosID })
                .Index(t => t.GeneradoPorDepartamentoID)
                .Index(t => t.MedioDePagoID)
                .Index(t => t.ConceptoFondosID)
                .Index(t => t.EstadoID)
                .Index(t => t.MonedaID)
                .Index(t => t.TipoSolicitudID)
                .Index(t => t.EmpleadoSolicitanteID)
                .Index(t => t.EmpleadoRealizadorID);
            
            CreateTable(
                "dbo.Empleado",
                c => new
                    {
                        EmpleadoID = c.Int(nullable: false, identity: true),
                        Legajo = c.String(),
                        Usuarioid = c.Int(),
                        Domicilio = c.String(),
                        Sueldo = c.Decimal(precision: 18, scale: 2),
                        Fotografia = c.String(),
                        Mail = c.String(),
                        Tel = c.String(),
                        DepartamentoID = c.Int(),
                        EmpresaID = c.Int(),
                        ComercioID = c.Int(),
                        CargoID = c.Int(),
                        EstadoId = c.Int(),
                        PersonaID = c.Int(),
                        TipoEmpleadoID = c.Int(),
                    })
                .PrimaryKey(t => t.EmpleadoID)
                .ForeignKey("dbo.Cargo", t => t.CargoID)
                .ForeignKey("dbo.Comercio", t => new { t.EmpresaID, t.ComercioID })
                .ForeignKey("dbo.Departamento", t => t.DepartamentoID)
                .ForeignKey("dbo.Empresa", t => t.EmpresaID)
                .ForeignKey("dbo.Estado", t => t.EstadoId)
                .ForeignKey("dbo.Persona", t => t.PersonaID)
                .ForeignKey("dbo.TipoEmpleado", t => t.TipoEmpleadoID)
                .ForeignKey("dbo.Usuario", t => t.Usuarioid)
                .Index(t => t.Usuarioid)
                .Index(t => t.DepartamentoID)
                .Index(t => new { t.EmpresaID, t.ComercioID })
                .Index(t => t.CargoID)
                .Index(t => t.EstadoId)
                .Index(t => t.PersonaID)
                .Index(t => t.TipoEmpleadoID);
            
            CreateTable(
                "dbo.TipoEmpleado",
                c => new
                    {
                        TipoEmpleadoID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.TipoEmpleadoID);
            
            CreateTable(
                "dbo.SolicitudFondoConceptoGastosProveedor",
                c => new
                    {
                        EmpresaID = c.Int(nullable: false),
                        ComercioID = c.Int(nullable: false),
                        SolicitudFondoID = c.Long(nullable: false),
                        ConceptoGastosProveedorID = c.Int(nullable: false),
                        Importe = c.Decimal(precision: 18, scale: 2),
                        Detalle = c.String(),
                        sConceptoGastosProveedor = c.String(),
                    })
                .PrimaryKey(t => new { t.EmpresaID, t.ComercioID, t.SolicitudFondoID, t.ConceptoGastosProveedorID })
                .ForeignKey("dbo.Comercio", t => new { t.EmpresaID, t.ComercioID }, cascadeDelete: true)
                .ForeignKey("dbo.ConceptoGastosProveedor", t => t.ConceptoGastosProveedorID, cascadeDelete: true)
                .ForeignKey("dbo.Empresa", t => t.EmpresaID, cascadeDelete: true)
                .ForeignKey("dbo.SolicitudFondo", t => new { t.EmpresaID, t.ComercioID, t.SolicitudFondoID }, cascadeDelete: true)
                .Index(t => new { t.EmpresaID, t.ComercioID })
                .Index(t => new { t.EmpresaID, t.ComercioID, t.SolicitudFondoID })
                .Index(t => t.ConceptoGastosProveedorID);
            
            CreateTable(
                "dbo.TipoSolicitud",
                c => new
                    {
                        TipoSolicitudID = c.Int(nullable: false),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.TipoSolicitudID);
            
            CreateTable(
                "dbo.TransferenciasDepositos",
                c => new
                    {
                        EmpresaID = c.Int(nullable: false),
                        TransferenciasDepositosID = c.Long(nullable: false, identity: true),
                        TransferenciasDepositosIDRemoto = c.Long(),
                        NumTransferencia = c.String(),
                        Importe = c.Decimal(precision: 18, scale: 2),
                        Fecha = c.DateTime(precision: 7, storeType: "datetime2"),
                        Costo = c.Decimal(precision: 18, scale: 2),
                        Notas = c.String(),
                        CuentaOrigenEmpresaID = c.Int(),
                        CuentaOrigenCbID = c.Int(),
                        CuentaDestinoEmpresaID = c.Int(),
                        CuentaDestinoCbID = c.Int(),
                        ChequeEmpID = c.Int(),
                        ChequeCbID = c.Int(),
                        ChequeNumChequera = c.String(maxLength: 128),
                        ChequeNumCheque = c.String(maxLength: 128),
                        MedioDePagoID = c.Int(),
                        MonedaID = c.Int(),
                        EmpleadoRegistradorEmpresaID = c.Int(),
                        EmpleadoRegistradorPersonaID = c.Int(),
                        ComercioEmpresaID = c.Int(),
                        ComercioID = c.Int(),
                        PersonaId = c.Int(),
                        ProveedorSucursalID = c.Int(),
                        ProveedorID = c.Int(),
                        Host = c.String(),
                        UsuarioID = c.Int(nullable: false),
                        TipoTransferenciaDepositoID = c.Int(),
                        EstadoID = c.Int(nullable: false),
                        ComercioEmpresa_EmpresaID = c.Int(),
                        EmpleadoRegistrador_EmpleadoID = c.Int(),
                    })
                .PrimaryKey(t => new { t.EmpresaID, t.TransferenciasDepositosID })
                .ForeignKey("dbo.Cheque", t => new { t.ChequeEmpID, t.ChequeCbID, t.ChequeNumChequera, t.ChequeNumCheque })
                .ForeignKey("dbo.Comercio", t => new { t.EmpresaID, t.ComercioID })
                .ForeignKey("dbo.Empresa", t => t.ComercioEmpresa_EmpresaID)
                .ForeignKey("dbo.CuentaBancaria", t => new { t.CuentaDestinoEmpresaID, t.CuentaDestinoCbID })
                .ForeignKey("dbo.CuentaBancaria", t => new { t.CuentaOrigenEmpresaID, t.CuentaOrigenCbID })
                .ForeignKey("dbo.Empleado", t => t.EmpleadoRegistrador_EmpleadoID)
                .ForeignKey("dbo.Empresa", t => t.EmpresaID)
                .ForeignKey("dbo.Estado", t => t.EstadoID, cascadeDelete: true)
                .ForeignKey("dbo.MedioDePago", t => t.MedioDePagoID)
                .ForeignKey("dbo.Moneda", t => t.MonedaID)
                .ForeignKey("dbo.Persona", t => t.PersonaId)
                .ForeignKey("dbo.ProveedorSucursal", t => t.ProveedorSucursalID)
                .ForeignKey("dbo.TipoTransferenciaDeposito", t => t.TipoTransferenciaDepositoID)
                .ForeignKey("dbo.Usuario", t => t.UsuarioID)
                .Index(t => new { t.EmpresaID, t.ComercioID })
                .Index(t => new { t.CuentaOrigenEmpresaID, t.CuentaOrigenCbID })
                .Index(t => new { t.CuentaDestinoEmpresaID, t.CuentaDestinoCbID })
                .Index(t => new { t.ChequeEmpID, t.ChequeCbID, t.ChequeNumChequera, t.ChequeNumCheque })
                .Index(t => t.MedioDePagoID)
                .Index(t => t.MonedaID)
                .Index(t => t.PersonaId)
                .Index(t => t.ProveedorSucursalID)
                .Index(t => t.UsuarioID)
                .Index(t => t.TipoTransferenciaDepositoID)
                .Index(t => t.EstadoID)
                .Index(t => t.ComercioEmpresa_EmpresaID)
                .Index(t => t.EmpleadoRegistrador_EmpleadoID);
            
            CreateTable(
                "dbo.TipoTransferenciaDeposito",
                c => new
                    {
                        TipoTransferenciaDepositoID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.TipoTransferenciaDepositoID);
            
            CreateTable(
                "dbo.TipoMovimiento",
                c => new
                    {
                        TipoMovimientoID = c.Int(nullable: false),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        Cod = c.String(),
                        ClaseMovimientoID = c.Int(nullable: false),
                        CodInter = c.String(),
                        TipoMovIDAnula = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TipoMovimientoID)
                .ForeignKey("dbo.ClaseMovimiento", t => t.ClaseMovimientoID, cascadeDelete: true)
                .Index(t => t.ClaseMovimientoID);
            
            CreateTable(
                "dbo.EstadoTransmision",
                c => new
                    {
                        EstadoTransmisionID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.EstadoTransmisionID);
            
            CreateTable(
                "dbo.Operacion",
                c => new
                    {
                        OperacionID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.OperacionID);
            
            CreateTable(
                "dbo.OrdenDePago",
                c => new
                    {
                        OrdenDePagoID = c.Int(nullable: false, identity: true),
                        EmpresaID = c.Int(),
                        Fecha = c.DateTime(nullable: false),
                        fecha_pago = c.DateTime(nullable: false),
                        importe = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EstadoID = c.Int(),
                        ConceptoFondosID = c.Int(),
                    })
                .PrimaryKey(t => t.OrdenDePagoID)
                .ForeignKey("dbo.ConceptoFondos", t => t.ConceptoFondosID)
                .ForeignKey("dbo.Empresa", t => t.EmpresaID)
                .ForeignKey("dbo.Estado", t => t.EstadoID)
                .Index(t => t.EmpresaID)
                .Index(t => t.EstadoID)
                .Index(t => t.ConceptoFondosID);
            
            CreateTable(
                "dbo.TipoImagen",
                c => new
                    {
                        TipoImagenID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Sufijo = c.String(),
                        Orden = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TipoImagenID);
            
            CreateTable(
                "dbo.TipoImpresion",
                c => new
                    {
                        TipoImpresionID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Impresora = c.String(),
                    })
                .PrimaryKey(t => t.TipoImpresionID);
            
            CreateTable(
                "dbo.TipoRetencionPlan",
                c => new
                    {
                        TipoRetencionPlanID = c.String(nullable: false, maxLength: 128),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.TipoRetencionPlanID);
            
            CreateTable(
                "dbo.Transmision",
                c => new
                    {
                        TransmisionID = c.Long(nullable: false, identity: true),
                        OperacionID = c.Int(nullable: false),
                        EstadoTransmisionID = c.Int(nullable: false),
                        EmpresaID = c.Int(nullable: false),
                        ComercioID = c.Int(nullable: false),
                        EntidadID = c.String(),
                        EntidadID2 = c.String(),
                        EntidadID3 = c.String(),
                        EntidadID4 = c.String(),
                        EntidadID5 = c.String(),
                        EntidadID6 = c.String(),
                        EntidadID7 = c.String(),
                        Fecha = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        RutaApi = c.String(),
                        GrupoTransmision = c.Int(),
                    })
                .PrimaryKey(t => t.TransmisionID)
                .ForeignKey("dbo.Comercio", t => new { t.EmpresaID, t.ComercioID }, cascadeDelete: true)
                .ForeignKey("dbo.Empresa", t => t.EmpresaID, cascadeDelete: true)
                .ForeignKey("dbo.EstadoTransmision", t => t.EstadoTransmisionID, cascadeDelete: true)
                .ForeignKey("dbo.Operacion", t => t.OperacionID)
                .Index(t => t.OperacionID)
                .Index(t => t.EstadoTransmisionID)
                .Index(t => new { t.EmpresaID, t.ComercioID });
            
            CreateTable(
                "dbo.Gasto",
                c => new
                    {
                        EmpresaID = c.Int(nullable: false),
                        ComercioID = c.Int(nullable: false),
                        GastoID = c.Int(nullable: false, identity: true),
                        SolicitudFondoID = c.Long(),
                        Activo = c.Boolean(nullable: false),
                        Importe = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Descripcion = c.String(),
                        DepartamentoID = c.Int(),
                        ConceptoGastoID = c.Int(),
                        ConceptoGastoProveedorID = c.Int(),
                        ProveedorID = c.Int(),
                        ProveedorSucursalID = c.Int(),
                        Fecha = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Pagado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.EmpresaID, t.ComercioID, t.GastoID })
                .ForeignKey("dbo.Comercio", t => new { t.EmpresaID, t.ComercioID })
                .ForeignKey("dbo.ConceptoGastos", t => t.ConceptoGastoID)
                .ForeignKey("dbo.ConceptoGastosProveedor", t => t.ConceptoGastoProveedorID)
                .ForeignKey("dbo.Departamento", t => t.DepartamentoID)
                .ForeignKey("dbo.Empresa", t => t.EmpresaID)
                .ForeignKey("dbo.Proveedor", t => t.ProveedorID)
                .ForeignKey("dbo.ProveedorSucursal", t => t.ProveedorSucursalID)
                .ForeignKey("dbo.SolicitudFondo", t => new { t.EmpresaID, t.ComercioID, t.SolicitudFondoID })
                .Index(t => new { t.EmpresaID, t.ComercioID })
                .Index(t => new { t.EmpresaID, t.ComercioID, t.SolicitudFondoID })
                .Index(t => t.DepartamentoID)
                .Index(t => t.ConceptoGastoID)
                .Index(t => t.ConceptoGastoProveedorID)
                .Index(t => t.ProveedorID)
                .Index(t => t.ProveedorSucursalID);
            
            CreateTable(
                "dbo.PlanesTipo",
                c => new
                    {
                        PlanesTipoID = c.String(nullable: false, maxLength: 20),
                        EmpresaID = c.Int(nullable: false),
                        ComercioID = c.Int(nullable: false),
                        TipoAV = c.String(maxLength: 1),
                        PuntoD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PuntoH = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Inter = c.Decimal(nullable: false, precision: 18, scale: 4),
                        Inter_Incr = c.Decimal(nullable: false, precision: 18, scale: 4),
                        Gasto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Gasto_Incr = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GastoFijo = c.Decimal(precision: 18, scale: 2),
                        Comis = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Comis_Incr = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MontoMax = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NroORden = c.Int(nullable: false),
                        Notas = c.String(maxLength: 40),
                        Corte = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlanesTipoID)
                .ForeignKey("dbo.Comercio", t => new { t.EmpresaID, t.ComercioID })
                .ForeignKey("dbo.Empresa", t => t.EmpresaID)
                .Index(t => new { t.EmpresaID, t.ComercioID });
            
            CreateTable(
                "dbo.PlanesBonif",
                c => new
                    {
                        PlanesBonifID = c.String(nullable: false, maxLength: 128),
                        PlanesTipoID = c.String(maxLength: 20),
                        EmpresaID = c.Int(nullable: false),
                        ComercioID = c.Int(nullable: false),
                        TipoBoni = c.String(maxLength: 2),
                        PorBoni = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cuotas_D = c.Int(nullable: false),
                        Cuotas_H = c.Int(nullable: false),
                        TipoCuota = c.String(maxLength: 1),
                        nMora = c.Int(nullable: false),
                        FechaAlta = c.DateTime(nullable: false),
                        FechaVenci = c.DateTime(nullable: false),
                        UsuarioID = c.Int(nullable: false),
                        UsuarioPC = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.PlanesBonifID)
                .ForeignKey("dbo.Comercio", t => new { t.EmpresaID, t.ComercioID }, cascadeDelete: true)
                .ForeignKey("dbo.Empresa", t => t.EmpresaID, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.UsuarioID, cascadeDelete: true)
                .ForeignKey("dbo.PlanesTipo", t => t.PlanesTipoID)
                .Index(t => t.PlanesTipoID)
                .Index(t => new { t.EmpresaID, t.ComercioID })
                .Index(t => t.UsuarioID);
            
            CreateTable(
                "dbo.PlanesDetalle",
                c => new
                    {
                        PlanesDetalleID = c.Int(nullable: false, identity: true),
                        PlanesTipoID = c.String(maxLength: 20),
                        EmpresaID = c.Int(nullable: false),
                        ComercioID = c.Int(nullable: false),
                        TipoCuota = c.String(),
                        Cuotas_D = c.Int(nullable: false),
                        Cuotas_H = c.Int(nullable: false),
                        SiCreditos = c.Boolean(nullable: false),
                        nCreditos_D = c.Int(nullable: false),
                        nCreditos_H = c.Int(nullable: false),
                        SiCancel = c.Boolean(nullable: false),
                        nCancel_D = c.Int(nullable: false),
                        nCancel_H = c.Int(nullable: false),
                        SiMora = c.Boolean(nullable: false),
                        nMora_D = c.Int(nullable: false),
                        nMora_H = c.Int(nullable: false),
                        SiValor = c.Boolean(nullable: false),
                        nValor_D = c.Int(nullable: false),
                        nValor_H = c.Int(nullable: false),
                        Monto_max = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FechaAlta = c.DateTime(nullable: false),
                        FechaVenci = c.DateTime(nullable: false),
                        UsuarioID = c.Int(nullable: false),
                        UsuarioPC = c.String(),
                    })
                .PrimaryKey(t => t.PlanesDetalleID)
                .ForeignKey("dbo.Comercio", t => new { t.EmpresaID, t.ComercioID }, cascadeDelete: true)
                .ForeignKey("dbo.Empresa", t => t.EmpresaID, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.UsuarioID, cascadeDelete: true)
                .ForeignKey("dbo.PlanesTipo", t => t.PlanesTipoID)
                .Index(t => t.PlanesTipoID)
                .Index(t => new { t.EmpresaID, t.ComercioID })
                .Index(t => t.UsuarioID);
            
            CreateTable(
                "dbo.PlanesVenci",
                c => new
                    {
                        PlanesVenciID = c.String(nullable: false, maxLength: 128),
                        PlanesTipoID = c.String(maxLength: 20),
                        CambiaFecha = c.Boolean(nullable: false),
                        DiasPrimerCuota = c.Int(nullable: false),
                        TipoVencimiento = c.String(maxLength: 3),
                        VenciDia = c.Int(nullable: false),
                        VenciCorte = c.Int(nullable: false),
                        Corte1 = c.Int(nullable: false),
                        VenDia1 = c.Int(nullable: false),
                        Corte2 = c.Int(nullable: false),
                        Vendia2 = c.Int(nullable: false),
                        Vendia3 = c.Int(nullable: false),
                        FechaAlta = c.DateTime(nullable: false),
                        FechaVenci = c.DateTime(nullable: false),
                        UsuarioID = c.Int(nullable: false),
                        UsuarioPC = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.PlanesVenciID)
                .ForeignKey("dbo.Usuario", t => t.UsuarioID, cascadeDelete: true)
                .ForeignKey("dbo.PlanesTipo", t => t.PlanesTipoID)
                .Index(t => t.PlanesTipoID)
                .Index(t => t.UsuarioID);
            
            CreateTable(
                "dbo.PlanesParam",
                c => new
                    {
                        PlanesParamId = c.Int(nullable: false),
                        Desde = c.Int(nullable: false),
                        Hasta = c.Int(nullable: false),
                        Valor = c.Int(nullable: false),
                        Param1 = c.String(maxLength: 40),
                        Param2 = c.String(maxLength: 40),
                        Orden = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlanesParamId);
            
            CreateTable(
                "dbo.Cap",
                c => new
                    {
                        EmpresaID = c.Int(nullable: false),
                        ComercioID = c.Int(nullable: false),
                        CapID = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Notas = c.String(),
                        SolicitudFondoID = c.Long(),
                        Pagado = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Finalizado = c.Boolean(nullable: false),
                        EstadoID = c.Int(nullable: false),
                        Saldo = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.EmpresaID, t.ComercioID, t.CapID })
                .ForeignKey("dbo.Comercio", t => new { t.EmpresaID, t.ComercioID })
                .ForeignKey("dbo.Empresa", t => t.EmpresaID)
                .ForeignKey("dbo.Estado", t => t.EstadoID, cascadeDelete: true)
                .ForeignKey("dbo.SolicitudFondo", t => new { t.EmpresaID, t.ComercioID, t.SolicitudFondoID })
                .Index(t => new { t.EmpresaID, t.ComercioID })
                .Index(t => new { t.EmpresaID, t.ComercioID, t.SolicitudFondoID })
                .Index(t => t.EstadoID);
            
            CreateTable(
                "dbo.CapDetalle",
                c => new
                    {
                        EmpresaID = c.Int(nullable: false),
                        ComercioID = c.Int(nullable: false),
                        CapID = c.Int(nullable: false),
                        CapDetalleID = c.Int(nullable: false, identity: true),
                        FechaVencimiento = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Importe = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Detalle = c.String(),
                        ImportePago = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Finalizado = c.Boolean(nullable: false),
                        PendientePago = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.EmpresaID, t.ComercioID, t.CapID, t.CapDetalleID })
                .ForeignKey("dbo.Cap", t => new { t.EmpresaID, t.ComercioID, t.CapID }, cascadeDelete: true)
                .Index(t => new { t.EmpresaID, t.ComercioID, t.CapID });
            
            CreateTable(
                "dbo.Pago",
                c => new
                    {
                        EmpresaID = c.Int(nullable: false),
                        ComercioID = c.Int(nullable: false),
                        PagoID = c.Int(nullable: false, identity: true),
                        SolicitudFondoID = c.Long(),
                        CapID = c.Int(),
                        CapDetalleID = c.Int(),
                        FFID = c.Int(),
                        FFDetalleID = c.Int(),
                        Fecha = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Importe = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EstadoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EmpresaID, t.ComercioID, t.PagoID })
                .ForeignKey("dbo.CapDetalle", t => new { t.EmpresaID, t.ComercioID, t.CapID, t.CapDetalleID })
                .ForeignKey("dbo.Comercio", t => new { t.EmpresaID, t.ComercioID })
                .ForeignKey("dbo.Empresa", t => t.EmpresaID)
                .ForeignKey("dbo.Estado", t => t.EstadoID, cascadeDelete: true)
                .ForeignKey("dbo.FFDetalle", t => new { t.EmpresaID, t.ComercioID, t.FFID, t.FFDetalleID })
                .ForeignKey("dbo.SolicitudFondo", t => new { t.EmpresaID, t.ComercioID, t.SolicitudFondoID })
                .Index(t => new { t.EmpresaID, t.ComercioID, t.CapID, t.CapDetalleID })
                .Index(t => new { t.EmpresaID, t.ComercioID, t.FFID, t.FFDetalleID })
                .Index(t => new { t.EmpresaID, t.ComercioID, t.SolicitudFondoID })
                .Index(t => t.EstadoID);
            
            CreateTable(
                "dbo.FFDetalle",
                c => new
                    {
                        EmpresaID = c.Int(nullable: false),
                        ComercioID = c.Int(nullable: false),
                        FFID = c.Int(nullable: false),
                        FFDetalleID = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Importe = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Detalle = c.String(),
                        ImportePago = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.EmpresaID, t.ComercioID, t.FFID, t.FFDetalleID })
                .ForeignKey("dbo.FF", t => new { t.EmpresaID, t.ComercioID, t.FFID }, cascadeDelete: true)
                .Index(t => new { t.EmpresaID, t.ComercioID, t.FFID });
            
            CreateTable(
                "dbo.FF",
                c => new
                    {
                        EmpresaID = c.Int(nullable: false),
                        ComercioID = c.Int(nullable: false),
                        FFID = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        PendienteReposicionSemAnt = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Remanente = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalGastos = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MontoFF = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Repuesto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Notas = c.String(),
                        EstadoID = c.Int(nullable: false),
                        AReponer = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Pagado = c.Boolean(nullable: false),
                        SolicitudFondoID = c.Long(),
                    })
                .PrimaryKey(t => new { t.EmpresaID, t.ComercioID, t.FFID })
                .ForeignKey("dbo.Comercio", t => new { t.EmpresaID, t.ComercioID })
                .ForeignKey("dbo.Empresa", t => t.EmpresaID)
                .ForeignKey("dbo.Estado", t => t.EstadoID, cascadeDelete: true)
                .ForeignKey("dbo.SolicitudFondo", t => new { t.EmpresaID, t.ComercioID, t.SolicitudFondoID })
                .Index(t => new { t.EmpresaID, t.ComercioID })
                .Index(t => new { t.EmpresaID, t.ComercioID, t.SolicitudFondoID })
                .Index(t => t.EstadoID);
            
            CreateTable(
                "dbo.PerfilesPermisos",
                c => new
                    {
                        PerfilID = c.Int(nullable: false),
                        PermisoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PerfilID, t.PermisoID })
                .ForeignKey("dbo.Perfil", t => t.PerfilID, cascadeDelete: true)
                .ForeignKey("dbo.Permiso", t => t.PermisoID, cascadeDelete: true)
                .Index(t => t.PerfilID)
                .Index(t => t.PermisoID);
            
            CreateTable(
                "dbo.UsuariosPerfiles",
                c => new
                    {
                        UsuarioID = c.Int(nullable: false),
                        PerfilID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UsuarioID, t.PerfilID })
                .ForeignKey("dbo.Usuario", t => t.UsuarioID, cascadeDelete: true)
                .ForeignKey("dbo.Perfil", t => t.PerfilID, cascadeDelete: true)
                .Index(t => t.UsuarioID)
                .Index(t => t.PerfilID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FF", new[] { "EmpresaID", "ComercioID", "SolicitudFondoID" }, "dbo.SolicitudFondo");
            DropForeignKey("dbo.FFDetalle", new[] { "EmpresaID", "ComercioID", "FFID" }, "dbo.FF");
            DropForeignKey("dbo.FF", "EstadoID", "dbo.Estado");
            DropForeignKey("dbo.FF", "EmpresaID", "dbo.Empresa");
            DropForeignKey("dbo.FF", new[] { "EmpresaID", "ComercioID" }, "dbo.Comercio");
            DropForeignKey("dbo.Cap", new[] { "EmpresaID", "ComercioID", "SolicitudFondoID" }, "dbo.SolicitudFondo");
            DropForeignKey("dbo.CapDetalle", new[] { "EmpresaID", "ComercioID", "CapID" }, "dbo.Cap");
            DropForeignKey("dbo.Pago", new[] { "EmpresaID", "ComercioID", "SolicitudFondoID" }, "dbo.SolicitudFondo");
            DropForeignKey("dbo.Pago", new[] { "EmpresaID", "ComercioID", "FFID", "FFDetalleID" }, "dbo.FFDetalle");
            DropForeignKey("dbo.Pago", "EstadoID", "dbo.Estado");
            DropForeignKey("dbo.Pago", "EmpresaID", "dbo.Empresa");
            DropForeignKey("dbo.Pago", new[] { "EmpresaID", "ComercioID" }, "dbo.Comercio");
            DropForeignKey("dbo.Pago", new[] { "EmpresaID", "ComercioID", "CapID", "CapDetalleID" }, "dbo.CapDetalle");
            DropForeignKey("dbo.Cap", "EstadoID", "dbo.Estado");
            DropForeignKey("dbo.Cap", "EmpresaID", "dbo.Empresa");
            DropForeignKey("dbo.Cap", new[] { "EmpresaID", "ComercioID" }, "dbo.Comercio");
            DropForeignKey("dbo.PlanesVenci", "PlanesTipoID", "dbo.PlanesTipo");
            DropForeignKey("dbo.PlanesVenci", "UsuarioID", "dbo.Usuario");
            DropForeignKey("dbo.PlanesDetalle", "PlanesTipoID", "dbo.PlanesTipo");
            DropForeignKey("dbo.PlanesDetalle", "UsuarioID", "dbo.Usuario");
            DropForeignKey("dbo.PlanesDetalle", "EmpresaID", "dbo.Empresa");
            DropForeignKey("dbo.PlanesDetalle", new[] { "EmpresaID", "ComercioID" }, "dbo.Comercio");
            DropForeignKey("dbo.PlanesBonif", "PlanesTipoID", "dbo.PlanesTipo");
            DropForeignKey("dbo.PlanesBonif", "UsuarioID", "dbo.Usuario");
            DropForeignKey("dbo.PlanesBonif", "EmpresaID", "dbo.Empresa");
            DropForeignKey("dbo.PlanesBonif", new[] { "EmpresaID", "ComercioID" }, "dbo.Comercio");
            DropForeignKey("dbo.PlanesTipo", "EmpresaID", "dbo.Empresa");
            DropForeignKey("dbo.PlanesTipo", new[] { "EmpresaID", "ComercioID" }, "dbo.Comercio");
            DropForeignKey("dbo.Gasto", new[] { "EmpresaID", "ComercioID", "SolicitudFondoID" }, "dbo.SolicitudFondo");
            DropForeignKey("dbo.Gasto", "ProveedorSucursalID", "dbo.ProveedorSucursal");
            DropForeignKey("dbo.Gasto", "ProveedorID", "dbo.Proveedor");
            DropForeignKey("dbo.Gasto", "EmpresaID", "dbo.Empresa");
            DropForeignKey("dbo.Gasto", "DepartamentoID", "dbo.Departamento");
            DropForeignKey("dbo.Gasto", "ConceptoGastoProveedorID", "dbo.ConceptoGastosProveedor");
            DropForeignKey("dbo.Gasto", "ConceptoGastoID", "dbo.ConceptoGastos");
            DropForeignKey("dbo.Gasto", new[] { "EmpresaID", "ComercioID" }, "dbo.Comercio");
            DropForeignKey("dbo.Transmision", "OperacionID", "dbo.Operacion");
            DropForeignKey("dbo.Transmision", "EstadoTransmisionID", "dbo.EstadoTransmision");
            DropForeignKey("dbo.Transmision", "EmpresaID", "dbo.Empresa");
            DropForeignKey("dbo.Transmision", new[] { "EmpresaID", "ComercioID" }, "dbo.Comercio");
            DropForeignKey("dbo.OrdenDePago", "EstadoID", "dbo.Estado");
            DropForeignKey("dbo.OrdenDePago", "EmpresaID", "dbo.Empresa");
            DropForeignKey("dbo.OrdenDePago", "ConceptoFondosID", "dbo.ConceptoFondos");
            DropForeignKey("dbo.CuentaCorriente", new[] { "EmpresaID", "TransferenciaDepositoID" }, "dbo.TransferenciasDepositos");
            DropForeignKey("dbo.CuentaCorriente", "TipoMovimientoID", "dbo.TipoMovimiento");
            DropForeignKey("dbo.CuentaCorriente", new[] { "EmpresaID", "ComercioID", "SolicitudFondoID" }, "dbo.SolicitudFondo");
            DropForeignKey("dbo.CuentaCorriente", new[] { "EmpresaID", "ComercioID", "ReciboID" }, "dbo.Recibo");
            DropForeignKey("dbo.Recibo", "UsuarioID", "dbo.Usuario");
            DropForeignKey("dbo.Recibo", new[] { "EmpresaID", "TransferenciasDepositosID" }, "dbo.TransferenciasDepositos");
            DropForeignKey("dbo.Recibo", "TipoMovimientoID", "dbo.TipoMovimiento");
            DropForeignKey("dbo.TipoMovimiento", "ClaseMovimientoID", "dbo.ClaseMovimiento");
            DropForeignKey("dbo.Recibo", new[] { "EmpresaID", "ComercioID", "SolicitudFondoID" }, "dbo.SolicitudFondo");
            DropForeignKey("dbo.SolicitudFondo", new[] { "EmpresaID", "TransferenciasDepositosID" }, "dbo.TransferenciasDepositos");
            DropForeignKey("dbo.TransferenciasDepositos", "UsuarioID", "dbo.Usuario");
            DropForeignKey("dbo.TransferenciasDepositos", "TipoTransferenciaDepositoID", "dbo.TipoTransferenciaDeposito");
            DropForeignKey("dbo.TransferenciasDepositos", "ProveedorSucursalID", "dbo.ProveedorSucursal");
            DropForeignKey("dbo.TransferenciasDepositos", "PersonaId", "dbo.Persona");
            DropForeignKey("dbo.TransferenciasDepositos", "MonedaID", "dbo.Moneda");
            DropForeignKey("dbo.TransferenciasDepositos", "MedioDePagoID", "dbo.MedioDePago");
            DropForeignKey("dbo.TransferenciasDepositos", "EstadoID", "dbo.Estado");
            DropForeignKey("dbo.TransferenciasDepositos", "EmpresaID", "dbo.Empresa");
            DropForeignKey("dbo.TransferenciasDepositos", "EmpleadoRegistrador_EmpleadoID", "dbo.Empleado");
            DropForeignKey("dbo.TransferenciasDepositos", new[] { "CuentaOrigenEmpresaID", "CuentaOrigenCbID" }, "dbo.CuentaBancaria");
            DropForeignKey("dbo.TransferenciasDepositos", new[] { "CuentaDestinoEmpresaID", "CuentaDestinoCbID" }, "dbo.CuentaBancaria");
            DropForeignKey("dbo.TransferenciasDepositos", "ComercioEmpresa_EmpresaID", "dbo.Empresa");
            DropForeignKey("dbo.TransferenciasDepositos", new[] { "EmpresaID", "ComercioID" }, "dbo.Comercio");
            DropForeignKey("dbo.TransferenciasDepositos", new[] { "ChequeEmpID", "ChequeCbID", "ChequeNumChequera", "ChequeNumCheque" }, "dbo.Cheque");
            DropForeignKey("dbo.SolicitudFondo", "TipoSolicitudID", "dbo.TipoSolicitud");
            DropForeignKey("dbo.SolicitudFondoConceptoGastosProveedor", new[] { "EmpresaID", "ComercioID", "SolicitudFondoID" }, "dbo.SolicitudFondo");
            DropForeignKey("dbo.SolicitudFondoConceptoGastosProveedor", "EmpresaID", "dbo.Empresa");
            DropForeignKey("dbo.SolicitudFondoConceptoGastosProveedor", "ConceptoGastosProveedorID", "dbo.ConceptoGastosProveedor");
            DropForeignKey("dbo.SolicitudFondoConceptoGastosProveedor", new[] { "EmpresaID", "ComercioID" }, "dbo.Comercio");
            DropForeignKey("dbo.SolicitudFondo", "MonedaID", "dbo.Moneda");
            DropForeignKey("dbo.SolicitudFondo", "MedioDePagoID", "dbo.MedioDePago");
            DropForeignKey("dbo.SolicitudFondo", "GeneradoPorDepartamentoID", "dbo.Departamento");
            DropForeignKey("dbo.SolicitudFondo", "EstadoID", "dbo.Estado");
            DropForeignKey("dbo.SolicitudFondo", "EmpresaID", "dbo.Empresa");
            DropForeignKey("dbo.SolicitudFondo", "EmpleadoSolicitanteID", "dbo.Empleado");
            DropForeignKey("dbo.SolicitudFondo", "EmpleadoRealizadorID", "dbo.Empleado");
            DropForeignKey("dbo.Empleado", "Usuarioid", "dbo.Usuario");
            DropForeignKey("dbo.Empleado", "TipoEmpleadoID", "dbo.TipoEmpleado");
            DropForeignKey("dbo.Empleado", "PersonaID", "dbo.Persona");
            DropForeignKey("dbo.Empleado", "EstadoId", "dbo.Estado");
            DropForeignKey("dbo.Empleado", "EmpresaID", "dbo.Empresa");
            DropForeignKey("dbo.Empleado", "DepartamentoID", "dbo.Departamento");
            DropForeignKey("dbo.Empleado", new[] { "EmpresaID", "ComercioID" }, "dbo.Comercio");
            DropForeignKey("dbo.Empleado", "CargoID", "dbo.Cargo");
            DropForeignKey("dbo.SolicitudFondo", "ConceptoFondosID", "dbo.ConceptoFondos");
            DropForeignKey("dbo.SolicitudFondo", new[] { "EmpresaID", "ComercioID" }, "dbo.Comercio");
            DropForeignKey("dbo.SolicitudFondo", new[] { "EmpresaID", "CuentaBancariaID", "NumChequera", "NumCheque" }, "dbo.Cheque");
            DropForeignKey("dbo.SolicitudFondo", new[] { "EmpresaID", "ComercioID", "AvisoDePagoID" }, "dbo.AvisoDePago");
            DropForeignKey("dbo.Recibo", "EstadoID", "dbo.Estado");
            DropForeignKey("dbo.Recibo", "EmpresaID", "dbo.Empresa");
            DropForeignKey("dbo.Recibo", new[] { "ComercioAdheridoEmpresaID", "ComercioAdheridoComercioID" }, "dbo.Comercio");
            DropForeignKey("dbo.Recibo", new[] { "EmpresaID", "ComercioID" }, "dbo.Comercio");
            DropForeignKey("dbo.CuentaCorriente", new[] { "EmpresaID", "ComercioID", "CreditoID", "CuotaID", "CobranzaID", "NotaCDID" }, "dbo.NotasCD");
            DropForeignKey("dbo.CuentaCorriente", "EmpresaID", "dbo.Empresa");
            DropForeignKey("dbo.CuentaCorriente", new[] { "EmpresaID", "ComercioID", "CreditoID", "CuotaID" }, "dbo.Cuota");
            DropForeignKey("dbo.CuentaCorriente", new[] { "EmpresaID", "ComercioID", "CreditoID" }, "dbo.Credito");
            DropForeignKey("dbo.CuentaCorriente", new[] { "EmpresaID", "ComercioID" }, "dbo.Comercio");
            DropForeignKey("dbo.CuentaCorriente", new[] { "EmpresaID", "ComercioID", "CreditoID", "CuotaID", "CobranzaID" }, "dbo.Cobranza");
            DropForeignKey("dbo.CreditoAnulado", "UsuarioID", "dbo.Usuario");
            DropForeignKey("dbo.CreditoAnulado", "TipoAnulacionID", "dbo.TipoAnulacion");
            DropForeignKey("dbo.CreditoAnulado", "EmpresaID", "dbo.Empresa");
            DropForeignKey("dbo.CreditoAnulado", new[] { "EmpresaID", "ComercioID" }, "dbo.Comercio");
            DropForeignKey("dbo.CreditoAnulado", new[] { "Documento", "TipoDocumentoID" }, "dbo.Cliente");
            DropForeignKey("dbo.ConceptoGastosDepartamento", "EstadoID", "dbo.Estado");
            DropForeignKey("dbo.ConceptoGastosDepartamento", "DepartamentoID", "dbo.Departamento");
            DropForeignKey("dbo.ConceptoGastosDepartamento", "ConceptoGastosID", "dbo.ConceptoGastos");
            DropForeignKey("dbo.Departamento", "ConceptoFondos_ConceptoFondosID", "dbo.ConceptoFondos");
            DropForeignKey("dbo.ConceptoFondos", "MedioDePagoID", "dbo.MedioDePago");
            DropForeignKey("dbo.AvisoDePago", "EmpresaID", "dbo.Empresa");
            DropForeignKey("dbo.Credito", new[] { "EmpresaID", "ComercioID", "AvisoDePagoID" }, "dbo.AvisoDePago");
            DropForeignKey("dbo.Credito", "usuarioAvalID", "dbo.Usuario");
            DropForeignKey("dbo.Credito", "UsuarioID", "dbo.Usuario");
            DropForeignKey("dbo.Credito", "TipoCuotaID", "dbo.TipoCuota");
            DropForeignKey("dbo.Credito", "TipoBonificacionID", "dbo.TipoBonificacion");
            DropForeignKey("dbo.Nota", new[] { "EmpresaID", "ComercioID", "CreditoID" }, "dbo.Credito");
            DropForeignKey("dbo.Credito", "EmpresaID", "dbo.Empresa");
            DropForeignKey("dbo.CreditoAval", "UsuarioID", "dbo.Usuario");
            DropForeignKey("dbo.CreditoAval", "TipoAvalID", "dbo.TipoAval");
            DropForeignKey("dbo.CreditoAval", "EmpresaID", "dbo.Empresa");
            DropForeignKey("dbo.CreditoAval", new[] { "EmpresaID", "ComercioID", "CreditoID" }, "dbo.Credito");
            DropForeignKey("dbo.CreditoAval", new[] { "EmpresaID", "ComercioID" }, "dbo.Comercio");
            DropForeignKey("dbo.Credito", new[] { "EmpresaID", "ComercioID" }, "dbo.Comercio");
            DropForeignKey("dbo.Cobranza", "UsuarioID", "dbo.Usuario");
            DropForeignKey("dbo.Cobranza", "TipoPagoID", "dbo.TipoPago");
            DropForeignKey("dbo.Cobranza", "TipoBonificacionID", "dbo.TipoBonificacion");
            DropForeignKey("dbo.NotasCD", new[] { "EmpresaID", "ComercioID", "CreditoID", "CuotaID", "CobranzaID" }, "dbo.Cobranza");
            DropForeignKey("dbo.NotasCD", "UsuarioID", "dbo.Usuario");
            DropForeignKey("dbo.Nota", new[] { "EmpresaID", "ComercioID", "CreditoID", "CuotaID", "CobranzaID" }, "dbo.Cobranza");
            DropForeignKey("dbo.Cobranza", "EmpresaID", "dbo.Empresa");
            DropForeignKey("dbo.Cobranza", new[] { "EmpresaID", "ComercioID", "CreditoID", "CuotaID" }, "dbo.Cuota");
            DropForeignKey("dbo.Cuota", "TipoCuotaID", "dbo.TipoCuota");
            DropForeignKey("dbo.Nota", new[] { "EmpresaID", "ComercioID", "CreditoID", "CuotaID" }, "dbo.Cuota");
            DropForeignKey("dbo.Cuota", "EmpresaID", "dbo.Empresa");
            DropForeignKey("dbo.Cuota", new[] { "EmpresaID", "ComercioID", "CreditoID" }, "dbo.Credito");
            DropForeignKey("dbo.Cuota", new[] { "EmpresaID", "ComercioID" }, "dbo.Comercio");
            DropForeignKey("dbo.Cuota", new[] { "Documento", "TipoDocumentoID" }, "dbo.Cliente");
            DropForeignKey("dbo.Cobranza", new[] { "EmpresaID", "ComercioID", "CreditoID" }, "dbo.Credito");
            DropForeignKey("dbo.Cobranza", new[] { "EmpresaID", "ComercioID" }, "dbo.Comercio");
            DropForeignKey("dbo.Cobranza", new[] { "Documento", "TipoDocumentoID" }, "dbo.Cliente");
            DropForeignKey("dbo.Cliente", "UsuarioModificacionID", "dbo.Usuario");
            DropForeignKey("dbo.Cliente", "TipoDocumentoID", "dbo.TipoDocumento");
            DropForeignKey("dbo.Cliente", "TipoComoConocioID", "dbo.TipoComoConocio");
            DropForeignKey("dbo.Telefono", "UsuarioID", "dbo.Usuario");
            DropForeignKey("dbo.Telefono", "EstadoID", "dbo.Estado");
            DropForeignKey("dbo.Telefono", new[] { "Documento", "TipoDocumentoID" }, "dbo.Cliente");
            DropForeignKey("dbo.Telefono", "ClaseDatoID", "dbo.ClaseDato");
            DropForeignKey("dbo.Cliente", "SexoID", "dbo.Sexo");
            DropForeignKey("dbo.Refinanciacion", new[] { "Documento", "TipoDocumentoID" }, "dbo.Cliente");
            DropForeignKey("dbo.Refinanciacion", "UsuarioID", "dbo.Usuario");
            DropForeignKey("dbo.RefinanciacionCobranza", "TipoPagoID", "dbo.TipoPago");
            DropForeignKey("dbo.RefinanciacionCobranza", new[] { "EmpresaID", "ComercioID", "CreditoID", "RefinanciacionID", "RefinanciacionCuotaID" }, "dbo.RefinanciacionCuota");
            DropForeignKey("dbo.RefinanciacionCobranza", new[] { "EmpresaID", "ComercioID", "CreditoID", "RefinanciacionID" }, "dbo.Refinanciacion");
            DropForeignKey("dbo.RefinanciacionCobranza", "EmpresaID", "dbo.Empresa");
            DropForeignKey("dbo.RefinanciacionCobranza", new[] { "EmpresaID", "ComercioID" }, "dbo.Comercio");
            DropForeignKey("dbo.RefinanciacionCobranza", new[] { "Documento", "TipoDocumentoID" }, "dbo.Cliente");
            DropForeignKey("dbo.RefinanciacionCuota", new[] { "EmpresaID", "ComercioID", "CreditoID", "RefinanciacionID" }, "dbo.Refinanciacion");
            DropForeignKey("dbo.RefinanciacionCuota", "EmpresaID", "dbo.Empresa");
            DropForeignKey("dbo.RefinanciacionCuota", new[] { "EmpresaID", "ComercioID" }, "dbo.Comercio");
            DropForeignKey("dbo.RefinanciacionCuota", new[] { "Documento", "TipoDocumentoID" }, "dbo.Cliente");
            DropForeignKey("dbo.Refinanciacion", "EstadoID", "dbo.Estado");
            DropForeignKey("dbo.Refinanciacion", "EmpresaID", "dbo.Empresa");
            DropForeignKey("dbo.Refinanciacion", new[] { "EmpresaID", "ComercioID", "CreditoID" }, "dbo.Credito");
            DropForeignKey("dbo.Refinanciacion", new[] { "EmpresaID", "ComercioID" }, "dbo.Comercio");
            DropForeignKey("dbo.Cliente", "ProfesionID", "dbo.Profesion");
            DropForeignKey("dbo.Profesion", "ProfesionPadreID", "dbo.Profesion");
            DropForeignKey("dbo.Nota", new[] { "Documento", "TipoDocumentoID" }, "dbo.Cliente");
            DropForeignKey("dbo.Nota", "UsuarioID", "dbo.Usuario");
            DropForeignKey("dbo.Mail", new[] { "Documento", "TipoDocumentoID" }, "dbo.Cliente");
            DropForeignKey("dbo.Mail", "UsuarioID", "dbo.Usuario");
            DropForeignKey("dbo.Mail", "EstadoID", "dbo.Estado");
            DropForeignKey("dbo.Mail", "ClaseDatoID", "dbo.ClaseDato");
            DropForeignKey("dbo.Cliente", "EstadoID", "dbo.Estado");
            DropForeignKey("dbo.Domicilio", "UsuarioID", "dbo.Usuario");
            DropForeignKey("dbo.UsuariosPerfiles", "PerfilID", "dbo.Perfil");
            DropForeignKey("dbo.UsuariosPerfiles", "UsuarioID", "dbo.Usuario");
            DropForeignKey("dbo.PerfilesPermisos", "PermisoID", "dbo.Permiso");
            DropForeignKey("dbo.PerfilesPermisos", "PerfilID", "dbo.Perfil");
            DropForeignKey("dbo.Domicilio", new[] { "PaisId", "ProvinciaID" }, "dbo.Provincia");
            DropForeignKey("dbo.Domicilio", "PaisId", "dbo.Pais");
            DropForeignKey("dbo.Domicilio", new[] { "PaisId", "ProvinciaID", "LocalidadID" }, "dbo.Localidad");
            DropForeignKey("dbo.Domicilio", "EstadoID", "dbo.Estado");
            DropForeignKey("dbo.Domicilio", new[] { "Documento", "TipoDocumentoID" }, "dbo.Cliente");
            DropForeignKey("dbo.Domicilio", "ClaseDatoID", "dbo.ClaseDato");
            DropForeignKey("dbo.Credito", new[] { "Garante3", "TipoDocumentoIDG3" }, "dbo.Cliente");
            DropForeignKey("dbo.Credito", new[] { "Garante2", "TipoDocumentoIDG2" }, "dbo.Cliente");
            DropForeignKey("dbo.Credito", new[] { "Garante1", "TipoDocumentoIDG1" }, "dbo.Cliente");
            DropForeignKey("dbo.Credito", new[] { "Adicional", "TipoDocumentoIDAdi" }, "dbo.Cliente");
            DropForeignKey("dbo.Credito", new[] { "Documento", "TipoDocumentoID" }, "dbo.Cliente");
            DropForeignKey("dbo.Credito", new[] { "EmpresaID", "AbogadoID" }, "dbo.Comercio");
            DropForeignKey("dbo.AvisoDePago", new[] { "EmpresaID", "ComercioID" }, "dbo.Comercio");
            DropForeignKey("dbo.Autorizacion", "PersonaID", "dbo.Persona");
            DropForeignKey("dbo.Autorizacion", "EstadoID", "dbo.Estado");
            DropForeignKey("dbo.Autorizacion", "EmpresaID", "dbo.Empresa");
            DropForeignKey("dbo.Autorizacion", new[] { "EmpresaID", "ComercioID" }, "dbo.Comercio");
            DropForeignKey("dbo.Comercio", "Titular2_PersonaID", "dbo.Persona");
            DropForeignKey("dbo.Comercio", "Titular1_PersonaID", "dbo.Persona");
            DropForeignKey("dbo.Comercio", "TipoComercioID", "dbo.TipoComercio");
            DropForeignKey("dbo.Comercio", new[] { "PaisId", "ProvinciaID" }, "dbo.Provincia");
            DropForeignKey("dbo.Comercio", "PaisId", "dbo.Pais");
            DropForeignKey("dbo.Comercio", new[] { "PaisId", "ProvinciaID", "LocalidadID" }, "dbo.Localidad");
            DropForeignKey("dbo.Comercio", "EmpresaID", "dbo.Empresa");
            DropForeignKey("dbo.CuentaBancaria", "EmpresaID", "dbo.Empresa");
            DropForeignKey("dbo.CuentaBancaria", "TipoCuentaBancariaID", "dbo.TipoCuentaBancaria");
            DropForeignKey("dbo.CuentaBancaria", new[] { "BancoID", "SucursalBancoID" }, "dbo.SucursalBanco");
            DropForeignKey("dbo.SucursalBanco", new[] { "PaisId", "ProvinciaID" }, "dbo.Provincia");
            DropForeignKey("dbo.SucursalBanco", "PaisId", "dbo.Pais");
            DropForeignKey("dbo.SucursalBanco", new[] { "PaisId", "ProvinciaID", "LocalidadID" }, "dbo.Localidad");
            DropForeignKey("dbo.SucursalBanco", "BancoID", "dbo.Banco");
            DropForeignKey("dbo.CuentaBancaria", "ProveedorSucursal_ProveedorSucursalID", "dbo.ProveedorSucursal");
            DropForeignKey("dbo.CuentaBancaria", "Proveedor_ProveedorID", "dbo.Proveedor");
            DropForeignKey("dbo.Proveedor", new[] { "PaisId", "ProvinciaID" }, "dbo.Provincia");
            DropForeignKey("dbo.Proveedor", "PaisId", "dbo.Pais");
            DropForeignKey("dbo.Proveedor", new[] { "PaisId", "ProvinciaID", "LocalidadID" }, "dbo.Localidad");
            DropForeignKey("dbo.Proveedor", "EstadoID", "dbo.Estado");
            DropForeignKey("dbo.ConceptoGastosProveedor", "ProveedorSucursalID", "dbo.ProveedorSucursal");
            DropForeignKey("dbo.ProveedorSucursal", new[] { "PaisID", "ProvinciaID" }, "dbo.Provincia");
            DropForeignKey("dbo.ProveedorSucursal", "ProveedorID", "dbo.Proveedor");
            DropForeignKey("dbo.ProveedorSucursal", "PaisID", "dbo.Pais");
            DropForeignKey("dbo.ProveedorSucursal", new[] { "PaisID", "ProvinciaID", "LocalidadID" }, "dbo.Localidad");
            DropForeignKey("dbo.ProveedorSucursal", "EstadoID", "dbo.Estado");
            DropForeignKey("dbo.ConceptoGastosProveedor", "ProveedorID", "dbo.Proveedor");
            DropForeignKey("dbo.ConceptoGastosProveedor", "EstadoID", "dbo.Estado");
            DropForeignKey("dbo.ConceptoGastosProveedor", "ConceptoGastosID", "dbo.ConceptoGastos");
            DropForeignKey("dbo.ConceptoGastos", "EstadoID", "dbo.Estado");
            DropForeignKey("dbo.ConceptoGastos", "ConceptoGastoPadreID", "dbo.ConceptoGastos");
            DropForeignKey("dbo.CuentaBancaria", "PersonaID", "dbo.Persona");
            DropForeignKey("dbo.CuentaBancaria", "MonedaID", "dbo.Moneda");
            DropForeignKey("dbo.Moneda", "PaisId", "dbo.Pais");
            DropForeignKey("dbo.CuentaBancaria", "EstadoID", "dbo.Estado");
            DropForeignKey("dbo.CuentaBancaria", new[] { "EmpresaID", "ComercioID" }, "dbo.Comercio");
            DropForeignKey("dbo.CuentaBancaria", "ClaseCuentaBancariaID", "dbo.ClaseCuentaBancaria");
            DropForeignKey("dbo.Chequera", new[] { "EmpresaID", "CuentaBancariaID" }, "dbo.CuentaBancaria");
            DropForeignKey("dbo.Chequera", "EstadoID", "dbo.Estado");
            DropForeignKey("dbo.Cheque", new[] { "EmpresaID", "CuentaBancariaID", "ChequeraID" }, "dbo.Chequera");
            DropForeignKey("dbo.Cheque", "TipoChequeID", "dbo.TipoCheque");
            DropForeignKey("dbo.Cheque", "EstadoID", "dbo.Estado");
            DropForeignKey("dbo.Estado", "TipoEstadoID", "dbo.TipoEstado");
            DropForeignKey("dbo.CuentaBancaria", "BancoID", "dbo.Banco");
            DropForeignKey("dbo.Comercio", "Contacto2_PersonaID", "dbo.Persona");
            DropForeignKey("dbo.Comercio", "Contacto1_PersonaID", "dbo.Persona");
            DropForeignKey("dbo.Persona", "TiposDocumento_TipoDocumentoID", "dbo.TipoDocumento");
            DropForeignKey("dbo.Persona", new[] { "PaisID", "ProvinciaID" }, "dbo.Provincia");
            DropForeignKey("dbo.Persona", "PaisID", "dbo.Pais");
            DropForeignKey("dbo.Persona", new[] { "PaisID", "ProvinciaID", "LocalidadID" }, "dbo.Localidad");
            DropForeignKey("dbo.Localidad", "PaisId", "dbo.Pais");
            DropForeignKey("dbo.Provincia", "PaisId", "dbo.Pais");
            DropForeignKey("dbo.Localidad", new[] { "PaisId", "ProvinciaID" }, "dbo.Provincia");
            DropIndex("dbo.UsuariosPerfiles", new[] { "PerfilID" });
            DropIndex("dbo.UsuariosPerfiles", new[] { "UsuarioID" });
            DropIndex("dbo.PerfilesPermisos", new[] { "PermisoID" });
            DropIndex("dbo.PerfilesPermisos", new[] { "PerfilID" });
            DropIndex("dbo.FF", new[] { "EstadoID" });
            DropIndex("dbo.FF", new[] { "EmpresaID", "ComercioID", "SolicitudFondoID" });
            DropIndex("dbo.FF", new[] { "EmpresaID", "ComercioID" });
            DropIndex("dbo.FFDetalle", new[] { "EmpresaID", "ComercioID", "FFID" });
            DropIndex("dbo.Pago", new[] { "EstadoID" });
            DropIndex("dbo.Pago", new[] { "EmpresaID", "ComercioID", "SolicitudFondoID" });
            DropIndex("dbo.Pago", new[] { "EmpresaID", "ComercioID", "FFID", "FFDetalleID" });
            DropIndex("dbo.Pago", new[] { "EmpresaID", "ComercioID", "CapID", "CapDetalleID" });
            DropIndex("dbo.CapDetalle", new[] { "EmpresaID", "ComercioID", "CapID" });
            DropIndex("dbo.Cap", new[] { "EstadoID" });
            DropIndex("dbo.Cap", new[] { "EmpresaID", "ComercioID", "SolicitudFondoID" });
            DropIndex("dbo.Cap", new[] { "EmpresaID", "ComercioID" });
            DropIndex("dbo.PlanesVenci", new[] { "UsuarioID" });
            DropIndex("dbo.PlanesVenci", new[] { "PlanesTipoID" });
            DropIndex("dbo.PlanesDetalle", new[] { "UsuarioID" });
            DropIndex("dbo.PlanesDetalle", new[] { "EmpresaID", "ComercioID" });
            DropIndex("dbo.PlanesDetalle", new[] { "PlanesTipoID" });
            DropIndex("dbo.PlanesBonif", new[] { "UsuarioID" });
            DropIndex("dbo.PlanesBonif", new[] { "EmpresaID", "ComercioID" });
            DropIndex("dbo.PlanesBonif", new[] { "PlanesTipoID" });
            DropIndex("dbo.PlanesTipo", new[] { "EmpresaID", "ComercioID" });
            DropIndex("dbo.Gasto", new[] { "ProveedorSucursalID" });
            DropIndex("dbo.Gasto", new[] { "ProveedorID" });
            DropIndex("dbo.Gasto", new[] { "ConceptoGastoProveedorID" });
            DropIndex("dbo.Gasto", new[] { "ConceptoGastoID" });
            DropIndex("dbo.Gasto", new[] { "DepartamentoID" });
            DropIndex("dbo.Gasto", new[] { "EmpresaID", "ComercioID", "SolicitudFondoID" });
            DropIndex("dbo.Gasto", new[] { "EmpresaID", "ComercioID" });
            DropIndex("dbo.Transmision", new[] { "EmpresaID", "ComercioID" });
            DropIndex("dbo.Transmision", new[] { "EstadoTransmisionID" });
            DropIndex("dbo.Transmision", new[] { "OperacionID" });
            DropIndex("dbo.OrdenDePago", new[] { "ConceptoFondosID" });
            DropIndex("dbo.OrdenDePago", new[] { "EstadoID" });
            DropIndex("dbo.OrdenDePago", new[] { "EmpresaID" });
            DropIndex("dbo.TipoMovimiento", new[] { "ClaseMovimientoID" });
            DropIndex("dbo.TransferenciasDepositos", new[] { "EmpleadoRegistrador_EmpleadoID" });
            DropIndex("dbo.TransferenciasDepositos", new[] { "ComercioEmpresa_EmpresaID" });
            DropIndex("dbo.TransferenciasDepositos", new[] { "EstadoID" });
            DropIndex("dbo.TransferenciasDepositos", new[] { "TipoTransferenciaDepositoID" });
            DropIndex("dbo.TransferenciasDepositos", new[] { "UsuarioID" });
            DropIndex("dbo.TransferenciasDepositos", new[] { "ProveedorSucursalID" });
            DropIndex("dbo.TransferenciasDepositos", new[] { "PersonaId" });
            DropIndex("dbo.TransferenciasDepositos", new[] { "MonedaID" });
            DropIndex("dbo.TransferenciasDepositos", new[] { "MedioDePagoID" });
            DropIndex("dbo.TransferenciasDepositos", new[] { "ChequeEmpID", "ChequeCbID", "ChequeNumChequera", "ChequeNumCheque" });
            DropIndex("dbo.TransferenciasDepositos", new[] { "CuentaDestinoEmpresaID", "CuentaDestinoCbID" });
            DropIndex("dbo.TransferenciasDepositos", new[] { "CuentaOrigenEmpresaID", "CuentaOrigenCbID" });
            DropIndex("dbo.TransferenciasDepositos", new[] { "EmpresaID", "ComercioID" });
            DropIndex("dbo.SolicitudFondoConceptoGastosProveedor", new[] { "ConceptoGastosProveedorID" });
            DropIndex("dbo.SolicitudFondoConceptoGastosProveedor", new[] { "EmpresaID", "ComercioID", "SolicitudFondoID" });
            DropIndex("dbo.SolicitudFondoConceptoGastosProveedor", new[] { "EmpresaID", "ComercioID" });
            DropIndex("dbo.Empleado", new[] { "TipoEmpleadoID" });
            DropIndex("dbo.Empleado", new[] { "PersonaID" });
            DropIndex("dbo.Empleado", new[] { "EstadoId" });
            DropIndex("dbo.Empleado", new[] { "CargoID" });
            DropIndex("dbo.Empleado", new[] { "EmpresaID", "ComercioID" });
            DropIndex("dbo.Empleado", new[] { "DepartamentoID" });
            DropIndex("dbo.Empleado", new[] { "Usuarioid" });
            DropIndex("dbo.SolicitudFondo", new[] { "EmpleadoRealizadorID" });
            DropIndex("dbo.SolicitudFondo", new[] { "EmpleadoSolicitanteID" });
            DropIndex("dbo.SolicitudFondo", new[] { "TipoSolicitudID" });
            DropIndex("dbo.SolicitudFondo", new[] { "MonedaID" });
            DropIndex("dbo.SolicitudFondo", new[] { "EstadoID" });
            DropIndex("dbo.SolicitudFondo", new[] { "ConceptoFondosID" });
            DropIndex("dbo.SolicitudFondo", new[] { "MedioDePagoID" });
            DropIndex("dbo.SolicitudFondo", new[] { "GeneradoPorDepartamentoID" });
            DropIndex("dbo.SolicitudFondo", new[] { "EmpresaID", "TransferenciasDepositosID" });
            DropIndex("dbo.SolicitudFondo", new[] { "EmpresaID", "CuentaBancariaID", "NumChequera", "NumCheque" });
            DropIndex("dbo.SolicitudFondo", new[] { "EmpresaID", "ComercioID", "AvisoDePagoID" });
            DropIndex("dbo.Recibo", new[] { "ComercioAdheridoEmpresaID", "ComercioAdheridoComercioID" });
            DropIndex("dbo.Recibo", new[] { "EstadoID" });
            DropIndex("dbo.Recibo", new[] { "UsuarioID" });
            DropIndex("dbo.Recibo", new[] { "TipoMovimientoID" });
            DropIndex("dbo.Recibo", new[] { "EmpresaID", "TransferenciasDepositosID" });
            DropIndex("dbo.Recibo", new[] { "EmpresaID", "ComercioID", "SolicitudFondoID" });
            DropIndex("dbo.Recibo", new[] { "EmpresaID", "ComercioID" });
            DropIndex("dbo.CuentaCorriente", new[] { "TipoMovimientoID" });
            DropIndex("dbo.CuentaCorriente", new[] { "EmpresaID", "TransferenciaDepositoID" });
            DropIndex("dbo.CuentaCorriente", new[] { "EmpresaID", "ComercioID", "SolicitudFondoID" });
            DropIndex("dbo.CuentaCorriente", new[] { "EmpresaID", "ComercioID", "ReciboID" });
            DropIndex("dbo.CuentaCorriente", new[] { "EmpresaID", "ComercioID", "CreditoID", "CuotaID", "CobranzaID", "NotaCDID" });
            DropIndex("dbo.CuentaCorriente", new[] { "EmpresaID", "ComercioID", "CreditoID", "CuotaID", "CobranzaID" });
            DropIndex("dbo.CreditoAnulado", new[] { "TipoAnulacionID" });
            DropIndex("dbo.CreditoAnulado", new[] { "UsuarioID" });
            DropIndex("dbo.CreditoAnulado", new[] { "Documento", "TipoDocumentoID" });
            DropIndex("dbo.CreditoAnulado", new[] { "EmpresaID", "ComercioID" });
            DropIndex("dbo.ConceptoGastosDepartamento", new[] { "EstadoID" });
            DropIndex("dbo.ConceptoGastosDepartamento", new[] { "DepartamentoID" });
            DropIndex("dbo.ConceptoGastosDepartamento", new[] { "ConceptoGastosID" });
            DropIndex("dbo.Departamento", new[] { "ConceptoFondos_ConceptoFondosID" });
            DropIndex("dbo.ConceptoFondos", new[] { "MedioDePagoID" });
            DropIndex("dbo.CreditoAval", new[] { "UsuarioID" });
            DropIndex("dbo.CreditoAval", new[] { "TipoAvalID" });
            DropIndex("dbo.CreditoAval", new[] { "EmpresaID", "ComercioID" });
            DropIndex("dbo.CreditoAval", new[] { "EmpresaID", "ComercioID", "CreditoID" });
            DropIndex("dbo.NotasCD", new[] { "UsuarioID" });
            DropIndex("dbo.NotasCD", new[] { "EmpresaID", "ComercioID", "CreditoID", "CuotaID", "CobranzaID" });
            DropIndex("dbo.Cuota", new[] { "TipoCuotaID" });
            DropIndex("dbo.Cuota", new[] { "Documento", "TipoDocumentoID" });
            DropIndex("dbo.Cuota", new[] { "EmpresaID", "ComercioID", "CreditoID" });
            DropIndex("dbo.Cuota", new[] { "EmpresaID", "ComercioID" });
            DropIndex("dbo.Cobranza", new[] { "UsuarioID" });
            DropIndex("dbo.Cobranza", new[] { "TipoBonificacionID" });
            DropIndex("dbo.Cobranza", new[] { "TipoPagoID" });
            DropIndex("dbo.Cobranza", new[] { "Documento", "TipoDocumentoID" });
            DropIndex("dbo.Cobranza", new[] { "EmpresaID", "ComercioID", "CreditoID", "CuotaID" });
            DropIndex("dbo.Cobranza", new[] { "EmpresaID", "ComercioID", "CreditoID" });
            DropIndex("dbo.Cobranza", new[] { "EmpresaID", "ComercioID" });
            DropIndex("dbo.Telefono", new[] { "UsuarioID" });
            DropIndex("dbo.Telefono", new[] { "Documento", "TipoDocumentoID" });
            DropIndex("dbo.Telefono", new[] { "ClaseDatoID" });
            DropIndex("dbo.Telefono", new[] { "EstadoID" });
            DropIndex("dbo.RefinanciacionCobranza", new[] { "TipoPagoID" });
            DropIndex("dbo.RefinanciacionCobranza", new[] { "Documento", "TipoDocumentoID" });
            DropIndex("dbo.RefinanciacionCobranza", new[] { "EmpresaID", "ComercioID", "CreditoID", "RefinanciacionID", "RefinanciacionCuotaID" });
            DropIndex("dbo.RefinanciacionCobranza", new[] { "EmpresaID", "ComercioID", "CreditoID", "RefinanciacionID" });
            DropIndex("dbo.RefinanciacionCobranza", new[] { "EmpresaID", "ComercioID" });
            DropIndex("dbo.RefinanciacionCuota", new[] { "Documento", "TipoDocumentoID" });
            DropIndex("dbo.RefinanciacionCuota", new[] { "EmpresaID", "ComercioID", "CreditoID", "RefinanciacionID" });
            DropIndex("dbo.RefinanciacionCuota", new[] { "EmpresaID", "ComercioID" });
            DropIndex("dbo.Refinanciacion", new[] { "EstadoID" });
            DropIndex("dbo.Refinanciacion", new[] { "UsuarioID" });
            DropIndex("dbo.Refinanciacion", new[] { "Documento", "TipoDocumentoID" });
            DropIndex("dbo.Refinanciacion", new[] { "EmpresaID", "ComercioID", "CreditoID" });
            DropIndex("dbo.Refinanciacion", new[] { "EmpresaID", "ComercioID" });
            DropIndex("dbo.Profesion", new[] { "ProfesionPadreID" });
            DropIndex("dbo.Nota", new[] { "UsuarioID" });
            DropIndex("dbo.Nota", new[] { "Documento", "TipoDocumentoID" });
            DropIndex("dbo.Nota", new[] { "EmpresaID", "ComercioID", "CreditoID", "CuotaID", "CobranzaID" });
            DropIndex("dbo.Nota", new[] { "EmpresaID", "ComercioID", "CreditoID", "CuotaID" });
            DropIndex("dbo.Mail", new[] { "UsuarioID" });
            DropIndex("dbo.Mail", new[] { "Documento", "TipoDocumentoID" });
            DropIndex("dbo.Mail", new[] { "EstadoID" });
            DropIndex("dbo.Mail", new[] { "ClaseDatoID" });
            DropIndex("dbo.Domicilio", new[] { "UsuarioID" });
            DropIndex("dbo.Domicilio", new[] { "Documento", "TipoDocumentoID" });
            DropIndex("dbo.Domicilio", new[] { "EstadoID" });
            DropIndex("dbo.Domicilio", new[] { "ClaseDatoID" });
            DropIndex("dbo.Domicilio", new[] { "PaisId", "ProvinciaID", "LocalidadID" });
            DropIndex("dbo.Cliente", new[] { "EstadoID" });
            DropIndex("dbo.Cliente", new[] { "UsuarioModificacionID" });
            DropIndex("dbo.Cliente", new[] { "TipoComoConocioID" });
            DropIndex("dbo.Cliente", new[] { "SexoID" });
            DropIndex("dbo.Cliente", new[] { "ProfesionID" });
            DropIndex("dbo.Cliente", new[] { "TipoDocumentoID" });
            DropIndex("dbo.Credito", new[] { "TipoBonificacionID" });
            DropIndex("dbo.Credito", new[] { "UsuarioID" });
            DropIndex("dbo.Credito", new[] { "TipoCuotaID" });
            DropIndex("dbo.Credito", new[] { "usuarioAvalID" });
            DropIndex("dbo.Credito", new[] { "Adicional", "TipoDocumentoIDAdi" });
            DropIndex("dbo.Credito", new[] { "Garante3", "TipoDocumentoIDG3" });
            DropIndex("dbo.Credito", new[] { "Garante2", "TipoDocumentoIDG2" });
            DropIndex("dbo.Credito", new[] { "Garante1", "TipoDocumentoIDG1" });
            DropIndex("dbo.Credito", new[] { "Documento", "TipoDocumentoID" });
            DropIndex("dbo.Credito", new[] { "EmpresaID", "ComercioID", "AvisoDePagoID" });
            DropIndex("dbo.Credito", new[] { "EmpresaID", "ComercioID" });
            DropIndex("dbo.Credito", new[] { "EmpresaID", "AbogadoID" });
            DropIndex("dbo.AvisoDePago", new[] { "EmpresaID", "ComercioID" });
            DropIndex("dbo.SucursalBanco", new[] { "PaisId", "ProvinciaID", "LocalidadID" });
            DropIndex("dbo.SucursalBanco", new[] { "BancoID" });
            DropIndex("dbo.ProveedorSucursal", new[] { "EstadoID" });
            DropIndex("dbo.ProveedorSucursal", new[] { "PaisID", "ProvinciaID", "LocalidadID" });
            DropIndex("dbo.ProveedorSucursal", new[] { "ProveedorID" });
            DropIndex("dbo.ConceptoGastos", new[] { "ConceptoGastoPadreID" });
            DropIndex("dbo.ConceptoGastos", new[] { "EstadoID" });
            DropIndex("dbo.ConceptoGastosProveedor", new[] { "EstadoID" });
            DropIndex("dbo.ConceptoGastosProveedor", new[] { "ProveedorSucursalID" });
            DropIndex("dbo.ConceptoGastosProveedor", new[] { "ProveedorID" });
            DropIndex("dbo.ConceptoGastosProveedor", new[] { "ConceptoGastosID" });
            DropIndex("dbo.Proveedor", new[] { "EstadoID" });
            DropIndex("dbo.Proveedor", new[] { "PaisId", "ProvinciaID", "LocalidadID" });
            DropIndex("dbo.Moneda", new[] { "PaisId" });
            DropIndex("dbo.Estado", new[] { "TipoEstadoID" });
            DropIndex("dbo.Cheque", new[] { "EstadoID" });
            DropIndex("dbo.Cheque", new[] { "TipoChequeID" });
            DropIndex("dbo.Cheque", new[] { "EmpresaID", "CuentaBancariaID", "ChequeraID" });
            DropIndex("dbo.Chequera", new[] { "EstadoID" });
            DropIndex("dbo.Chequera", new[] { "EmpresaID", "CuentaBancariaID" });
            DropIndex("dbo.CuentaBancaria", new[] { "ProveedorSucursal_ProveedorSucursalID" });
            DropIndex("dbo.CuentaBancaria", new[] { "Proveedor_ProveedorID" });
            DropIndex("dbo.CuentaBancaria", new[] { "PersonaID" });
            DropIndex("dbo.CuentaBancaria", new[] { "EstadoID" });
            DropIndex("dbo.CuentaBancaria", new[] { "MonedaID" });
            DropIndex("dbo.CuentaBancaria", new[] { "BancoID" });
            DropIndex("dbo.CuentaBancaria", new[] { "BancoID", "SucursalBancoID" });
            DropIndex("dbo.CuentaBancaria", new[] { "TipoCuentaBancariaID" });
            DropIndex("dbo.CuentaBancaria", new[] { "ClaseCuentaBancariaID" });
            DropIndex("dbo.CuentaBancaria", new[] { "EmpresaID", "ComercioID" });
            DropIndex("dbo.Provincia", new[] { "PaisId" });
            DropIndex("dbo.Localidad", new[] { "PaisId", "ProvinciaID" });
            DropIndex("dbo.Persona", new[] { "TiposDocumento_TipoDocumentoID" });
            DropIndex("dbo.Persona", new[] { "PaisID", "ProvinciaID", "LocalidadID" });
            DropIndex("dbo.Comercio", new[] { "Titular2_PersonaID" });
            DropIndex("dbo.Comercio", new[] { "Titular1_PersonaID" });
            DropIndex("dbo.Comercio", new[] { "Contacto2_PersonaID" });
            DropIndex("dbo.Comercio", new[] { "Contacto1_PersonaID" });
            DropIndex("dbo.Comercio", new[] { "PaisId", "ProvinciaID", "LocalidadID" });
            DropIndex("dbo.Comercio", new[] { "TipoComercioID" });
            DropIndex("dbo.Comercio", new[] { "EmpresaID" });
            DropIndex("dbo.Autorizacion", new[] { "PersonaID" });
            DropIndex("dbo.Autorizacion", new[] { "EstadoID" });
            DropIndex("dbo.Autorizacion", new[] { "EmpresaID", "ComercioID" });
            DropTable("dbo.UsuariosPerfiles");
            DropTable("dbo.PerfilesPermisos");
            DropTable("dbo.FF");
            DropTable("dbo.FFDetalle");
            DropTable("dbo.Pago");
            DropTable("dbo.CapDetalle");
            DropTable("dbo.Cap");
            DropTable("dbo.PlanesParam");
            DropTable("dbo.PlanesVenci");
            DropTable("dbo.PlanesDetalle");
            DropTable("dbo.PlanesBonif");
            DropTable("dbo.PlanesTipo");
            DropTable("dbo.Gasto");
            DropTable("dbo.Transmision");
            DropTable("dbo.TipoRetencionPlan");
            DropTable("dbo.TipoImpresion");
            DropTable("dbo.TipoImagen");
            DropTable("dbo.OrdenDePago");
            DropTable("dbo.Operacion");
            DropTable("dbo.EstadoTransmision");
            DropTable("dbo.TipoMovimiento");
            DropTable("dbo.TipoTransferenciaDeposito");
            DropTable("dbo.TransferenciasDepositos");
            DropTable("dbo.TipoSolicitud");
            DropTable("dbo.SolicitudFondoConceptoGastosProveedor");
            DropTable("dbo.TipoEmpleado");
            DropTable("dbo.Empleado");
            DropTable("dbo.SolicitudFondo");
            DropTable("dbo.Recibo");
            DropTable("dbo.CuentaCorriente");
            DropTable("dbo.TipoAnulacion");
            DropTable("dbo.CreditoAnulado");
            DropTable("dbo.CuentaCorrienteCorte");
            DropTable("dbo.ConceptoGastosDepartamento");
            DropTable("dbo.Departamento");
            DropTable("dbo.MedioDePago");
            DropTable("dbo.ConceptoFondos");
            DropTable("dbo.ClaseMovimiento");
            DropTable("dbo.Cargo");
            DropTable("dbo.TipoAval");
            DropTable("dbo.CreditoAval");
            DropTable("dbo.TipoBonificacion");
            DropTable("dbo.NotasCD");
            DropTable("dbo.TipoCuota");
            DropTable("dbo.Cuota");
            DropTable("dbo.Cobranza");
            DropTable("dbo.TipoComoConocio");
            DropTable("dbo.Telefono");
            DropTable("dbo.Sexo");
            DropTable("dbo.TipoPago");
            DropTable("dbo.RefinanciacionCobranza");
            DropTable("dbo.RefinanciacionCuota");
            DropTable("dbo.Refinanciacion");
            DropTable("dbo.Profesion");
            DropTable("dbo.Nota");
            DropTable("dbo.Mail");
            DropTable("dbo.Permiso");
            DropTable("dbo.Perfil");
            DropTable("dbo.Usuario");
            DropTable("dbo.ClaseDato");
            DropTable("dbo.Domicilio");
            DropTable("dbo.Cliente");
            DropTable("dbo.Credito");
            DropTable("dbo.AvisoDePago");
            DropTable("dbo.TipoComercio");
            DropTable("dbo.TipoCuentaBancaria");
            DropTable("dbo.SucursalBanco");
            DropTable("dbo.ProveedorSucursal");
            DropTable("dbo.ConceptoGastos");
            DropTable("dbo.ConceptoGastosProveedor");
            DropTable("dbo.Proveedor");
            DropTable("dbo.Moneda");
            DropTable("dbo.ClaseCuentaBancaria");
            DropTable("dbo.TipoCheque");
            DropTable("dbo.TipoEstado");
            DropTable("dbo.Estado");
            DropTable("dbo.Cheque");
            DropTable("dbo.Chequera");
            DropTable("dbo.Banco");
            DropTable("dbo.CuentaBancaria");
            DropTable("dbo.Empresa");
            DropTable("dbo.TipoDocumento");
            DropTable("dbo.Provincia");
            DropTable("dbo.Pais");
            DropTable("dbo.Localidad");
            DropTable("dbo.Persona");
            DropTable("dbo.Comercio");
            DropTable("dbo.Autorizacion");
        }
    }
}
