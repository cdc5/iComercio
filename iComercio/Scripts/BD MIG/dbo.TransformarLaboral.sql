USE [ComercioMig]
GO
/****** Object:  UserDefinedFunction [dbo].[TransformarLaboral]    Script Date: 02/12/2021 16:28:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER FUNCTION [dbo].[TransformarLaboral](@CCodEmpleo nvarchar(max),@CComLab nvarchar(max))
RETURNS nvarchar(max) AS
BEGIN

DECLARE @res nvarchar(max)

IF @CComLab <> ''
BEGIN
	Select TOP 1  @res = ProfesionID from Profesion where ProfesionID = @CComLab
END
ELSE
	IF @CCodEmpleo <> ''
	BEGIN
		SET @res = @CCodEmpleo
		IF @CCodEmpleo = 'POL'
			SET @res = 'PO'
		ELSE IF @CCodEmpleo = 'MUN'
			SET @res = 'MU'
		ELSE IF @CCodEmpleo = 'DOP' OR @CCodEmpleo = 'DON'
			SET @res = 'DO'
		ELSE IF @CCodEmpleo = '' OR @CCodEmpleo = 'AAA'
			SET @res = 'S/N'
		Else
			SET @res = 'S/N'
	END
RETURN @res 
END

