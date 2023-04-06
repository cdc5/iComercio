namespace iComercio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _19 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CreditoAnulado", "FechaDesdeDebito", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CreditoAnulado", "FechaDesdeDebito", c => c.DateTime(nullable: false));
        }
    }
}
