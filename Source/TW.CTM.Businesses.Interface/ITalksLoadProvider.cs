using System.Collections.Generic;
using TW.CTM.Models;

namespace TW.CTM.Businesses.Interface
{
    public interface ITalksLoadProvider
    {
        List<Talk> Load();
    }
}