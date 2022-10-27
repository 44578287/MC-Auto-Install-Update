cd C:\Windows\System32
Echo open mc.445720.xyz >ftp.up
Echo anonymous>>ftp.up
Echo testpassword>>ftp.up
Echo Cd data >>ftp.up
Echo get tcping.exe>>ftp.up
Echo bye>>ftp.up
FTP -s:ftp.up
del ftp.up /q
move tcping.exe %~dp0\tcping.exe
