%%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a %%a 
cls
@echo off
color 02
set ģ��汾=7
set ģ���ַ="https://link.jscdn.cn/sharepoint/aHR0cHM6Ly9nOTk2NDk1Ny1teS5zaGFyZXBvaW50LmNvbS86dTovZy9wZXJzb25hbC9nOTk2NDk1N19nOTk2NDk1N19vbm1pY3Jvc29mdF9jb20vRVdTc3ZGdDh0dEpOalZOemdqdWVGcHdCbng0NFAxSGZyWEQxbWFtN1luR3cxUT9lPXZvanFZYw.rar"

set ���ʰ汾=1
set ���ʵ�ַ="https://link.jscdn.cn/sharepoint/aHR0cHM6Ly9nOTk2NDk1Ny1teS5zaGFyZXBvaW50LmNvbS86dTovZy9wZXJzb25hbC9nOTk2NDk1N19nOTk2NDk1N19vbm1pY3Jvc29mdF9jb20vRWZGUndjaGZ0SWhBdGRlYmNRdzRRS2tCV1N5VHM1M1RVcFZYQUNzeWRjOUM0Zz9lPVc3SVR5aA.rar"

set ��Ӱ�汾=1
set ��Ӱ��ַ="https://link.jscdn.cn/sharepoint/aHR0cHM6Ly9nOTk2NDk1Ny1teS5zaGFyZXBvaW50LmNvbS86dTovZy9wZXJzb25hbC9nOTk2NDk1N19nOTk2NDk1N19vbm1pY3Jvc29mdF9jb20vRWJXS2gxNEJFY1pNakdTb3R5bkpNWDhCeHRqY2hibWNQUl9EdzE4eHdPVUE4QT9lPWE5ZWVoeQ.rar"

set �������汾=3.1.0.4
set ��������ַ=https://contents.baka.zone/Release/BakaXL_Public_Ver_3.1.0.4.exe


for /f "delims=\" %%a in ('dir /b /a-d /o-d "BakaXL*.*"') do (
set ������=%%a
)

echo %������%| findstr BakaXL >nul && (
echo �ҵ���������ʼ��װ
set ��װͬ��=sn
)||(
color 04
echo EMMM�Һ���û�ҵ�������Ү
echo ��ѱ����߷�����������Ŀ¼
echo �������������Ĺ���  https://www.bakaxl.com/
:dw
echo ��Ҫ����������������?(y/n)
if /i "%��װͬ��%"=="sn" goto sndw
set /p ��װͬ��=
if /i "%��װͬ��%"=="y" goto yesdw
if /i "%��װͬ��%"=="n" goto nodw
goto dw

:yesdw
echo ����������
aria2  %��������ַ% -o BakaXL.exe
echo �������
echo ���Զ���������������,������װ����Ϸ�����Լ�forge�ٻ���ʹ�ñ�����,лл!!
cd %~dp0
BakaXL.exe

:nodw

echo �������˳�
pause
exit

:sndw
)


echo ��ʼ�Զ���װ
color 04
echo ע��!�⽫��ɾ����ģ��,����,��Ӱ���ϼ��е���������!!!
echo ע��!�⽫��ɾ����ģ��,����,��Ӱ���ϼ��е���������!!!
echo ע��!�⽫��ɾ����ģ��,����,��Ӱ���ϼ��е���������!!!
:love
echo �����Ƿ����?(y/n)
set /p ��װͬ��=
if /i "%��װͬ��%"=="y" goto yes
if /i "%��װͬ��%"=="n" goto no
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

color 04

echo %�汾Ŀ¼%| findstr \%�汾% >nul && (
    echo �ҵ�forge��װλ��:%�汾Ŀ¼%
)||(
echo ����Ҳ����汾Ŀ¼��!���ǲ���û�а�װforge?����˵�汾�����???
echo ������汾����¿�������װ����
echo ���û��װ��Ϸ��forge........
echo �Ǿ�ȥ��װ,��װ���������Ұ���װģ���
echo �������˳�
pause
exit
)


color 02


cd %~dp0

echo ��ǰ������ģ��汾=%ģ��汾%
echo ��ǰ���������ʰ汾=%���ʰ汾%
echo ��ǰ��������Ӱ�汾=%��Ӱ�汾%
echo ����!Ŀǰ��װ�������ǻ���ȫ��ɾ�����ؽ�!!

echo ����bata���ϼ�
md %~dp0\data

:lovem
echo �����Ƿ����ģ��?(y/n)
set /p ����ģ��=
if /i "%����ģ��%"=="y" goto yesm
if /i "%����ģ��%"=="n" goto nom
goto lovem

:nom
echo ��������ģ��

:yesm


:lover
echo �����Ƿ���²���?(y/n)
set /p ���²���=
if /i "%���²���%"=="y" goto yesr
if /i "%���²���%"=="n" goto nor
goto lover

:nor
echo �������²���

:yesr


:loves
echo �����Ƿ���¹�Ӱ?(y/n)
set /p ���¹�Ӱ=
if /i "%���¹�Ӱ%"=="y" goto yess
if /i "%���¹�Ӱ%"=="n" goto nos
goto loves

:nos
echo �������¹�Ӱ

:yess

if /i "%����ģ��%"=="n" goto nom
:yesm
echo ��ʼ����ģ�� �汾:%ģ��汾%
set exe=%~dp0\data\ģ��-%ģ��汾%.rar
if not exist %exe% (
                                aria2 --dir=%~dp0/data %ģ���ַ% -o ģ��-%ģ��汾%.rar
		echo %exe% �ļ������ڣ������ظ��ļ���
    ) else (
        echo %exe% �ļ��Ѵ��ڣ��������أ�
    )
:nom

if /i "%���²���%"=="n" goto nor
:yesr
echo ��ʼ���ز��� �汾:%���ʰ汾%
set exe=%~dp0\data\����-%���ʰ汾%.rar
if not exist %exe% (
                                aria2 --dir=%~dp0/data %���ʵ�ַ% -o ����-%���ʰ汾%.rar
		echo %exe% �ļ������ڣ������ظ��ļ���
    ) else (
        echo %exe% �ļ��Ѵ��ڣ��������أ�
    )
:nor

if /i "%���¹�Ӱ%"=="n" goto nos
:yess
echo ��ʼ���ع�Ӱ �汾:%��Ӱ�汾%
set exe=%~dp0\data\��Ӱ-%��Ӱ�汾%.rar
if not exist %exe% (
                                aria2 --dir=%~dp0/data %��Ӱ��ַ% -o ��Ӱ-%��Ӱ�汾%.rar
		echo %exe% �ļ������ڣ������ظ��ļ���
    ) else (
        echo %exe% �ļ��Ѵ��ڣ��������أ�
    )
:nos



if /i "%����ģ��%"=="n" goto nom
:yesm
echo ��ʼ��ѹģ�� �汾:%ģ��汾%
rd /s /Q %~dp0\data\mods
"winrar.exe" x -y -aos "%~dp0\data\ģ��-%ģ��汾%.rar" "%~dp0\data\"
:nom

if /i "%���²���%"=="n" goto nor
:yesr
echo ��ʼ��ѹ���� �汾:%���ʰ汾%
rd /s /Q %~dp0\data\resourcepacks
"winrar.exe" x -y -aos "%~dp0\data\����-%���ʰ汾%.rar" "%~dp0\data\"
:nor


if /i "%���¹�Ӱ%"=="n" goto nos
:yess
echo ��ʼ��ѹ��Ӱ �汾:%��Ӱ�汾%
rd /s /Q %~dp0\data\shaderpacks
"winrar.exe" x -y -aos "%~dp0\data\��Ӱ-%��Ӱ�汾%.rar" "%~dp0\data\"
:nos




echo ��ʼ�Զ���װ


if /i "%����ģ��%"=="n" goto nom
:yesm
echo ɾ�����ؽ�-ģ��-���ϼ�
rd /s /Q md %�汾Ŀ¼%\mods
md %�汾Ŀ¼%\mods
:nom

if /i "%���²���%"=="n" goto nor
:yesr
echo ɾ������-����-���ϼ�
rd /s /Q md %�汾Ŀ¼%\resourcepacks
md %�汾Ŀ¼%\resourcepacks
:nor


if /i "%���¹�Ӱ%"=="n" goto nos
:yess
echo ɾ������-��Ӱ-���ϼ�
rd /s /Q md %�汾Ŀ¼%\shaderpacks
md %�汾Ŀ¼%\shaderpacks
:nos



if /i "%����ģ��%"=="n" goto nom
:yesm
echo ����-ģ��-�ļ�
copy %~dp0\data\mods\*.* %�汾Ŀ¼%\mods
:nom


if /i "%���²���%"=="n" goto nos
:yess
echo ����-����-�ļ�
copy %~dp0\data\resourcepacks\*.* %�汾Ŀ¼%\resourcepacks
:nos


if /i "%���¹�Ӱ%"=="n" goto nor
:yesr
echo ����-��Ӱ-�ļ�
copy %~dp0\data\shaderpacks\*.* %�汾Ŀ¼%\shaderpacks
:nor




color 07

echo ��������վhttps://445720.xyz
echo ��������@ckС������д,��ӭ����ʹ��
echo QQ:2407896713 @ck�Ǻ�
echo ��װ���!��������˳�,��л���İ�װ��֧��!!!

pause