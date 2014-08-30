/*************************************************************
** File:    000011_Populate_AccountAccountSettingsLink_Table.sql
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

DECLARE @AccountID UNIQUEIDENTIFIER = (SELECT TOP 1 AccountID FROM Account WHERE Email = 'administration@relsocial.com')
DECLARE @AccountSettingsID UNIQUEIDENTIFIER = (SELECT TOP 1 AccountSettingsID FROM AccountSettings WHERE Section = 'Account.Settings.Notifications' AND Name = 'Notify recipients upon account creation')
DECLARE @AccountSettingsTypeID UNIQUEIDENTIFIER = (SELECT TOP 1 AccountSettingsTypeID FROM AccountSettings WHERE Section = 'Account.Settings.Notifications' AND Name = 'Notify recipients upon account creation')


INSERT INTO [dbo].[AccountAccountSettingsLink]
           ([AccountID]
           ,[AccountSettingsID]
           ,[AccountSettingsTypeID]
           ,[Value])
     VALUES
           (@AccountID
           ,@AccountSettingsID
           ,@AccountSettingsTypeID
           ,'True')
GO

USE {{DatabaseName}}
GO

DECLARE @AccountID UNIQUEIDENTIFIER = (SELECT TOP 1 AccountID FROM Account WHERE Email = 'service@relsocial.com')
DECLARE @AccountSettingsID UNIQUEIDENTIFIER = (SELECT TOP 1 AccountSettingsID FROM AccountSettings WHERE Section = 'Account.Settings.Notifications' AND Name = 'Notify recipients upon account creation')
DECLARE @AccountSettingsTypeID UNIQUEIDENTIFIER = (SELECT TOP 1 AccountSettingsTypeID FROM AccountSettings WHERE Section = 'Account.Settings.Notifications' AND Name = 'Notify recipients upon account creation')


INSERT INTO [dbo].[AccountAccountSettingsLink]
           ([AccountID]
           ,[AccountSettingsID]
           ,[AccountSettingsTypeID]
           ,[Value])
     VALUES
           (@AccountID
           ,@AccountSettingsID
           ,@AccountSettingsTypeID
           ,'True')
GO
