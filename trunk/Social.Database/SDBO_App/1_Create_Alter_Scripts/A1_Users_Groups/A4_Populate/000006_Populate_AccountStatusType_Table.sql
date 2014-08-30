/*************************************************************
** File:    000006_Populate_AccountStatusType_Table.sql
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

INSERT INTO [dbo].[AccountStatusType] ([Type]) VALUES ('Active')
INSERT INTO [dbo].[AccountStatusType] ([Type]) VALUES ('Pending')
INSERT INTO [dbo].[AccountStatusType] ([Type]) VALUES ('Disabled')

