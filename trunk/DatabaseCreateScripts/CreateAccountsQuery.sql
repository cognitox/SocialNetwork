GO
USE SDBO_App;
GO

/***************************************************************************************/
-- CREATE GROUP ACCOUNT PAYMENT PLANS
/***************************************************************************************/


USE [SDBO_App]
GO

/****** Object:  Table [dbo].[PaymentPlanAccount]    Script Date: 8/29/2014 5:34:20 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PaymentPlanAccount](
	[PaymentPlanAccountID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_PaymentPlanAccount_PaymentPlanAccountID]  DEFAULT (newsequentialid()),
	[Name] [varchar](300) NOT NULL,
	[CreatedDate] [datetime] NULL DEFAULT (getdate()),
	[UpdatedDate] [datetime] NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[PaymentPlanAccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO





/* 
Holds all of the group account payment plans
*/
CREATE TABLE dbo.[PaymentPlanAccount]
(
	PaymentPlanAccountID UNIQUEIDENTIFIER PRIMARY KEY,
	[Name] VARCHAR(300) NOT NULL,
	CreatedDate datetime DEFAULT(GETDATE()), 
	UpdatedDate datetime DEFAULT(GETDATE())
)

ALTER TABLE dbo.[PaymentPlanAccount]
    ADD CONSTRAINT DF_PaymentPlanAccount_PaymentPlanAccountID DEFAULT NEWSEQUENTIALID() FOR PaymentPlanAccountID

GO


--UPDATE TRIGGER

CREATE TRIGGER dbo.PaymentPlanAccount_Update_UpdatedDate
ON dbo.[PaymentPlanAccount]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.PaymentPlanAccount SET UpdatedDate=GETDATE() 
        WHERE PaymentPlanAccountID IN (SELECT PaymentPlanAccountID FROM INSERTED) 
END 
GO


/***************************************************************************************/
-- CREATE GROUP ACCOUNT PAYMENT PLANS FEES
/***************************************************************************************/

CREATE TABLE PaymentPlanAccountFee
(
	PaymentPlanAccountFeeID UNIQUEIDENTIFIER PRIMARY KEY,
	PaymentPlanAccountID UNIQUEIDENTIFIER NOT NULL,
	Section VARCHAR(500), -- holds the payment type options
	Amount DECIMAL,

	-- Updated Datetime
	CreatedDate datetime DEFAULT(GETDATE()), 
	UpdatedDate datetime DEFAULT(GETDATE())
)


ALTER TABLE dbo.[PaymentPlanAccountFee]
    ADD CONSTRAINT DF_PaymentPlanAccountFee_PaymentPlanAccountFeeID DEFAULT NEWSEQUENTIALID() FOR PaymentPlanAccountFeeID
	
GO

ALTER TABLE dbo.[PaymentPlanAccountFee]
	ADD CONSTRAINT FK_PaymentPlanAccountFee_PaymentPlanAccountID FOREIGN KEY (PaymentPlanAccountID) REFERENCES PaymentPlanAccount(PaymentPlanAccountID);
GO



--UPDATE TRIGGER

CREATE TRIGGER dbo.PaymentPlanAccountFee_Update_UpdatedDate
ON dbo.[PaymentPlanAccountFee]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.PaymentPlanAccountFee SET UpdatedDate=GETDATE() 
        WHERE PaymentPlanAccountFeeID IN (SELECT PaymentPlanAccountFeeID FROM INSERTED) 
END 
GO


/***************************************************************************************/
-- CREATE GRUOP ACCOUNT TYPES
/***************************************************************************************/

/* 
Holds the group account types
*/
CREATE TABLE dbo.[AccountType]
(
	AccountTypeID UNIQUEIDENTIFIER PRIMARY KEY,
	[Type] VARCHAR(300),

	-- Updated Datetime
	CreatedDate datetime DEFAULT(GETDATE()), 
	UpdatedDate datetime DEFAULT(GETDATE())
)
GO

ALTER TABLE dbo.[AccountType]
    ADD CONSTRAINT DF_AccountType_AccountTypeID DEFAULT NEWSEQUENTIALID() FOR AccountTypeID

GO


--UPDATE TRIGGER

CREATE TRIGGER dbo.AccountType_Update_UpdatedDate
ON dbo.[AccountType]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.AccountType SET UpdatedDate=GETDATE() 
        WHERE AccountTypeID IN (SELECT AccountTypeID FROM INSERTED) 
END 
GO



/***************************************************************************************/
-- CREATE GRUOP ACCOUNT TABLE
/***************************************************************************************/

/*
Holds the accountIDs and the account types
*/
CREATE TABLE dbo.[Account]
(
	AccountID UNIQUEIDENTIFIER PRIMARY KEY,
	AccountTypeID UNIQUEIDENTIFIER NOT NULL,
	PaymentPlanAccountID UNIQUEIDENTIFIER NOT NULL,
	Email VARCHAR(500),

	-- Updated Datetime
	CreatedDate datetime DEFAULT(GETDATE()), 
	UpdatedDate datetime DEFAULT(GETDATE())
)
GO
-- ADD PRIMARY KEY
ALTER TABLE dbo.[Account]
    ADD CONSTRAINT DF_Account_AccountID DEFAULT NEWSEQUENTIALID() FOR AccountID
GO

-- ADD FORIEGN KEY CONSTRAINT -> AccountTypeID
ALTER TABLE dbo.[Account]
	ADD CONSTRAINT FK_Account_AccountTypeID FOREIGN KEY (AccountTypeID) REFERENCES AccountType(AccountTypeID);
GO

-- ADD FORIEGN KEY CONSTRAINT -> AccountTypeID
ALTER TABLE dbo.[Account]
	ADD CONSTRAINT FK_Account_PaymentPlanAccountID FOREIGN KEY (PaymentPlanAccountID) REFERENCES PaymentPlanAccount(PaymentPlanAccountID);
GO


--UPDATE TRIGGER

CREATE TRIGGER dbo.Account_Update_UpdatedDate
ON dbo.[Account]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.Account SET UpdatedDate=GETDATE() 
        WHERE AccountID IN (SELECT AccountID FROM INSERTED) 
END 
GO


/***************************************************************************************/
-- CREATE Group Account Status Type ID
/***************************************************************************************/

/*
Holds the group account status types
*/
CREATE TABLE dbo.[AccountStatusType]
(
	AccountStatusTypeID UNIQUEIDENTIFIER PRIMARY KEY,
	[Type] VARCHAR(300),

	-- Updated Datetime
	CreatedDate datetime DEFAULT(GETDATE()), 
	UpdatedDate datetime DEFAULT(GETDATE())
)
GO
ALTER TABLE dbo.[AccountStatusType]
    ADD CONSTRAINT DF_AccountStatusType_AccountStatusTypeID DEFAULT NEWSEQUENTIALID() FOR AccountStatusTypeID

GO


--UPDATE TRIGGER

CREATE TRIGGER dbo.AccountStatusType_Update_UpdatedDate
ON dbo.[AccountStatusType]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.AccountStatusType SET UpdatedDate=GETDATE() 
        WHERE AccountStatusTypeID IN (SELECT AccountStatusTypeID FROM INSERTED) 
END 
GO



USE [SDBO_App]
GO

INSERT INTO [dbo].[AccountStatusType] ([Type]) VALUES ('Active')
INSERT INTO [dbo].[AccountStatusType] ([Type]) VALUES ('Pending')
INSERT INTO [dbo].[AccountStatusType] ([Type]) VALUES ('Disabled')

GO

/***************************************************************************************/
-- CREATE Group Account MetaData
/***************************************************************************************/

/*
Holds all of the group accounts meta data
*/
CREATE TABLE dbo.[AccountMetaData]
( 
	AccountMetaDataID UNIQUEIDENTIFIER PRIMARY KEY,
	AccountID UNIQUEIDENTIFIER NOT NULL,
	AccountStatusTypeID UNIQUEIDENTIFIER NOT NULL,

	-- add in the metadata of the account
	ProfileImage VARCHAR(MAX),

	-- Updated Datetime
	CreatedDate datetime DEFAULT(GETDATE()), 
	UpdatedDate datetime DEFAULT(GETDATE())
)

-- ADD PRIMARY KEY
ALTER TABLE dbo.[AccountMetaData]
    ADD CONSTRAINT DF_AccountMetaDataID DEFAULT NEWSEQUENTIALID() FOR AccountMetaDataID
GO

-- ADD FORIEGN KEY CONSTRAINT
ALTER TABLE dbo.[AccountMetaData]
	ADD CONSTRAINT FK_AccountMetaData_AccountID FOREIGN KEY (AccountID) REFERENCES Account(AccountID);
GO

-- GROUP ACCOUNT STATUS TYPE
ALTER TABLE dbo.[AccountMetaData]
	ADD CONSTRAINT FK_AccountMetaData_AccountStatusTypeID FOREIGN KEY (AccountStatusTypeID) REFERENCES AccountStatusType(AccountStatusTypeID);
GO



--UPDATE TRIGGER

CREATE TRIGGER dbo.AccountMetaData_Update_UpdatedDate
ON dbo.[AccountMetaData]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.AccountMetaData SET UpdatedDate=GETDATE() 
        WHERE AccountMetaDataID IN (SELECT AccountMetaDataID FROM INSERTED) 
END 
GO


/***************************************************************************************/
-- Create Group Account Payment Plan & Fees
/***************************************************************************************/

-- Create the payment plan
USE [SDBO_App]
GO

INSERT INTO [dbo].[PaymentPlanAccount] ([Name]) VALUES ('Free')
GO

-- Insert Fees
USE [SDBO_App]
GO

DECLARE @PaymentPlanID UNIQUEIDENTIFIER = (SELECT TOP 1 PaymentPlanAccountID FROM PaymentPlanAccount WHERE Name = 'Free')

INSERT INTO [dbo].[PaymentPlanAccountFee] ([PaymentPlanAccountID], [Section] ,[Amount]) VALUES (@PaymentPlanID ,'Signup.Fee' ,0.00)
INSERT INTO [dbo].[PaymentPlanAccountFee] ([PaymentPlanAccountID], [Section] ,[Amount]) VALUES (@PaymentPlanID ,'Monthly.Fee' ,0.00)

GO
/***************************************************************************************/
-- CREATE GRUOP ACCOUNT AND TYPES
/***************************************************************************************/


-- POPULATE Group Account Type

USE [SDBO_App]
GO

INSERT INTO [dbo].[AccountType] ([Type]) VALUES ('Administration')
INSERT INTO [dbo].[AccountType] ([Type]) VALUES ('Service')

INSERT INTO [dbo].[AccountType] ([Type]) VALUES ('Standard')
INSERT INTO [dbo].[AccountType] ([Type]) VALUES ('Advanced')
INSERT INTO [dbo].[AccountType] ([Type]) VALUES ('Business')

GO

-- TODO:// INSERT GROUP ACCOUNT PAYMENT PLAN ID

-- POPULATE Group Account
USE [SDBO_App]
GO


DECLARE @PaymentPlanID UNIQUEIDENTIFIER = (SELECT TOP 1 PaymentPlanAccountID FROM PaymentPlanAccount WHERE Name = 'Free')
DECLARE @Type UNIQUEIDENTIFIER = (SELECT TOP 1 AccountTypeID FROM [dbo].[AccountType] WHERE [Type] = 'Administration')
INSERT INTO [dbo].[Account] ([AccountTypeID],[PaymentPlanAccountID], [Email]) VALUES (@Type, @PaymentPlanID, 'administration@relsocial.com')

GO

DECLARE @PaymentPlanID UNIQUEIDENTIFIER = (SELECT TOP 1 PaymentPlanAccountID FROM PaymentPlanAccount WHERE Name = 'Free')
DECLARE @Type UNIQUEIDENTIFIER = (SELECT TOP 1 AccountTypeID FROM [dbo].[AccountType] WHERE [Type] = 'Service')
INSERT INTO [dbo].[Account] ([AccountTypeID],[PaymentPlanAccountID], [Email]) VALUES (@Type, @PaymentPlanID, 'service@relsocial.com')



GO

/***************************************************************************************/
-- CREATE Group Account Meta Data
/***************************************************************************************/
USE [SDBO_App]
GO

DECLARE @AccountID UNIQUEIDENTIFIER = (SELECT TOP 1 AccountID FROM dbo.Account WHERE Email = 'administration@relsocial.com' )
DECLARE @AccountStatusTypeID UNIQUEIDENTIFIER = (SELECT TOP 1 AccountStatusTypeID FROM dbo.AccountStatusType WHERE [Type] = 'Active' )

INSERT INTO [dbo].[AccountMetaData]
           ([AccountID]
           ,[AccountStatusTypeID]
		   ,[ProfileImage])
     VALUES
           (@AccountID
           ,@AccountStatusTypeID
		   --profile image
		   ,'/9j/4AAQSkZJRgABAQAAAQABAAD/2wCEAAkGBw8RERIQEBIQEBAQFxYXFhAPFBEPFA8QFR0YFhQSFhMYKCghGBolHBMXIT0hJSktLi4uFx80OD8sNygtLisBCgoKDg0OGxAQGywcHSQtLC8vLi4sLCwsLCw3Ny0vNSwtNy4sLCw3Li0sLzEsNy0sLCs3LCwsLC8wLC4sLC8sLv/AABEIAMgAoAMBIgACEQEDEQH/xAAcAAEAAQUBAQAAAAAAAAAAAAAAAgMEBQYHAQj/xAA8EAACAgADBgQCBwcDBQAAAAAAAQIDBBExBRIhQVFxBgcTkWGxIlJicoGhwRQyQqKywtEjksM0Q1Njgv/EABsBAQEAAwEBAQAAAAAAAAAAAAABAgQFAwYH/8QAKxEBAAIBAgQEBQUAAAAAAAAAAAECEQMEBRIxUSFhgbEzNEGh8BMiMuHx/9oADAMBAAIRAxEAPwDtFcFkuC0XJEvTj0XshXouyJGbBH049F7IenHovZEgQR9OPReyHpx6L2RIAR9OPReyHpx6L2RI1nHeOtn1TdanK6a4NURdmTWvFcCjZPTj0Xsh6cei9kaRjPH+DmtyNuIws1/E6VPL4OLz4exY0eYUqZRV0qcZVL/u4dOmyH3qZf5B4Oi+nHovZD049F7IttmbSpxNatomrIPmuT5prk/gXYEfTj0Xsh6cei9kSBBH049F7IenHovZEgBH049F7IenHovZEgBH049F7IjZBZPgtHyRUI2aPsyhXouyJEa9F2RIgAAKAGr+MvGFWBjuRysxMl9GvPhBfWn8PhzKjKeIds4bC1OWIkt2SaVa4yt6xjHn8uJyjHeO8RJOGFrqwVb0VCW/u/GeS49ka9tPaN2Isdt03Ocub5LlFLkvgWpcMcql105ycpylOT1lNuUn3bKYBUZDYu2cRhLPUom4N/vR1jNLlKPM694Q8ZU47/Ta9LERWbrbzU1zcHz7ao4iShNxalFuMovNSi2nF9U1oyYWJfSgNe8C7aljMJGybTtg3Cb6yjpJr4ppmwmLIAAUAAAjZo+zJEbNH2YQr0XZEiNei7IkAAAUPn/xYmsdis9fVnr0z4flkfQBxrxts5T2u6v3VfKttrpJJN+yLDGWr7PwNl8/TrWbybbfBRjFZtt9C88M7H/bLvT3tyCjvSkuL3eCyS68TevD+wJ4PE3OP0sPdFKPFOUMnvZT6rlmWcdiTwGJ/aaIuzDSzU64pudUHzil+8k13MnnzdmF294erV0cNgoW2WxW9a5SzjFP9xPPR6lXBeAcTLjbZXUuizsf5ZL8zokIRTckknLLNpZOWWmZMuGHPLTavL2hL6V10n1ioRXtx+Zh/Eng54at3VWSshH96MklKK+tmuDX4HSi22jSp02wek4SXumEi85at5O4zK3EUvScYzS+1BuL/Ka9jqZxfyptyx8ftVz+SZ2gwlswAAigAAEbNH2ZIjZo+zCFei7IkRr0XZEgAAChy/zHp9LaODxH8Njgs/tQmk1n2kjqBidswUmoySlB8d2STWa55PmWGNpxC0YAM2qAAAMgANB8sdnWRxznKMlCpWQ32nuua+jup82dfMFgalvxUUks8+HXVszpjLZpbMAAMWYAABGzR9mSI2aPswhXouyJEa9F2RIAAAoWuPp3o8NY8f8AJdAqTGYw14Hslk2uh4ZtQAAAAAZHZdOs32X6syB4llw6HphLarGIwAAjIAAAjZo+zJEbNH2YQr0XZEiNei7IkAAAUAAGI2hTuyz5S+fMtTPWVqSyfFMw+Kwzg+qejM4lr6lMeKiACvMLjBUuUl0XF/4LWUsi/wBiWZ767P5iejKkZsygAPNtAAAAAARs0fZkiNmj7MIV6LsiRGvRdkSAAAKAAAY3bMc1H8f0MkY/a2ke7/QsdWGp/GWJjb1PXaibSZ5uLoeng1VBvMr7Nx1Vd0a5zjGVyajFvJza48DBeJPENOEW6kp3tcIco/am+S+HM5njMTO2crLJOU5cXLtol0SNfX3MU/bHjLscP4TfXj9W88te/f8Ap9GA4bs7xztGnJet6sV/DclP+bX8zaNm+ai0xOHy+3RLP+SX+T0w08ulAweyPFmBxOSruipv+Cz/AE5ez1/AzhAAAUI2aPsyRGzR9mEK9F2RIjXouyJAAAFADA+JPFeFwSyslv2tcKYZOT+99VfFhGclJJNtpJat8El1bOb+MPHUVdVHCSVsKt/1c+ELHLd3VGXw3ZcfitTUvEni3FY15Tfp08qa293/AOn/ABPuYKB560zWkzHVucPpTV3NaXjMTn2l1jZvinCXLPfVUucLcotfjozD+IvGkY514TKcmnndyg+W6v4nrx5cNeWhA07bu81x0d3S4FtqanPOZjtPR7ZNyblJuUpPNyfFt9WyMj0hM89CvNqQ2+JasaW1tjtiPXw9kQAdd8QNGVwXjDaGGyjXiJuEdIWZWR7fS4/mYotrtQsOj7M82rVksTh42fbpl6b/ANks0/dG1bJ8xdnXvdc5US6XpRT+G8s0cLBMK+ncPia7FvVzhZH60JKa90Ts0fZnzh4c2h+zYqm9NxUJx3snlnXnlJPrwbPo6zR9mRXtei7IkRr0XZEiAQtsjGLlJqMYrNyk0kl1begsmoxcnpFNvsuLOBeLfF+I2hLi3Xh084UJ8MuTn9aXyKNw8X+YylnRgJNfWxK4Z8t2Cf8AUc7nJtttuTfFuTbbfVt6staNS4KxkJQIkoHjuPhy3+FfN09faUwAcl9uFORNlM3tnXxmz57j+r+2mn6/n3ADxyXVG++Zelrbqy4di6ltJ8WFh4AArxo+h/COP/aMBRbnm3Woy+9Bbr+R88nW/JzaG9hsRh3rTLeX3LE/7oP3JI6LXouyJEa9F2RIxVYbft3MLiJfVqsf8rPmtH0R41s3dn4t/wDql+fD9T54MoJVKNS4LWueTzJu9/ArFXJQKMFLm/wK0Dw3PwpdDhXzdPX2lMAHJfbIyZAlMidXbV5dOPN8XxbV/U3VvLw/PVSnTnz9+JTdTXL2LkNmw5qzBKyWbIhQAADcfKvH+ljtxvJX1zh3kvpR+TNOLnZmLdN1Vy1qnGXdJ8V+KzQH0vXouyJEa9F2RIwVrPmPbu7NxP2ko+7SOBnavN+7d2eo/wDktgvbOX9pxUyhJC4piss+ZblfDvgUlVJQIkoHlrxnTlt8Pty7qk+aYB4zkVjmmIh9tq6kadJvPSIygzwA7cRiMPz69ptabT1kKF0+RUtnl3ZbFSAABV5sfAPEXQoXB2byXdRcv0LJM2zyvp3tpU/YU5eya/UwW3cH6GJvp5V2Tivu5vd/LIgsQAUfUFei7IkRr0XZEjBXNPOy/KrCV/WnZLL7iiv+Q5QdF86rc8RhofUrk/8AfJL+w50ZQgVKHx7lMqW1SrklJNPJSyfOMlmn7MouD2J4meowvGazD029uXVrbtMe6oQmTKcmc/aVzfPZ9TxrW5NvyfW0/bq8PJPLielvdPPsdN8ihKWbzPAAoAAN/wDJmnPF3T+pV+cpJfozH+auD9PaM5crown+OW6/6TYvJKj/AKyzk/Riu69SUvnEh52YX6WEuXNWVt9t2UfnIn1VzEAFR9PVzWS4rRc0S9SPVe6AJhOZxLzavUtoNLioVwXvm/1NMAKrxnQfMbYihhsDioZcKq6rEuu6nCX9S9gCDR6JZrLoVACp0VGUwDU2cYrM+bt8dvM61Y+mPf8AxSunyKABtuKAAAAAOx+TlSjgrJtpepdJ8WtIxjH5plx5t4ZWYDfWTdNkJcMtHnB/lI8BMJlxUAFV/9k='
		   )
GO

DECLARE @AccountID UNIQUEIDENTIFIER = (SELECT TOP 1 AccountID FROM dbo.Account WHERE Email = 'service@relsocial.com' )
DECLARE @AccountStatusTypeID UNIQUEIDENTIFIER = (SELECT TOP 1 AccountStatusTypeID FROM dbo.AccountStatusType WHERE [Type] = 'Active' )

INSERT INTO [dbo].[AccountMetaData]
           ([AccountID]
           ,[AccountStatusTypeID]
		   ,[ProfileImage])
     VALUES
           (@AccountID
           ,@AccountStatusTypeID
		   --profile image
		   ,'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'
		   )
GO


/***************************************************************************************/
-- 
/***************************************************************************************/
/*
Holds all of the group level configuration settings
*/
CREATE TABLE dbo.[AccountConfiguration]
(
	AccountConfigurationID UNIQUEIDENTIFIER PRIMARY KEY,
	Section VARCHAR(300) NOT NULL,
	Name VARCHAR(300) NOT NULL,
	Value VARCHAR(500) NOT NULL,

	-- Updated Datetime
	CreatedDate datetime DEFAULT(GETDATE()), 
	UpdatedDate datetime DEFAULT(GETDATE())
)

GO
-- ADD PRIMARY KEY
ALTER TABLE dbo.[AccountConfiguration]
    ADD CONSTRAINT DF_AccountConfiguration_AccountConfigurationID DEFAULT NEWSEQUENTIALID() FOR AccountConfigurationID
GO



--UPDATE TRIGGER

CREATE TRIGGER dbo.AccountConfiguration_Update_UpdatedDate
ON dbo.[AccountConfiguration]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.AccountConfiguration SET UpdatedDate=GETDATE() 
        WHERE AccountConfigurationID IN (SELECT AccountConfigurationID FROM INSERTED) 
END 
GO




-- INERT SOME DEFAULT CONFIGURATIONS
USE [SDBO_App]
GO

INSERT INTO [dbo].[AccountConfiguration] ([Section] ,[Name] ,[Value]) VALUES ('Landing.Page', 'DisplayProfilePicture', 'True')

GO





/***************************************************************************************/
-- Group Account Settings Type
/***************************************************************************************/
/* 
Holds the group account types
*/
CREATE TABLE dbo.[AccountSettingsType]
(
	AccountSettingsTypeID UNIQUEIDENTIFIER PRIMARY KEY,
	[Type] VARCHAR(300),

	-- Updated Datetime
	CreatedDate datetime DEFAULT(GETDATE()), 
	UpdatedDate datetime DEFAULT(GETDATE())
)
GO

ALTER TABLE dbo.[AccountSettingsType]
    ADD CONSTRAINT DF_AccountSettingsType_AccountSettingsTypeID DEFAULT NEWSEQUENTIALID() FOR AccountSettingsTypeID

GO


--UPDATE TRIGGER

CREATE TRIGGER dbo.AccountSettingsType_Update_UpdatedDate
ON dbo.[AccountSettingsType]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.AccountSettingsType SET UpdatedDate=GETDATE() 
        WHERE AccountSettingsTypeID IN (SELECT AccountSettingsTypeID FROM INSERTED) 
END 
GO


-- POPULATE
USE [SDBO_App]
GO

INSERT INTO [dbo].[AccountSettingsType] ([Type]) VALUES ('CheckBox')
INSERT INTO [dbo].[AccountSettingsType] ([Type]) VALUES ('Email')
INSERT INTO [dbo].[AccountSettingsType] ([Type]) VALUES ('Text')
INSERT INTO [dbo].[AccountSettingsType] ([Type]) VALUES ('TextArea')
INSERT INTO [dbo].[AccountSettingsType] ([Type]) VALUES ('Password')

GO



/***************************************************************************************/
-- Group Account Settings, global... if not set then default to the default value
/***************************************************************************************/
/*
Holds all of the group level account settings, based off of sections
*/
CREATE TABLE dbo.[AccountSettings]
(
	AccountSettingsID UNIQUEIDENTIFIER PRIMARY KEY,
	AccountSettingsTypeID UNIQUEIDENTIFIER NOT NULL,
	Section VARCHAR(300) NOT NULL,
	Name VARCHAR(300) NOT NULL,
	DefaultValue VARCHAR(500) NOT NULL,

	-- Updated Datetime
	CreatedDate datetime DEFAULT(GETDATE()), 
	UpdatedDate datetime DEFAULT(GETDATE())
)

GO

-- ADD PRIMARY KEY
ALTER TABLE dbo.[AccountSettings]
    ADD CONSTRAINT DF_AccountSettings_AccountSettingsID DEFAULT NEWSEQUENTIALID() FOR AccountSettingsID
GO

-- ADD FORIEGN KEY CONSTRAINT
ALTER TABLE dbo.[AccountSettings]
	ADD CONSTRAINT FK_AccountSettings_AccountSettingsTypeID FOREIGN KEY (AccountSettingsTypeID) REFERENCES AccountSettingsType(AccountSettingsTypeID);
GO



--UPDATE TRIGGER

CREATE TRIGGER dbo.AccountSettings_Update_UpdatedDate
ON dbo.[AccountSettings]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.AccountSettings SET UpdatedDate=GETDATE() 
        WHERE AccountSettingsID IN (SELECT AccountSettingsID FROM INSERTED) 
END 
GO


USE [SDBO_App]
GO


-- POPULATE

DECLARE @AccountSettingsTypeID UNIQUEIDENTIFIER = (SELECT TOP 1 AccountSettingsTypeID FROM AccountSettingsType WHERE [Type] = 'CheckBox')

INSERT INTO [dbo].[AccountSettings]
           ([AccountSettingsTypeID], [Section], [Name], [DefaultValue])
     VALUES
           (@AccountSettingsTypeID
           ,'Account.Settings'
           ,'Enable Notifications'
           ,'True')
GO

DECLARE @AccountSettingsTypeID UNIQUEIDENTIFIER = (SELECT TOP 1 AccountSettingsTypeID FROM AccountSettingsType WHERE [Type] = 'CheckBox')
INSERT INTO [dbo].[AccountSettings]
           ([AccountSettingsTypeID], [Section], [Name], [DefaultValue])
     VALUES
           (@AccountSettingsTypeID
           ,'Account.Settings.Notifications'
           ,'Notify recipients upon account creation'
           ,'True')
GO

--- 



/***************************************************************************************/
-- Group Account Group Account Settings Link
/***************************************************************************************/

/*
Holds all of the group level account settings, based off of sections
*/
CREATE TABLE dbo.[AccountAccountSettingsLink]
(
	AccountAccountSettingsLinkID UNIQUEIDENTIFIER PRIMARY KEY,
	AccountID UNIQUEIDENTIFIER NOT NULL,
	AccountSettingsID UNIQUEIDENTIFIER NOT NULL,
	AccountSettingsTypeID UNIQUEIDENTIFIER NOT NULL,
	Value VARCHAR(500),

	-- Updated Datetime
	CreatedDate datetime DEFAULT(GETDATE()), 
	UpdatedDate datetime DEFAULT(GETDATE())
)

GO

-- ADD PRIMARY KEY
ALTER TABLE dbo.[AccountAccountSettingsLink]
    ADD CONSTRAINT DF_AccountAccountSettingsLink_AccountAccountSettingsLinkID DEFAULT NEWSEQUENTIALID() FOR AccountAccountSettingsLinkID
GO

-- ADD FORIEGN KEY CONSTRAINT
ALTER TABLE dbo.[AccountAccountSettingsLink]
	ADD CONSTRAINT FK_AccountAccountSettingsLink_AccountID FOREIGN KEY (AccountID) REFERENCES Account(AccountID);
GO

ALTER TABLE dbo.[AccountAccountSettingsLink]
	ADD CONSTRAINT FK_AccountAccountSettingsLink_AccountSettingsID FOREIGN KEY (AccountSettingsID) REFERENCES AccountSettings(AccountSettingsID);
GO

ALTER TABLE dbo.[AccountAccountSettingsLink]
	ADD CONSTRAINT FK_AccountAccountSettingsLink_AccountSettingsTypeID FOREIGN KEY (AccountSettingsTypeID) REFERENCES AccountSettingsType(AccountSettingsTypeID);
GO

--UPDATE TRIGGER

CREATE TRIGGER dbo.AccountAccountSettingsLink_Update_UpdatedDate
ON dbo.[AccountAccountSettingsLink]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.AccountAccountSettingsLink SET UpdatedDate=GETDATE() 
        WHERE AccountAccountSettingsLinkID IN (SELECT AccountAccountSettingsLinkID FROM INSERTED) 
END 
GO


---Populate


USE [SDBO_App]
GO

DECLARE @AccountID UNIQUEIDENTIFIER = (SELECT TOP 1 AccountID FROM Account WHERE Email = 'adminitration@relsocial.com')
DECLARE @AccountSettingsID UNIQUEIDENTIFIER = (SELECT TOP 1 AccountSettingsID FROM AccountSettings WHERE Section = 'Account.Settings.Notifications' AND Name = 'Notify recipients upon account creation')
DECLARE @AccountSettingsTypeID UNIQUEIDENTIFIER = (SELECT TOP 1 AccountSettingsTypeID FROM AccountSettings WHERE Section = 'Account.Settings.Notifications' AND Name = 'Notify recipients upon account creation')


INSERT INTO [dbo].[AccountAccountSettingsLink]
           ([AccountID]
           ,[AccountSettingsID]
           ,[AccountSettingsTypeID]
           ,[Value])
     VALUES
           (@AccountID
           ,@AccountSettingsID
           ,@AccountSettingsTypeID
           ,'True')
GO

USE [SDBO_App]
GO

DECLARE @AccountID UNIQUEIDENTIFIER = (SELECT TOP 1 AccountID FROM Account WHERE Email = 'service@relsocial.com')
DECLARE @AccountSettingsID UNIQUEIDENTIFIER = (SELECT TOP 1 AccountSettingsID FROM AccountSettings WHERE Section = 'Account.Settings.Notifications' AND Name = 'Notify recipients upon account creation')
DECLARE @AccountSettingsTypeID UNIQUEIDENTIFIER = (SELECT TOP 1 AccountSettingsTypeID FROM AccountSettings WHERE Section = 'Account.Settings.Notifications' AND Name = 'Notify recipients upon account creation')


INSERT INTO [dbo].[AccountAccountSettingsLink]
           ([AccountID]
           ,[AccountSettingsID]
           ,[AccountSettingsTypeID]
           ,[Value])
     VALUES
           (@AccountID
           ,@AccountSettingsID
           ,@AccountSettingsTypeID
           ,'True')
GO

/***************************************************************************************/






/***************************************************************************************/
-- Group Account Roles
/***************************************************************************************/
/*
Holds all of the group level account settings, based off of sections
*/
CREATE TABLE dbo.[AccountRole]
(
	AccountRoleID UNIQUEIDENTIFIER PRIMARY KEY,
	[Role] VARCHAR(500),

	-- Updated Datetime
	CreatedDate datetime DEFAULT(GETDATE()), 
	UpdatedDate datetime DEFAULT(GETDATE())
)

GO

-- ADD PRIMARY KEY
ALTER TABLE dbo.[AccountRole]
    ADD CONSTRAINT DF_AccountRole_AccountRoleID DEFAULT NEWSEQUENTIALID() FOR AccountRoleID
GO


--UPDATE TRIGGER

CREATE TRIGGER dbo.AccountRole_Update_UpdatedDate
ON dbo.[AccountRole]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.AccountRole SET UpdatedDate=GETDATE() 
        WHERE AccountRoleID IN (SELECT AccountRoleID FROM INSERTED) 
END 
GO




-- Populate
USE [SDBO_App]
GO

INSERT INTO [dbo].[AccountRole] ([Role]) VALUES ('User')
GO



/***************************************************************************************/








SELECT * FROM dbo.Account;
SELECT * FROM dbo.AccountMetaData;
SELECT * FROM dbo.AccountStatusType;
SELECT * FROM dbo.AccountType;
SELECT * FROM dbo.PaymentPlanAccount;
SELECT * FROM dbo.PaymentPlanAccountFee;

SELECT * FROM dbo.Account ga
LEFT JOIN dbo.AccountMetaData gamd ON ga.AccountID = gamd.AccountID

-- Get the group name and the payment plan name
SELECT ga.Email, ppga.Name FROM dbo.Account ga
LEFT JOIN PaymentPlanAccount ppga ON ga.[PaymentPlanAccountID] = ppga.PaymentPlanAccountID

-- Get the group name and the payment plan name and payment options associated with this plan
SELECT 
	ga.Email,
	ppga.Name, 
	ppgaf.Section,
	ppgaf.Amount 
	FROM dbo.Account ga
LEFT JOIN PaymentPlanAccount ppga ON ga.[PaymentPlanAccountID] = ppga.PaymentPlanAccountID
LEFT JOIN PaymentPlanAccountFee ppgaf ON ppga.PaymentPlanAccountID = ppgaf.PaymentPlanAccountID


-- Get Types of account, and payment plans

SELECT 
	ga.Email,
	gat.[Type] as 'Account Type',
	ppga.Name, 
	ppgaf.Section,
	ppgaf.Amount 
	FROM dbo.Account ga
LEFT JOIN [dbo].[AccountType] gat ON ga.AccountTypeID = gat.AccountTypeID
LEFT JOIN PaymentPlanAccount ppga ON ga.[PaymentPlanAccountID] = ppga.PaymentPlanAccountID
LEFT JOIN PaymentPlanAccountFee ppgaf ON ppga.PaymentPlanAccountID = ppgaf.PaymentPlanAccountID

-- Get Types of account, and payment plans, and status

SELECT 
	ga.Email,
	gat.[Type] as 'Account Type',
	ppga.Name, 
	ppgaf.Section,
	ppgaf.Amount 
	FROM dbo.Account ga
LEFT JOIN [dbo].[AccountType] gat ON ga.AccountTypeID = gat.AccountTypeID
LEFT JOIN PaymentPlanAccount ppga ON ga.[PaymentPlanAccountID] = ppga.PaymentPlanAccountID
LEFT JOIN PaymentPlanAccountFee ppgaf ON ppga.PaymentPlanAccountID = ppgaf.PaymentPlanAccountID



-- GET Monthly Fee
SELECT 
	ga.Email,
	ppga.Name, 
	ppgaf.Section,
	ppgaf.Amount 
	FROM dbo.Account ga
LEFT JOIN PaymentPlanAccount ppga ON ga.[PaymentPlanAccountID] = ppga.PaymentPlanAccountID
LEFT JOIN PaymentPlanAccountFee ppgaf ON ppga.PaymentPlanAccountID = ppgaf.PaymentPlanAccountID
WHERE ppgaf.Section = 'Monthly.Fee'

-- GET signup fee
SELECT 
	ga.Email,
	ppga.Name, 
	ppgaf.Section,
	ppgaf.Amount 
	FROM dbo.Account ga
LEFT JOIN PaymentPlanAccount ppga ON ga.[PaymentPlanAccountID] = ppga.PaymentPlanAccountID
LEFT JOIN PaymentPlanAccountFee ppgaf ON ppga.PaymentPlanAccountID = ppgaf.PaymentPlanAccountID
WHERE ppgaf.Section = 'Signup.Fee'


-- get profile pictrue
SELECT ga.Email, gamd.ProfileImage FROM Account ga
LEFT JOIN AccountMetaData gamd ON ga.AccountID = gamd.AccountID



/***************************************************************************/
-- settings queries
/***************************************************************************/


SELECT * FROM AccountSettings;

-- Get group account settings and type, with default value
SELECT gas.Name, gast.[Type], gas.DefaultValue FROM AccountSettings gas
LEFT JOIN AccountSettingsType gast ON gas.AccountSettingsTypeID = gast.AccountSettingsTypeID

-- Get account settings for the current group account
-- This Query gets all of the account settings for the current account id
SELECT gas.Name, 
	   gast.[Type], 
	   ISNULL(gagasl.Value, gas.DefaultValue) AS 'Value'
	   FROM AccountSettings gas
LEFT JOIN AccountSettingsType gast ON gas.AccountSettingsTypeID = gast.AccountSettingsTypeID
LEFT JOIN AccountAccountSettingsLink gagasl ON gas.AccountSettingsID = gagasl.AccountSettingsID
WHERE gagasl.AccountID = (SELECT TOP 1 AccountID FROM Account WHERE Name = 'administration@relsocial.com')







