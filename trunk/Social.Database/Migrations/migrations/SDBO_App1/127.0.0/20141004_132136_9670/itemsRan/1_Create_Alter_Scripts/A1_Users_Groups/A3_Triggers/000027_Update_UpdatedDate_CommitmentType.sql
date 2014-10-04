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

/****** Object:  Trigger [dbo].[CommitmentType_Update_UpdatedDate]    Script Date: 10/1/2014 8:52:16 PM ******/

CREATE TRIGGER [dbo].[CommitmentType_Update_UpdatedDate]
ON [dbo].[CommitmentType]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.CommitmentType SET UpdatedDate=GETUTCDATE() 
        WHERE CommitmentTypeID IN (SELECT CommitmentTypeID FROM INSERTED) 
END 

GO


