using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TW.CTM.Common.Extends;

namespace TW.CTM.Common.UnitTest.Extends
{
    [TestClass]
    public class TestTimeSpanExtend
    {
        [TestMethod]
        public void Test_TimeSpan_AddMinutes()
        {
            var timeSpan = new TimeSpan(10, 20, 00);
            var actualTimeSpan = timeSpan.AddMinutes(10);
            Assert.AreEqual(new TimeSpan(10, 30, 00), actualTimeSpan);
        }

        [TestMethod]
        public void Test_TimeSpan_ToStringHhMm()
        {
            var timeSpan = new TimeSpan(10, 20, 00);
            Assert.AreEqual("10:20", timeSpan.ToStringHhMm());
        }
    }
}