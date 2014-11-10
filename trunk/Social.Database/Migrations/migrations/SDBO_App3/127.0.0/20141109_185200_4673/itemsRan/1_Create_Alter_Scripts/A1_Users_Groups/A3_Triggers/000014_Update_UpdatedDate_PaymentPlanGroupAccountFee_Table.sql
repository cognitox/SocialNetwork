/*************************************************************
** File:    000014_Update_UpdatedDate_PaymentPlanGroupAccountFee_Table.sql
** Name:	[dbo].[PaymentPlanGroupAccountFee_Update_UpdatedDate]
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

/****** Object:  Trigger [dbo].[PaymentPlanGroupAccountFee_Update_UpdatedDate]    Script Date: 8/30/2014 12:02:49 AM ******/

CREATE TRIGGER [dbo].[PaymentPlanGroupAccountFee_Update_UpdatedDate]
ON [dbo].[PaymentPlanGroupAccountFee]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.PaymentPlanGroupAccountFee SET UpdatedDate=GETUTCDATE() 
        WHERE PaymentPlanGroupAccountFeeID IN (SELECT PaymentPlanGroupAccountFeeID FROM INSERTED) 
END 
