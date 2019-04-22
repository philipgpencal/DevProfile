using DevProfile.Domain.Core.Interfaces.Repository;
using DevProfile.Domain.Core.Interfaces.Services;
using DevProfile.Domain.Model;

namespace DevProfile.Domain.Services
{
    public class TechnologyService : BaseService<Technology>, ITechnologyService
    {
        private readonly ITechnologyRepository technologyRepository;

        public TechnologyService(ITechnologyRepository technologyRepository) : base(technologyRepository)
        {
            this.technologyRepository = technologyRepository;
        }
    }
}
