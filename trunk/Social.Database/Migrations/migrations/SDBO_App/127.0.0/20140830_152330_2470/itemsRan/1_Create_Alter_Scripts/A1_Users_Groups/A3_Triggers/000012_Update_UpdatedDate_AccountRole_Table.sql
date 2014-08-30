/*************************************************************
** File:    000012_Update_UpdatedDate_AccountRole_Table.sql
** Name:	[dbo].[AccountRole_Update_UpdatedDate]
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

/****** Object:  Trigger [dbo].[AccountRole_Update_UpdatedDate]    Script Date: 8/30/2014 12:01:13 AM ******/

CREATE TRIGGER [dbo].[AccountRole_Update_UpdatedDate]
ON [dbo].[AccountRole]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.AccountRole SET UpdatedDate=GETDATE() 
        WHERE AccountRoleID IN (SELECT AccountRoleID FROM INSERTED) 
END 

