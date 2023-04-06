namespace iComercio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gasto", "EstadoID", c => c.Int());
            CreateIndex("dbo.Gasto", "EstadoID");
            AddForeignKey("dbo.Gasto", "EstadoID", "dbo.Estado", "EstadoID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gasto", "EstadoID", "dbo.Estado");
            DropIndex("dbo.Gasto", new[] { "EstadoID" });
            DropColumn("dbo.Gasto", "EstadoID");
        }
    }
}
