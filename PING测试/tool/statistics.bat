cd..
set �ϼ�Ŀ¼=%cd%
cd %~dp0
set datevar=%date:~0,4%��%date:~5,2%��%date:~8,2%��
set timevar=%time:~0,2%
if /i %timevar% LSS 10 (
set timevar=0%time:~1,1%
)
set timevar=%timevar%ʱ%time:~3,2%��%time:~6,2%��
cd ..
@findstr /c:"Average" "%�ϼ�Ŀ¼%\data\*.txt" > %�ϼ�Ŀ¼%\%computername%\Ping-ͳ��-%computername%-%datevar%%timevar%.txt
