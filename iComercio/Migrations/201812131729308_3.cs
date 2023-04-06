namespace iComercio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CuentaCorriente", "GastoID", c => c.Int());
            CreateIndex("dbo.CuentaCorriente", new[] { "EmpresaID", "ComercioID", "GastoID" });
            AddForeignKey("dbo.CuentaCorriente", new[] { "EmpresaID", "ComercioID", "GastoID" }, "dbo.Gasto", new[] { "EmpresaID", "ComercioID", "GastoID" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CuentaCorriente", new[] { "EmpresaID", "ComercioID", "GastoID" }, "dbo.Gasto");
            DropIndex("dbo.CuentaCorriente", new[] { "EmpresaID", "ComercioID", "GastoID" });
            DropColumn("dbo.CuentaCorriente", "GastoID");
        }
    }
}
