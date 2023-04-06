namespace iComercio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _23 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comercio", "Actualiza", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comercio", "Actualiza");
        }
    }
}
