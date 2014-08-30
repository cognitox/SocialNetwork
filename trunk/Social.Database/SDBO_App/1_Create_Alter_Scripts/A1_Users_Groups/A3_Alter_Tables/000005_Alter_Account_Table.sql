/*************************************************************
** File:    000005_Alter_Account_Table.sql
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

ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_AccountTypeID] FOREIGN KEY([AccountTypeID])
REFERENCES [dbo].[AccountType] ([AccountTypeID])
GO

ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_AccountTypeID]
GO

ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_PaymentPlanAccountID] FOREIGN KEY([PaymentPlanAccountID])
REFERENCES [dbo].[PaymentPlanAccount] ([PaymentPlanAccountID])
GO

ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_PaymentPlanAccountID]
GO
