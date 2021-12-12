using Microsoft.AspNetCore.Mvc;

namespace TracksMusicApi.Controllers
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

        [HttpGet(Name = "GetTracks")]
        public async Task<IEnumerable<InternalMusicTrack>> Get(string artistName, CancellationToken token)
        {
            return await _trackService.GetTracksAsync(artistName, token);
        }
    }
}