@echo off
:: https://github.com/chucknorris/roundhouse/wiki/ConfigurationOptions

SET DIR=%~dp0

:: username and password
SET user="sa"
SET password="oroVerde"

:: server & ip
SET server="localhost"
SET server.database="127.0.0.1"

:: db name
SET database.name="SANDBOX_DB"

:: repository
SET repository.path="git@github.com:ARDevOp/Augmented_Project.git"

:: env var
SET environment="LOCAL"

:: modifying these references is like playing with scissors 
:: refer to the documentation
SET version.file="%DIR%\database_local_build.xml"
SET connstring="Server=%server%;Database=%database.name%;User Id=%user%;Password=%password%;"

:: settings
SET silent=true
SET debug=false
SET sql.files.directory="%DIR%\SDBO_App"
SET version.xpath="//buildInfo/version"
SET databasetype="sqlserver"
SET outputpath="%DIR%\Migrations"
SET commandtimeout="50000"
SET commandtimeoutadmin="50000"

::folder structure

SET alterdatabasefoldername="1_Create_Alter_Scripts"
SET runbeforeupfoldername="2_Before_Update_Scripts"
SET upfoldername="3_Update_Scripts"
SET runfirstafterupdatefoldername="4_After_Update_Scripts"
SET functionsfoldername="5_Table_Function_Scripts"
SET viewsfoldername="6_View_Scripts"
SET sprocsfoldername="7_Stored_Procedures_Scripts"
SET indexesfoldername="8_Index_Scripts"
SET runAfterOtherAnyTimeScriptsfoldername="9_Run_After_Other_Anytime_Scripts"
SET permissionsfoldername="Z10_Permission_Scripts"

:: error table names

SET schemaname="dbo"
SET versiontablename="SDBOVersion"
SET scriptsruntablename="SDBOScriptsRun"
SET scriptsrunerrorstablename="SDBOScriptsRunErrors"

"%DIR%\..\Solutions\packages\roundhouse.0.8.6\bin\rh.exe" ^
	/databasename=%database.name% ^
	/sqlfilesdirectory=%sql.files.directory% ^
	/s=%server.database% ^
	/versionfile=%version.file% ^
	/versionxpath=%version.xpath% ^
	/repositorypath=%repository.path% ^
	/connstring=%connstring% ^
	/databasetype=%databasetype% ^
	/environmentname=%environment% ^
	/outputpath=%outputpath%  ^
	/commandtimeout=%commandtimeout% ^
	/commandtimeoutadmin=%commandtimeoutadmin% ^
	/alterdatabasefoldername=%alterdatabasefoldername% ^
	/runbeforeupfoldername=%runbeforeupfoldername%  ^
	/upfoldername=%upfoldername%  ^
	/runfirstafterupdatefoldername=%runfirstafterupdatefoldername%  ^
	/functionsfoldername=%functionsfoldername%  ^
	/viewsfoldername=%viewsfoldername% ^
	/sprocsfoldername=%sprocsfoldername% ^
	/indexesfoldername=%indexesfoldername% ^
	/runAfterOtherAnyTimeScriptsfoldername=%runAfterOtherAnyTimeScriptsfoldername% ^
	/permissionsfoldername=%permissionsfoldername% ^
	/schemaname=%schemaname% ^
	/versiontablename=%versiontablename% ^
	/scriptsruntablename=%scriptsruntablename% ^
	/scriptsrunerrorstablename=%scriptsrunerrorstablename% ^
	/debug=%debug% ^
	/silent=%silent% ^
	/simple





call "C:\_SOURCECODE\SocialNetwork\vendor\aspnet_regsql.exe" -C %connstring% -A all

PAUSE