using ServiceSendJingTaiMessage.BusinessLogic;
using ServiceSendJingTaiMessage.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Topshelf;

namespace ServiceSendJingTaiMessage
{
    class Program
    {

        public static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<SendJingTaiMessage>(s =>
                {
                    s.ConstructUsing(name => new SendJingTaiMessage());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();
                x.StartAutomatically();
                x.EnablePauseAndContinue();
                x.SetDescription("ELD设备静态信息更新服务");
                x.SetDisplayName("SendELDMessageService");
                x.SetServiceName("SendELDMessageService");

            });

           



        }

       
    }
}
