/*************************************************************
** File:    000024_Alter_AccountGroupAccountLink.sql
** Name:	
** Desc:	
**			Foreign key constraints for [dbo].[AccountGroupAccountLink]
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
           ([CommitmentGroupStatusTypeID]
           ,[Title]
           ,[Details])
     VALUES
           ((SELECT CommitmentGroupStatusTypeID FROM [dbo].CommitmentGroupStatusType WHERE [Type] = 'Open')
           ,'MASTER COMMITMENT GROUP'
           ,'This is the commitment group that the default master commitment is apart of. All commitments are a child commitment of the MASTER COMMITMENT GROUP')
GO


ALTER TABLE [dbo].[CommitmentGroup]  WITH CHECK ADD  CONSTRAINT [FK_CommitmentGroup_CommitmentGroupStatusTypeID] FOREIGN KEY([CommitmentGroupStatusTypeID])
REFERENCES [dbo].[CommitmentGroupStatusType] ([CommitmentGroupStatusTypeID])
GO

ALTER TABLE [dbo].[CommitmentGroup] CHECK CONSTRAINT [FK_CommitmentGroup_CommitmentGroupStatusTypeID]
GO

