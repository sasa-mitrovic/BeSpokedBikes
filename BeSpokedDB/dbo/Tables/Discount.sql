CREATE TABLE [dbo].[Discount]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [DiscountID] INT NOT NULL, 
    [BeginDate] DATETIME NOT NULL, 
    [EndDate] DATETIME NOT NULL, 
    [DiscountPercentage] DECIMAL(18, 2) NOT NULL
)
