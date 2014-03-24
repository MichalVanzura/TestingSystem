using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TestingSystem.Models.Mapping
{
    public class ThematicAreaMap : EntityTypeConfiguration<ThematicArea>
    {
        public ThematicAreaMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ThematicArea");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.ThematicAreaID).HasColumnName("ThematicAreaID");
            this.Property(t => t.TestTemplate_ID).HasColumnName("TestTemplate_ID");

            // Relationships
            this.HasOptional(t => t.TestTemplate)
                .WithMany(t => t.ThematicAreas)
                .HasForeignKey(d => d.TestTemplate_ID);
            this.HasOptional(t => t.ThematicArea2)
                .WithMany(t => t.ThematicArea1)
                .HasForeignKey(d => d.ThematicAreaID);

        }
    }
}
