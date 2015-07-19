using Microsoft.VisualStudio.TestTools.UnitTesting;
using TW.CTM.Common.Extends;

namespace TW.CTM.Common.UnitTest.Extends
{
    [TestClass]
    public class TestStringExtend
    {
        private const string StringWithNumber = "Hel1o Wo2ld"; // the char after Hel is number one.

        [TestMethod]
        public void IsContainNumber_WhenStringWithANumber_ReturnTrue()
        {
            Assert.AreEqual(true, StringWithNumber.IsContainNumber());
        }

        [TestMethod]
        public void ExtractFirstInt_WhenStringWithANumber_ReturnTheFistInt()
        {
            Assert.AreEqual(1, StringWithNumber.ExtractFirstInt());
        }
    }
}