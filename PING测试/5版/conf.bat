@echo off
set name=hostname
%name%
set datevar=%date:~0,4%��%date:~5,2%��%date:~8,2%��
set timevar=%time:~0,2%
if /i %timevar% LSS 10 (
set timevar=0%time:~1,1%
)
set timevar=%timevar%ʱ%time:~3,2%��%time:~6,2%��
echo ��ǰʱ�䣺%datevar%%timevar%
echo ��ʼ����
echo �ƶ���Ŀ��Ŀ¼
cd %~dp0
echo ����data���ϼ�
md %~dp0\data
echo ���data���ϼ�
del %~dp0\data\"*.txt"
ipconfig /all> %~dp0\data\������Ϣ.txt
echo ��ʼ���� 445720.xyz
tcping 445720.xyz > %~dp0\data\(1)445720.xyz.txt
echo ��ʼ���� 44578287.xyz
tcping 44578287.xyz > %~dp0\data\(2)44578287.xyz.txt
echo ��ʼ���� home.44578287.xyz
tcping home.44578287.xyz > %~dp0\data\(3)home.44578287.xyz.txt
echo ��ʼ���� 42.193.111.84
tcping 42.193.111.84 > %~dp0\data\(8)42.193.111.84.txt
echo ��ʼ���� 42.193.111.84 7000
tcping 42.193.111.84 7000 > %~dp0\data\(7)7000.txt
echo ��ʼ���� 42.193.111.84 14457
tcping 42.193.111.84 14457 > %~dp0\data\(6)14457.txt
echo ��ʼ���� mc.445720.xyz 25565
tcping mc.445720.xyz 25565 > %~dp0\data\(5)mc.445720.xyz.25565.txt
echo ��ʼ���� mc.445720.xyz
tcping mc.445720.xyz > %~dp0\data\(4)mc.445720.xyz.txt
cd %~dp0\data
echo ����data
type *.txt>res
rename res data.txt
echo ���data�ļ���
md %~dp0\%computername%
echo ���data
copy data.txt %~dp0\%computername%\Ping-data-%computername%-%datevar%%timevar%.txt
cd %~dp0
call statistics.bat
type %~dp0\%computername%\Ping-ͳ��-%computername%-%datevar%%timevar%.txt
echo �ϴ���־�ļ�
cd %~dp0
call UP-FTP.bat
echo ���ͳ��
type %~dp0\%computername%\Ping-ͳ��-%computername%-%datevar%%timevar%.txt
echo ��������˳�,лл�������,��Щ���϶�������˵�ǳ���Ҫ!!!
echo ��������վhttps://445720.xyz
echo ��������@ckС������д,��ӭ����ʹ��
pause