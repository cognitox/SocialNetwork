/*************************************************************
** File:    000023_Populate_GroupAccountRole.sql
** Name:	
** Desc:	Group Account User Roles, Currenlty there are 
**			Administrators, who own the group accounts, and users
**			who are associated with the group accounts
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

INSERT INTO [dbo].[GroupAccountRole] ([Role]) VALUES ('Administrator')
INSERT INTO [dbo].[GroupAccountRole] ([Role]) VALUES ('User')
GO
