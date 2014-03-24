using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TestingSystem.Models.Mapping
{
    public class TestTemplateMap : EntityTypeConfiguration<TestTemplate>
    {
        public TestTemplateMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("TestTemplate");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Time).HasColumnName("Time");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
            this.Property(t => t.StudentGroupID).HasColumnName("StudentGroupID");

            // Relationships
            this.HasRequired(t => t.StudentGroup)
                .WithMany(t => t.TestTemplates)
                .HasForeignKey(d => d.StudentGroupID);

        }
    }
}
