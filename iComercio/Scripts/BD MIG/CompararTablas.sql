Alter Procedure CompararTablas
AS
BEGIN

DECLARE @CantAnt int
DECLARE @CantNueva int

Create Table #resultados
(
    Tabla nvarchar(50),
	CantAnt int,
	CantNueva int,
	Diferencia as (CantAnt-CantNueva)
)

SELECT @CantAnt = count(CDocumento) from [ComerFinanMig].dbo.Clientes
SELECT @CantNueva = count(Documento) from [ComercioMig].dbo.Cliente

Insert into #resultados (Tabla,CantAnt,CantNueva) values ('Clientes',@CantAnt,@CantNueva)

SELECT @CantAnt = count(Cdomicilio) from [ComerFinanMig].dbo.Clientes
SELECT @CantAnt =  @CantAnt + count(CdomicilioE) from [ComerFinanMig].dbo.Clientes
SELECT @CantNueva = count(DomicilioID) from [ComercioMig].dbo.Domicilio

Insert into #resultados (Tabla,CantAnt,CantNueva) values ('Domicilio',@CantAnt,@CantNueva)

SELECT @CantAnt = count(CTelefono1) from [ComerFinanMig].dbo.Clientes where ( not CTelefono1 is null)
SELECT @CantAnt =  @CantAnt + count(CTelefono2) from [ComerFinanMig].dbo.Clientes where ( not CTelefono2 is null)
SELECT @CantAnt =  @CantAnt + count(CTelefonoE) from [ComerFinanMig].dbo.Clientes where ( not CTelefonoE is null)
SELECT @CantNueva = count(TelefonoID) from [ComercioMig].dbo.Telefono

Insert into #resultados (Tabla,CantAnt,CantNueva) values ('Telefonos',@CantAnt,@CantNueva)

SELECT @CantAnt = count(mail) from [ComerFinanMig].dbo.Clientes where ( not mail is null AND mail <> '' and mail <> ' ')
SELECT @CantNueva = count(MailID) from [ComercioMig].dbo.Mail

Insert into #resultados (Tabla,CantAnt,CantNueva) values ('Mail',@CantAnt,@CantNueva)



SELECT @CantAnt = count(CNotas) from [ComerFinanMig].dbo.Clientes where (not CNotas is null AND CNotas <> '' AND CNotas <> ' ')
SELECT @CantNueva = count(NotaID) from [ComercioMig].dbo.Nota

Insert into #resultados (Tabla,CantAnt,CantNueva) values ('Nota',@CantAnt,@CantNueva)


Select * from #resultados

drop table #resultados

END




