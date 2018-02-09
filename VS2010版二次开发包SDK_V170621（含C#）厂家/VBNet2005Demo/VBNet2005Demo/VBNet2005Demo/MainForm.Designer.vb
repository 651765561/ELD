<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.groupBox5 = New System.Windows.Forms.GroupBox
        Me.btnRegion = New System.Windows.Forms.Button
        Me.btnObject = New System.Windows.Forms.Button
        Me.btnLeaf = New System.Windows.Forms.Button
        Me.btnChapter = New System.Windows.Forms.Button
        Me.pictureBox = New System.Windows.Forms.PictureBox
        Me.groupBox4 = New System.Windows.Forms.GroupBox
        Me.btnClock2 = New System.Windows.Forms.Button
        Me.btnPicFile2 = New System.Windows.Forms.Button
        Me.btnDateTime2 = New System.Windows.Forms.Button
        Me.btnString2 = New System.Windows.Forms.Button
        Me.btnDib2 = New System.Windows.Forms.Button
        Me.btnText2 = New System.Windows.Forms.Button
        Me.btnAdjustTime2 = New System.Windows.Forms.Button
        Me.btnGetBright2 = New System.Windows.Forms.Button
        Me.btnSetBright2 = New System.Windows.Forms.Button
        Me.btnGetPower2 = New System.Windows.Forms.Button
        Me.btnPowerOff2 = New System.Windows.Forms.Button
        Me.btnPowerOn2 = New System.Windows.Forms.Button
        Me.groupBox3 = New System.Windows.Forms.GroupBox
        Me.btnClock = New System.Windows.Forms.Button
        Me.btnPicFile = New System.Windows.Forms.Button
        Me.btnDateTime = New System.Windows.Forms.Button
        Me.btnString = New System.Windows.Forms.Button
        Me.btnDib = New System.Windows.Forms.Button
        Me.btnText = New System.Windows.Forms.Button
        Me.btnAdjustTime = New System.Windows.Forms.Button
        Me.btnGetBright = New System.Windows.Forms.Button
        Me.btnSetBright = New System.Windows.Forms.Button
        Me.btnGetPower = New System.Windows.Forms.Button
        Me.btnPowerOff = New System.Windows.Forms.Button
        Me.btnPowerOn = New System.Windows.Forms.Button
        Me.groupBox2 = New System.Windows.Forms.GroupBox
        Me.eLocalPort = New System.Windows.Forms.TextBox
        Me.label3 = New System.Windows.Forms.Label
        Me.eRemoteHost = New System.Windows.Forms.TextBox
        Me.label4 = New System.Windows.Forms.Label
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.cmbBaudRate = New System.Windows.Forms.ComboBox
        Me.label2 = New System.Windows.Forms.Label
        Me.eCommPort = New System.Windows.Forms.TextBox
        Me.label1 = New System.Windows.Forms.Label
        Me.cmbDevType = New System.Windows.Forms.ComboBox
        Me.eAddress = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.groupBox5.SuspendLayout()
        CType(Me.pictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox4.SuspendLayout()
        Me.groupBox3.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'groupBox5
        '
        Me.groupBox5.Controls.Add(Me.btnRegion)
        Me.groupBox5.Controls.Add(Me.btnObject)
        Me.groupBox5.Controls.Add(Me.btnLeaf)
        Me.groupBox5.Controls.Add(Me.btnChapter)
        Me.groupBox5.Location = New System.Drawing.Point(483, 138)
        Me.groupBox5.Name = "groupBox5"
        Me.groupBox5.Size = New System.Drawing.Size(125, 159)
        Me.groupBox5.TabIndex = 15
        Me.groupBox5.TabStop = False
        Me.groupBox5.Text = "局部更新例程"
        '
        'btnRegion
        '
        Me.btnRegion.Location = New System.Drawing.Point(7, 49)
        Me.btnRegion.Name = "btnRegion"
        Me.btnRegion.Size = New System.Drawing.Size(110, 24)
        Me.btnRegion.TabIndex = 9
        Me.btnRegion.Text = "只更新1个分区"
        Me.btnRegion.UseVisualStyleBackColor = True
        '
        'btnObject
        '
        Me.btnObject.Location = New System.Drawing.Point(7, 108)
        Me.btnObject.Name = "btnObject"
        Me.btnObject.Size = New System.Drawing.Size(110, 23)
        Me.btnObject.TabIndex = 7
        Me.btnObject.Text = "只更新1个对象"
        Me.btnObject.UseVisualStyleBackColor = True
        '
        'btnLeaf
        '
        Me.btnLeaf.Location = New System.Drawing.Point(7, 79)
        Me.btnLeaf.Name = "btnLeaf"
        Me.btnLeaf.Size = New System.Drawing.Size(110, 23)
        Me.btnLeaf.TabIndex = 7
        Me.btnLeaf.Text = "只更新1个页面"
        Me.btnLeaf.UseVisualStyleBackColor = True
        '
        'btnChapter
        '
        Me.btnChapter.Location = New System.Drawing.Point(7, 20)
        Me.btnChapter.Name = "btnChapter"
        Me.btnChapter.Size = New System.Drawing.Size(110, 23)
        Me.btnChapter.TabIndex = 6
        Me.btnChapter.Text = "只更新1个节目"
        Me.btnChapter.UseVisualStyleBackColor = True
        '
        'pictureBox
        '
        Me.pictureBox.Image = CType(resources.GetObject("pictureBox.Image"), System.Drawing.Image)
        Me.pictureBox.Location = New System.Drawing.Point(410, 9)
        Me.pictureBox.Name = "pictureBox"
        Me.pictureBox.Size = New System.Drawing.Size(67, 34)
        Me.pictureBox.TabIndex = 14
        Me.pictureBox.TabStop = False
        '
        'groupBox4
        '
        Me.groupBox4.Controls.Add(Me.btnClock2)
        Me.groupBox4.Controls.Add(Me.btnPicFile2)
        Me.groupBox4.Controls.Add(Me.btnDateTime2)
        Me.groupBox4.Controls.Add(Me.btnString2)
        Me.groupBox4.Controls.Add(Me.btnDib2)
        Me.groupBox4.Controls.Add(Me.btnText2)
        Me.groupBox4.Controls.Add(Me.btnAdjustTime2)
        Me.groupBox4.Controls.Add(Me.btnGetBright2)
        Me.groupBox4.Controls.Add(Me.btnSetBright2)
        Me.groupBox4.Controls.Add(Me.btnGetPower2)
        Me.groupBox4.Controls.Add(Me.btnPowerOff2)
        Me.groupBox4.Controls.Add(Me.btnPowerOn2)
        Me.groupBox4.Location = New System.Drawing.Point(12, 258)
        Me.groupBox4.Name = "groupBox4"
        Me.groupBox4.Size = New System.Drawing.Size(466, 142)
        Me.groupBox4.TabIndex = 13
        Me.groupBox4.TabStop = False
        Me.groupBox4.Text = "阻塞方式，执行命令函数时，进程阻塞，直到获得应答结果时函数返回"
        '
        'btnClock2
        '
        Me.btnClock2.Location = New System.Drawing.Point(123, 78)
        Me.btnClock2.Name = "btnClock2"
        Me.btnClock2.Size = New System.Drawing.Size(110, 23)
        Me.btnClock2.TabIndex = 11
        Me.btnClock2.Text = "发送模拟时钟"
        Me.btnClock2.UseVisualStyleBackColor = True
        '
        'btnPicFile2
        '
        Me.btnPicFile2.Location = New System.Drawing.Point(239, 49)
        Me.btnPicFile2.Name = "btnPicFile2"
        Me.btnPicFile2.Size = New System.Drawing.Size(108, 23)
        Me.btnPicFile2.TabIndex = 10
        Me.btnPicFile2.Text = "发送图片文件"
        Me.btnPicFile2.UseVisualStyleBackColor = True
        '
        'btnDateTime2
        '
        Me.btnDateTime2.Location = New System.Drawing.Point(7, 78)
        Me.btnDateTime2.Name = "btnDateTime2"
        Me.btnDateTime2.Size = New System.Drawing.Size(110, 23)
        Me.btnDateTime2.TabIndex = 9
        Me.btnDateTime2.Text = "发送日期时间"
        Me.btnDateTime2.UseVisualStyleBackColor = True
        '
        'btnString2
        '
        Me.btnString2.Location = New System.Drawing.Point(353, 49)
        Me.btnString2.Name = "btnString2"
        Me.btnString2.Size = New System.Drawing.Size(107, 23)
        Me.btnString2.TabIndex = 8
        Me.btnString2.Text = "发送内码文字"
        Me.btnString2.UseVisualStyleBackColor = True
        '
        'btnDib2
        '
        Me.btnDib2.Location = New System.Drawing.Point(123, 49)
        Me.btnDib2.Name = "btnDib2"
        Me.btnDib2.Size = New System.Drawing.Size(110, 23)
        Me.btnDib2.TabIndex = 7
        Me.btnDib2.Text = "发送点阵图像"
        Me.btnDib2.UseVisualStyleBackColor = True
        '
        'btnText2
        '
        Me.btnText2.Location = New System.Drawing.Point(7, 49)
        Me.btnText2.Name = "btnText2"
        Me.btnText2.Size = New System.Drawing.Size(110, 23)
        Me.btnText2.TabIndex = 6
        Me.btnText2.Text = "发送点阵文字"
        Me.btnText2.UseVisualStyleBackColor = True
        '
        'btnAdjustTime2
        '
        Me.btnAdjustTime2.Location = New System.Drawing.Point(393, 20)
        Me.btnAdjustTime2.Name = "btnAdjustTime2"
        Me.btnAdjustTime2.Size = New System.Drawing.Size(66, 23)
        Me.btnAdjustTime2.TabIndex = 5
        Me.btnAdjustTime2.Text = "校正时间"
        Me.btnAdjustTime2.UseVisualStyleBackColor = True
        '
        'btnGetBright2
        '
        Me.btnGetBright2.Location = New System.Drawing.Point(321, 20)
        Me.btnGetBright2.Name = "btnGetBright2"
        Me.btnGetBright2.Size = New System.Drawing.Size(66, 23)
        Me.btnGetBright2.TabIndex = 4
        Me.btnGetBright2.Text = "读取亮度"
        Me.btnGetBright2.UseVisualStyleBackColor = True
        '
        'btnSetBright2
        '
        Me.btnSetBright2.Location = New System.Drawing.Point(249, 20)
        Me.btnSetBright2.Name = "btnSetBright2"
        Me.btnSetBright2.Size = New System.Drawing.Size(66, 23)
        Me.btnSetBright2.TabIndex = 3
        Me.btnSetBright2.Text = "设置亮度"
        Me.btnSetBright2.UseVisualStyleBackColor = True
        '
        'btnGetPower2
        '
        Me.btnGetPower2.Location = New System.Drawing.Point(150, 20)
        Me.btnGetPower2.Name = "btnGetPower2"
        Me.btnGetPower2.Size = New System.Drawing.Size(93, 23)
        Me.btnGetPower2.TabIndex = 2
        Me.btnGetPower2.Text = "读取电源状态"
        Me.btnGetPower2.UseVisualStyleBackColor = True
        '
        'btnPowerOff2
        '
        Me.btnPowerOff2.Location = New System.Drawing.Point(78, 20)
        Me.btnPowerOff2.Name = "btnPowerOff2"
        Me.btnPowerOff2.Size = New System.Drawing.Size(66, 23)
        Me.btnPowerOff2.TabIndex = 1
        Me.btnPowerOff2.Text = "关闭电源"
        Me.btnPowerOff2.UseVisualStyleBackColor = True
        '
        'btnPowerOn2
        '
        Me.btnPowerOn2.Location = New System.Drawing.Point(6, 20)
        Me.btnPowerOn2.Name = "btnPowerOn2"
        Me.btnPowerOn2.Size = New System.Drawing.Size(66, 23)
        Me.btnPowerOn2.TabIndex = 0
        Me.btnPowerOn2.Text = "打开电源"
        Me.btnPowerOn2.UseVisualStyleBackColor = True
        '
        'groupBox3
        '
        Me.groupBox3.Controls.Add(Me.btnClock)
        Me.groupBox3.Controls.Add(Me.btnPicFile)
        Me.groupBox3.Controls.Add(Me.btnDateTime)
        Me.groupBox3.Controls.Add(Me.btnString)
        Me.groupBox3.Controls.Add(Me.btnDib)
        Me.groupBox3.Controls.Add(Me.btnText)
        Me.groupBox3.Controls.Add(Me.btnAdjustTime)
        Me.groupBox3.Controls.Add(Me.btnGetBright)
        Me.groupBox3.Controls.Add(Me.btnSetBright)
        Me.groupBox3.Controls.Add(Me.btnGetPower)
        Me.groupBox3.Controls.Add(Me.btnPowerOff)
        Me.groupBox3.Controls.Add(Me.btnPowerOn)
        Me.groupBox3.Location = New System.Drawing.Point(11, 138)
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.Size = New System.Drawing.Size(466, 114)
        Me.groupBox3.TabIndex = 12
        Me.groupBox3.TabStop = False
        Me.groupBox3.Text = "异步方式，使用窗体消息方式获得命令执行结果"
        '
        'btnClock
        '
        Me.btnClock.Location = New System.Drawing.Point(123, 78)
        Me.btnClock.Name = "btnClock"
        Me.btnClock.Size = New System.Drawing.Size(110, 23)
        Me.btnClock.TabIndex = 11
        Me.btnClock.Text = "发送模拟时钟"
        Me.btnClock.UseVisualStyleBackColor = True
        '
        'btnPicFile
        '
        Me.btnPicFile.Location = New System.Drawing.Point(237, 49)
        Me.btnPicFile.Name = "btnPicFile"
        Me.btnPicFile.Size = New System.Drawing.Size(110, 23)
        Me.btnPicFile.TabIndex = 10
        Me.btnPicFile.Text = "发送图片文件"
        Me.btnPicFile.UseVisualStyleBackColor = True
        '
        'btnDateTime
        '
        Me.btnDateTime.Location = New System.Drawing.Point(7, 78)
        Me.btnDateTime.Name = "btnDateTime"
        Me.btnDateTime.Size = New System.Drawing.Size(110, 23)
        Me.btnDateTime.TabIndex = 9
        Me.btnDateTime.Text = "发送日期时间"
        Me.btnDateTime.UseVisualStyleBackColor = True
        '
        'btnString
        '
        Me.btnString.Location = New System.Drawing.Point(353, 49)
        Me.btnString.Name = "btnString"
        Me.btnString.Size = New System.Drawing.Size(107, 23)
        Me.btnString.TabIndex = 8
        Me.btnString.Text = "发送内码文字"
        Me.btnString.UseVisualStyleBackColor = True
        '
        'btnDib
        '
        Me.btnDib.Location = New System.Drawing.Point(123, 49)
        Me.btnDib.Name = "btnDib"
        Me.btnDib.Size = New System.Drawing.Size(110, 23)
        Me.btnDib.TabIndex = 7
        Me.btnDib.Text = "发送点阵图像"
        Me.btnDib.UseVisualStyleBackColor = True
        '
        'btnText
        '
        Me.btnText.Location = New System.Drawing.Point(7, 49)
        Me.btnText.Name = "btnText"
        Me.btnText.Size = New System.Drawing.Size(110, 23)
        Me.btnText.TabIndex = 6
        Me.btnText.Text = "发送点阵文字"
        Me.btnText.UseVisualStyleBackColor = True
        '
        'btnAdjustTime
        '
        Me.btnAdjustTime.Location = New System.Drawing.Point(393, 20)
        Me.btnAdjustTime.Name = "btnAdjustTime"
        Me.btnAdjustTime.Size = New System.Drawing.Size(66, 23)
        Me.btnAdjustTime.TabIndex = 5
        Me.btnAdjustTime.Text = "校正时间"
        Me.btnAdjustTime.UseVisualStyleBackColor = True
        '
        'btnGetBright
        '
        Me.btnGetBright.Location = New System.Drawing.Point(321, 20)
        Me.btnGetBright.Name = "btnGetBright"
        Me.btnGetBright.Size = New System.Drawing.Size(66, 23)
        Me.btnGetBright.TabIndex = 4
        Me.btnGetBright.Text = "读取亮度"
        Me.btnGetBright.UseVisualStyleBackColor = True
        '
        'btnSetBright
        '
        Me.btnSetBright.Location = New System.Drawing.Point(249, 20)
        Me.btnSetBright.Name = "btnSetBright"
        Me.btnSetBright.Size = New System.Drawing.Size(66, 23)
        Me.btnSetBright.TabIndex = 3
        Me.btnSetBright.Text = "设置亮度"
        Me.btnSetBright.UseVisualStyleBackColor = True
        '
        'btnGetPower
        '
        Me.btnGetPower.Location = New System.Drawing.Point(150, 20)
        Me.btnGetPower.Name = "btnGetPower"
        Me.btnGetPower.Size = New System.Drawing.Size(93, 23)
        Me.btnGetPower.TabIndex = 2
        Me.btnGetPower.Text = "读取电源状态"
        Me.btnGetPower.UseVisualStyleBackColor = True
        '
        'btnPowerOff
        '
        Me.btnPowerOff.Location = New System.Drawing.Point(78, 20)
        Me.btnPowerOff.Name = "btnPowerOff"
        Me.btnPowerOff.Size = New System.Drawing.Size(66, 23)
        Me.btnPowerOff.TabIndex = 1
        Me.btnPowerOff.Text = "关闭电源"
        Me.btnPowerOff.UseVisualStyleBackColor = True
        '
        'btnPowerOn
        '
        Me.btnPowerOn.Location = New System.Drawing.Point(6, 20)
        Me.btnPowerOn.Name = "btnPowerOn"
        Me.btnPowerOn.Size = New System.Drawing.Size(66, 23)
        Me.btnPowerOn.TabIndex = 0
        Me.btnPowerOn.Text = "打开电源"
        Me.btnPowerOn.UseVisualStyleBackColor = True
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.eLocalPort)
        Me.groupBox2.Controls.Add(Me.label3)
        Me.groupBox2.Controls.Add(Me.eRemoteHost)
        Me.groupBox2.Controls.Add(Me.label4)
        Me.groupBox2.Location = New System.Drawing.Point(248, 49)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(229, 83)
        Me.groupBox2.TabIndex = 11
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "网络通讯参数"
        '
        'eLocalPort
        '
        Me.eLocalPort.Location = New System.Drawing.Point(76, 51)
        Me.eLocalPort.Name = "eLocalPort"
        Me.eLocalPort.Size = New System.Drawing.Size(132, 21)
        Me.eLocalPort.TabIndex = 4
        Me.eLocalPort.Text = "8881"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(17, 57)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(53, 12)
        Me.label3.TabIndex = 3
        Me.label3.Text = "本地端口"
        '
        'eRemoteHost
        '
        Me.eRemoteHost.Location = New System.Drawing.Point(76, 20)
        Me.eRemoteHost.Name = "eRemoteHost"
        Me.eRemoteHost.Size = New System.Drawing.Size(132, 21)
        Me.eRemoteHost.TabIndex = 2
        Me.eRemoteHost.Text = "192.168.1.99"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(17, 27)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(53, 12)
        Me.label4.TabIndex = 1
        Me.label4.Text = "控制卡IP"
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.cmbBaudRate)
        Me.groupBox1.Controls.Add(Me.label2)
        Me.groupBox1.Controls.Add(Me.eCommPort)
        Me.groupBox1.Controls.Add(Me.label1)
        Me.groupBox1.Location = New System.Drawing.Point(11, 49)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(229, 83)
        Me.groupBox1.TabIndex = 10
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "串口通讯参数"
        '
        'cmbBaudRate
        '
        Me.cmbBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBaudRate.FormattingEnabled = True
        Me.cmbBaudRate.Items.AddRange(New Object() {"57600", "38400", "19200", "9600"})
        Me.cmbBaudRate.Location = New System.Drawing.Point(65, 52)
        Me.cmbBaudRate.Name = "cmbBaudRate"
        Me.cmbBaudRate.Size = New System.Drawing.Size(144, 20)
        Me.cmbBaudRate.TabIndex = 4
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(17, 57)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(41, 12)
        Me.label2.TabIndex = 3
        Me.label2.Text = "波特率"
        '
        'eCommPort
        '
        Me.eCommPort.Location = New System.Drawing.Point(64, 20)
        Me.eCommPort.Name = "eCommPort"
        Me.eCommPort.Size = New System.Drawing.Size(145, 21)
        Me.eCommPort.TabIndex = 2
        Me.eCommPort.Text = "1"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(17, 27)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(41, 12)
        Me.label1.TabIndex = 1
        Me.label1.Text = "串口号"
        '
        'cmbDevType
        '
        Me.cmbDevType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDevType.FormattingEnabled = True
        Me.cmbDevType.Items.AddRange(New Object() {"串口通讯", "网络通讯"})
        Me.cmbDevType.Location = New System.Drawing.Point(11, 23)
        Me.cmbDevType.Name = "cmbDevType"
        Me.cmbDevType.Size = New System.Drawing.Size(118, 20)
        Me.cmbDevType.TabIndex = 9
        '
        'eAddress
        '
        Me.eAddress.Location = New System.Drawing.Point(174, 23)
        Me.eAddress.Name = "eAddress"
        Me.eAddress.Size = New System.Drawing.Size(46, 21)
        Me.eAddress.TabIndex = 17
        Me.eAddress.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(139, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 12)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "地址"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(622, 417)
        Me.Controls.Add(Me.eAddress)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.groupBox5)
        Me.Controls.Add(Me.pictureBox)
        Me.Controls.Add(Me.groupBox4)
        Me.Controls.Add(Me.groupBox3)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.cmbDevType)
        Me.Name = "MainForm"
        Me.Text = "VB.Net2005例程"
        Me.groupBox5.ResumeLayout(False)
        CType(Me.pictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupBox4.ResumeLayout(False)
        Me.groupBox3.ResumeLayout(False)
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents groupBox5 As System.Windows.Forms.GroupBox
    Private WithEvents btnRegion As System.Windows.Forms.Button
    Private WithEvents btnObject As System.Windows.Forms.Button
    Private WithEvents btnLeaf As System.Windows.Forms.Button
    Private WithEvents btnChapter As System.Windows.Forms.Button
    Private WithEvents pictureBox As System.Windows.Forms.PictureBox
    Private WithEvents groupBox4 As System.Windows.Forms.GroupBox
    Private WithEvents btnClock2 As System.Windows.Forms.Button
    Private WithEvents btnPicFile2 As System.Windows.Forms.Button
    Private WithEvents btnDateTime2 As System.Windows.Forms.Button
    Private WithEvents btnString2 As System.Windows.Forms.Button
    Private WithEvents btnDib2 As System.Windows.Forms.Button
    Private WithEvents btnText2 As System.Windows.Forms.Button
    Private WithEvents btnAdjustTime2 As System.Windows.Forms.Button
    Private WithEvents btnGetBright2 As System.Windows.Forms.Button
    Private WithEvents btnSetBright2 As System.Windows.Forms.Button
    Private WithEvents btnGetPower2 As System.Windows.Forms.Button
    Private WithEvents btnPowerOff2 As System.Windows.Forms.Button
    Private WithEvents btnPowerOn2 As System.Windows.Forms.Button
    Private WithEvents groupBox3 As System.Windows.Forms.GroupBox
    Private WithEvents btnClock As System.Windows.Forms.Button
    Private WithEvents btnPicFile As System.Windows.Forms.Button
    Private WithEvents btnDateTime As System.Windows.Forms.Button
    Private WithEvents btnString As System.Windows.Forms.Button
    Private WithEvents btnDib As System.Windows.Forms.Button
    Private WithEvents btnText As System.Windows.Forms.Button
    Private WithEvents btnAdjustTime As System.Windows.Forms.Button
    Private WithEvents btnGetBright As System.Windows.Forms.Button
    Private WithEvents btnSetBright As System.Windows.Forms.Button
    Private WithEvents btnGetPower As System.Windows.Forms.Button
    Private WithEvents btnPowerOff As System.Windows.Forms.Button
    Private WithEvents btnPowerOn As System.Windows.Forms.Button
    Private WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents eLocalPort As System.Windows.Forms.TextBox
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents eRemoteHost As System.Windows.Forms.TextBox
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents cmbBaudRate As System.Windows.Forms.ComboBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents eCommPort As System.Windows.Forms.TextBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents cmbDevType As System.Windows.Forms.ComboBox
    Private WithEvents eAddress As System.Windows.Forms.TextBox
    Private WithEvents Label5 As System.Windows.Forms.Label

End Class
