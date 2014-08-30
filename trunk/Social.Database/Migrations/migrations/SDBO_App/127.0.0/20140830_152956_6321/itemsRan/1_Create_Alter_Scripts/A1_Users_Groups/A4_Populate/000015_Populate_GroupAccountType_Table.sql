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



INSERT INTO [dbo].[GroupAccountType] ([Type]) VALUES ('Everyone')
INSERT INTO [dbo].[GroupAccountType] ([Type]) VALUES ('University')
INSERT INTO [dbo].[GroupAccountType] ([Type]) VALUES ('Business')

GO