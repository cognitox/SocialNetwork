/*************************************************************
** File:    000025_Update_UpdatedDate_CommitmentGroupStatusType.sql
** Name:	[dbo].[AccountGroupAccountLink_Update_UpdatedDate]
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

/****** Object:  Trigger [dbo].[CommitmentTypeSubType_Update_UpdatedDate]    Script Date: 10/1/2014 8:57:26 PM ******/


CREATE TRIGGER [dbo].[CommitmentTypeSubType_Update_UpdatedDate]
ON [dbo].[CommitmentTypeSubType]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.CommitmentTypeSubType SET UpdatedDate=GETUTCDATE() 
        WHERE CommitmentTypeSubTypeID IN (SELECT CommitmentTypeSubTypeID FROM INSERTED) 
END 


GO




