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

/****** Object:  Table [dbo].[GroupAccountGroupAccountSettingsLink]    Script Date: 8/29/2014 10:59:35 PM ******/

CREATE TABLE [dbo].[GroupAccountGroupAccountSettingsLink](
	[GroupAccountGroupAccountSettingsLinkID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_GroupAccountGroupAccountSettingsLink_GroupAccountGroupAccountSettingsLinkID]  DEFAULT (newsequentialid()),
	[GroupAccountID] [uniqueidentifier] NOT NULL,
	[GroupAccountSettingsID] [uniqueidentifier] NOT NULL,
	[GroupAccountSettingsTypeID] [uniqueidentifier] NOT NULL,
	[Value] [varchar](500) NULL,
	[CreatedDate] [datetime] NULL DEFAULT (getdate()),
	[UpdatedDate] [datetime] NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[GroupAccountGroupAccountSettingsLinkID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


