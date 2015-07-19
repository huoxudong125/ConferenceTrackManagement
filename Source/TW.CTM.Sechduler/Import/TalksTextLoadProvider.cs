using System.Collections.Generic;
using TW.CTM.Businesses.Interface;
using TW.CTM.Common;
using TW.CTM.Models;

namespace TW.CTM.Businesses.Import
{
    public class TalksTextLoadProvider : ITalksLoadProvider
    {
        private readonly string _talksStr;

        public TalksTextLoadProvider(string talksStr)
        {
            Guard.ArgumentNotNullOrEmpty(talksStr, "talkStr");
            _talksStr = talksStr;
        }

        public List<Talk> Load()
        {
            var talks = new List<Talk>();
            var talkDescriptionArrary = _talksStr.Split(new[] { '\n' });
            foreach (var str in talkDescriptionArrary)
            {
                if (string.IsNullOrEmpty(str))
                    continue;

                var talk = TalkHelper.Parse(str.Replace('\r', ' ').Trim());
                if (talk != null)
                {
                    talks.Add(talk);
                }
            }

            return talks;
        }
    }
}