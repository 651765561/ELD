using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Threading;
using Dapper;
using ELD_CreateLuKuang.Dapper;
using Quartz;
using Quartz.Impl;
using Topshelf;

namespace ELD_CreateLuKuang
{
    public class QuartzServiceRunner
    {
        private readonly IScheduler _scheduler;
        List<object> list = new List<object>();



        public QuartzServiceRunner()
        {
            _scheduler = StdSchedulerFactory.GetDefaultScheduler();
 
        }

        public void Start()
        {

            WriteFile("kaishi", "kaishi");
            int num1 = 10;
            //从配置文件中读取任务启动时间
            string cronExpr = ConfigurationManager.AppSettings["cronExpr"];
            string ScancronExpr = ConfigurationManager.AppSettings["ScancronExpr"];
            /*获取任务调度信息
             id = '1', groupName = 'group1', jobName = 'job1', trigggerName = 'trigger1', state = '0'
             */
            var list = DBscheduler.GetAllList();
            IJobDetail job;
            ITrigger trigger;
            for (int i = 0; i < list.Count; i++)
            {
                var item = list[i];
                job = JobBuilder.Create<StartJob>().WithIdentity(item.jobName, item.gropName).Build();
                //创建任务运行的触发器
                trigger = TriggerBuilder.Create()
                   .WithIdentity(item.trigggerName, item.gropName)
                   .WithSchedule(CronScheduleBuilder.CronSchedule(new CronExpression(cronExpr)))
                   .Build();
                //传递参数
                job.JobDataMap.Put("item", item);
                job.JobDataMap.Put("jobName", item.jobName);
                job.JobDataMap.Put("_scheduler", _scheduler);
                job.JobDataMap.Put("trigger", item.trigggerName);
                //启动任务
                _scheduler.ScheduleJob(job, trigger);
                // _scheduler.Start();
            }
            // Thread.Sleep(1000*10);
            //
            job = JobBuilder.Create<StartJob>().WithIdentity("Scan_job", "Scan_group").Build();
          
            //创建任务运行的触发器
            trigger = TriggerBuilder.Create()
                .WithIdentity("Scan_triggger", "Scan_group")
                .WithSchedule(CronScheduleBuilder.CronSchedule(new CronExpression(ScancronExpr)))
                .Build();
            //传递参数
            job.JobDataMap.Put("_scheduler", _scheduler);
  
            _scheduler.ScheduleJob(job, trigger);
            //
            
            _scheduler.Start();

            //
            //for (int i = 0; i < 2; i++)
            //{
            //    int num = i + 1;
            //    IJobDetail job = JobBuilder.Create<StartJob>().WithIdentity("job" + num, "group" + num).Build();
            //    //创建任务运行的触发器
            //    ITrigger trigger = TriggerBuilder.Create()
            //        .WithIdentity("triggger" + num, "group" + num)
            //        .WithSchedule(CronScheduleBuilder.CronSchedule(new CronExpression(cronExpr)))
            //        .Build();
            //    //传递参数
            //    job.JobDataMap.Put("aa", "Hello" + (i + 1));
            //    job.JobDataMap.Put("_scheduler", _scheduler);

            //    //启动任务
            //    _scheduler.ScheduleJob(job, trigger);


            //    // list.Add(_scheduler);

            //}




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
