using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using TestingSystem.Models.Mapping;

namespace TestingSystem.Models
{
    public partial class TestingSystemContext : DbContext
    {
        static TestingSystemContext()
        {
            Database.SetInitializer<TestingSystemContext>(null);
        }

        public TestingSystemContext()
            : base("Name=TestingSystemContext")
        {
        }

        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentGroup> StudentGroups { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestTemplate> TestTemplates { get; set; }
        public DbSet<ThematicArea> ThematicAreas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AnswerMap());
            modelBuilder.Configurations.Add(new QuestionMap());
            modelBuilder.Configurations.Add(new StudentMap());
            modelBuilder.Configurations.Add(new StudentGroupMap());
            modelBuilder.Configurations.Add(new TeacherMap());
            modelBuilder.Configurations.Add(new TestMap());
            modelBuilder.Configurations.Add(new TestTemplateMap());
            modelBuilder.Configurations.Add(new ThematicAreaMap());
        }
    }
}
