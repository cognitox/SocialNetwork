/*************************************************************
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

/****** Object:  Table [dbo].[GroupAccountConfiguration]    Script Date: 8/29/2014 10:58:34 PM ******/

CREATE TABLE [dbo].[GroupAccountConfiguration](
	[GroupAccountConfigurationID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_GroupAccountConfiguration_GroupAccountConfigurationID]  DEFAULT (newsequentialid()),
	[Section] [varchar](300) NOT NULL,
	[Name] [varchar](300) NOT NULL,
	[Value] [varchar](500) NOT NULL,
	[CreatedDate] [datetime] NULL DEFAULT (getdate()),
	[UpdatedDate] [datetime] NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[GroupAccountConfigurationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

