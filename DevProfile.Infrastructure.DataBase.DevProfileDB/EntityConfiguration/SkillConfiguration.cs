using DevProfile.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevProfile.Infrastructure.DataBase.DevProfileDB.EntityConfiguration
{
    public class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.HasKey(d => d.Id);

            // Properties
            builder.Property(d => d.DeveloperId).IsRequired();
            builder.Property(d => d.TechnologyId).IsRequired();
            builder.Property(d => d.StackId).IsRequired();

            // Table & Column Mappings
            builder.ToTable("Skill", "devprofile");
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.DeveloperId).HasColumnName("DeveloperId");
            builder.Property(c => c.TechnologyId).HasColumnName("TechnologyId");
            builder.Property(c => c.StackId).HasColumnName("StackId");
        }
    }
}
