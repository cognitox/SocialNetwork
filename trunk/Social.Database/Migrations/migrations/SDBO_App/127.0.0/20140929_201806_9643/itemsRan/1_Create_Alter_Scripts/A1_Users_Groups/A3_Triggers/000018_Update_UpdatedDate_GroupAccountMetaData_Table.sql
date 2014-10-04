/*************************************************************
** File:    000018_Update_UpdatedDate_GroupAccountMetaData_Table.sql
** Name:	[dbo].[GroupAccountMetaData_Update_UpdatedDate]
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

/****** Object:  Trigger [dbo].[GroupAccountMetaData_Update_UpdatedDate]    Script Date: 8/30/2014 12:07:44 AM ******/

CREATE TRIGGER [dbo].[GroupAccountMetaData_Update_UpdatedDate]
ON [dbo].[GroupAccountMetaData]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.GroupAccountMetaData SET UpdatedDate=GETUTCDATE() 
        WHERE GroupAccountMetaDataID IN (SELECT GroupAccountMetaDataID FROM INSERTED) 
END 
