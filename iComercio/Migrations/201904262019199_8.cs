namespace iComercio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recibo", "CreditoID", c => c.Int());
            AddColumn("dbo.Recibo", "CuotaID", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recibo", "CuotaID");
            DropColumn("dbo.Recibo", "CreditoID");
        }
    }
}
