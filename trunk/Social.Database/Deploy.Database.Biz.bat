@echo off
:: https://github.com/chucknorris/roundhouse/wiki/ConfigurationOptions

SET DIR=%~dp0
:: settings
SET silent=true
SET debug=false
SET sql.files.directory="%DIR%\..\scripts"
SET version.xpath="//buildInfo/version"
SET databasetype="mysql"
SET outputpath="%DIR%\.."
SET commandtimeout="50000"
SET commandtimeoutadmin="50000"

::folder structure

SET alterdatabasefoldername="1_alter_scripts"
SET runaftercreatedatabasefoldername="2_after_create_scripts"
SET runbeforeupfoldername="3_before_update_scripts"
SET upfoldername="4_update_scripts"
SET runfirstafterupdatefoldername="5_after_update_scripts"
SET functionsfoldername="6_functions"
SET viewsfoldername="7_views"
SET sprocsfoldername="8_stored_proceedures"
SET indexesfoldername="9_indexes"
SET runAfterOtherAnyTimeScriptsfoldername="10_run_after_orther_any_time_scripts"
SET permissionsfoldername="11_permissions_scripts"

:: error table names

SET schemaname="Manage"
SET versiontablename="ARDBVersion"
SET scriptsruntablename="ARDBScriptsRun"
SET scriptsrunerrorstablename="ARDBScriptsRunErrors"

"%DIR%\rh.exe" ^
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
	/runaftercreatedatabasefoldername=%runaftercreatedatabasefoldername% ^
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