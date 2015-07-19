using Microsoft.VisualStudio.TestTools.UnitTesting;
using TW.CTM.Models;

namespace TW.CTM.Businesses.UnitTest
{
    [TestClass]
    public class TestTalksScheduler
    {
        private Conference conference;

        // Use ClassInitialize to run code before running the first test in the class
        [TestInitialize]
        public void TestInitialize_Schedule_Talks()
        {
            conference = TestHelper.GetDemoConference();
        }

        [TestMethod]
        [DeploymentItem(@"TestData\TalkListDemo.txt")]
        public void Schedule_ConferenceTracksCount_IsRight()
        {
            Assert.AreEqual(2, conference.Tracks.Count, "The count of Conference's tracks is not right.");
        }

        [TestMethod]
        [DeploymentItem(@"TestData\TalkListDemo.txt")]
        public void Schedule_ConferenceNetworkEvent_StartTime_IsRight()
        {
            foreach (Track track in conference.Tracks)
            {
                Assert.IsTrue(track.Networking.StartTime >= track.Networking.StartTimeFrom
                    , "The Networking Event is Started earlier Than the allowed startTime  ");
                Assert.IsTrue(track.Networking.StartTime <= track.Networking.StartTimeTo
                    , "The Networking Event is Started Later Than the allowed startTime");
            }
        }

        [TestMethod]
        [DeploymentItem(@"TestData\TalkListDemo.txt")]
        public void Schedule_ConferenceMorningSeesion_RemainTime_NoLessThanZero()
        {
            foreach (Track track in conference.Tracks)
            {
                Assert.IsTrue(track.MorningSession.TimeRemaining.TotalMinutes >= 0,
                    "The Morning session is out of time range");
            }
        }

        [TestMethod]
        [DeploymentItem(@"TestData\TalkListDemo.txt")]
        public void Schedule_ConferenceEveningSession_RemainTime_NoLessThanZero()
        {
            foreach (Track track in conference.Tracks)
            {
                Assert.IsTrue(track.EveningSession.TimeRemaining.TotalMinutes >= 0,
                    "The Morning session is out of time range");
            }
        }

        [TestMethod]
        [DeploymentItem(@"TestData\TalkListDemo.txt")]
        public void Schedule_Conference_CheckSpecificTalk_IsRight()
        {
            Assert.AreEqual(2, conference.Tracks.Count);
            Track track = conference.Tracks[1];
            Assert.AreEqual(4, track.MorningSession.Talks.Count);
            StringAssert.Contains(track.MorningSession.Talks[3].Title, "Rails for Python Developers");
        }
    }
}