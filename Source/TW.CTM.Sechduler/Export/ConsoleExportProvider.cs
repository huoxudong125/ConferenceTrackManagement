using System;
using TW.CTM.Businesses.Interface;

namespace TW.CTM.Businesses.Export
{
    public class ConsoleExportProvider : IConferenceExportProvider
    {
        public void ExportLine(string talkDescription)
        {
            Console.WriteLine(talkDescription);
        }
    }
}