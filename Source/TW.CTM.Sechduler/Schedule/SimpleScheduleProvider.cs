using System;
using System.Collections.Generic;
using System.Linq;
using TW.CTM.Common;
using TW.CTM.Common.Extends;
using TW.CTM.Models;

namespace TW.CTM.Businesses
{
    public class SimpleScheduleProvider : ITalksScheduleProvider
    {
        public List<Track> Schedule(IEnumerable<Talk> talks)
        {
            var talksOrderedList = talks.OrderByDescending(t => t.Length).ToList();//assign the long talk first

            var tracks = GenerateTracks(talksOrderedList);
            InitializeTracks(tracks);

            foreach (var talk in talksOrderedList)
            {
                var isScheduledInMorning = ScheduleInMorning(talk, tracks);

                if (!isScheduledInMorning)
                {
                    ScheduleInEvening(talk, tracks);
                }
            }
            ScheduleNetworkingEvent(tracks);

            return tracks;
        }

        private List<Track> GenerateTracks(IEnumerable<Talk> talks)
        {
            Guard.ArgumentNotNull(talks, "Talks");
            var tracks = new List<Track>();

            var validTalksMinutesOfTrack = TrackHelper.MaxTalkValidateMinutes;
            int allTalkTimeMinutes = talks.Sum(t => t.Length);
            var needTracksCount = (int)Math.Ceiling(allTalkTimeMinutes / validTalksMinutesOfTrack);
            if (needTracksCount > 0)
            {
                for (int i = 0; i < needTracksCount; i++)
                {
                    tracks.Add(TrackHelper.GetNewDefultTrack());
                }
            }
            return tracks;
        }

        private void InitializeTracks(IEnumerable<Track> tracks)
        {
            foreach (var track in tracks)
            {
                track.MorningSession.Talks = new List<Talk>();
                track.MorningSession.TimeRemaining =
                    track.MorningSession.EndTime.Subtract(track.MorningSession.StartTime);

                track.EveningSession.Talks = new List<Talk>();
                track.EveningSession.TimeRemaining =
                    track.EveningSession.EndTime.Subtract(track.EveningSession.StartTime);
            }
        }

        private bool ScheduleInMorning(Talk talk, IEnumerable<Track> tracks)
        {
            foreach (var track in tracks)
            {
                if (TalkCanBeScheduledInMorning(talk, track))
                {
                    track.MorningSession.Talks.Add(talk);
                    track.MorningSession.TimeRemaining = track.MorningSession
                        .TimeRemaining.Subtract(new TimeSpan(0, talk.Length, 0));
                    return true;
                }
            }
            return false;
        }

        private bool TalkCanBeScheduledInMorning(Talk talk, Track track)
        {
            return track.MorningSession != null && (talk.Length <= track.MorningSession.TimeRemaining.TotalMinutes);
        }

        private bool ScheduleInEvening(Talk talk, IEnumerable<Track> tracks)
        {
            foreach (var track in tracks)
            {
                var duration = talk.Length;
                if (TalkCanBeScheduledInEvening(talk, track))
                {
                    track.EveningSession.Talks.Add(talk);
                    track.EveningSession.TimeRemaining = track.EveningSession
                        .TimeRemaining.Subtract(new TimeSpan(0, duration, 0));
                    return true;
                }
            }
            return false;
        }

        private bool TalkCanBeScheduledInEvening(Talk talk, Track track)
        {
            return (talk.Length <= track.EveningSession.TimeRemaining.TotalMinutes);
        }

        private void ScheduleNetworkingEvent(IEnumerable<Track> tracks)
        {
            foreach (var track in tracks)
            {
                var canStartTime = track.EveningSession.EndTime.Subtract(track.EveningSession.TimeRemaining);
                if (canStartTime <= track.Networking.StartTimeFrom)
                {
                    canStartTime = track.Networking.StartTimeFrom;
                }
                else if (canStartTime > track.Networking.StartTimeTo)
                {
                    throw new ArgumentOutOfRangeException(
                        string.Format("Network Event must start no later than {0}", track.Networking.StartTimeTo.ToStringHhMm()));
                }
                track.Networking.StartTime = canStartTime;
            }
        }
    }
}