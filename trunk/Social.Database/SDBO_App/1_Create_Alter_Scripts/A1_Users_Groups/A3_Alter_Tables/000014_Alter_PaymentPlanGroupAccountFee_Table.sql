/*************************************************************
** File:    000014_Alter_PaymentPlanGroupAccountFee_Table.sql
** Name:	
** Desc:	
**			Foreign key constraints for [dbo].[PaymentPlanGroupAccountFee]
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

ALTER TABLE [dbo].[PaymentPlanGroupAccountFee]  WITH CHECK ADD  CONSTRAINT [FK_PaymentPlanGroupAccountFee_PaymentPlanGroupAccountID] FOREIGN KEY([PaymentPlanGroupAccountID])
REFERENCES [dbo].[PaymentPlanGroupAccount] ([PaymentPlanGroupAccountID])
GO

ALTER TABLE [dbo].[PaymentPlanGroupAccountFee] CHECK CONSTRAINT [FK_PaymentPlanGroupAccountFee_PaymentPlanGroupAccountID]
GO
