namespace TestingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Question", "ThematicAreaID", "dbo.ThematicArea");
            DropForeignKey("dbo.ThematicArea", "ThematicArea_ID", "dbo.ThematicArea");
            DropIndex("dbo.Question", new[] { "ThematicAreaID" });
            DropIndex("dbo.ThematicArea", new[] { "ThematicArea_ID" });
            RenameColumn(table: "dbo.ThematicArea", name: "ThematicArea_ID", newName: "ThematicAreaID");
            AlterColumn("dbo.Question", "ThematicAreaID", c => c.Long(nullable: false));
            CreateIndex("dbo.Question", "ThematicAreaID");
            CreateIndex("dbo.ThematicArea", "ThematicAreaID");
            AddForeignKey("dbo.Question", "ThematicAreaID", "dbo.ThematicArea", "ID", cascadeDelete: true);
            AddForeignKey("dbo.ThematicArea", "ThematicAreaID", "dbo.ThematicArea", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ThematicArea", "ThematicAreaID", "dbo.ThematicArea");
            DropForeignKey("dbo.Question", "ThematicAreaID", "dbo.ThematicArea");
            DropIndex("dbo.ThematicArea", new[] { "ThematicAreaID" });
            DropIndex("dbo.Question", new[] { "ThematicAreaID" });
            AlterColumn("dbo.Question", "ThematicAreaID", c => c.Long());
            RenameColumn(table: "dbo.ThematicArea", name: "ThematicAreaID", newName: "ThematicArea_ID");
            CreateIndex("dbo.ThematicArea", "ThematicArea_ID");
            CreateIndex("dbo.Question", "ThematicAreaID");
            AddForeignKey("dbo.ThematicArea", "ThematicArea_ID", "dbo.ThematicArea", "ID");
            AddForeignKey("dbo.Question", "ThematicAreaID", "dbo.ThematicArea", "ID");
        }
    }
}
