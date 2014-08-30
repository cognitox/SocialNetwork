/*************************************************************
** File:    000008_Create_AccountConfiguration_Table.sql
** Name:	[dbo].[AccountConfiguration]
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

/****** Object:  Table [dbo].[AccountConfiguration]    Script Date: 8/29/2014 10:54:52 PM ******/

CREATE TABLE [dbo].[AccountConfiguration](
	[AccountConfigurationID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_AccountConfiguration_AccountConfigurationID]  DEFAULT (newsequentialid()),
	[Section] [varchar](300) NOT NULL,
	[Name] [varchar](300) NOT NULL,
	[Value] [varchar](500) NOT NULL,
	[CreatedDate] [datetime] NULL DEFAULT (getdate()),
	[UpdatedDate] [datetime] NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[AccountConfigurationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
