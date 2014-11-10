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

ALTER TABLE [dbo].[CommitmentTypeSubType]  WITH CHECK ADD  CONSTRAINT [FK_CommitmentTypeSubType_CommitmentTypeID] FOREIGN KEY([CommitmentTypeID])
REFERENCES [dbo].[CommitmentType] ([CommitmentTypeID])
GO




