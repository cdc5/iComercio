namespace iComercio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transmision", "CantTransmisiones", c => c.Int());
            AddColumn("dbo.Transmision", "UltimaTransmision", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transmision", "UltimaTransmision");
            DropColumn("dbo.Transmision", "CantTransmisiones");
        }
    }
}
