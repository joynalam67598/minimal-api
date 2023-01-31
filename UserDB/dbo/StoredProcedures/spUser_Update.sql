CREATE PROCEDURE [dbo].[spUser_Update]
	@Id int,
	@FirstName nvarchar(50),
	@LastName nvarchar(20)
AS
begin
	Update dbo.[User] set FirstName = @FirstName, LastName = @LastName where Id = @Id;
end
