/*************************************************************
** File:    000045_Create_CommitmentQuestionnaireLink.sql
** Name:	[dbo].[CommitmentQuestionnaireLink]
** Desc:	
**
**
**
**
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

/****** Object:  Table [dbo].[CommitmentQuestionnaireLink]    Script Date: 10/4/2014 12:33:37 PM ******/

CREATE TABLE [dbo].[CommitmentQuestionnaireLink](
	[CommitmentQuestionnaireLinkID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_CommitmentQuestionnaireLink_CommitmentQuestionnaireLinkID]  DEFAULT (newsequentialid()),
	[CommitmentQuestionnaireLinkTypeID] [uniqueidentifier] NOT NULL,
	[CommitmentGroupID] [uniqueidentifier] NOT NULL,
	[CommitmentID] [uniqueidentifier] NOT NULL,
	[AccountID] [uniqueidentifier] NOT NULL,
	[SendToAccountID] [uniqueidentifier] NOT NULL,
	[QuestionnaireID] [uniqueidentifier] NOT NULL DEFAULT (CONVERT([uniqueidentifier],CONVERT([binary],(0)))),
	[Name] [varchar](255) NOT NULL,
	[CreatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	[UpdatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	[IsDeleted] BIT NOT NULL DEFAULT 0,
PRIMARY KEY CLUSTERED 
(
	[CommitmentQuestionnaireLinkID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
