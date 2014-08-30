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
USE {{DatabaseName}}
GO

DECLARE @PaymentPlanID UNIQUEIDENTIFIER = (SELECT TOP 1 PaymentPlanGroupAccountID FROM PaymentPlanGroupAccount WHERE Name = 'Beta Demo Plan')
-- GET THE UNIVERSITY TYPE
DECLARE @UniversityType UNIQUEIDENTIFIER = (SELECT TOP 1 GroupAccountTypeID FROM [dbo].[GroupAccountType] WHERE [Type] = 'University')
INSERT INTO [dbo].[GroupAccount] ([GroupAccountTypeID],[PaymentPlanGroupAccountID], [Name]) VALUES (@UniversityType, @PaymentPlanID, 'DePaul University')


GO

