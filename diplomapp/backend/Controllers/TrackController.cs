using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrackController : ControllerBase
    {


        private readonly ILogger<TrackController> _logger;
        private readonly TrackService _trackService;

        public TrackController(ILogger<TrackController> logger, TrackService trackService)
        {
            _logger = logger;
            _trackService = trackService;
        }

        [HttpGet("GetAvailabeYears/years")]
        public async Task<IEnumerable<int>> GetAvailabeYears(CancellationToken token)
        {
            return _trackService.GetAvailabeYears();
        }

        [HttpGet("GetAllTracks")]
        public async Task<IEnumerable<InternalMusicTrack>> GetAllTracks(CancellationToken token)
        {
            return _trackService.GetAllTracksFromDb();
        }

        [HttpGet("GetTracksByYear")]
        public async Task<IEnumerable<InternalMusicTrack>> GetTracksByYears(int year, CancellationToken token)
        {
            return _trackService.GetTracksByYearsFromDb(year);
        }

        [HttpDelete("DeleteTracks")]
        public async Task DeleteTracks(CancellationToken token)
        {
            _trackService.DeleteAllTracks();
        }

        [HttpPost("UpdateTracks")]
        public async Task UpdateTracks(string artistName, CancellationToken token)
        {
            _trackService.UpdateAsync(artistName, token);
        }
    }
}