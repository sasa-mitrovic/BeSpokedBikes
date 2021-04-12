﻿CREATE TABLE [dbo].[Customer]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CustomerID] INT NOT NULL,
    [FName] NVARCHAR(50) NOT NULL, 
    [LName] NVARCHAR(50) NOT NULL, 
    [Address] NVARCHAR(250) NOT NULL, 
    [Phone] NVARCHAR(15) NOT NULL, 
    [StartDate] DATETIME NOT NULL
)