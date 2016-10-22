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

        private void _partial_result_handler(object sender, PartialSpeechResponseEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void _full_result_handler(object sender, SpeechResponseEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void _conversion_error_handler(object sender, SpeechErrorEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void _create_mic_client()
        {
            _mic_client = SpeechRecognitionServiceFactory.CreateMicrophoneClient(_mode, "en-US", _api_key);

            _mic_client.OnMicrophoneStatus += _mic_status_handler;
            _mic_client.OnPartialResponseReceived += _partial_result_handler;
            _mic_client.OnResponseReceived += _full_result_handler;
            _mic_client.OnConversationError += _conversion_error_handler;
        }

        public void StartSpeechRec()
        {
            this._create_mic_client();
            _mic_client.StartMicAndRecognition();
        }
    }
}
