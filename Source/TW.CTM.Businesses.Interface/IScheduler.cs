using System.Collections.Generic;
using TW.CTM.Models;

namespace TW.CTM.Businesses.Interface
{
    public interface IScheduler
    {
        Conference Schedule(IEnumerable<Talk> talks);
    }
}