/*************************************************************
** File:    000025_Populate_CommitmentGroupStatusType.sql
** Name:	
** Desc:	User Account Payment Plans, Currently all user accounts are free
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

INSERT INTO [dbo].[CommitmentQuestionnaireLink]
           ([CommitmentQuestionnaireLinkID]
		   ,[CommitmentQuestionnaireLinkTypeID]
		   ,[CommitmentGroupID]
           ,[CommitmentID]
           ,[AccountID]
		   ,[SendToAccountID]
           ,[QuestionnaireID]
           ,[Name])
     VALUES
           (cast(cast(0 as binary) as uniqueidentifier)
		   ,(SELECT CommitmentQuestionnaireLinkTypeID FROM dbo.CommitmentQuestionnaireLinkType WHERE [Type] = 'MASTER COMMITMENT QUESTIONNAIRE LINK TYPE NODE')
           ,(SELECT CommitmentGroupID FROM dbo.CommitmentGroup WHERE Title = 'MASTER COMMITMENT GROUP')
           ,(SELECT CommitmentID FROM Commitment WHERE Name = 'MASTER COMMITMENT NODE')
           ,(SELECT AccountID FROM dbo.Account WHERE Email = 'master@relsocial.com')
           ,CAST(CAST(0 AS BINARY) AS uniqueidentifier)
		   ,(SELECT QuestionnaireID FROM dbo.Questionnaire WHERE Name = 'MASTER QUESTIONNAIRE NODE')
           ,'MASTER COMMITMENT QUESTIONNAIRE LINK NODE')

GO
