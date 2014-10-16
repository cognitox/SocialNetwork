/*************************************************************
** File:    000005_Create_Account_Table.sql
** Name:	[dbo].[Account]
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

/****** Object:  Table [dbo].[Account]    Script Date: 8/29/2014 10:54:03 PM ******/

CREATE TABLE [dbo].[Account](
	[AccountID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Account_AccountID]  DEFAULT (newsequentialid()),
	[AccountTypeID] [uniqueidentifier] NOT NULL,
	[PaymentPlanAccountID] [uniqueidentifier] NOT NULL,
	[Email] [varchar](500) NULL,
	[CreatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	[UpdatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	[IsDeleted] BIT NOT NULL DEFAULT 0,
PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


