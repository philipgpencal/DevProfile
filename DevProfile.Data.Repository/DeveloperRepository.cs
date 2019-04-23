using DevProfile.Domain.Core.Interfaces.Repository;
using DevProfile.Domain.Model;
using DevProfile.Infrastructure.DataBase.DevProfileDB;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DevProfile.Data.Repository
{
    public class DeveloperRepository : BaseRepository<Developer>, IDeveloperRepository
    {
        private readonly DevProfileContext devProfileContext;

        public DeveloperRepository(DevProfileContext devProfileContext) : base (devProfileContext)
        {
            this.devProfileContext = devProfileContext;
        }
    }
}
