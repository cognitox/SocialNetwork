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


--'MASTER COMMITMENT TYPE'
INSERT INTO [dbo].[CommitmentTypeSubType] ([CommitmentTypeID],[Type]) 
	VALUES ((SELECT CommitmentTypeID FROM CommitmentType WHERE [Type] = 'MASTER COMMITMENT TYPE'), 'NONE')
GO

--'Standard Commitment'
INSERT INTO [dbo].[CommitmentTypeSubType] ([CommitmentTypeID],[Type]) 
	VALUES ((SELECT CommitmentTypeID FROM CommitmentType WHERE [Type] = 'Standard Commitment'), 'Administrator')
GO
INSERT INTO [dbo].[CommitmentTypeSubType] ([CommitmentTypeID],[Type]) 
	VALUES ((SELECT CommitmentTypeID FROM CommitmentType WHERE [Type] = 'Standard Commitment'), 'Moderator')
GO
INSERT INTO [dbo].[CommitmentTypeSubType] ([CommitmentTypeID],[Type]) 
	VALUES ((SELECT CommitmentTypeID FROM CommitmentType WHERE [Type] = 'Standard Commitment'), 'Commiter')
GO
INSERT INTO [dbo].[CommitmentTypeSubType] ([CommitmentTypeID],[Type]) 
	VALUES ((SELECT CommitmentTypeID FROM CommitmentType WHERE [Type] = 'Standard Commitment'), 'Commitee')
GO

--'1 to Many Group Commitment'
INSERT INTO [dbo].[CommitmentTypeSubType] ([CommitmentTypeID],[Type]) 
	VALUES ((SELECT CommitmentTypeID FROM CommitmentType WHERE [Type] = '1 to Many Group Commitment'), 'Administrator')
GO
INSERT INTO [dbo].[CommitmentTypeSubType] ([CommitmentTypeID],[Type]) 
	VALUES ((SELECT CommitmentTypeID FROM CommitmentType WHERE [Type] = '1 to Many Group Commitment'), 'Moderator')
GO
INSERT INTO [dbo].[CommitmentTypeSubType] ([CommitmentTypeID],[Type]) 
	VALUES ((SELECT CommitmentTypeID FROM CommitmentType WHERE [Type] = '1 to Many Group Commitment'), 'Commiter')
GO
INSERT INTO [dbo].[CommitmentTypeSubType] ([CommitmentTypeID],[Type]) 
	VALUES ((SELECT CommitmentTypeID FROM CommitmentType WHERE [Type] = '1 to Many Group Commitment'), 'Commitee')
GO


--'Many to Many Commitment'
INSERT INTO [dbo].[CommitmentTypeSubType] ([CommitmentTypeID],[Type]) 
	VALUES ((SELECT CommitmentTypeID FROM CommitmentType WHERE [Type] = 'Many to Many Commitment'), 'Administrator')
GO
INSERT INTO [dbo].[CommitmentTypeSubType] ([CommitmentTypeID],[Type]) 
	VALUES ((SELECT CommitmentTypeID FROM CommitmentType WHERE [Type] = 'Many to Many Commitment'), 'Moderator')
GO
INSERT INTO [dbo].[CommitmentTypeSubType] ([CommitmentTypeID],[Type]) 
	VALUES ((SELECT CommitmentTypeID FROM CommitmentType WHERE [Type] = 'Many to Many Commitment'), 'Commiter Group')
GO
INSERT INTO [dbo].[CommitmentTypeSubType] ([CommitmentTypeID],[Type]) 
	VALUES ((SELECT CommitmentTypeID FROM CommitmentType WHERE [Type] = 'Many to Many Commitment'), 'Commitee Group')
GO

--'Skill Builder Challange'
INSERT INTO [dbo].[CommitmentTypeSubType] ([CommitmentTypeID],[Type]) 
	VALUES ((SELECT CommitmentTypeID FROM CommitmentType WHERE [Type] = 'Skill Builder Challange'), 'Administrator')
GO
INSERT INTO [dbo].[CommitmentTypeSubType] ([CommitmentTypeID],[Type]) 
	VALUES ((SELECT CommitmentTypeID FROM CommitmentType WHERE [Type] = 'Skill Builder Challange'), 'Moderator')
GO
INSERT INTO [dbo].[CommitmentTypeSubType] ([CommitmentTypeID],[Type]) 
	VALUES ((SELECT CommitmentTypeID FROM CommitmentType WHERE [Type] = 'Skill Builder Challange'), 'Mentor')
GO
INSERT INTO [dbo].[CommitmentTypeSubType] ([CommitmentTypeID],[Type]) 
	VALUES ((SELECT CommitmentTypeID FROM CommitmentType WHERE [Type] = 'Skill Builder Challange'), 'Mentee')
GO


