CREATE TABLE [dbo].[Animals]
(
  [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  [Name] VARCHAR(35) UNIQUE,
  [Species] VARCHAR(8),
  [Height] INT,
  [Weight] INT,
  [Happiness] INT
)