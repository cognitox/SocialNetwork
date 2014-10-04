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

/****** Object:  Trigger [dbo].[QuestionnaireQuestionType_Update_UpdatedDate]    Script Date: 10/1/2014 9:57:20 PM ******/

CREATE TRIGGER [dbo].[QuestionnaireQuestionType_Update_UpdatedDate]
ON [dbo].[QuestionnaireQuestionType]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.QuestionnaireQuestionType SET UpdatedDate=GETUTCDATE() 
        WHERE QuestionnaireQuestionTypeID IN (SELECT QuestionnaireQuestionTypeID FROM INSERTED) 
END 


GO

