using System.Collections.Generic;
using TW.CTM.Businesses.Interface;
using TW.CTM.Common;
using TW.CTM.Models;

namespace TW.CTM.Businesses
{
    public class Scheduler : IScheduler
    {
        private readonly ITalksScheduleProvider _simpleScheduleProvider;

        #region .octr

        public Scheduler(ITalksScheduleProvider talkScheduleProvider)
        {
            _simpleScheduleProvider = talkScheduleProvider;
        }

        #endregion .octr

        public Conference Schedule(IEnumerable<Talk> talks)
        {
            Guard.ArgumentNotNull(talks, "Talks");
            var conference = new Conference(_simpleScheduleProvider.Schedule(talks));
            return conference;
        }
    }
}