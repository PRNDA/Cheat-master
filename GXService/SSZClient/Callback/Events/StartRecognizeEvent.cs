using System;

namespace SSZClient.Callback.Events
{
    //开始识别牌的事件委托
    public delegate void StartRecognizeEvent(StartRecognizeEventArgs args);

    public class StartRecognizeEventArgs : EventArgs
    {
    }
}
