/*************************************************************
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


INSERT INTO [dbo].[CommitmentGroupStatusType] ([Type]) VALUES ('Open')
GO
INSERT INTO [dbo].[CommitmentGroupStatusType] ([Type]) VALUES ('Pending')
GO
INSERT INTO [dbo].[CommitmentGroupStatusType] ([Type]) VALUES ('Closed')
GO
