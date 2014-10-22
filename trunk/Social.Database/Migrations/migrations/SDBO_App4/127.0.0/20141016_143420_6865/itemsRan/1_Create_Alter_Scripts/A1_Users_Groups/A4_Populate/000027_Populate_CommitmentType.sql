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


-- populate the master commitment type node here, because a master table relys on this value being within the database
INSERT INTO [dbo].[CommitmentType] ([Type],[IsActive]) VALUES ('MASTER COMMITMENT TYPE',1)
GO

INSERT INTO [dbo].[CommitmentType] ([Type],[IsActive]) VALUES ('Standard Commitment',1)
GO
INSERT INTO [dbo].[CommitmentType] ([Type],[IsActive]) VALUES ('1 to Many Group Commitment',1)
GO
INSERT INTO [dbo].[CommitmentType] ([Type],[IsActive]) VALUES ('Many to Many Commitment',1)
GO
INSERT INTO [dbo].[CommitmentType] ([Type],[IsActive]) VALUES ('Skill Builder Challange',1)
GO


