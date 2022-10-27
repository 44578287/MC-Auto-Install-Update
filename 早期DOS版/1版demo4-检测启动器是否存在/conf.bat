@echo off
color 02
set 模组版本=V7.0
set 模组地址="https://link.jscdn.cn/sharepoint/aHR0cHM6Ly9nOTk2NDk1Ny1teS5zaGFyZXBvaW50LmNvbS86dTovZy9wZXJzb25hbC9nOTk2NDk1N19nOTk2NDk1N19vbm1pY3Jvc29mdF9jb20vRVdTc3ZGdDh0dEpOalZOemdqdWVGcHdCbng0NFAxSGZyWEQxbWFtN1luR3cxUT9lPXZvanFZYw.rar"

set 材质版本=V1.0
set 材质地址="https://link.jscdn.cn/sharepoint/aHR0cHM6Ly9nOTk2NDk1Ny1teS5zaGFyZXBvaW50LmNvbS86dTovZy9wZXJzb25hbC9nOTk2NDk1N19nOTk2NDk1N19vbm1pY3Jvc29mdF9jb20vRWZGUndjaGZ0SWhBdGRlYmNRdzRRS2tCV1N5VHM1M1RVcFZYQUNzeWRjOUM0Zz9lPVc3SVR5aA.rar"

set 光影版本=V1.0
set 光影地址="https://link.jscdn.cn/sharepoint/aHR0cHM6Ly9nOTk2NDk1Ny1teS5zaGFyZXBvaW50LmNvbS86dTovZy9wZXJzb25hbC9nOTk2NDk1N19nOTk2NDk1N19vbm1pY3Jvc29mdF9jb20vRWJXS2gxNEJFY1pNakdTb3R5bkpNWDhCeHRqY2hibWNQUl9EdzE4eHdPVUE4QT9lPWE5ZWVoeQ.rar"



for /f "delims=\" %%a in ('dir /b /a-d /o-d "BakaXL*.*"') do (
set 启动器=%%a
)

echo %启动器%| findstr BakaXL >nul && (
echo 找到启动器开始安装
)||(
color 04
echo EMMM我好像没找到启动器耶
echo 请把本工具放在启动器根目录
echo 呐这是启动器的官网  https://www.bakaxl.com/
echo 本程序将退出
pause
exit
)


echo 开始自动安装
color 04
echo 注意!这将会删除掉模组,材质,光影资料夹中的所有资料!!!
echo 注意!这将会删除掉模组,材质,光影资料夹中的所有资料!!!
echo 注意!这将会删除掉模组,材质,光影资料夹中的所有资料!!!
:love
echo 请问是否继续?(yes/no)
set /p 安装同意=
if /i "%安装同意%"=="yes" goto yes
if /i "%安装同意%"=="no" goto no
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

echo 删除并重建bata资料夹
rd /s /Q md %~dp0\data
md %~dp0\data

echo 开始下载模组 版本:%模组版本%
aria2 --dir=%~dp0/data %模组地址% -o 模组.rar

echo 开始下载材质 版本:%材质版本%
aria2 --dir=%~dp0/data %材质地址% -o 材质.rar

echo 开始下载光影 版本:%光影版本%
aria2 --dir=%~dp0/data %光影地址% -o 光影.rar


echo 开始解压模组 版本:%模组版本%
"winrar.exe" x -y -aos "%~dp0\data\模组.rar" "%~dp0\data\"

echo 开始解压材质 版本:%材质版本%
"winrar.exe" x -y -aos "%~dp0\data\材质.rar" "%~dp0\data\"

echo 开始解压光影 版本:%光影版本%
"winrar.exe" x -y -aos "%~dp0\data\光影.rar" "%~dp0\data\"





echo 开始自动安装

echo 删除并重建-模组-资料夹
rd /s /Q md %版本目录%\mods
md %版本目录%\mods

echo 删除并重-材质-资料夹
rd /s /Q md %版本目录%\resourcepacks
md %版本目录%\resourcepacks

echo 删除并重-光影-资料夹
rd /s /Q md %版本目录%\shaderpacks
md %版本目录%\shaderpacks

echo 复制-模组-文件
copy %~dp0\data\mods\*.* %版本目录%\mods

echo 复制-材质-文件
copy %~dp0\data\resourcepacks\*.* %版本目录%\resourcepacks

echo 复制-光影-文件
copy %~dp0\data\shaderpacks\*.* %版本目录%\shaderpacks

color 07

echo 快易享主站https://445720.xyz
echo 本工具由@ck小捷所编写,欢迎交流使用
echo QQ:2407896713 @ck呵呵
echo 安装完成!按任意键退出,感谢您的安装与支持!!!

pause