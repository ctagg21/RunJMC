USE RunJMC
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DbReset')
      DROP PROCEDURE DbReset
GO

CREATE PROCEDURE DbReset AS
BEGIN
	DELETE FROM EntriesTags;
	DELETE FROM Entries;
	DELETE FROM Tags;
	DELETE FROM Categories;
	DELETE FROM AspNetUsers WHERE id IN ('00000000-0000-0000-0000-000000000000', '11111111-1111-1111-1111-111111111111');

	
	INSERT INTO AspNetUsers(Id, EmailConfirmed, PhoneNumberConfirmed, Email, TwoFactorEnabled, LockoutEnabled, AccessFailedCount, UserName)
	VALUES('00000000-0000-0000-0000-000000000000', 0, 0, 'test@test.com', 0, 0, 0, 'test');

	INSERT INTO AspNetUsers(Id, EmailConfirmed, PhoneNumberConfirmed, Email, TwoFactorEnabled, LockoutEnabled, AccessFailedCount, UserName)
	VALUES('11111111-1111-1111-1111-111111111111', 0, 0, 'test2@test.com', 0, 0, 0, 'test2');

	SET IDENTITY_INSERT Categories ON;

INSERT INTO Categories (CategoryId, CategoryName)
	VALUES (1, 'Science'),
	(2, 'Sports'),
	(3, 'History'),
	(4, 'Pop Culture');

	SET IDENTITY_INSERT Categories OFF;

	SET IDENTITY_INSERT Tags ON;

INSERT INTO Tags (TagId, TagName)
	VALUES (1, 'Centipede'),
	(2, 'Football'),
	(3, 'Fun'),
	(4, 'Gettysburg');

	SET IDENTITY_INSERT Tags OFF;

	SET IDENTITY_INSERT Entries ON;

INSERT INTO Entries (EntryId, Content, IsApproved, CategoryId, UserId, Title)
	VALUES (1, '<p>Test entry</p>', 1, 1, '00000000-0000-0000-0000-000000000000', 'Test Title'),
	(2, '<p>Another test entry</p>', 1, 3, '00000000-0000-0000-0000-000000000000', 'Test Title2');
	
	SET IDENTITY_INSERT Entries OFF;

INSERT INTO EntriesTags(EntryId, TagId)
	VALUES (1, 1),
	(1, 2),
	(2, 4),
	(2, 2);

	END