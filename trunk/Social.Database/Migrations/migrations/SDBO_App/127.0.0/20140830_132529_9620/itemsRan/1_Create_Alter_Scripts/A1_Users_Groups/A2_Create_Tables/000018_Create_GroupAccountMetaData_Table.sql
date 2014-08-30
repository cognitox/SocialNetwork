/*************************************************************
** File:    000018_Create_GroupAccountMetaData_Table.sql
** Name:	[dbo].[GroupAccountMetaData]
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

/****** Object:  Table [dbo].[GroupAccountMetaData]    Script Date: 8/29/2014 10:58:22 PM ******/

CREATE TABLE [dbo].[GroupAccountMetaData](
	[GroupAccountMetaDataID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_GroupAccountMetaDataID]  DEFAULT (newsequentialid()),
	[GroupAccountID] [uniqueidentifier] NOT NULL,
	[GroupAccountStatusTypeID] [uniqueidentifier] NOT NULL,
	[CustomBranding] [varchar](max) NULL,
	[CreatedDate] [datetime] NULL DEFAULT (getdate()),
	[UpdatedDate] [datetime] NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[GroupAccountMetaDataID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

