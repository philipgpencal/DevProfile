using Autofac;
using DevProfile.Domain.Core.Interfaces.Services;
using DevProfile.Domain.Services;

namespace DevProfile.Infrastructure.CrossCutting.IOC
{
    public class ServicesIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TechnologyService>().As<ITechnologyService>();
            builder.RegisterType<SkillService>().As<ISkillService>();
            builder.RegisterType<StackService>().As<IStackService>();
            builder.RegisterType<DeveloperService>().As<IDeveloperService>();
        }
    }
}