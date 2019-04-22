using DevProfile.Domain.Core.Interfaces.Services;

namespace DevProfile.Domain.Services
{
    public class DeveloperService : IDeveloperService
    {
        public string Test()
        {
            return "TESTE IOC";
        }
    }
}
