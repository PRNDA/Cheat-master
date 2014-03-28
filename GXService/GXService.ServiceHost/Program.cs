using System.ServiceProcess;

namespace GXService.ServiceHost
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            ServiceBase.Run(new ServiceBase[] 
            { 
                new GXHostService() 
            });
        }
    }
}
