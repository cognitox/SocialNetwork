/*************************************************************
** File:    000016_Alter_GroupAccount_Table.sql
** Name:	
** Desc:	
**			Foreign key constraints for [dbo].[GroupAccount]
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


ALTER TABLE [dbo].[GroupAccount]  ADD  CONSTRAINT [FK_GroupAccount_GroupAccountTypeID] FOREIGN KEY([GroupAccountTypeID])
REFERENCES [dbo].[GroupAccountType] ([GroupAccountTypeID])
GO

ALTER TABLE [dbo].[GroupAccount] CHECK CONSTRAINT [FK_GroupAccount_GroupAccountTypeID]
GO

ALTER TABLE [dbo].[GroupAccount]  ADD  CONSTRAINT [FK_GroupAccount_PaymentPlanGroupAccountID] FOREIGN KEY([PaymentPlanGroupAccountID])
REFERENCES [dbo].[PaymentPlanGroupAccount] ([PaymentPlanGroupAccountID])
GO

ALTER TABLE [dbo].[GroupAccount] CHECK CONSTRAINT [FK_GroupAccount_PaymentPlanGroupAccountID]
GO

