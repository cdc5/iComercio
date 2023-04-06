USE [ComercioMig]
GO
/****** Object:  UserDefinedFunction [dbo].[Apellido]    Script Date: 02/12/2021 16:25:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER FUNCTION [dbo].[Apellido](@NombreComp nvarchar(max))
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
	set @res = @apellido
	END
ELSE 
	BEGIN
		set @res = @NombreComp
	END
RETURN @res 
END

