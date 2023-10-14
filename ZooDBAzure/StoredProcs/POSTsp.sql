CREATE PROCEDURE [dbo].[POSTsp]
  @name varchar(35),
  @species varchar(8),
  @height INT,
  @weight INT
AS
  INSERT INTO dbo.Animals([Name], Species, Height, [Weight])
  Values(@name, @species, @height, @weight)
RETURN 0
