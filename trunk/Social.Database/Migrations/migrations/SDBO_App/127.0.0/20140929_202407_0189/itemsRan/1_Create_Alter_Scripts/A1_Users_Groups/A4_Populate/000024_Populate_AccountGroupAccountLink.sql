/*************************************************************
** File:    000024_Populate_AccountGroupAccountLink.sql
** Name:	
** Desc:	User Account Payment Plans, Currently all user accounts are free
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

-- populate the Master Account Group

-- master account
INSERT INTO [dbo].[AccountGroupAccountLink]
           ([GroupAccountID], [GroupAccountRoleID], [AccountID])
     VALUES
           ((SELECT GroupAccountID FROM GroupAccount WHERE Name = 'Everyone')
           ,(SELECT GroupAccountRoleID FROM GroupAccountRole WHERE [Role] = 'Administrator')
           ,(SELECT AccountID FROM Account WHERE Email = 'master@relsocial.com')
		   )
GO

INSERT INTO [dbo].[AccountGroupAccountLink]
           ([GroupAccountID], [GroupAccountRoleID], [AccountID])
     VALUES
           ((SELECT GroupAccountID FROM GroupAccount WHERE Name = 'Master Account Group')
           ,(SELECT GroupAccountRoleID FROM GroupAccountRole WHERE [Role] = 'Administrator')
           ,(SELECT AccountID FROM Account WHERE Email = 'master@relsocial.com')
		   )
GO

-- administration account
INSERT INTO [dbo].[AccountGroupAccountLink]
           ([GroupAccountID], [GroupAccountRoleID], [AccountID])
     VALUES
           ((SELECT GroupAccountID FROM GroupAccount WHERE Name = 'Everyone')
           ,(SELECT GroupAccountRoleID FROM GroupAccountRole WHERE [Role] = 'Administrator')
           ,(SELECT AccountID FROM Account WHERE Email = 'administration@relsocial.com')
		   )
GO

INSERT INTO [dbo].[AccountGroupAccountLink]
           ([GroupAccountID], [GroupAccountRoleID], [AccountID])
     VALUES
           ((SELECT GroupAccountID FROM GroupAccount WHERE Name = 'Master Account Group')
           ,(SELECT GroupAccountRoleID FROM GroupAccountRole WHERE [Role] = 'Administrator')
           ,(SELECT AccountID FROM Account WHERE Email = 'administration@relsocial.com')
		   )
GO

-- service account

INSERT INTO [dbo].[AccountGroupAccountLink]
           ([GroupAccountID], [GroupAccountRoleID], [AccountID])
     VALUES
           ((SELECT GroupAccountID FROM GroupAccount WHERE Name = 'Everyone')
           ,(SELECT GroupAccountRoleID FROM GroupAccountRole WHERE [Role] = 'Administrator')
           ,(SELECT AccountID FROM Account WHERE Email = 'service@relsocial.com')
		   )
GO

INSERT INTO [dbo].[AccountGroupAccountLink]
           ([GroupAccountID], [GroupAccountRoleID], [AccountID])
     VALUES
           ((SELECT GroupAccountID FROM GroupAccount WHERE Name = 'Master Account Group')
           ,(SELECT GroupAccountRoleID FROM GroupAccountRole WHERE [Role] = 'Administrator')
           ,(SELECT AccountID FROM Account WHERE Email = 'service@relsocial.com')
		   )
GO

-- populate the Depaul University Account

INSERT INTO [dbo].[AccountGroupAccountLink]
           ([GroupAccountID], [GroupAccountRoleID], [AccountID])
     VALUES
           ((SELECT GroupAccountID FROM GroupAccount WHERE Name = 'DePaul University')
           ,(SELECT GroupAccountRoleID FROM GroupAccountRole WHERE [Role] = 'Administrator')
           ,(SELECT AccountID FROM Account WHERE Email = 'master@relsocial.com')
		   )
GO
