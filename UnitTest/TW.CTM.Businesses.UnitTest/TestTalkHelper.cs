using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TW.CTM.Businesses.UnitTest
{
    [TestClass]
    public class TestTalkParser
    {
        [TestMethod]
        public void Talk_Parse_TalkDescribeString_ToNormalTalk()
        {
            var talk = TalkHelper.Parse("User Interface CSS in Rails Apps 30min");
            Assert.AreEqual(30, talk.Length);
            Assert.AreEqual("User Interface CSS in Rails Apps", talk.Title.Trim());
        }

        [TestMethod]
        public void Talk_Parse_TalkDescribeString_ToLightingTalk()
        {
            var talk = TalkHelper.Parse("Rails for Python Developers lightning");
            Assert.AreEqual(5, talk.Length);
            Assert.AreEqual("Rails for Python Developers", talk.Title.Trim());
        }
    }
}