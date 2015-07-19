using System;
using System.Collections.Generic;
using TW.CTM.Businesses.Interface;
using TW.CTM.Common.Extends;
using TW.CTM.Models;

namespace TW.CTM.Businesses
{
    public class TalksExporter
    {
        private readonly ITalksExportProvider _exporterProvider;

        #region .octor

        public TalksExporter(ITalksExportProvider exportProvider)
        {
            _exporterProvider = exportProvider;
        }

        #endregion .octor

        #region public functions

        public void Export(IList<Track> tracks)
        {
            for (int i = 0; i < tracks.Count; i++)
            {
                Track track = tracks[i];

                //Track info
                string lineStr = string.Format("\nTrack {0} :", (i + 1));
                _exporterProvider.ExportLine(lineStr);
                //MoningSession
                ExportMorningSession(track);

                //Lunch
                ExportLine_PM_Format(track.LunchBreak.StartTime, track.LunchBreak.Title);
                //EveningSession
                ExportEveningSession(track);

                //Networking event
                ExportLine_PM_Format(track.Networking.StartTime, track.Networking.Title);
            }
        }

        #endregion public functions

        #region private functions

        private void ExportMorningSession(Track track)
        {
            var currentTime = track.MorningSession.StartTime;
            foreach (Talk talk in track.MorningSession.Talks)
            {
                string lineStr = string.Format("{0}AM \t{1}", currentTime.ToStringHhMm(), talk);
                _exporterProvider.ExportLine(lineStr);
                currentTime = currentTime.AddMinutes(talk.Length);
            }
        }

        private void ExportEveningSession(Track track)
        {
            TimeSpan currentTime = track.EveningSession.StartTime;
            foreach (Talk talk in track.EveningSession.Talks)
            {
                ExportLine_PM_Format(currentTime, talk.ToString());
                currentTime = currentTime.AddMinutes(talk.Length);
            }
        }

        private void ExportLine_PM_Format(TimeSpan timeSpan, string content)
        {
            string lineStr = string.Format("{0}PM \t{1}", timeSpan.ToStringHhMm(), content);
            _exporterProvider.ExportLine(lineStr);
        }

        #endregion private functions
    }
}