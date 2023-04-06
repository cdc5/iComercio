USE [ComercioMig]
GO
/****** Object:  StoredProcedure [dbo].[CargarClientes]    Script Date: 02/12/2021 14:20:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Procedure [dbo].[CargarClientes] (@empresa int)
AS
BEGIN
--Clientes
INSERT INTO [dbo].[Cliente]
           ([Documento]
           ,[TipoDocumentoID]
           ,[Nombre]
           ,[Apellido]
           ,[ProfesionID]
           ,[EmpresaLaboral]
           ,[Sueldo]
           ,[Legajo]
           ,[FechaNacimiento]
           ,[SexoID]
           ,[FechaAlta]
           ,[TipoComoConocioID]
           ,[Puntaje]
           ,[Tarjeta]
           ,[FechaAltaTarjeta]
           ,[FechaVencimientoTarjeta]
           ,[FechaModificacion]
           ,[UsuarioModificacionID]
           ,[EstadoID]
           ,[NombreCompleto]
           ,[Zona]
           ,[Cod1]
           ,[Cod2]
           ,[Cuit])
    Select  CDocumento,
			CCodDocu,
			dbo.Nombre(CNombre),
			dbo.apellido(CNombre),
			dbo.TransformarLaboral(CCodEmpleo,Ccomlab),
			cempresa,
			csueldo,
			legajo,
			cfechanaci,	
			csexo,
			getdate(),
			dbo.ComoConocio(conocio),
			0,
			etique,
			fetiq,
			null,
			null,
			null,
			84,
			cnombre,
			null,
			null,
			null,
			null
from [ComerFinanMig].dbo.Clientes where CDocumento not in 
                                          (Select Documento from ComercioMig.dbo.Cliente)

--dom cliente									  
INSERT INTO [dbo].[Domicilio]
           ([Direccion]
           ,[Numero]
           ,[Piso]
           ,[Departamento]
           ,[Complemento]
           ,[NotasDomicilio]
           ,[LocalidadID]
           ,[ProvinciaID]
           ,[PaisId]
           ,[ClaseDatoID]
           ,[EstadoID]
           ,[EmpresaID]
           ,[ComercioID]
           ,[Documento]
           ,[TipoDocumentoID]
           ,[Fecha]
           ,[UsuarioID]
           ,[PcComer]
           ,[DomicilioCompleto])
SELECT     null,
		   null,
		   null,
		   null,
		   null,
		   cdomicilio + ' ' + clocalidad +' ' + dbo.ObtenerProvinciaDesdeClave(cprovincia),
		   null,
		   null,
		   null,
		   1,
		   85,
		   @empresa,
		   null,
		   cdocumento,
		   ccoddocu,		   
		   Getdate(),
		   1,
		   null,
		   null
from [ComerFinanMig].dbo.Clientes 


--Dom Empresa									  
INSERT INTO [dbo].[Domicilio]
           ([Direccion]
           ,[Numero]
           ,[Piso]
           ,[Departamento]
           ,[Complemento]
           ,[NotasDomicilio]
           ,[LocalidadID]
           ,[ProvinciaID]
           ,[PaisId]
           ,[ClaseDatoID]
           ,[EstadoID]
           ,[EmpresaID]
           ,[ComercioID]
           ,[Documento]
           ,[TipoDocumentoID]
           ,[Fecha]
           ,[UsuarioID]
           ,[PcComer]
           ,[DomicilioCompleto])
SELECT     null,
		   null,
		   null,
		   null,
		   null,
		   cdomicilioe + ' ' + clocalidade +' ' + dbo.ObtenerProvinciaDesdeClave(cprovinciae),
		   null,
		   null,
		   null,
		   2,
		   85,
		   @empresa,
		   null,
		   cdocumento,
		   ccoddocu,		   
		   Getdate(),
		   1,
		   null,
		   null
from [ComerFinanMig].dbo.Clientes --where CDocumento not in (Select Documento from ComercioMig.dbo.Cliente)
    
    
--Telefonos 1
INSERT INTO [dbo].[Telefono]
           ([CodArea]
           ,[Numero]
           ,[esCelular]
           ,[EstadoID]
           ,[ClaseDatoID]
           ,[Documento]
           ,[TipoDocumentoID]
           ,[EmpresaID]
           ,[ComercioID]
           ,[Fecha]
           ,[Nota]
           ,[UsuarioID]
           ,[PcComer]
           ,[TelefonoCompleto])
SELECT  null,
		ctelefono1,
		null,
		85,
		1,
		cdocumento,
		ccoddocu,
		@empresa,
		null,
		getdate(),
		null,
		1,
		null,
		null
from [ComerFinanMig].dbo.Clientes
where not ctelefono1 is null

	 
--Telefonos 2
INSERT INTO [dbo].[Telefono]
           ([CodArea]
           ,[Numero]
           ,[esCelular]
           ,[EstadoID]
           ,[ClaseDatoID]
           ,[Documento]
           ,[TipoDocumentoID]
           ,[EmpresaID]
           ,[ComercioID]
           ,[Fecha]
           ,[Nota]
           ,[UsuarioID]
           ,[PcComer]
           ,[TelefonoCompleto])
SELECT  null,
		ctelefono2,
		null,
		85,
		1,
		cdocumento,
		ccoddocu,
		@empresa,
		null,
		getdate(),
		null,
		1,
		null,
		null
from [ComerFinanMig].dbo.Clientes
where not ctelefono2 is null

--Telefonos Empresa
INSERT INTO [dbo].[Telefono]
           ([CodArea]
           ,[Numero]
           ,[esCelular]
           ,[EstadoID]
           ,[ClaseDatoID]
           ,[Documento]
           ,[TipoDocumentoID]
           ,[EmpresaID]
           ,[ComercioID]
           ,[Fecha]
           ,[Nota]
           ,[UsuarioID]
           ,[PcComer]
           ,[TelefonoCompleto])
SELECT  null,
		ctelefonoe,
		null,
		85,
		2,
		cdocumento,
		ccoddocu,
		@empresa,
		null,
		getdate(),
		null,
		1,
		null,
		null
from [ComerFinanMig].dbo.Clientes
where not ctelefonoe is null

--mail
INSERT INTO [dbo].[Mail]
           ([Direccion]
           ,[ClaseDatoID]
           ,[EstadoID]
           ,[Documento]
           ,[TipoDocumentoID]
           ,[EmpresaID]
           ,[ComercioID]
           ,[Fecha]
           ,[Nota]
           ,[UsuarioID]
           ,[PcComer])
     SELECT mail,
			1,
			85,
			cdocumento,
			ccoddocu,
			@empresa,
			null,
			getdate(),
			null,
			1,
			null	 
	 from [ComerFinanMig].dbo.Clientes
	 where not mail is null AND mail <> '' AND mail <>' '

	 
INSERT INTO [dbo].[Nota]
           ([EmpresaID]
           ,[Documento]
           ,[TipoDocumentoID]
           ,[ComercioID]
           ,[CreditoID]
           ,[CuotaID]
           ,[CobranzaID]
           ,[Detalle]
           ,[UsuarioID]
           ,[Fecha])
     SELECT @empresa,
			cdocumento,
			ccoddocu,
			null,
			null,
			null,
			null,
		    cnotas,
			1,
			getdate()
	 from [ComerFinanMig].dbo.Clientes
	 where (not CNotas is null AND CNotas <> '' AND CNotas <> ' ')

END


