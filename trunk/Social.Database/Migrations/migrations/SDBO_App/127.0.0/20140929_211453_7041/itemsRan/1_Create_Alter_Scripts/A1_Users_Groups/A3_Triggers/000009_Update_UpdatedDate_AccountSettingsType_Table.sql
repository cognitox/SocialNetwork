/*************************************************************
** File:    000009_Update_UpdatedDate_AccountSettingsType_Table.sql
** Name:	[dbo].[AccountSettingsType_Update_UpdatedDate]
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

/****** Object:  Trigger [dbo].[AccountSettingsType_Update_UpdatedDate]    Script Date: 8/29/2014 11:58:43 PM ******/

CREATE TRIGGER [dbo].[AccountSettingsType_Update_UpdatedDate]
ON [dbo].[AccountSettingsType]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.AccountSettingsType SET UpdatedDate=GETUTCDATE() 
        WHERE AccountSettingsTypeID IN (SELECT AccountSettingsTypeID FROM INSERTED) 
END 

