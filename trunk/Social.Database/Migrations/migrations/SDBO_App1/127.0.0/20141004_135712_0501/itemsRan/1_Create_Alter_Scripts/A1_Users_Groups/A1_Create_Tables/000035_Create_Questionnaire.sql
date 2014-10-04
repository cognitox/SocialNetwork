/*************************************************************
** File:    000026_Create_CommitmentGroup.sql
** Name:	[dbo].[CommitmentGroup]
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

/****** Object:  Table [dbo].[Questionnaire]    Script Date: 10/1/2014 9:50:48 PM ******/

CREATE TABLE [dbo].[Questionnaire](
	[QuestionnaireID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Questionnaire_QuestionnaireID]  DEFAULT (newsequentialid()),
	[QuestionnaireTypeID] [uniqueidentifier] NOT NULL,
	[Name] [varchar](500) NOT NULL,
	[Details] [varchar](max) NOT NULL,
	[SendDate] [datetime] NOT NULL,
	[ClosedDate] [datetime] NOT NULL,
	[CreatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	[UpdatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
PRIMARY KEY CLUSTERED 
(
	[QuestionnaireID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

