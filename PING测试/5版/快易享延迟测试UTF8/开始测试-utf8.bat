@echo off
title 快易享服务器Ping测试,谢谢您的贡献!!!
color 02
Echo 请求管理员权限
PUSHD %~DP0 & cd /d "%~dp0"
%1 %2
mshta vbscript:createobject("shell.application").shellexecute("%~s0","goto :runas","","runas",1)(window.close)&goto :eof
:runas
netsh advfirewall firewall add rule name="ftp" dir=in action=allow program="%SystemRoot%\System32\ftp.exe" enable=yes
netsh advfirewall firewall add rule name="ftp" dir=out action=allow program="%SystemRoot%\System32\ftp.exe" enable=yes
set name=hostname
%name%
set datevar=%date:~0,4%年%date:~5,2%月%date:~8,2%日
set timevar=%time:~0,2%
if /i %timevar% LSS 10 (
set timevar=0%time:~1,1%
)
set timevar=%timevar%时%time:~3,2%分%time:~6,2%秒
echo 当前时间：%datevar%%timevar%
echo 判断主程序是否存在
set exe=%~dp0\tcping.exe
if not exist %exe% (
                                call DW-EXE-FTP.bat
		echo %exe% 文件不存在，已下载该文件！
    ) else (
        echo %exe% 文件已存在，无需下载！
    )
echo 下载配置文件
cd %~dp0
call DW-FTP-utf8.bat
echo 运行配置文件
choice /t 1 /d y /n >nul
cd %~dp0
call conf-utf8.bat
cd %~dp0
call statistics.bat
netsh advfirewall firewall delete rule name= ftp program="%SystemRoot%\System32\ftp.exe"

