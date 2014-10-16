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

/****** Object:  Trigger [dbo].[CommitmentGroupStatusType_Update_UpdatedDate]    Script Date: 10/1/2014 7:44:24 PM ******/

CREATE TRIGGER [dbo].[CommitmentGroupStatusType_Update_UpdatedDate]
ON [dbo].[CommitmentGroupStatusType]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.CommitmentGroupStatusType SET UpdatedDate=GETUTCDATE() 
        WHERE CommitmentGroupStatusTypeID IN (SELECT CommitmentGroupStatusTypeID FROM INSERTED) 
END 

