/*************************************************************
** File:    000005_Populate_Account_Table.sql
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

DECLARE @PaymentPlanID UNIQUEIDENTIFIER = (SELECT TOP 1 PaymentPlanAccountID FROM PaymentPlanAccount WHERE Name = 'Free')
DECLARE @Type UNIQUEIDENTIFIER = (SELECT TOP 1 AccountTypeID FROM [dbo].[AccountType] WHERE [Type] = 'Administration')
INSERT INTO [dbo].[Account] ([AccountTypeID],[PaymentPlanAccountID], [Email]) VALUES (@Type, @PaymentPlanID, 'administration@relsocial.com')

GO

DECLARE @PaymentPlanID UNIQUEIDENTIFIER = (SELECT TOP 1 PaymentPlanAccountID FROM PaymentPlanAccount WHERE Name = 'Free')
DECLARE @Type UNIQUEIDENTIFIER = (SELECT TOP 1 AccountTypeID FROM [dbo].[AccountType] WHERE [Type] = 'Service')
INSERT INTO [dbo].[Account] ([AccountTypeID],[PaymentPlanAccountID], [Email]) VALUES (@Type, @PaymentPlanID, 'service@relsocial.com')

GO

DECLARE @PaymentPlanID UNIQUEIDENTIFIER = (SELECT TOP 1 PaymentPlanAccountID FROM PaymentPlanAccount WHERE Name = 'Free')
DECLARE @Type UNIQUEIDENTIFIER = (SELECT TOP 1 AccountTypeID FROM [dbo].[AccountType] WHERE [Type] = 'Master')
INSERT INTO [dbo].[Account] ([AccountTypeID],[PaymentPlanAccountID], [Email]) VALUES (@Type, @PaymentPlanID, 'master@relsocial.com')

GO
