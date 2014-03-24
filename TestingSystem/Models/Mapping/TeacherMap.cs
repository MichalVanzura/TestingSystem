using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TestingSystem.Models.Mapping
{
    public class TeacherMap : EntityTypeConfiguration<Teacher>
    {
        public TeacherMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.LastName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Teacher");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.BirthDate).HasColumnName("BirthDate");
            this.Property(t => t.RegisterDate).HasColumnName("RegisterDate");
            this.Property(t => t.Student_ID).HasColumnName("Student_ID");

            // Relationships
            this.HasOptional(t => t.Student)
                .WithMany(t => t.Teachers)
                .HasForeignKey(d => d.Student_ID);

        }
    }
}
