using Autofac;

namespace DevProfile.Infrastructure.CrossCutting.IOC
{
    public class DevProfileIOC : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RepositoryIOC.Load(builder);
            ServicesIOC.Load(builder);
        }
    }
}
