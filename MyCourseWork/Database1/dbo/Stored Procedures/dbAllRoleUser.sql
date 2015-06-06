CREATE PROCEDURE [dbo].[dbAllRoleUser]
	
AS
BEGIN
	
	
	declare @curUser Varchar(30);
	set @curUser = SYSTEM_USER;

    EXEC sp_helpuser @curUser
END