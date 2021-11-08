@ECHO  OFF
call :@echo

set appName=sat-challenge
set host=https://%appName%.herokuapp.com

ECHO ......................................................................................................
%@%@[42m Starting %appName%
ECHO ......................................................................................................

%@%@[32m Creating on git..
git init && git add . && git commit -m "init"
%@%@[32m Created ong git ok :)

%@%@[32m Creating heroku app...
heroku create %appName% && heroku buildpacks:set jincod/dotnetcore --app %appName% && git push heroku master
%@%@[33m Created on heroku ok :)

start %host%/swagger
PAUSE

:@echo Windows 10 native ANSI colors fast and compact macro setup by AveYo - just replace ECHO with %@% and <ESC> with @
set @10=&for /f "tokens=2-5 delims=[." %%k in ('ver') do for %%M in (%%k) do if %%M. equ 10. set "@10=%%m.%%n"
set "@=for %%n in (1,2) do if %%n==2 ( set #=^&(set @echo=!@echo:;=:! ^& for %%s in (!@echo!) do for /f "delims=[" %%t in "
 set @=%@%("%%s") do if %%s==%%t set #=!#!%%~s )^&echo(!#!^&endlocal) else setlocal enableDelayedExpansion ^&set @echo=%
if not defined @10 exit/b macro below restores escape sequences on Win10                macro above stripps @[* on older versions
for /f "tokens=1,2" %%s in ('forfiles /m "%~nx0" /c "cmd /cecho(0x1B 0xFF"') do set "@ESC=%%s" &set "@NBSP=%%t"
set @=for %%n in (1,2) do if %%n==2 (call echo(%%@echo:@[=%@ESC%[%%%@ESC%[0m%@NBSP%) else call ^&set @echo=%
for %%v in (VirtualTerminalLevel ForceV2) do reg add HKCU\Console /v %%v /d 1 /f /t reg_dword >nul 2>nul
exit/b Example: %@% @[102;93m  Hello  @[30m  World  @[                      Documentation: msft Console Virtual Terminal Sequences
::