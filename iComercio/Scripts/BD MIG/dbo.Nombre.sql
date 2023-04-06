USE [ComercioMig]
GO
/****** Object:  UserDefinedFunction [dbo].[Nombre]    Script Date: 02/12/2021 16:26:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER FUNCTION [dbo].[Nombre](@NombreComp nvarchar(max))
RETURNS nvarchar(max) AS
BEGIN

Declare @apellido nvarchar(max)
Declare @nombre nvarchar(max)
DECLARE @pos int
DECLARE @len int
DECLARE @res nvarchar(max)

set @pos =Charindex(' ',@NombreComp)
IF @pos <> 0
BEGIN
	
	set @apellido = LEFT(@NombreComp,@pos)
	set @len = LEN(@NombreComp)
	set @nombre = RIGHT(@NombreComp,@len-@pos)
	set @res = @nombre
END
ELSE 
	BEGIN
		set @res = @NombreComp
	END
RETURN @res 
END
