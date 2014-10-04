﻿/*************************************************************
** File:    000017_Create_GroupAccountStatusType_Table.sql
** Name:	[dbo].[GroupAccountStatusType]
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

/****** Object:  Table [dbo].[GroupAccountStatusType]    Script Date: 8/29/2014 10:58:04 PM ******/

CREATE TABLE [dbo].[GroupAccountStatusType](
	[GroupAccountStatusTypeID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_GroupAccountStatusType_GroupAccountStatusTypeID]  DEFAULT (newsequentialid()),
	[Type] [varchar](300) NULL,
	[CreatedDate] [datetime] NOT NULL DEFAULT (getdate()),
	[UpdatedDate] [datetime] NOT NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[GroupAccountStatusTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
