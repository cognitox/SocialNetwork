/*************************************************************
** File:    000019_Update_UpdatedDate_GroupAccountConfiguration_Table.sql
** Name:	[dbo].[GroupAccountConfiguration_Update_UpdatedDate]
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

/****** Object:  Trigger [dbo].[GroupAccountConfiguration_Update_UpdatedDate]    Script Date: 8/30/2014 12:08:09 AM ******/

CREATE TRIGGER [dbo].[GroupAccountConfiguration_Update_UpdatedDate]
ON [dbo].[GroupAccountConfiguration]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.GroupAccountConfiguration SET UpdatedDate=GETDATE() 
        WHERE GroupAccountConfigurationID IN (SELECT GroupAccountConfigurationID FROM INSERTED) 
END 
