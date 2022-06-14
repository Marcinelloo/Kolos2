using Microsoft.EntityFrameworkCore;
using kolos2.Entities;
using kolos2.Entities.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolos2.Services
{
    public class RepoService : IRepoService
    {
        private readonly RepositoryContext _repository;
        public RepoService(RepositoryContext repository)
        {
            _repository = repository;
        }

        public async Task<Musican> GetMusicanById(int id)
        {
            return await _repository.Musican.Where(e => e.IdMusican == id).FirstOrDefaultAsync();
        }

        public async Task<List<Track>> GetMusicanTracks(int id)
        {

            return await _repository.MusicanTrack.Where(e => e.IdMusican == id).Select(e => e.Track).OrderBy(e => e.Duration).ToListAsync();
        }

        public async Task<List<Track>> GetMusicanTracksWhereAlbumDoesntExist(int id)
        {
            return await _repository.MusicanTrack.Where(e => e.IdMusican == id).Select(e => e.Track).Where(e => e.IdMusicAlbum == null).ToListAsync();
        }

        public bool DeleteMusican(int id)
        {
            var musican = new Musican() { IdMusican = id };
            _repository.Musican.Attach(musican);
            _repository.Musican.Remove(musican);

            return true;
        }

        public bool DeleteTrack(int id)
        {
            var track = new Track() { IdTrack = id };
            _repository.Track.Attach(track);
            _repository.Track.Remove(track);

            return true;
        }

        public bool DeleteMusicanTrack(int IdTrack, int IdMusican)
        {

            var musicanTrack = new MusicanTrack() { IdMusican = IdMusican, IdTrack = IdTrack };
            _repository.MusicanTrack.Attach(musicanTrack);
            _repository.MusicanTrack.Remove(musicanTrack);

            return true;
        }

    }
}
