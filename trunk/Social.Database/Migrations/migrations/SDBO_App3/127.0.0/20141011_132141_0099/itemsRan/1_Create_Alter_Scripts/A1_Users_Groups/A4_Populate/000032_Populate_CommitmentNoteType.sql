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

INSERT INTO [dbo].[CommitmentNoteType] ([Type]) VALUES ('MASTER COMMITMENT NOTE TYPE')
GO
INSERT INTO [dbo].[CommitmentNoteType] ([Type]) VALUES ('Question')
GO
INSERT INTO [dbo].[CommitmentNoteType] ([Type]) VALUES ('Comment')
GO
INSERT INTO [dbo].[CommitmentNoteType] ([Type]) VALUES ('Template')
GO