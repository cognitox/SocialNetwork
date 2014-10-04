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


INSERT INTO [dbo].[CommitmentGroup]
           ([CommitmentGroupID]
		   ,[CommitmentGroupStatusTypeID]
           ,[Title]
           ,[Details])
     VALUES
           (cast(cast(0 as binary) as uniqueidentifier)
		   ,(SELECT CommitmentGroupStatusTypeID FROM [dbo].CommitmentGroupStatusType WHERE [Type] = 'Open')
           ,'MASTER COMMITMENT GROUP'
           ,'This is the commitment group that the default master commitment is apart of. All commitments are a child commitment of the MASTER COMMITMENT GROUP')
GO

