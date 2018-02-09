java_protocol_demo
---------------------------------------

    此例程是非调用dll方式的java例子程序，为纯java源码的例程。

    仅支持字库方式的文字、日期时间显示，和一些控制命令（开关屏、亮度、校时）。

    代码中，通讯方式采用的是udp通讯，在windowsXP/MyEclipse8.x下编译运行通过，连接显示屏测试成功。

    对于android等非windows开发环境，请重新自行编写UDP通讯部分的代码。
      

    ProtocolDemo.java ----- 调用主例程。
    LEDSender2010.java ---- 控制卡通讯协议相关代码。
    MyUdpSocket.java ------ UDP通讯相关代码。
