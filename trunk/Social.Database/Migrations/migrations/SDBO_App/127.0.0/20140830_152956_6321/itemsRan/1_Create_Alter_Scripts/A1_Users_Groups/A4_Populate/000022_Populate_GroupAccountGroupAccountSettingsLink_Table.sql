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
USE {{DatabaseName}}
GO

DECLARE @GroupAccountID UNIQUEIDENTIFIER = (SELECT TOP 1 GroupAccountID FROM GroupAccount WHERE Name = 'DePaul University')
DECLARE @GroupAccountSettingsID UNIQUEIDENTIFIER = (SELECT TOP 1 GroupAccountSettingsID FROM GroupAccountSettings WHERE Section = 'Account.Settings' AND Name = 'Enable Notifications')
DECLARE @GroupAccountSettingsTypeID UNIQUEIDENTIFIER = (SELECT TOP 1 GroupAccountSettingsTypeID FROM GroupAccountSettings WHERE Section = 'Account.Settings' AND Name = 'Enable Notifications')


INSERT INTO [dbo].[GroupAccountGroupAccountSettingsLink]
           ([GroupAccountID]
           ,[GroupAccountSettingsID]
           ,[GroupAccountSettingsTypeID]
           ,[Value])
     VALUES
           (@GroupAccountID
           ,@GroupAccountSettingsID
           ,@GroupAccountSettingsTypeID
           ,'True')
GO


USE [SDBO_App]
GO

DECLARE @GroupAccountID UNIQUEIDENTIFIER = (SELECT TOP 1 GroupAccountID FROM GroupAccount WHERE Name = 'DePaul University')
DECLARE @GroupAccountSettingsID UNIQUEIDENTIFIER = (SELECT TOP 1 GroupAccountSettingsID FROM GroupAccountSettings WHERE Section = 'Account.Settings.Notifications' AND Name = 'Notify recipients upon account creation')
DECLARE @GroupAccountSettingsTypeID UNIQUEIDENTIFIER = (SELECT TOP 1 GroupAccountSettingsTypeID FROM GroupAccountSettings WHERE Section = 'Account.Settings.Notifications' AND Name = 'Notify recipients upon account creation')


INSERT INTO [dbo].[GroupAccountGroupAccountSettingsLink]
           ([GroupAccountID]
           ,[GroupAccountSettingsID]
           ,[GroupAccountSettingsTypeID]
           ,[Value])
     VALUES
           (@GroupAccountID
           ,@GroupAccountSettingsID
           ,@GroupAccountSettingsTypeID
           ,'True')
GO
