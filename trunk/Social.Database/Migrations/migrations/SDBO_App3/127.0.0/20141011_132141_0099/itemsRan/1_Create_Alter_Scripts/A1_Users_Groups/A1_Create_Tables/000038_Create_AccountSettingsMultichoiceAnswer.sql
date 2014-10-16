/*************************************************************
** File:    000038_Create_AccountSettingsMultichoiceAnswer.sql
** Name:	[dbo].[AccountSettingsMultichoiceAnswer]
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

/****** Object:  Table [dbo].[AccountSettingsMultichoiceAnswer]    Script Date: 10/4/2014 11:55:20 AM ******/

CREATE TABLE [dbo].[AccountSettingsMultichoiceAnswer](
	[AccountSettingsMultichoiceAnswerID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_AccountSettingsMultichoiceAnswer_AccountSettingsMultichoiceAnswerID]  DEFAULT (newsequentialid()),
	[Answer] [varchar](max) NOT NULL,
	[Helptext] [varchar](max) NOT NULL,
	[CreatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	[UpdatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
PRIMARY KEY CLUSTERED 
(
	[AccountSettingsMultichoiceAnswerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
