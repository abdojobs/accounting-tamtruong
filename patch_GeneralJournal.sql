USE [Ketoan]
GO

/****** Object:  Index [PK__GeneralJournal__09DE7BCC]    Script Date: 11/25/2013 16:13:42 ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[GeneralJournal]') AND name = N'PK__GeneralJournal__09DE7BCC')
ALTER TABLE [dbo].[GeneralJournal] DROP CONSTRAINT [PK__GeneralJournal__09DE7BCC]
GO

ALTER TABLE [GeneralJournal]
DROP COLUMN Id


Alter Table [GeneralJournal]
ALTER COLUMN Account_Id int NOT NULL


Alter Table [GeneralJournal]
ALTER COLUMN Proceducetype_Id int NOT NULL

ALTER TABLE [GeneralJournal]
ADD CONSTRAINT pk_ProceduceId_AccountId_ProceduceTypeId PRIMARY KEY
(
	Proceduce_Id,
	Account_Id,
	Proceducetype_Id
)


