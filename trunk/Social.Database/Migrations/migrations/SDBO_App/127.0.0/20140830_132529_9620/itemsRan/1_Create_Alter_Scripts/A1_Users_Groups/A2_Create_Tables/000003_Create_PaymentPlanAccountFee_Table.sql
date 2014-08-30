/*************************************************************
** File:    000003_Create_PaymentPlanAccountFee_Table.sql
** Name:	[dbo].[PaymentPlanAccountFee]
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


/****** Object:  Table [dbo].[PaymentPlanAccountFee]    Script Date: 8/29/2014 11:02:30 PM ******/

CREATE TABLE [dbo].[PaymentPlanAccountFee](
	[PaymentPlanAccountFeeID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_PaymentPlanAccountFee_PaymentPlanAccountFeeID]  DEFAULT (newsequentialid()),
	[PaymentPlanAccountID] [uniqueidentifier] NOT NULL,
	[Section] [varchar](500) NULL,
	[Amount] [decimal](18, 0) NULL,
	[CreatedDate] [datetime] NULL DEFAULT (getdate()),
	[UpdatedDate] [datetime] NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[PaymentPlanAccountFeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



