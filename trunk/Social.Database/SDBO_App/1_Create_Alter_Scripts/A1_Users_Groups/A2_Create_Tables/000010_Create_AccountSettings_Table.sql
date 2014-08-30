/*************************************************************
** File:    000010_Create_AccountSettings_Table.sql
** Name:	[dbo].[AccountSettings]
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

/****** Object:  Table [dbo].[AccountSettings]    Script Date: 8/29/2014 10:55:07 PM ******/

CREATE TABLE [dbo].[AccountSettings](
	[AccountSettingsID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_AccountSettings_AccountSettingsID]  DEFAULT (newsequentialid()),
	[AccountSettingsTypeID] [uniqueidentifier] NOT NULL,
	[Section] [varchar](300) NOT NULL,
	[Name] [varchar](300) NOT NULL,
	[DefaultValue] [varchar](500) NOT NULL,
	[CreatedDate] [datetime] NULL DEFAULT (getdate()),
	[UpdatedDate] [datetime] NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[AccountSettingsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

