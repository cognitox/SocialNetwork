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

GO

ALTER TABLE [dbo].[QuestionnaireQuestionAnswerType] ADD  CONSTRAINT [DF_QuestionnaireQuestionAnswerType_QuestionnaireQuestionAnswerTypeID]  DEFAULT (newsequentialid()) FOR [QuestionnaireQuestionAnswerTypeID]
GO

ALTER TABLE [dbo].[QuestionnaireQuestionAnswerType] ADD  DEFAULT (getutcdate()) FOR [CreatedDate]
GO

ALTER TABLE [dbo].[QuestionnaireQuestionAnswerType] ADD  DEFAULT (getutcdate()) FOR [UpdatedDate]
GO

