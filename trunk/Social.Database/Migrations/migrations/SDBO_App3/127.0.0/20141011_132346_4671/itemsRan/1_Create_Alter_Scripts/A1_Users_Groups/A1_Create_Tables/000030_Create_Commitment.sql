/*************************************************************
** File:    000030_Create_Commitment.sql
** Name:	[dbo].[Commitment]
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

/****** Object:  Table [dbo].[Commitment]    Script Date: 10/1/2014 9:04:09 PM ******/

CREATE TABLE [dbo].[Commitment](
	[CommitmentID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Commitment_CommitmentID]  DEFAULT (newsequentialid()),
	[CommitmentGroupID] [uniqueidentifier] NOT NULL,
	[ParentCommitmentID] [uniqueidentifier] NOT NULL DEFAULT (CONVERT([uniqueidentifier],CONVERT([binary],(0)))),
	[CommitmentTypeID] [uniqueidentifier] NOT NULL,
	[CommitmentStatusTypeID] [uniqueidentifier] NOT NULL,
	[CommitmentTypeSubTypeID] [uniqueidentifier] NOT NULL,
	[AccountID] [uniqueidentifier] NOT NULL,
	[Title] [varchar](500) NOT NULL,
	[Name] [varchar](500) NOT NULL,
	[Details] [varchar](max) NULL,
	[StartDateTime] [datetime] NOT NULL,
	[EndDateTime] [datetime] NOT NULL,
	[RevisionNumber] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	[UpdatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
PRIMARY KEY CLUSTERED 
(
	[CommitmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
