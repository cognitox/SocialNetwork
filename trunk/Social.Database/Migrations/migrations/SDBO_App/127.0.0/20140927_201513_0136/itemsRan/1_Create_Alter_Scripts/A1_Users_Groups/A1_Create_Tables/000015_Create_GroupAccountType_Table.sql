/*************************************************************
** File:    000015_Create_GroupAccountType_Table.sql
** Name:	[dbo].[GroupAccountType]
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

/****** Object:  Table [dbo].[GroupAccountType]    Script Date: 8/29/2014 10:57:21 PM ******/

CREATE TABLE [dbo].[GroupAccountType](
	[GroupAccountTypeID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_GroupAccountType_GroupAccountTypeID]  DEFAULT (newsequentialid()),
	[Type] [varchar](300) NULL,
	[CreatedDate] [datetime] NOT NULL DEFAULT (getdate()),
	[UpdatedDate] [datetime] NOT NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[GroupAccountTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

