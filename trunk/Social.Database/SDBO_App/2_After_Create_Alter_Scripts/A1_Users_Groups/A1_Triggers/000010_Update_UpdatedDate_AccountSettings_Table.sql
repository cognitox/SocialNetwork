/*************************************************************
** File:    000010_Update_UpdatedDate_AccountSettings_Table.sql
** Name:	[dbo].[AccountSettings_Update_UpdatedDate]
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

/****** Object:  Trigger [dbo].[AccountSettings_Update_UpdatedDate]    Script Date: 8/29/2014 11:59:29 PM ******/

CREATE TRIGGER [dbo].[AccountSettings_Update_UpdatedDate]
ON [dbo].[AccountSettings]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.AccountSettings SET UpdatedDate=GETDATE() 
        WHERE AccountSettingsID IN (SELECT AccountSettingsID FROM INSERTED) 
END 
