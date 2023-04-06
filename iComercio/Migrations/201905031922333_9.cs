namespace iComercio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cliente", "Zona", c => c.String());
            AddColumn("dbo.Cliente", "Cod1", c => c.String());
            AddColumn("dbo.Cliente", "Cod2", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cliente", "Cod2");
            DropColumn("dbo.Cliente", "Cod1");
            DropColumn("dbo.Cliente", "Zona");
        }
    }
}
