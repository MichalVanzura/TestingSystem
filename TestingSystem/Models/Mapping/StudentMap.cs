using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TestingSystem.Models.Mapping
{
    public class StudentMap : EntityTypeConfiguration<Student>
    {
        public StudentMap()
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
            this.ToTable("Student");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.BirthDate).HasColumnName("BirthDate");
            this.Property(t => t.RegisterDate).HasColumnName("RegisterDate");

            // Relationships
            this.HasMany(t => t.StudentGroups)
                .WithMany(t => t.Students)
                .Map(m =>
                    {
                        m.ToTable("StudentStudentGroup");
                        m.MapLeftKey("Student_ID");
                        m.MapRightKey("StudentGroup_ID");
                    });


        }
    }
}
