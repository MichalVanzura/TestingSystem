using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TestingSystem.Models.Mapping
{
    public class TestMap : EntityTypeConfiguration<Test>
    {
        public TestMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Test");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.TestTemplateID).HasColumnName("TestTemplateID");
            this.Property(t => t.result).HasColumnName("result");
            this.Property(t => t.CompletedAt).HasColumnName("CompletedAt");
            this.Property(t => t.Student_ID).HasColumnName("Student_ID");

            // Relationships
            this.HasOptional(t => t.Student)
                .WithMany(t => t.Tests)
                .HasForeignKey(d => d.Student_ID);
            this.HasRequired(t => t.TestTemplate)
                .WithMany(t => t.Tests)
                .HasForeignKey(d => d.TestTemplateID);

        }
    }
}
