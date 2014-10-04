﻿/*************************************************************
** File:    000013_Create_PaymentPlanGroupAccount_Table.sql
** Name:	[dbo].[PaymentPlanGroupAccount]
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

/****** Object:  Table [dbo].[PaymentPlanGroupAccount]    Script Date: 8/29/2014 10:56:33 PM ******/

CREATE TABLE [dbo].[PaymentPlanGroupAccount](
	[PaymentPlanGroupAccountID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_PaymentPlanGroupAccount_PaymentPlanGroupAccountID]  DEFAULT (newsequentialid()),
	[Name] [varchar](300) NOT NULL,
	[CreatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	[UpdatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
PRIMARY KEY CLUSTERED 
(
	[PaymentPlanGroupAccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

