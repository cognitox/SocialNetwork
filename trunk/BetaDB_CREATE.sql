Select * from BetaSignUp;
Select * from ContactUs
-- Truncate Table BetaSignUp;
-- Truncate Table ContactUs;
--DROP TABLE BetaSignUp;
--Drop TABLE ContactUs

CREATE TABLE BetaSignUp
(
	[BetaSignUpID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_BETA_BetaSignUpID]  DEFAULT (newsequentialid()) primary key,
	[Email] VARCHAR(500) NOT NULL
)


CREATE TABLE ContactUs
(
	[ContactUsID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_BETA_ContactUsID]  DEFAULT (newsequentialid()) primary key,
	[Name] VARCHAR(MAX) NOT NULL,
	[Email] VARCHAR(MAX) NOT NULL,
	[Phone] VARCHAR(MAX) NOT NULL,
	[Message] VARCHAR(MAX) NOT NULL	
)