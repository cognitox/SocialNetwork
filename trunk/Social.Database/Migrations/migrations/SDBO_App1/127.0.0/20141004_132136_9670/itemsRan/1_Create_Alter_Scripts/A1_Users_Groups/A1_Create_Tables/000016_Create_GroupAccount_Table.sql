/*************************************************************
** File:    000016_Create_GroupAccount_Table.sql
** Name:	[dbo].[GroupAccount]
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

/****** Object:  Table [dbo].[GroupAccount]    Script Date: 8/29/2014 10:57:49 PM ******/

CREATE TABLE [dbo].[GroupAccount](
	[GroupAccountID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_GroupAccount_GroupAccountID]  DEFAULT (newsequentialid()),
	[GroupAccountTypeID] [uniqueidentifier] NOT NULL,
	[PaymentPlanGroupAccountID] [uniqueidentifier] NOT NULL,
	[Name] [varchar](500) NULL,
	[CreatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	[UpdatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
PRIMARY KEY CLUSTERED 
(
	[GroupAccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

