namespace iComercio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Mail", "Fecha", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Nota", "Fecha", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Telefono", "Fecha", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Telefono", "Fecha", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Nota", "Fecha", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Mail", "Fecha", c => c.DateTime(nullable: false));
        }
    }
}
