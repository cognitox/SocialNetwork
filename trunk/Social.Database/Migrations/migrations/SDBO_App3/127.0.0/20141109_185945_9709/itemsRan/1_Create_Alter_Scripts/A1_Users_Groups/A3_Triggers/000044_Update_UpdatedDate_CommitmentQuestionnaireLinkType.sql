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

/****** Object:  Trigger [dbo].[CommitmentQuestionnaireLinkType_Update_UpdatedDate]    Script Date: 10/4/2014 12:26:44 PM ******/

CREATE TRIGGER [dbo].[CommitmentQuestionnaireLinkType_Update_UpdatedDate]
ON [dbo].[CommitmentQuestionnaireLinkType]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.CommitmentQuestionnaireLinkType SET UpdatedDate=GETUTCDATE() 
        WHERE CommitmentQuestionnaireLinkTypeID IN (SELECT CommitmentQuestionnaireLinkTypeID FROM INSERTED) 
END 


GO

