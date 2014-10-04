/*************************************************************
** File:    000003_Update_UpdatedDate_PaymentPlanAccountFee_Table.sql
** Name:	[dbo].[PaymentPlanAccountFee_Update_UpdatedDate]
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

/****** Object:  Trigger [dbo].[PaymentPlanAccountFee_Update_UpdatedDate]    Script Date: 8/29/2014 11:51:09 PM ******/

CREATE TRIGGER [dbo].[PaymentPlanAccountFee_Update_UpdatedDate]
ON [dbo].[PaymentPlanAccountFee]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.PaymentPlanAccountFee SET UpdatedDate=GETDATE() 
        WHERE PaymentPlanAccountFeeID IN (SELECT PaymentPlanAccountFeeID FROM INSERTED) 
END 
