using Autofac;
using DevProfile.Application.Services;
using DevProfile.Application.Services.Interfaces;

namespace DevProfile.Infrastructure.CrossCutting.IOC
{
    public class AppServicesIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProfileAppService>().As<IProfileAppService>();
        }
    }
}