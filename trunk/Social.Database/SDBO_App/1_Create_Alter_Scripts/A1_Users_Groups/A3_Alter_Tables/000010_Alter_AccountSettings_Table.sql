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

ALTER TABLE [dbo].[AccountSettings]  WITH CHECK ADD  CONSTRAINT [FK_AccountSettings_AccountSettingsTypeID] FOREIGN KEY([AccountSettingsTypeID])
REFERENCES [dbo].[AccountSettingsType] ([AccountSettingsTypeID])
GO

ALTER TABLE [dbo].[AccountSettings] CHECK CONSTRAINT [FK_AccountSettings_AccountSettingsTypeID]
GO
