/*************************************************************
** File:    000039_Create_AccountSettingsAccountSettingsMultichoiceAnswerLink.sql
** Name:	[dbo].[AccountSettingsAccountSettingsMultichoiceAnswerLink]
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

/****** Object:  Table [dbo].[AccountSettingsAccountSettingsMultichoiceAnswerLink]    Script Date: 10/4/2014 11:58:48 AM ******/

CREATE TABLE [dbo].[AccountSettingsAccountSettingsMultichoiceAnswerLink](
	[AccountSettingsAccountSettingsMultichoiceAnswerLinkID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_AccountSettingsAccountSettingsMultichoiceAnswerLink_AccountSettingsAccountSettingsMultichoiceAnswerLinkID]  DEFAULT (newsequentialid()),
	[AccountSettingsID] [uniqueidentifier] NOT NULL,
	[AccountSettingsMultichoiceAnswerID] [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	[UpdatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
PRIMARY KEY CLUSTERED 
(
	[AccountSettingsAccountSettingsMultichoiceAnswerLinkID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
