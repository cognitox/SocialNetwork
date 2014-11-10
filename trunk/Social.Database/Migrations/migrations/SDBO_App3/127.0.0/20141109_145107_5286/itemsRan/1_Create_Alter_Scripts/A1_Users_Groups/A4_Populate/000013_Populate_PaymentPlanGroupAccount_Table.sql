/*************************************************************
** File:    000013_Populate_PaymentPlanGroupAccount_Table.sql
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
INSERT INTO [dbo].[PaymentPlanGroupAccount] ([Name]) VALUES ('MASTER ACCOUNT PAYMENT PLAN')
INSERT INTO [dbo].[PaymentPlanGroupAccount] ([Name]) VALUES ('Everyone Payment Plan')
INSERT INTO [dbo].[PaymentPlanGroupAccount] ([Name]) VALUES ('Beta Demo Payment Plan')
GO

