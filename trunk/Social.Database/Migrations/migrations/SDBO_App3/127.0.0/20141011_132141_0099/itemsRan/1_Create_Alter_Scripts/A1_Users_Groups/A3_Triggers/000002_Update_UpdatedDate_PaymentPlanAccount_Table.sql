/*************************************************************
** File:    000002_Update_UpdatedDate_PaymentPlanAccount_Table.sql
** Name:	[dbo].[PaymentPlanAccount_Update_UpdatedDate]
** Desc:	Database Trigger, Updates the UpdatedDate Column On Update
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

/****** Object:  Trigger [dbo].[PaymentPlanAccount_Update_UpdatedDate]    Script Date: 8/29/2014 11:50:18 PM ******/

CREATE TRIGGER [dbo].[PaymentPlanAccount_Update_UpdatedDate]
ON [dbo].[PaymentPlanAccount]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.PaymentPlanAccount SET UpdatedDate=GETUTCDATE() 
        WHERE PaymentPlanAccountID IN (SELECT PaymentPlanAccountID FROM INSERTED) 
END 

