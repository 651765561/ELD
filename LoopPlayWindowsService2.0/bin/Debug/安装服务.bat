bat��װ������
cd /d %~dp0
@echo on
color 2f
mode con: cols=80 lines=25
echo �밴�������ʼ��װELD�������ŷ���...
pause
LoopPlayWindowsService2.0 install
LoopPlayWindowsService2.0 start
pause
