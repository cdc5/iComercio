namespace iComercio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _28 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlanesTipo", "TipoRetencionPlanID", c => c.String(maxLength: 128));
            CreateIndex("dbo.PlanesTipo", "TipoRetencionPlanID");
            AddForeignKey("dbo.PlanesTipo", "TipoRetencionPlanID", "dbo.TipoRetencionPlan", "TipoRetencionPlanID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlanesTipo", "TipoRetencionPlanID", "dbo.TipoRetencionPlan");
            DropIndex("dbo.PlanesTipo", new[] { "TipoRetencionPlanID" });
            DropColumn("dbo.PlanesTipo", "TipoRetencionPlanID");
        }
    }
}
