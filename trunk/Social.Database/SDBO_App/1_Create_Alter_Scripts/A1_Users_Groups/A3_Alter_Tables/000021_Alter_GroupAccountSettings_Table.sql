/*************************************************************
** File:    000021_Alter_GroupAccountSettings_Table.sql
** Name:	
** Desc:	
**			Foreign key constraints for [dbo].[GroupAccountSettings]
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


