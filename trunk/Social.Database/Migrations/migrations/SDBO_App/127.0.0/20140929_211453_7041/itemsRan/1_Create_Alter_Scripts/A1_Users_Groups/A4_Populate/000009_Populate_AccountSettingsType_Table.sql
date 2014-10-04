/*************************************************************
** File:    000009_Populate_AccountSettingsType_Table.sql
** Name:	
** Desc:	
**
**
**
**
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

INSERT INTO [dbo].[AccountSettingsType] ([Type]) VALUES ('CheckBox')
INSERT INTO [dbo].[AccountSettingsType] ([Type]) VALUES ('Email')
INSERT INTO [dbo].[AccountSettingsType] ([Type]) VALUES ('Text')
INSERT INTO [dbo].[AccountSettingsType] ([Type]) VALUES ('TextArea')
INSERT INTO [dbo].[AccountSettingsType] ([Type]) VALUES ('Password')
INSERT INTO [dbo].[AccountSettingsType] ([Type]) VALUES ('Multichoice')

