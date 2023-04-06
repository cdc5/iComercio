Create Procedure CargarCreditos(@Empresa int)
AS
BEGIN

INSERT INTO [dbo].[Credito]
           ([EmpresaID]
           ,[ComercioID]
           ,[CreditoID]
           ,[Documento]
           ,[TipoDocumentoID]
           ,[ValorNominal]
           ,[ValorCuota]
           ,[FechaSolicitud]
           ,[Total]
           ,[Interes]
           ,[Gasto]
           ,[Comision]
           ,[Cancelado]
           ,[Garante1]
           ,[TipoDocumentoIDG1]
           ,[Garante2]
           ,[TipoDocumentoIDG2]
           ,[Garante3]
           ,[TipoDocumentoIDG3]
           ,[Adicional]
           ,[TipoDocumentoIDAdi]
           ,[Avalado]
           ,[usuarioAvalID]
           ,[UsuarioAvalAnt]
           ,[TipoCuotaID]
           ,[CantidadCuotas]
           ,[NroInformeContel]
           ,[AbogadoID]
           ,[FechaAbogado]
           ,[UsuarioID]
           ,[UsuarioAnt]
           ,[PcComer]
           ,[FechaComer]
           ,[TipoBonificacionID]
           ,[PorcentajeBonificacion]
           ,[ValorBonificacion]
           ,[TasaPlan]
           ,[IncrementoPlan]
           ,[GastoPlan]
           ,[GastoIncrementoPlan]
           ,[GastoFijo]
           ,[ComisionPlan]
           ,[ComisionIncrementoPlan]
           ,[TipoRetencionPlanID]
           ,[NombrePlan]
           ,[Puntaje]
           ,[DiasVenciPrimerCuota]
           ,[RefinanciacionID]
           ,[AvisoDePagoID]
           ,[Corte]
           ,[FechaAviso]
           ,[NumCuentaBancaria]
           ,[FechaDesdeDebito])
     SELECT
           @Empresa,
           [KComercio],
           [KCredito],
           [KDocumento],
           [KCodDocu],
           [KValorNom],
           [KValorCuota]
           [KFechSoli],
           ([KValorCuota] * [KCuotas]),
           [KInteresImp],
           [KGastoImp],
           [KComisionImp],
           [KCancelado],
           [KGarante1],
           [KCodDocuG1],
           [KGarante2],
           [KCodDocuG2],
           [KGarante3],
           [KCodDocuG3],
           [CodAdi],
           [DocuAdi],
           [KAvalado],
       --    dbo.UsuarioAval([UsuAval]) ,
           [DocuAdi],
           [KTipCuota],
           [KCuotas],
           [NroInf],
           [KAbogado],
           [kFechaAbo],
         --  dbo.Usuario([Usuario]),
           [Usuario],
           [PC_comer],
           [hora_comer],
           [TipoBoni],
           [PorBoni],
           NULL,
           [KTasa],
           0,
           [KGasto],
           0,
           0,
           [KComision],
           0,
           [KRetencion],
           NULL,
           0,
        --   Convertir(INTEGER,[KVenci],'')
           --BuscarRefi,<RefinanciacionID, int,>
           null,
           --DeterminarCorte,<Corte, int,>
           --DateAdd(fechasoli, diascorte) 0001-01-01 00:00:00.0000000
           null
           '0001-01-01 00:00:00.0000000'

		   
    
	  FROM [ComerFinanMig].dbo.Creditos s LEFT OUTER join ComercioMig.dbo.Credito i
      on s.kComercio = i.ComercioID and s.kCredito = i.CreditoID where i.CreditoID is null



	  END