/*************************************************************
** File:    000010_Populate_AccountSettings_Table.sql
** Name:	
** Desc:	
**
**
**
**
**
** Auth:	Justin Jarczyk
** Date:	8/29/2014
**************************
** Change History
**************************
** PR		Date			Author				Description	
** --		--------		-------				------------------------------------
** 1		8/29/2014		Justin Jarczyk		Created Script
**
**
**************************************************************/
USE {{DatabaseName}}
GO

DECLARE @AccountSettingsTypeID UNIQUEIDENTIFIER = (SELECT TOP 1 AccountSettingsTypeID FROM AccountSettingsType WHERE [Type] = 'CheckBox')
INSERT INTO [dbo].[AccountSettings]
           ([AccountSettingsTypeID], [Section], [Name], [DefaultValue])
     VALUES
           (@AccountSettingsTypeID
           ,'Account.Settings'
           ,'Enable Notifications'
           ,'True')
GO

DECLARE @AccountSettingsTypeID UNIQUEIDENTIFIER = (SELECT TOP 1 AccountSettingsTypeID FROM AccountSettingsType WHERE [Type] = 'CheckBox')
INSERT INTO [dbo].[AccountSettings]
           ([AccountSettingsTypeID], [Section], [Name], [DefaultValue])
     VALUES
           (@AccountSettingsTypeID
           ,'Account.Settings.Notifications'
           ,'Notify recipients upon account creation'
           ,'True')
GO
