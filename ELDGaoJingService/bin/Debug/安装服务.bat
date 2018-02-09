bat安装方法：
cd /d %~dp0
@echo on
color 2f
mode con: cols=80 lines=25
echo 请按任意键开始安装告警播放服务...
pause
ELDGaoJingService install
ELDGaoJingService start
pause
