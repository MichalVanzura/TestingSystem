namespace TestingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationQuestionTest : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Question", "Test_ID", "dbo.Test");
            DropIndex("dbo.Question", new[] { "Test_ID" });
            CreateTable(
                "dbo.TestQuestion",
                c => new
                    {
                        Test_ID = c.Long(nullable: false),
                        Question_ID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Test_ID, t.Question_ID })
                .ForeignKey("dbo.Test", t => t.Test_ID, cascadeDelete: true)
                .ForeignKey("dbo.Question", t => t.Question_ID, cascadeDelete: true)
                .Index(t => t.Test_ID)
                .Index(t => t.Question_ID);
            
            DropColumn("dbo.Question", "Test_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Question", "Test_ID", c => c.Long());
            DropForeignKey("dbo.TestQuestion", "Question_ID", "dbo.Question");
            DropForeignKey("dbo.TestQuestion", "Test_ID", "dbo.Test");
            DropIndex("dbo.TestQuestion", new[] { "Question_ID" });
            DropIndex("dbo.TestQuestion", new[] { "Test_ID" });
            DropTable("dbo.TestQuestion");
            CreateIndex("dbo.Question", "Test_ID");
            AddForeignKey("dbo.Question", "Test_ID", "dbo.Test", "ID");
        }
    }
}
