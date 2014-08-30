/*************************************************************
** File:    000010_Alter_AccountSettings_Table.sql
** Name:	
** Desc:	
**			Foreign key constraints for [dbo].[AccountSettings]
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

ALTER TABLE [dbo].[AccountSettings]  ADD  CONSTRAINT [FK_AccountSettings_AccountSettingsTypeID] FOREIGN KEY([AccountSettingsTypeID])
REFERENCES [dbo].[AccountSettingsType] ([AccountSettingsTypeID])
GO

ALTER TABLE [dbo].[AccountSettings] CHECK CONSTRAINT [FK_AccountSettings_AccountSettingsTypeID]
GO
