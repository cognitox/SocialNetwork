/*************************************************************
** File:    000002_Create_PaymentPlanAccount_Table.sql
** Name:	[dbo].[PaymentPlanAccount]
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

/****** Object:  Table [dbo].[PaymentPlanAccount]    Script Date: 8/29/2014 11:11:47 PM ******/

USE {{DatabaseName}}
GO

CREATE TABLE [dbo].[PaymentPlanAccount](
	[PaymentPlanAccountID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_PaymentPlanAccount_PaymentPlanAccountID]  DEFAULT (newsequentialid()),
	[Name] [varchar](300) NOT NULL,
	[CreatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	[UpdatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	[IsDeleted] BIT NOT NULL DEFAULT 0,
PRIMARY KEY CLUSTERED 
(
	[PaymentPlanAccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]






