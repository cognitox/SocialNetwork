/*************************************************************
** File:    000001_Create_SDBO_App_Database.sql
** Name:	DATABASE {{DatabaseName}}
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

USE [master]
GO


/****** Object:  Database {{DatabaseName}}    Script Date: 8/29/2014 4:52:24 PM ******/

CREATE DATABASE {{DatabaseName}}
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'{{DatabaseName}}', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\SDBO_App.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'{{DatabaseName}}_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\SDBO_App_log.ldf' , SIZE = 784KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE {{DatabaseName}} SET COMPATIBILITY_LEVEL = 110
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC {{DatabaseName}}.[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE {{DatabaseName}} SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE {{DatabaseName}} SET ANSI_NULLS OFF 
GO

ALTER DATABASE {{DatabaseName}} SET ANSI_PADDING OFF 
GO

ALTER DATABASE {{DatabaseName}} SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE {{DatabaseName}} SET ARITHABORT OFF 
GO

ALTER DATABASE {{DatabaseName}} SET AUTO_CLOSE OFF 
GO

ALTER DATABASE {{DatabaseName}} SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE {{DatabaseName}} SET AUTO_SHRINK OFF 
GO

ALTER DATABASE {{DatabaseName}} SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE {{DatabaseName}} SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE {{DatabaseName}} SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE {{DatabaseName}} SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE {{DatabaseName}} SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE {{DatabaseName}} SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE {{DatabaseName}} SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE {{DatabaseName}} SET  ENABLE_BROKER 
GO

ALTER DATABASE {{DatabaseName}} SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE {{DatabaseName}} SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE {{DatabaseName}} SET TRUSTWORTHY OFF 
GO

ALTER DATABASE {{DatabaseName}} SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE {{DatabaseName}} SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE {{DatabaseName}} SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE {{DatabaseName}} SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE {{DatabaseName}} SET RECOVERY FULL 
GO

ALTER DATABASE {{DatabaseName}} SET  MULTI_USER 
GO

ALTER DATABASE {{DatabaseName}} SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE {{DatabaseName}} SET DB_CHAINING OFF 
GO

ALTER DATABASE {{DatabaseName}} SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE {{DatabaseName}} SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE {{DatabaseName}} SET  READ_WRITE 
GO




--USE {{DatabaseName}}
--GO
/****** Object:  Login [SDBOAppUser]    Script Date: 8/30/2014 2:07:42 PM ******/
--CREATE LOGIN [SDBOServiceAccount] WITH PASSWORD=N'oroVerde', DEFAULT_DATABASE={{DatabaseName}}, DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=ON, CHECK_POLICY=ON

--USE SDBO_App
--CREATE USER SDBOServiceAccount FOR LOGIN SDBOServiceAccount

--USE SDBO_App;

--EXEC sp_addrolemember 'db_owner', 'SDBOServiceAccount'
--EXEC sp_addrolemember 'db_datareader', 'SDBOServiceAccount'

--GO







