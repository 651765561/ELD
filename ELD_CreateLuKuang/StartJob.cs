using ELD_CreateLuKuang.Dapper;
using Quartz;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELD_CreateLuKuang
{

    /*
    支持quartz版本2.6.1.0 
    */

    //加上并发限制
    [DisallowConcurrentExecution]
    public class StartJob : IJob
    {
        public static readonly LogFileFolder Log = new LogFileFolder("StartJob");
        bool flag = false;
        public void Execute(IJobExecutionContext context)
        {
           
            try
            {
                Log.FatalFormat("\r\n状态监测过程中发生异常:\r\n{0}\r\n{1}\r\n",
                   878,
                  78877887);
                // 获取传递过来的参数            
                JobDataMap data = context.JobDetail.JobDataMap;
               var str= data.Get("jobName");
              var _scheduler=  data.Get("_scheduler") as IScheduler;
                var trigger = data.Get("trigger").ToString();
               var hh= _scheduler.GetTriggerState( new TriggerKey(trigger));
                
                WriteFile("计划任务"+str,"dddf"+ str);
                string  jobName = context.JobDetail.Key.Name;
                if (jobName == "Scan_job")
                {
                      ScanDB(_scheduler);

                }
                flag = true;
                //清除数据库不存在的任务jobdetail
                if (!ExitsDB(jobName) && jobName != "Scan_job") {
                    JobKey _jobKey = new JobKey(jobName);
                    _scheduler.PauseJob(_jobKey);
                    _scheduler.DeleteJob(_jobKey);
                }

                //var para = CrossingService.GetIpList(DbContext.GetSubCode());

                //CrossingService.InSertDb(para);

                //for (int i = 0; i < para.Count; i += 20)
                //{
                //    var i1 = i;
                //    Log.Info($"启动线程{i1}-{i1 + 20}");
                //    Task.Run(() =>
                //    {
                //        CrossingService.InSertDb(para.Skip(i1).Take(20).ToList());
                //    });

                //}
                //  para.Clear();

            }
            catch (Exception ex)
            {
                Log.FatalFormat("\r\n状态监测过程中发生异常:\r\n{0}\r\n{1}\r\n",
                    ex.Message,
                    ex.StackTrace);
            }



        }

        /// <summary>
        /// 查看jobname 任务是否在数据库存在
        /// </summary>
        /// <param name="jobname"></param>
        /// <returns></returns>
        public bool ExitsDB(string jobname)
        {
            var list = DBscheduler.GetAllList();
         bool flag=    list.Exists(p => p.jobName == jobname);
            return flag;

               

        }
        /// <summary>
        /// 对数据中没加入任务调度的工作 加入任务调度
        /// </summary>
        /// <param name="_scheduler"></param>
        public void ScanDB(IScheduler _scheduler)
        {
            var list = DBscheduler.GetAllList();
            /*扫描运行的任务是否在数据库存在*/
           var jobs= _scheduler.GetCurrentlyExecutingJobs().ToList<IJobExecutionContext>();
            foreach (var item in jobs)
            {
                string jobname =item.JobDetail.Key.Name;
           


            }
            /*扫描数据库的任务是否都启用*/
            foreach (var item in list)
            {
             // var h1=  _scheduler.GetCurrentlyExecutingJobs().ToList<IJobExecutionContext>().Exists(p => p.JobDetail.Key.Name == "job1");
            //  var h2=  _scheduler.GetCurrentlyExecutingJobs().ToList<IJobExecutionContext>().Where(p => p.JobDetail.Key.Name == "job1");
                //Exits(_scheduler)

                JobKey jobkey = new JobKey(item.jobName);
            var flag=_scheduler.CheckExists(jobkey);
                if (!flag)
                {
                    string cronExpr = ConfigurationManager.AppSettings["cronExpr"];
                    IJobDetail job1 = JobBuilder.Create<StartJob>().WithIdentity(item.jobName, item.gropName).Build();
                    //创建任务运行的触发器
                    ITrigger trigger1 = TriggerBuilder.Create()
                        .WithIdentity(item.trigggerName, item.gropName)
                        .WithSchedule(CronScheduleBuilder.CronSchedule(new CronExpression(cronExpr)))
                        .Build();
                    //传递参数
                    job1.JobDataMap.Put("item", item);
                    job1.JobDataMap.Put("jobName", item.jobName);
                    job1.JobDataMap.Put("_scheduler", _scheduler);
                    //启动任务
                    _scheduler.ScheduleJob(job1, trigger1);
                    _scheduler.Start();
                }
            }


        }

         
        public void WriteFile(string filename,string str)
        {
            Console.WriteLine(DateTime.Now.ToString()+ str);
            string path = @"d:\"+ filename+".txt";
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.BaseStream.Seek(0, SeekOrigin.End);
            //sw.Write(DateTime.Now.ToString() + ":" + str + "\r\n执行结果：" + Text + "\r\n");
            sw.Write(DateTime.Now.ToString() + ":" + str + "\r\n执行结果：" );
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

    }
}
