using System;
using System.ServiceModel;
using GXService.CardRecognize.Service;
using GXService.SSZGameServer.CardTypeParseService.Service;
using GXService.SSZGameServer.GameControlService.Service;

namespace GXService.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var hostCardRecognize = new ServiceHost(typeof(CardRecognizeService));
                hostCardRecognize.Opened += (sender, eventArgs) => Console.WriteLine("扑克牌识别服务启动完成!");
                if (hostCardRecognize.State != CommunicationState.Opened)
                {
                    hostCardRecognize.Open();
                }

                var hostCardTypeParse = new ServiceHost(typeof(CardTypeParseService));
                hostCardTypeParse.Opened += (sender, eventArgs) => Console.WriteLine("十三张牌型解析服务启动完成!");
                if (hostCardTypeParse.State != CommunicationState.Opened)
                {
                    hostCardTypeParse.Open();
                }

                var hostSSZGameControl = new ServiceHost(typeof (GameControlService));
                hostSSZGameControl.Opened += (sender, eventArgs) => Console.WriteLine("十三张游戏控制服务启动完成");
                if (hostSSZGameControl.State != CommunicationState.Opened)
                {
                    hostSSZGameControl.Open();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException == null ? ex.ToString() : ex.InnerException.ToString());
            }

            Console.ReadKey();
        }
    }
}
