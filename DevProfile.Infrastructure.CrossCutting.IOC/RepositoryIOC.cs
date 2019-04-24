using Autofac;
using DevProfile.Data.Repository;
using DevProfile.Domain.Core.Interfaces.Repository;

namespace DevProfile.Infrastructure.CrossCutting.IOC
{
    public class RepositoryIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            /*
            builder.RegisterType<TechnologyRepository>().As<ITechnologyRepository>();
            builder.RegisterType<SkillRepository>().As<ISkillRepository>();
            builder.RegisterType<StackRepository>().As<IStackRepository>();
            builder.RegisterType<DeveloperRepository>().As<IDeveloperRepository>();
            */

            builder.RegisterType<TechnologyMemoryRepository>().As<ITechnologyRepository>();
            builder.RegisterType<SkillMemoryRepository>().As<ISkillRepository>();
            builder.RegisterType<StackMemoryRepository>().As<IStackRepository>();
            builder.RegisterType<DeveloperMemoryRepository>().As<IDeveloperRepository>();
        }
    }
}