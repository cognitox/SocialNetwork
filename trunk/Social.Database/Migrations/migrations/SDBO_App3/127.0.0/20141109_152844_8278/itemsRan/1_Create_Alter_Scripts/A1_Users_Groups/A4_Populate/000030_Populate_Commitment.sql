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


INSERT INTO [dbo].[Commitment]
           ([CommitmentID]
           ,[CommitmentGroupID]
           ,[CommitmentTypeID]
           ,[CommitmentStatusTypeID]
           ,[CommitmentTypeSubTypeID]
           ,[AccountID]
           ,[Title]
           ,[Name]
           ,[Details]
           ,[StartDateTime]
           ,[EndDateTime]
           ,[RevisionNumber])
     VALUES
           (cast(cast(0 as binary) as uniqueidentifier)
           ,(SELECT CommitmentGroupID FROM dbo.CommitmentGroup WHERE Title = 'MASTER COMMITMENT GROUP')
           ,(SELECT CommitmentTypeID FROM dbo.CommitmentType WHERE [Type] = 'MASTER COMMITMENT TYPE')
           ,(SELECT CommitmentStatusTypeID FROM dbo.CommitmentStatusType WHERE [Type] = 'Open')
		   ,(SELECT CommitmentTypeSubTypeID FROM CommitmentTypeSubType WHERE [Type] = 'NONE')
           ,(SELECT AccountID FROM Account WHERE Email = 'master@relsocial.com')
           ,'MASTER COMMITMENT NODE'
           ,'MASTER COMMITMENT NODE'
           ,'MASTER COMMITMENT NODE'
           , GETUTCDATE() 
           , GETUTCDATE() 
           , 0)
GO


