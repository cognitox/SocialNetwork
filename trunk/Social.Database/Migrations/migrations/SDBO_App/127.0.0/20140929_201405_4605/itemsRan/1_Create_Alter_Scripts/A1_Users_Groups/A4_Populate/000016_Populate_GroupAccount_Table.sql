/*************************************************************
** File:    000016_Populate_GroupAccount_Table.sql
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

DECLARE @PaymentPlanID UNIQUEIDENTIFIER = (SELECT TOP 1 PaymentPlanGroupAccountID FROM PaymentPlanGroupAccount WHERE Name = 'MASTER ACCOUNT PAYMENT PLAN')
-- GET THE UNIVERSITY TYPE
DECLARE @UniversityType UNIQUEIDENTIFIER = (SELECT TOP 1 GroupAccountTypeID FROM [dbo].[GroupAccountType] WHERE [Type] = 'Master')
INSERT INTO [dbo].[GroupAccount] ([GroupAccountTypeID],[PaymentPlanGroupAccountID], [Name]) VALUES (@UniversityType, @PaymentPlanID, 'Master Account Group')


GO


DECLARE @PaymentPlanID UNIQUEIDENTIFIER = (SELECT TOP 1 PaymentPlanGroupAccountID FROM PaymentPlanGroupAccount WHERE Name = 'Everyone Payment Plan')
-- GET THE UNIVERSITY TYPE
DECLARE @UniversityType UNIQUEIDENTIFIER = (SELECT TOP 1 GroupAccountTypeID FROM [dbo].[GroupAccountType] WHERE [Type] = 'Everyone')
INSERT INTO [dbo].[GroupAccount] ([GroupAccountTypeID],[PaymentPlanGroupAccountID], [Name]) VALUES (@UniversityType, @PaymentPlanID, 'Everyone')


GO


DECLARE @PaymentPlanID UNIQUEIDENTIFIER = (SELECT TOP 1 PaymentPlanGroupAccountID FROM PaymentPlanGroupAccount WHERE Name = 'Beta Demo Payment Plan')
-- GET THE UNIVERSITY TYPE
DECLARE @UniversityType UNIQUEIDENTIFIER = (SELECT TOP 1 GroupAccountTypeID FROM [dbo].[GroupAccountType] WHERE [Type] = 'University')
INSERT INTO [dbo].[GroupAccount] ([GroupAccountTypeID],[PaymentPlanGroupAccountID], [Name]) VALUES (@UniversityType, @PaymentPlanID, 'DePaul University')


GO
