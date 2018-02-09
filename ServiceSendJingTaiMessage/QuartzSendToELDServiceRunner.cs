using Quartz;
using Quartz.Impl;
using ServiceSendJingTaiMessage.Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Topshelf;

namespace ServiceSendJingTaiMessage
{
    public class QuartzSendToELDServiceRunner
    {
        private readonly IScheduler _scheduler;
        List<object> list = new List<object>();



        public QuartzSendToELDServiceRunner()
        {
            _scheduler = StdSchedulerFactory.GetDefaultScheduler();
        }
        public void Start()
        {
            DBELD dbELD = new DBELD();
            //获取全部ELD设备信息
            var list = dbELD.GetAllLedList();
            string ScancronExpr = ConfigurationManager.AppSettings["ScancronExpr"];
            IJobDetail job;
            ITrigger trigger;
            for (int i = 0; i <6; i++)
            {
                var item = list[i];
                job = JobBuilder.Create<SendELDMessageJob>().WithIdentity(item.led_ip, "eld").Build();
                //创建任务运行的触发器
                trigger = TriggerBuilder.Create().StartAt(DateTime.UtcNow.AddSeconds(i))
                   .WithIdentity(item.led_ip , "eld")
                   .WithSchedule(CronScheduleBuilder.CronSchedule(new CronExpression(ScancronExpr)))
                   .Build();
                //传递参数
                job.JobDataMap.Put("elDitem", item);
                job.JobDataMap.Put("led_ip", item.led_ip);
                job.JobDataMap.Put("_scheduler", _scheduler);
                //启动任务
                //trigger.StartTimeUtc = DateTime.UtcNow.AddSeconds(10);
                _scheduler.ScheduleJob(job, trigger);
              
              //  Thread.Sleep(2000);

                // string led_areaPY=  PinYinConverterHelp.GetAllPinYin(item.led_area);
            }
            _scheduler.Start();

        }

        public void WriteFile(string filename, string str)
        {
            Console.WriteLine(DateTime.Now.ToString() + str);
            string path = @"d:\" + filename + ".txt";
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.BaseStream.Seek(0, SeekOrigin.End);
            //sw.Write(DateTime.Now.ToString() + ":" + str + "\r\n执行结果：" + Text + "\r\n");
            sw.Write(DateTime.Now.ToString() + ":" + str + "\r\n执行结果：");
            sw.Flush();
            sw.Close();
            fs.Close();
            System.IO.FileInfo fileInfo = null;
            fileInfo = new System.IO.FileInfo(path);
            /*单位转换成MB*/
            double fileSizeNum = System.Math.Ceiling(fileInfo.Length / (1024.0 * 1024.0));
            /*大于等于6Mb删除日志文件*/
            if (fileSizeNum >= 6)
            {
                File.Delete(path);
            }
        }
        public void Stop()
        {
            _scheduler.Clear();

        }

        public bool Continue(HostControl hostControl)
        {
            _scheduler.ResumeAll();
            return true;
        }

        public bool Pause(HostControl hostControl)
        {
            _scheduler.PauseAll();
            return true;
        }
    }
}
