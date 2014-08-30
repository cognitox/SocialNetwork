/*************************************************************
** File:    00000
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



DECLARE @GroupAccountSettingsTypeID UNIQUEIDENTIFIER = (SELECT TOP 1 GroupAccountSettingsTypeID FROM GroupAccountSettingsType WHERE [Type] = 'CheckBox')

INSERT INTO [dbo].[GroupAccountSettings]
           ([GroupAccountSettingsTypeID], [Section], [Name], [DefaultValue])
     VALUES
           (@GroupAccountSettingsTypeID
           ,'Account.Settings'
           ,'Enable Notifications'
           ,'True')
GO

DECLARE @GroupAccountSettingsTypeID UNIQUEIDENTIFIER = (SELECT TOP 1 GroupAccountSettingsTypeID FROM GroupAccountSettingsType WHERE [Type] = 'CheckBox')
INSERT INTO [dbo].[GroupAccountSettings]
           ([GroupAccountSettingsTypeID], [Section], [Name], [DefaultValue])
     VALUES
           (@GroupAccountSettingsTypeID
           ,'Account.Settings.Notifications'
           ,'Notify recipients upon account creation'
           ,'True')
GO

