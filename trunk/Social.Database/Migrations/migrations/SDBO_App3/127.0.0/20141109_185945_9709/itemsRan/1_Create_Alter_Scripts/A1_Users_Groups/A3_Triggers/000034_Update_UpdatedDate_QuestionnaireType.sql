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

/****** Object:  Trigger [dbo].[QuestionnaireType_Update_UpdatedDate]    Script Date: 10/1/2014 9:47:52 PM ******/

CREATE TRIGGER [dbo].[QuestionnaireType_Update_UpdatedDate]
ON [dbo].[QuestionnaireType]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.QuestionnaireType SET UpdatedDate=GETUTCDATE() 
        WHERE QuestionnaireTypeID IN (SELECT QuestionnaireTypeID FROM INSERTED) 
END 


GO
