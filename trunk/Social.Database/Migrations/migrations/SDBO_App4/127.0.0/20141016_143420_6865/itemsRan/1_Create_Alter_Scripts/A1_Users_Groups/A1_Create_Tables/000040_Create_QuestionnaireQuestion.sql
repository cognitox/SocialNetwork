/*************************************************************
** File:    000040_Create_QuestionnaireQuestion.sql
** Name:	[dbo].[QuestionnaireQuestion]
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

/****** Object:  Table [dbo].[QuestionnaireQuestion]    Script Date: 10/4/2014 12:02:25 PM ******/

CREATE TABLE [dbo].[QuestionnaireQuestion](
	[QuestionnaireQuestionID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_QuestionnaireQuestion_QuestionnaireQuestionID]  DEFAULT (newsequentialid()),
	[QuestionnaireQuestionTypeID] [uniqueidentifier] NOT NULL,
	[AccountID] [uniqueidentifier] NOT NULL,
	[GroupAccountID] [uniqueidentifier] NOT NULL,
	[CommitmentGroupID] [uniqueidentifier] NOT NULL,
	[QuestionnaireQuestionAnswerTypeID] [uniqueidentifier] NOT NULL,
	[Name] [varchar](max) NOT NULL,
	[CreatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	[UpdatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	[IsDeleted] BIT NOT NULL DEFAULT 0,
PRIMARY KEY CLUSTERED 
(
	[QuestionnaireQuestionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

