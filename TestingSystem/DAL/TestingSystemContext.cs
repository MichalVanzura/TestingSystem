using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestingSystem.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TestingSystem.DAL
{
    public class TestingSystemContext : DbContext
    {
        public TestingSystemContext()
            : base("TestingSystemContext")
        {
        }

        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentGroup> StudentGroups { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TestTemplate> TestTemplates { get; set; }
        public DbSet<ThematicArea> ThematicAreas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}