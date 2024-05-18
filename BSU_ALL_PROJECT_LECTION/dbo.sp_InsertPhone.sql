CREATE PROCEDURE [dbo].[sp_InsertPhone]
    @title nchar(10),
    @company nchar(10),
    @price int,
    @Id int out
AS
    INSERT INTO pHONES(Title, Company, Price)
    VALUES (@title, @company,@price)
  
    SET @Id=SCOPE_IDENTITY()