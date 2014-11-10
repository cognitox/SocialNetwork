﻿/*************************************************************
** File:    000024_Alter_AccountGroupAccountLink.sql
** Name:	
** Desc:	
**			Foreign key constraints for [dbo].[AccountGroupAccountLink]
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



ALTER TABLE [dbo].[AccountGroupAccountLink]  ADD  CONSTRAINT [FK_AccountGroupAccountLink_AccountID] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([AccountID])
GO

ALTER TABLE [dbo].[AccountGroupAccountLink] CHECK CONSTRAINT [FK_AccountGroupAccountLink_AccountID]
GO

ALTER TABLE [dbo].[AccountGroupAccountLink]  ADD  CONSTRAINT [FK_AccountGroupAccountLink_GroupAccountID] FOREIGN KEY([GroupAccountID])
REFERENCES [dbo].[GroupAccount] ([GroupAccountID])
GO

ALTER TABLE [dbo].[AccountGroupAccountLink] CHECK CONSTRAINT [FK_AccountGroupAccountLink_GroupAccountID]
GO

ALTER TABLE [dbo].[AccountGroupAccountLink]  ADD  CONSTRAINT [FK_AccountGroupAccountLink_GroupAccountRoleID] FOREIGN KEY([GroupAccountRoleID])
REFERENCES [dbo].[GroupAccountRole] ([GroupAccountRoleID])
GO

ALTER TABLE [dbo].[AccountGroupAccountLink] CHECK CONSTRAINT [FK_AccountGroupAccountLink_GroupAccountRoleID]
GO
