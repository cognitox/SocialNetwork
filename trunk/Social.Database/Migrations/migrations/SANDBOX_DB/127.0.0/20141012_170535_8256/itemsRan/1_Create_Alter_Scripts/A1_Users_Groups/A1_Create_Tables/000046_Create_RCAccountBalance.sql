/*************************************************************
** File:    000046_Create_RCAccountBalance.sql
** Name:	[dbo].[RCAccountBalance]
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

/****** Object:  Table [dbo].[RCAccountBalance]    Script Date: 10/4/2014 12:38:40 PM ******/

CREATE TABLE [dbo].[RCAccountBalance](
	[RCAccountBalanceID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_RCAccountBalance_RCAccountBalanceID]  DEFAULT (newsequentialid()),
	[AccountID] [uniqueidentifier] NOT NULL,
	[Amount] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	[UpdatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	[IsDeleted] BIT NOT NULL DEFAULT 0,
PRIMARY KEY CLUSTERED 
(
	[RCAccountBalanceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
