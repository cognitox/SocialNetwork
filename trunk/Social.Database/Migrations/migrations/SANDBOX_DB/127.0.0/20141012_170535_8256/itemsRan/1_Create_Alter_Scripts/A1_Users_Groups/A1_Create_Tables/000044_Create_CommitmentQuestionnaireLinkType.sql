/*************************************************************
** File:    000044_Create_CommitmentQuestionnaireLinkType.sql
** Name:	[dbo].[CommitmentQuestionnaireLinkType]
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

/****** Object:  Table [dbo].[CommitmentQuestionnaireLinkType]    Script Date: 10/4/2014 12:25:48 PM ******/

CREATE TABLE [dbo].[CommitmentQuestionnaireLinkType](
	[CommitmentQuestionnaireLinkTypeID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_CommitmentQuestionnaireType_CommitmentQuestionnaireTypeID]  DEFAULT (newsequentialid()),
	[Type] [varchar](255) NULL,
	[CreatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	[UpdatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	[IsDeleted] BIT NOT NULL DEFAULT 0,
PRIMARY KEY CLUSTERED 
(
	[CommitmentQuestionnaireLinkTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

