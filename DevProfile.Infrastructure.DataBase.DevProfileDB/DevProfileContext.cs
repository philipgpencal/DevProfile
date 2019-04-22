using DevProfile.Domain.Model;
using DevProfile.Infrastructure.DataBase.DevProfileDB.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace DevProfile.Infrastructure.DataBase.DevProfileDB
{
    public class DevProfileContext : DbContext
    {
        public DevProfileContext(DbContextOptions<DevProfileContext> options) : base(options)
        {
        }

        public virtual DbSet<Developer> Developers { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<Stack> Stacks { get; set; }
        public virtual DbSet<Technology> Technologies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new StackConfiguration())
                .ApplyConfiguration(new SkillConfiguration())
                .ApplyConfiguration(new TechnologyConfiguration())
                .ApplyConfiguration(new DeveloperConfiguration());
        }
    }
}
