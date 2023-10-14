CREATE PROCEDURE [dbo].[UPDATEsp]
  @name varchar(35),
  @species varchar(8),
  @height INT,
  @weight INT
AS
  UPDATE dbo.Animals
  SET [Name] = @name, Species = @species, Height = @height, [Weight] = @weight
RETURN 0
