/*************************************************************
** File:    000022_Populate_GroupAccountGroupAccountSettingsLink_Table.sql
** Name:	
** Desc:	Links group account settings to a group account, group acount settings
**			are through the group account settings table, and are broken down 
**			by section with a default value... when quering this table, 
**			the group settings table must be referenced to get the proper setting
**			configurations.
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

-- create settings

DECLARE @GroupAccountID UNIQUEIDENTIFIER = (SELECT TOP 1 GroupAccountID FROM GroupAccount WHERE Name = 'Master Account Group')
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


USE {{DatabaseName}}
GO

DECLARE @GroupAccountID UNIQUEIDENTIFIER = (SELECT TOP 1 GroupAccountID FROM GroupAccount WHERE Name = 'Master Account Group')
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

-- create settings

DECLARE @GroupAccountID UNIQUEIDENTIFIER = (SELECT TOP 1 GroupAccountID FROM GroupAccount WHERE Name = 'Everyone')
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


USE {{DatabaseName}}
GO

DECLARE @GroupAccountID UNIQUEIDENTIFIER = (SELECT TOP 1 GroupAccountID FROM GroupAccount WHERE Name = 'Everyone')
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

-- create settings

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


USE {{DatabaseName}}
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

