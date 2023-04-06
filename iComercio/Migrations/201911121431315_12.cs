namespace iComercio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CuentaBancariaCliente",
                c => new
                    {
                        CuentaBancariaClienteID = c.Int(nullable: false, identity: true),
                        Documento = c.Int(nullable: false),
                        TipoDocumentoID = c.String(nullable: false, maxLength: 128),
                        NumCuentaBancaria = c.String(),
                        CBU = c.String(),
                        Alias = c.String(),
                        Descripcion = c.String(),
                        Notas = c.String(),
                        FechaAlta = c.DateTime(),
                        SucursalBancoID = c.Int(),
                        BancoID = c.Int(),
                        MonedaID = c.Int(),
                        EstadoID = c.Int(),
                        sCuentaBancaria = c.String(),
                    })
                .PrimaryKey(t => t.CuentaBancariaClienteID)
                .ForeignKey("dbo.Banco", t => t.BancoID)
                .ForeignKey("dbo.Estado", t => t.EstadoID)
                .ForeignKey("dbo.Moneda", t => t.MonedaID)
                .ForeignKey("dbo.SucursalBanco", t => new { t.BancoID, t.SucursalBancoID })
                .ForeignKey("dbo.TipoDocumento", t => t.TipoDocumentoID, cascadeDelete: true)
                .ForeignKey("dbo.Cliente", t => new { t.Documento, t.TipoDocumentoID })
                .Index(t => new { t.Documento, t.TipoDocumentoID })
                .Index(t => t.TipoDocumentoID)
                .Index(t => new { t.BancoID, t.SucursalBancoID })
                .Index(t => t.BancoID)
                .Index(t => t.MonedaID)
                .Index(t => t.EstadoID);
            
            AddColumn("dbo.Credito", "CuentaBancariaClienteID", c => c.Int());
            AddColumn("dbo.Cliente", "Cuit", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CuentaBancariaCliente", new[] { "Documento", "TipoDocumentoID" }, "dbo.Cliente");
            DropForeignKey("dbo.CuentaBancariaCliente", "TipoDocumentoID", "dbo.TipoDocumento");
            DropForeignKey("dbo.CuentaBancariaCliente", new[] { "BancoID", "SucursalBancoID" }, "dbo.SucursalBanco");
            DropForeignKey("dbo.CuentaBancariaCliente", "MonedaID", "dbo.Moneda");
            DropForeignKey("dbo.CuentaBancariaCliente", "EstadoID", "dbo.Estado");
            DropForeignKey("dbo.CuentaBancariaCliente", "BancoID", "dbo.Banco");
            DropIndex("dbo.CuentaBancariaCliente", new[] { "EstadoID" });
            DropIndex("dbo.CuentaBancariaCliente", new[] { "MonedaID" });
            DropIndex("dbo.CuentaBancariaCliente", new[] { "BancoID" });
            DropIndex("dbo.CuentaBancariaCliente", new[] { "BancoID", "SucursalBancoID" });
            DropIndex("dbo.CuentaBancariaCliente", new[] { "TipoDocumentoID" });
            DropIndex("dbo.CuentaBancariaCliente", new[] { "Documento", "TipoDocumentoID" });
            DropColumn("dbo.Cliente", "Cuit");
            DropColumn("dbo.Credito", "CuentaBancariaClienteID");
            DropTable("dbo.CuentaBancariaCliente");
        }
    }
}
