using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TW.CTM.Businesses.Import;
using TW.CTM.Models;

namespace TW.CTM.Businesses.UnitTest
{
    public static class TestHelper
    {
        public static Conference GetDemoConference()
        {
            Assert.IsTrue(File.Exists("TalkListDemo.txt"), "The talks list file is not found.");
            var talkLoader = new TalksLoader(new TalksFileLoadProvider("TalkListDemo.txt"));
            var talks = talkLoader.Load();
            Assert.AreEqual(19, talks.Count, "Can't Load all Talks");

            var scheduler = new Scheduler(new SimpleScheduleProvider());
            return scheduler.Schedule(talks);
        }
    }
}