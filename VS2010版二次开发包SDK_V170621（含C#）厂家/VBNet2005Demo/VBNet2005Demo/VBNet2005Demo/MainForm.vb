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
            Text = "����ִ��������߷�������..."
            SendStatus = 1
        ElseIf K = R_DEVICE_INVALID Then
            Text = "��ͨѶ�豸ʧ��(���ڲ����ڡ����ߴ����ѱ�ռ�á���������˿ڱ�ռ��)"
        ElseIf K = R_DEVICE_BUSY Then
            Text = "�豸æ������ͨѶ��..."
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
        AddText(K, 0, 0, 64, 32, 1, 0, "���", "����", 12, RGB(255, 255, 0), WFS_BOLD, 0, 0, 1, 0, 1, 0, 0, 0, 1000)
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
        AddString(K, 0, 0, 64, 32, 1, 0, "���", 1, RGB(255, 0, 0), 1, 0, 1, 0, 0, 0, 1000)
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
        AddDateTime(K, 0, 0, 64, 32, 1, 0, "����", 12, RGB(0, 255, 0), 0, 0, 0, 0, 0, "#y��#m��#d�� #h:#n:#s ����#w ũ��#c")
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
                Text = "���ͳ�ʱ"
            ElseIf notifyparam.notify = LM_TX_COMPLETE Then
                If notifyparam.Result = RESULT_FLASH Then
                    Text = "���ݴ�����ɣ�����д��Flash"
                Else
                    Text = "���ݴ������"
                End If
            ElseIf notifyparam.notify = LM_RESPOND Then
                If notifyparam.Command = PKC_GET_POWER Then
                    If notifyparam.Status = LED_POWER_ON Then
                        Text = "��ȡ��Դ״̬��ɣ���ǰΪ��Դ����״̬"
                    Else
                        Text = "��ȡ��Դ״̬��ɣ���ǰΪ��Դ�ر�״̬"
                    End If
                ElseIf notifyparam.Command = PKC_SET_POWER Then
                    If notifyparam.Result = 99 Then
                        Text = "��ǰΪ��ʱ������ģʽ"
                    ElseIf notifyparam.Status = LED_POWER_ON Then
                        Text = "���õ�Դ״̬��ɣ���ǰΪ��Դ����״̬"
                    Else
                        Text = "���õ�Դ״̬��ɣ���ǰΪ��Դ�ر�״̬"
                    End If
                ElseIf notifyparam.Command = PKC_GET_BRIGHT Then
                    Text = "��ȡ������ɣ���ǰ����=" & notifyparam.Status
                ElseIf notifyparam.Command = PKC_SET_BRIGHT Then
                    If notifyparam.Result = 99 Then
                        Text = "��ǰΪ��ʱ���ȵ���ģʽ"
                    Else
                        Text = "����������ɣ���ǰ����=" & notifyparam.Status
                    End If
                ElseIf notifyparam.Command = PKC_ADJUST_TIME Then
                    Text = "У����ʾ��ʱ�����"
                End If
            ElseIf notifyparam.notify = LM_NOTIFY Then
            End If
        ElseIf K = R_DEVICE_INVALID Then
            Text = "��ͨѶ�豸ʧ��(���ڲ����ڡ����ߴ����ѱ�ռ�á���������˿ڱ�ռ��)"
        ElseIf K = R_DEVICE_BUSY Then
            Text = "�豸æ������ͨѶ��..."
        End If
    End Sub

    Private Sub btnPowerOn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPowerOn2.Click
        GetDeviceParam()
        FParam.notifyMode = NOTIFY_BLOCK
        FParam.wmHandle = 0
        FParam.wmMessage = 0
        Text = "����ִ��������߷�������..."
        Parse2(LED_SetPower(FParam, LED_POWER_ON))
    End Sub

    Private Sub btnPowerOff2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPowerOff2.Click
        GetDeviceParam()
        FParam.notifyMode = NOTIFY_BLOCK
        FParam.wmHandle = 0
        FParam.wmMessage = 0
        Text = "����ִ��������߷�������..."
        Parse2(LED_SetPower(FParam, LED_POWER_OFF))
    End Sub

    Private Sub btnGetPower2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetPower2.Click
        GetDeviceParam()
        FParam.notifyMode = NOTIFY_BLOCK
        FParam.wmHandle = 0
        FParam.wmMessage = 0
        Text = "����ִ��������߷�������..."
        Parse2(LED_GetPower(FParam))
    End Sub

    Private Sub btnSetBright2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetBright2.Click
        GetDeviceParam()
        FParam.notifyMode = NOTIFY_BLOCK
        FParam.wmHandle = 0
        FParam.wmMessage = 0
        Text = "����ִ��������߷�������..."
        Parse2(LED_SetBright(FParam, 4))
    End Sub

    Private Sub btnGetBright2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetBright2.Click
        GetDeviceParam()
        FParam.notifyMode = NOTIFY_BLOCK
        FParam.wmHandle = 0
        FParam.wmMessage = 0
        Text = "����ִ��������߷�������..."
        Parse2(LED_GetBright(FParam))
    End Sub

    Private Sub btnAdjustTime2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdjustTime2.Click
        GetDeviceParam()
        FParam.notifyMode = NOTIFY_BLOCK
        FParam.wmHandle = 0
        FParam.wmMessage = 0
        Text = "����ִ��������߷�������..."
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
        AddText(K, 0, 0, 64, 32, 1, 0, "���", "����", 12, RGB(255, 255, 0), WFS_BOLD, 0, 0, 1, 0, 1, 0, 0, 0, 1000)
        Text = "����ִ��������߷�������..."
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
        AddString(K, 0, 0, 64, 32, 1, 0, "���", 1, RGB(255, 0, 0), 1, 0, 1, 0, 0, 0, 1000)
        Text = "����ִ��������߷�������..."
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
        AddDateTime(K, 0, 0, 64, 32, 1, 0, "����", 12, RGB(0, 255, 0), 0, 0, 0, 0, 0, "#y��#m��#d�� #h:#n:#s ����#w ũ��#c")
        Text = "����ִ��������߷�������..."
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
        Text = "����ִ��������߷�������..."
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
        Text = "����ִ��������߷�������..."
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
        Text = "����ִ��������߷�������..."
        Parse2(LED_SendToScreen(FParam, K))
    End Sub

    Private Sub btnChapter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChapter.Click
        Dim K As Long

        GetDeviceParam()
        FParam.notifyMode = NOTIFY_EVENT
        FParam.wmHandle = Handle
        FParam.wmMessage = WM_LED_NOTIFY

        '��������У�ChapterIndex=0��ֻ���¿��ƿ��ڵ�1����Ŀ
        '���ChapterIndex=1��ֻ���¿��ƿ��ڵ�2����Ŀ
        '�Դ�����
        K = MakeChapter(ROOT_PLAY_CHAPTER, ACTMODE_REPLACE, 0, COLOR_MODE_DOUBLE, 10000, WAIT_CHILD)
        AddRegion(K, 0, 0, 64, 64, 0)
        AddLeaf(K, 10000, WAIT_CHILD)
        AddText(K, 0, 0, 64, 32, 1, 0, "���", "����", 12, RGB(255, 255, 0), WFS_BOLD, 0, 0, 1, 0, 1, 0, 0, 0, 1000)
        Parse(LED_SendToScreen(FParam, K))
    End Sub

    Private Sub btnRegion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegion.Click
        Dim K As Long

        GetDeviceParam()
        FParam.notifyMode = NOTIFY_EVENT
        FParam.wmHandle = Handle
        FParam.wmMessage = WM_LED_NOTIFY

        '��������У�ChapterIndex=0��RegionIndex=0��ֻ���¿��ƿ��ڵ�1����Ŀ�еĵ�1������
        '���ChapterIndex=1��RegionIndex=2��ֻ���¿��ƿ��ڵ�2����Ŀ�еĵ�3������
        '�Դ�����
        K = MakeRegion(ROOT_PLAY_REGION, ACTMODE_REPLACE, 0, 0, COLOR_MODE_DOUBLE, 0, 0, 64, 64, 0)
        AddLeaf(K, 10000, WAIT_CHILD)
        AddText(K, 0, 0, 64, 32, 1, 0, "���", "����", 12, RGB(255, 255, 0), WFS_BOLD, 0, 0, 1, 0, 1, 0, 0, 0, 1000)
        Parse(LED_SendToScreen(FParam, K))
    End Sub

    Private Sub btnLeaf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeaf.Click
        Dim K As Long

        GetDeviceParam()
        FParam.notifyMode = NOTIFY_EVENT
        FParam.wmHandle = Handle
        FParam.wmMessage = WM_LED_NOTIFY

        '��������У�ChapterIndex=0��RegionIndex=0��LeafIndex=0��ֻ���¿��ƿ��ڵ�1����Ŀ�еĵ�1�������еĵ�1��ҳ��
        '���ChapterIndex=1��RegionIndex=2��LeafIndex=1��ֻ���¿��ƿ��ڵ�2����Ŀ�еĵ�3�������еĵ�2��ҳ��
        '�Դ�����
        K = MakeLeaf(ROOT_PLAY_LEAF, ACTMODE_REPLACE, 0, 0, 0, COLOR_MODE_DOUBLE, 5000, WAIT_CHILD)
        AddText(K, 0, 0, 64, 32, 1, 0, "���", "����", 12, RGB(255, 255, 0), WFS_BOLD, 0, 0, 1, 0, 1, 0, 0, 0, 1000)
        Parse(LED_SendToScreen(FParam, K))
    End Sub
End Class
