CREATE TABLE [dbo].[SalesPerson]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [SalesPersonID] INT NOT NULL, 
    [FName] NVARCHAR(50) NOT NULL, 
    [LName] NVARCHAR(50) NOT NULL, 
    [Address] NVARCHAR(250) NOT NULL, 
    [Phone] NVARCHAR(15) NOT NULL, 
    [StartDate] DATETIME NOT NULL, 
    [TerminationDate] DATETIME NOT NULL, 
    [Manager] NVARCHAR(100) NOT NULL
)
