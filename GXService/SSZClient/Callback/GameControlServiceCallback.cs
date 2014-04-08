using SSZClient.Callback.Events;
using SSZClient.GameControlServiceReference;

namespace SSZClient.Callback
{
    public class GameControlServiceCallback : IGameControlServiceCallback
    {
        public event BroadcastEvent Broadcast;
        public event StartRecognizeEvent StartRecognize;

        public void OnDataBroadcast(byte[] data)
        {
            var handler = Broadcast;
            if (handler != null)
            {
                handler(new BroadcastEventArgs(data));
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
