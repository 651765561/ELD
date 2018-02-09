bat安装方法：
cd /d %~dp0
@echo on
color 2f
mode con: cols=80 lines=25
echo 请按任意键开始安装ELD扫描系统服务...
pause
ServiceSendJingTaiMessage install
ServiceSendJingTaiMessage start
pause
