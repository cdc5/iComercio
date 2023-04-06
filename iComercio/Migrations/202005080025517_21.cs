namespace iComercio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _21 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.CuentaCorriente", new[] { "EmpresaID", "ComercioID", "CreditoID", "CuotaID", "CobranzaID" });
            DropIndex("dbo.CuentaCorriente", new[] { "EmpresaID", "ComercioID", "GastoID" });
            DropIndex("dbo.CuentaCorriente", new[] { "EmpresaID", "ComercioID", "CreditoID", "CuotaID", "CobranzaID", "NotaCDID" });
            DropIndex("dbo.CuentaCorriente", new[] { "EmpresaID", "ComercioID", "PagoID" });
            DropIndex("dbo.CuentaCorriente", new[] { "EmpresaID", "ComercioID", "ReciboID" });
            DropIndex("dbo.CuentaCorriente", new[] { "EmpresaID", "ComercioID", "SolicitudFondoID" });
           
            CreateIndex("dbo.CuentaCorriente", new[] { "EmpresaID", "ComercioID", "CreditoID", "CuotaID", "CobranzaID" });
            CreateIndex("dbo.CuentaCorriente", new[] { "EmpresaID", "ComercioID", "GastoID" });
            CreateIndex("dbo.CuentaCorriente", new[] { "EmpresaID", "ComercioID", "CreditoID", "CuotaID", "CobranzaID", "NotaCDID" });
            CreateIndex("dbo.CuentaCorriente", new[] { "EmpresaID", "ComercioID", "PagoID" });
            CreateIndex("dbo.CuentaCorriente", new[] { "EmpresaID", "GestionID", "ReciboID" });
            CreateIndex("dbo.CuentaCorriente", new[] { "EmpresaID", "ComercioID", "SolicitudFondoID" });
        }
        
        public override void Down()
        {
            DropIndex("dbo.CuentaCorriente", new[] { "EmpresaID", "ComercioID", "SolicitudFondoID" });
            DropIndex("dbo.CuentaCorriente", new[] { "EmpresaID", "GestionID", "ReciboID" });
            DropIndex("dbo.CuentaCorriente", new[] { "EmpresaID", "ComercioID", "PagoID" });
            DropIndex("dbo.CuentaCorriente", new[] { "EmpresaID", "ComercioID", "CreditoID", "CuotaID", "CobranzaID", "NotaCDID" });
            DropIndex("dbo.CuentaCorriente", new[] { "EmpresaID", "ComercioID", "GastoID" });
            DropIndex("dbo.CuentaCorriente", new[] { "EmpresaID", "ComercioID", "CreditoID", "CuotaID", "CobranzaID" });
            
            CreateIndex("dbo.CuentaCorriente", new[] { "EmpresaID", "ComercioID", "SolicitudFondoID" });
            CreateIndex("dbo.CuentaCorriente", new[] { "EmpresaID", "ComercioID", "ReciboID" });
            CreateIndex("dbo.CuentaCorriente", new[] { "EmpresaID", "ComercioID", "PagoID" });
            CreateIndex("dbo.CuentaCorriente", new[] { "EmpresaID", "ComercioID", "CreditoID", "CuotaID", "CobranzaID", "NotaCDID" });
            CreateIndex("dbo.CuentaCorriente", new[] { "EmpresaID", "ComercioID", "GastoID" });
            CreateIndex("dbo.CuentaCorriente", new[] { "EmpresaID", "ComercioID", "CreditoID", "CuotaID", "CobranzaID" });
        }
    }
}
