using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracksMusicApi
{
    public class InternalMusicTrack
    {
        public InternalMusicTrack(string kind, 
            string collectionName, 
            string trackName, 
            double collectionPrice, 
            double trackPrice, 
            DateTime releaseDate, 
            int trackCount, 
            int trackNumber, 
            string primaryGenreName)
        {
            Kind = kind;
            CollectionName = collectionName;
            TrackName = trackName;
            CollectionPrice = collectionPrice;
            TrackPrice = trackPrice;
            ReleaseDate = releaseDate;
            TrackCount = trackCount;
            TrackNumber = trackNumber;
            PrimaryGenreName = primaryGenreName;
        }

        public string Kind { get; }
        public string CollectionName { get; }
        public string TrackName { get; }
        public double CollectionPrice { get;  }
        public double TrackPrice { get;  }
        public DateTime ReleaseDate { get;  }
        public int TrackCount { get;  }
        public int TrackNumber { get; }
        public string PrimaryGenreName { get; }
    }
}
