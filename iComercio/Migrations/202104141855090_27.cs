namespace iComercio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _27 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CuentaBancaria", "orden", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CuentaBancaria", "orden");
        }
    }
}
