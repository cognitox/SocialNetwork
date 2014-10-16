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

ALTER TABLE [dbo].[AccountCommitmentLink]  WITH CHECK ADD  CONSTRAINT [FK_AccountCommitmentLink_AccountCommitmentLinkTypeID] FOREIGN KEY([AccountCommitmentLinkTypeID])
REFERENCES [dbo].[AccountCommitmentLinkType] ([AccountCommitmentLinkTypeID])
GO

ALTER TABLE [dbo].[AccountCommitmentLink] CHECK CONSTRAINT [FK_AccountCommitmentLink_AccountCommitmentLinkTypeID]
GO

ALTER TABLE [dbo].[AccountCommitmentLink]  WITH CHECK ADD  CONSTRAINT [FK_AccountCommitmentLink_AccountID] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([AccountID])
GO

ALTER TABLE [dbo].[AccountCommitmentLink] CHECK CONSTRAINT [FK_AccountCommitmentLink_AccountID]
GO

ALTER TABLE [dbo].[AccountCommitmentLink]  WITH CHECK ADD  CONSTRAINT [FK_AccountCommitmentLink_CommitmentGroupID] FOREIGN KEY([CommitmentGroupID])
REFERENCES [dbo].[CommitmentGroup] ([CommitmentGroupID])
GO

ALTER TABLE [dbo].[AccountCommitmentLink] CHECK CONSTRAINT [FK_AccountCommitmentLink_CommitmentGroupID]
GO

ALTER TABLE [dbo].[AccountCommitmentLink]  WITH CHECK ADD  CONSTRAINT [FK_AccountCommitmentLink_CommitmentTypeID] FOREIGN KEY([CommitmentTypeID])
REFERENCES [dbo].[CommitmentType] ([CommitmentTypeID])
GO

ALTER TABLE [dbo].[AccountCommitmentLink] CHECK CONSTRAINT [FK_AccountCommitmentLink_CommitmentTypeID]
GO

ALTER TABLE [dbo].[AccountCommitmentLink]  WITH CHECK ADD  CONSTRAINT [FK_AccountCommitmentLink_CommitmentTypeSubTypeID] FOREIGN KEY([CommitmentTypeSubTypeID])
REFERENCES [dbo].[CommitmentTypeSubType] ([CommitmentTypeSubTypeID])
GO

ALTER TABLE [dbo].[AccountCommitmentLink] CHECK CONSTRAINT [FK_AccountCommitmentLink_CommitmentTypeSubTypeID]
GO

ALTER TABLE [dbo].[AccountCommitmentLink]  WITH CHECK ADD  CONSTRAINT [FK_AccountCommitmentLink_GroupAccountID] FOREIGN KEY([GroupAccountID])
REFERENCES [dbo].[GroupAccount] ([GroupAccountID])
GO

ALTER TABLE [dbo].[AccountCommitmentLink] CHECK CONSTRAINT [FK_AccountCommitmentLink_GroupAccountID]
GO

ALTER TABLE [dbo].[AccountCommitmentLink]  WITH CHECK ADD  CONSTRAINT [FK_AccountCommitmentLink_HeadNodeCommitmentID] FOREIGN KEY([HeadNodeCommitmentID])
REFERENCES [dbo].[Commitment] ([CommitmentID])
GO

ALTER TABLE [dbo].[AccountCommitmentLink] CHECK CONSTRAINT [FK_AccountCommitmentLink_HeadNodeCommitmentID]
GO

