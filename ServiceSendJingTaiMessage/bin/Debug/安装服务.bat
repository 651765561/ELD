bat��װ������
cd /d %~dp0
@echo on
color 2f
mode con: cols=80 lines=25
echo �밴�������ʼ��װELD�豸��̬��Ϣ���·���...
pause
ServiceSendJingTaiMessage install
ServiceSendJingTaiMessage start
pause
