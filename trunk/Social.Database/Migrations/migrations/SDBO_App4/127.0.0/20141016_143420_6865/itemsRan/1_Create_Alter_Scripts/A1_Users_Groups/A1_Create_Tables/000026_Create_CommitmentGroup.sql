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

/****** Object:  Table [dbo].[CommitmentGroup]    Script Date: 10/1/2014 8:12:58 PM ******/

CREATE TABLE [dbo].[CommitmentGroup](
	[CommitmentGroupID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_CommitmentGroup_CommitmentGroupID]  DEFAULT (newsequentialid()),
	[CommitmentGroupStatusTypeID] [uniqueidentifier] NOT NULL,
	[Title] [varchar](max) NOT NULL,
	[Details] [varchar](max) NOT NULL,
	[CreatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	[UpdatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	[IsDeleted] BIT NOT NULL DEFAULT 0,
PRIMARY KEY CLUSTERED 
(
	[CommitmentGroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


