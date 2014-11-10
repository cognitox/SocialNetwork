/*************************************************************
** File:    000025_Populate_CommitmentGroupStatusType.sql
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





INSERT INTO [dbo].[CommitmentStatusType] ([Type]) VALUES ('Open')
GO
INSERT INTO [dbo].[CommitmentStatusType] ([Type]) VALUES ('Pending')
GO
INSERT INTO [dbo].[CommitmentStatusType] ([Type]) VALUES ('Closed')
GO


