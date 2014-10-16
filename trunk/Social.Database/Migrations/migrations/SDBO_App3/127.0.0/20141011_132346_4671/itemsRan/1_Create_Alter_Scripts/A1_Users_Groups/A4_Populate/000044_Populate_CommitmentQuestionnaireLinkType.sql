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

GO

-- need to handle who this is sending to ....
INSERT INTO [dbo].[CommitmentQuestionnaireLinkType] ([Type]) VALUES ('MASTER COMMITMENT QUESTIONNAIRE LINK TYPE NODE')
INSERT INTO [dbo].[CommitmentQuestionnaireLinkType] ([Type]) VALUES ('Entrance Questionnaire')
INSERT INTO [dbo].[CommitmentQuestionnaireLinkType] ([Type]) VALUES ('Commitment Questionnaire')
INSERT INTO [dbo].[CommitmentQuestionnaireLinkType] ([Type]) VALUES ('Exit Questionnaire')

GO