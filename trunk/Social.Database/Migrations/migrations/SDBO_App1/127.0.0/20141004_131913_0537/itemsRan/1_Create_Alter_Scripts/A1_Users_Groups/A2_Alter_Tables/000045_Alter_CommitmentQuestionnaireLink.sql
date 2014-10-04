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

ALTER TABLE [dbo].[CommitmentQuestionnaireLink]  WITH CHECK ADD  CONSTRAINT [FK_CommitmentQuestionnaireLink_AccountID] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([AccountID])
GO

ALTER TABLE [dbo].[CommitmentQuestionnaireLink] CHECK CONSTRAINT [FK_CommitmentQuestionnaireLink_AccountID]
GO

ALTER TABLE [dbo].[CommitmentQuestionnaireLink]  WITH CHECK ADD  CONSTRAINT [FK_CommitmentQuestionnaireLink_CommitmentGroupID] FOREIGN KEY([CommitmentGroupID])
REFERENCES [dbo].[CommitmentGroup] ([CommitmentGroupID])
GO

ALTER TABLE [dbo].[CommitmentQuestionnaireLink] CHECK CONSTRAINT [FK_CommitmentQuestionnaireLink_CommitmentGroupID]
GO

ALTER TABLE [dbo].[CommitmentQuestionnaireLink]  WITH CHECK ADD  CONSTRAINT [FK_CommitmentQuestionnaireLink_CommitmentID] FOREIGN KEY([CommitmentID])
REFERENCES [dbo].[Commitment] ([CommitmentID])
GO

ALTER TABLE [dbo].[CommitmentQuestionnaireLink] CHECK CONSTRAINT [FK_CommitmentQuestionnaireLink_CommitmentID]
GO

ALTER TABLE [dbo].[CommitmentQuestionnaireLink]  WITH CHECK ADD  CONSTRAINT [FK_CommitmentQuestionnaireLink_CommitmentQuestionnaireLinkTypeID] FOREIGN KEY([CommitmentQuestionnaireLinkTypeID])
REFERENCES [dbo].[CommitmentQuestionnaireLinkType] ([CommitmentQuestionnaireLinkTypeID])
GO

ALTER TABLE [dbo].[CommitmentQuestionnaireLink] CHECK CONSTRAINT [FK_CommitmentQuestionnaireLink_CommitmentQuestionnaireLinkTypeID]
GO

ALTER TABLE [dbo].[CommitmentQuestionnaireLink]  WITH CHECK ADD  CONSTRAINT [FK_CommitmentQuestionnaireLink_QuestionnaireID] FOREIGN KEY([QuestionnaireID])
REFERENCES [dbo].[Questionnaire] ([QuestionnaireID])
GO

ALTER TABLE [dbo].[CommitmentQuestionnaireLink] CHECK CONSTRAINT [FK_CommitmentQuestionnaireLink_QuestionnaireID]
GO

ALTER TABLE [dbo].[CommitmentQuestionnaireLink]  WITH CHECK ADD  CONSTRAINT [FK_CommitmentQuestionnaireLink_SendToAccountID] FOREIGN KEY([SendToAccountID])
REFERENCES [dbo].[Account] ([AccountID])
GO

ALTER TABLE [dbo].[CommitmentQuestionnaireLink] CHECK CONSTRAINT [FK_CommitmentQuestionnaireLink_SendToAccountID]
GO

