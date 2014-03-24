namespace TestingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answer",
                c => new
                {
                    ID = c.Long(nullable: false, identity: true),
                    QuestionID = c.Long(nullable: false),
                    Text = c.String(),
                    IsCorrect = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Question", t => t.QuestionID, cascadeDelete: true)
                .Index(t => t.QuestionID);

            CreateTable(
                "dbo.Question",
                c => new
                {
                    ID = c.Long(nullable: false, identity: true),
                    Text = c.String(nullable: false),
                    QuestionType = c.Int(),
                    Points = c.Double(nullable: false),
                    Explanation = c.String(),
                    ThematicAreaID = c.Long(),
                    Test_ID = c.Long(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ThematicArea", t => t.ThematicAreaID)
                .ForeignKey("dbo.Test", t => t.Test_ID)
                .Index(t => t.ThematicAreaID)
                .Index(t => t.Test_ID);

            CreateTable(
                "dbo.ThematicArea",
                c => new
                {
                    ID = c.Long(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 50),
                    ThematicArea_ID = c.Long(),
                    TestTemplate_ID = c.Long(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ThematicArea", t => t.ThematicArea_ID)
                .ForeignKey("dbo.TestTemplate", t => t.TestTemplate_ID)
                .Index(t => t.ThematicArea_ID)
                .Index(t => t.TestTemplate_ID);

            CreateTable(
                "dbo.StudentGroup",
                c => new
                {
                    ID = c.Long(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 50),
                    TeacherID = c.Long(nullable: false),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Teacher", t => t.TeacherID, cascadeDelete: true)
                .Index(t => t.TeacherID);

            CreateTable(
                "dbo.Student",
                c => new
                {
                    ID = c.Long(nullable: false, identity: true),
                    FirstName = c.String(nullable: false, maxLength: 50),
                    LastName = c.String(nullable: false, maxLength: 50),
                    BirthDate = c.DateTime(nullable: false),
                    RegisterDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Teacher",
                c => new
                {
                    ID = c.Long(nullable: false, identity: true),
                    FirstName = c.String(nullable: false, maxLength: 50),
                    LastName = c.String(nullable: false, maxLength: 50),
                    BirthDate = c.DateTime(nullable: false),
                    RegisterDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                    Student_ID = c.Long(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Student", t => t.Student_ID)
                .Index(t => t.Student_ID);

            CreateTable(
                "dbo.Test",
                c => new
                {
                    ID = c.Long(nullable: false, identity: true),
                    TestTemplateID = c.Long(nullable: false),
                    result = c.Double(nullable: false),
                    CompletedAt = c.DateTime(nullable: false),
                    Student_ID = c.Long(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TestTemplate", t => t.TestTemplateID, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.Student_ID)
                .Index(t => t.TestTemplateID)
                .Index(t => t.Student_ID);

            CreateTable(
                "dbo.TestTemplate",
                c => new
                {
                    ID = c.Long(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 50),
                    Time = c.DateTime(nullable: false),
                    StartDate = c.DateTime(nullable: false),
                    EndDate = c.DateTime(nullable: false),
                    StudentGroupID = c.Long(nullable: false),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.StudentGroup", t => t.StudentGroupID, cascadeDelete: true)
                .Index(t => t.StudentGroupID);

            CreateTable(
                "dbo.StudentStudentGroup",
                c => new
                {
                    Student_ID = c.Long(nullable: false),
                    StudentGroup_ID = c.Long(nullable: false),
                })
                .PrimaryKey(t => new { t.Student_ID, t.StudentGroup_ID })
                .ForeignKey("dbo.Student", t => t.Student_ID, cascadeDelete: true)
                .ForeignKey("dbo.StudentGroup", t => t.StudentGroup_ID, cascadeDelete: true)
                .Index(t => t.Student_ID)
                .Index(t => t.StudentGroup_ID);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Test", "Student_ID", "dbo.Student");
            DropForeignKey("dbo.Test", "TestTemplateID", "dbo.TestTemplate");
            DropForeignKey("dbo.ThematicArea", "TestTemplate_ID", "dbo.TestTemplate");
            DropForeignKey("dbo.TestTemplate", "StudentGroupID", "dbo.StudentGroup");
            DropForeignKey("dbo.Question", "Test_ID", "dbo.Test");
            DropForeignKey("dbo.Teacher", "Student_ID", "dbo.Student");
            DropForeignKey("dbo.StudentGroup", "TeacherID", "dbo.Teacher");
            DropForeignKey("dbo.StudentStudentGroup", "StudentGroup_ID", "dbo.StudentGroup");
            DropForeignKey("dbo.StudentStudentGroup", "Student_ID", "dbo.Student");
            DropForeignKey("dbo.ThematicArea", "ThematicArea_ID", "dbo.ThematicArea");
            DropForeignKey("dbo.Question", "ThematicAreaID", "dbo.ThematicArea");
            DropForeignKey("dbo.Answer", "QuestionID", "dbo.Question");
            DropIndex("dbo.Test", new[] { "Student_ID" });
            DropIndex("dbo.Test", new[] { "TestTemplateID" });
            DropIndex("dbo.ThematicArea", new[] { "TestTemplate_ID" });
            DropIndex("dbo.TestTemplate", new[] { "StudentGroupID" });
            DropIndex("dbo.Question", new[] { "Test_ID" });
            DropIndex("dbo.Teacher", new[] { "Student_ID" });
            DropIndex("dbo.StudentGroup", new[] { "TeacherID" });
            DropIndex("dbo.StudentStudentGroup", new[] { "StudentGroup_ID" });
            DropIndex("dbo.StudentStudentGroup", new[] { "Student_ID" });
            DropIndex("dbo.ThematicArea", new[] { "ThematicArea_ID" });
            DropIndex("dbo.Question", new[] { "ThematicAreaID" });
            DropIndex("dbo.Answer", new[] { "QuestionID" });
            DropTable("dbo.StudentStudentGroup");
            DropTable("dbo.TestTemplate");
            DropTable("dbo.Test");
            DropTable("dbo.Teacher");
            DropTable("dbo.Student");
            DropTable("dbo.StudentGroup");
            DropTable("dbo.ThematicArea");
            DropTable("dbo.Question");
            DropTable("dbo.Answer");
        }
    }
}
