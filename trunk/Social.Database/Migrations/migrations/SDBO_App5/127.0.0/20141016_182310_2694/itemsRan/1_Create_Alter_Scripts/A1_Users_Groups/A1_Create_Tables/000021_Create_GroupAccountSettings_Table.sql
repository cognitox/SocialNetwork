/*************************************************************
** File:    000021_Create_GroupAccountSettings_Table.sql
** Name:	[dbo].[GroupAccountSettings]
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

/****** Object:  Table [dbo].[GroupAccountSettings]    Script Date: 8/29/2014 10:59:12 PM ******/

CREATE TABLE [dbo].[GroupAccountSettings](
	[GroupAccountSettingsID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_GroupAccountSettings_GroupAccountSettingsID]  DEFAULT (newsequentialid()),
	[GroupAccountSettingsTypeID] [uniqueidentifier] NOT NULL,
	[Section] [varchar](300) NOT NULL,
	[Name] [varchar](300) NOT NULL,
	[DefaultValue] [varchar](500) NOT NULL,
	[CreatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	[UpdatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	[IsDeleted] BIT NOT NULL DEFAULT 0,
PRIMARY KEY CLUSTERED 
(
	[GroupAccountSettingsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
