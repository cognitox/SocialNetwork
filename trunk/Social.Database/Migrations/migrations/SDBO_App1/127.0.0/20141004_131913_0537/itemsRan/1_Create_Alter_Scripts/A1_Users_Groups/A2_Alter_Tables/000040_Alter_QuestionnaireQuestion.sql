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

ALTER TABLE [dbo].[QuestionnaireQuestion] ADD  CONSTRAINT [DF_QuestionnaireQuestion_QuestionnaireQuestionID]  DEFAULT (newsequentialid()) FOR [QuestionnaireQuestionID]
GO

ALTER TABLE [dbo].[QuestionnaireQuestion] ADD  DEFAULT (getutcdate()) FOR [CreatedDate]
GO

ALTER TABLE [dbo].[QuestionnaireQuestion] ADD  DEFAULT (getutcdate()) FOR [UpdatedDate]
GO

ALTER TABLE [dbo].[QuestionnaireQuestion]  WITH CHECK ADD  CONSTRAINT [FK_QuestionnaireQuestion_AccountID] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([AccountID])
GO

ALTER TABLE [dbo].[QuestionnaireQuestion] CHECK CONSTRAINT [FK_QuestionnaireQuestion_AccountID]
GO

ALTER TABLE [dbo].[QuestionnaireQuestion]  WITH CHECK ADD  CONSTRAINT [FK_QuestionnaireQuestion_CommitmentGroupID] FOREIGN KEY([CommitmentGroupID])
REFERENCES [dbo].[CommitmentGroup] ([CommitmentGroupID])
GO

ALTER TABLE [dbo].[QuestionnaireQuestion] CHECK CONSTRAINT [FK_QuestionnaireQuestion_CommitmentGroupID]
GO

ALTER TABLE [dbo].[QuestionnaireQuestion]  WITH CHECK ADD  CONSTRAINT [FK_QuestionnaireQuestion_GroupAccountID] FOREIGN KEY([GroupAccountID])
REFERENCES [dbo].[GroupAccount] ([GroupAccountID])
GO

ALTER TABLE [dbo].[QuestionnaireQuestion] CHECK CONSTRAINT [FK_QuestionnaireQuestion_GroupAccountID]
GO

ALTER TABLE [dbo].[QuestionnaireQuestion]  WITH CHECK ADD  CONSTRAINT [FK_QuestionnaireQuestion_QuestionnaireQuestionAnswerTypeID] FOREIGN KEY([QuestionnaireQuestionAnswerTypeID])
REFERENCES [dbo].[QuestionnaireQuestionAnswerType] ([QuestionnaireQuestionAnswerTypeID])
GO

ALTER TABLE [dbo].[QuestionnaireQuestion] CHECK CONSTRAINT [FK_QuestionnaireQuestion_QuestionnaireQuestionAnswerTypeID]
GO

ALTER TABLE [dbo].[QuestionnaireQuestion]  WITH CHECK ADD  CONSTRAINT [FK_QuestionnaireQuestion_QuestionnaireQuestionTypeID] FOREIGN KEY([QuestionnaireQuestionTypeID])
REFERENCES [dbo].[QuestionnaireQuestionAnswerType] ([QuestionnaireQuestionAnswerTypeID])
GO

ALTER TABLE [dbo].[QuestionnaireQuestion] CHECK CONSTRAINT [FK_QuestionnaireQuestion_QuestionnaireQuestionTypeID]
GO
