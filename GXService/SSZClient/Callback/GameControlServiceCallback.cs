using SSZClient.Callback.Events;
using SSZClient.GameControlServiceReference;
using RecognizeResult = SSZClient.CardRecognizeServiceReference.RecognizeResult;

namespace SSZClient.Callback
{
    public class GameControlServiceCallback : IGameControlServiceCallback
    {
        public event RecognizedEvent Recognized;
        public event StartRecognizeEvent StartRecognize;

        public void OnRecognized(ClientInfo clientInfo, RecognizeResult recognizeResult)
        {
            var handler = Recognized;
            if (handler != null)
            {
                handler(new RecognizedEventArgs(clientInfo, recognizeResult));
            }
        }

        public void OnStartRecognize()
        {
            var handler = StartRecognize;
            if (null != handler)
            {
                handler(new StartRecognizeEventArgs());
            }
        }
    }
}
