using DevProfile.Application.DTO;
using System.Collections.Generic;

namespace DevProfile.Application.Services.Interfaces
{
    public interface IProfileAppService
    {
        void SaveNewProfile(ProfileDTO profileDTO);
        List<FullProfileDTO> GetAll();
        FullProfileDTO GetByDeveloperId(int developerId);
        void DeleteProfile(int developerId);
    }
}
