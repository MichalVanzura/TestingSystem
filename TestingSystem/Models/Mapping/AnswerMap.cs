using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TestingSystem.Models.Mapping
{
    public class AnswerMap : EntityTypeConfiguration<Answer>
    {
        public AnswerMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Answer");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.QuestionID).HasColumnName("QuestionID");
            this.Property(t => t.Text).HasColumnName("Text");
            this.Property(t => t.IsCorrect).HasColumnName("IsCorrect");

            // Relationships
            this.HasRequired(t => t.Question)
                .WithMany(t => t.Answers)
                .HasForeignKey(d => d.QuestionID);

        }
    }
}
