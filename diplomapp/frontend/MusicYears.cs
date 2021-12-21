using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend
{
    public class MusicYear
    {
        public MusicYear(
            string trackYear
            )
        {     
            TrackYear = trackYear;
        }
        public string TrackYear { get; }
    }
}
