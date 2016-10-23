using System;
using Documentation;

namespace QuickDocConsole
{
    class Program
    {
        Documentation.Documentation doc = null;
        public Boolean waitForMessage = true;

        public Program(string lang)
        {
            doc = GetDocumentationType(lang);

            SpeechRecManager.Instance.StartListeningForComment();
            SpeechRecManager.Instance.OnSpeechReceived += SpeechRecManager_OnSpeechReceived;
        }

        static void Main(string[] args)
        {
            if (args.Length >= 1)
            {
                Program p = new Program(args[0]);
                while (p.waitForMessage) { }
                Environment.Exit(0);
            }
        }

        private void SpeechRecManager_OnSpeechReceived(object sender, EventArgs e)
        {
            doc.Message = SpeechRecManager.Instance.GetResponse();
            string response = doc.getDocumentedString();
            Console.Write(response);
            waitForMessage = false;
        }

        private Documentation.Documentation GetDocumentationType(string lang)
        {
            Documentation.Documentation doc = null;
            switch (lang)
            {
                case "P":
                    doc = new PythonDocumentation();
                    break;
                case "L":
                    doc = new RacketDocumentation();
                    break;
                case "C":
                    doc = new CDocumentation();
                    break;
            }
            return doc;
        }
    }
}
