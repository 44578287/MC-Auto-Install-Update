@echo off

:lover
echo �����Ƿ���²���?(y/n)
set /p ���²���=
if /i "%���²���%"=="y" goto yesr
if /i "%���²���%"=="n" goto nor
goto lover



:nor
echo �������²���
:end

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

echo 123

echo 123
pause