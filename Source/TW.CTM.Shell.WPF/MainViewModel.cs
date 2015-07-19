using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using TW.CTM.Businesses;
using TW.CTM.Businesses.Export;
using TW.CTM.Businesses.Import;
using TW.CTM.Shell.WPF.MVVM;

namespace TW.CTM.Shell.WPF
{
    public class MainViewModel : ObservableObject
    {
        private string _sourceTalkString;
        private string _scheduledTalksString;
        private ICommand _loadTalksCommand;
        private ICommand _scheduleCommand;
        private ICommand _exportCommand;
        private Models.Conference _conference;

        public string SourceTalksString
        {
            get { return _sourceTalkString; }
            set
            {
                _sourceTalkString = value;
                OnPropertyChanged("SourceTalksString");
            }
        }

        public string ScheduledTalksString
        {
            get { return _scheduledTalksString; }
            set
            {
                _scheduledTalksString = value;
                OnPropertyChanged("ScheduledTalksString");
            }
        }

        public ICommand LoadTalksCommand
        {
            get
            {
                if (_loadTalksCommand == null)
                {
                    _loadTalksCommand = new RelayCommand(
                        param => LoadTalks(), param => true
                    );
                }
                return _loadTalksCommand;
            }
        }

        public ICommand ScheduleCommand
        {
            get
            {
                if (_scheduleCommand == null)
                {
                    _scheduleCommand = new RelayCommand(
                        param => ScheduleTalks(),
                        param => !string.IsNullOrEmpty(SourceTalksString)
                    );
                }
                return _scheduleCommand;
            }
        }

        public ICommand ExportCommand
        {
            get
            {
                if (_exportCommand == null)
                {
                    _exportCommand = new RelayCommand(
                        param => Export(),
                        param => !string.IsNullOrEmpty(ScheduledTalksString)
                    );
                }
                return _exportCommand;
            }
        }

        private object Export()
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    var exporter = new ConferenceExporter(new FileExportProvider(saveFileDialog.FileName));
                    exporter.Export(_conference);
                }
                catch (Exception ex)//TODO:need to improve, this is not good practice.
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return null;
        }

        private object ScheduleTalks()
        {
            try
            {
                var talksLoader = new TalksLoader(new TalksTextLoadProvider(SourceTalksString));
                var talks = talksLoader.Load();

                var scheduler = new Scheduler(new SimpleScheduleProvider());
                _conference = scheduler.Schedule(talks);

                var resultStringBuilder = new StringBuilder();
                var exporter = new ConferenceExporter(new StringBuilderExportProvider(resultStringBuilder));
                exporter.Export(_conference);
                ScheduledTalksString = resultStringBuilder.ToString();
            }
            catch (Exception ex)//TODO:need to improve, this is not good practice.
            {
                _conference = null;
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        private object LoadTalks()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                SourceTalksString = File.ReadAllText(openFileDialog.FileName, Encoding.Unicode);
                ScheduledTalksString = string.Empty;
            }

            return null;
        }
    }
}