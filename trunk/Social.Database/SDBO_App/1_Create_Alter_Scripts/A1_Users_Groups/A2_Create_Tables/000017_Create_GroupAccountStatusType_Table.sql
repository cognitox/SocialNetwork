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

/****** Object:  Table [dbo].[GroupAccountStatusType]    Script Date: 8/29/2014 10:58:04 PM ******/

CREATE TABLE [dbo].[GroupAccountStatusType](
	[GroupAccountStatusTypeID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_GroupAccountStatusType_GroupAccountStatusTypeID]  DEFAULT (newsequentialid()),
	[Type] [varchar](300) NULL,
	[CreatedDate] [datetime] NULL DEFAULT (getdate()),
	[UpdatedDate] [datetime] NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[GroupAccountStatusTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
