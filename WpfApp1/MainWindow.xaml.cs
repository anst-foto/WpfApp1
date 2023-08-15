using System;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var progress = new Progress<int>();
            progress.ProgressChanged += (_, i) =>
            {
                ProgressBar.Value = i;
                Values.Text = i.ToString();
            };
            await ProcessAsync(progress, (int)ProgressBar.Minimum, (int)ProgressBar.Maximum);
        }

        private async Task ProcessAsync(IProgress<int> progress, int start, int end)
        {
            for (int i = start; i < end; i++)
            {
                await Task.Delay(500);
                progress.Report(i);
            }
        }
    }
}