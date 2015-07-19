using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TW.CTM.Common.UnitTest
{
    [TestClass]
    public class TestGuard
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNotNull_WhenNull_ThrowArgumentNullException()
        {
            Guard.ArgumentNotNull(null, "test");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNotNullOrEmpty_WhenNull_ThrowArgumentNullException()
        {
            Guard.ArgumentNotNullOrEmpty(null, "test");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ArgumentNotNullOrEmpty_WhenEmpty_ThrowArgumentException()
        {
            Guard.ArgumentNotNullOrEmpty(string.Empty, "test");
        }
    }
}