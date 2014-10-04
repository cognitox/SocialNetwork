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

ALTER TABLE [dbo].[CommitmentGroup]  WITH CHECK ADD  CONSTRAINT [FK_CommitmentGroup_CommitmentGroupStatusTypeID] FOREIGN KEY([CommitmentGroupStatusTypeID])
REFERENCES [dbo].[CommitmentGroupStatusType] ([CommitmentGroupStatusTypeID])
GO

ALTER TABLE [dbo].[CommitmentGroup] CHECK CONSTRAINT [FK_CommitmentGroup_CommitmentGroupStatusTypeID]
GO

