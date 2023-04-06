namespace iComercio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CuentaCorriente", "PagoID", c => c.Int());
            CreateIndex("dbo.CuentaCorriente", new[] { "EmpresaID", "ComercioID", "PagoID" });
            AddForeignKey("dbo.CuentaCorriente", new[] { "EmpresaID", "ComercioID", "PagoID" }, "dbo.Pago", new[] { "EmpresaID", "ComercioID", "PagoID" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CuentaCorriente", new[] { "EmpresaID", "ComercioID", "PagoID" }, "dbo.Pago");
            DropIndex("dbo.CuentaCorriente", new[] { "EmpresaID", "ComercioID", "PagoID" });
            DropColumn("dbo.CuentaCorriente", "PagoID");
        }
    }
}
