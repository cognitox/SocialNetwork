/*************************************************************
** File:    000013_Update_UpdatedDate_PaymentPlanGroupAccount_Table.sql
** Name:	[dbo].[PaymentPlanGroupAccount_Update_UpdatedDate]
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

/****** Object:  Trigger [dbo].[PaymentPlanGroupAccount_Update_UpdatedDate]    Script Date: 8/30/2014 12:02:10 AM ******/

CREATE TRIGGER [dbo].[PaymentPlanGroupAccount_Update_UpdatedDate]
ON [dbo].[PaymentPlanGroupAccount]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.PaymentPlanGroupAccount SET UpdatedDate=GETDATE() 
        WHERE PaymentPlanGroupAccountID IN (SELECT PaymentPlanGroupAccountID FROM INSERTED) 
END 
