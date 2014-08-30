/*************************************************************
** File:    00000
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

INSERT INTO [dbo].[AccountType] ([Type]) VALUES ('Administration')
INSERT INTO [dbo].[AccountType] ([Type]) VALUES ('Service')

INSERT INTO [dbo].[AccountType] ([Type]) VALUES ('Standard')
INSERT INTO [dbo].[AccountType] ([Type]) VALUES ('Advanced')
INSERT INTO [dbo].[AccountType] ([Type]) VALUES ('Business')
