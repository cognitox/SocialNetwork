/*************************************************************
** File:    000017_Update_UpdatedDate_GroupAccountStatusType_Table.sql
** Name:	[dbo].[GroupAccountStatusType_Update_UpdatedDate]
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

/****** Object:  Trigger [dbo].[GroupAccountStatusType_Update_UpdatedDate]    Script Date: 8/30/2014 12:07:11 AM ******/

CREATE TRIGGER [dbo].[GroupAccountStatusType_Update_UpdatedDate]
ON [dbo].[GroupAccountStatusType]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.GroupAccountStatusType SET UpdatedDate=GETDATE() 
        WHERE GroupAccountStatusTypeID IN (SELECT GroupAccountStatusTypeID FROM INSERTED) 
END 
