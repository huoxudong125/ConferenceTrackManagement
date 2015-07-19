using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using TW.CTM.Businesses.Interface;
using TW.CTM.Common;
using TW.CTM.Models;

namespace TW.CTM.Businesses.Import
{
    public class TalksFileLoadProvider : ITalksLoadProvider
    {
        private readonly string _talksFilePath;

        public TalksFileLoadProvider(string talksFilePath)
        {
            Guard.ArgumentNotNullOrEmpty(talksFilePath, "talksFilePath");
            _talksFilePath = talksFilePath;
        }

        public List<Talk> Load()
        {
            var talks = new List<Talk>();
            Task.Run(async () =>
            {
                var talksFromFile = await LoadFromTextFileAsync(_talksFilePath);
                talks.AddRange(talksFromFile);
            }).Wait();

            return talks;
        }

        private async Task<IList<Talk>> LoadFromTextFileAsync(string talksFilePath)
        {
            Guard.ArgumentNotNullOrEmpty(talksFilePath, "talksFilePath");
            var result = new List<Talk>();
            if (!File.Exists(talksFilePath))
            {
                throw new FileNotFoundException(string.Format("Can't found the file [{0}]", talksFilePath));
            }

            using (var streamReader = new StreamReader(talksFilePath, Encoding.Unicode))
            {
                while (!streamReader.EndOfStream)
                {
                    string talkStr = await streamReader.ReadLineAsync();
                    var talk = TalkHelper.Parse(talkStr);
                    if (talk != null)
                    {
                        result.Add(talk);
                    }
                }
            }

            return result;
        }
    }
}