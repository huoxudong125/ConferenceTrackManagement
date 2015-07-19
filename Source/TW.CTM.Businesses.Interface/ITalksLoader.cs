using System.Collections.Generic;
using TW.CTM.Models;

namespace TW.CTM.Businesses.Interface
{
    public interface ITalksLoader
    {
        List<Talk> Load();
    }
}