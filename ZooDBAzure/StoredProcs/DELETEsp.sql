CREATE PROCEDURE [dbo].[DELETEsp]
  @name varchar(35),
  @species varchar(8)
AS
  DELETE
  FROM dbo.Animals
  WHERE 
  [Name] = @name AND
  Species = @species
  RETURN 0
