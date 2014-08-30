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

ALTER TABLE [dbo].[GroupAccountGroupAccountSettingsLink]  WITH CHECK ADD  CONSTRAINT [FK_GroupAccountGroupAccountSettingsLink_GroupAccountID] FOREIGN KEY([GroupAccountID])
REFERENCES [dbo].[GroupAccount] ([GroupAccountID])
GO

ALTER TABLE [dbo].[GroupAccountGroupAccountSettingsLink] CHECK CONSTRAINT [FK_GroupAccountGroupAccountSettingsLink_GroupAccountID]
GO

ALTER TABLE [dbo].[GroupAccountGroupAccountSettingsLink]  WITH CHECK ADD  CONSTRAINT [FK_GroupAccountGroupAccountSettingsLink_GroupAccountSettingsID] FOREIGN KEY([GroupAccountSettingsID])
REFERENCES [dbo].[GroupAccountSettings] ([GroupAccountSettingsID])
GO

ALTER TABLE [dbo].[GroupAccountGroupAccountSettingsLink] CHECK CONSTRAINT [FK_GroupAccountGroupAccountSettingsLink_GroupAccountSettingsID]
GO

ALTER TABLE [dbo].[GroupAccountGroupAccountSettingsLink]  WITH CHECK ADD  CONSTRAINT [FK_GroupAccountGroupAccountSettingsLink_GroupAccountSettingsTypeID] FOREIGN KEY([GroupAccountSettingsTypeID])
REFERENCES [dbo].[GroupAccountSettingsType] ([GroupAccountSettingsTypeID])
GO

ALTER TABLE [dbo].[GroupAccountGroupAccountSettingsLink] CHECK CONSTRAINT [FK_GroupAccountGroupAccountSettingsLink_GroupAccountSettingsTypeID]
GO

