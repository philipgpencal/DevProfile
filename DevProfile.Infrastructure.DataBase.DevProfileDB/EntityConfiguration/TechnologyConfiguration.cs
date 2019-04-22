using DevProfile.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevProfile.Infrastructure.DataBase.DevProfileDB.EntityConfiguration
{
    public class TechnologyConfiguration : IEntityTypeConfiguration<Technology>
    {
        public void Configure(EntityTypeBuilder<Technology> builder)
        {
            builder.HasKey(d => d.Id);

            // Properties
            builder.Property(d => d.Name).IsRequired().HasMaxLength(50);
            builder.Property(d => d.Description).HasMaxLength(500);
            builder.Property(d => d.Enabled).IsRequired();

            // Table & Column Mappings
            builder.ToTable("Technology", "devprofile");
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.Name).HasColumnName("Name");
            builder.Property(c => c.Description).HasColumnName("Description");
            builder.Property(c => c.Enabled).HasColumnName("Enabled");
        }
    }
}
