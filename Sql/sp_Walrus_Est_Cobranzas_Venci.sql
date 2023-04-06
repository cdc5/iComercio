USE [Comercio55]
GO
/****** Object:  StoredProcedure [dbo].[sp_Walrus_Est_Cobranzas_Pago_Venci]    Script Date: 15/09/2022 22:13:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_Walrus_Est_Cobranzas_Venci](@Comer int,
									 @FechaDesde DateTime,
									 @FechaHasta DateTime)
AS
BEGIN
SELECT      
						year(cob.FechaVencimiento) AS [AÑO],
						MONTH(cob.FechaVencimiento) as [MES],
						Day(cob.FechaVencimiento) as [DIA],
						CAST( COUNT(cob.CreditoID) as int) as [CANTIDAD],
						CAST(SUM(cob.ImportePago) as money) as [IMPORTE],
						CAST(SUM(cob.ImportePagoPunitorios) as money) as [PUNITORIO],
						CAST(SUM(cob.Interes) as money) as [INTERESES],
						@Comer as  [COMERCIO]
						,CAST(SUM(ISNULL((CASE WHEN notcd.Detalle = 'BONIFICADO' THEN notcd.Importe END) ,0)) as money ) as [NOTABONI]
						,CAST(SUM(ISNULL((CASE WHEN notcd.Detalle = 'ANTICIPADO' THEN notcd.Importe END) ,0)) as money ) as [NOTAANTI]
						,CAST(SUM(ISNULL((CASE WHEN notcd.Detalle = 'ANULADA' THEN notcd.Importe END) ,0)) as money ) as [NOTAANULADA]
				
					FROM Cobranza cob
					LEFT join NotasCD notcd ON  cob.ComercioID = notcd.ComercioID AND cob.CreditoID = notcd.CreditoID AND cob.CuotaID = notcd.CuotaID AND cob.CobranzaID = notcd.CobranzaID    
					WHERE cob.FechaVencimiento >= @FechaDesde AND cob.FechaVencimiento < @FechaHasta AND cob.ComercioID = @Comer
					GROUP BY  YEAR( cob.FechaVencimiento), MONTH( cob.FechaVencimiento), DAY(cob.FechaVencimiento) 
					ORDER BY  1 ,2, 3

END



	--if @PagoVenci = 'V'
	--BEGIN
	--	if @Comer > 0
	--	BEGIN
	--		if @Diario = 0
	--			BEGIN
	--				SELECT      
	--					year(cob.FechaVencimiento) AS [AÑO],
	--					MONTH(cob.FechaVencimiento) as [MES],
	--					0  as [DIA],
	--					CAST( COUNT(cob.CreditoID) as int) as [CANTIDAD],
	--					CAST(SUM(cob.ImportePago) as money) as [IMPORTE],
	--					CAST(SUM(cob.ImportePagoPunitorios) as money) as [PUNITORIO],
	--					CAST(SUM(cob.Interes) as money) as [INTERESES],
	--					@Comer as  [COMERCIO]
	--					,CAST(SUM(ISNULL((CASE WHEN notcd.Detalle = 'BONIFICADO' THEN notcd.Importe END) ,0)) as money ) as [NOTABONI]
	--					,CAST(SUM(ISNULL((CASE WHEN notcd.Detalle = 'ANTICIPADO' THEN notcd.Importe END) ,0)) as money ) as [NOTAANTI]
	--					,CAST(SUM(ISNULL((CASE WHEN notcd.Detalle = 'ANULADA' THEN notcd.Importe END) ,0)) as money ) as [NOTAANULADA]
					
	--				FROM Cobranza cob
	--				LEFT join NotasCD notcd ON  cob.com_id = notcd.ComercioID AND cob.CreditoID = notcd.CreditoID AND cob.CuotaID = notcd.CuotaID AND cob.CobranzaID = notcd.CobranzaID    
	--				WHERE cob.FechaVencimiento >= @FechaDesde AND cob.FechaVencimiento < @FechaHasta AND cob.com_id = @Comer
	--				GROUP BY  YEAR( cob.FechaVencimiento), MONTH( cob.FechaVencimiento) 
	--				ORDER BY  1 ,2
	--			END
	--		if @Diario = 1
	--			BEGIN
	--				SELECT      
	--					year(cob.FechaVencimiento) AS [AÑO],
	--					MONTH(cob.FechaVencimiento) as [MES],
	--					Day(cob.FechaVencimiento) as [DIA],
	--					CAST( COUNT(cob.CreditoID) as int) as [CANTIDAD],
	--					CAST(SUM(cob.ImportePago) as money) as [IMPORTE],
	--					CAST(SUM(cob.ImportePagoPunitorios) as money) as [PUNITORIO],
	--					CAST(SUM(cob.Interes) as money) as [INTERESES],
	--					@Comer as  [COMERCIO]
	--					,CAST(SUM(ISNULL((CASE WHEN notcd.Detalle = 'BONIFICADO' THEN notcd.Importe END) ,0)) as money ) as [NOTABONI]
	--					,CAST(SUM(ISNULL((CASE WHEN notcd.Detalle = 'ANTICIPADO' THEN notcd.Importe END) ,0)) as money ) as [NOTAANTI]
	--					,CAST(SUM(ISNULL((CASE WHEN notcd.Detalle = 'ANULADA' THEN notcd.Importe END) ,0)) as money ) as [NOTAANULADA]
				
	--				FROM Cobranza cob
	--				LEFT join NotasCD notcd ON  cob.com_id = notcd.ComercioID AND cob.CreditoID = notcd.CreditoID AND cob.CuotaID = notcd.CuotaID AND cob.CobranzaID = notcd.CobranzaID    
	--				WHERE cob.FechaVencimiento >= @FechaDesde AND cob.FechaVencimiento < @FechaHasta AND cob.com_id = @Comer
	--				GROUP BY  YEAR( cob.FechaVencimiento), MONTH( cob.FechaVencimiento), DAY(cob.FechaVencimiento) 
	--				ORDER BY  1 ,2, 3
	--			END
	--	END
	--	if @Comer = 0
	--	BEGIN
	--		if @Diario = 0
	--			BEGIN
	--				SELECT      
	--					year(cob.FechaVencimiento) AS [AÑO],
	--					MONTH(cob.FechaVencimiento) as [MES],
	--					0  as [DIA],
	--					CAST( COUNT(cob.CreditoID) as int) as [CANTIDAD],
	--					CAST(SUM(cob.ImportePago) as money) as [IMPORTE],
	--					CAST(SUM(cob.ImportePagoPunitorios) as money) as [PUNITORIO],
	--					CAST(SUM(cob.Interes) as money) as [INTERESES],
	--					@Comer as  [COMERCIO]
	--					,CAST(SUM(ISNULL((CASE WHEN notcd.Detalle = 'BONIFICADO' THEN notcd.Importe END) ,0)) as money ) as [NOTABONI]
	--					,CAST(SUM(ISNULL((CASE WHEN notcd.Detalle = 'ANTICIPADO' THEN notcd.Importe END) ,0)) as money ) as [NOTAANTI]
	--					,CAST(SUM(ISNULL((CASE WHEN notcd.Detalle = 'ANULADA' THEN notcd.Importe END) ,0)) as money ) as [NOTAANULADA]

	--				FROM Cobranza cob
	--				LEFT join NotasCD notcd ON  cob.com_id = notcd.ComercioID AND cob.CreditoID = notcd.CreditoID AND cob.CuotaID = notcd.CuotaID AND cob.CobranzaID = notcd.CobranzaID    
	--				WHERE cob.FechaVencimiento >= @FechaDesde AND cob.FechaVencimiento < @FechaHasta
	--				GROUP BY  YEAR( cob.FechaVencimiento), MONTH( cob.FechaVencimiento) 
	--				ORDER BY  1 ,2
	--			END

	--		if @Diario = 1
	--			BEGIN
	--				SELECT      
	--					year(cob.FechaVencimiento) AS [AÑO],
	--					MONTH(cob.FechaVencimiento) as [MES],
	--					Day(cob.FechaVencimiento) as [DIA],
	--					CAST( COUNT(cob.CreditoID) as int) as [CANTIDAD],
	--					CAST(SUM(cob.ImportePago) as money) as [IMPORTE],
	--					CAST(SUM(cob.ImportePagoPunitorios) as money) as [PUNITORIO],
	--					CAST(SUM(cob.Interes) as money) as [INTERESES],
	--					@Comer as  [COMERCIO]
	--					,CAST(SUM(ISNULL((CASE WHEN notcd.Detalle = 'BONIFICADO' THEN notcd.Importe END) ,0)) as money ) as [NOTABONI]
	--					,CAST(SUM(ISNULL((CASE WHEN notcd.Detalle = 'ANTICIPADO' THEN notcd.Importe END) ,0)) as money ) as [NOTAANTI]
	--					,CAST(SUM(ISNULL((CASE WHEN notcd.Detalle = 'ANULADA' THEN notcd.Importe END) ,0)) as money ) as [NOTAANULADA]

	--				FROM Cobranza cob
	--				LEFT join NotasCD notcd ON  cob.com_id = notcd.ComercioID AND cob.CreditoID = notcd.CreditoID AND cob.CuotaID = notcd.CuotaID AND cob.CobranzaID = notcd.CobranzaID    
	--				WHERE cob.FechaVencimiento >= @FechaDesde AND cob.FechaVencimiento < @FechaHasta
	--				GROUP BY  YEAR( cob.FechaVencimiento), MONTH( cob.FechaVencimiento) , DAY(cob.FechaVencimiento) 
	--				ORDER BY  1 ,2, 3
	--			END
	--		END
	--	END
	--END


	--if @PagoVenci = 'P'
	--BEGIN
	--	if @Comer > 0
	--	BEGIN
	--		if @Diario = 0
	--			BEGIN
	--				SELECT      
	--				year(cob.FechaPago) AS [AÑO],
	--				MONTH(cob.FechaPago) as [MES],
	--				0  as [DIA],
	--				CAST( COUNT(cob.CreditoID) as int) as [CANTIDAD],
	--				CAST(SUM(cob.ImportePago) as money) as [IMPORTE],
	--				CAST(SUM(cob.ImportePagoPunitorios) as money) as [PUNITORIO],
	--				CAST(SUM(cob.Interes) as money) as [INTERESES],
	--				@Comer as  [COMERCIO]
	--				,CAST(SUM(ISNULL((CASE WHEN notcd.Detalle = 'BONIFICADO' THEN notcd.Importe END) ,0)) as money ) as [NOTABONI]
	--				,CAST(SUM(ISNULL((CASE WHEN notcd.Detalle = 'ANTICIPADO' THEN notcd.Importe END) ,0)) as money ) as [NOTAANTI]
	--				,CAST(SUM(ISNULL((CASE WHEN notcd.Detalle = 'ANULADA' THEN notcd.Importe END) ,0)) as money ) as [NOTAANULADA]
			
	--			FROM Cobranza cob
	--				LEFT join NotasCD notcd ON  cob.com_id = notcd.ComercioID AND cob.CreditoID = notcd.CreditoID AND cob.CuotaID = notcd.CuotaID AND cob.CobranzaID = notcd.CobranzaID    
	--			WHERE cob.FechaPago >= @FechaDesde AND cob.FechaPago < @FechaHasta AND cob.com_id = @Comer
	--			GROUP BY  YEAR( cob.FechaPago), MONTH( cob.FechaPago) 
	--			ORDER BY  1 ,2
	--			END
	--		if @Diario = 1
	--			BEGIN
	--				SELECT      
	--				year(cob.FechaPago) AS [AÑO],
	--				MONTH(cob.FechaPago) as [MES],
	--				Day(cob.FechaPago) as [DIA],
	--				CAST( COUNT(cob.CreditoID) as int) as [CANTIDAD],
	--				CAST(SUM(cob.ImportePago) as money) as [IMPORTE],
	--				CAST(SUM(cob.ImportePagoPunitorios) as money) as [PUNITORIO],
	--				CAST(SUM(cob.Interes) as money) as [INTERESES],
	--				@Comer as  [COMERCIO]
	--				,CAST(SUM(ISNULL((CASE WHEN notcd.Detalle = 'BONIFICADO' THEN notcd.Importe END) ,0)) as money ) as [NOTABONI]
	--				,CAST(SUM(ISNULL((CASE WHEN notcd.Detalle = 'ANTICIPADO' THEN notcd.Importe END) ,0)) as money ) as [NOTAANTI]
	--				,CAST(SUM(ISNULL((CASE WHEN notcd.Detalle = 'ANULADA' THEN notcd.Importe END) ,0)) as money ) as [NOTAANULADA]
				
	--			FROM Cobranza cob
	--				LEFT join NotasCD notcd ON  cob.com_id = notcd.ComercioID AND cob.CreditoID = notcd.CreditoID AND cob.CuotaID = notcd.CuotaID AND cob.CobranzaID = notcd.CobranzaID    
	--			WHERE cob.FechaPago >= @FechaDesde AND cob.FechaPago < @FechaHasta AND cob.com_id = @Comer
	--			GROUP BY  YEAR( cob.FechaPago), MONTH( cob.FechaPago), DAY(cob.FechaPago) 
	--			ORDER BY  1 ,2, 3
	--			END
	--	END
	--	if @Comer = 0
	--	BEGIN
	--		if @Diario = 0
	--			BEGIN
	--				SELECT      
	--				year(cob.FechaPago) AS [AÑO],
	--				MONTH(cob.FechaPago) as [MES],
	--				0  as [DIA],
	--				CAST( COUNT(cob.CreditoID) as int) as [CANTIDAD],
	--				CAST(SUM(cob.ImportePago) as money) as [IMPORTE],
	--				CAST(SUM(cob.ImportePagoPunitorios) as money) as [PUNITORIO],
	--				CAST(SUM(cob.Interes) as money) as [INTERESES],
	--				@Comer as  [COMERCIO]
	--				,CAST(SUM(ISNULL((CASE WHEN notcd.Detalle = 'BONIFICADO' THEN notcd.Importe END) ,0)) as money ) as [NOTABONI]
	--				,CAST(SUM(ISNULL((CASE WHEN notcd.Detalle = 'ANTICIPADO' THEN notcd.Importe END) ,0)) as money ) as [NOTAANTI]
	--				,CAST(SUM(ISNULL((CASE WHEN notcd.Detalle = 'ANULADA' THEN notcd.Importe END) ,0)) as money ) as [NOTAANULADA]

	--			FROM Cobranza cob
	--				LEFT join NotasCD notcd ON  cob.com_id = notcd.ComercioID AND cob.CreditoID = notcd.CreditoID AND cob.CuotaID = notcd.CuotaID AND cob.CobranzaID = notcd.CobranzaID    
	--			WHERE cob.FechaPago >= @FechaDesde AND cob.FechaPago < @FechaHasta
	--			GROUP BY  YEAR( cob.FechaPago), MONTH( cob.FechaPago) 
	--			ORDER BY  1 ,2
	--			END

	--		if @Diario = 1
	--			BEGIN
	--				SELECT      
	--				year(cob.FechaPago) AS [AÑO],
	--				MONTH(cob.FechaPago) as [MES],
	--				Day(cob.FechaPago) as [DIA],
	--				CAST( COUNT(cob.CreditoID) as int) as [CANTIDAD],
	--				CAST(SUM(cob.ImportePago) as money) as [IMPORTE],
	--				CAST(SUM(cob.ImportePagoPunitorios) as money) as [PUNITORIO],
	--				CAST(SUM(cob.Interes) as money) as [INTERESES],
	--				@Comer as  [COMERCIO]
	--				,CAST(SUM(ISNULL((CASE WHEN notcd.Detalle = 'BONIFICADO' THEN notcd.Importe END) ,0)) as money ) as [NOTABONI]
	--				,CAST(SUM(ISNULL((CASE WHEN notcd.Detalle = 'ANTICIPADO' THEN notcd.Importe END) ,0)) as money ) as [NOTAANTI]
	--				,CAST(SUM(ISNULL((CASE WHEN notcd.Detalle = 'ANULADA' THEN notcd.Importe END) ,0)) as money ) as [NOTAANULADA]

	--			FROM Cobranza cob
	--				LEFT join NotasCD notcd ON  cob.com_id = notcd.ComercioID AND cob.CreditoID = notcd.CreditoID AND cob.CuotaID = notcd.CuotaID AND cob.CobranzaID = notcd.CobranzaID    
	--			WHERE cob.FechaPago >= @FechaDesde AND cob.FechaPago < @FechaHasta
	--			GROUP BY  YEAR( cob.FechaPago), MONTH( cob.FechaPago) , DAY(cob.FechaPago) 
	--			ORDER BY  1 ,2, 3
	--			END
	--	END
	--END
