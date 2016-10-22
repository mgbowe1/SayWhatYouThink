using System;
using System.Windows;

namespace QuickDoc
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            startRecordingBtn.Click += StartRecordingBtn_Click;
            endRecordingBtn.Click += EndRecordingBtn_Click;
        }

        private void EndRecordingBtn_Click(object sender, RoutedEventArgs e)
        {
            SpeechRecManager.Instance.StopListeningForComment();
        }

        private void StartRecordingBtn_Click(object sender, RoutedEventArgs e)
        {
            SpeechRecManager.Instance.StartListeningForComment();
            SpeechRecManager.Instance.OnSpeechReceived += MainWindow_OnSpeechReceived;
        }

        private void MainWindow_OnSpeechReceived(object sender, EventArgs e)
        {
            Application.Current.Dispatcher.Invoke(
                new Action(() => speechText.Text = SpeechRecManager.Instance.GetResponse()));            
        }
    }
}
