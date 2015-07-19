using System.Collections.Generic;
using TW.CTM.Models;

namespace TW.CTM.Businesses
{
    public interface ITalksScheduleProvider
    {
        List<Track> Schedule(IEnumerable<Talk> talks);
    }
}