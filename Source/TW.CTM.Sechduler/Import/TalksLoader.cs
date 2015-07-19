using System.Collections.Generic;
using TW.CTM.Businesses.Interface;
using TW.CTM.Common;
using TW.CTM.Models;

namespace TW.CTM.Businesses.Import
{
    public class TalksLoader : ITalksLoader
    {
        private readonly ITalksLoadProvider _talkLoadTextFileProvider;

        public TalksLoader(ITalksLoadProvider talksLoadProvider)
        {
            Guard.ArgumentNotNull(talksLoadProvider, "talksLoadProvider");
            _talkLoadTextFileProvider = talksLoadProvider;
        }

        public List<Talk> Load()
        {
            return _talkLoadTextFileProvider.Load();
        }
    }
}