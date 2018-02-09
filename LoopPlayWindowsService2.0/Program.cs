using LoopPlayWindowsService2._0.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace LoopPlayWindowsService2._0
{
    class Program
    {
      public  static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.BackgroundColor = ConsoleColor.Blue
                
                
                ;
            Console.Clear();//必须

            /*Loop Play*/

            //HostFactory.Run(x =>
            //{
            //    x.Service<SendLoopPlayMessage>(s =>
            //    {
            //        s.ConstructUsing(name => new SendLoopPlayMessage());
            //        s.WhenStarted(tc => tc.Start());
            //        s.WhenStopped(tc => tc.Stop());
            //    });
            //    x.RunAsLocalSystem();
            //    x.StartAutomatically();
            //    x.EnablePauseAndContinue();
            //    x.SetDescription("ELD轮流播放服务");
            //    x.SetDisplayName("SendLoopPlayMessage");
            //    x.SetServiceName("SendLoopPlayMessage");

            //});

            SendLoopPlayMessageII bll = new SendLoopPlayMessageII();
            bll.Play();
        }
    }
}
