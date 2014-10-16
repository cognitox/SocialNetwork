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

INSERT INTO [dbo].[QuestionnaireQuestionAnswerType] ([Type]) VALUES ('CheckBox')
INSERT INTO [dbo].[QuestionnaireQuestionAnswerType] ([Type]) VALUES ('Email')
INSERT INTO [dbo].[QuestionnaireQuestionAnswerType] ([Type]) VALUES ('Text')
INSERT INTO [dbo].[QuestionnaireQuestionAnswerType] ([Type]) VALUES ('TextArea')
INSERT INTO [dbo].[QuestionnaireQuestionAnswerType] ([Type]) VALUES ('Password')
INSERT INTO [dbo].[QuestionnaireQuestionAnswerType] ([Type]) VALUES ('Multichoice')
GO
