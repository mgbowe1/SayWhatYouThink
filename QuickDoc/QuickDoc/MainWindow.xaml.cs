using System;
using System.Windows;
using DocumentLibrary;

namespace QuickDoc
{
    public partial class MainWindow : Window
    {
        Documentation _doc = null;

        public MainWindow(string language)
        {
            InitializeComponent();

            _doc = GetDocumentationType(language);

            SpeechRecManager.Instance.StartListeningForComment();
            SpeechRecManager.Instance.OnSpeechReceived += MainWindow_OnSpeechReceived;
        }

        private void MainWindow_OnSpeechReceived(object sender, EventArgs e)
        {
            string response = _doc.GetFormattedComment(SpeechRecManager.Instance.GetResponse());

            //Application.Current.Dispatcher.Invoke(new Action(() =>
            //   System.Console.WriteLine(response)
            //));

            //Application.Current.Dispatcher.Invoke(new Action(() =>
            //   Application.Current.Shutdown()
            //));
        }

        private Documentation GetDocumentationType(string lang)
        {
            Documentation doc = null;
            switch (lang)
            {
                case "P":
                    doc = new PythonStyle();
                    break;
                case "L":
                    doc = new RacketStyle();
                    break;
                case "C":
                    doc = new JavaStyle();
                    break;
            }
            return doc;
        }
    }
}
