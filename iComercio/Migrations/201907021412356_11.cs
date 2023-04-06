namespace iComercio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _11 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Refinanciacion", "FechaComerAnula", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Refinanciacion", "FechaComerAnula", c => c.DateTime(nullable: false));
        }
    }
}
