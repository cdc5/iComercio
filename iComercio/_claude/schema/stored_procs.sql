USE [ComercioPru4002]
GO
/****** Object:  StoredProcedure [dbo].[ACobrar]    Script Date: 29/3/2026 11:29:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[ACobrar]
AS
Begin
	Select  ComercioID,
			Year(FechaVencimiento) Año,
			Month(FechaVencimiento) Mes,
			CAST(sum(importe) as money) Cuota,
			CAST(sum(importepago)as money) Pagado,
			CAST(sum(importePagoPunitorios)as money) Punitorios,
			CAST(sum(deuda)as money) Deuda
	From Cuota
	Group by ComercioID,Year(FechaVencimiento),Month(FechaVencimiento)
	order by ComercioID,Year(FechaVencimiento),Month(FechaVencimiento)
END		
GO
/****** Object:  StoredProcedure [dbo].[ActualizarCreditoABonificado]    Script Date: 29/3/2026 11:29:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create Procedure [dbo].[ActualizarCreditoABonificado](@credito int,@comercio int)
AS
BEGIN

Declare @cantCuotas int
Declare @cuotasBoni int
Declare @valorCuota decimal

Select @cantCuotas = CantidadCuotas, @valorCuota = ValorCuota from Credito where Creditoid = @credito and comercioid = @comercio

IF @cantCuotas = 12
	BEGIN
		set @cuotasBoni = 3
	END
IF @cantCuotas = 9 
	BEGIN
		set @cuotasBoni = 2
	END
IF @cantCuotas = 6
	BEGIN
		set @cuotasBoni = 1
	END

Update Credito set TipoBonificacionID = 'X', PorcentajeBonificacion = @cuotasBoni, ValorBonificacion = @valorCuota * @cuotasBoni
where Creditoid = @credito and comercioid = @comercio

END
GO
/****** Object:  StoredProcedure [dbo].[CobradoDelMes]    Script Date: 29/3/2026 11:29:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[CobradoDelMes]
AS
BEGIN
Select Comercioid,
	   YEAR(cob.FechaVencimiento) Año,
	   MONTH(cob.FechaVencimiento) Mes, 
	   CAST(sum(cob.ImportePago) as money) Cobrado,
	   CAST(sum(cob.ImportePagoPunitorios)as money) PunitoriosCobrados,
	   CAST(sum(cob.ImportePago + cob.ImportePagoPunitorios) as money) Total	   
from  Cobranza cob 
group by Comercioid,YEAR(cob.FechaVencimiento), MONTH(cob.FechaVencimiento)
order by Comercioid,YEAR(cob.FechaVencimiento), MONTH(cob.FechaVencimiento)
END
GO
/****** Object:  StoredProcedure [dbo].[CobradoEnElMes]    Script Date: 29/3/2026 11:29:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[CobradoEnElMes]
AS
BEGIN
Select Comercioid,
	   YEAR(cob.FechaPago) Año,
	   MONTH(cob.FechaPago) Mes, 
	   CAST(sum(cob.ImportePago) as money) Cobrado,
	   CAST(sum(cob.ImportePagoPunitorios)as money) PunitoriosCobrados,
	   CAST(sum(cob.ImportePago + cob.ImportePagoPunitorios) as money) Total	   
from  Cobranza cob 
group by Comercioid,YEAR(cob.FechaPago), MONTH(cob.FechaPago)
order by Comercioid,YEAR(cob.FechaPago), MONTH(cob.FechaPago)
END
GO
/****** Object:  StoredProcedure [dbo].[MI_RegistrosPorFila]    Script Date: 29/3/2026 11:29:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[MI_RegistrosPorFila]
AS
BEGIN

--2008 r2	
SELECT o.name,
  ddps.row_count 
FROM sys.indexes AS i
  INNER JOIN sys.objects AS o ON i.OBJECT_ID = o.OBJECT_ID
  INNER JOIN sys.dm_db_partition_stats AS ddps ON i.OBJECT_ID = ddps.OBJECT_ID
  AND i.index_id = ddps.index_id 
WHERE i.index_id < 2  AND o.is_ms_shipped = 0 ORDER BY o.NAME 


--2000
-- Shows all user tables and row counts for the current database 
-- Remove OBJECTPROPERTY function call to include system objects 
--SELECT o.NAME,
--  i.rowcnt 
--FROM sysindexes AS i
--  INNER JOIN sysobjects AS o ON i.id = o.id 
--WHERE i.indid < 2  AND OBJECTPROPERTY(o.id, 'IsMSShipped') = 0
--ORDER BY o.NAME


--Con un SP
--CREATE TABLE #counts
--(
--    table_name varchar(255),
--    row_count int
--)

--EXEC sp_MSForEachTable @command1='INSERT #counts (table_name, row_count) SELECT ''?'', COUNT(*) FROM ?'
--SELECT table_name, row_count FROM #counts ORDER BY table_name, row_count DESC
--DROP TABLE #counts
END

GO
/****** Object:  StoredProcedure [dbo].[ObtenerCreditosYTasa]    Script Date: 29/3/2026 11:29:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ObtenerCreditosYTasa]
AS
Begin
select Comercioid, CAST(sum(valornominal) as money) [VALORNOM],
CAST(sum(interes)  as money)[INTERES],
CAST(sum(valornominal) + sum(interes)  as money) [CAP+INTERES],
CAST((sum(valornominal) + sum(interes))/avg(cantidadcuotas)  as money)[CAP+INTERES/CUOTAS],
count(*) [CANT],
 min(fechasolicitud) [FECHA INICIO SOLICITUD],
 max(cantidadcuotas) [MAXIMA CANTIDAD DE CUOTAS],
 min(cantidadcuotas) [MINIMA CANTIDAD DE CUOTAS],
 avg(cantidadcuotas) [PROM CANTIDAD DE CUOTAS] from creditos 
 group by ComercioID
 order by ComercioID

 
Select 
ComercioID,
Year(fechasolicitud) Año,
Month(FechaSolicitud) Mes,
CAST(sum(valornominal) as money) [VALORNOM],
CAST(sum(interes)  as money)[INTERES],
CAST(sum(valornominal) + sum(interes)  as money) [CAP+INTERES],
CAST((sum(valornominal) + sum(interes))/avg(cantidadcuotas)  as money)[CAP+INTERES/CUOTAS],
count(*) [CANT],
 min(fechasolicitud) [FECHA INICIO SOLICITUD],
 max(cantidadcuotas) [MAXIMA CANTIDAD DE CUOTAS],
 min(cantidadcuotas) [MINIMA CANTIDAD DE CUOTAS],
 avg(cantidadcuotas) [PROM CANTIDAD DE CUOTAS] from creditos 
 group by comercioid,Year(fechasolicitud), Month(FechaSolicitud)
 order by comercioid,Year(fechasolicitud), Month(FechaSolicitud)

 Select	 comercioid,
		 creditoid,
		 fechasolicitud,
		 CAST(valornominal as money),
		 CAST(interes as money),
		 CAST(interes/valornominal *100 as money),
		 cantidadcuotas,
		 CAST((interes/valornominal *100)/cantidadcuotas as money)from creditos
 order by comercioid,fechasolicitud asc


 END
GO
/****** Object:  StoredProcedure [dbo].[Planes_ActualizarFechaVencimiento]    Script Date: 29/3/2026 11:29:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Planes_ActualizarFechaVencimiento](@PlanesTipoID nvarchar(20),@nuevaFecha DateTime)
as
BEGIN

update planesvenci set fechavenci = @nuevaFecha where [PlanesTipoID] = @PlanesTipoID 
update planesBonif set fechavenci = @nuevaFecha where [PlanesTipoID] = @PlanesTipoID 
update planesDetalle set fechavenci = @nuevaFecha where [PlanesTipoID] = @PlanesTipoID 

END
GO
