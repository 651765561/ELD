bat安装方法：
cd /d %~dp0
@echo on
color 2f
mode con: cols=80 lines=25
echo 请按任意键开始安装ELD轮流播放服务...
pause
LoopPlayWindowsService2.0 install
LoopPlayWindowsService2.0 start
pause
