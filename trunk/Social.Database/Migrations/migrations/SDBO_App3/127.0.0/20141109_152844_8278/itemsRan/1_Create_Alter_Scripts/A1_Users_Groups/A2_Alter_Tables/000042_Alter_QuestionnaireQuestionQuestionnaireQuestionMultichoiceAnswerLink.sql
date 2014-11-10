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

ALTER TABLE [dbo].[QuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLink]  WITH CHECK ADD  CONSTRAINT [FK_QQQQMultichoiceAnswerLink_AccountID] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([AccountID])
GO

ALTER TABLE [dbo].[QuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLink] CHECK CONSTRAINT [FK_QQQQMultichoiceAnswerLink_AccountID]
GO

ALTER TABLE [dbo].[QuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLink]  WITH CHECK ADD  CONSTRAINT [FK_QQQQMultichoiceAnswerLink_GroupAccountID] FOREIGN KEY([GroupAccountID])
REFERENCES [dbo].[GroupAccount] ([GroupAccountID])
GO

ALTER TABLE [dbo].[QuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLink] CHECK CONSTRAINT [FK_QQQQMultichoiceAnswerLink_GroupAccountID]
GO

ALTER TABLE [dbo].[QuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLink]  WITH CHECK ADD  CONSTRAINT [FK_QQQQMultichoiceAnswerLink_QQMultichoiceAnswerID] FOREIGN KEY([QuestionnaireQuestionMultichoiceAnswerID])
REFERENCES [dbo].[QuestionnaireQuestionMultichoiceAnswer] ([QuestionnaireQuestionMultichoiceAnswerID])
GO

ALTER TABLE [dbo].[QuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLink] CHECK CONSTRAINT [FK_QQQQMultichoiceAnswerLink_QQMultichoiceAnswerID]
GO

ALTER TABLE [dbo].[QuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLink]  WITH CHECK ADD  CONSTRAINT [FK_QQQQMultichoiceAnswerLink_QQQQMultichoiceAnswerLinkID] FOREIGN KEY([QuestionnaireQuestionID])
REFERENCES [dbo].[QuestionnaireQuestion] ([QuestionnaireQuestionID])
GO

ALTER TABLE [dbo].[QuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLink] CHECK CONSTRAINT [FK_QQQQMultichoiceAnswerLink_QQQQMultichoiceAnswerLinkID]
GO

ALTER TABLE [dbo].[QuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLink]  WITH CHECK ADD  CONSTRAINT [FK_QuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLink_CommitmentGroupID] FOREIGN KEY([CommitmentGroupID])
REFERENCES [dbo].[CommitmentGroup] ([CommitmentGroupID])
GO

ALTER TABLE [dbo].[QuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLink] CHECK CONSTRAINT [FK_QuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLink_CommitmentGroupID]
GO