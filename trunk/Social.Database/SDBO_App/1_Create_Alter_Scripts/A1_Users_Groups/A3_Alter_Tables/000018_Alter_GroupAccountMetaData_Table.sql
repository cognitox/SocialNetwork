/*************************************************************
** File:    000018_Alter_GroupAccountMetaData_Table.sql
** Name:	
** Desc:	
**			Foreign key constraints for [dbo].[GroupAccountMetaData]
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


GO

ALTER TABLE [dbo].[GroupAccountMetaData]  ADD  CONSTRAINT [FK_GroupAccountMetaData_GroupAccountID] FOREIGN KEY([GroupAccountID])
REFERENCES [dbo].[GroupAccount] ([GroupAccountID])
GO

ALTER TABLE [dbo].[GroupAccountMetaData] CHECK CONSTRAINT [FK_GroupAccountMetaData_GroupAccountID]
GO

ALTER TABLE [dbo].[GroupAccountMetaData]  ADD  CONSTRAINT [FK_GroupAccountMetaData_GroupAccountStatusTypeID] FOREIGN KEY([GroupAccountStatusTypeID])
REFERENCES [dbo].[GroupAccountStatusType] ([GroupAccountStatusTypeID])
GO

ALTER TABLE [dbo].[GroupAccountMetaData] CHECK CONSTRAINT [FK_GroupAccountMetaData_GroupAccountStatusTypeID]
GO

