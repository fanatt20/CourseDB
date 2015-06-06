CREATE PROCEDURE [dbo].[RoleUser]
AS
SET NOCOUNT ON

declare @curUser nvarchar(30)
declare @t table(UserName nvarchar(50), RoleName nvarchar(50), LoginName nvarchar(50), DefDBName nvarchar(50), DefSchemaName nvarchar(50), UserID smallint, [SID]  varbinary(100)) 
declare @Role nvarchar(50) 
 
set @curUser = USER

insert into @t
EXEC sp_helpuser @curUser

select RoleName from @t
