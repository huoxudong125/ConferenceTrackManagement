using System.Collections.Generic;
using System.Collections.ObjectModel;
using TW.CTM.Common;

namespace TW.CTM.Models
{
    public class Conference
    {
        private readonly IList<Track> _tracks;

        public ReadOnlyCollection<Track> Tracks
        {
            get { return new ReadOnlyCollection<Track>(_tracks); }
        }

        public Conference(IList<Track> tracks)
        {
            Guard.ArgumentNotNull(tracks, "Tracks");
            _tracks = tracks;
        }
    }
}