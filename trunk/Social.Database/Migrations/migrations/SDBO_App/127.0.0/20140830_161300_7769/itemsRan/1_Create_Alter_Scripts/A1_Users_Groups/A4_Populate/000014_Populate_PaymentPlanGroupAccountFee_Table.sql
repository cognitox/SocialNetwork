/*************************************************************
** File:    000014_Populate_PaymentPlanGroupAccountFee_Table.sql
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
USE {{DatabaseName}}
GO

DECLARE @PaymentPlanID UNIQUEIDENTIFIER = (SELECT TOP 1 PaymentPlanGroupAccountID FROM PaymentPlanGroupAccount WHERE Name = 'Beta Demo Plan')

INSERT INTO [dbo].[PaymentPlanGroupAccountFee] ([PaymentPlanGroupAccountID], [Section] ,[Amount]) VALUES (@PaymentPlanID ,'Signup.Fee' ,0.00)
INSERT INTO [dbo].[PaymentPlanGroupAccountFee] ([PaymentPlanGroupAccountID], [Section] ,[Amount]) VALUES (@PaymentPlanID ,'Monthly.Fee' ,0.00)

GO

