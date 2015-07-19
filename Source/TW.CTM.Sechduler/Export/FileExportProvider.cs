using System.IO;
using System.Text;
using TW.CTM.Businesses.Interface;
using TW.CTM.Common;

namespace TW.CTM.Businesses.Export
{
    /// <summary>
    /// The FileExportProvider is just for demonstrating
    /// Need to consider implement IDispose for performance(etc. GC)
    /// </summary>
    public class FileExportProvider : IConferenceExportProvider//TODO: implement IDisposable
    {
        private readonly string _targetFilePath;

        /// <summary>
        /// Export the conference to the file.
        /// </summary>
        /// <param name="targetFilePath">the target file</param>
        public FileExportProvider(string targetFilePath)
        {
            Guard.ArgumentNotNullOrEmpty(targetFilePath, "targetFilePath");
            _targetFilePath = targetFilePath;
        }

        public void ExportLine(string talkDescription)
        {
            using (var streamWriter = new StreamWriter(_targetFilePath, true, Encoding.Unicode))
            {
                streamWriter.WriteLine(talkDescription);
            }
        }
    }
}