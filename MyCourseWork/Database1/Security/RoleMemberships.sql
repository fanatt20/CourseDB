ALTER ROLE [db_ddladmin] ADD MEMBER [libraryAdmin];


GO
ALTER ROLE [db_datareader] ADD MEMBER [ReadOnlyUser];


GO
ALTER ROLE [db_datareader] ADD MEMBER [ReadWriteUser];


GO
ALTER ROLE [db_datareader] ADD MEMBER [libraryAdmin];


GO
ALTER ROLE [db_datawriter] ADD MEMBER [ReadWriteUser];


GO
ALTER ROLE [db_datawriter] ADD MEMBER [libraryAdmin];

