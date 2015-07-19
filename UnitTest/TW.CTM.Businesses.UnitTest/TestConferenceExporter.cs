using Microsoft.VisualStudio.TestTools.UnitTesting;
using TW.CTM.Businesses.Export;

namespace TW.CTM.Businesses.UnitTest
{
    [TestClass]
    public class TestConferenceExporter
    {
        [TestMethod]
        [DeploymentItem(@"TestData\TalkListSlim.txt")]
        public void Test_ExportTalks_ToFile()
        {
            var conference = TestHelper.GetDemoConference();
            var exporter = new ConferenceExporter(new FileExportProvider("TalkListSlim.txt"));
            exporter.Export(conference);
        }
    }
}