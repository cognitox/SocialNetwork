/*************************************************************
** File:    000025_Create_CommitmentGroupStatusType.sql
** Name:	[dbo].[CommitmentGroupStatusType]
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

/****** Object:  Table [dbo].[CommitmentGroupStatusType]    Script Date: 10/1/2014 7:42:02 PM ******/

CREATE TABLE [dbo].[CommitmentGroupStatusType](
	[CommitmentGroupStatusTypeID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_CommitmentGroupStatusType_CommitmentGroupStatusTypeID]  DEFAULT (newsequentialid()),
	[Type] [varchar](500) NOT NULL,
	[CreatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	[UpdatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
PRIMARY KEY CLUSTERED 
(
	[CommitmentGroupStatusTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

