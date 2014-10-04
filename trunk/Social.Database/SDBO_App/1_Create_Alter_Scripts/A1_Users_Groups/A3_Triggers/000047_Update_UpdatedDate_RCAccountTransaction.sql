/*************************************************************
** File:    000025_Update_UpdatedDate_CommitmentGroupStatusType.sql
** Name:	[dbo].[AccountGroupAccountLink_Update_UpdatedDate]
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

/****** Object:  Trigger [dbo].[RCAccountTransaction_Update_UpdatedDate]    Script Date: 10/4/2014 12:44:14 PM ******/

CREATE TRIGGER [dbo].[RCAccountTransaction_Update_UpdatedDate]
ON [dbo].[RCAccountTransaction]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.RCAccountTransaction SET UpdatedDate=GETUTCDATE() 
        WHERE RCAccountTransactionID IN (SELECT RCAccountTransactionID FROM INSERTED) 
END 


GO




