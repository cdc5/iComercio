namespace iComercio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _25 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Log", "Tipo", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Log", "Tipo");
        }
    }
}
