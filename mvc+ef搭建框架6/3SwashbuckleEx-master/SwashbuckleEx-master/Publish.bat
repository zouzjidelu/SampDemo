:: �������ַ���
echo %1
:: ��Ŀ������ַ
echo %2
:: ApiKey
echo %3


:: ɾ����ʷ��
del %1 /f /q /a

:: ������
set nupkg=""

:: ���
nuget Pack %2 -Build -Properties Configuration=Release

:: ���°�����
for %%a in (dir /s /a /b ./%1) do (set nupkg=%%a)

:: ���Ͱ�
nuget push %nupkg% %3 -Source https://www.nuget.org/api/v2/package