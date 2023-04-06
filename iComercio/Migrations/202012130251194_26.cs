namespace iComercio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _26 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comercio", "ToleranciaBoni", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comercio", "ToleranciaBoni");
        }
    }
}
