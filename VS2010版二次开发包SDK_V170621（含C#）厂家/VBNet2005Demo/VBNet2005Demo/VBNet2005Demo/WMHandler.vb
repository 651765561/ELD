Option Explicit On

Module WMHandler

    Public Delegate Function DelegateWndProc(ByVal hWnd As Integer, ByVal Message As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer

    Public Declare Function CallWindowProc Lib "user32" Alias "CallWindowProcA" (ByVal lpPrevWndProc As Integer, ByVal hWnd As Integer, ByVal Message As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    Public Declare Function SetWindowLongProc Lib "user32" Alias "SetWindowLongA" (ByVal hWnd As Integer, ByVal nIndex As Integer, ByVal dwValue As DelegateWndProc) As Integer
    Public Declare Function SetWindowLong Lib "user32" Alias "SetWindowLongA" (ByVal hWnd As Integer, ByVal nIndex As Integer, ByVal dwValue As Integer) As Integer
    Public Declare Function PostMessage Lib "user32" Alias "PostMessageA" (ByVal hWnd As Integer, ByVal Message As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer

    Const GWL_WNDPROC = (-4)
    Const WM_USER = 1024
    Public Const WM_LED_NOTIFY = WM_USER + 1
    Public lpPrevWndProc As Integer
    Public SendStatus As Integer
    Private mywinproc As DelegateWndProc

    Public Sub Hook(ByVal hWnd As Integer)
        mywinproc = New DelegateWndProc(AddressOf WndProc)
        GC.Collect()
        GC.WaitForPendingFinalizers()
        lpPrevWndProc = SetWindowLongProc(hWnd, GWL_WNDPROC, mywinproc)
    End Sub

    Public Sub UnHook(ByVal hWnd As Integer)
        SetWindowLong(hWnd, GWL_WNDPROC, lpPrevWndProc)
    End Sub

    Function WndProc(ByVal hWnd As Integer, ByVal Message As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
        Dim notifyparam As TNotifyParam = New TNotifyParam
        If Message = WM_LED_NOTIFY Then
            LED_GetNotifyParam(notifyparam, wParam)
            If notifyparam.notify = LM_TIMEOUT Then
                MainForm.Text = "发送超时"
                SendStatus = 0
            ElseIf notifyparam.notify = LM_TX_COMPLETE Then
                If notifyparam.Result = RESULT_FLASH Then
                    MainForm.Text = "数据传送完成，正在写入Flash"
                Else
                    MainForm.Text = "数据传送完成"
                End If
                SendStatus = 0
            ElseIf notifyparam.notify = LM_RESPOND Then
                If notifyparam.Command = PKC_GET_POWER Then
                    If notifyparam.Status = LED_POWER_ON Then
                        MainForm.Text = "读取电源状态完成，当前为电源开启状态"
                    Else
                        MainForm.Text = "读取电源状态完成，当前为电源关闭状态"
                    End If
                ElseIf notifyparam.Command = PKC_SET_POWER Then

                    If notifyparam.Result = 99 Then
                        MainForm.Text = "当前为定时开关屏模式"
                    ElseIf notifyparam.Status = LED_POWER_ON Then
                        MainForm.Text = "设置电源状态完成，当前为电源开启状态"
                    Else
                        MainForm.Text = "设置电源状态完成，当前为电源关闭状态"
                    End If
                ElseIf notifyparam.Command = PKC_GET_BRIGHT Then
                    MainForm.Text = "读取亮度完成，当前亮度=" & notifyparam.Status
                ElseIf notifyparam.Command = PKC_SET_BRIGHT Then
                    If notifyparam.Result = 99 Then
                        MainForm.Text = "当前为定时亮度调节模式"
                    Else
                        MainForm.Text = "设置亮度完成，当前亮度=" & notifyparam.Status
                    End If
                ElseIf notifyparam.Command = PKC_COM_TRANSFER Then
                    MainForm.Text = "串口转发完成"
                ElseIf notifyparam.Command = PKC_ADJUST_TIME Then
                    MainForm.Text = "校正显示屏时间完成"
                End If
            ElseIf notifyparam.notify = LM_NOTIFY Then
            End If
        Else
            WndProc = CallWindowProc(lpPrevWndProc, hWnd, Message, wParam, lParam)
        End If
    End Function

End Module




