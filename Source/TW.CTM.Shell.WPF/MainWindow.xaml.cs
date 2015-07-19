using System;
using System.Windows;

namespace TW.CTM.Shell.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(string.Format(" Conference Track Management{0}{0} For ThoughtWorks Quiz {0}{0}  by Quanfu Huo (huo423@126.com)",
                Environment.NewLine));
        }
    }
}