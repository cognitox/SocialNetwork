/*************************************************************
** File:    000025_Populate_CommitmentGroupStatusType.sql
** Name:	
** Desc:	User Account Payment Plans, Currently all user accounts are free
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

INSERT INTO [dbo].[CommitmentNote]
           ([CommitmentNoteID]
           ,[CommitmentGroupID]
           ,[CommitmentID]
           ,[CommitmentNoteTypeID]
           ,[AccountID]
           ,[ParentCommitmentNoteID]
           ,[Name]
           ,[Details]
           ,[RevisionNumber]
           ,[CreatedDate]
           ,[UpdatedDate])
     VALUES
           (cast(cast(0 as binary) as uniqueidentifier)
           ,(SELECT CommitmentGroupID FROM dbo.CommitmentGroup WHERE Title = 'MASTER COMMITMENT GROUP')
           ,(SELECT CommitmentID FROM Commitment WHERE Name = 'MASTER COMMITMENT NODE')
           ,(SELECT CommitmentNoteTypeID FROM dbo.CommitmentNoteType WHERE [Type] = 'MASTER COMMITMENT NOTE TYPE')
		   ,(SELECT AccountID FROM dbo.Account WHERE Email = 'master@relsocial.com')
           ,CAST(CAST(0 AS BINARY) AS uniqueidentifier)
           ,'MASTER COMMITMENT NOTE NODE'
           ,'MASTER COMMITMENT NOTE NODE'
           , 0
           ,GETUTCDATE()
           ,GETUTCDATE())
GO

