@echo off
color 02
set ģ��汾=V7.0
set ģ���ַ="https://link.jscdn.cn/sharepoint/aHR0cHM6Ly9nOTk2NDk1Ny1teS5zaGFyZXBvaW50LmNvbS86dTovZy9wZXJzb25hbC9nOTk2NDk1N19nOTk2NDk1N19vbm1pY3Jvc29mdF9jb20vRVdTc3ZGdDh0dEpOalZOemdqdWVGcHdCbng0NFAxSGZyWEQxbWFtN1luR3cxUT9lPXZvanFZYw.rar"

set ���ʰ汾=V1.0
set ���ʵ�ַ="https://link.jscdn.cn/sharepoint/aHR0cHM6Ly9nOTk2NDk1Ny1teS5zaGFyZXBvaW50LmNvbS86dTovZy9wZXJzb25hbC9nOTk2NDk1N19nOTk2NDk1N19vbm1pY3Jvc29mdF9jb20vRWZGUndjaGZ0SWhBdGRlYmNRdzRRS2tCV1N5VHM1M1RVcFZYQUNzeWRjOUM0Zz9lPVc3SVR5aA.rar"

set ��Ӱ�汾=V1.0
set ��Ӱ��ַ="https://link.jscdn.cn/sharepoint/aHR0cHM6Ly9nOTk2NDk1Ny1teS5zaGFyZXBvaW50LmNvbS86dTovZy9wZXJzb25hbC9nOTk2NDk1N19nOTk2NDk1N19vbm1pY3Jvc29mdF9jb20vRWJXS2gxNEJFY1pNakdTb3R5bkpNWDhCeHRqY2hibWNQUl9EdzE4eHdPVUE4QT9lPWE5ZWVoeQ.rar"

echo ��ǰ������ģ��汾=%ģ��汾%
echo ��ǰ���������ʰ汾=%���ʰ汾%
echo ��ǰ��������Ӱ�汾=%��Ӱ�汾%
echo ����!Ŀǰ��װ�������ǻ���ȫ��ɾ�����ؽ�!!

echo ɾ�����ؽ�bata���ϼ�
rd /s /Q md %~dp0\data
md %~dp0\data

echo ��ʼ����ģ�� �汾:%ģ��汾%
aria2 --dir=%~dp0/data %ģ���ַ% -o ģ��.rar

echo ��ʼ���ز��� �汾:%���ʰ汾%
aria2 --dir=%~dp0/data %���ʵ�ַ% -o ����.rar

echo ��ʼ���ع�Ӱ �汾:%��Ӱ�汾%
aria2 --dir=%~dp0/data %��Ӱ��ַ% -o ��Ӱ.rar


echo ��ʼ��ѹģ�� �汾:%ģ��汾%
"winrar.exe" x -y -aos "%~dp0\data\ģ��.rar" "%~dp0\data\"

echo ��ʼ��ѹ���� �汾:%���ʰ汾%
"winrar.exe" x -y -aos "%~dp0\data\����.rar" "%~dp0\data\"

echo ��ʼ��ѹ��Ӱ �汾:%��Ӱ�汾%
"winrar.exe" x -y -aos "%~dp0\data\��Ӱ.rar" "%~dp0\data\"


color 06
echo ������ģ��Ҫ��װforge�İ汾 ʾ��:1.12.2
set /p �汾=
set �汾=%�汾%-forge
cd %~dp0\.minecraft\versions\%�汾%*

set �汾Ŀ¼=%cd%
color 02

echo �汾Ŀ¼:%�汾Ŀ¼%

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
echo ��ʼ�Զ���װ

echo ɾ�����ؽ�-ģ��-���ϼ�
rd /s /Q md %�汾Ŀ¼%\mods
md %�汾Ŀ¼%\mods

echo ɾ������-����-���ϼ�
rd /s /Q md %�汾Ŀ¼%\resourcepacks
md %�汾Ŀ¼%\resourcepacks

echo ɾ������-��Ӱ-���ϼ�
rd /s /Q md %�汾Ŀ¼%\shaderpacks
md %�汾Ŀ¼%\shaderpacks

echo ����-ģ��-�ļ�
copy %~dp0\data\mods\*.* %�汾Ŀ¼%\mods

echo ����-����-�ļ�
copy %~dp0\data\resourcepacks\*.* %�汾Ŀ¼%\resourcepacks

echo ����-��Ӱ-�ļ�
copy %~dp0\data\shaderpacks\*.* %�汾Ŀ¼%\shaderpacks

echo ��������վhttps://445720.xyz
echo ��������@ckС������д,��ӭ����ʹ��
echo QQ:2407896713 @ck�Ǻ�
echo ��װ��ɰ�������˳�,��л���İ�װ��֧��!!!

pause