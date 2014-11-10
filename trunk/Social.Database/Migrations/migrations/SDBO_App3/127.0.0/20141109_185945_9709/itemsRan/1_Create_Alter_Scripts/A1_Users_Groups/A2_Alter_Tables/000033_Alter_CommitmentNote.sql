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

ALTER TABLE [dbo].[CommitmentNote]  WITH CHECK ADD  CONSTRAINT [FK_CommitmentNote_AccountID] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([AccountID])
GO



ALTER TABLE [dbo].[CommitmentNote] CHECK CONSTRAINT [FK_CommitmentNote_AccountID]
GO

ALTER TABLE [dbo].[CommitmentNote]  WITH CHECK ADD  CONSTRAINT [FK_CommitmentNote_CommitmentGroupID] FOREIGN KEY([CommitmentGroupID])
REFERENCES [dbo].[CommitmentGroup] ([CommitmentGroupID])
GO

ALTER TABLE [dbo].[CommitmentNote] CHECK CONSTRAINT [FK_CommitmentNote_CommitmentGroupID]
GO

ALTER TABLE [dbo].[CommitmentNote]  WITH CHECK ADD  CONSTRAINT [FK_CommitmentNote_CommitmentID] FOREIGN KEY([CommitmentID])
REFERENCES [dbo].[Commitment] ([CommitmentID])
GO

ALTER TABLE [dbo].[CommitmentNote] CHECK CONSTRAINT [FK_CommitmentNote_CommitmentID]
GO

ALTER TABLE [dbo].[CommitmentNote]  WITH CHECK ADD  CONSTRAINT [FK_CommitmentNote_CommitmentNoteTypeID] FOREIGN KEY([CommitmentNoteTypeID])
REFERENCES [dbo].[CommitmentNoteType] ([CommitmentNoteTypeID])
GO

ALTER TABLE [dbo].[CommitmentNote] CHECK CONSTRAINT [FK_CommitmentNote_CommitmentNoteTypeID]
GO

ALTER TABLE [dbo].[CommitmentNote]  WITH CHECK ADD  CONSTRAINT [FK_CommitmentNote_ParentCommitmentNoteID] FOREIGN KEY([ParentCommitmentNoteID])
REFERENCES [dbo].[CommitmentNote] ([CommitmentNoteID])
GO

ALTER TABLE [dbo].[CommitmentNote] CHECK CONSTRAINT [FK_CommitmentNote_ParentCommitmentNoteID]
GO

