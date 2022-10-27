@echo off
set name=hostname
%name%
set datevar=%date:~0,4%年%date:~5,2%月%date:~8,2%日
set timevar=%time:~0,2%
if /i %timevar% LSS 10 (
set timevar=0%time:~1,1%
)
set timevar=%timevar%时%time:~3,2%分%time:~6,2%秒
echo 当前时间：%datevar%%timevar%
echo 开始测试
echo 移动到目标目录
cd %~dp0
echo 创建data资料夹
md %~dp0\data
echo 清空data资料夹
del %~dp0\data\"*.txt"
ipconfig /all> %~dp0\data\网卡信息.txt
echo 开始测试 445720.xyz
tcping 445720.xyz > %~dp0\data\(1)445720.xyz.txt
echo 开始测试 44578287.xyz
tcping 44578287.xyz > %~dp0\data\(2)44578287.xyz.txt
echo 开始测试 home.44578287.xyz
tcping home.44578287.xyz > %~dp0\data\(3)home.44578287.xyz.txt
echo 开始测试 42.193.111.84
tcping 42.193.111.84 > %~dp0\data\(8)42.193.111.84.txt
echo 开始测试 42.193.111.84 7000
tcping 42.193.111.84 7000 > %~dp0\data\(7)7000.txt
echo 开始测试 42.193.111.84 14457
tcping 42.193.111.84 14457 > %~dp0\data\(6)14457.txt
echo 开始测试 mc.445720.xyz 25565
tcping mc.445720.xyz 25565 > %~dp0\data\(5)mc.445720.xyz.25565.txt
echo 开始测试 mc.445720.xyz
tcping mc.445720.xyz > %~dp0\data\(4)mc.445720.xyz.txt
cd %~dp0\data
echo 整合data
type *.txt>res
rename res data.txt
echo 输出data文件夹
md %~dp0\%computername%
echo 输出data
copy data.txt %~dp0\%computername%\Ping-data-%computername%-%datevar%%timevar%.txt
cd %~dp0
call statistics.bat
type %~dp0\%computername%\Ping-统计-%computername%-%datevar%%timevar%.txt
echo 上传日志文件
cd %~dp0
call UP-FTP.bat
echo 输出统整
type %~dp0\%computername%\Ping-统计-%computername%-%datevar%%timevar%.txt
echo 按任意键退出,谢谢掺与测试,这些资料对我们来说非常重要!!!
echo 快易享主站https://445720.xyz
echo 本工具由@ck小捷所编写,欢迎交流使用
pause