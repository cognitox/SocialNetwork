/*************************************************************
** File:    00000
** Name:	
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

/****** Object:  Table [dbo].[AccountAccountSettingsLink]    Script Date: 8/29/2014 10:55:58 PM ******/

CREATE TABLE [dbo].[AccountAccountSettingsLink](
	[AccountAccountSettingsLinkID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_AccountAccountSettingsLink_AccountAccountSettingsLinkID]  DEFAULT (newsequentialid()),
	[AccountID] [uniqueidentifier] NOT NULL,
	[AccountSettingsID] [uniqueidentifier] NOT NULL,
	[AccountSettingsTypeID] [uniqueidentifier] NOT NULL,
	[Value] [varchar](500) NULL,
	[CreatedDate] [datetime] NULL DEFAULT (getdate()),
	[UpdatedDate] [datetime] NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[AccountAccountSettingsLinkID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

