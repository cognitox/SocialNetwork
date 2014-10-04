/*
TODO:// Finish entering in all of the tables, and foriegn keys
TODO:// Finish creating all of the Revision logic on the database
TODO:// Finish add in a delete flag, and on deleted trigger for all tables in the database
TODO:// Finish converting all the times in the database to UTC Time,
TODO:// Standardize the database to have the same VARCHAR sizes for all type tables
TODO:// CREATE mock users and data scripts for the database
TODO:// Create stored procedures to get all of the data upfront...
			CreateUser
			Get commitments for user
			Permissions
			Offload Old data to data storage warehouse

TODO:// Create views, that contain user account snapshots and summaries
*/
USE SDBO_App;

--DROP TABLE dbo.[CommitmentGroupStatusType]
--DROP TABLE dbo.[CommitmentGroup]
--DROP TABLE dbo.[CommitmentType]
--DROP TABLE dbo.[CommitmentTypeSubType]
--DROP TABLE dbo.[CommitmentStatusType]
--DROP TABLE dbo.[Commitment]

--DROP TRIGGER [dbo].[CommitmentStatusType_Update_UpdatedDate]
--DROP TRIGGER [dbo].[CommitmentTypeSubType_Update_UpdatedDate]
--DROP TRIGGER [dbo].[CommitmentType_Update_UpdatedDate]
--DROP TRIGGER [dbo].[CommitmentGroup_Update_UpdatedDate]
--DROP TRIGGER [dbo].[CommitmentGroupStatusType_Update_UpdatedDate]
--DROP TRIGGER [dbo].[Commitment_Update_UpdatedDate]


/**********************/
-- Application Commitment Logic
/**********************/
use SDBO_App;

CREATE TABLE [dbo].[CommitmentGroupStatusType]
(
	CommitmentGroupStatusTypeID [uniqueidentifier] NOT NULL CONSTRAINT [DF_CommitmentGroupStatusType_CommitmentGroupStatusTypeID]  DEFAULT (newsequentialid()) primary key,
	[Type] VARCHAR(500) NOT NULL,
	
	[CreatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	[UpdatedDate] [datetime] NOT NULL DEFAULT (getutcdate())

)

/****** Object:  Trigger [dbo].[AccountRole_Update_UpdatedDate]    Script Date: 8/30/2014 12:01:13 AM ******/
GO
CREATE TRIGGER [dbo].[CommitmentGroupStatusType_Update_UpdatedDate]
ON [dbo].[CommitmentGroupStatusType]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.CommitmentGroupStatusType SET UpdatedDate=GETUTCDATE() 
        WHERE CommitmentGroupStatusTypeID IN (SELECT CommitmentGroupStatusTypeID FROM INSERTED) 
END 

GO

INSERT INTO [dbo].[CommitmentGroupStatusType] ([Type]) VALUES ('Open')
GO
INSERT INTO [dbo].[CommitmentGroupStatusType] ([Type]) VALUES ('Pending')
GO
INSERT INTO [dbo].[CommitmentGroupStatusType] ([Type]) VALUES ('Closed')
GO













--- Create Commitment Group

CREATE TABLE [dbo].[CommitmentGroup]
(
	CommitmentGroupID [uniqueidentifier] NOT NULL CONSTRAINT [DF_CommitmentGroup_CommitmentGroupID]  DEFAULT (newsequentialid()) primary key,
	CommitmentGroupStatusTypeID [uniqueidentifier] NOT NULL, -- total group status
	
	Title VARCHAR(MAX) NOT NULL,
	Details VARCHAR(MAX) NOT NULL,
	
	[CreatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	[UpdatedDate] [datetime] NOT NULL DEFAULT (getutcdate())

)


/****** Object:  Trigger [dbo].[AccountRole_Update_UpdatedDate]    Script Date: 8/30/2014 12:01:13 AM ******/
GO

CREATE TRIGGER [dbo].[CommitmentGroup_Update_UpdatedDate]
ON [dbo].[CommitmentGroup]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.CommitmentGroup SET UpdatedDate=GETUTCDATE() 
        WHERE CommitmentGroupID IN (SELECT CommitmentGroupID FROM INSERTED) 
END 

GO


ALTER TABLE [dbo].[CommitmentGroup]  WITH CHECK ADD  CONSTRAINT [FK_CommitmentGroup_CommitmentGroupStatusTypeID] FOREIGN KEY([CommitmentGroupStatusTypeID])
REFERENCES [dbo].[CommitmentGroupStatusType] ([CommitmentGroupStatusTypeID])
GO


INSERT INTO [dbo].[CommitmentGroup]
           ([CommitmentGroupStatusTypeID]
           ,[Title]
           ,[Details])
     VALUES
           ((SELECT CommitmentGroupStatusTypeID FROM [dbo].CommitmentGroupStatusType WHERE [Type] = 'Open')
           ,'MASTER COMMITMENT GROUP'
           ,'This is the commitment group that the default master commitment is apart of. All commitments are a child commitment of the MASTER COMMITMENT GROUP')
GO



--//TODO: ADD TO LOAD SCRIPT
INSERT INTO [dbo].[CommitmentGroup]
           ([CommitmentGroupStatusTypeID]
           ,[Title]
           ,[Details])
     VALUES
           ((SELECT CommitmentGroupStatusTypeID FROM [dbo].CommitmentGroupStatusType WHERE [Type] = 'Open')
           ,'Learning Python, Skill Builder Challange 1 (Basic)'
           ,'This skill builder challange will consist of learning the basics of programming. The concepts involved will consist of String handling and Manipulation, and learning general programming concepts')
GO





-- Create the commitment logic



CREATE TABLE [dbo].[CommitmentType]
(
	CommitmentTypeID [uniqueidentifier] NOT NULL CONSTRAINT [DF_CommitmentType_CommitmentTypeID]  DEFAULT (newsequentialid()) primary key,
	
	[Type] VARCHAR(100),
	[IsActive] bit,

	[CreatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	[UpdatedDate] [datetime] NOT NULL DEFAULT (getutcdate())

)


/****** Object:  Trigger [dbo].[AccountRole_Update_UpdatedDate]    Script Date: 8/30/2014 12:01:13 AM ******/
GO

CREATE TRIGGER [dbo].[CommitmentType_Update_UpdatedDate]
ON [dbo].[CommitmentType]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.CommitmentType SET UpdatedDate=GETUTCDATE() 
        WHERE CommitmentTypeID IN (SELECT CommitmentTypeID FROM INSERTED) 
END 

GO


USE [SDBO_App]
GO

INSERT INTO [dbo].[CommitmentType] ([Type],[IsActive]) VALUES ('MASTER COMMITMENT TYPE',1)
GO
INSERT INTO [dbo].[CommitmentType] ([Type],[IsActive]) VALUES ('Standard Commitment',1)
GO
INSERT INTO [dbo].[CommitmentType] ([Type],[IsActive]) VALUES ('1 to Many Group Commitment',1)
GO
INSERT INTO [dbo].[CommitmentType] ([Type],[IsActive]) VALUES ('Many to Many Commitment',1)
GO
INSERT INTO [dbo].[CommitmentType] ([Type],[IsActive]) VALUES ('Skill Builder Challange',1)
GO

-- Sub Types for each type

CREATE TABLE [dbo].[CommitmentTypeSubType]
(
	CommitmentTypeSubTypeID [uniqueidentifier] NOT NULL CONSTRAINT [DF_CommitmentTypeSubType_CommitmentTypeSubTypeID]  DEFAULT (newsequentialid()) primary key,
	CommitmentTypeID [uniqueidentifier] NOT NULL,
	[Type] VARCHAR(100) NOT NULL,

	[CreatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	[UpdatedDate] [datetime] NOT NULL DEFAULT (getutcdate())
)

GO 

CREATE TRIGGER [dbo].[CommitmentTypeSubType_Update_UpdatedDate]
ON [dbo].[CommitmentTypeSubType]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.CommitmentTypeSubType SET UpdatedDate=GETUTCDATE() 
        WHERE CommitmentTypeSubTypeID IN (SELECT CommitmentTypeSubTypeID FROM INSERTED) 
END 

GO


ALTER TABLE [dbo].[CommitmentTypeSubType]  WITH CHECK ADD  CONSTRAINT [FK_CommitmentTypeSubType_CommitmentTypeSubTypeID] FOREIGN KEY([CommitmentTypeSubTypeID])
REFERENCES [dbo].[CommitmentTypeSubType] ([CommitmentTypeSubTypeID])
GO



--'MASTER COMMITMENT TYPE'
INSERT INTO [dbo].[CommitmentTypeSubType] ([CommitmentTypeID],[Type]) 
	VALUES ((SELECT CommitmentTypeID FROM CommitmentType WHERE [Type] = 'MASTER COMMITMENT TYPE'), 'NONE')
GO

--'Standard Commitment'
INSERT INTO [dbo].[CommitmentTypeSubType] ([CommitmentTypeID],[Type]) 
	VALUES ((SELECT CommitmentTypeID FROM CommitmentType WHERE [Type] = 'Standard Commitment'), 'Administrator')
GO
INSERT INTO [dbo].[CommitmentTypeSubType] ([CommitmentTypeID],[Type]) 
	VALUES ((SELECT CommitmentTypeID FROM CommitmentType WHERE [Type] = 'Standard Commitment'), 'Moderator')
GO
INSERT INTO [dbo].[CommitmentTypeSubType] ([CommitmentTypeID],[Type]) 
	VALUES ((SELECT CommitmentTypeID FROM CommitmentType WHERE [Type] = 'Standard Commitment'), 'Commiter')
GO
INSERT INTO [dbo].[CommitmentTypeSubType] ([CommitmentTypeID],[Type]) 
	VALUES ((SELECT CommitmentTypeID FROM CommitmentType WHERE [Type] = 'Standard Commitment'), 'Commitee')
GO

--'1 to Many Group Commitment'
INSERT INTO [dbo].[CommitmentTypeSubType] ([CommitmentTypeID],[Type]) 
	VALUES ((SELECT CommitmentTypeID FROM CommitmentType WHERE [Type] = '1 to Many Group Commitment'), 'Administrator')
GO
INSERT INTO [dbo].[CommitmentTypeSubType] ([CommitmentTypeID],[Type]) 
	VALUES ((SELECT CommitmentTypeID FROM CommitmentType WHERE [Type] = '1 to Many Group Commitment'), 'Moderator')
GO
INSERT INTO [dbo].[CommitmentTypeSubType] ([CommitmentTypeID],[Type]) 
	VALUES ((SELECT CommitmentTypeID FROM CommitmentType WHERE [Type] = '1 to Many Group Commitment'), 'Commiter')
GO
INSERT INTO [dbo].[CommitmentTypeSubType] ([CommitmentTypeID],[Type]) 
	VALUES ((SELECT CommitmentTypeID FROM CommitmentType WHERE [Type] = '1 to Many Group Commitment'), 'Commitee')
GO


--'Many to Many Commitment'
INSERT INTO [dbo].[CommitmentTypeSubType] ([CommitmentTypeID],[Type]) 
	VALUES ((SELECT CommitmentTypeID FROM CommitmentType WHERE [Type] = 'Many to Many Commitment'), 'Administrator')
GO
INSERT INTO [dbo].[CommitmentTypeSubType] ([CommitmentTypeID],[Type]) 
	VALUES ((SELECT CommitmentTypeID FROM CommitmentType WHERE [Type] = 'Many to Many Commitment'), 'Moderator')
GO
INSERT INTO [dbo].[CommitmentTypeSubType] ([CommitmentTypeID],[Type]) 
	VALUES ((SELECT CommitmentTypeID FROM CommitmentType WHERE [Type] = 'Many to Many Commitment'), 'Commiter Group')
GO
INSERT INTO [dbo].[CommitmentTypeSubType] ([CommitmentTypeID],[Type]) 
	VALUES ((SELECT CommitmentTypeID FROM CommitmentType WHERE [Type] = 'Many to Many Commitment'), 'Commitee Group')
GO

--'Skill Builder Challange'
INSERT INTO [dbo].[CommitmentTypeSubType] ([CommitmentTypeID],[Type]) 
	VALUES ((SELECT CommitmentTypeID FROM CommitmentType WHERE [Type] = 'Skill Builder Challange'), 'Administrator')
GO
INSERT INTO [dbo].[CommitmentTypeSubType] ([CommitmentTypeID],[Type]) 
	VALUES ((SELECT CommitmentTypeID FROM CommitmentType WHERE [Type] = 'Skill Builder Challange'), 'Moderator')
GO
INSERT INTO [dbo].[CommitmentTypeSubType] ([CommitmentTypeID],[Type]) 
	VALUES ((SELECT CommitmentTypeID FROM CommitmentType WHERE [Type] = 'Skill Builder Challange'), 'Mentor')
GO
INSERT INTO [dbo].[CommitmentTypeSubType] ([CommitmentTypeID],[Type]) 
	VALUES ((SELECT CommitmentTypeID FROM CommitmentType WHERE [Type] = 'Skill Builder Challange'), 'Mentee')
GO





CREATE TABLE [dbo].[CommitmentStatusType]
(
	CommitmentStatusTypeID [uniqueidentifier] NOT NULL CONSTRAINT [DF_CommitmentStatusType_CommitmentStatusTypeID]  DEFAULT (newsequentialid()) primary key,
	[Type] VARCHAR(100) NOT NULL,
	
	[CreatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	[UpdatedDate] [datetime] NOT NULL DEFAULT (getutcdate())

)


/****** Object:  Trigger [dbo].[AccountRole_Update_UpdatedDate]    Script Date: 8/30/2014 12:01:13 AM ******/
GO
CREATE TRIGGER [dbo].[CommitmentStatusType_Update_UpdatedDate]
ON [dbo].[CommitmentStatusType]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.CommitmentStatusType SET UpdatedDate=GETUTCDATE() 
        WHERE CommitmentStatusTypeID IN (SELECT CommitmentStatusTypeID FROM INSERTED) 
END 

GO
INSERT INTO [dbo].[CommitmentStatusType] ([Type]) VALUES ('Open')
GO
INSERT INTO [dbo].[CommitmentStatusType] ([Type]) VALUES ('Pending')
GO
INSERT INTO [dbo].[CommitmentStatusType] ([Type]) VALUES ('Closed')
GO


-- Open
-- Pending
-- Closed







CREATE TABLE [dbo].[Commitment]
( 
	CommitmentID [uniqueidentifier] NOT NULL CONSTRAINT [DF_Commitment_CommitmentID]  DEFAULT (newsequentialid()) primary key,
	CommitmentGroupID [uniqueidentifier] NOT NULL,
	ParentCommitmentID [uniqueidentifier] NOT NULL DEFAULT cast(cast(0 as binary) as uniqueidentifier), -- Head Node has a parent of 0
	CommitmentTypeID [uniqueidentifier] NOT NULL,
	CommitmentStatusTypeID [uniqueidentifier] NOT NULL, -- individual status of commitments
	CommitmentTypeSubTypeID [uniqueidentifier] NOT NULL, -- sub type of commitment, milestone or ....
	
	AccountID [uniqueidentifier] NOT NULL, -- person who last modified or revised the commitment

	Title VARCHAR(500) NOT NULL,
	Name VARCHAR(500)  NOT NULL,
	Details VARCHAR(MAX),

	StartDateTime DATETIME NOT NULL,
	EndDateTime DATETIME NOT NULL,
	
	RevisionNumber INT NOT NULL, 

	[CreatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	[UpdatedDate] [datetime] NOT NULL DEFAULT (getutcdate())

)
-- add in a instead of update trigger that makes the revision history

/****** Object:  Trigger [dbo].[AccountRole_Update_UpdatedDate]    Script Date: 8/30/2014 12:01:13 AM ******/
GO

/*
CREATE TRIGGER [dbo].[Commitment_Update_UpdatedDate_revision_number]
ON [dbo].[Commitment]
FOR UPDATE 
AS -- TODO://Need to test
BEGIN 
	INSERT INTO [dbo].[Commitment]
           ([CommitmentGroupID]
		   ,[ParentCommitmentID]
           ,[CommitmentTypeID]
           ,[CommitmentStatusTypeID]
           ,[CommitmentTypeSubTypeID]
           ,[AccountID]
           ,[Title]
           ,[Name]
           ,[Details]
           ,[RevisionNumber])
     VALUES
           ((SELECT [CommitmentGroupID] FROM INSERTED)
		   ,(SELECT [CommitmentID] FROM INSERTED)
           ,(SELECT [CommitmentTypeID] FROM INSERTED)
           ,(SELECT [CommitmentStatusTypeID] FROM INSERTED)
		   ,(SELECT [CommitmentTypeSubTypeID] FROM INSERTED)
           ,(SELECT [AccountID] FROM INSERTED)
           ,(SELECT [Title] FROM INSERTED)
           ,(SELECT [Name] FROM INSERTED)
           ,(SELECT [Details] FROM INSERTED)
           , (SELECT [RevisionNumber] + 1 FROM INSERTED))

		   -- need to handle the cases where the commitment is put in
		   -- TODO:// handle all of the inserted sub commitments... and how revisioning works

    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.Commitment SET UpdatedDate=GETUTCDATE() 
        WHERE CommitmentID IN (SELECT CommitmentID FROM INSERTED)
END 
*/
GO

ALTER TABLE [dbo].[Commitment]  WITH CHECK ADD  CONSTRAINT [FK_Commitment_CommitmentGroupID] FOREIGN KEY([CommitmentGroupID])
REFERENCES [dbo].[CommitmentGroup] ([CommitmentGroupID])
GO

-- need to insert the default head node before we add the foreign key constraint

INSERT INTO [dbo].[Commitment]
           ([CommitmentID]
           ,[CommitmentGroupID]
           ,[CommitmentTypeID]
           ,[CommitmentStatusTypeID]
           ,[CommitmentTypeSubTypeID]
           ,[AccountID]
           ,[Title]
           ,[Name]
           ,[Details]
           ,[StartDateTime]
           ,[EndDateTime]
           ,[RevisionNumber])
     VALUES
           (cast(cast(0 as binary) as uniqueidentifier)
           ,(SELECT CommitmentGroupID FROM dbo.CommitmentGroup WHERE Title = 'MASTER COMMITMENT GROUP')
           ,(SELECT CommitmentTypeID FROM dbo.CommitmentType WHERE [Type] = 'MASTER COMMITMENT TYPE')
           ,(SELECT CommitmentStatusTypeID FROM dbo.CommitmentStatusType WHERE [Type] = 'Open')
		   ,(SELECT CommitmentTypeSubTypeID FROM CommitmentTypeSubType WHERE [Type] = 'NONE')
           ,(SELECT AccountID FROM Account WHERE Email = 'master@relsocial.com')
           ,'MASTER COMMITMENT NODE'
           ,'MASTER COMMITMENT NODE'
           ,'MASTER COMMITMENT NODE'
           , GETUTCDATE() 
           , GETUTCDATE() 
           , 0)
GO

ALTER TABLE [dbo].[Commitment] WITH CHECK ADD CONSTRAINT [FK_Commitment_CommitmentTypeID] FOREIGN KEY([CommitmentTypeID])
REFERENCES [dbo].[CommitmentType] ([CommitmentTypeID])
GO

ALTER TABLE [dbo].[Commitment]  WITH CHECK ADD  CONSTRAINT [FK_Commitment_CommitmentStatusTypeID] FOREIGN KEY([CommitmentStatusTypeID])
REFERENCES [dbo].[CommitmentStatusType] ([CommitmentStatusTypeID])
GO

ALTER TABLE [dbo].[Commitment] WITH CHECK ADD CONSTRAINT [FK_Commitment_CommitmentTypeSubTypeID] FOREIGN KEY([CommitmentTypeSubTypeID])
REFERENCES [dbo].[CommitmentTypeSubType] ([CommitmentTypeSubTypeID])
GO

ALTER TABLE [dbo].[Commitment] WITH CHECK ADD CONSTRAINT [FK_Commitment_AccountID] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([AccountID])
GO


-- add in commitment notes



CREATE TABLE [dbo].[AccountCommitmentLinkType]
(
	AccountCommitmentLinkTypeID [uniqueidentifier] NOT NULL CONSTRAINT [DF_AccountCommitmentLinkType_AccountCommitmentLinkTypeID]  DEFAULT (newsequentialid()) primary key,
	[Type] VARCHAR(200) NOT NULL,
	
	[CreatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	[UpdatedDate] [datetime] NOT NULL DEFAULT (getutcdate())

)



/****** Object:  Trigger [dbo].[AccountRole_Update_UpdatedDate]    Script Date: 8/30/2014 12:01:13 AM ******/
GO
CREATE TRIGGER [dbo].[AccountCommitmentLinkType_Update_UpdatedDate]
ON [dbo].[AccountCommitmentLinkType]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.AccountCommitmentLinkType SET UpdatedDate=GETUTCDATE() 
        WHERE AccountCommitmentLinkTypeID IN (SELECT AccountCommitmentLinkTypeID FROM INSERTED) 
END 

GO


USE [SDBO_App]
GO

INSERT INTO [dbo].[AccountCommitmentLinkType] ([Type]) VALUES ('Template')
GO

INSERT INTO [dbo].[AccountCommitmentLinkType] ([Type]) VALUES ('Active Commitment')
GO








-- leaving off point



-- table that links users to commitments
CREATE TABLE [dbo].[AccountCommitmentLink]
(
	AccountCommitmentLinkID [uniqueidentifier] NOT NULL CONSTRAINT [DF_AccountCommitmentLink_AccountCommitmentLinkID]  DEFAULT (newsequentialid()) primary key,
	CommitmentGroupID [uniqueidentifier] NOT NULL, -- easy select for all the commitments
	HeadNodeCommitmentID [uniqueidentifier] NOT NULL, -- head node commitment
	GroupAccountID [uniqueidentifier] NOT NULL,
	AccountID [uniqueidentifier] NOT NULL,
	CommitmentTypeID [uniqueidentifier] NOT NULL,
	CommitmentTypeSubTypeID [uniqueidentifier] NOT NULL,
	-- find all the open commitments
	AccountCommitmentLinkTypeID [uniqueidentifier] NOT NULL,
	
	[CreatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	[UpdatedDate] [datetime] NOT NULL DEFAULT (getutcdate())

)
GO

CREATE TRIGGER [dbo].[AccountCommitmentLink_Update_UpdatedDate]
ON [dbo].[AccountCommitmentLink]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.AccountCommitmentLink SET UpdatedDate=GETUTCDATE() 
        WHERE AccountCommitmentLinkID IN (SELECT AccountCommitmentLinkID FROM INSERTED) 
END 

GO


ALTER TABLE [dbo].[AccountCommitmentLink]  WITH CHECK ADD  CONSTRAINT [FK_AccountCommitmentLink_CommitmentGroupID] FOREIGN KEY([CommitmentGroupID])
REFERENCES [dbo].[CommitmentGroup] ([CommitmentGroupID])
GO

-- commitment ID , off name reference
ALTER TABLE [dbo].[AccountCommitmentLink]  WITH CHECK ADD  CONSTRAINT [FK_AccountCommitmentLink_HeadNodeCommitmentID] FOREIGN KEY([HeadNodeCommitmentID])
REFERENCES [dbo].[Commitment] ([CommitmentID])
GO

ALTER TABLE [dbo].[AccountCommitmentLink]  WITH CHECK ADD  CONSTRAINT [FK_AccountCommitmentLink_GroupAccountID] FOREIGN KEY([GroupAccountID])
REFERENCES [dbo].[GroupAccount] ([GroupAccountID])
GO

ALTER TABLE [dbo].[AccountCommitmentLink]  WITH CHECK ADD  CONSTRAINT [FK_AccountCommitmentLink_AccountID] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([AccountID])
GO

ALTER TABLE [dbo].[AccountCommitmentLink]  WITH CHECK ADD  CONSTRAINT [FK_AccountCommitmentLink_CommitmentTypeID] FOREIGN KEY([CommitmentTypeID])
REFERENCES [dbo].[CommitmentType] ([CommitmentTypeID])
GO

ALTER TABLE [dbo].[AccountCommitmentLink]  WITH CHECK ADD  CONSTRAINT [FK_AccountCommitmentLink_CommitmentTypeSubTypeID] FOREIGN KEY([CommitmentTypeSubTypeID])
REFERENCES [dbo].[CommitmentTypeSubType] ([CommitmentTypeSubTypeID])
GO

ALTER TABLE [dbo].[AccountCommitmentLink]  WITH CHECK ADD  CONSTRAINT [FK_AccountCommitmentLink_AccountCommitmentLinkTypeID] FOREIGN KEY([AccountCommitmentLinkTypeID])
REFERENCES [dbo].[AccountCommitmentLinkType] ([AccountCommitmentLinkTypeID])
GO





/**Commitment Note Logic*/


CREATE TABLE [dbo].[CommitmentNoteType]
(
	CommitmentNoteTypeID [uniqueidentifier] NOT NULL CONSTRAINT [DF_CommitmentNoteType_CommitmentNoteTypeID]  DEFAULT (newsequentialid()) primary key,
	[Type] VARCHAR (255),
	
	[CreatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	[UpdatedDate] [datetime] NOT NULL DEFAULT (getutcdate())

)
GO

CREATE TRIGGER [dbo].[CommitmentNoteType_Update_UpdatedDate]
ON [dbo].[CommitmentNoteType]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.CommitmentNoteType SET UpdatedDate=GETUTCDATE() 
        WHERE CommitmentNoteTypeID IN (SELECT CommitmentNoteTypeID FROM INSERTED) 
END 

GO

USE [SDBO_App]
GO

INSERT INTO [dbo].[CommitmentNoteType] ([Type]) VALUES ('MASTER COMMITMENT NOTE TYPE')
GO
INSERT INTO [dbo].[CommitmentNoteType] ([Type]) VALUES ('Question')
GO
INSERT INTO [dbo].[CommitmentNoteType] ([Type]) VALUES ('Comment')
GO
INSERT INTO [dbo].[CommitmentNoteType] ([Type]) VALUES ('Template')
GO


CREATE TABLE [dbo].[CommitmentNote] -- allows for notes of notes, 
(
	
	CommitmentNoteID [uniqueidentifier] NOT NULL CONSTRAINT [DF_CommitmentNote_CommitmentNoteID]  DEFAULT (newsequentialid()) primary key,
	CommitmentGroupID [uniqueidentifier] NOT NULL,
	CommitmentID [uniqueidentifier] NOT NULL,
	CommitmentNoteTypeID [uniqueidentifier] NOT NULL,
	AccountID [uniqueidentifier] NOT NULL, -- person who submitted the commitment
	ParentCommitmentNoteID [uniqueidentifier] NOT NULL DEFAULT cast(cast(0 as binary) as uniqueidentifier), -- Head Node has a parent of 0

	Name VARCHAR(255) NOT NULL,
	Details VARCHAR(500) NOT NULL,
	
	RevisionNumber INT NOT NULL, 

	[CreatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	[UpdatedDate] [datetime] NOT NULL DEFAULT (getutcdate())
	
)

GO

CREATE TRIGGER [dbo].[CommitmentNote_Update_UpdatedDate]
ON [dbo].[CommitmentNote]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.CommitmentNote SET UpdatedDate=GETUTCDATE() 
        WHERE CommitmentNoteID IN (SELECT CommitmentNoteID FROM INSERTED) 
END 

GO

INSERT INTO [dbo].[CommitmentNote]
           ([CommitmentNoteID]
           ,[CommitmentGroupID]
           ,[CommitmentID]
           ,[CommitmentNoteTypeID]
           ,[AccountID]
           ,[ParentCommitmentNoteID]
           ,[Name]
           ,[Details]
           ,[RevisionNumber]
           ,[CreatedDate]
           ,[UpdatedDate])
     VALUES
           (cast(cast(0 as binary) as uniqueidentifier)
           ,(SELECT CommitmentGroupID FROM dbo.CommitmentGroup WHERE Title = 'MASTER COMMITMENT GROUP')
           ,(SELECT CommitmentID FROM Commitment WHERE Name = 'MASTER COMMITMENT NODE')
           ,(SELECT CommitmentNoteTypeID FROM dbo.CommitmentNoteType WHERE [Type] = 'MASTER COMMITMENT NOTE TYPE')
		   ,(SELECT AccountID FROM dbo.Account WHERE Email = 'master@relsocial.com')
           ,CAST(CAST(0 AS BINARY) AS uniqueidentifier)
           ,'MASTER COMMITMENT NOTE NODE'
           ,'MASTER COMMITMENT NOTE NODE'
           , 0
           ,GETUTCDATE()
           ,GETUTCDATE())
GO


ALTER TABLE [dbo].[CommitmentNote]  WITH CHECK ADD  CONSTRAINT [FK_CommitmentNote_CommitmentGroupID] FOREIGN KEY([CommitmentGroupID])
REFERENCES [dbo].[CommitmentGroup] ([CommitmentGroupID])
GO

ALTER TABLE [dbo].[CommitmentNote]  WITH CHECK ADD  CONSTRAINT [FK_CommitmentNote_CommitmentID] FOREIGN KEY([CommitmentID])
REFERENCES [dbo].[Commitment] ([CommitmentID])
GO

ALTER TABLE [dbo].[CommitmentNote]  WITH CHECK ADD  CONSTRAINT [FK_CommitmentNote_CommitmentNoteTypeID] FOREIGN KEY([CommitmentNoteTypeID])
REFERENCES [dbo].[CommitmentNoteType] ([CommitmentNoteTypeID])
GO

ALTER TABLE [dbo].[CommitmentNote]  WITH CHECK ADD  CONSTRAINT [FK_CommitmentNote_AccountID] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([AccountID])
GO

ALTER TABLE [dbo].[CommitmentNote]  WITH CHECK ADD  CONSTRAINT [FK_CommitmentNote_ParentCommitmentNoteID] FOREIGN KEY([ParentCommitmentNoteID])
REFERENCES [dbo].[CommitmentNote] ([CommitmentNoteID])
GO







CREATE TABLE [dbo].[QuestionnaireType]
(
	QuestionnaireTypeID [uniqueidentifier] NOT NULL CONSTRAINT [DF_QuestionnaireType_QuestionnaireTypeID]  DEFAULT (newsequentialid()) primary key,
	[Type] VARCHAR (255),
	
	[CreatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	[UpdatedDate] [datetime] NOT NULL DEFAULT (getutcdate())

)
GO

CREATE TRIGGER [dbo].[QuestionnaireType_Update_UpdatedDate]
ON [dbo].[QuestionnaireType]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.QuestionnaireType SET UpdatedDate=GETUTCDATE() 
        WHERE QuestionnaireTypeID IN (SELECT QuestionnaireTypeID FROM INSERTED) 
END 

GO

INSERT INTO [dbo].[QuestionnaireType] ([Type]) VALUES ('Commitment')
GO
INSERT INTO [dbo].[QuestionnaireType] ([Type]) VALUES ('Template')
GO




CREATE TABLE [dbo].[Questionnaire]
(
	
	QuestionnaireID [uniqueidentifier] NOT NULL CONSTRAINT [DF_Questionnaire_QuestionnaireID]  DEFAULT (newsequentialid()) primary key,

	QuestionnaireTypeID [uniqueidentifier] NOT NULL,

	Name VARCHAR(500) NOT NULL,

	[Details] VARCHAR(MAX) NOT NULL,

	SendDate [datetime] not null,

	ClosedDate [datetime] not null,

	[CreatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),

	[UpdatedDate] [datetime] NOT NULL DEFAULT (getutcdate())

)

GO

CREATE TRIGGER [dbo].[Questionnaire_Update_UpdatedDate]
ON [dbo].[Questionnaire]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.Questionnaire SET UpdatedDate=GETUTCDATE() 
        WHERE QuestionnaireID IN (SELECT QuestionnaireID FROM INSERTED) 
END 

GO

USE [SDBO_App]
GO

INSERT INTO [dbo].[Questionnaire]
           ([QuestionnaireID]
           ,[QuestionnaireTypeID]
           ,[Name]
           ,[Details]
           ,[SendDate]
           ,[ClosedDate])
     VALUES
           (cast(cast(0 as binary) as uniqueidentifier)
           ,(SELECT QuestionnaireTypeID FROM [dbo].[QuestionnaireType] WHERE [Type] = 'Commitment')
           ,'MASTER QUESTIONNAIRE NODE'
           ,'MASTER QUESTIONNAIRE NODE'
           ,GETUTCDATE()
           ,GETUTCDATE())
GO




ALTER TABLE [dbo].[Questionnaire]  WITH CHECK ADD  CONSTRAINT [FK_Questionnaire_AccountID] FOREIGN KEY([QuestionnaireTypeID])
REFERENCES [dbo].[QuestionnaireType] ([QuestionnaireTypeID])
GO












CREATE TABLE [dbo].[QuestionnaireQuestionType]
(
	QuestionnaireQuestionTypeID [uniqueidentifier] NOT NULL CONSTRAINT [DF_QuestionnaireQuestionType_QuestionnaireQuestionTypeID]  DEFAULT (newsequentialid()) primary key,
	[Type] VARCHAR (255),
	
	[CreatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	[UpdatedDate] [datetime] NOT NULL DEFAULT (getutcdate())

)
GO

CREATE TRIGGER [dbo].[QuestionnaireQuestionType_Update_UpdatedDate]
ON [dbo].[QuestionnaireQuestionType]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.QuestionnaireQuestionType SET UpdatedDate=GETUTCDATE() 
        WHERE QuestionnaireQuestionTypeID IN (SELECT QuestionnaireQuestionTypeID FROM INSERTED) 
END 

GO

INSERT INTO [dbo].[QuestionnaireQuestionType] ([Type]) VALUES ('Question')
GO
INSERT INTO [dbo].[QuestionnaireQuestionType] ([Type]) VALUES ('Template Question')
GO





CREATE TABLE [dbo].[QuestionnaireQuestionAnswerType]
(

	QuestionnaireQuestionAnswerTypeID [uniqueidentifier] NOT NULL CONSTRAINT [DF_QuestionnaireQuestionAnswerType_QuestionnaireQuestionAnswerTypeID]  DEFAULT (newsequentialid()) primary key,
	[Type] VARCHAR(255) NOT NULL,
	[CreatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	[UpdatedDate] [datetime] NOT NULL DEFAULT (getutcdate())

)

GO

CREATE TRIGGER [dbo].[QuestionnaireQuestionAnswerType_Update_UpdatedDate]
ON [dbo].[QuestionnaireQuestionAnswerType]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.QuestionnaireQuestionAnswerType SET UpdatedDate=GETUTCDATE() 
        WHERE QuestionnaireQuestionAnswerTypeID IN (SELECT QuestionnaireQuestionAnswerTypeID FROM INSERTED) 
END 

INSERT INTO [dbo].[QuestionnaireQuestionAnswerType] ([Type]) VALUES ('CheckBox')
INSERT INTO [dbo].[QuestionnaireQuestionAnswerType] ([Type]) VALUES ('Email')
INSERT INTO [dbo].[QuestionnaireQuestionAnswerType] ([Type]) VALUES ('Text')
INSERT INTO [dbo].[QuestionnaireQuestionAnswerType] ([Type]) VALUES ('TextArea')
INSERT INTO [dbo].[QuestionnaireQuestionAnswerType] ([Type]) VALUES ('Password')
INSERT INTO [dbo].[QuestionnaireQuestionAnswerType] ([Type]) VALUES ('Multichoice')
GO




-- Leaving off HERE....














































CREATE TABLE [dbo].[AccountSettingsMultichoiceAnswer]
(
	AccountSettingsMultichoiceAnswerID [uniqueidentifier] NOT NULL CONSTRAINT [DF_AccountSettingsMultichoiceAnswer_AccountSettingsMultichoiceAnswerID]  DEFAULT (newsequentialid()) primary key,
	Answer VARCHAR(MAX) NOT NULL,
	Helptext VARCHAR(MAX) NOT NULL,
	[CreatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	[UpdatedDate] [datetime] NOT NULL DEFAULT (getutcdate())
)

GO





CREATE TRIGGER [dbo].[AccountSettingsMultichoiceAnswer_Update_UpdatedDate]
ON [dbo].[AccountSettingsMultichoiceAnswer]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.AccountSettingsMultichoiceAnswer SET UpdatedDate=GETUTCDATE() 
        WHERE AccountSettingsMultichoiceAnswerID IN (SELECT AccountSettingsMultichoiceAnswerID FROM INSERTED) 
END 

GO








CREATE TABLE [dbo].[AccountSettingsAccountSettingsMultichoiceAnswerLink]
(
	AccountSettingsAccountSettingsMultichoiceAnswerLinkID [uniqueidentifier] NOT NULL CONSTRAINT [DF_AccountSettingsAccountSettingsMultichoiceAnswerLink_AccountSettingsAccountSettingsMultichoiceAnswerLinkID]  DEFAULT (newsequentialid()) primary key,
	AccountSettingsID [uniqueidentifier] NOT NULL,
	AccountSettingsMultichoiceAnswerID [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	[UpdatedDate] [datetime] NOT NULL DEFAULT (getutcdate())
)

GO

CREATE TRIGGER [dbo].[AccountSettingsAccountSettingsMultichoiceAnswerLink_Update_UpdatedDate]
ON [dbo].[AccountSettingsAccountSettingsMultichoiceAnswerLink]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.AccountSettingsAccountSettingsMultichoiceAnswerLink SET UpdatedDate=GETUTCDATE() 
        WHERE AccountSettingsAccountSettingsMultichoiceAnswerLinkID IN (SELECT AccountSettingsAccountSettingsMultichoiceAnswerLinkID FROM INSERTED) 
END 

GO

ALTER TABLE [dbo].[AccountSettingsAccountSettingsMultichoiceAnswerLink]  WITH CHECK ADD CONSTRAINT [FK_AccountSettingsAccountSettingsMultichoiceAnswerLink_QuestionnaireQuestionTypeID] FOREIGN KEY([AccountSettingsID])
REFERENCES [dbo].[AccountSettings] ([AccountSettingsID])
GO

ALTER TABLE [dbo].[AccountSettingsAccountSettingsMultichoiceAnswerLink]  WITH CHECK ADD CONSTRAINT [FK_AccountSettingsAccountSettingsMultichoiceAnswerLink_AccountSettingsMultichoiceAnswerID] FOREIGN KEY([AccountSettingsMultichoiceAnswerID])
REFERENCES [dbo].[AccountSettingsMultichoiceAnswer] ([AccountSettingsMultichoiceAnswerID])
GO

















CREATE TABLE [dbo].[QuestionnaireQuestion]
(
	QuestionnaireQuestionID [uniqueidentifier] NOT NULL CONSTRAINT [DF_QuestionnaireQuestion_QuestionnaireQuestionID]  DEFAULT (newsequentialid()) primary key,

	QuestionnaireQuestionTypeID [uniqueidentifier] NOT NULL,

	AccountID [uniqueidentifier] NOT NULL, -- person who created it....

	GroupAccountID [uniqueidentifier] NOT NULL, -- the group account it was created under, default everyone

	CommitmentGroupID [uniqueidentifier] NOT NULL,

	QuestionnaireQuestionAnswerTypeID [uniqueidentifier] NOT NULL,
	
	Name VARCHAR(MAX) NOT NULL,

	[CreatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),

	[UpdatedDate] [datetime] NOT NULL DEFAULT (getutcdate())

)

GO

CREATE TRIGGER [dbo].[QuestionnaireQuestion_Update_UpdatedDate]
ON [dbo].[QuestionnaireQuestion]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.QuestionnaireQuestion SET UpdatedDate=GETUTCDATE() 
        WHERE QuestionnaireQuestionID IN (SELECT QuestionnaireQuestionID FROM INSERTED) 
END 

GO

ALTER TABLE [dbo].[QuestionnaireQuestion]  WITH CHECK ADD  CONSTRAINT [FK_QuestionnaireQuestion_QuestionnaireQuestionTypeID] FOREIGN KEY([QuestionnaireQuestionTypeID])
REFERENCES [dbo].[QuestionnaireQuestionAnswerType] ([QuestionnaireQuestionAnswerTypeID])
GO

ALTER TABLE [dbo].[QuestionnaireQuestion]  WITH CHECK ADD  CONSTRAINT [FK_QuestionnaireQuestion_AccountID] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([AccountID])
GO

ALTER TABLE [dbo].[QuestionnaireQuestion]  WITH CHECK ADD  CONSTRAINT [FK_QuestionnaireQuestion_GroupAccountID] FOREIGN KEY([GroupAccountID])
REFERENCES [dbo].[GroupAccount] ([GroupAccountID])
GO

ALTER TABLE [dbo].[QuestionnaireQuestion]  WITH CHECK ADD  CONSTRAINT [FK_QuestionnaireQuestion_QuestionnaireQuestionAnswerTypeID] FOREIGN KEY([QuestionnaireQuestionAnswerTypeID])
REFERENCES [dbo].[QuestionnaireQuestionAnswerType] ([QuestionnaireQuestionAnswerTypeID])
GO

ALTER TABLE [dbo].[QuestionnaireQuestion]  WITH CHECK ADD  CONSTRAINT [FK_QuestionnaireQuestion_CommitmentGroupID] FOREIGN KEY([CommitmentGroupID])
REFERENCES [dbo].[CommitmentGroup] ([CommitmentGroupID])
GO

-- 













CREATE TABLE [dbo].[QuestionnaireQuestionMultichoiceAnswer]
(
	QuestionnaireQuestionMultichoiceAnswerID [uniqueidentifier] NOT NULL CONSTRAINT [DF_QuestionnaireQuestion_QuestionnaireQuestionMultichoiceAnswerID]  DEFAULT (newsequentialid()) primary key,
	AccountID [uniqueidentifier] NOT NULL, -- person who created it....
	GroupAccountID [uniqueidentifier] NOT NULL, -- the group account it was created under, default everyone
	CommitmentGroupID [uniqueidentifier] NOT NULL,
	Answer VARCHAR(MAX) NOT NULL,
	Helptext VARCHAR(MAX) NOT NULL,
	[CreatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	[UpdatedDate] [datetime] NOT NULL DEFAULT (getutcdate())
)

GO

CREATE TRIGGER [dbo].[QuestionnaireQuestionMultichoiceAnswer_Update_UpdatedDate]
ON [dbo].[QuestionnaireQuestionMultichoiceAnswer]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.QuestionnaireQuestionMultichoiceAnswer SET UpdatedDate=GETUTCDATE() 
        WHERE QuestionnaireQuestionMultichoiceAnswerID IN (SELECT QuestionnaireQuestionMultichoiceAnswerID FROM INSERTED) 
END 

GO


ALTER TABLE [dbo].[QuestionnaireQuestionMultichoiceAnswer]  WITH CHECK ADD  CONSTRAINT [FK_QuestionnaireQuestionMultichoiceAnswer_AccountID] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([AccountID])
GO

ALTER TABLE [dbo].[QuestionnaireQuestionMultichoiceAnswer]  WITH CHECK ADD  CONSTRAINT [FK_QuestionnaireQuestionMultichoiceAnswer_GroupAccountID] FOREIGN KEY([GroupAccountID])
REFERENCES [dbo].[GroupAccount] ([GroupAccountID])
GO

ALTER TABLE [dbo].[QuestionnaireQuestionMultichoiceAnswer]  WITH CHECK ADD  CONSTRAINT [FK_QuestionnaireQuestionMultichoiceAnswer_CommitmentGroupID] FOREIGN KEY([CommitmentGroupID])
REFERENCES [dbo].[CommitmentGroup] ([CommitmentGroupID])
GO














CREATE TABLE [dbo].[QuestionairreQuestionQuestionnaireQuestionMultichoiceAnswerLink]
(
	QuestionairreQuestionQuestionnaireQuestionMultichoiceAnswerLinkID [uniqueidentifier] NOT NULL CONSTRAINT [DF_QQQQMultichoiceAnswerLink_QQQQMultichoiceAnswerLinkID]  DEFAULT (newsequentialid()) primary key,
	QuestionnaireQuestionID [uniqueidentifier] NOT NULL,
	QuestionnaireQuestionMultichoiceAnswerID [uniqueidentifier] NOT NULL,
	AccountID [uniqueidentifier] NOT NULL, -- person who created it....
	GroupAccountID [uniqueidentifier] NOT NULL, -- the group account it was created under, default everyone
	CommitmentGroupID [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	[UpdatedDate] [datetime] NOT NULL DEFAULT (getutcdate())
)




GO

CREATE TRIGGER [dbo].[QuestionairreQuestionQuestionnaireQuestionMultichoiceAnswerLink_Update_UpdatedDate]
ON [dbo].[QuestionairreQuestionQuestionnaireQuestionMultichoiceAnswerLink]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.QuestionairreQuestionQuestionnaireQuestionMultichoiceAnswerLink SET UpdatedDate=GETUTCDATE() 
        WHERE QuestionairreQuestionQuestionnaireQuestionMultichoiceAnswerLinkID IN (SELECT QuestionairreQuestionQuestionnaireQuestionMultichoiceAnswerLinkID FROM INSERTED) 
END 

GO

ALTER TABLE [dbo].[QuestionairreQuestionQuestionnaireQuestionMultichoiceAnswerLink]  WITH CHECK ADD  CONSTRAINT [FK_QQQQMultichoiceAnswerLink_QQQQMultichoiceAnswerLinkID] FOREIGN KEY([QuestionnaireQuestionID])
REFERENCES [dbo].[QuestionnaireQuestion] ([QuestionnaireQuestionID])
GO

ALTER TABLE [dbo].[QuestionairreQuestionQuestionnaireQuestionMultichoiceAnswerLink]  WITH CHECK ADD  CONSTRAINT [FK_QQQQMultichoiceAnswerLink_QQMultichoiceAnswerID] FOREIGN KEY([QuestionnaireQuestionMultichoiceAnswerID])
REFERENCES [dbo].[QuestionnaireQuestionMultichoiceAnswer] ([QuestionnaireQuestionMultichoiceAnswerID])
GO


ALTER TABLE [dbo].[QuestionairreQuestionQuestionnaireQuestionMultichoiceAnswerLink]  WITH CHECK ADD  CONSTRAINT [FK_QQQQMultichoiceAnswerLink_AccountID] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([AccountID])
GO

ALTER TABLE [dbo].[QuestionairreQuestionQuestionnaireQuestionMultichoiceAnswerLink]  WITH CHECK ADD  CONSTRAINT [FK_QQQQMultichoiceAnswerLink_GroupAccountID] FOREIGN KEY([GroupAccountID])
REFERENCES [dbo].[GroupAccount] ([GroupAccountID])
GO

ALTER TABLE [dbo].[QuestionairreQuestionQuestionnaireQuestionMultichoiceAnswerLink]  WITH CHECK ADD  CONSTRAINT [FK_QuestionairreQuestionQuestionnaireQuestionMultichoiceAnswerLink_CommitmentGroupID] FOREIGN KEY([CommitmentGroupID])
REFERENCES [dbo].[CommitmentGroup] ([CommitmentGroupID])
GO













CREATE TABLE [dbo].[QuestionnaireQuestionnaireQuestionLink]
(
	QuestionnaireQuestionnaireQuestionLinkID [uniqueidentifier] NOT NULL CONSTRAINT [DF_QuestionnaireQuestionLink_QuestionnaireQuestionLinkID]  DEFAULT (newsequentialid()) primary key,
	
	CommitmentGroupID [uniqueidentifier] NOT NULL,
	
	QuestionnaireID [uniqueidentifier] NOT NULL,
	-- can be old revision numbers

	QuestionnaireQuestionID [uniqueidentifier] NOT NULL,
	
	-- all questions associated with the group
	
	-- associate with the question
	
	RevisonNumber INT NOT NULL, 

	SortOrder INT NOT NULL,
	
	[CreatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),

	[UpdatedDate] [datetime] NOT NULL DEFAULT (getutcdate())

)

GO

CREATE TRIGGER [dbo].[QuestionnaireQuestionnaireQuestionLink_Update_UpdatedDate]
ON [dbo].[QuestionnaireQuestionnaireQuestionLink]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.QuestionnaireQuestionnaireQuestionLink SET UpdatedDate=GETUTCDATE() 
        WHERE QuestionnaireQuestionnaireQuestionLinkID IN (SELECT QuestionnaireQuestionnaireQuestionLinkID FROM INSERTED) 
END 

GO

ALTER TABLE [dbo].[QuestionnaireQuestionnaireQuestionLink]  WITH CHECK ADD  CONSTRAINT [FK_QuestionnaireQuestionnaireQuestionLink_CommitmentGroupID] FOREIGN KEY([CommitmentGroupID])
REFERENCES [dbo].[CommitmentGroup] ([CommitmentGroupID])
GO

ALTER TABLE [dbo].[QuestionnaireQuestionnaireQuestionLink]  WITH CHECK ADD  CONSTRAINT [FK_QuestionnaireQuestionnaireQuestionLink_CommitmentQuestionnaireID] FOREIGN KEY([QuestionnaireID])
REFERENCES [dbo].[Questionnaire] ([QuestionnaireID])
GO

ALTER TABLE [dbo].[QuestionnaireQuestionnaireQuestionLink]  WITH CHECK ADD  CONSTRAINT [FK_QuestionnaireQuestionnaireQuestionLink_QuestionnaireQuestionID] FOREIGN KEY([QuestionnaireQuestionID])
REFERENCES [dbo].[QuestionnaireQuestion] ([QuestionnaireQuestionID])
GO












-- add in a instead of update trigger that makes the revision history

CREATE TABLE [dbo].[CommitmentQuestionnaireLinkType]
(

	CommitmentQuestionnaireLinkTypeID [uniqueidentifier] NOT NULL CONSTRAINT [DF_CommitmentQuestionnaireType_CommitmentQuestionnaireTypeID]  DEFAULT (newsequentialid()) primary key,
	[Type] VARCHAR (255),
	[CreatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	[UpdatedDate] [datetime] NOT NULL DEFAULT (getutcdate())

)

GO

CREATE TRIGGER [dbo].[CommitmentQuestionnaireLinkType_Update_UpdatedDate]
ON [dbo].[CommitmentQuestionnaireLinkType]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.CommitmentQuestionnaireLinkType SET UpdatedDate=GETUTCDATE() 
        WHERE CommitmentQuestionnaireLinkTypeID IN (SELECT CommitmentQuestionnaireLinkTypeID FROM INSERTED) 
END 

GO

-- need to handle who this is sending to ....
INSERT INTO [dbo].[CommitmentQuestionnaireLinkType] ([Type]) VALUES ('MASTER COMMITMENT QUESTIONNAIRE LINK TYPE NODE')
INSERT INTO [dbo].[CommitmentQuestionnaireLinkType] ([Type]) VALUES ('Entrance Questionnaire')
INSERT INTO [dbo].[CommitmentQuestionnaireLinkType] ([Type]) VALUES ('Commitment Questionnaire')
INSERT INTO [dbo].[CommitmentQuestionnaireLinkType] ([Type]) VALUES ('Exit Questionnaire')

GO
-- question 
-- comment
-- template




-- this needs to link multiple questions to a commitment

CREATE TABLE [dbo].[CommitmentQuestionnaireLink] -- allows for notes of notes, 
(	
	CommitmentQuestionnaireLinkID [uniqueidentifier] NOT NULL CONSTRAINT [DF_CommitmentQuestionnaireLink_CommitmentQuestionnaireLinkID]  DEFAULT (newsequentialid()) primary key,
	
	CommitmentQuestionnaireLinkTypeID [uniqueidentifier] NOT NULL,

	CommitmentGroupID [uniqueidentifier] NOT NULL,
	
	CommitmentID [uniqueidentifier] NOT NULL,
	
	AccountID [uniqueidentifier] NOT NULL, -- person who submitted the commitment
	
	SendToAccountID [uniqueidentifier] NOT NULL, -- person who it will be sent to

	QuestionnaireID [uniqueidentifier] NOT NULL DEFAULT cast(cast(0 as binary) as uniqueidentifier), -- Head Node has a parent of 0

	Name VARCHAR(255) NOT NULL,
	
	[CreatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	
	[UpdatedDate] [datetime] NOT NULL DEFAULT (getutcdate())
	
)



GO

CREATE TRIGGER [dbo].[CommitmentQuestionnaireLink_Update_UpdatedDate]
ON [dbo].[CommitmentQuestionnaireLink]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.CommitmentQuestionnaireLink SET UpdatedDate=GETUTCDATE() 
        WHERE CommitmentQuestionnaireLinkID IN (SELECT CommitmentQuestionnaireLinkID FROM INSERTED) 
END 


GO


INSERT INTO [dbo].[CommitmentQuestionnaireLink]
           ([CommitmentQuestionnaireLinkID]
		   ,[CommitmentQuestionnaireLinkTypeID]
		   ,[CommitmentGroupID]
           ,[CommitmentID]
           ,[AccountID]
		   ,[SendToAccountID]
           ,[QuestionnaireID]
           ,[Name])
     VALUES
           (cast(cast(0 as binary) as uniqueidentifier)
		   ,(SELECT CommitmentQuestionnaireLinkTypeID FROM dbo.CommitmentQuestionnaireLinkType WHERE [Type] = 'MASTER COMMITMENT QUESTIONNAIRE LINK TYPE NODE')
           ,(SELECT CommitmentGroupID FROM dbo.CommitmentGroup WHERE Title = 'MASTER COMMITMENT GROUP')
           ,(SELECT CommitmentID FROM Commitment WHERE Name = 'MASTER COMMITMENT NODE')
           ,(SELECT AccountID FROM dbo.Account WHERE Email = 'master@relsocial.com')
           ,CAST(CAST(0 AS BINARY) AS uniqueidentifier)
		   ,(SELECT QuestionnaireID FROM dbo.Questionnaire WHERE Name = 'MASTER QUESTIONNAIRE NODE')
           ,'MASTER COMMITMENT QUESTIONNAIRE LINK NODE')

GO


ALTER TABLE [dbo].[CommitmentQuestionnaireLink]  WITH CHECK ADD  CONSTRAINT [FK_CommitmentQuestionnaireLink_CommitmentGroupID] FOREIGN KEY([CommitmentGroupID])
REFERENCES [dbo].[CommitmentGroup] ([CommitmentGroupID])
GO

ALTER TABLE [dbo].[CommitmentQuestionnaireLink]  WITH CHECK ADD  CONSTRAINT [FK_CommitmentQuestionnaireLink_CommitmentID] FOREIGN KEY([CommitmentID])
REFERENCES [dbo].[Commitment] ([CommitmentID])
GO

ALTER TABLE [dbo].[CommitmentQuestionnaireLink]  WITH CHECK ADD  CONSTRAINT [FK_CommitmentQuestionnaireLink_AccountID] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([AccountID])
GO

ALTER TABLE [dbo].[CommitmentQuestionnaireLink]  WITH CHECK ADD  CONSTRAINT [FK_CommitmentQuestionnaireLink_QuestionnaireID] FOREIGN KEY([QuestionnaireID])
REFERENCES [dbo].[Questionnaire] ([QuestionnaireID])
GO

ALTER TABLE [dbo].[CommitmentQuestionnaireLink]  WITH CHECK ADD  CONSTRAINT [FK_CommitmentQuestionnaireLink_SendToAccountID] FOREIGN KEY([SendToAccountID])
REFERENCES [dbo].[Account] ([AccountID])
GO

ALTER TABLE [dbo].[CommitmentQuestionnaireLink]  WITH CHECK ADD  CONSTRAINT [FK_CommitmentQuestionnaireLink_CommitmentQuestionnaireLinkTypeID] FOREIGN KEY([CommitmentQuestionnaireLinkTypeID])
REFERENCES [dbo].[CommitmentQuestionnaireLinkType] ([CommitmentQuestionnaireLinkTypeID])
GO

















/**********************/
-- RC MONEY Portion
/**********************/


CREATE TABLE [dbo].[RCAccountBalance]
(
	RCAccountBalanceID [uniqueidentifier] NOT NULL CONSTRAINT [DF_RCAccountBalance_AccountRelationshipCapitalBalanceID]  DEFAULT (newsequentialid()) primary key,
	AccountID [uniqueidentifier] NOT NULL,
	Amount INT NOT NULL,
	[CreatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	[UpdatedDate] [datetime] NOT NULL DEFAULT (getutcdate())

)

GO

CREATE TRIGGER [dbo].[RCAccountBalance_Update_UpdatedDate]
ON [dbo].[RCAccountBalance]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.RCAccountBalance SET UpdatedDate=GETUTCDATE() 
        WHERE RCAccountBalanceID IN (SELECT RCAccountBalanceID FROM INSERTED) 
END 

GO

ALTER TABLE [dbo].[RCAccountBalance]  WITH CHECK ADD  CONSTRAINT [FK_RCAccountBalance_AccountID] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([AccountID])
GO




CREATE TABLE [dbo].[RCAccountTransaction]
(
	RCAccountTransactionID [uniqueidentifier] NOT NULL CONSTRAINT [DF_RCAccountTransaction_RelationshipCapitalID]  DEFAULT (newsequentialid()) primary key,
	ReceiverGroupAccountID [uniqueidentifier] NOT NULL,
	ReceiverAccountID [uniqueidentifier] NOT NULL,
	GrantorGroupAccountID [uniqueidentifier] NOT NULL,
	GrantorAccountID [uniqueidentifier] NOT NULL,
	CommitmentGroupID [uniqueidentifier] NOT NULL,
	CommitmentID [uniqueidentifier] NOT NULL,
	
	TransactionAmount INT NOT NULL,
	AccountTotal INT NOT NULL,

	[CreatedDate] [datetime] NOT NULL DEFAULT (getutcdate()),
	[UpdatedDate] [datetime] NOT NULL DEFAULT (getutcdate())

)

GO

CREATE TRIGGER [dbo].[RCAccountTransaction_Update_UpdatedDate]
ON [dbo].[RCAccountTransaction]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.RCAccountTransaction SET UpdatedDate=GETUTCDATE() 
        WHERE RCAccountTransactionID IN (SELECT RCAccountTransactionID FROM INSERTED) 
END 

GO

ALTER TABLE [dbo].[RCAccountTransaction]  WITH CHECK ADD  CONSTRAINT [FK_RCAccountTransaction_ReceiverGroupAccountID] FOREIGN KEY([ReceiverGroupAccountID])
REFERENCES [dbo].[GroupAccount] ([GroupAccountID])
GO

ALTER TABLE [dbo].[RCAccountTransaction]  WITH CHECK ADD  CONSTRAINT [FK_RCAccountTransaction_ReceiverAccountID] FOREIGN KEY([ReceiverAccountID])
REFERENCES [dbo].[Account] ([AccountID])
GO

ALTER TABLE [dbo].[RCAccountTransaction]  WITH CHECK ADD  CONSTRAINT [FK_RCAccountTransaction_GrantorGroupAccountID] FOREIGN KEY([GrantorGroupAccountID])
REFERENCES [dbo].[GroupAccount] ([GroupAccountID])
GO

ALTER TABLE [dbo].[RCAccountTransaction]  WITH CHECK ADD  CONSTRAINT [FK_RCAccountTransaction_GrantorAccountID] FOREIGN KEY([GrantorAccountID])
REFERENCES [dbo].[Account] ([AccountID])
GO

ALTER TABLE [dbo].[RCAccountTransaction]  WITH CHECK ADD  CONSTRAINT [FK_RCAccountTransaction_CommitmentGroupID] FOREIGN KEY([CommitmentGroupID])
REFERENCES [dbo].[CommitmentGroup] ([CommitmentGroupID])
GO

ALTER TABLE [dbo].[RCAccountTransaction]  WITH CHECK ADD  CONSTRAINT [FK_RCAccountTransaction_CommitmentID] FOREIGN KEY([CommitmentID])
REFERENCES [dbo].[Commitment] ([CommitmentID])
GO





select t.name, v.name from SDBO_App.sys.tables t
left join SDBO_App1.sys.tables v on v.name = t.name;

USE [SDBO_App1]
GO

ALTER TABLE [dbo].[Commitment] ADD  DEFAULT (CONVERT([uniqueidentifier],CONVERT([binary],(0)))) FOR [ParentCommitmentID]
GO



select * from [dbo].[CommitmentGroup]
select * from [dbo].[Commitment];


SELECT * FROM dbo.CommitmentGroup 
SELECT * FROM dbo.CommitmentNote
SELECT * FROM [dbo].[Questionnaire]
SELECT * FROM [dbo].[CommitmentQuestionnaireLink]

SELECT CommitmentGroupID FROM dbo.CommitmentGroup WHERE Title = 'MASTER COMMITMENT GROUP'


------









