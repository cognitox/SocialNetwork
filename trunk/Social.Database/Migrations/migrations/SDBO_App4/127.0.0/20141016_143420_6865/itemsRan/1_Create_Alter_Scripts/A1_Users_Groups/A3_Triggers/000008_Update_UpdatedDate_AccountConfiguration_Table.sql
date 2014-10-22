/*************************************************************
** File:    000008_Update_UpdatedDate_AccountConfiguration_Table.sql
** Name:	[dbo].[AccountConfiguration_Update_UpdatedDate]
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

/****** Object:  Trigger [dbo].[AccountConfiguration_Update_UpdatedDate]    Script Date: 8/29/2014 11:56:07 PM ******/

CREATE TRIGGER [dbo].[AccountConfiguration_Update_UpdatedDate]
ON [dbo].[AccountConfiguration]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.AccountConfiguration SET UpdatedDate=GETUTCDATE() 
        WHERE AccountConfigurationID IN (SELECT AccountConfigurationID FROM INSERTED) 
END 

