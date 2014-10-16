USE SDBO_App1;

SELECT 
    [Extent1].[AccountID] AS [AccountID], 
    [Extent1].[AccountTypeID] AS [AccountTypeID], 
    [Extent1].[PaymentPlanAccountID] AS [PaymentPlanAccountID], 
    [Extent1].[Email] AS [Email], 
    [Extent1].[CreatedDate] AS [CreatedDate], 
    [Extent1].[UpdatedDate] AS [UpdatedDate]
    FROM [dbo].[Account] AS [Extent1]



use SDBO_App3;


select * from dbo.aspnet_Applications;
select * from dbo.aspnet_Membership;
select * from dbo.aspnet_WebEvent_Events;

select * from [dbo].[aspnet_Applications]
select * from [dbo].[aspnet_PersonalizationAllUsers]
select * from [dbo].[aspnet_PersonalizationPerUser]
select * from [dbo].[aspnet_Profile]
select * from [dbo].[aspnet_Roles]
select * from [dbo].[aspnet_SchemaVersions]
select * from [dbo].[aspnet_Users]
select * from [dbo].[aspnet_UsersInRoles]
select * from [dbo].[aspnet_WebEvent_Events]

select * from [dbo].[AspNetRoles]
select * from [dbo].[AspNetUserLogins]
select * from [dbo].[AspNetUserClaims]
select * from [dbo].[AspNetUserRoles]
select * from [dbo].[AspNetUsers]


select * from dbo.Account;
BIT IsDeleted DEFAULT 0











select * from 


select * from dbo.Account;
select * from dbo.AccountType;
select * from dbo.PaymentPlanAccount;
select * from dbo.AccountAccountSettingsLink;
select * from dbo.AccountSettings;


GO

CREATE PROCEDURE dbo.CreateAccount 
    @email VARCHAR(500),
    @accountType VARCHAR(500) = 'Standard',
	@paymentPlanName VARCHAR(500) = 'Free'
AS

	-- create account
	INSERT INTO [dbo].[Account]
			   ([AccountTypeID]
			   ,[PaymentPlanAccountID]
			   ,[Email])
		 VALUES
			   ((SELECT AccountTypeID FROM dbo.AccountType WHERE [Type] = @accountType)
			   ,(SELECT PaymentPlanAccountID FROM PaymentPlanAccount WHERE Name = @paymentPlanName)
			   ,@email)
	GO

	-- link with settings

	-- load with relationship capital


RETURN 0 

GO


/*
	--link account with settings

	select * from dbo.AccountSettings
	select * from dbo.AccountSettingsType;
	select * from AccountSettingsAccountSettingsMultichoiceAnswerLink;
	select * from AccountSettingsMultichoiceAnswer;

	select * from AccountAccountSettingsLink;


*/


CREATE PROCEDURE dbo.CreateGroupAccount
    @param1 int = 0,
    @param2 int  
AS
    SELECT @param1,@param2 



RETURN 0 





GO


CREATE PROCEDURE dbo.CreateGroupAccountSettings
    @param1 int = 0,
    @param2 int  
AS
    SELECT @param1,@param2 



RETURN 0 





GO


CREATE PROCEDURE dbo.CreateAccountSettings
    @param1 int = 0,
    @param2 int  
AS
    SELECT @param1,@param2 



RETURN 0 





