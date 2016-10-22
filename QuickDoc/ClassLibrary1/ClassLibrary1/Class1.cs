using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.SpeechRecognition;

namespace STT
{
    public class SpeechRec
    {
        private string _api_key;
        private DataRecognitionClient _data_client;
        private MicrophoneRecognitionClient _mic_client;
        private SpeechRecognitionMode _mode;

        public delegate void SpeechReceivedHandler(object sender, SpeechReceivedEventArgs e);
        public event SpeechReceivedHandler OnSpeechReceived;

        public SpeechRec(string api_key)
        {
            _api_key = api_key;
            _mode = SpeechRecognitionMode.ShortPhrase;
        }

        private void _mic_status_handler(object sender, MicrophoneEventArgs e)
        {
            if (e.Recording)
            {
                Console.WriteLine("Please start speaking");
            }
        }

        private void _full_result_handler(object sender, SpeechResponseEventArgs e)
        {
            _mic_client.EndMicAndRecognition();
            if (OnSpeechReceived == null) return;

            if (e.PhraseResponse.RecognitionStatus == RecognitionStatus.NoMatch)
            {
                SpeechReceivedEventArgs args = new SpeechReceivedEventArgs(false, "No Matches");
                OnSpeechReceived(this, args);
            }
            else
            {
                var viable_results = e.PhraseResponse.Results.Where((x) => (x.Confidence == Confidence.High || x.Confidence == Confidence.Normal));
                if(viable_results.Count() == 0)
                {
                    SpeechReceivedEventArgs args = new SpeechReceivedEventArgs(false, "No Viable Matches");
                    OnSpeechReceived(this, args);
                }
                else
                {
                    var best = viable_results.First().DisplayText;
                    SpeechReceivedEventArgs args = new SpeechReceivedEventArgs(true, best);
                    OnSpeechReceived(this, args);
                }
            }
        }

        private void _conversion_error_handler(object sender, SpeechErrorEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void _create_mic_client()
        {
            _mic_client = SpeechRecognitionServiceFactory.CreateMicrophoneClient(_mode, "en-US", _api_key);

            _mic_client.OnMicrophoneStatus += _mic_status_handler;
            _mic_client.OnResponseReceived += _full_result_handler;
            _mic_client.OnConversationError += _conversion_error_handler;
        }

        public void StartSpeechRec()
        {
            this._create_mic_client();
            _mic_client.StartMicAndRecognition();
        }

    }

    public class SpeechReceivedEventArgs : EventArgs
    {
        public bool Success { get; private set; }
        public string Result { get; private set; }

        public SpeechReceivedEventArgs(bool success, string result)
        {
            Success = success;
            Result = result;
        }
    }
}
