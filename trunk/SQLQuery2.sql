
/****************************************/
-- Notifications

CREATE TABLE [NotificationQueue]
(
	NotificationID  INT IDENTITY(1,1) PRIMARY KEY,
	NotificationTypeID INT NOT NULL
)

CREATE TABLE [NotificationType]
(
	NotificationTypeID  INT IDENTITY(1,1) PRIMARY KEY,
	[Type] VARCHAR(50) NOT NULL
)


-- Account Create
-- Reminder
-- Commitment Accepted
-- Acc Update
-- Commitment Update
-- Commitment ....




-- to audit all of the accounts within the database
CREATE TABLE [AuditRecord]
(
	AuditRecordID INT IDENTITY(1,1) PRIMARY KEY,
	AuditRecordTypeID INT NOT NULL
	AccountID INT NOT NULL
	Details VARCHAR(MAX) NOT NULL
);

CREATE TABLE [AuditRecordType]
(
	AuditRecordTypeID INT IDENTITY(1,1) PRIMARY KEY,
	[Type] VARCHAR(50)
);


-- holds all of the application configuration settings
CREATE TABLE [Configuration]
(
	ConfigurationID INT IDENTITY(1,1) PRIMARY KEY,
	Section VARCHAR(300) NOT NULL,
	Name VARCHAR(300) NOT NULL,
	Value VARCHAR(500) NOT NULL
);
