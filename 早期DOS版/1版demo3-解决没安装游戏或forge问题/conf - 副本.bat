@echo off
color 02
set 模组版本=V7.0
set 模组地址="https://link.jscdn.cn/sharepoint/aHR0cHM6Ly9nOTk2NDk1Ny1teS5zaGFyZXBvaW50LmNvbS86dTovZy9wZXJzb25hbC9nOTk2NDk1N19nOTk2NDk1N19vbm1pY3Jvc29mdF9jb20vRVdTc3ZGdDh0dEpOalZOemdqdWVGcHdCbng0NFAxSGZyWEQxbWFtN1luR3cxUT9lPXZvanFZYw.rar"

set 材质版本=V1.0
set 材质地址="https://link.jscdn.cn/sharepoint/aHR0cHM6Ly9nOTk2NDk1Ny1teS5zaGFyZXBvaW50LmNvbS86dTovZy9wZXJzb25hbC9nOTk2NDk1N19nOTk2NDk1N19vbm1pY3Jvc29mdF9jb20vRWZGUndjaGZ0SWhBdGRlYmNRdzRRS2tCV1N5VHM1M1RVcFZYQUNzeWRjOUM0Zz9lPVc3SVR5aA.rar"

set 光影版本=V1.0
set 光影地址="https://link.jscdn.cn/sharepoint/aHR0cHM6Ly9nOTk2NDk1Ny1teS5zaGFyZXBvaW50LmNvbS86dTovZy9wZXJzb25hbC9nOTk2NDk1N19nOTk2NDk1N19vbm1pY3Jvc29mdF9jb20vRWJXS2gxNEJFY1pNakdTb3R5bkpNWDhCeHRqY2hibWNQUl9EdzE4eHdPVUE4QT9lPWE5ZWVoeQ.rar"

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
set 当前目录=%~dp0
echo %~dp0
pause
color 04


::echo %版本目录%| findstr "forge" >nul && (
  ::  echo %版本目录%包含%版本目录%
::) 

echo %版本目录%| findstr "forge" >nul && (
    echo %版本目录%包含forge
) || (
    echo %版本目录%不包含forge
    echo 程序退出
    pause
    exit
)


::if exist "%版本目录%"== "%~dp0" (
  :: echo 21321321
::)

color 02




pause