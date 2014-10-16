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

/****** Object:  Trigger [dbo].[QuestionnaireQuestionnaireQuestionLink_Update_UpdatedDate]    Script Date: 10/4/2014 12:22:24 PM ******/

CREATE TRIGGER [dbo].[QuestionnaireQuestionnaireQuestionLink_Update_UpdatedDate]
ON [dbo].[QuestionnaireQuestionnaireQuestionLink]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.QuestionnaireQuestionnaireQuestionLink SET UpdatedDate=GETUTCDATE() 
        WHERE QuestionnaireQuestionnaireQuestionLinkID IN (SELECT QuestionnaireQuestionnaireQuestionLinkID FROM INSERTED) 
END 


GO



