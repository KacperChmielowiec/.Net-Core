CREATE PROCEDURE [dbo].[spUser_Delete]
	@Id int
AS
begin

	delete from users
	where Id = @Id;

end
