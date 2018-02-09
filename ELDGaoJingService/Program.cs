using ELDGaoJingService.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace ELDGaoJingService
{
   public class Program
    {
        static void Main(string[] args)
        {
            //Console.ForegroundColor = ConsoleColor.Magenta;
            //Console.BackgroundColor = ConsoleColor.Blue
            //SendGaojingMessage hh = new SendGaojingMessage();
            //hh.SendAlramMessage();

            //;
            //Console.Clear();//必须
            HostFactory.Run(x =>
            {
                x.Service<SendGaojingMessage>(s =>
                {
                    s.ConstructUsing(name => new SendGaojingMessage());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();
                x.StartAutomatically();
                x.EnablePauseAndContinue();
                x.SetDescription("ELD告警播放服务");
                x.SetDisplayName("ELDService_SendGaojingMessage");
                x.SetServiceName("ELDService_SendGaojingMessage");

            });
        }
    }
}
