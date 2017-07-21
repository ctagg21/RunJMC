USE RunJMC
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetAllTags')
      DROP PROCEDURE GetAllTags
GO

CREATE PROCEDURE GetAllTags AS
BEGIN
	SELECT TagId, TagName
	FROM Tags
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'AddTag')
      DROP PROCEDURE AddTag
GO

CREATE PROCEDURE AddTag (
	
	@TagName nvarchar(20)
	
) AS
BEGIN
	INSERT INTO Tags (TagName)
	VALUES (@TagName);

	
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetAllCategories')
      DROP PROCEDURE GetAllCategories
GO

CREATE PROCEDURE GetAllCategories AS
BEGIN
	SELECT CategoryId, CategoryName
	FROM Categories
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'AddCategory')
      DROP PROCEDURE AddCategory
GO

CREATE PROCEDURE AddCategory (
	
	@CategoryName nvarchar(20)
	
) AS
BEGIN
	INSERT INTO Categories (CategoryName)
	VALUES (@CategoryName);

	
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetAllEntries')
      DROP PROCEDURE GetAllEntries
GO

CREATE PROCEDURE GetAllEntries AS
BEGIN
	SELECT EntryId, Content, IsApproved, PublishDate, CategoryId, UserId, Title, IsStatic
	FROM Entries
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetEntryById')
      DROP PROCEDURE GetEntryById
GO

CREATE PROCEDURE GetEntryById (
	@EntryId int
) AS
BEGIN
	SELECT EntryId, Content, IsApproved, PublishDate, CategoryId, UserId, Title, IsStatic
	FROM Entries
	WHERE EntryId = @EntryId
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetEntriesByTag')
      DROP PROCEDURE GetEntriesByTag
GO

CREATE PROCEDURE GetEntriesByTag (
	@TagId int
) AS
BEGIN
	SELECT e.EntryId, Content, IsApproved, PublishDate, CategoryId, UserId, Title, IsStatic
	FROM Entries e
	INNER JOIN EntriesTags et ON et.EntryId = e.EntryId
	INNER JOIN Tags t ON et.TagId = t.TagId
	WHERE t.TagId = @TagId
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetEntriesByCategory')
      DROP PROCEDURE GetEntriesByCategory
GO

CREATE PROCEDURE GetEntriesByCategory (
	@CategoryId int
) AS
BEGIN
	SELECT EntryId, Content, IsApproved, PublishDate, CategoryId, UserId, Title, IsStatic
	FROM Entries
	WHERE CategoryId = @CategoryId
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'AddEntry')
      DROP PROCEDURE AddEntry
GO

CREATE PROCEDURE AddEntry (
	
	@Content nvarchar(max),
	@IsApproved bit,
	@CategoryId int,
	@UserId nvarchar(128),
	@Title nvarchar(50),
	@IsStatic bit
) AS
BEGIN
	INSERT INTO Entries (Content, IsApproved, CategoryId, UserId, Title, IsStatic, PublishDate)
	VALUES (@Content, @IsApproved, @CategoryId, @UserId, @Title, @IsStatic, getdate());

	
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'UpdateEntry')
      DROP PROCEDURE UpdateEntry
GO

CREATE PROCEDURE UpdateEntry (
	@EntryId int,
	@Content nvarchar(max),
	@IsApproved bit,
	@CategoryId int,
	@Title nvarchar(50),
	@IsStatic bit
) AS
BEGIN
	UPDATE Entries SET 
		Content = @Content, 
		IsApproved = @IsApproved, 
		CategoryId = @CategoryId, 
		Title = @Title,
		IsStatic = @IsStatic
	WHERE EntryId = @EntryId
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DeleteEntry')
      DROP PROCEDURE DeleteEntry
GO

CREATE PROCEDURE DeleteEntry (
	@EntryId int
) AS
BEGIN
	BEGIN TRANSACTION

	DELETE FROM EntriesTags WHERE EntryId = @EntryId
	DELETE FROM Entries WHERE EntryId = @EntryId;

	COMMIT TRANSACTION
END
GO