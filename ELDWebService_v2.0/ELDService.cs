using ELDWebService_v2._0.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;

namespace ELDWebService_v2._0
{
    public class ELDService
    {
        private const int WM_LED_NOTIFY = 1025;
        private ReaderWriterLockSlim cacheLock = new ReaderWriterLockSlim();
        string Text = "发送成功！";
        CLEDSender LEDSender = new CLEDSender();

        public string AdjustTime(MyTDeviceParam myTDeviceParam)
        {
            TDeviceParam deviceParam = new TDeviceParam();
            deviceParam.devType = LEDSender.DEVICE_TYPE_UDP;
            deviceParam.locPort = (ushort)myTDeviceParam.locPort;
            deviceParam.rmtHost = myTDeviceParam.rmtHost;
            deviceParam.rmtPort = (ushort)myTDeviceParam.rmtPort;
            deviceParam.dstAddr = 0;
            /*解决超时问题*/
            deviceParam.txTimeo = 200;
            deviceParam.txRepeat = 30;
            /*连接 LED 判断 是否打开 */
            TSenderParam param = new TSenderParam();
            param.devParam = deviceParam;

            //param.txTimeo = 200;
            //param.txRepeat = 30;
            param.notifyMode = LEDSender.NOTIFY_BLOCK;
            param.wmHandle = 0;
            param.wmMessage = 0;
            Text = "正在执行命令或者发送数据...";
            Parse2(LEDSender.Do_LED_AdjustTime(ref param));
            return Text;
        }

        /// <summary>
        /// 分区并发布信息（IsSave：是否保留分区和发布的信息）
        /// </summary>
        /// <param name="myTDeviceParam"></param>
        /// <param name="arrEldRegion"></param>
        /// <param name="arrleafObj"></param>
        /// <param name="IsSave"></param>
        /// <returns></returns>
        public string FenPingAndSendsDongTai(MyTDeviceParam myTDeviceParam, ELDRegion[] arrEldRegion, LeafObj[] arrleafObj, bool IsSave)
        {
            ushort K;
            TDeviceParam deviceParam = new TDeviceParam();
            deviceParam.devType = LEDSender.DEVICE_TYPE_UDP;
            deviceParam.locPort = (ushort)myTDeviceParam.locPort;
            deviceParam.rmtHost = myTDeviceParam.rmtHost;
            deviceParam.rmtPort = (ushort)myTDeviceParam.rmtPort;
            deviceParam.dstAddr = 0;

            /*解决超时问题*/
            //deviceParam.txTimeo = 200;
            //deviceParam.txRepeat = 30;

            /*连接 LED 判断 是否打开 */
            TSenderParam param = new TSenderParam();
            param.devParam = deviceParam;

            param.notifyMode = LEDSender.NOTIFY_BLOCK;
            param.wmHandle = 0;
            param.wmMessage = 0;
            Text = "正在执行命令或者发送数据...";
            try
            {
                //进入写锁，其他所有访问操作的线程都被阻塞。即写独占锁。
                cacheLock.EnterWriteLock();
                if (IsSave)
                {
                    K = (ushort)LEDSender.Do_MakeRoot(LEDSender.ROOT_DOWNLOAD, GetColorType(2), LEDSender.SURVIVE_ALWAYS);
                }
                else
                {
                    K = (ushort)LEDSender.Do_MakeRoot(LEDSender.ROOT_PLAY, GetColorType(2), LEDSender.SURVIVE_ALWAYS);
                }


                LEDSender.Do_AddChapter(K, 30000, LEDSender.WAIT_CHILD);
                //添加区域
                for (int i = 0; i < arrEldRegion.Length; i++)
                {
                    var region = arrEldRegion[i];
                    LEDSender.Do_AddRegion(K, region.left, region.top, region.width, region.height, region.border);

                    var arrdisplayObj = arrleafObj[i].DisplayObjList;
                    uint next_time = uint.Parse(arrleafObj[i].Next_time.ToString());
                    if (next_time == 0)
                    {
                        next_time = 10;
                        arrleafObj[i].Next_time =10;
                    }
                    uint looptime = 1000 * next_time;

                    //
                    for (int k = 0; k < arrdisplayObj.Count; k++)
                    {
                        //添加页对象
                        //LEDSender.Do_AddLeaf(K, 10000, LEDSender.WAIT_CHILD);
                        LEDSender.Do_AddLeaf(K, looptime, LEDSender.WAIT_CHILD);
                        SendObjII(K, LEDSender, arrdisplayObj[k]);
                    }

                    //LEDSender.Do_AddText
                }
                Parse2(LEDSender.Do_LED_SendToScreen(ref param, K));
            }
            catch (Exception ex)
            {

                string path = @"d:\屏幕分区和发布信息.txt";
                WriteFile(path, ex.ToString());
            }

            finally
            {
                /*日志文件*/
                List<ELDRegion> listEldRegion = new List<ELDRegion>();
                for (int i = 0; i < arrEldRegion.Length; i++)
                {
                    listEldRegion.Add(arrEldRegion[i]);
                }
                string str1 = JsonConvert.SerializeObject(myTDeviceParam);
                string str2 = JsonConvert.SerializeObject(listEldRegion);
                string str3 = JsonConvert.SerializeObject(arrleafObj);
                string str = "MyTDeviceParam:\r\n" + str1 + "\r\narrEldRegion:\r\n" + str2 + "\r\n" + "执行结果\r\n arrleafObj:" + str3 + "\r\n" + Text + "\r\n";
                string path = @"d:\屏幕分区和发布信息.txt";
                WriteFile(path, str);
                cacheLock.ExitWriteLock();
            }
            return Text;
        }
        /// <summary>
        /// 分屏 断电断网 保留 分区信息 和发布信息
        /// </summary>
        /// <param name="myTDeviceParam"></param>
        /// <param name="arrEldRegion"></param>
        /// <param name="arrleafObj"></param>
        /// <returns></returns>
        public string FenPingAndSendsDongTai(MyTDeviceParam myTDeviceParam, ELDRegion[] arrEldRegion, LeafObj[] arrleafObj)
        {
            foreach (var item in arrleafObj)
            {
                if (item.Next_time == 0)
                {
                    item.Next_time = 1000;
                }
            }
            ushort K;
            TDeviceParam deviceParam = new TDeviceParam();
            deviceParam.devType = LEDSender.DEVICE_TYPE_UDP;
            deviceParam.locPort = (ushort)myTDeviceParam.locPort;
            deviceParam.rmtHost = myTDeviceParam.rmtHost;
            deviceParam.rmtPort = (ushort)myTDeviceParam.rmtPort;
            deviceParam.dstAddr = 0;

            /*连接 LED 判断 是否打开 */
            TSenderParam param = new TSenderParam();
            param.devParam = deviceParam;

            param.notifyMode = LEDSender.NOTIFY_BLOCK;
            param.wmHandle = 0;
            param.wmMessage = 0;
            Text = "正在执行命令或者发送数据...";
            try
            {
                //进入写锁，其他所有访问操作的线程都被阻塞。即写独占锁。
                cacheLock.EnterWriteLock();
                K = (ushort)LEDSender.Do_MakeRoot(LEDSender.ROOT_DOWNLOAD, GetColorType(2), LEDSender.SURVIVE_ALWAYS);

                LEDSender.Do_AddChapter(K, 30000, LEDSender.WAIT_CHILD);
                //添加区域
                for (int i = 0; i < arrEldRegion.Length; i++)
                {
                    var region = arrEldRegion[i];
                    LEDSender.Do_AddRegion(K, region.left, region.top, region.width, region.height, region.border);

                    var arrdisplayObj = arrleafObj[i].DisplayObjList;
                    uint next_time = uint.Parse(arrleafObj[i].Next_time.ToString());
                    if (next_time == 0)
                    {
                        next_time = 1000;
                    }

                    uint looptime = 1000 * next_time;

                    //
                    for (int k = 0; k < arrdisplayObj.Count; k++)
                    {
                        //添加页对象
                        //LEDSender.Do_AddLeaf(K, 10000, LEDSender.WAIT_CHILD);
                        LEDSender.Do_AddLeaf(K, looptime, LEDSender.WAIT_CHILD);
                        SendObjII(K, LEDSender, arrdisplayObj[k]);
                    }

                    //LEDSender.Do_AddText
                }
                Parse2(LEDSender.Do_LED_SendToScreen(ref param, K));
            }
            catch (Exception ex)
            {

                string path = @"d:\屏幕分区和发布信息.txt";
                WriteFile(path, ex.ToString());
            }

            finally
            {
                /*日志文件*/
                List<ELDRegion> listEldRegion = new List<ELDRegion>();
                for (int i = 0; i < arrEldRegion.Length; i++)
                {
                    listEldRegion.Add(arrEldRegion[i]);
                }
                string str1 = JsonConvert.SerializeObject(myTDeviceParam);
                string str2 = JsonConvert.SerializeObject(listEldRegion);
                string str3 = JsonConvert.SerializeObject(arrleafObj);
                string str = "MyTDeviceParam:\r\n" + str1 + "\r\narrEldRegion:\r\n" + str2 + "\r\n" + "\r\n" + "arrleafObj:" + str3 + "执行结果" + Text;
                string path = @"d:\屏幕分区和发布信息.txt";
                WriteFile(path, str);
                cacheLock.ExitWriteLock();
            }
            return Text;
        }

        /// <summary>
        /// 分区且实现内容填充（整屏写入）
        /// </summary>
        /// <param name="myTDeviceParam"></param>
        /// <param name="arrEldRegion"></param>
        /// <param name="arrdisplayObj"></param>
        /// <returns></returns>
        public string FenPingAndSends(MyTDeviceParam myTDeviceParam, ELDRegion[] arrEldRegion, DisplayObj[] arrdisplayObj)
        {
            ushort K;
            TDeviceParam deviceParam = new TDeviceParam();
            deviceParam.devType = LEDSender.DEVICE_TYPE_UDP;
            deviceParam.locPort = (ushort)myTDeviceParam.locPort;
            deviceParam.rmtHost = myTDeviceParam.rmtHost;
            deviceParam.rmtPort = (ushort)myTDeviceParam.rmtPort;
            deviceParam.dstAddr = 0;

            /*连接 LED 判断 是否打开 */
            TSenderParam param = new TSenderParam();
            param.devParam = deviceParam;

            param.notifyMode = LEDSender.NOTIFY_BLOCK;
            param.wmHandle = 0;
            param.wmMessage = 0;
            Text = "正在执行命令或者发送数据...";

            try
            {
                //进入写锁，其他所有访问操作的线程都被阻塞。即写独占锁。
                cacheLock.EnterWriteLock();
                K = (ushort)LEDSender.Do_MakeRoot(LEDSender.ROOT_DOWNLOAD, GetColorType(2), LEDSender.SURVIVE_ALWAYS);

                LEDSender.Do_AddChapter(K, 30000, LEDSender.WAIT_CHILD);
                //添加区域
                for (int i = 0; i < arrEldRegion.Length; i++)
                {
                    var region = arrEldRegion[i];
                    LEDSender.Do_AddRegion(K, region.left, region.top, region.width, region.height, region.border);

                    //添加页对象
                    LEDSender.Do_AddLeaf(K, 10000, LEDSender.WAIT_CHILD);

                    //
                    SendObjII(K, LEDSender, arrdisplayObj[i]);
                    //LEDSender.Do_AddText
                }
                Parse2(LEDSender.Do_LED_SendToScreen(ref param, K));
                // string TNotifyParamStr = JsonConvert.SerializeObject(hh)+ "K :"+ K;
                // string path = @"d:\TNotifyParamStr.txt";
                // WriteFile(path, TNotifyParamStr);
            }
            catch (Exception ex)
            {
                string path = @"d:\屏幕分区和发布信息.txt";
                WriteFile(path, ex.ToString());

            }
            finally
            {
                /*日志文件*/
                List<ELDRegion> listEldRegion = new List<ELDRegion>();
                for (int i = 0; i < arrEldRegion.Length; i++)
                {
                    listEldRegion.Add(arrEldRegion[i]);
                }
                string str1 = JsonConvert.SerializeObject(myTDeviceParam);
                string str2 = JsonConvert.SerializeObject(listEldRegion);
                string str = "MyTDeviceParam:\r\n" + str1 + "\r\narrEldRegion:\r\n" + str2 + "\r\n" + "执行结果" + Text + "\r\n";
                string path = @"d:\屏幕分区和发布信息.txt";
                WriteFile(path, str);
                cacheLock.ExitWriteLock();
            }



            return Text;
        }

        /// <summary>
        /// 向指定分区发送信息（断电断网 不保留发布信息）
        /// </summary>
        /// <param name="myTDeviceParam"></param>
        /// <param name="displayObj"></param>
        /// <param name="RegionIndex"></param>
        /// <returns></returns>
        public string SendObjToELD(MyTDeviceParam myTDeviceParam, DisplayObj displayObj, int RegionIndex)
        {
            try
            {//进入写锁，其他所有访问操作的线程都被阻塞。即写独占锁。
                cacheLock.EnterWriteLock();
                ushort K;
                TDeviceParam deviceParam = new TDeviceParam();
                deviceParam.devType = LEDSender.DEVICE_TYPE_UDP;
                deviceParam.locPort = (ushort)myTDeviceParam.locPort;
                deviceParam.rmtHost = myTDeviceParam.rmtHost;
                deviceParam.rmtPort = (ushort)myTDeviceParam.rmtPort;
                deviceParam.dstAddr = 0;

                /*连接 LED 判断 是否打开 */
                TSenderParam param = new TSenderParam();
                param.devParam = deviceParam;
                // GetDeviceParam(ref param.devParam);
                param.notifyMode = LEDSender.NOTIFY_BLOCK;
                param.wmHandle = 0;
                param.wmMessage = 0;
                Text = "正在执行命令或者发送数据...";
                //Parse2(LEDSender.Do_LED_GetPower(ref param));

                /* 如果设备没有打开 则打开设备*/
                //if (Text != "读取电源状态完成，当前为电源开启状态")
                //{
                //    SetPower(deviceParam, 1);
                //}
                //更新第1分区
                K = (ushort)LEDSender.Do_MakeLeaf(LEDSender.ROOT_PLAY_LEAF, LEDSender.ACTMODE_REPLACE, 0, RegionIndex, 0, GetColorType(), 10000, LEDSender.WAIT_CHILD);
                //LEDSender.Do_AddLeaf(K, 10000, LEDSender.WAIT_CHILD);
                SendObjII(K, LEDSender, displayObj);



                /*执行发送指令 内容发送到显示屏*/
                Parse2(LEDSender.Do_LED_SendToScreen(ref param, K));
            }
            finally
            {

                string str = JsonConvert.SerializeObject(displayObj) + "RegionIndex:" + RegionIndex;
                string path = @"d:\向指定分区发送信息.txt";
                FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.BaseStream.Seek(0, SeekOrigin.End);
                sw.Write(DateTime.Now.ToString() + ":" + str + "\r\n执行结果：" + Text + "\r\n");

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
                cacheLock.ExitWriteLock();
            }

            return Text;
        }
        private void SendObjII(ushort k1, CLEDSender ledSender1, DisplayObj displayObj)
        {
            switch (displayObj.ObjTypeIndex)
            {
                case 0:
                    {
                        /*Text 发送文字信息*/
                        TextPro textPro = displayObj.TextPro;
                        //    //自动换行的文字
                        //ledSender1.Do_AddText(k1, textPro.left, textPro.top, textPro.width, textPro.height, LEDSender.V_TRUE, textPro.border, textPro.str, textPro.fontname, textPro.fontsize,
                        //    textPro.fontcolor, LEDSender.WFS_NONE, LEDSender.V_FALSE, textPro.alignment, textPro.inmethod, textPro.inspeed, textPro.outmethod, textPro.outspeed,
                        //    textPro.stopmethod, textPro.stopspeed, textPro.stoptime);
                        ledSender1.Do_AddText(k1, textPro.left, textPro.top, textPro.width, textPro.height, LEDSender.V_TRUE, textPro.border, textPro.str, textPro.fontname, textPro.fontsize,
                         textPro.fontcolor, LEDSender.WFS_NONE, textPro.wordwrap, textPro.alignment, textPro.inmethod, textPro.inspeed, textPro.outmethod, textPro.outspeed,
                         textPro.stopmethod, textPro.stopspeed, textPro.stoptime);

                        break;
                    }
                case 1:
                    {

                        /*Picture 发送图片信息*/
                        PicturePro picturePro = displayObj.PicturePro;
                        ledSender1.Do_AddPicture(k1, picturePro.left, picturePro.top, picturePro.width, picturePro.height, LEDSender.V_TRUE, picturePro.border, picturePro.filename, picturePro.alignment, picturePro.inmethod, picturePro.inspeed,
                            picturePro.outmethod, picturePro.outspeed, picturePro.stopmethod, picturePro.stopspeed, picturePro.stoptime);
                        break;
                    }
                case 2:
                    {/*DateTime 发送日期时间信息*/
                        DateTimePro dateTimePro = displayObj.DateTimePro;

                        ledSender1.Do_AddDateTime(k1, dateTimePro.left, dateTimePro.top, dateTimePro.width, dateTimePro.height, LEDSender.V_TRUE, dateTimePro.border, dateTimePro.fontname, dateTimePro.fontsize, dateTimePro.fontcolor,
                            LEDSender.WFS_NONE, dateTimePro.year_offset, dateTimePro.month_offset, dateTimePro.day_offset, dateTimePro.sec_offset, dateTimePro.format);
                        break;
                    }
                case 3:
                    {/*Clock 发送时钟信息*/
                        ClockPro clockPro = displayObj.ClockPro;
                        ledSender1.Do_AddClock(k1, clockPro.left, clockPro.top, clockPro.width, clockPro.height, LEDSender.V_TRUE, clockPro.border, clockPro.offset, clockPro.bkcolor,
                            clockPro.bordercolor, clockPro.borderwidth, clockPro.bordershape, clockPro.dotradius, clockPro.adotwidth, clockPro.adotcolor, clockPro.bdotwidth, clockPro.bdotcolor,
                            clockPro.hourwidth, clockPro.hourcolor, clockPro.minutewidth, clockPro.minutecolor, clockPro.secondwidth, clockPro.secondcolor);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
        private void WriteFile(string path, string content)
        {
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.BaseStream.Seek(0, SeekOrigin.End);
            sw.Write(DateTime.Now.ToString() + ":" + content + "\n");
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
        public string FenPingII(MyTDeviceParam myTDeviceParam, ELDRegion[] arrEldRegion)
        {//
            try
            {
                //进入写锁，其他所有访问操作的线程都被阻塞。即写独占锁。
                cacheLock.EnterWriteLock();



                //
                ushort K;
                TDeviceParam deviceParam = new TDeviceParam();
                deviceParam.devType = LEDSender.DEVICE_TYPE_UDP;
                deviceParam.locPort = (ushort)myTDeviceParam.locPort;
                deviceParam.rmtHost = myTDeviceParam.rmtHost;
                deviceParam.rmtPort = (ushort)myTDeviceParam.rmtPort;
                deviceParam.dstAddr = 0;

                /*添加数据库信息*/
                BusinessLogic.road bllRoad = new BusinessLogic.road();
                Entity.Road m = new Entity.Road();
                m.r_id = myTDeviceParam.r_id;
                if (bllRoad.Exists(myTDeviceParam.rmtHost))
                {
                    m = bllRoad.GetModelByeld_rmtHost(myTDeviceParam.rmtHost);
                }
                m.rmtPort = myTDeviceParam.rmtPort;
                m.displayType = myTDeviceParam.displayType;
                m.locPort = myTDeviceParam.locPort;
                m.eld_rmtHost = myTDeviceParam.rmtHost;
                m.r_id = myTDeviceParam.r_id;
                m.r_name = myTDeviceParam.r_name;
                if (bllRoad.Exists(myTDeviceParam.rmtHost))
                {
                    bllRoad.UpdateByIp(m);
                }
                else
                {
                    bllRoad.Add(m);
                }


                /*添加告警信息*/
                for (int i = 0; i < arrEldRegion.Length; i++)
                {
                    var item = arrEldRegion[i];
                    if (item.RegionType == 1)
                    {
                        BusinessLogic.region bllRegion = new BusinessLogic.region();
                        Entity.region m1 = new Entity.region();
                        if (bllRegion.ExistsByELD_IP(item.ELD_IP))
                        {
                            m1 = bllRegion.GetModel(item.ELD_IP);
                        }
                        m1.ELD_IP = myTDeviceParam.rmtHost;
                        m1.Region_Index = item.Region_Index;
                        m1.Region_Type = 1;
                        m1.border = item.border;
                        m1.height = item.height;
                        m1.left = item.left;
                        m1.road_id = item.road_id;
                        m1.ELD_IP = item.ELD_IP;
                        m1.top = item.top;
                        m1.width = item.width;
                        if (bllRegion.ExistsByELD_IP(m1.ELD_IP))
                        {
                            bllRegion.Update(m1);
                        }
                        else
                        {
                            bllRegion.Add(m1);
                        }

                    }
                }
                /*连接 LED 判断 是否打开 */
                TSenderParam param = new TSenderParam();
                param.devParam = deviceParam;

                param.notifyMode = LEDSender.NOTIFY_BLOCK;
                param.wmHandle = 0;
                param.wmMessage = 0;
                Text = "正在执行命令或者发送数据...";
                //Parse2(LEDSender.Do_LED_GetPower(ref param));

                ///* 如果设备没有打开 则打开设备*/
                //if (Text != "读取电源状态完成，当前为电源开启状态")
                //{
                //    SetPower(deviceParam, 1);
                //}
                /*
                 ROOT_DOWNLOAD:再次通电 保留分区信息
                 */
                K = (ushort)LEDSender.Do_MakeRoot(LEDSender.ROOT_DOWNLOAD, GetColorType(2), LEDSender.SURVIVE_ALWAYS);

                LEDSender.Do_AddChapter(K, 30000, LEDSender.WAIT_CHILD);
                // LEDSender.Do_AddRegion(K, 0, 0, 240, 32, 0);
                //添加区域
                for (int i = 0; i < arrEldRegion.Length; i++)
                {
                    var region = arrEldRegion[i];
                    LEDSender.Do_AddRegion(K, region.left, region.top, region.width, region.height, region.border);

                    //添加页对象
                    LEDSender.Do_AddLeaf(K, 10000, LEDSender.WAIT_CHILD);

                    //
                    //LEDSender.Do_AddText
                }
                Parse2(LEDSender.Do_LED_SendToScreen(ref param, K));
            }
            finally
            {
                /*日志文件*/
                List<ELDRegion> listEldRegion = new List<ELDRegion>();
                for (int i = 0; i < arrEldRegion.Length; i++)
                {
                    listEldRegion.Add(arrEldRegion[i]);
                }
                string str1 = JsonConvert.SerializeObject(myTDeviceParam);
                string str2 = JsonConvert.SerializeObject(listEldRegion);
                string str = "MyTDeviceParam:\r\n" + str1 + "\r\narrEldRegion:\r\n" + str2 + "\r\n" + "执行结果" + Text + "\r\n";
                string path = @"d:\屏幕分区.txt";
                FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.BaseStream.Seek(0, SeekOrigin.End);
                sw.Write(DateTime.Now.ToString() + ":" + str + "\n");
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
                cacheLock.ExitWriteLock();
            }


            //  return "分屏完成";
            return Text;

        }

        private void Parse2(Int32 K)
        {
            TNotifyParam notifyparam = new TNotifyParam();
            if (K >= 0)
            {
                LEDSender.Do_LED_GetNotifyParam(ref notifyparam, K);

                if (notifyparam.notify == LEDSender.LM_TIMEOUT)
                {
                    Text = "命令执行超时";
                }
                else if (notifyparam.notify == LEDSender.LM_TX_COMPLETE)
                {
                    if (notifyparam.result == LEDSender.RESULT_FLASH)
                    {
                        Text = "数据传送完成，正在写入Flash";
                    }
                    else
                    {
                        Text = "数据传送完成";
                    }
                }
                else if (notifyparam.notify == LEDSender.LM_NOTIFY)
                {
                    // notifyparam.command,notifyparam.status,notifyparam.result

                    if (notifyparam.result == LEDSender.NOTIFY_ROOT_DOWNLOAD)
                    {
                        Text = "数据传送完成";
                    }
                }
                else if (notifyparam.notify == LEDSender.LM_RESPOND)
                {
                    if (notifyparam.command == LEDSender.PKC_GET_POWER)
                    {
                        if (notifyparam.status == LEDSender.LED_POWER_ON) Text = "读取电源状态完成，当前为电源开启状态";
                        else if (notifyparam.status == LEDSender.LED_POWER_OFF) Text = "读取电源状态完成，当前为电源关闭状态";
                    }
                    else if (notifyparam.command == LEDSender.PKC_SET_POWER)
                    {
                        if (notifyparam.result == 99) Text = "当前为定时开关屏模式";
                        else if (notifyparam.status == LEDSender.LED_POWER_ON) Text = "设置电源状态完成，当前为电源开启状态";
                        else Text = "设置电源状态完成，当前为电源关闭状态";
                    }
                    else if (notifyparam.command == LEDSender.PKC_GET_BRIGHT)
                    {
                        Text = string.Format("读取亮度完成，当前亮度={0:D}", notifyparam.status);
                    }
                    else if (notifyparam.command == LEDSender.PKC_SET_BRIGHT)
                    {
                        if (notifyparam.result == 99) Text = "当前为定时亮度调节模式";
                        else Text = string.Format("设置亮度完成，当前亮度={0:D}", notifyparam.status);
                    }
                    else if (notifyparam.command == LEDSender.PKC_ADJUST_TIME)
                    {
                        Text = "校正显示屏时间完成";
                    }
                }
            }
            else if (K == LEDSender.R_DEVICE_INVALID) Text = "打开通讯设备失败(串口不存在、或者串口已被占用、或者网络端口被占用)";
            else if (K == LEDSender.R_DEVICE_BUSY) Text = "设备忙，正在通讯中...";


        }

        /// <summary>
        /// 获取屏幕基色 (一般取2)
        ///  //显示屏基色类型
        //COLOR_MODE_MONO = 1;  //单色
        // COLOR_MODE_DOUBLE = 2;  //双色
        //COLOR_MODE_THREE = 3;  //全彩无灰度
        //COLOR_MODE_FULLCOLOR = 4;  //全彩
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private int GetColorType(int index)
        {
            switch (index)
            {
                case 1: return LEDSender.COLOR_MODE_MONO;
                case 2: return LEDSender.COLOR_MODE_DOUBLE;
                case 3: return LEDSender.COLOR_MODE_THREE;
                case 4: return LEDSender.COLOR_MODE_FULLCOLOR;
                default: return LEDSender.COLOR_MODE_DOUBLE;
            }
        }


        private int GetColorType()
        {
            return LEDSender.COLOR_MODE_DOUBLE;
            //switch (cmbColorType.SelectedIndex)
            //{
            //    case 1: return LEDSender.COLOR_MODE_THREE;
            //    case 2: return LEDSender.COLOR_MODE_FULLCOLOR;
            //    default: return LEDSender.COLOR_MODE_DOUBLE;
            //}
        }
    }
}