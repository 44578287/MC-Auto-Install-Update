@echo off
title �����������Ping����,лл���Ĺ���!!!
color 02
Echo �������ԱȨ��
PUSHD %~DP0 & cd /d "%~dp0"
%1 %2
mshta vbscript:createobject("shell.application").shellexecute("%~s0","goto :runas","","runas",1)(window.close)&goto :eof
:runas
netsh advfirewall firewall add rule name="ftp" dir=in action=allow program="%SystemRoot%\System32\ftp.exe" enable=yes
netsh advfirewall firewall add rule name="ftp" dir=out action=allow program="%SystemRoot%\System32\ftp.exe" enable=yes
set name=hostname
%name%
set datevar=%date:~0,4%��%date:~5,2%��%date:~8,2%��
set timevar=%time:~0,2%
if /i %timevar% LSS 10 (
set timevar=0%time:~1,1%
)
set timevar=%timevar%ʱ%time:~3,2%��%time:~6,2%��
echo ��ǰʱ�䣺%datevar%%timevar%
echo �ж��������Ƿ����
set exe=%~dp0\tcping.exe
if not exist %exe% (
                                call DW-EXE-FTP.bat
		echo %exe% �ļ������ڣ������ظ��ļ���
    ) else (
        echo %exe% �ļ��Ѵ��ڣ��������أ�
    )
echo ���������ļ�
cd %~dp0
call DW-FTP.bat
echo ���������ļ�
choice /t 1 /d y /n >nul
cd %~dp0
call conf.bat
netsh advfirewall firewall delete rule name= ftp program="%SystemRoot%\System32\ftp.exe"

