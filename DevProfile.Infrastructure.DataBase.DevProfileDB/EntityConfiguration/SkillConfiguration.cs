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
            builder.Property(d => d.IdDeveloper).IsRequired();
            builder.Property(d => d.IdTechnology).IsRequired();
            builder.Property(d => d.IdStack).IsRequired();

            // Table & Column Mappings
            builder.ToTable("Skill", "devprofile");
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.IdDeveloper).HasColumnName("IdDeveloper");
            builder.Property(c => c.IdTechnology).HasColumnName("IdTechnology");
            builder.Property(c => c.IdStack).HasColumnName("IdStack");
        }
    }
}
