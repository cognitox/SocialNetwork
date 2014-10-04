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

ALTER TABLE [dbo].[AccountSettingsMultichoiceAnswer] ADD  CONSTRAINT [DF_AccountSettingsMultichoiceAnswer_AccountSettingsMultichoiceAnswerID]  DEFAULT (newsequentialid()) FOR [AccountSettingsMultichoiceAnswerID]
GO

ALTER TABLE [dbo].[AccountSettingsMultichoiceAnswer] ADD  DEFAULT (getutcdate()) FOR [CreatedDate]
GO

ALTER TABLE [dbo].[AccountSettingsMultichoiceAnswer] ADD  DEFAULT (getutcdate()) FOR [UpdatedDate]
GO

