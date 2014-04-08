using System;

namespace SSZClient.Callback.Events
{
    //数据广播事件委托
    public delegate void BroadcastEvent(BroadcastEventArgs args);

    public class BroadcastEventArgs : EventArgs
    {
        public BroadcastEventArgs(byte[] data)
        {
            Data = data;
        }

        public byte[] Data { get; private set; }
    }
}
