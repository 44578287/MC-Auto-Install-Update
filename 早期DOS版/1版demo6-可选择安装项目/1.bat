@echo off

:lover
echo 请问是否更新材质?(y/n)
set /p 更新材质=
if /i "%更新材质%"=="y" goto yesr
if /i "%更新材质%"=="n" goto nor
goto lover



:nor
echo 您不更新材质
:end

if /i "%更新材质%"=="n" goto nor
:yesr
echo 开始下载材质 版本:%材质版本%
set exe=%~dp0\data\材质-%材质版本%.rar
if not exist %exe% (
                                aria2 --dir=%~dp0/data %材质地址% -o 材质-%材质版本%.rar
		echo %exe% 文件不存在，已下载该文件！
    ) else (
        echo %exe% 文件已存在，无需下载！
    )



:nor

echo 123

echo 123
pause