/*************************************************************
** File:    000006_Update_UpdatedDate_AccountStatusType_Table.sql
** Name:	[dbo].[AccountStatusType_Update_UpdatedDate]
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

/****** Object:  Trigger [dbo].[AccountStatusType_Update_UpdatedDate]    Script Date: 8/29/2014 11:54:02 PM ******/

CREATE TRIGGER [dbo].[AccountStatusType_Update_UpdatedDate]
ON [dbo].[AccountStatusType]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.AccountStatusType SET UpdatedDate=GETDATE() 
        WHERE AccountStatusTypeID IN (SELECT AccountStatusTypeID FROM INSERTED) 
END 
