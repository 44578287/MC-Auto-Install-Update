@echo off
title "快易享MC 自动安装&更新"
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

echo 检测aria2.exe
set exe=%~dp0\tool\aria2.exe
if not exist %exe% (
		md tool
                                powershell -Command Invoke-WebRequest https://link.jscdn.cn/sharepoint/aHR0cHM6Ly9nOTk2NDk1Ny1teS5zaGFyZXBvaW50LmNvbS86dTovZy9wZXJzb25hbC9nOTk2NDk1N19nOTk2NDk1N19vbm1pY3Jvc29mdF9jb20vRVVxamE2S2NpU2RCdEE0bVA1SHdrTVlCa3BfT1B5cWdRb1dSUGd3SXQ5dGtDQT9lPU5rS1lZSQ.exe -OutFile tool\aria2.exe
		echo %exe% 文件不存在，已下载该文件！
    ) else (
        echo %exe% 文件已存在，无需下载！
    )

echo 检测WinRAR.exe
set exe=%~dp0\tool\WinRAR.exe
if not exist %exe% (
		md tool
                                powershell -Command Invoke-WebRequest https://link.jscdn.cn/sharepoint/aHR0cHM6Ly9nOTk2NDk1Ny1teS5zaGFyZXBvaW50LmNvbS86dTovZy9wZXJzb25hbC9nOTk2NDk1N19nOTk2NDk1N19vbm1pY3Jvc29mdF9jb20vRVIzQUd6bThhVWxGb0Q3aVV5SFRSQ2dCOHpwZjZqUktzVmQwS1dCNjVoUl9WZz9lPWU5bEpjUA.exe -OutFile tool\WinRAR.exe
		echo %exe% 文件不存在，已下载该文件！
    ) else (
        echo %exe% 文件已存在，无需下载！
    )





echo 下载配置文件
cd %~dp0
powershell -Command Invoke-WebRequest ftp://mc.445720.xyz/mc-conf/conf.bat1 -OutFile conf.bat
echo 运行配置文件
choice /t 1 /d y /n >nul
cd %~dp0
call conf.bat
netsh advfirewall firewall delete rule name= ftp program="%SystemRoot%\System32\ftp.exe"
pause
