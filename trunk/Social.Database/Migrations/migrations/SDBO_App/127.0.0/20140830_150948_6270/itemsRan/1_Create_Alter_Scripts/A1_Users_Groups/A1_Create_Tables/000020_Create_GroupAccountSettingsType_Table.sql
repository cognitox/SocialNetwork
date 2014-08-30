﻿/*************************************************************
** File:    000020_Create_GroupAccountSettingsType_Table.sql
** Name:	[dbo].[GroupAccountSettingsType]
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

/****** Object:  Table [dbo].[GroupAccountSettingsType]    Script Date: 8/29/2014 10:58:57 PM ******/

CREATE TABLE [dbo].[GroupAccountSettingsType](
	[GroupAccountSettingsTypeID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_GroupAccountSettingsType_GroupAccountSettingsTypeID]  DEFAULT (newsequentialid()),
	[Type] [varchar](300) NULL,
	[CreatedDate] [datetime] NULL DEFAULT (getdate()),
	[UpdatedDate] [datetime] NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[GroupAccountSettingsTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
