%%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a 
cls
@echo off
color 02
set 模组版本=7
set 模组地址="https://link.jscdn.cn/sharepoint/aHR0cHM6Ly9nOTk2NDk1Ny1teS5zaGFyZXBvaW50LmNvbS86dTovZy9wZXJzb25hbC9nOTk2NDk1N19nOTk2NDk1N19vbm1pY3Jvc29mdF9jb20vRVdTc3ZGdDh0dEpOalZOemdqdWVGcHdCbng0NFAxSGZyWEQxbWFtN1luR3cxUT9lPXZvanFZYw.rar"

set 材质版本=1
set 材质地址="https://link.jscdn.cn/sharepoint/aHR0cHM6Ly9nOTk2NDk1Ny1teS5zaGFyZXBvaW50LmNvbS86dTovZy9wZXJzb25hbC9nOTk2NDk1N19nOTk2NDk1N19vbm1pY3Jvc29mdF9jb20vRWZGUndjaGZ0SWhBdGRlYmNRdzRRS2tCV1N5VHM1M1RVcFZYQUNzeWRjOUM0Zz9lPVc3SVR5aA.rar"

set 光影版本=1
set 光影地址="https://link.jscdn.cn/sharepoint/aHR0cHM6Ly9nOTk2NDk1Ny1teS5zaGFyZXBvaW50LmNvbS86dTovZy9wZXJzb25hbC9nOTk2NDk1N19nOTk2NDk1N19vbm1pY3Jvc29mdF9jb20vRWJXS2gxNEJFY1pNakdTb3R5bkpNWDhCeHRqY2hibWNQUl9EdzE4eHdPVUE4QT9lPWE5ZWVoeQ.rar"

set 启动器版本=3.1.0.4
set 启动器地址=https://contents.baka.zone/Release/BakaXL_Public_Ver_3.1.0.4.exe


for /f "delims=\" %%a in ('dir /b /a-d /o-d "BakaXL*.*"') do (
set 启动器=%%a
)

echo %启动器%| findstr BakaXL >nul && (
echo 找到启动器开始安装
set 安装同意=sn
)||(
color 04
echo EMMM我好像没找到启动器耶
echo 请把本工具放在启动器根目录
echo 呐这是启动器的官网  https://www.bakaxl.com/
:dw
echo 需要帮你下载启动器吗?(y/n)
if /i "%安装同意%"=="sn" goto sndw
set /p 安装同意=
if /i "%安装同意%"=="y" goto yesdw
if /i "%安装同意%"=="n" goto nodw
goto dw

:yesdw
echo 下载启动器
aria2  %启动器地址% -o BakaXL.exe
echo 下载完成
echo 已自动帮您拉起启动器,请您安装完游戏本体以及forge再回来使用本工具,谢谢!!
cd %~dp0
BakaXL.exe

:nodw

echo 本程序将退出
pause
exit

:sndw
)


echo 开始自动安装
color 04
echo 注意!这将会删除掉模组,材质,光影资料夹中的所有资料!!!
echo 注意!这将会删除掉模组,材质,光影资料夹中的所有资料!!!
echo 注意!这将会删除掉模组,材质,光影资料夹中的所有资料!!!
:love
echo 请问是否继续?(y/n)
set /p 安装同意=
if /i "%安装同意%"=="y" goto yes
if /i "%安装同意%"=="n" goto no
goto love

:no
echo 取消安装!谢谢使用本工具
pause
exit

:yes
color 02


color 06
echo 请输入模组要安装forge的版本 示例:1.12.2
set /p 版本=
set 版本=%版本%-forge
cd %~dp0\.minecraft\versions\%版本%*

set 版本目录=%cd%
echo 版本目录:%版本目录%

color 04

echo %版本目录%| findstr \%版本% >nul && (
    echo 找到forge安装位置:%版本目录%
)||(
echo 大哥找不到版本目录啊!你是不是没有安装forge?还是说版本打错了???
echo 如果打错版本请从新开启本安装程序
echo 如果没安装游戏跟forge........
echo 那就去安装,安装完再来找我帮你装模组叭
echo 本程序将退出
pause
exit
)


color 02


cd %~dp0

echo 当前服务器模组版本=%模组版本%
echo 当前服务器材质版本=%材质版本%
echo 当前服务器光影版本=%光影版本%
echo 警告!目前安装动作都是基于全部删除并重建!!

echo 创建bata资料夹
md %~dp0\data

:lovem
echo 请问是否更新模组?(y/n)
set /p 更新模组=
if /i "%更新模组%"=="y" goto yesm
if /i "%更新模组%"=="n" goto nom
goto lovem

:nom
echo 您不更新模组

:yesm


:lover
echo 请问是否更新材质?(y/n)
set /p 更新材质=
if /i "%更新材质%"=="y" goto yesr
if /i "%更新材质%"=="n" goto nor
goto lover

:nor
echo 您不更新材质

:yesr


:loves
echo 请问是否更新光影?(y/n)
set /p 更新光影=
if /i "%更新光影%"=="y" goto yess
if /i "%更新光影%"=="n" goto nos
goto loves

:nos
echo 您不更新光影

:yess

if /i "%更新模组%"=="n" goto nom
:yesm
echo 开始下载模组 版本:%模组版本%
set exe=%~dp0\data\模组-%模组版本%.rar
if not exist %exe% (
                                aria2 --dir=%~dp0/data %模组地址% -o 模组-%模组版本%.rar
		echo %exe% 文件不存在，已下载该文件！
    ) else (
        echo %exe% 文件已存在，无需下载！
    )
:nom

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

if /i "%更新光影%"=="n" goto nos
:yess
echo 开始下载光影 版本:%光影版本%
set exe=%~dp0\data\光影-%光影版本%.rar
if not exist %exe% (
                                aria2 --dir=%~dp0/data %光影地址% -o 光影-%光影版本%.rar
		echo %exe% 文件不存在，已下载该文件！
    ) else (
        echo %exe% 文件已存在，无需下载！
    )
:nos



if /i "%更新模组%"=="n" goto nom
:yesm
echo 开始解压模组 版本:%模组版本%
rd /s /Q %~dp0\data\mods
"winrar.exe" x -y -aos "%~dp0\data\模组-%模组版本%.rar" "%~dp0\data\"
:nom

if /i "%更新材质%"=="n" goto nor
:yesr
echo 开始解压材质 版本:%材质版本%
rd /s /Q %~dp0\data\resourcepacks
"winrar.exe" x -y -aos "%~dp0\data\材质-%材质版本%.rar" "%~dp0\data\"
:nor


if /i "%更新光影%"=="n" goto nos
:yess
echo 开始解压光影 版本:%光影版本%
rd /s /Q %~dp0\data\shaderpacks
"winrar.exe" x -y -aos "%~dp0\data\光影-%光影版本%.rar" "%~dp0\data\"
:nos




echo 开始自动安装


if /i "%更新模组%"=="n" goto nom
:yesm
echo 删除并重建-模组-资料夹
rd /s /Q md %版本目录%\mods
md %版本目录%\mods
:nom

if /i "%更新材质%"=="n" goto nor
:yesr
echo 删除并重-材质-资料夹
rd /s /Q md %版本目录%\resourcepacks
md %版本目录%\resourcepacks
:nor


if /i "%更新光影%"=="n" goto nos
:yess
echo 删除并重-光影-资料夹
rd /s /Q md %版本目录%\shaderpacks
md %版本目录%\shaderpacks
:nos



if /i "%更新模组%"=="n" goto nom
:yesm
echo 复制-模组-文件
copy %~dp0\data\mods\*.* %版本目录%\mods
:nom


if /i "%更新材质%"=="n" goto nos
:yess
echo 复制-材质-文件
copy %~dp0\data\resourcepacks\*.* %版本目录%\resourcepacks
:nos


if /i "%更新光影%"=="n" goto nor
:yesr
echo 复制-光影-文件
copy %~dp0\data\shaderpacks\*.* %版本目录%\shaderpacks
:nor




color 07

echo 快易享主站https://445720.xyz
echo 本工具由@ck小捷所编写,欢迎交流使用
echo QQ:2407896713 @ck呵呵
echo 安装完成!按任意键退出,感谢您的安装与支持!!!

pause