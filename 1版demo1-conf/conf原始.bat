@echo off
set ģ��汾=7
set ģ���ַ=

set ���ʰ汾=1
set ���ʵ�ַ=

set ��Ӱ�汾=1
set ��Ӱ��ַ="https://g9964957-my.sharepoint.com/personal/g9964957_g9964957_onmicrosoft_com/_layouts/15/download.aspx?UniqueId=065efe4a-03e1-43db-8707-e3b78f6d793e&Translate=false&tempauth=eyJ0eXAiOiJKV1QiLCJhbGciOiJub25lIn0.eyJhdWQiOiIwMDAwMDAwMy0wMDAwLTBmZjEtY2UwMC0wMDAwMDAwMDAwMDAvZzk5NjQ5NTctbXkuc2hhcmVwb2ludC5jb21AN2MzNDk3NWUtNDUzMy00NjQyLWJjN2YtMTcyYjE5NWNjZDBlIiwiaXNzIjoiMDAwMDAwMDMtMDAwMC0wZmYxLWNlMDAtMDAwMDAwMDAwMDAwIiwibmJmIjoiMTY0MTczNjgwNyIsImV4cCI6IjE2NDE3NDA0MDciLCJlbmRwb2ludHVybCI6Im51TTJaMXhyL3k2SHNqQTMzN1pJcXJFeXNhUlZiTjVlaXp3Y0JBWkxYUWM9IiwiZW5kcG9pbnR1cmxMZW5ndGgiOiIxNjUiLCJpc2xvb3BiYWNrIjoiVHJ1ZSIsImNpZCI6IlpqYzFPR0UwTkRNdFpHVmhaUzAwTVdJMkxXRmxPVE10TWpBd016RTFOVEpoTldZMCIsInZlciI6Imhhc2hlZHByb29mdG9rZW4iLCJzaXRlaWQiOiJORGN4T1RnNVptVXRaamN5TlMwMFpHWmxMVGcyWmpVdE9HUmtNR0ZpTkdGaE1Ea3giLCJhcHBfZGlzcGxheW5hbWUiOiIxMjMiLCJnaXZlbl9uYW1lIjoiRk5VIiwiZmFtaWx5X25hbWUiOiJMTlUiLCJzaWduaW5fc3RhdGUiOiJbXCJrbXNpXCJdIiwiYXBwaWQiOiJmNTU4OTNhOS0wMjRlLTQ0YzItYmM2OC00ZDlhZWUxZDZkNzEiLCJ0aWQiOiI3YzM0OTc1ZS00NTMzLTQ2NDItYmM3Zi0xNzJiMTk1Y2NkMGUiLCJ1cG4iOiJnOTk2NDk1N0BnOTk2NDk1Ny5vbm1pY3Jvc29mdC5jb20iLCJwdWlkIjoiMTAwMzIwMDE1Nzc0MzlCRiIsImNhY2hla2V5IjoiMGguZnxtZW1iZXJzaGlwfDEwMDMyMDAxNTc3NDM5YmZAbGl2ZS5jb20iLCJzY3AiOiJhbGxmaWxlcy53cml0ZSIsInR0IjoiMiIsInVzZVBlcnNpc3RlbnRDb29raWUiOm51bGwsImlwYWRkciI6IjIwLjE5MC4xNDQuMTY5In0.eElJbThBcjlONVlBRDlaZnNOV0oreTc0SGEwbUZyMnJXOUZIcVozaWk3cz0&ApiVersion=2.0"

echo ��ǰ������ģ��汾=%ģ��汾%
echo ��ǰ���������ʰ汾=%���ʰ汾%
echo ��ǰ��������Ӱ�汾=%��Ӱ�汾%
echo ����!Ŀǰ��װ�������ǻ���ȫ��ɾ�����ؽ�!!

echo ɾ�����ؽ�bata���ϼ�
rd /s /Q md %~dp0\data
md %~dp0\data

echo ��ʼ����ģ�� �汾:%ģ��汾%

echo ��ʼ���ز��� �汾:%���ʰ汾%

echo ��ʼ���ع�Ӱ �汾:%��Ӱ�汾%

::powershell -Command "(New-Object Net.WebClient).DownloadFile('%��Ӱ��ַ%', '%~dp0\data\shaderpacks-1.png')"
::powershell -Command "Invoke-WebRequest %��Ӱ��ַ% -OutFile %~dp0\data\shaderpacks-1.rar"
:powershell -Command Invoke-WebRequest %��Ӱ��ַ% -OutFile 1.rar
:powershell -Command (New-Object Net.WebClient).DownloadFile('%��Ӱ��ַ%', '1.rar')

aria2 --dir=%~dp0/data %��Ӱ��ַ% -o shaderpacks.rar
::aria2  %��Ӱ��ַ%
pause