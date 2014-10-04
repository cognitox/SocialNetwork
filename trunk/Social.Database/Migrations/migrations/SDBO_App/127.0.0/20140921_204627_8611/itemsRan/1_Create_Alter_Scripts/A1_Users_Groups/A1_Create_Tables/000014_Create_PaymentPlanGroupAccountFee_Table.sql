/*************************************************************
** File:    000014_Create_PaymentPlanGroupAccountFee_Table.sql
** Name:	[dbo].[PaymentPlanGroupAccountFee]
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

/****** Object:  Table [dbo].[PaymentPlanGroupAccountFee]    Script Date: 8/29/2014 10:56:55 PM ******/

CREATE TABLE [dbo].[PaymentPlanGroupAccountFee](
	[PaymentPlanGroupAccountFeeID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_PaymentPlanGroupAccountFee_PaymentPlanGroupAccountFeeID]  DEFAULT (newsequentialid()),
	[PaymentPlanGroupAccountID] [uniqueidentifier] NOT NULL,
	[Section] [varchar](500) NULL,
	[Amount] [decimal](18, 0) NULL,
	[CreatedDate] [datetime] NOT NULL DEFAULT (getdate()),
	[UpdatedDate] [datetime] NOT NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[PaymentPlanGroupAccountFeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

