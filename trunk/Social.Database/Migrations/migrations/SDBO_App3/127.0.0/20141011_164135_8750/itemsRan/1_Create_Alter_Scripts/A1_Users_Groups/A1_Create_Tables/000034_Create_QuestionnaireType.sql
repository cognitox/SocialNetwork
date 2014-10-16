/*************************************************************
** File:    000034_Create_QuestionnaireType.sql
** Name:	[dbo].[QuestionnaireType]
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

/****** Object:  Table [dbo].[QuestionnaireType]    Script Date: 10/1/2014 9:46:11 PM ******/

CREATE TABLE [dbo].[QuestionnaireType](
	[QuestionnaireTypeID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_QuestionnaireType_QuestionnaireTypeID]  DEFAULT (newsequentialid()),
	[Type] [varchar](255) NULL,
	[CreatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	[UpdatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	[IsDeleted] BIT NOT NULL DEFAULT 0,
PRIMARY KEY CLUSTERED 
(
	[QuestionnaireTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
