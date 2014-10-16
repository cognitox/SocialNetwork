/*************************************************************
** File:    000031_Create_AccountCommitmentLinkType.sql
** Name:	[dbo].[AccountCommitmentLinkType]
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

/****** Object:  Table [dbo].[AccountCommitmentLinkType]    Script Date: 10/1/2014 9:10:08 PM ******/

CREATE TABLE [dbo].[AccountCommitmentLinkType](
	[AccountCommitmentLinkTypeID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_AccountCommitmentLinkType_AccountCommitmentLinkTypeID]  DEFAULT (newsequentialid()),
	[Type] [varchar](200) NOT NULL,
	[CreatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	[UpdatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
PRIMARY KEY CLUSTERED 
(
	[AccountCommitmentLinkTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
