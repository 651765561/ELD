Attribute VB_Name = "WMHandler"
Public Declare Sub SetRect Lib "user32" (ARect As rect, ByVal left As Long, ByVal top As Long, ByVal right As Long, ByVal bottom As Long)
Public Declare Function CallWindowProc Lib "user32" Alias "CallWindowProcA" (ByVal lpPrevWndProc As Long, ByVal hWnd As Long, ByVal Message As Long, ByVal wParam As Long, ByVal lParam As Long) As Long
Public Declare Function SetWindowLong Lib "user32" Alias "SetWindowLongA" (ByVal hWnd As Long, ByVal nIndex As Long, ByVal dwValue As Long) As Long
Public Declare Function PostMessage Lib "user32" Alias "PostMessageA" (ByVal hWnd As Long, ByVal Message As Long, ByVal wParam As Long, ByVal lParam As Long) As Long

Const GWL_WNDPROC = (-4)
Const WM_USER = 1024
Public Const WM_LED_NOTIFY = WM_USER + 1
Global lpPrevWndProc As Long
Global SendStatus As Long

Public Sub Hook(ByVal hWnd As Long)
  lpPrevWndProc = SetWindowLong(hWnd, GWL_WNDPROC, AddressOf WndProc)
End Sub

Public Sub UnHook(ByVal hWnd As Long)
  SetWindowLong hWnd, GWL_WNDPROC, lpPrevWndProc
End Sub


Function WndProc(ByVal hWnd As Long, ByVal Message As Long, ByVal wParam As Long, ByVal lParam As Long) As Long

  Dim notifyparam As TNotifyParam
  
  If Message = WM_LED_NOTIFY Then
    
    LED_GetNotifyParam notifyparam, wParam
    
    If notifyparam.notify = LM_TIMEOUT Then
      Form1.Caption = "发送超时"
      SendStatus = 0
      
    ElseIf notifyparam.notify = LM_TX_COMPLETE Then
      If notifyparam.Result = RESULT_FLASH Then
        Form1.Caption = "数据传送完成，正在写入Flash"
      Else
        Form1.Caption = "数据传送完成"
      End If
      
      SendStatus = 0
      
    ElseIf notifyparam.notify = LM_RESPOND Then
    
      If notifyparam.Command = PKC_GET_POWER Then
        If notifyparam.Status = LED_POWER_ON Then
          Form1.Caption = "读取电源状态完成，当前为电源开启状态"
        Else
          Form1.Caption = "读取电源状态完成，当前为电源关闭状态"
        End If
        
      ElseIf notifyparam.Command = PKC_SET_POWER Then
        If notifyparam.Result = 99 Then
          Form1.Caption = "当前为定时开关屏模式"
        ElseIf notifyparam.Status = LED_POWER_ON Then
          Form1.Caption = "设置电源状态完成，当前为电源开启状态"
        Else
          Form1.Caption = "设置电源状态完成，当前为电源关闭状态"
        End If
      
      ElseIf notifyparam.Command = PKC_GET_SWITCH Then
        Form1.Caption = "读取5V输出状态完成，当前5V输出状态=" & notifyparam.Status
      
      ElseIf notifyparam.Command = PKC_SET_SWITCH Then
        Form1.Caption = "设置5V输出完成，当前5V输出状态=" & notifyparam.Status
        
      ElseIf notifyparam.Command = PKC_GET_BRIGHT Then
        Form1.Caption = "读取亮度完成，当前亮度=" & notifyparam.Status
        
      ElseIf notifyparam.Command = PKC_SET_BRIGHT Then
        If notifyparam.Result = 99 Then
          Form1.Caption = "当前为定时亮度调节模式"
        Else
          Form1.Caption = "设置亮度完成，当前亮度=" & notifyparam.Status
        End If
        
      ElseIf notifyparam.Command = PKC_COM_TRANSFER Then
        Form1.Caption = "串口转发完成"
        
      ElseIf notifyparam.Command = PKC_ADJUST_TIME Then
        Form1.Caption = "校正显示屏时间完成"
        
      End If
    ElseIf notifyparam.notify = LM_NOTIFY Then
    End If
  Else
    WndProc = CallWindowProc(lpPrevWndProc, hWnd, Message, wParam, lParam)
  End If
  
End Function

