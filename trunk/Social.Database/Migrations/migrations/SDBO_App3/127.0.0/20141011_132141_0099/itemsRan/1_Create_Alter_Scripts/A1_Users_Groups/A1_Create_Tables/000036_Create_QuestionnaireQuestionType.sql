/*************************************************************
** File:    000036_Create_QuestionnaireQuestionType.sql
** Name:	[dbo].[QuestionnaireQuestionType]
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

/****** Object:  Table [dbo].[QuestionnaireQuestionType]    Script Date: 10/1/2014 9:55:40 PM ******/

CREATE TABLE [dbo].[QuestionnaireQuestionType](
	[QuestionnaireQuestionTypeID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_QuestionnaireQuestionType_QuestionnaireQuestionTypeID]  DEFAULT (newsequentialid()),
	[Type] [varchar](255) NULL,
	[CreatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	[UpdatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
PRIMARY KEY CLUSTERED 
(
	[QuestionnaireQuestionTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

