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

ALTER TABLE [dbo].[GroupAccount]  WITH CHECK ADD  CONSTRAINT [FK_GroupAccount_GroupAccountTypeID] FOREIGN KEY([GroupAccountTypeID])
REFERENCES [dbo].[GroupAccountType] ([GroupAccountTypeID])
GO

ALTER TABLE [dbo].[GroupAccount] CHECK CONSTRAINT [FK_GroupAccount_GroupAccountTypeID]
GO

ALTER TABLE [dbo].[GroupAccount]  WITH CHECK ADD  CONSTRAINT [FK_GroupAccount_PaymentPlanGroupAccountID] FOREIGN KEY([PaymentPlanGroupAccountID])
REFERENCES [dbo].[PaymentPlanGroupAccount] ([PaymentPlanGroupAccountID])
GO

ALTER TABLE [dbo].[GroupAccount] CHECK CONSTRAINT [FK_GroupAccount_PaymentPlanGroupAccountID]
GO

