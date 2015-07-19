using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TW.CTM.Models.UnitTest
{
    [TestClass]
    public class TestTalk
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Talk_WhenTitleWithNumber_ThrowException()
        {
            var talk = new NormalTalk("Hel1o Wo2ld", 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Talk_WhenTitleIsEmpty_ThrowException()
        {
            var talk = new NormalTalk(string.Empty, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Talk_WhenTitleIsNull_ThrowException()
        {
            var talk = new NormalTalk(null, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Talk_WhenNoramlTalkLengthLessThanOneMinutes_ThrowException()
        {
            var talk = new NormalTalk("Topic", 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Talk_WhenNoramlTalkLengthAreNegative_ThrowException()
        {
            var talk = new NormalTalk("Topic", -10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Talk_WhenNoramlTalkLengthMoreThan180Minutes_ThrowException()
        {
            var talk = new NormalTalk("Topic", 181);
        }

        [TestMethod]
        public void Talk_CreateALightingTalk()
        {
            var talk = new LightingTalk("Topic");
            Assert.AreEqual(5, talk.Length, "The length of Lighting talk should be 5 minutes.");
        }

        [TestMethod]
        public void Talk_CreateANormalTalk()
        {
            var talk = new NormalTalk("Topic", 15);
            Assert.AreEqual(15, talk.Length, "The length of Lighting talk should be 5 minutes.");
        }
    }
}