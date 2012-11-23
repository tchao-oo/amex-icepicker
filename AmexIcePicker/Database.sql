/*

 RUN, ONE AT THE TIME, THE FOLLOWING 4 LINES

CREATE LOGIN AmexIcePickerPlatform_User WITH PASSWORD = 'cNVo!!|7RHy'
CREATE DATABASE [AmexIcePickerPlatform]
USE [AmexIcePickerPlatform]
CREATE USER AmexIcePickerPlatform_User FOR LOGIN AmexIcePickerPlatform_User WITH DEFAULT_SCHEMA = db_owner

*/

USE [AmexIcePickerPlatform]
GO


/****** Object:  Table [dbo].[Property]    Script Date: 11/23/2012 15:45:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Property](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [nvarchar](100) NULL,
	[Locale] [varchar](10) NULL,
	[DateCreated] [datetime] NULL CONSTRAINT [DF_Properties_DateCreated]  DEFAULT (getdate()),
	[Name] [varchar](50) NULL,
	[Value] [ntext] NULL,
	[DateModified] [datetime] NULL CONSTRAINT [DF_Properties_DateModified]  DEFAULT (getdate()),
 CONSTRAINT [PK_Properties] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO


/****** Object:  Table [dbo].[Email]    Script Date: 11/23/2012 15:45:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Email](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [varchar](100) NULL,
	[FromName] [nvarchar](150) NULL,
	[ToName] [nvarchar](150) NULL,
	[FromEmail] [varchar](250) NULL,
	[ToEmail] [varchar](250) NULL,
	[HtmlBody] [text] NULL,
	[Subject] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL CONSTRAINT [DF_Email_CreatedDate]  DEFAULT (getdate()),
 CONSTRAINT [PK_Email] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO


/****** Object:  StoredProcedure [dbo].[Property_Set]    Script Date: 11/23/2012 15:45:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Property_Set]
(
	@_clientid nvarchar(100), 
	@_locale varchar(10),
	@_value ntext,
	@_name varchar(50)
)

as

BEGIN
	DECLARE @_propId int
	SET @_propId = (SELECT Id FROM [Property] WHERE [Name] = @_name AND ClientId = @_clientId)
	
	IF (@_propId IS NULL)
		insert into Property 
			(ClientId, Locale, [Name], [Value])
		values 
			(@_clientid, @_locale, @_name, @_value)
	ELSE
		update Property
		set ClientId = @_clientid,
			Locale = @_locale, [Value] = @_value, 
			DateModified = getdate()
		where [Name] = @_name

END
GO


/****** Object:  StoredProcedure [dbo].[Property_GetById]    Script Date: 11/23/2012 15:45:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Teresa Chao	
-- Create date: 04-11-2010
-- =============================================
CREATE PROCEDURE [dbo].[Property_GetById]
	@_name varchar(50)
AS
	BEGIN
		SELECT ClientId, Locale, [Name], [Value], DateModified, DateCreated
		From Property
		WHERE [Name] = @_name
	END
GO


/****** Object:  StoredProcedure [dbo].[Email_Insert]    Script Date: 11/23/2012 15:45:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Email_Insert]
(
	@_clientId nvarchar(100), 
	@_fromEmail varchar(250),
	@_fromName nvarchar(150),
	@_toEmail varchar(250),
	@_toName nvarchar(150),
	@_htmlBody text,
	@_subject nvarchar(100)
)
as
BEGIN
	insert into Email 
		(ClientId, FromEmail, FromName, ToEmail, ToName, Subject, HtmlBody)
	values 
		(@_clientId, @_fromEmail, @_fromName, @_toEmail, @_toName, @_subject, @_htmlBody)
END
GO
