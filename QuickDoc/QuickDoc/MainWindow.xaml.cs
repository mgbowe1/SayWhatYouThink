using System;
using System.Windows;
using System.Windows.Input;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace QuickDoc
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            startRecordingBtn.Click += StartRecordingBtn_Click;
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
