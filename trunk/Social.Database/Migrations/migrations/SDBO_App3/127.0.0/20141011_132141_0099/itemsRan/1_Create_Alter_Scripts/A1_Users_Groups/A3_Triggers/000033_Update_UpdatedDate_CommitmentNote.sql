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

/****** Object:  Trigger [dbo].[CommitmentNote_Update_UpdatedDate]    Script Date: 10/1/2014 9:44:27 PM ******/

CREATE TRIGGER [dbo].[CommitmentNote_Update_UpdatedDate]
ON [dbo].[CommitmentNote]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.CommitmentNote SET UpdatedDate=GETUTCDATE() 
        WHERE CommitmentNoteID IN (SELECT CommitmentNoteID FROM INSERTED) 
END 


GO

