/*************************************************************
** File:    000029_Create_CommitmentStatusType.sql
** Name:	[dbo].[CommitmentStatusType]
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

/****** Object:  Table [dbo].[CommitmentStatusType]    Script Date: 10/1/2014 8:59:25 PM ******/

CREATE TABLE [dbo].[CommitmentStatusType](
	[CommitmentStatusTypeID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_CommitmentStatusType_CommitmentStatusTypeID]  DEFAULT (newsequentialid()),
	[Type] [varchar](100) NOT NULL,
	[CreatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	[UpdatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	[IsDeleted] BIT NOT NULL DEFAULT 0,
PRIMARY KEY CLUSTERED 
(
	[CommitmentStatusTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
