using System;
using System.Collections.Generic;

namespace TW.CTM.Models
{
    public abstract class Session
    {
        public string Title { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }
    }

    public class TalkSession : Session
    {
        public List<Talk> Talks { get; set; }

        public TimeSpan TimeRemaining { get; set; }
    }

    public class NetworkingEvent : Session
    {
        public TimeSpan StartTimeFrom { get; set; }

        public TimeSpan StartTimeTo { get; set; }
    }

    public class Break : Session
    {
    }
}