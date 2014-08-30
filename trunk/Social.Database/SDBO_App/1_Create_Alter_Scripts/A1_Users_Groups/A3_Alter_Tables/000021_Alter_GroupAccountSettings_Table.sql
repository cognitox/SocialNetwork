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

GO

ALTER TABLE [dbo].[GroupAccountSettings]  WITH CHECK ADD  CONSTRAINT [FK_GroupAccountSettings_GroupAccountSettingsTypeID] FOREIGN KEY([GroupAccountSettingsTypeID])
REFERENCES [dbo].[GroupAccountSettingsType] ([GroupAccountSettingsTypeID])
GO

ALTER TABLE [dbo].[GroupAccountSettings] CHECK CONSTRAINT [FK_GroupAccountSettings_GroupAccountSettingsTypeID]
GO


