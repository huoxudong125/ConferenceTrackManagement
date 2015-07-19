using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TW.CTM.Businesses.Import;

namespace TW.CTM.Businesses.UnitTest
{
    /// <summary>
    /// Summary description for TestTalksLoadTextProvider
    /// </summary>
    [TestClass]
    public class TestTalksLoadProvider
    {
        private readonly string _talksStr = @"Writing Fast Tests Against Enterprise Rails 60min
Overdoing it in Python 45min
Lua for the Masses 30min
Ruby Errors from Mismatched Gem Versions 45min
Common Ruby Errors 45min
Rails for Python Developers lightning
Communicating Over Distance 60min";

        [TestMethod]
        public void Test_Talks_TextLoadProvider()
        {
            var textLoader = new TalksTextLoadProvider(_talksStr);
            var actualTalksList = textLoader.Load();
            Assert.AreEqual(7, actualTalksList.Count);
        }

        [TestMethod]
        [DeploymentItem(@"TestData\TalkListSlim.txt")]
        public void Test_Talks_FileLoadProvider()
        {
            Assert.IsTrue(File.Exists("TalkListSlim.txt"), "Test file is not found.");
            var textLoader = new TalksFileLoadProvider("TalkListSlim.txt");
            var actualTalksList = textLoader.Load();
            Assert.AreEqual(7, actualTalksList.Count);
        }
    }
}