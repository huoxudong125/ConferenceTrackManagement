namespace TW.CTM.Models
{
    public class Track
    {
        #region properties

        public TalkSession MorningSession { get; set; }

        public Break LunchBreak { get; set; }

        public TalkSession EveningSession { get; set; }

        public NetworkingEvent Networking { get; set; }

        #endregion properties
    }
}