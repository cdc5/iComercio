USE [Comercio55]
GO
/****** Object:  StoredProcedure [dbo].[sp_Walrus_AltasBajas_CTACTE]    Script Date: 15/09/2022 22:11:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_Walrus_AltasBajas_CTACTE](@Comer int,
									 @FechaDesde DateTime,
									 @FechaHasta DateTime)
AS
BEGIN



					SELECT      
				
						year(cr.FechaComercioAnula) AS [AÑO]
						,MONTH(cr.FechaComercioAnula) as [MES]
						,DAY(cr.FechaComercioAnula)  as [DIA]
						,CAST( COUNT(cr.CreditoID)	 as int) as [CANTIDAD]
						,CAST(SUM(cr.ValorNominal) as money) as [VALORNOMINAL]


						,CAST(SUM(ISNULL((CASE WHEN cr.TipoRetencionPlanID = 'G' THEN cr.Gasto END) ,0)) as money ) as [GASTO_RETENIDO]
						,CAST(SUM(ISNULL((CASE WHEN cr.TipoRetencionPlanID = 'A' THEN cr.Gasto END) ,0)) as money ) as [GASTO_RETENIDO2]
						,CAST(SUM(ISNULL((CASE WHEN cr.TipoRetencionPlanID = 'C' THEN 
									CASE WHEN cr.TipoCuotaID  = 'A' THEN cr.ValorCuota END
									END) ,0)) as money ) as [CUOTA_RETENIDO]

						,CAST(SUM(ISNULL((CASE WHEN cr.TipoRetencionPlanID = 'A' THEN 
									CASE WHEN cr.TipoCuotaID  = 'A' THEN cr.ValorCuota END
									END) ,0)) as money ) as [CUOTA_RETENIDOA]
						,CAST(SUM(cr.Comision) as money) as [COMISION]
						--CAST(SUM(cr.ValorCuota) as money) as [IMPORTECUOTAS]
						--,CAST(SUM(cr.Gasto) as money) as [GASTO]
						--,CAST(SUM(cr.Interes) as money) as [INTERES]
						--,CAST(SUM(cr.Comision) as money) as [COMISION]
						--,CAST(SUM(cr.ValorBonificacion) as money) as [BONIFICACION]
						--,@Comer as  [COMERCIO]
			
					FROM CreditoAnulado cr
					WHERE cr.FechaComercioAnula >= @FechaDesde AND cr.FechaComercioAnula < @FechaHasta AND cr.ComercioID = @Comer
					GROUP BY  YEAR( cr.FechaComercioAnula), MONTH( cr.FechaComercioAnula) ,DAY(cr.FechaComercioAnula)
					ORDER BY  1 ,2,3
				END

		



