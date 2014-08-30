/*************************************************************
** File:    000023_Create_GroupAccountRole.sql
** Name:	[dbo].[GroupAccountRole]
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

/****** Object:  Table [dbo].[GroupAccountRole]    Script Date: 8/29/2014 10:59:56 PM ******/

CREATE TABLE [dbo].[GroupAccountRole](
	[GroupAccountRoleID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_GroupAccountRole_GroupAccountRoleID]  DEFAULT (newsequentialid()),
	[Role] [varchar](500) NULL,
	[CreatedDate] [datetime] NULL DEFAULT (getdate()),
	[UpdatedDate] [datetime] NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[GroupAccountRoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

