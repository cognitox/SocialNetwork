/*************************************************************
** File:    000008_Populate_AccountConfiguration_Table.sql
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

INSERT INTO [dbo].[AccountConfiguration] ([Section] ,[Name] ,[Value]) VALUES ('Landing.Page', 'DisplayProfilePicture', 'True')
