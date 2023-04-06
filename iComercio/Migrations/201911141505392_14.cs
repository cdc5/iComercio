namespace iComercio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _14 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.CuentaBancariaCliente");
            AddColumn("dbo.Credito", "NumCuentaBancaria", c => c.String());
            AlterColumn("dbo.CuentaBancariaCliente", "NumCuentaBancaria", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.CuentaBancariaCliente", new[] { "Documento", "TipoDocumentoID", "NumCuentaBancaria" });
            DropColumn("dbo.Credito", "CuentaBancariaClienteID");
            DropColumn("dbo.CuentaBancariaCliente", "CuentaBancariaClienteID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CuentaBancariaCliente", "CuentaBancariaClienteID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Credito", "CuentaBancariaClienteID", c => c.Int());
            DropPrimaryKey("dbo.CuentaBancariaCliente");
            AlterColumn("dbo.CuentaBancariaCliente", "NumCuentaBancaria", c => c.String());
            DropColumn("dbo.Credito", "NumCuentaBancaria");
            AddPrimaryKey("dbo.CuentaBancariaCliente", "CuentaBancariaClienteID");
        }
    }
}
