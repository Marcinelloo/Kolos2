using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using kolos2.DTOs;
using kolos2.Entities.Models;
using kolos2.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace kolos2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicanTrackController : ControllerBase
    {

        private readonly IRepoService _service;

        public MusicanTrackController(IRepoService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            var musican = await _service.GetMusicanById(id);

            if (musican is null)
                return NotFound("muscian doesnt exist");

            var tracks = await _service.GetMusicanTracks(id);

            if (tracks is null)
                return NotFound("tracks doesnt exist");

            var result = new MusicanGet
            {
                Musican = musican,
                Tracks = tracks,
            };

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var musican = await _service.GetMusicanById(id);

            if (musican is null)
                return NotFound("muscian doesnt exist");

            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {

                try
                {
                    var tracks = await _service.GetMusicanTracks(id);

                    if (tracks is null)
                    {
                        return BadRequest("nie mozna usunac bo nie ma utworow ktore nie pojawily sie w albumach");
                    }

                    _service.DeleteMusican(id);

                    foreach (var track in tracks)
                    {
                        // _service.DeleteMusicanTrack(track.IdTrack);
                    }

                    scope.Complete();

                }
                catch (Exception)
                {
                    return Problem("Nieoczekiwany błąd serwera");
                }
            }

            return NoContent();

        }
    }
}
