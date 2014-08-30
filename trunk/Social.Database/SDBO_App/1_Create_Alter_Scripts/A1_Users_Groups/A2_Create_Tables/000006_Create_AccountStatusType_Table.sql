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

/****** Object:  Table [dbo].[AccountStatusType]    Script Date: 8/29/2014 10:54:27 PM ******/

CREATE TABLE [dbo].[AccountStatusType](
	[AccountStatusTypeID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_AccountStatusType_AccountStatusTypeID]  DEFAULT (newsequentialid()),
	[Type] [varchar](300) NULL,
	[CreatedDate] [datetime] NULL DEFAULT (getdate()),
	[UpdatedDate] [datetime] NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[AccountStatusTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
