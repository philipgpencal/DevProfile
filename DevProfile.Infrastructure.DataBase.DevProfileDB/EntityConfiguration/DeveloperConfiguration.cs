using DevProfile.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevProfile.Infrastructure.DataBase.DevProfileDB.EntityConfiguration
{
    public class DeveloperConfiguration : IEntityTypeConfiguration<Developer>
    {
        public void Configure(EntityTypeBuilder<Developer> builder)
        {
            builder.HasKey(d => d.Id);

            // Properties
            builder.Property(d => d.Name).IsRequired().HasMaxLength(50);

            //Relationships
            builder.HasMany(d => d.Skills).WithOne(s => s.Developer).HasForeignKey(s => s.DeveloperId);

            // Table & Column Mappings
            builder.ToTable("Developer", "devprofile");
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.Name).HasColumnName("Name");
        }
    }
}
