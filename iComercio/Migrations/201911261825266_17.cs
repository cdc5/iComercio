namespace iComercio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _17 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CreditoAnulado", "FechaDesdeDebito", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CreditoAnulado", "FechaDesdeDebito");
        }
    }
}
