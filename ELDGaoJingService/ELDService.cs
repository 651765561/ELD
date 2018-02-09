using ELDGaoJingService.Entity.Partial;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ELDGaoJingService
{
    public class ELDService
    {
        private const int WM_LED_NOTIFY = 1025;
        private ReaderWriterLockSlim cacheLock = new ReaderWriterLockSlim();
        string Text = "发送成功！";
        CLEDSender LEDSender = new CLEDSender();
        #region  ELD屏操作

        /// <summary>
        /// 
        /// </summary>
        /// <param name="myTDeviceParam"></param>
        /// <returns></returns>
        public string AdjustTime(TDeviceParam deviceParam)
        {

            try
            {
                //进入写锁，其他所有访问操作的线程都被阻塞。即写独占锁。
                cacheLock.EnterWriteLock();
                ushort K;
                deviceParam.dstAddr = 0;
                /*解决超时问题*/
                deviceParam.txTimeo = 100;
                deviceParam.txRepeat = 5;
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
            catch (Exception ex)
            {

                return Text;
            }
            finally
            {
                cacheLock.ExitWriteLock();
            }


        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceParam"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public string SetPower(TDeviceParam deviceParam, int val)
        {

            TSenderParam param = new TSenderParam();
            param.devParam = deviceParam;
            param.notifyMode = LEDSender.NOTIFY_BLOCK;

            /*阻塞方式下 
             * wmHandle ；wmMessage 可以都取0值
             */
            param.wmHandle = 0;
            param.wmMessage = 0;
            Text = "正在执行命令或者发送数据...";
            Parse2(LEDSender.Do_LED_SetPower(ref param, val));
            return Text;
        }

        /// <summary>
        /// 不支持分页 一个分区只显示一条信息
        /// </summary>
        /// <param name="myTDeviceParam"></param>
        /// <param name="displayObj"></param>
        /// <param name="regionObj"></param>
        /// <param name="RegionIndex"></param>
        /// <returns></returns>
        public string SendObjToELD(MyTDeviceParam myTDeviceParam, DisplayObj displayObj,Entity.led_region regionObj, int RegionIndex)
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
                /*解决超时问题*/
                deviceParam.txTimeo = 100;
                deviceParam.txRepeat = 5;

                /*连接 LED 判断 是否打开 */
                TSenderParam param = new TSenderParam();
                param.devParam = deviceParam;
                // GetDeviceParam(ref param.devParam);
                param.notifyMode = LEDSender.NOTIFY_BLOCK;
                param.wmHandle = 0;
                param.wmMessage = 0;
                Text = "正在执行命令或者发送数据...";
              
                K = (ushort)LEDSender.Do_MakeRegion(LEDSender.ROOT_PLAY_REGION, LEDSender.ACTMODE_REPLACE, 0, RegionIndex, GetColorType(), regionObj.region_left, regionObj.region_top, regionObj.region_width, regionObj.text_height, displayObj.TextPro.border);
                LEDSender.Do_AddLeaf(K, 10000, LEDSender.WAIT_CHILD);
                SendObjII(K, LEDSender, displayObj);

                /*执行发送指令 内容发送到显示屏*/
                Parse2(LEDSender.Do_LED_SendToScreen(ref param, K));
                Thread.Sleep(2 * 1000);
            }
            finally
            {

                string str = JsonConvert.SerializeObject(displayObj) + "RegionIndex:" + RegionIndex;
                string fpath = @"d:\告警播放设备日志\";
                string path = fpath + myTDeviceParam.rmtHost + ".txt";
                if (!Directory.Exists(fpath))
                {
                    Directory.CreateDirectory(fpath);
                }

                FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.BaseStream.Seek(0, SeekOrigin.End);
                sw.Write(DateTime.Now.ToString() + "\r\n:" + str + "\r\n执行结果：" + Text + "\r\n");

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="K"></param>
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
        #endregion
    }
}
