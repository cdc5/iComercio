namespace iComercio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _22 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comercio", "CantCuoArr", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comercio", "CantCuoArr");
        }
    }
}
