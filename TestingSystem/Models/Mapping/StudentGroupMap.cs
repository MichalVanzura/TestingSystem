using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TestingSystem.Models.Mapping
{
    public class StudentGroupMap : EntityTypeConfiguration<StudentGroup>
    {
        public StudentGroupMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("StudentGroup");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.TeacherID).HasColumnName("TeacherID");

            // Relationships
            this.HasRequired(t => t.Teacher)
                .WithMany(t => t.StudentGroups)
                .HasForeignKey(d => d.TeacherID);

        }
    }
}
