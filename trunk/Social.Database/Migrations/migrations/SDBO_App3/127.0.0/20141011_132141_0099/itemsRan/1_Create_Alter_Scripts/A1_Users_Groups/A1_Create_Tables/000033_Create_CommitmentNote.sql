/*************************************************************
** File:    000033_Create_CommitmentNote.sql
** Name:	[dbo].[CommitmentNote]
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

/****** Object:  Table [dbo].[CommitmentNote]    Script Date: 10/1/2014 9:41:52 PM ******/

CREATE TABLE [dbo].[CommitmentNote](
	[CommitmentNoteID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_CommitmentNote_CommitmentNoteID]  DEFAULT (newsequentialid()),
	[CommitmentGroupID] [uniqueidentifier] NOT NULL,
	[CommitmentID] [uniqueidentifier] NOT NULL,
	[CommitmentNoteTypeID] [uniqueidentifier] NOT NULL,
	[AccountID] [uniqueidentifier] NOT NULL,
	[ParentCommitmentNoteID] [uniqueidentifier] NOT NULL DEFAULT (CONVERT([uniqueidentifier],CONVERT([binary],(0)))),
	[Name] [varchar](255) NOT NULL,
	[Details] [varchar](500) NOT NULL,
	[RevisionNumber] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	[UpdatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
PRIMARY KEY CLUSTERED 
(
	[CommitmentNoteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

