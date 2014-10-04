
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





