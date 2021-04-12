CREATE TABLE [dbo].[Sales]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ProductID] INT NOT NULL, 
    [SalesPersonID] INT NOT NULL, 
    [CustomerID] INT NOT NULL, 
    [SaleDate] DATETIME NOT NULL
)
