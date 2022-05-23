IF (NOT EXISTS (SELECT 1 FROM [dbo].[users]))
BEGIN
	INSERT INTO [dbo].[users] (FirstName,LastName) values('Tim','Corey');
END