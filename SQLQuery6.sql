CREATE TABLE [dbo].[RafaelMembers] (
    ID int NOT NULL IDENTITY,
	[Name] TEXT NULL,
	[PhoneNum] TEXT NULL,
	[HomeAddress] TEXT NULL,
	[WorkSite] TEXT NULL,
	[HasCar] INT NULL
	PRIMARY KEY CLUSTERED ([Id] ASC)
);