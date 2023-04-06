namespace iComercio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _24 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Log",
                c => new
                    {
                        LogID = c.Long(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Usuario = c.String(maxLength: 150),
                        Host = c.String(maxLength: 150),
                        Mens = c.String(),
                    })
                .PrimaryKey(t => t.LogID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Log");
        }
    }
}
