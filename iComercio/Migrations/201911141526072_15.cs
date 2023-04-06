namespace iComercio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _15 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CreditoAnulado", "NumCuentaBancaria", c => c.String());
            DropColumn("dbo.CreditoAnulado", "CuentaBancariaClienteID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CreditoAnulado", "CuentaBancariaClienteID", c => c.Int());
            DropColumn("dbo.CreditoAnulado", "NumCuentaBancaria");
        }
    }
}
