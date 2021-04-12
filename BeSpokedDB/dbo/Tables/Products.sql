CREATE TABLE [dbo].[Products]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [ProductID] INT NOT NULL,
    [ProductName] NVARCHAR(50) NOT NULL, 
    [Manufacturer] NVARCHAR(50) NOT NULL, 
    [Style] NVARCHAR(50) NOT NULL, 
    [PurchasePrice] MONEY NOT NULL, 
    [SalePrice] MONEY NOT NULL, 
    [Qty] INT NOT NULL, 
    [CommissionPercentage] DECIMAL(18, 4) NOT NULL
)
