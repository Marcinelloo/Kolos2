using kolos2.Entities.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolos2.Services
{
    public interface IRepoService
    {
        Task<Musican> GetMusicanById(int id);
        Task<List<Track>> GetMusicanTracks(int id);

        Task<List<Track>> GetMusicanTracksWhereAlbumDoesntExist(int id);

        bool DeleteMusican(int id);

        bool DeleteTrack(int id);

        bool DeleteMusicanTrack(int id1, int id2);
    }
}
