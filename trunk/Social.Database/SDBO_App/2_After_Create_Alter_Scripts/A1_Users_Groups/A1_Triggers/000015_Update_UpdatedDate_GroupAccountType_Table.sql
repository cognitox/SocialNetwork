/*************************************************************
** File:    000015_Update_UpdatedDate_GroupAccountType_Table.sql
** Name:	[dbo].[GroupAccountType_Update_UpdatedDate]
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

/****** Object:  Trigger [dbo].[GroupAccountType_Update_UpdatedDate]    Script Date: 8/30/2014 12:04:38 AM ******/

CREATE TRIGGER [dbo].[GroupAccountType_Update_UpdatedDate]
ON [dbo].[GroupAccountType]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.GroupAccountType SET UpdatedDate=GETDATE() 
        WHERE GroupAccountTypeID IN (SELECT GroupAccountTypeID FROM INSERTED) 
END 
