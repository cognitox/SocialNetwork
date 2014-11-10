/*************************************************************
** File:    000007_Create_AccountMetaData_Table.sql
** Name:	[dbo].[AccountMetaData]
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

/****** Object:  Table [dbo].[AccountMetaData]    Script Date: 8/29/2014 10:54:40 PM ******/

CREATE TABLE [dbo].[AccountMetaData](
	[AccountMetaDataID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_AccountMetaDataID]  DEFAULT (newsequentialid()),
	[AccountID] [uniqueidentifier] NOT NULL,
	[AccountStatusTypeID] [uniqueidentifier] NOT NULL,
	
	[ProfileImage] [varchar](max) NULL,
	[FirstName] [varchar](max) NULL,
	[LastName] [varchar](max) NULL,
	[Headline] [varchar](max) NULL,
	[LinkedInID] [varchar](max) NULL,

	[CreatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	[UpdatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	[IsDeleted] BIT NOT NULL DEFAULT 0,
PRIMARY KEY CLUSTERED 
(
	[AccountMetaDataID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


