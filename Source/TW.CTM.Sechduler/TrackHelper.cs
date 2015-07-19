using System;
using TW.CTM.Models;

namespace TW.CTM.Businesses
{
    public class TrackHelper
    {
        private static Track _defaultTrack;
        private static double _maxValidMinutes;

        #region properties

        public static double MaxTalkValidateMinutes
        {
            get
            {
                if (_defaultTrack == null)
                {
                    _defaultTrack = GetNewDefultTrack();

                    TimeSpan morningValidateTimeSpan = _defaultTrack.MorningSession.EndTime
                                                       - _defaultTrack.MorningSession.StartTime;

                    TimeSpan eveningValidateTimeSpan = _defaultTrack.EveningSession.EndTime
                                                       - _defaultTrack.EveningSession.StartTime;

                    _maxValidMinutes = (morningValidateTimeSpan + eveningValidateTimeSpan).TotalMinutes;
                }

                return _maxValidMinutes;
            }
        }

        #endregion properties

        public static Track GetNewDefultTrack()
        {
            var defaultTrack = new Track
            {
                MorningSession = new TalkSession
                {
                    Title = "Morning Session",
                    StartTime = new TimeSpan(09, 00, 00),
                    EndTime = new TimeSpan(12, 00, 00)
                },
                EveningSession = new TalkSession
                {
                    Title = "Evening Session",
                    StartTime = new TimeSpan(01, 00, 00),
                    EndTime = new TimeSpan(05, 00, 00)
                },
                Networking = new NetworkingEvent
                {
                    Title = "Networking Event",
                    StartTimeFrom = new TimeSpan(04, 00, 00),
                    StartTimeTo = new TimeSpan(05, 00, 00)
                },
                LunchBreak = new Break
                {
                    Title = "Lunch ",
                    StartTime = new TimeSpan(12, 00, 00),
                    EndTime = new TimeSpan(01, 00, 00)
                }
            };
            return defaultTrack;
        }
    }
}