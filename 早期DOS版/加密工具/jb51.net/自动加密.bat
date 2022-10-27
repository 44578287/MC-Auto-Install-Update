@echo off
cd %~dp0

set source_dir="%~dp0\原未加密"

for /R %source_dir% %%f in (*.bat) do (
    echo 完整路径信息: %%f
    echo 所在目录信息: %%~dpf
    echo 文件前缀名称: %%~nf
    echo 文件后缀名称: %%~xf
    echo 完整文件名称: %%~nxf
    echo 不带后缀路径: %%~dpnf
    echo 文件修改时间: %%~tf
    echo 文件内容大小: %%~zf Byte

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
echo 恭喜你, 批处理加密成功^^!
echo ==========================
echo.
echo.
echo 按任意键退出......

pause