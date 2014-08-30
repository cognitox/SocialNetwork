/*************************************************************
** File:    000007_Update_UpdatedDate_AccountMetaData_Table.sql
** Name:	[dbo].[AccountMetaData_Update_UpdatedDate]
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

/****** Object:  Trigger [dbo].[AccountMetaData_Update_UpdatedDate]    Script Date: 8/29/2014 11:55:27 PM ******/

CREATE TRIGGER [dbo].[AccountMetaData_Update_UpdatedDate]
ON [dbo].[AccountMetaData]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.AccountMetaData SET UpdatedDate=GETDATE() 
        WHERE AccountMetaDataID IN (SELECT AccountMetaDataID FROM INSERTED) 
END 
