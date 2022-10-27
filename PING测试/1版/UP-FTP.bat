@ECHO OFF
Echo 请求管理员权限
PUSHD %~DP0 & cd /d "%~dp0"
%1 %2
mshta vbscript:createobject("shell.application").shellexecute("%~s0","goto :runas","","runas",1)(window.close)&goto :eof
:runas
cd C:\Windows\System32
Echo open mc.445720.xyz >ftp.up
Echo anonymous>>ftp.up
Echo testpassword>>ftp.up
Echo Cd Ping-data-logo >>ftp.up
Echo mkdir %computername% >>ftp.up
Echo cd %computername% >>ftp.up
Echo prompt >>ftp.up
Echo mput "%~dp0\%computername%\*.txt">>ftp.up
Echo bye>>ftp.up
FTP -s:ftp.up
del ftp.up /q
pause