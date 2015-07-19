using System.Text;
using TW.CTM.Businesses.Interface;

namespace TW.CTM.Shell.WPF
{
    internal class StringBuilderExportProvider : IConferenceExportProvider
    {
        private readonly StringBuilder _stringBuilder;

        public StringBuilderExportProvider(StringBuilder stringBuilder)
        {
            _stringBuilder = stringBuilder;
        }

        public void ExportLine(string talkDescription)
        {
            _stringBuilder.AppendLine(talkDescription);
        }
    }
}