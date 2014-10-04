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

/*

TODO:// IN DEVELOPMENT


CREATE TRIGGER [dbo].[Commitment_Update_UpdatedDate_revision_number]
ON [dbo].[Commitment]
FOR UPDATE 
AS -- TODO://Need to test
BEGIN 
	INSERT INTO [dbo].[Commitment]
           ([CommitmentGroupID]
		   ,[ParentCommitmentID]
           ,[CommitmentTypeID]
           ,[CommitmentStatusTypeID]
           ,[CommitmentTypeSubTypeID]
           ,[AccountID]
           ,[Title]
           ,[Name]
           ,[Details]
           ,[RevisionNumber])
     VALUES
           ((SELECT [CommitmentGroupID] FROM INSERTED)
		   ,(SELECT [CommitmentID] FROM INSERTED)
           ,(SELECT [CommitmentTypeID] FROM INSERTED)
           ,(SELECT [CommitmentStatusTypeID] FROM INSERTED)
		   ,(SELECT [CommitmentTypeSubTypeID] FROM INSERTED)
           ,(SELECT [AccountID] FROM INSERTED)
           ,(SELECT [Title] FROM INSERTED)
           ,(SELECT [Name] FROM INSERTED)
           ,(SELECT [Details] FROM INSERTED)
           , (SELECT [RevisionNumber] + 1 FROM INSERTED))

		   -- need to handle the cases where the commitment is put in
		   -- TODO:// handle all of the inserted sub commitments... and how revisioning works

    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.Commitment SET UpdatedDate=GETUTCDATE() 
        WHERE CommitmentID IN (SELECT CommitmentID FROM INSERTED)
END 
*/