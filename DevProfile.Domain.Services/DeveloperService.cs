using DevProfile.Domain.Core.Interfaces.Repository;
using DevProfile.Domain.Core.Interfaces.Services;
using DevProfile.Domain.Model;

namespace DevProfile.Domain.Services
{
    public class DeveloperService : BaseService<Developer>, IDeveloperService
    {
        private readonly IDeveloperRepository developerRepository;

        public DeveloperService(IDeveloperRepository developerRepository) : base(developerRepository)
        {
            this.developerRepository = developerRepository;
        }
    }
}
