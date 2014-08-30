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

INSERT INTO [dbo].[GroupAccountStatusType] ([Type]) VALUES ('Active')
INSERT INTO [dbo].[GroupAccountStatusType] ([Type]) VALUES ('Pending')
INSERT INTO [dbo].[GroupAccountStatusType] ([Type]) VALUES ('Disabled')

GO

