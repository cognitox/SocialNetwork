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

/****** Object:  Trigger [dbo].[AccountSettingsAccountSettingsMultichoiceAnswerLink_Update_UpdatedDate]    Script Date: 10/4/2014 11:59:38 AM ******/

CREATE TRIGGER [dbo].[AccountSettingsAccountSettingsMultichoiceAnswerLink_Update_UpdatedDate]
ON [dbo].[AccountSettingsAccountSettingsMultichoiceAnswerLink]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.AccountSettingsAccountSettingsMultichoiceAnswerLink SET UpdatedDate=GETUTCDATE() 
        WHERE AccountSettingsAccountSettingsMultichoiceAnswerLinkID IN (SELECT AccountSettingsAccountSettingsMultichoiceAnswerLinkID FROM INSERTED) 
END 


GO
