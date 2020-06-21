rem create service
rem to get help on the command, type sc <command>
set SVCNAME=DummyService
sc.exe delete %SVCNAME%
sc.exe create %SVCNAME% binPath= "%~dp0\%SVCNAME%.exe --arg1=toto" DisplayName= %SVCNAME% start= demand
sc.exe description %SVCNAME% "Dummy test service for testing"