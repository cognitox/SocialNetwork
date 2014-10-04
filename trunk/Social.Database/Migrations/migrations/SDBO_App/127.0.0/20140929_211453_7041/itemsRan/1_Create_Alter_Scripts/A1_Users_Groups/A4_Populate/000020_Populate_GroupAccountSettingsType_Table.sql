/*************************************************************
** File:    000020_Populate_GroupAccountSettingsType_Table.sql
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


INSERT INTO [dbo].[GroupAccountSettingsType] ([Type]) VALUES ('CheckBox')
INSERT INTO [dbo].[GroupAccountSettingsType] ([Type]) VALUES ('Email')
INSERT INTO [dbo].[GroupAccountSettingsType] ([Type]) VALUES ('Text')
INSERT INTO [dbo].[GroupAccountSettingsType] ([Type]) VALUES ('TextArea')
INSERT INTO [dbo].[GroupAccountSettingsType] ([Type]) VALUES ('Password')
GO
