USE RunJMC
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='EntriesTags')
	DROP TABLE EntriesTags
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Entries')
	DROP TABLE Entries
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Tags')
	DROP TABLE Tags
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Categories')
	DROP TABLE Categories
GO

CREATE TABLE Categories (
CategoryId int identity(1,1) not null primary key,
CategoryName nvarchar(20) not null)

CREATE TABLE Tags (
TagId int identity(1,1) not null primary key,
TagName nvarchar(20) not null)

CREATE TABLE Entries (
EntryId int identity(1,1) not null primary key,
Content nvarchar(max) not null,
IsApproved bit not null,
PublishDate datetime2 not null default  (getdate()),
CategoryId int not null foreign key references Categories(CategoryId),
UserId nvarchar(128) not null foreign key references AspNetUsers(Id),
Title nvarchar(50) not null,
IsStatic bit)

CREATE TABLE EntriesTags (
	EntryID INT NOT NULL,
	TagID INT NOT NULL,
	CONSTRAINT PK_EntriesTags
		PRIMARY KEY (EntryID, TagID),
	CONSTRAINT FK_Tags_EntriesTags
		FOREIGN KEY (TagID) 
		REFERENCES Tags(TagID),
	CONSTRAINT FK_EntriesTags_EntriesTags
		FOREIGN KEY (EntryID) 
		REFERENCES Entries(EntryID),
)
 