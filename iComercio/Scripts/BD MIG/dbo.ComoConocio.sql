USE [ComercioMig]
GO
/****** Object:  UserDefinedFunction [dbo].[ComoConocio]    Script Date: 02/12/2021 16:26:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER FUNCTION [dbo].[ComoConocio](@Conocio nvarchar(max))
RETURNS nvarchar(max) AS
BEGIN

DECLARE @res nvarchar(max)

	IF @Conocio <> '' AND @Conocio <> null AND @Conocio <> '.' AND @Conocio <> '***'
	   AND @Conocio <> '0' AND @Conocio <> '139' AND @Conocio <> '2' AND @Conocio <> '321'
	   AND @Conocio <> '44' AND @Conocio <> '467' AND @Conocio <> '52' AND @Conocio <> '59'
	   AND @Conocio <> '6003' AND @Conocio <> 'l'AND @Conocio <> 'Vacio'
	BEGIN
		if (@Conocio = 'MSJ. TEXTO')
			SET  @Conocio = 'SMS';
		if (@Conocio = 'LLAM. TELEFONICA')
			SET @Conocio = 'TELEVENTA' 
	END
	Select TOP 1  @res = TipoComoConocioID from TipoComoConocio where Nombre = @Conocio
	IF @res IS NULL
		SET  @res = 'J' --OTRO
RETURN @res 
END