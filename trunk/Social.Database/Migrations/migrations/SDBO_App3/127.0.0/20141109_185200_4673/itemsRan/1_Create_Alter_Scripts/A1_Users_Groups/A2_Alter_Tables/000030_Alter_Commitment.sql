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



ALTER TABLE [dbo].[Commitment]  WITH CHECK ADD  CONSTRAINT [FK_Commitment_AccountID] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([AccountID])
GO


ALTER TABLE [dbo].[Commitment] CHECK CONSTRAINT [FK_Commitment_AccountID]
GO

ALTER TABLE [dbo].[Commitment]  WITH CHECK ADD  CONSTRAINT [FK_Commitment_CommitmentGroupID] FOREIGN KEY([CommitmentGroupID])
REFERENCES [dbo].[CommitmentGroup] ([CommitmentGroupID])
GO

ALTER TABLE [dbo].[Commitment] CHECK CONSTRAINT [FK_Commitment_CommitmentGroupID]
GO

ALTER TABLE [dbo].[Commitment]  WITH CHECK ADD  CONSTRAINT [FK_Commitment_CommitmentStatusTypeID] FOREIGN KEY([CommitmentStatusTypeID])
REFERENCES [dbo].[CommitmentStatusType] ([CommitmentStatusTypeID])
GO

ALTER TABLE [dbo].[Commitment] CHECK CONSTRAINT [FK_Commitment_CommitmentStatusTypeID]
GO

ALTER TABLE [dbo].[Commitment]  WITH CHECK ADD  CONSTRAINT [FK_Commitment_CommitmentTypeID] FOREIGN KEY([CommitmentTypeID])
REFERENCES [dbo].[CommitmentType] ([CommitmentTypeID])
GO

ALTER TABLE [dbo].[Commitment] CHECK CONSTRAINT [FK_Commitment_CommitmentTypeID]
GO

ALTER TABLE [dbo].[Commitment]  WITH CHECK ADD  CONSTRAINT [FK_Commitment_CommitmentTypeSubTypeID] FOREIGN KEY([CommitmentTypeSubTypeID])
REFERENCES [dbo].[CommitmentTypeSubType] ([CommitmentTypeSubTypeID])
GO

ALTER TABLE [dbo].[Commitment] CHECK CONSTRAINT [FK_Commitment_CommitmentTypeSubTypeID]
GO



