/*************************************************************
** File:    000003_Alter_PaymentPlanAccountFee_Table.sql
** Name:	
** Desc:	
**			Foreign key constraints for [dbo].[PaymentPlanAccountFee]
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

ALTER TABLE [dbo].[PaymentPlanAccountFee] ADD  CONSTRAINT [FK_PaymentPlanAccountFee_PaymentPlanAccountID] FOREIGN KEY([PaymentPlanAccountID])
REFERENCES [dbo].[PaymentPlanAccount] ([PaymentPlanAccountID])
GO

ALTER TABLE [dbo].[PaymentPlanAccountFee] CHECK CONSTRAINT [FK_PaymentPlanAccountFee_PaymentPlanAccountID]
GO


