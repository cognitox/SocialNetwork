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

ALTER TABLE [dbo].[QuestionnaireQuestionnaireQuestionLink]  WITH CHECK ADD  CONSTRAINT [FK_QuestionnaireQuestionnaireQuestionLink_CommitmentGroupID] FOREIGN KEY([CommitmentGroupID])
REFERENCES [dbo].[CommitmentGroup] ([CommitmentGroupID])
GO

ALTER TABLE [dbo].[QuestionnaireQuestionnaireQuestionLink] CHECK CONSTRAINT [FK_QuestionnaireQuestionnaireQuestionLink_CommitmentGroupID]
GO

ALTER TABLE [dbo].[QuestionnaireQuestionnaireQuestionLink]  WITH CHECK ADD  CONSTRAINT [FK_QuestionnaireQuestionnaireQuestionLink_CommitmentQuestionnaireID] FOREIGN KEY([QuestionnaireID])
REFERENCES [dbo].[Questionnaire] ([QuestionnaireID])
GO

ALTER TABLE [dbo].[QuestionnaireQuestionnaireQuestionLink] CHECK CONSTRAINT [FK_QuestionnaireQuestionnaireQuestionLink_CommitmentQuestionnaireID]
GO

ALTER TABLE [dbo].[QuestionnaireQuestionnaireQuestionLink]  WITH CHECK ADD  CONSTRAINT [FK_QuestionnaireQuestionnaireQuestionLink_QuestionnaireQuestionID] FOREIGN KEY([QuestionnaireQuestionID])
REFERENCES [dbo].[QuestionnaireQuestion] ([QuestionnaireQuestionID])
GO

ALTER TABLE [dbo].[QuestionnaireQuestionnaireQuestionLink] CHECK CONSTRAINT [FK_QuestionnaireQuestionnaireQuestionLink_QuestionnaireQuestionID]
GO


