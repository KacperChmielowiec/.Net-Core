CREATE PROCEDURE [dbo].[spGet_ById]
	@Id int
AS

begin

	select FirstName, LastName from users
	where Id=@Id;
	

end
