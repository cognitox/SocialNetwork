﻿/*************************************************************
** File:    00000
** Name:	
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

/****** Object:  Table [dbo].[PaymentPlanGroupAccountFee]    Script Date: 8/29/2014 10:56:55 PM ******/

CREATE TABLE [dbo].[PaymentPlanGroupAccountFee](
	[PaymentPlanGroupAccountFeeID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_PaymentPlanGroupAccountFee_PaymentPlanGroupAccountFeeID]  DEFAULT (newsequentialid()),
	[PaymentPlanGroupAccountID] [uniqueidentifier] NOT NULL,
	[Section] [varchar](500) NULL,
	[Amount] [decimal](18, 0) NULL,
	[CreatedDate] [datetime] NULL DEFAULT (getdate()),
	[UpdatedDate] [datetime] NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[PaymentPlanGroupAccountFeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

