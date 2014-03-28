using System;
using System.ServiceModel;
using System.ServiceProcess;
using GXService.Broadcast.Service;
using GXService.CardRecognize.Service;
using log4net;

namespace GXService.ServiceHost
{
    partial class GXHostService : ServiceBase
    {
        private System.ServiceModel.ServiceHost _hostBroadcast;
        private System.ServiceModel.ServiceHost _hostCardRecognize;
        private readonly ILog _log = LogManager.GetLogger(string.Empty);

        public GXHostService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                _log.Error("服务启动");


                _hostBroadcast = new System.ServiceModel.ServiceHost(typeof(BroadcastService));
                _hostBroadcast.Opened += (sender, eventArgs) => Console.WriteLine("数据广播服务器启动完成!");
                if (_hostBroadcast.State != CommunicationState.Opened)
                {
                    _hostBroadcast.Open();
                }

                _hostCardRecognize = new System.ServiceModel.ServiceHost(typeof(CardRecognizeService));
                _hostCardRecognize.Opened += (sender, eventArgs) => Console.WriteLine("扑克牌识别服务器启动完成!");
                if (_hostCardRecognize.State != CommunicationState.Opened)
                {
                    _hostCardRecognize.Open();
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.InnerException ?? ex);
                throw;
            }
        }

        protected override void OnStop()
        {
            _log.Error("服务停止");


            if (_hostCardRecognize.State == CommunicationState.Opened)
            {
                _hostCardRecognize.Close();
            }
            if (_hostBroadcast.State == CommunicationState.Opened)
            {
                _hostBroadcast.Close();
            }
        }
    }
}
