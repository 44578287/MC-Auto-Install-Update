@echo off
cd %~dp0

set source_dir="%~dp0\ԭδ����"

for /R %source_dir% %%f in (*.bat) do (
    echo ����·����Ϣ: %%f
    echo ����Ŀ¼��Ϣ: %%~dpf
    echo �ļ�ǰ׺����: %%~nf
    echo �ļ���׺����: %%~xf
    echo �����ļ�����: %%~nxf
    echo ������׺·��: %%~dpnf
    echo �ļ��޸�ʱ��: %%~tf
    echo �ļ����ݴ�С: %%~zf Byte

set file=%%~nxf
)


if not exist "%file%" goto newly
if exist encrypt.bat copy encrypt.bat encryptbak.bat
echo %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a %%%%a >"%tmp%\encrypt.tmp"
echo cls>>"%tmp%\encrypt.tmp"
type "%file%">>"%tmp%\encrypt.tmp"
setlocal enabledelayedexpansion
for %%i in ("%tmp%\encrypt.tmp") do (
echo %%~zi >nul 2>nul
set size=%%~zi
set num=!size:~-1!
set /a mod=!num!%%2
if !mod! equ 0 (goto even) else (goto odd)
)
:even
copy "%tmp%\encrypt.tmp" %file%
del "%tmp%\encrypt.tmp"
cls
echo ==========================
echo ��ϲ��, ��������ܳɹ�^^!
echo ==========================
echo.
echo.
echo ��������˳�......

pause