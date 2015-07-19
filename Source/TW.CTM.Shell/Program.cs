using System;
using System.Collections.Generic;
using System.IO;
using TW.CTM.Businesses;
using TW.CTM.Businesses.Export;
using TW.CTM.Businesses.Import;
using TW.CTM.Models;

namespace TW.CTM.Shell
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length < 1 || args.Length > 2)
            {
                PrintUsage();
                return;
            }

            string sourcePath = args[0];//"TalkListslim.txt"
            string targetPath = string.Empty;
            if (args.Length > 1)
            {
                targetPath = args[1];//@"D:\outPut.txt"
            }

            try
            {
                ProcessConference(sourcePath, targetPath);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (AggregateException ex)
            {
                Console.WriteLine(ex.InnerException.Message);
            }
            catch (Exception ex) //TODO:
            {
                Console.WriteLine(ex.Message);
            }

            Console.Read();
        }

        private static void ProcessConference(string sourcePath, string targetPath)
        {
            var talks = new List<Talk>();

            //TODO:Consider IOC

            var talksLoader = new TalksLoader(new TalksFileLoadProvider(sourcePath));
            var talksFromFile = talksLoader.Load();
            talks.AddRange(talksFromFile);

            var scheduler = new Scheduler(new SimpleScheduleProvider());
            Conference conference = scheduler.Schedule(talks);

            if (conference != null)
            {
                var exporter = new ConferenceExporter(new ConsoleExportProvider());
                exporter.Export(conference);

                if (!string.IsNullOrEmpty(targetPath))
                {
                    exporter = new ConferenceExporter(new FileExportProvider(targetPath));
                    exporter.Export(conference);
                }
            }
        }

        private static void PrintUsage()
        {
            Console.WriteLine(@"Usage: TalksListSoureFilePath [ExportTargetFilePath] "
                + Environment.NewLine
                + "eg. TW.CTM.Shell.exe TalkListDemo.txt");
        }
    }
}