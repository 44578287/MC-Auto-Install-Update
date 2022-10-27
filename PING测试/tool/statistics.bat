cd..
set 上级目录=%cd%
cd %~dp0
set datevar=%date:~0,4%年%date:~5,2%月%date:~8,2%日
set timevar=%time:~0,2%
if /i %timevar% LSS 10 (
set timevar=0%time:~1,1%
)
set timevar=%timevar%时%time:~3,2%分%time:~6,2%秒
cd ..
@findstr /c:"Average" "%上级目录%\data\*.txt" > %上级目录%\%computername%\Ping-统计-%computername%-%datevar%%timevar%.txt
