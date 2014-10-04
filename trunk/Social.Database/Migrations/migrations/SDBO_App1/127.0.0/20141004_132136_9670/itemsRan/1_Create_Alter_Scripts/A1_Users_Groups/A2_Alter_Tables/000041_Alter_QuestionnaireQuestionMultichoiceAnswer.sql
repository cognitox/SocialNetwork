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

ALTER TABLE [dbo].[QuestionnaireQuestionMultichoiceAnswer] ADD  CONSTRAINT [DF_QuestionnaireQuestion_QuestionnaireQuestionMultichoiceAnswerID]  DEFAULT (newsequentialid()) FOR [QuestionnaireQuestionMultichoiceAnswerID]
GO

ALTER TABLE [dbo].[QuestionnaireQuestionMultichoiceAnswer] ADD  DEFAULT (getutcdate()) FOR [CreatedDate]
GO

ALTER TABLE [dbo].[QuestionnaireQuestionMultichoiceAnswer] ADD  DEFAULT (getutcdate()) FOR [UpdatedDate]
GO

ALTER TABLE [dbo].[QuestionnaireQuestionMultichoiceAnswer]  WITH CHECK ADD  CONSTRAINT [FK_QuestionnaireQuestionMultichoiceAnswer_AccountID] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([AccountID])
GO

ALTER TABLE [dbo].[QuestionnaireQuestionMultichoiceAnswer] CHECK CONSTRAINT [FK_QuestionnaireQuestionMultichoiceAnswer_AccountID]
GO

ALTER TABLE [dbo].[QuestionnaireQuestionMultichoiceAnswer]  WITH CHECK ADD  CONSTRAINT [FK_QuestionnaireQuestionMultichoiceAnswer_CommitmentGroupID] FOREIGN KEY([CommitmentGroupID])
REFERENCES [dbo].[CommitmentGroup] ([CommitmentGroupID])
GO

ALTER TABLE [dbo].[QuestionnaireQuestionMultichoiceAnswer] CHECK CONSTRAINT [FK_QuestionnaireQuestionMultichoiceAnswer_CommitmentGroupID]
GO

ALTER TABLE [dbo].[QuestionnaireQuestionMultichoiceAnswer]  WITH CHECK ADD  CONSTRAINT [FK_QuestionnaireQuestionMultichoiceAnswer_GroupAccountID] FOREIGN KEY([GroupAccountID])
REFERENCES [dbo].[GroupAccount] ([GroupAccountID])
GO

ALTER TABLE [dbo].[QuestionnaireQuestionMultichoiceAnswer] CHECK CONSTRAINT [FK_QuestionnaireQuestionMultichoiceAnswer_GroupAccountID]
GO

