using System.Collections.Generic;
using System.Threading.Tasks;
using MusicTutorAPI.Core.Models;

namespace MusicTutorAPI.Core.Services
{
    public interface IPupilService
    {
        Task<IEnumerable<Pupil>> GetAllPupils();
        Task<Pupil> GetPupilById();

    }
} 