/*************************************************************
** File:    000027_Create_CommitmentType.sql
** Name:	[dbo].[CommitmentType]
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

/****** Object:  Table [dbo].[CommitmentType]    Script Date: 10/1/2014 8:20:11 PM ******/

CREATE TABLE [dbo].[CommitmentType](
	[CommitmentTypeID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_CommitmentType_CommitmentTypeID]  DEFAULT (newsequentialid()),
	[Type] [varchar](100) NULL,
	[IsActive] [bit] NULL,
	[CreatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	[UpdatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
PRIMARY KEY CLUSTERED 
(
	[CommitmentTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

