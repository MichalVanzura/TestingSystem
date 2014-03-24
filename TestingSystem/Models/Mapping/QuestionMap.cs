using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TestingSystem.Models.Mapping
{
    public class QuestionMap : EntityTypeConfiguration<Question>
    {
        public QuestionMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Text)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Question");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Text).HasColumnName("Text");
            this.Property(t => t.QuestionType).HasColumnName("QuestionType");
            this.Property(t => t.Points).HasColumnName("Points");
            this.Property(t => t.Explanation).HasColumnName("Explanation");
            this.Property(t => t.ThematicAreaID).HasColumnName("ThematicAreaID");

            // Relationships
            this.HasMany(t => t.Tests)
                .WithMany(t => t.Questions)
                .Map(m =>
                    {
                        m.ToTable("TestQuestion");
                        m.MapLeftKey("Question_ID");
                        m.MapRightKey("Test_ID");
                    });

            this.HasRequired(t => t.ThematicArea)
                .WithMany(t => t.Questions)
                .HasForeignKey(d => d.ThematicAreaID);

        }
    }
}
