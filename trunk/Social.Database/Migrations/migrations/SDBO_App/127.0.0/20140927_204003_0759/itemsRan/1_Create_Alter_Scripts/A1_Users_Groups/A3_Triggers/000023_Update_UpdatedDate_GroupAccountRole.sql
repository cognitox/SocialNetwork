/*************************************************************
** File:    000023_Update_UpdatedDate_GroupAccountRole.sql
** Name:	[dbo].[GroupAccountRole_Update_UpdatedDate]
** Desc:	Database Trigger, Updates the UpdatedDate Column On Update
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

/****** Object:  Trigger [dbo].[GroupAccountRole_Update_UpdatedDate]    Script Date: 8/30/2014 12:19:48 AM ******/

CREATE TRIGGER [dbo].[GroupAccountRole_Update_UpdatedDate]
ON [dbo].[GroupAccountRole]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.GroupAccountRole SET UpdatedDate=GETDATE() 
        WHERE GroupAccountRoleID IN (SELECT GroupAccountRoleID FROM INSERTED) 
END 
