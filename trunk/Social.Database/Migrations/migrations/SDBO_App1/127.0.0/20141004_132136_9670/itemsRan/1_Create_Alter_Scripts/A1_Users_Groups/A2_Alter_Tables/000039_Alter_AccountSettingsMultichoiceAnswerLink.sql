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

ALTER TABLE [dbo].[AccountSettingsAccountSettingsMultichoiceAnswerLink] ADD  CONSTRAINT [DF_AccountSettingsAccountSettingsMultichoiceAnswerLink_AccountSettingsAccountSettingsMultichoiceAnswerLinkID]  DEFAULT (newsequentialid()) FOR [AccountSettingsAccountSettingsMultichoiceAnswerLinkID]
GO

ALTER TABLE [dbo].[AccountSettingsAccountSettingsMultichoiceAnswerLink] ADD  DEFAULT (getutcdate()) FOR [CreatedDate]
GO

ALTER TABLE [dbo].[AccountSettingsAccountSettingsMultichoiceAnswerLink] ADD  DEFAULT (getutcdate()) FOR [UpdatedDate]
GO

ALTER TABLE [dbo].[AccountSettingsAccountSettingsMultichoiceAnswerLink]  WITH CHECK ADD  CONSTRAINT [FK_AccountSettingsAccountSettingsMultichoiceAnswerLink_AccountSettingsMultichoiceAnswerID] FOREIGN KEY([AccountSettingsMultichoiceAnswerID])
REFERENCES [dbo].[AccountSettingsMultichoiceAnswer] ([AccountSettingsMultichoiceAnswerID])
GO

ALTER TABLE [dbo].[AccountSettingsAccountSettingsMultichoiceAnswerLink] CHECK CONSTRAINT [FK_AccountSettingsAccountSettingsMultichoiceAnswerLink_AccountSettingsMultichoiceAnswerID]
GO

ALTER TABLE [dbo].[AccountSettingsAccountSettingsMultichoiceAnswerLink]  WITH CHECK ADD  CONSTRAINT [FK_AccountSettingsAccountSettingsMultichoiceAnswerLink_QuestionnaireQuestionTypeID] FOREIGN KEY([AccountSettingsID])
REFERENCES [dbo].[AccountSettings] ([AccountSettingsID])
GO

ALTER TABLE [dbo].[AccountSettingsAccountSettingsMultichoiceAnswerLink] CHECK CONSTRAINT [FK_AccountSettingsAccountSettingsMultichoiceAnswerLink_QuestionnaireQuestionTypeID]
GO


