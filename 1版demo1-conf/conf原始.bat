@echo off
set 模组版本=7
set 模组地址=

set 材质版本=1
set 材质地址=

set 光影版本=1
set 光影地址="https://g9964957-my.sharepoint.com/personal/g9964957_g9964957_onmicrosoft_com/_layouts/15/download.aspx?UniqueId=065efe4a-03e1-43db-8707-e3b78f6d793e&Translate=false&tempauth=eyJ0eXAiOiJKV1QiLCJhbGciOiJub25lIn0.eyJhdWQiOiIwMDAwMDAwMy0wMDAwLTBmZjEtY2UwMC0wMDAwMDAwMDAwMDAvZzk5NjQ5NTctbXkuc2hhcmVwb2ludC5jb21AN2MzNDk3NWUtNDUzMy00NjQyLWJjN2YtMTcyYjE5NWNjZDBlIiwiaXNzIjoiMDAwMDAwMDMtMDAwMC0wZmYxLWNlMDAtMDAwMDAwMDAwMDAwIiwibmJmIjoiMTY0MTczNjgwNyIsImV4cCI6IjE2NDE3NDA0MDciLCJlbmRwb2ludHVybCI6Im51TTJaMXhyL3k2SHNqQTMzN1pJcXJFeXNhUlZiTjVlaXp3Y0JBWkxYUWM9IiwiZW5kcG9pbnR1cmxMZW5ndGgiOiIxNjUiLCJpc2xvb3BiYWNrIjoiVHJ1ZSIsImNpZCI6IlpqYzFPR0UwTkRNdFpHVmhaUzAwTVdJMkxXRmxPVE10TWpBd016RTFOVEpoTldZMCIsInZlciI6Imhhc2hlZHByb29mdG9rZW4iLCJzaXRlaWQiOiJORGN4T1RnNVptVXRaamN5TlMwMFpHWmxMVGcyWmpVdE9HUmtNR0ZpTkdGaE1Ea3giLCJhcHBfZGlzcGxheW5hbWUiOiIxMjMiLCJnaXZlbl9uYW1lIjoiRk5VIiwiZmFtaWx5X25hbWUiOiJMTlUiLCJzaWduaW5fc3RhdGUiOiJbXCJrbXNpXCJdIiwiYXBwaWQiOiJmNTU4OTNhOS0wMjRlLTQ0YzItYmM2OC00ZDlhZWUxZDZkNzEiLCJ0aWQiOiI3YzM0OTc1ZS00NTMzLTQ2NDItYmM3Zi0xNzJiMTk1Y2NkMGUiLCJ1cG4iOiJnOTk2NDk1N0BnOTk2NDk1Ny5vbm1pY3Jvc29mdC5jb20iLCJwdWlkIjoiMTAwMzIwMDE1Nzc0MzlCRiIsImNhY2hla2V5IjoiMGguZnxtZW1iZXJzaGlwfDEwMDMyMDAxNTc3NDM5YmZAbGl2ZS5jb20iLCJzY3AiOiJhbGxmaWxlcy53cml0ZSIsInR0IjoiMiIsInVzZVBlcnNpc3RlbnRDb29raWUiOm51bGwsImlwYWRkciI6IjIwLjE5MC4xNDQuMTY5In0.eElJbThBcjlONVlBRDlaZnNOV0oreTc0SGEwbUZyMnJXOUZIcVozaWk3cz0&ApiVersion=2.0"

echo 当前服务器模组版本=%模组版本%
echo 当前服务器材质版本=%材质版本%
echo 当前服务器光影版本=%光影版本%
echo 警告!目前安装动作都是基于全部删除并重建!!

echo 删除并重建bata资料夹
rd /s /Q md %~dp0\data
md %~dp0\data

echo 开始下载模组 版本:%模组版本%

echo 开始下载材质 版本:%材质版本%

echo 开始下载光影 版本:%光影版本%

::powershell -Command "(New-Object Net.WebClient).DownloadFile('%光影地址%', '%~dp0\data\shaderpacks-1.png')"
::powershell -Command "Invoke-WebRequest %光影地址% -OutFile %~dp0\data\shaderpacks-1.rar"
:powershell -Command Invoke-WebRequest %光影地址% -OutFile 1.rar
:powershell -Command (New-Object Net.WebClient).DownloadFile('%光影地址%', '1.rar')

aria2 --dir=%~dp0/data %光影地址% -o shaderpacks.rar
::aria2  %光影地址%
pause