Public Class MainForm

    Private FParam As TSenderParam = New TSenderParam

    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbDevType.SelectedIndex = 1
        cmbBaudRate.SelectedIndex = 0
        LED_Startup()
        Hook(Me.Handle)
    End Sub

    Private Sub MainForm_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        LED_Cleanup()
        UnHook(Me.Handle)
    End Sub

    Private Sub GetDeviceParam()
        If cmbDevType.SelectedIndex = 0 Then
            FParam.devParam.devType = DEVICE_TYPE_COM
        Else
            FParam.devParam.devType = DEVICE_TYPE_UDP
        End If
        FParam.devParam.comPort = eCommPort.Text
        FParam.devParam.comSpeed = cmbBaudRate.SelectedIndex
        FParam.devParam.rmtHost = eRemoteHost.Text
        FParam.devParam.locPort = eLocalPort.Text
        FParam.devParam.rmtPort = 6666
        FParam.devParam.comFlow = 0
        FParam.devParam.dstAddr = eAddress.Text
        FParam.devParam.srcAddr = 0
        FParam.devParam.txTimeo = 500
        FParam.devParam.txRepeat = 2
        FParam.devParam.txSlide = 0
        FParam.notifyMode = 0
        FParam.wmHandle = 0
        FParam.wmLParam = 0
        FParam.wmMessage = 0
    End Sub

    Private Sub Parse(ByVal K As Long)
        If K = R_DEVICE_READY Then
            Text = "正在执行命令或者发送数据..."
            SendStatus = 1
        ElseIf K = R_DEVICE_INVALID Then
            Text = "打开通讯设备失败(串口不存在、或者串口已被占用、或者网络端口被占用)"
        ElseIf K = R_DEVICE_BUSY Then
            Text = "设备忙，正在通讯中..."
        End If
    End Sub

    Private Sub btnPowerOn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPowerOn.Click
        GetDeviceParam()
        FParam.notifyMode = NOTIFY_EVENT
        FParam.wmHandle = Me.Handle
        FParam.wmMessage = WM_LED_NOTIFY
        Parse(LED_SetPower(FParam, LED_POWER_ON))
    End Sub

    Private Sub btnPowerOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPowerOff.Click
        GetDeviceParam()
        FParam.notifyMode = NOTIFY_EVENT
        FParam.wmHandle = Me.Handle
        FParam.wmMessage = WM_LED_NOTIFY
        Parse(LED_SetPower(FParam, LED_POWER_OFF))
    End Sub

    Private Sub btnGetPower_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetPower.Click
        GetDeviceParam()
        FParam.notifyMode = NOTIFY_EVENT
        FParam.wmHandle = Me.Handle
        FParam.wmMessage = WM_LED_NOTIFY
        Parse(LED_GetPower(FParam))
    End Sub

    Private Sub btnSetBright_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetBright.Click
        GetDeviceParam()
        FParam.notifyMode = NOTIFY_EVENT
        FParam.wmHandle = Me.Handle
        FParam.wmMessage = WM_LED_NOTIFY
        Parse(LED_SetBright(FParam, 7))
    End Sub

    Private Sub btnGetBright_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetBright.Click
        GetDeviceParam()
        FParam.notifyMode = NOTIFY_EVENT
        FParam.wmHandle = Me.Handle
        FParam.wmMessage = WM_LED_NOTIFY
        Parse(LED_GetBright(FParam))
    End Sub

    Private Sub btnAdjustTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdjustTime.Click
        GetDeviceParam()
        FParam.notifyMode = NOTIFY_EVENT
        FParam.wmHandle = Me.Handle
        FParam.wmMessage = WM_LED_NOTIFY
        Parse(LED_AdjustTime(FParam))
    End Sub

    Private Sub btnText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnText.Click
        Dim K As Integer
        GetDeviceParam()
        FParam.notifyMode = NOTIFY_EVENT
        FParam.wmHandle = Me.Handle
        FParam.wmMessage = WM_LED_NOTIFY

        K = MakeRoot(ROOT_PLAY, COLOR_MODE_DOUBLE)
        AddChapter(K, 10000, WAIT_CHILD)
        AddRegion(K, 0, 0, 64, 64, 0)
        AddLeaf(K, 10000, WAIT_CHILD)
        AddText(K, 0, 0, 64, 32, 1, 0, "你好", "宋体", 12, RGB(255, 255, 0), WFS_BOLD, 0, 0, 1, 0, 1, 0, 0, 0, 1000)
        Parse(LED_SendToScreen(FParam, K))
    End Sub

    Private Sub btnDib_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDib.Click
        Dim K As Long

        GetDeviceParam()
        FParam.notifyMode = NOTIFY_EVENT
        FParam.wmHandle = Handle
        FParam.wmMessage = WM_LED_NOTIFY

        K = MakeRoot(ROOT_PLAY, COLOR_MODE_DOUBLE)
        AddChapter(K, 10000, WAIT_CHILD)
        AddRegion(K, 0, 0, 64, 64, 0)
        AddLeaf(K, 10000, WAIT_CHILD)
        AddWindow(K, 0, 0, 64, 32, 1, 0, pictureBox.Handle, pictureBox.Image.Width, pictureBox.Image.Height, 0, 1, 0, 1, 0, 0, 0, 1000)
        Parse(LED_SendToScreen(FParam, K))
    End Sub

    Private Sub btnPicFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPicFile.Click
        Dim K As Long

        GetDeviceParam()
        FParam.notifyMode = NOTIFY_EVENT
        FParam.wmHandle = Handle
        FParam.wmMessage = WM_LED_NOTIFY

        K = MakeRoot(ROOT_PLAY, COLOR_MODE_DOUBLE)
        AddChapter(K, 10000, WAIT_CHILD)
        AddRegion(K, 0, 0, 64, 64, 0)
        AddLeaf(K, 10000, WAIT_CHILD)
        AddPicture(K, 0, 0, 64, 32, 1, 0, "Demo.bmp", 0, 1, 0, 1, 0, 0, 0, 1000)
        Parse(LED_SendToScreen(FParam, K))

    End Sub

    Private Sub btnString_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnString.Click
        Dim K As Long

        GetDeviceParam()
        FParam.notifyMode = NOTIFY_EVENT
        FParam.wmHandle = Handle
        FParam.wmMessage = WM_LED_NOTIFY

        K = MakeRoot(ROOT_PLAY, COLOR_MODE_DOUBLE)
        AddChapter(K, 10000, WAIT_CHILD)
        AddRegion(K, 0, 0, 64, 64, 0)
        AddLeaf(K, 10000, WAIT_CHILD)
        AddString(K, 0, 0, 64, 32, 1, 0, "你好", 1, RGB(255, 0, 0), 1, 0, 1, 0, 0, 0, 1000)
        Parse(LED_SendToScreen(FParam, K))
    End Sub

    Private Sub btnDateTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDateTime.Click
        Dim K As Long

        GetDeviceParam()
        FParam.notifyMode = NOTIFY_EVENT
        FParam.wmHandle = Handle
        FParam.wmMessage = WM_LED_NOTIFY

        K = MakeRoot(ROOT_PLAY, COLOR_MODE_DOUBLE)
        AddChapter(K, 10000, WAIT_CHILD)
        AddRegion(K, 0, 0, 64, 64, 0)
        AddLeaf(K, 10000, WAIT_CHILD)
        AddDateTime(K, 0, 0, 64, 32, 1, 0, "宋体", 12, RGB(0, 255, 0), 0, 0, 0, 0, 0, "#y年#m月#d日 #h:#n:#s 星期#w 农历#c")
        Parse(LED_SendToScreen(FParam, K))
    End Sub

    Private Sub btnClock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClock.Click
        Dim K As Long

        GetDeviceParam()
        FParam.notifyMode = NOTIFY_EVENT
        FParam.wmHandle = Handle
        FParam.wmMessage = WM_LED_NOTIFY

        K = MakeRoot(ROOT_PLAY, COLOR_MODE_DOUBLE)
        AddChapter(K, 10000, WAIT_CHILD)
        AddRegion(K, 0, 0, 64, 64, 0)
        AddLeaf(K, 10000, WAIT_CHILD)
        AddClock(K, 0, 0, 64, 64, 1, 0, 0, RGB(0, 0, 0), RGB(255, 255, 0), 1, SHAPE_CIRCLE, 30, 3, RGB(255, 255, 0), 2, RGB(0, 255, 0), 3, RGB(255, 255, 0), 2, RGB(0, 255, 0), 1, RGB(255, 0, 0))
        Parse(LED_SendToScreen(FParam, K))
    End Sub

    Private Sub Parse2(ByVal K As Long)
        Dim notifyparam As TNotifyParam = New TNotifyParam
        If K >= 0 Then
            LED_GetNotifyParam(notifyparam, K)
            If notifyparam.notify = LM_TIMEOUT Then
                Text = "发送超时"
            ElseIf notifyparam.notify = LM_TX_COMPLETE Then
                If notifyparam.Result = RESULT_FLASH Then
                    Text = "数据传送完成，正在写入Flash"
                Else
                    Text = "数据传送完成"
                End If
            ElseIf notifyparam.notify = LM_RESPOND Then
                If notifyparam.Command = PKC_GET_POWER Then
                    If notifyparam.Status = LED_POWER_ON Then
                        Text = "读取电源状态完成，当前为电源开启状态"
                    Else
                        Text = "读取电源状态完成，当前为电源关闭状态"
                    End If
                ElseIf notifyparam.Command = PKC_SET_POWER Then
                    If notifyparam.Result = 99 Then
                        Text = "当前为定时开关屏模式"
                    ElseIf notifyparam.Status = LED_POWER_ON Then
                        Text = "设置电源状态完成，当前为电源开启状态"
                    Else
                        Text = "设置电源状态完成，当前为电源关闭状态"
                    End If
                ElseIf notifyparam.Command = PKC_GET_BRIGHT Then
                    Text = "读取亮度完成，当前亮度=" & notifyparam.Status
                ElseIf notifyparam.Command = PKC_SET_BRIGHT Then
                    If notifyparam.Result = 99 Then
                        Text = "当前为定时亮度调节模式"
                    Else
                        Text = "设置亮度完成，当前亮度=" & notifyparam.Status
                    End If
                ElseIf notifyparam.Command = PKC_ADJUST_TIME Then
                    Text = "校正显示屏时间完成"
                End If
            ElseIf notifyparam.notify = LM_NOTIFY Then
            End If
        ElseIf K = R_DEVICE_INVALID Then
            Text = "打开通讯设备失败(串口不存在、或者串口已被占用、或者网络端口被占用)"
        ElseIf K = R_DEVICE_BUSY Then
            Text = "设备忙，正在通讯中..."
        End If
    End Sub

    Private Sub btnPowerOn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPowerOn2.Click
        GetDeviceParam()
        FParam.notifyMode = NOTIFY_BLOCK
        FParam.wmHandle = 0
        FParam.wmMessage = 0
        Text = "正在执行命令或者发送数据..."
        Parse2(LED_SetPower(FParam, LED_POWER_ON))
    End Sub

    Private Sub btnPowerOff2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPowerOff2.Click
        GetDeviceParam()
        FParam.notifyMode = NOTIFY_BLOCK
        FParam.wmHandle = 0
        FParam.wmMessage = 0
        Text = "正在执行命令或者发送数据..."
        Parse2(LED_SetPower(FParam, LED_POWER_OFF))
    End Sub

    Private Sub btnGetPower2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetPower2.Click
        GetDeviceParam()
        FParam.notifyMode = NOTIFY_BLOCK
        FParam.wmHandle = 0
        FParam.wmMessage = 0
        Text = "正在执行命令或者发送数据..."
        Parse2(LED_GetPower(FParam))
    End Sub

    Private Sub btnSetBright2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetBright2.Click
        GetDeviceParam()
        FParam.notifyMode = NOTIFY_BLOCK
        FParam.wmHandle = 0
        FParam.wmMessage = 0
        Text = "正在执行命令或者发送数据..."
        Parse2(LED_SetBright(FParam, 4))
    End Sub

    Private Sub btnGetBright2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetBright2.Click
        GetDeviceParam()
        FParam.notifyMode = NOTIFY_BLOCK
        FParam.wmHandle = 0
        FParam.wmMessage = 0
        Text = "正在执行命令或者发送数据..."
        Parse2(LED_GetBright(FParam))
    End Sub

    Private Sub btnAdjustTime2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdjustTime2.Click
        GetDeviceParam()
        FParam.notifyMode = NOTIFY_BLOCK
        FParam.wmHandle = 0
        FParam.wmMessage = 0
        Text = "正在执行命令或者发送数据..."
        Parse2(LED_AdjustTime(FParam))
    End Sub

    Private Sub btnText2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnText2.Click
        Dim K As Long

        GetDeviceParam()
        FParam.notifyMode = NOTIFY_BLOCK
        FParam.wmHandle = 0
        FParam.wmMessage = 0

        K = MakeRoot(ROOT_PLAY, COLOR_MODE_DOUBLE)
        AddChapter(K, 10000, WAIT_CHILD)
        AddRegion(K, 0, 0, 64, 64, 0)
        AddLeaf(K, 10000, WAIT_CHILD)
        AddText(K, 0, 0, 64, 32, 1, 0, "你好", "宋体", 12, RGB(255, 255, 0), WFS_BOLD, 0, 0, 1, 0, 1, 0, 0, 0, 1000)
        Text = "正在执行命令或者发送数据..."
        Parse2(LED_SendToScreen(FParam, K))
    End Sub

    Private Sub btnString2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnString2.Click
        Dim K As Long

        GetDeviceParam()
        FParam.notifyMode = NOTIFY_NONE
        FParam.wmHandle = 0
        FParam.wmMessage = 0

        K = MakeRoot(ROOT_PLAY, COLOR_MODE_DOUBLE)
        AddChapter(K, 10000, WAIT_CHILD)
        AddRegion(K, 0, 0, 64, 64, 0)
        AddLeaf(K, 10000, WAIT_CHILD)
        AddString(K, 0, 0, 64, 32, 1, 0, "你好", 1, RGB(255, 0, 0), 1, 0, 1, 0, 0, 0, 1000)
        Text = "正在执行命令或者发送数据..."
        Parse2(LED_SendToScreen(FParam, K))
    End Sub

    Private Sub btnDateTime2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDateTime2.Click
        Dim K As Long

        GetDeviceParam()
        FParam.notifyMode = NOTIFY_BLOCK
        FParam.wmHandle = 0
        FParam.wmMessage = 0

        K = MakeRoot(ROOT_PLAY, COLOR_MODE_DOUBLE)
        AddChapter(K, 10000, WAIT_CHILD)
        AddRegion(K, 0, 0, 64, 64, 0)
        AddLeaf(K, 10000, WAIT_CHILD)
        AddDateTime(K, 0, 0, 64, 32, 1, 0, "宋体", 12, RGB(0, 255, 0), 0, 0, 0, 0, 0, "#y年#m月#d日 #h:#n:#s 星期#w 农历#c")
        Text = "正在执行命令或者发送数据..."
        Parse2(LED_SendToScreen(FParam, K))
    End Sub

    Private Sub btnDib2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDib2.Click
        Dim K As Long

        GetDeviceParam()
        FParam.notifyMode = NOTIFY_BLOCK
        FParam.wmHandle = 0
        FParam.wmMessage = 0

        K = MakeRoot(ROOT_PLAY, COLOR_MODE_DOUBLE)
        AddChapter(K, 10000, WAIT_CHILD)
        AddRegion(K, 0, 0, 64, 64, 0)
        AddLeaf(K, 10000, WAIT_CHILD)
        AddWindow(K, 0, 0, 64, 32, 1, 0, pictureBox.Handle, pictureBox.Image.Width, pictureBox.Image.Height, 0, 1, 0, 1, 0, 0, 0, 1000)
        Text = "正在执行命令或者发送数据..."
        Parse2(LED_SendToScreen(FParam, K))
    End Sub

    Private Sub btnPicFile2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPicFile2.Click
        Dim K As Long

        GetDeviceParam()
        FParam.notifyMode = NOTIFY_BLOCK
        FParam.wmHandle = 0
        FParam.wmMessage = 0

        K = MakeRoot(ROOT_PLAY, COLOR_MODE_DOUBLE)
        AddChapter(K, 10000, WAIT_CHILD)
        AddRegion(K, 0, 0, 64, 64, 0)
        AddLeaf(K, 10000, WAIT_CHILD)
        AddPicture(K, 0, 0, 64, 32, 1, 0, "Demo.bmp", 0, 1, 0, 1, 0, 0, 0, 1000)
        Text = "正在执行命令或者发送数据..."
        Parse2(LED_SendToScreen(FParam, K))
    End Sub

    Private Sub btnClock2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClock2.Click
        Dim K As Long

        GetDeviceParam()
        FParam.notifyMode = NOTIFY_BLOCK
        FParam.wmHandle = 0
        FParam.wmMessage = 0

        K = MakeRoot(ROOT_PLAY, COLOR_MODE_DOUBLE)
        AddChapter(K, 10000, WAIT_CHILD)
        AddRegion(K, 0, 0, 64, 64, 0)
        AddLeaf(K, 10000, WAIT_CHILD)
        AddClock(K, 0, 0, 64, 64, 1, 0, 0, RGB(0, 0, 0), RGB(255, 255, 0), 1, SHAPE_CIRCLE, 30, 3, RGB(255, 255, 0), 2, RGB(0, 255, 0), 3, RGB(255, 255, 0), 2, RGB(0, 255, 0), 1, RGB(255, 0, 0))
        Text = "正在执行命令或者发送数据..."
        Parse2(LED_SendToScreen(FParam, K))
    End Sub

    Private Sub btnChapter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChapter.Click
        Dim K As Long

        GetDeviceParam()
        FParam.notifyMode = NOTIFY_EVENT
        FParam.wmHandle = Handle
        FParam.wmMessage = WM_LED_NOTIFY

        '这个操作中，ChapterIndex=0，只更新控制卡内第1个节目
        '如果ChapterIndex=1，只更新控制卡内第2个节目
        '以此类推
        K = MakeChapter(ROOT_PLAY_CHAPTER, ACTMODE_REPLACE, 0, COLOR_MODE_DOUBLE, 10000, WAIT_CHILD)
        AddRegion(K, 0, 0, 64, 64, 0)
        AddLeaf(K, 10000, WAIT_CHILD)
        AddText(K, 0, 0, 64, 32, 1, 0, "你好", "宋体", 12, RGB(255, 255, 0), WFS_BOLD, 0, 0, 1, 0, 1, 0, 0, 0, 1000)
        Parse(LED_SendToScreen(FParam, K))
    End Sub

    Private Sub btnRegion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegion.Click
        Dim K As Long

        GetDeviceParam()
        FParam.notifyMode = NOTIFY_EVENT
        FParam.wmHandle = Handle
        FParam.wmMessage = WM_LED_NOTIFY

        '这个操作中，ChapterIndex=0，RegionIndex=0，只更新控制卡内第1个节目中的第1个分区
        '如果ChapterIndex=1，RegionIndex=2，只更新控制卡内第2个节目中的第3个分区
        '以此类推
        K = MakeRegion(ROOT_PLAY_REGION, ACTMODE_REPLACE, 0, 0, COLOR_MODE_DOUBLE, 0, 0, 64, 64, 0)
        AddLeaf(K, 10000, WAIT_CHILD)
        AddText(K, 0, 0, 64, 32, 1, 0, "你好", "宋体", 12, RGB(255, 255, 0), WFS_BOLD, 0, 0, 1, 0, 1, 0, 0, 0, 1000)
        Parse(LED_SendToScreen(FParam, K))
    End Sub

    Private Sub btnLeaf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeaf.Click
        Dim K As Long

        GetDeviceParam()
        FParam.notifyMode = NOTIFY_EVENT
        FParam.wmHandle = Handle
        FParam.wmMessage = WM_LED_NOTIFY

        '这个操作中，ChapterIndex=0，RegionIndex=0，LeafIndex=0，只更新控制卡内第1个节目中的第1个分区中的第1个页面
        '如果ChapterIndex=1，RegionIndex=2，LeafIndex=1，只更新控制卡内第2个节目中的第3个分区中的第2个页面
        '以此类推
        K = MakeLeaf(ROOT_PLAY_LEAF, ACTMODE_REPLACE, 0, 0, 0, COLOR_MODE_DOUBLE, 5000, WAIT_CHILD)
        AddText(K, 0, 0, 64, 32, 1, 0, "你好", "宋体", 12, RGB(255, 255, 0), WFS_BOLD, 0, 0, 1, 0, 1, 0, 0, 0, 1000)
        Parse(LED_SendToScreen(FParam, K))
    End Sub
End Class
