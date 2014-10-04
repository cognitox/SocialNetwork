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

/****** Object:  Table [dbo].[AccountCommitmentLink]    Script Date: 10/4/2014 1:36:59 PM ******/

CREATE TABLE [dbo].[AccountCommitmentLink]( 
	[AccountCommitmentLinkID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_AccountCommitmentLink_AccountCommitmentLinkID]  DEFAULT (newsequentialid()),
	[CommitmentGroupID] [uniqueidentifier] NOT NULL,
	[HeadNodeCommitmentID] [uniqueidentifier] NOT NULL,
	[GroupAccountID] [uniqueidentifier] NOT NULL,
	[AccountID] [uniqueidentifier] NOT NULL,
	[CommitmentTypeID] [uniqueidentifier] NOT NULL,
	[CommitmentTypeSubTypeID] [uniqueidentifier] NOT NULL,
	[AccountCommitmentLinkTypeID] [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	[UpdatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
PRIMARY KEY CLUSTERED 
(
	[AccountCommitmentLinkID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
