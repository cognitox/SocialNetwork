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

ALTER TABLE [dbo].[RCAccountTransaction]  WITH CHECK ADD  CONSTRAINT [FK_RCAccountTransaction_CommitmentGroupID] FOREIGN KEY([CommitmentGroupID])
REFERENCES [dbo].[CommitmentGroup] ([CommitmentGroupID])
GO

ALTER TABLE [dbo].[RCAccountTransaction] CHECK CONSTRAINT [FK_RCAccountTransaction_CommitmentGroupID]
GO

ALTER TABLE [dbo].[RCAccountTransaction]  WITH CHECK ADD  CONSTRAINT [FK_RCAccountTransaction_CommitmentID] FOREIGN KEY([CommitmentID])
REFERENCES [dbo].[Commitment] ([CommitmentID])
GO

ALTER TABLE [dbo].[RCAccountTransaction] CHECK CONSTRAINT [FK_RCAccountTransaction_CommitmentID]
GO

ALTER TABLE [dbo].[RCAccountTransaction]  WITH CHECK ADD  CONSTRAINT [FK_RCAccountTransaction_GrantorAccountID] FOREIGN KEY([GrantorAccountID])
REFERENCES [dbo].[Account] ([AccountID])
GO

ALTER TABLE [dbo].[RCAccountTransaction] CHECK CONSTRAINT [FK_RCAccountTransaction_GrantorAccountID]
GO

ALTER TABLE [dbo].[RCAccountTransaction]  WITH CHECK ADD  CONSTRAINT [FK_RCAccountTransaction_GrantorGroupAccountID] FOREIGN KEY([GrantorGroupAccountID])
REFERENCES [dbo].[GroupAccount] ([GroupAccountID])
GO

ALTER TABLE [dbo].[RCAccountTransaction] CHECK CONSTRAINT [FK_RCAccountTransaction_GrantorGroupAccountID]
GO

ALTER TABLE [dbo].[RCAccountTransaction]  WITH CHECK ADD  CONSTRAINT [FK_RCAccountTransaction_ReceiverAccountID] FOREIGN KEY([ReceiverAccountID])
REFERENCES [dbo].[Account] ([AccountID])
GO

ALTER TABLE [dbo].[RCAccountTransaction] CHECK CONSTRAINT [FK_RCAccountTransaction_ReceiverAccountID]
GO

ALTER TABLE [dbo].[RCAccountTransaction]  WITH CHECK ADD  CONSTRAINT [FK_RCAccountTransaction_ReceiverGroupAccountID] FOREIGN KEY([ReceiverGroupAccountID])
REFERENCES [dbo].[GroupAccount] ([GroupAccountID])
GO

ALTER TABLE [dbo].[RCAccountTransaction] CHECK CONSTRAINT [FK_RCAccountTransaction_ReceiverGroupAccountID]
GO

