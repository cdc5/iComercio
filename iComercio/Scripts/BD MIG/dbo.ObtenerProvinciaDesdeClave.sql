USE [ComercioMig]
GO
/****** Object:  UserDefinedFunction [dbo].[ObtenerProvinciaDesdeClave]    Script Date: 02/12/2021 16:27:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER FUNCTION [dbo].[ObtenerProvinciaDesdeClave](@clave nvarchar(3))
RETURNS nvarchar(max) AS
BEGIN

DECLARE @res nvarchar(max)


SET @res = CASE @clave
            WHEN 'B' THEN 'BUENOS AIRES'
			WHEN 'C' THEN 'CAPITAL FEDERAL'
            WHEN 'I' THEN 'CATAMARCA'
            WHEN 'G' THEN 'CHACO'
            WHEN 'W' THEN 'CHUBUT'
            WHEN 'P' THEN 'CORDOBA'
			WHEN 'N' THEN 'CORRIENTES'
			WHEN 'O' THEN 'ENTRE RIOS'
			WHEN 'F' THEN 'FORMOSA'
			WHEN 'D' THEN 'JUJUY'
			WHEN 'T' THEN 'LA PAMPA'
		    WHEN 'Q' THEN 'LA RIOJA'
			WHEN 'M' THEN 'MENDOZA'
			WHEN 'L' THEN 'MISIONES'
			WHEN 'U' THEN 'NEUQUEN'
			WHEN 'V' THEN 'RIO NEGRO'
			WHEN 'E' THEN 'SALTA'
			WHEN 'R' THEN 'SAN JUAN'
			WHEN 'S' THEN 'SAN LUIS'
			WHEN 'X' THEN 'SANTA CRUZ'
			WHEN 'H' THEN 'SANTIAGO DEL ESTERO'
			WHEN 'Y' THEN 'TIERRA DEL FUEGO'
			WHEN 'J' THEN 'TUCUMAN'
		END

RETURN @res 
END

