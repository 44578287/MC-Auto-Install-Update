@echo off
color 02
set ģ��汾=V7.0
set ģ���ַ="https://link.jscdn.cn/sharepoint/aHR0cHM6Ly9nOTk2NDk1Ny1teS5zaGFyZXBvaW50LmNvbS86dTovZy9wZXJzb25hbC9nOTk2NDk1N19nOTk2NDk1N19vbm1pY3Jvc29mdF9jb20vRVdTc3ZGdDh0dEpOalZOemdqdWVGcHdCbng0NFAxSGZyWEQxbWFtN1luR3cxUT9lPXZvanFZYw.rar"

set ���ʰ汾=V1.0
set ���ʵ�ַ="https://link.jscdn.cn/sharepoint/aHR0cHM6Ly9nOTk2NDk1Ny1teS5zaGFyZXBvaW50LmNvbS86dTovZy9wZXJzb25hbC9nOTk2NDk1N19nOTk2NDk1N19vbm1pY3Jvc29mdF9jb20vRWZGUndjaGZ0SWhBdGRlYmNRdzRRS2tCV1N5VHM1M1RVcFZYQUNzeWRjOUM0Zz9lPVc3SVR5aA.rar"

set ��Ӱ�汾=V1.0
set ��Ӱ��ַ="https://link.jscdn.cn/sharepoint/aHR0cHM6Ly9nOTk2NDk1Ny1teS5zaGFyZXBvaW50LmNvbS86dTovZy9wZXJzb25hbC9nOTk2NDk1N19nOTk2NDk1N19vbm1pY3Jvc29mdF9jb20vRWJXS2gxNEJFY1pNakdTb3R5bkpNWDhCeHRqY2hibWNQUl9EdzE4eHdPVUE4QT9lPWE5ZWVoeQ.rar"

echo ��ʼ�Զ���װ
color 04
echo ע��!�⽫��ɾ����ģ��,����,��Ӱ���ϼ��е���������!!!
echo ע��!�⽫��ɾ����ģ��,����,��Ӱ���ϼ��е���������!!!
echo ע��!�⽫��ɾ����ģ��,����,��Ӱ���ϼ��е���������!!!
:love
echo �����Ƿ����?(yes/no)
set /p ��װͬ��=
if /i "%��װͬ��%"=="yes" goto yes
if /i "%��װͬ��%"=="no" goto no
goto love

:no
echo ȡ����װ!ллʹ�ñ�����
pause
exit

:yes
color 02


color 06
echo ������ģ��Ҫ��װforge�İ汾 ʾ��:1.12.2
set /p �汾=
set �汾=%�汾%-forge
cd %~dp0\.minecraft\versions\%�汾%*

set �汾Ŀ¼=%cd%
echo �汾Ŀ¼:%�汾Ŀ¼%
set ��ǰĿ¼=%~dp0
echo %~dp0
pause
color 04


::echo %�汾Ŀ¼%| findstr "forge" >nul && (
  ::  echo %�汾Ŀ¼%����%�汾Ŀ¼%
::) 

echo %�汾Ŀ¼%| findstr "forge" >nul && (
    echo %�汾Ŀ¼%����forge
) || (
    echo %�汾Ŀ¼%������forge
    echo �����˳�
    pause
    exit
)


::if exist "%�汾Ŀ¼%"== "%~dp0" (
  :: echo 21321321
::)

color 02




pause