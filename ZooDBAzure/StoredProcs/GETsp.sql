CREATE PROCEDURE [dbo].[GETsp]
  @name varchar(35),
  @species varchar(8)
AS
  SELECT [Name], Species, Height, [Weight], Happiness
  FROM dbo.Animals a
  WHERE 
  a.[Name] = @name AND
  a.Species = @species

