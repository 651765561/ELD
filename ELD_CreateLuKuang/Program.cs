using ELD_CreateLuKuang.Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using Quartz;
using log4net;
using Quartz.Impl;
using log4net.Core;
using ELD_CreateLuKuang.BusinessLogic;

namespace ELD_CreateLuKuang
{
    class Program
    {
        static void Main(string[] args)
        {

            DrawPic hh = new DrawPic();
            hh.CreateRoadPic();
            //   DA da = new DA();
            // var list=da.GetRoadList();

            //  string hh = ConfigurationManager.AppSettings["mysqlconnectionString"];
            /*
             x.SetDisplayName("LuKuangService");在Windows 服务显示

               */
            HostFactory.Run(x =>
            {
                x.Service<QuartzServiceRunner>(s =>
                {
                    s.ConstructUsing(name => new QuartzServiceRunner());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();
                x.StartAutomatically();
                x.EnablePauseAndContinue();
                x.SetDescription("路况图更新服务");
                x.SetDisplayName("LuKuangService");
                x.SetServiceName("LuKuangService");

            });
        }
    }
}
