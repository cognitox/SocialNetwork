/*************************************************************
** File:    00000
** Name:	
** Desc:	
**
**
**
**
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

ALTER TABLE [dbo].[AccountMetaData]  WITH CHECK ADD  CONSTRAINT [FK_AccountMetaData_AccountID] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([AccountID])
GO

ALTER TABLE [dbo].[AccountMetaData] CHECK CONSTRAINT [FK_AccountMetaData_AccountID]
GO

ALTER TABLE [dbo].[AccountMetaData]  WITH CHECK ADD  CONSTRAINT [FK_AccountMetaData_AccountStatusTypeID] FOREIGN KEY([AccountStatusTypeID])
REFERENCES [dbo].[AccountStatusType] ([AccountStatusTypeID])
GO

ALTER TABLE [dbo].[AccountMetaData] CHECK CONSTRAINT [FK_AccountMetaData_AccountStatusTypeID]
GO
