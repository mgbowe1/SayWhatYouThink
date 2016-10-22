using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpeechRecLib;


namespace QuickDoc
{
    public class SpeechRecManager
    {
        private static SpeechRecManager _instance = null;
        private SpeechRec _speechRec;
        private string _response = "";

        public event EventHandler OnSpeechReceived;

        private SpeechRecManager()
        {
            _speechRec = new SpeechRec("83d360c791ae43e795500e1ae43fcd6c");
            _speechRec.OnSpeechReceived += SpeechRec_OnSpeechReceived;
        }

        public static SpeechRecManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SpeechRecManager();
                }
                return _instance;
            }
        }

        public void StartListeningForComment()
        {
            _speechRec.StartSpeechRec();
        }

        private void SpeechRec_OnSpeechReceived(object sender, SpeechReceivedEventArgs e)
        {
            if (e.Success)
            {
                _response = e.Result;

                if (OnSpeechReceived != null)
                    OnSpeechReceived(this, new EventArgs());
            }
        }

        public string GetResponse()
        {
            return _response;
        }
    }
}
