CREATE TABLE [dbo].[Users]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), 
    [FirstName] VARCHAR(150) NULL, 
    [LastName] VARCHAR(150) NULL, 
    [Phone] VARCHAR(20) NULL, 
    [Email] VARCHAR(150) NULL, 
    [Password] VARCHAR(150) NULL, 
    [CreatedDate] DATETIME NULL, 
    [LastUpdate] DATETIME NULL, 
    [LastUpdated] TIMESTAMP NULL 
)

GO

CREATE TRIGGER [dbo].[Trigger_Users_UpdateDateTime]
    ON [dbo].[Users]
    FOR DELETE, INSERT, UPDATE
    AS
    BEGIN
        SET NoCount ON
        UPDATE tab
        SET LastUpdate=GETDATE()
        FROM dbo.Users tab
            LEFT JOIN inserted ins on ins.Id=tab.Id

    END