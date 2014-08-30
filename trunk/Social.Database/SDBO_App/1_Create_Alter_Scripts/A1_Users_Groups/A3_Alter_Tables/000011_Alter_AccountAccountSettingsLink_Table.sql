/*************************************************************
** File:    000011_Alter_AccountAccountSettingsLink_Table.sql
** Name:	
** Desc:	
**			Foreign key constraints for [dbo].[AccountAccountSettingsLink]
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

ALTER TABLE [dbo].[AccountAccountSettingsLink]  WITH CHECK ADD  CONSTRAINT [FK_AccountAccountSettingsLink_AccountID] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([AccountID])
GO

ALTER TABLE [dbo].[AccountAccountSettingsLink] CHECK CONSTRAINT [FK_AccountAccountSettingsLink_AccountID]
GO

ALTER TABLE [dbo].[AccountAccountSettingsLink]  WITH CHECK ADD  CONSTRAINT [FK_AccountAccountSettingsLink_AccountSettingsID] FOREIGN KEY([AccountSettingsID])
REFERENCES [dbo].[AccountSettings] ([AccountSettingsID])
GO

ALTER TABLE [dbo].[AccountAccountSettingsLink] CHECK CONSTRAINT [FK_AccountAccountSettingsLink_AccountSettingsID]
GO

ALTER TABLE [dbo].[AccountAccountSettingsLink]  WITH CHECK ADD  CONSTRAINT [FK_AccountAccountSettingsLink_AccountSettingsTypeID] FOREIGN KEY([AccountSettingsTypeID])
REFERENCES [dbo].[AccountSettingsType] ([AccountSettingsTypeID])
GO

ALTER TABLE [dbo].[AccountAccountSettingsLink] CHECK CONSTRAINT [FK_AccountAccountSettingsLink_AccountSettingsTypeID]
GO
