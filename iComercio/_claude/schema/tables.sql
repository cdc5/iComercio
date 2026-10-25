USE [master]
GO
/****** Object:  Database [ComercioPru4002]    Script Date: 29/3/2026 11:28:52 ******/
CREATE DATABASE [ComercioPru4002]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ComercioPru', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ComercioPru4002.mdf' , SIZE = 16576KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ComercioPru_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ComercioPru4002_log.ldf' , SIZE = 70976KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ComercioPru4002] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ComercioPru4002].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ComercioPru4002] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ComercioPru4002] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ComercioPru4002] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ComercioPru4002] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ComercioPru4002] SET ARITHABORT OFF 
GO
ALTER DATABASE [ComercioPru4002] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ComercioPru4002] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ComercioPru4002] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ComercioPru4002] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ComercioPru4002] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ComercioPru4002] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ComercioPru4002] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ComercioPru4002] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ComercioPru4002] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ComercioPru4002] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ComercioPru4002] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ComercioPru4002] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ComercioPru4002] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ComercioPru4002] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ComercioPru4002] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ComercioPru4002] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ComercioPru4002] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ComercioPru4002] SET RECOVERY FULL 
GO
ALTER DATABASE [ComercioPru4002] SET  MULTI_USER 
GO
ALTER DATABASE [ComercioPru4002] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ComercioPru4002] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ComercioPru4002] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ComercioPru4002] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ComercioPru4002] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ComercioPru4002] SET QUERY_STORE = OFF
GO
USE [ComercioPru4002]
GO
/****** Object:  User [comer]    Script Date: 29/3/2026 11:28:52 ******/
CREATE USER [comer] FOR LOGIN [comer] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[CuentaCorriente]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CuentaCorriente](
	[EmpresaID] [int] NOT NULL,
	[ComercioID] [int] NOT NULL,
	[CuentaCorrienteID] [bigint] IDENTITY(1,1) NOT NULL,
	[IDRemoto] [bigint] NULL,
	[TipoMovimientoID] [int] NULL,
	[Fecha] [datetime] NOT NULL,
	[SolicitudFondoID] [bigint] NULL,
	[CreditoID] [int] NULL,
	[CuotaID] [int] NULL,
	[CobranzaID] [int] NULL,
	[NotaCDID] [int] NULL,
	[TransferenciaDepositoID] [bigint] NULL,
	[ReciboID] [int] NULL,
	[Importe] [decimal](18, 2) NOT NULL,
	[GestionID] [int] NULL,
	[FechaAviso] [datetime] NULL,
	[CreditoNro] [int] NULL,
	[GastoID] [int] NULL,
	[PagoID] [int] NULL,
 CONSTRAINT [PK_dbo.CuentaCorriente] PRIMARY KEY CLUSTERED 
(
	[EmpresaID] ASC,
	[ComercioID] ASC,
	[CuentaCorrienteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[cc]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[cc]
AS
SELECT        TOP (100) PERCENT Importe, Fecha, GestionID, EmpresaID, ComercioID, CuentaCorrienteID, IDRemoto, TipoMovimientoID, SolicitudFondoID, CreditoID, CuotaID, CobranzaID, NotaCDID, ReciboID, 
                         TransferenciaDepositoID, CreditoNro, FechaAviso, GastoID, PagoID
FROM            dbo.CuentaCorriente
ORDER BY Importe DESC


GO
/****** Object:  Table [dbo].[Cobranza]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cobranza](
	[EmpresaID] [int] NOT NULL,
	[ComercioID] [int] NOT NULL,
	[CreditoID] [int] NOT NULL,
	[CuotaID] [int] NOT NULL,
	[CobranzaID] [int] NOT NULL,
	[Documento] [int] NOT NULL,
	[TipoDocumentoID] [nvarchar](128) NOT NULL,
	[ImportePago] [decimal](19, 2) NOT NULL,
	[ImportePagoPunitorios] [decimal](19, 2) NOT NULL,
	[Interes] [decimal](19, 2) NOT NULL,
	[PunitoriosCalc] [decimal](19, 2) NULL,
	[FechaPago] [datetime2](7) NOT NULL,
	[FechaVencimiento] [datetime2](7) NOT NULL,
	[TipoPagoID] [nvarchar](128) NULL,
	[TipoBonificacionID] [nvarchar](128) NULL,
	[PorcentajeBonificacion] [decimal](19, 2) NULL,
	[PagoRev] [bit] NOT NULL,
	[FechaRev] [datetime2](7) NULL,
	[CobranzaIDRev] [int] NULL,
	[Motivo] [nvarchar](100) NULL,
	[GestionEmpresaID] [int] NOT NULL,
	[GestionID] [int] NOT NULL,
	[RefinanciacionCobranzaID] [int] NOT NULL,
	[UsuarioID] [int] NOT NULL,
	[PcComer] [nvarchar](max) NULL,
	[ImporteTotal] [decimal](18, 2) NOT NULL,
	[ImporteCapital] [decimal](18, 2) NOT NULL,
	[NotasBoni] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Cobranza] PRIMARY KEY CLUSTERED 
(
	[EmpresaID] ASC,
	[ComercioID] ASC,
	[CreditoID] ASC,
	[CuotaID] ASC,
	[CobranzaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[Cobranzas]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Cobranzas]
AS
SELECT        ImporteTotal, FechaPago, GestionID, EmpresaID, ComercioID, CreditoID, CuotaID, CobranzaID, Documento, TipoDocumentoID, ImportePago, ImportePagoPunitorios, Interes, PunitoriosCalc, FechaVencimiento, 
                         TipoPagoID, TipoBonificacionID, PorcentajeBonificacion, PagoRev, FechaRev, CobranzaIDRev, Motivo, GestionEmpresaID, RefinanciacionCobranzaID, UsuarioID, PcComer, NotasBoni, ImporteCapital
FROM            dbo.Cobranza

GO
/****** Object:  Table [dbo].[Credito]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Credito](
	[EmpresaID] [int] NOT NULL,
	[ComercioID] [int] NOT NULL,
	[CreditoID] [int] NOT NULL,
	[Documento] [int] NOT NULL,
	[TipoDocumentoID] [nvarchar](128) NOT NULL,
	[ValorNominal] [decimal](19, 2) NOT NULL,
	[ValorCuota] [decimal](19, 2) NOT NULL,
	[FechaSolicitud] [datetime2](7) NOT NULL,
	[Total] [decimal](19, 2) NOT NULL,
	[Interes] [decimal](19, 2) NOT NULL,
	[Gasto] [decimal](19, 2) NOT NULL,
	[Comision] [decimal](19, 2) NOT NULL,
	[Cancelado] [bit] NOT NULL,
	[Garante1] [int] NULL,
	[TipoDocumentoIDG1] [nvarchar](128) NULL,
	[Garante2] [int] NULL,
	[TipoDocumentoIDG2] [nvarchar](128) NULL,
	[Garante3] [int] NULL,
	[TipoDocumentoIDG3] [nvarchar](128) NULL,
	[Adicional] [int] NULL,
	[TipoDocumentoIDAdi] [nvarchar](128) NULL,
	[Avalado] [bit] NOT NULL,
	[usuarioAvalID] [int] NULL,
	[UsuarioAvalAnt] [nvarchar](max) NULL,
	[TipoCuotaID] [nvarchar](128) NULL,
	[CantidadCuotas] [int] NOT NULL,
	[NroInformeContel] [int] NULL,
	[AbogadoID] [int] NULL,
	[FechaAbogado] [datetime2](7) NOT NULL,
	[UsuarioID] [int] NOT NULL,
	[UsuarioAnt] [nvarchar](max) NULL,
	[PcComer] [nvarchar](max) NULL,
	[FechaComer] [datetime2](7) NOT NULL,
	[TipoBonificacionID] [nvarchar](128) NULL,
	[PorcentajeBonificacion] [decimal](19, 2) NULL,
	[ValorBonificacion] [decimal](18, 2) NULL,
	[TasaPlan] [decimal](19, 2) NOT NULL,
	[IncrementoPlan] [decimal](19, 2) NOT NULL,
	[GastoPlan] [decimal](19, 2) NOT NULL,
	[GastoIncrementoPlan] [decimal](19, 2) NOT NULL,
	[GastoFijo] [bit] NOT NULL,
	[ComisionPlan] [decimal](19, 2) NOT NULL,
	[ComisionIncrementoPlan] [decimal](19, 2) NOT NULL,
	[TipoRetencionPlanID] [nvarchar](max) NULL,
	[NombrePlan] [nvarchar](50) NULL,
	[Puntaje] [decimal](18, 2) NULL,
	[DiasVenciPrimerCuota] [int] NOT NULL,
	[RefinanciacionID] [int] NULL,
	[AvisoDePagoID] [int] NULL,
	[Corte] [int] NOT NULL,
	[FechaAviso] [datetime2](7) NOT NULL,
	[NumCuentaBancaria] [nvarchar](max) NULL,
	[FechaDesdeDebito] [datetime2](7) NOT NULL,
	[AdelantadaGastos] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_dbo.Credito] PRIMARY KEY CLUSTERED 
(
	[EmpresaID] ASC,
	[ComercioID] ASC,
	[CreditoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[Creditos]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Creditos]
AS
SELECT        EmpresaID, ComercioID, CreditoID, Documento, TipoDocumentoID, ValorNominal, ValorCuota, FechaSolicitud, Interes, Gasto, Comision, Cancelado, Garante1, TipoDocumentoIDG1, Garante2, TipoDocumentoIDG2, 
                         Garante3, TipoDocumentoIDG3, Adicional, TipoDocumentoIDAdi, Avalado, usuarioAvalID, UsuarioAvalAnt, TipoCuotaID, CantidadCuotas, NroInformeContel, AbogadoID, FechaAbogado, RefinanciacionID, UsuarioID, 
                         UsuarioAnt, PcComer, FechaComer, TipoBonificacionID, PorcentajeBonificacion, ValorBonificacion, TasaPlan, IncrementoPlan, GastoPlan, GastoIncrementoPlan, GastoFijo, ComisionPlan, 
                         ComisionIncrementoPlan, TipoRetencionPlanID, NombrePlan, Puntaje, DiasVenciPrimerCuota, Corte, FechaAviso, NumCuentaBancaria, FechaDesdeDebito
FROM            dbo.Credito

GO
/****** Object:  Table [dbo].[CreditoAnulado]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CreditoAnulado](
	[EmpresaID] [int] NOT NULL,
	[ComercioID] [int] NOT NULL,
	[CreditoAnuladoID] [int] IDENTITY(1,1) NOT NULL,
	[CreditoID] [int] NOT NULL,
	[Documento] [int] NOT NULL,
	[TipoDocumentoID] [nvarchar](128) NOT NULL,
	[ValorNominal] [decimal](19, 2) NOT NULL,
	[ValorCuota] [decimal](19, 2) NOT NULL,
	[FechaSolicitud] [datetime2](7) NOT NULL,
	[Interes] [decimal](19, 2) NOT NULL,
	[Gasto] [decimal](19, 2) NOT NULL,
	[Comision] [decimal](19, 2) NOT NULL,
	[Garante1] [int] NULL,
	[TipoDocumentoIDG1] [nvarchar](max) NULL,
	[Garante2] [int] NULL,
	[TipoDocumentoIDG2] [nvarchar](max) NULL,
	[Garante3] [int] NULL,
	[TipoDocumentoIDG3] [nvarchar](max) NULL,
	[Adicional] [int] NULL,
	[TipoDocumentoIDAdi] [nvarchar](max) NULL,
	[Avalado] [bit] NOT NULL,
	[usuarioAvalID] [int] NULL,
	[TipoCuotaID] [nvarchar](max) NULL,
	[CantidadCuotas] [int] NOT NULL,
	[NroInformeContel] [int] NULL,
	[AbogadoID] [int] NULL,
	[FechaAbogado] [datetime2](7) NOT NULL,
	[UsuarioID] [int] NOT NULL,
	[PcComer] [nvarchar](max) NULL,
	[FechaComer] [datetime2](7) NOT NULL,
	[TipoBonificacionID] [nvarchar](max) NULL,
	[PorcentajeBonificacion] [decimal](19, 2) NULL,
	[ValorBonificacion] [decimal](18, 2) NOT NULL,
	[TasaPlan] [decimal](19, 2) NOT NULL,
	[IncrementoPlan] [decimal](19, 2) NOT NULL,
	[GastoPlan] [decimal](19, 2) NOT NULL,
	[GastoIncrementoPlan] [decimal](19, 2) NOT NULL,
	[GastoFijo] [bit] NOT NULL,
	[ComisionPlan] [decimal](19, 2) NOT NULL,
	[ComisionIncrementoPlan] [decimal](19, 2) NOT NULL,
	[TipoRetencionPlanID] [nvarchar](max) NULL,
	[NombrePlan] [nvarchar](50) NULL,
	[Puntaje] [decimal](18, 2) NULL,
	[DiasVenciPrimerCuota] [int] NOT NULL,
	[RefinanciacionID] [int] NULL,
	[UsuarioIDAnula] [int] NOT NULL,
	[PcComerAnula] [nvarchar](max) NULL,
	[FechaComercioAnula] [datetime2](7) NOT NULL,
	[Motivo] [nvarchar](250) NULL,
	[TipoAnulacionID] [nvarchar](2) NULL,
	[AvisoDePagoID] [int] NULL,
	[Corte] [int] NOT NULL,
	[FechaAviso] [datetime2](7) NOT NULL,
	[NumCuentaBancaria] [nvarchar](max) NULL,
	[FechaDesdeDebito] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_dbo.CreditoAnulado] PRIMARY KEY CLUSTERED 
(
	[EmpresaID] ASC,
	[ComercioID] ASC,
	[CreditoAnuladoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[CreditosAnulados]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[CreditosAnulados]
AS
SELECT        EmpresaID, ComercioID, CreditoID, CreditoAnuladoID, Documento, TipoDocumentoID, ValorNominal, ValorCuota, FechaSolicitud, Interes, Gasto, Comision, Garante1, TipoDocumentoIDG1, Garante2, 
                         TipoDocumentoIDG2, Garante3, TipoDocumentoIDG3, Adicional, TipoDocumentoIDAdi, Avalado, usuarioAvalID, TipoCuotaID, CantidadCuotas, NroInformeContel, AbogadoID, FechaAbogado, UsuarioID, PcComer, 
                         FechaComer, TipoBonificacionID, PorcentajeBonificacion, ValorBonificacion, TasaPlan, IncrementoPlan, GastoPlan, GastoIncrementoPlan, GastoFijo, ComisionPlan, ComisionIncrementoPlan, 
                         TipoRetencionPlanID, NombrePlan, Puntaje, DiasVenciPrimerCuota, RefinanciacionID, UsuarioIDAnula, PcComerAnula, FechaComercioAnula, Motivo, TipoAnulacionID, Corte, FechaAviso, NumCuentaBancaria, 
                         FechaDesdeDebito, AvisoDePagoID
FROM            dbo.CreditoAnulado

GO
/****** Object:  Table [dbo].[Cuota]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cuota](
	[EmpresaID] [int] NOT NULL,
	[ComercioID] [int] NOT NULL,
	[CreditoID] [int] NOT NULL,
	[CuotaID] [int] NOT NULL,
	[Documento] [int] NOT NULL,
	[TipoDocumentoID] [nvarchar](128) NOT NULL,
	[Importe] [decimal](19, 2) NOT NULL,
	[Interes] [decimal](19, 2) NOT NULL,
	[ImportePago] [decimal](19, 2) NOT NULL,
	[ImportePagoPunitorios] [decimal](19, 2) NOT NULL,
	[FechaVencimiento] [datetime2](7) NOT NULL,
	[FechaUltimoPago] [datetime2](7) NULL,
	[TipoCuotaID] [nvarchar](128) NULL,
	[CantidadCuotas] [int] NOT NULL,
	[ValorBonificacion] [decimal](19, 2) NOT NULL,
	[Deuda]  AS ([Importe]-[ImportePago]),
 CONSTRAINT [PK_dbo.Cuota] PRIMARY KEY CLUSTERED 
(
	[EmpresaID] ASC,
	[ComercioID] ASC,
	[CreditoID] ASC,
	[CuotaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Cuotas]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[Cuotas]
AS
SELECT        EmpresaID, ComercioID, CreditoID, CuotaID, Documento, TipoDocumentoID, Importe, Interes, ImportePago, ImportePagoPunitorios, FechaVencimiento, FechaUltimoPago, TipoCuotaID, CantidadCuotas, 
                         ValorBonificacion
FROM            dbo.Cuota


GO
/****** Object:  View [dbo].[Cuotas_mayor_pago]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Cuotas_mayor_pago]
AS
SELECT TOP (100) PERCENT EmpresaID, ComercioID, CreditoID, CuotaID, Documento, TipoDocumentoID, Importe, Interes, ImportePago, ImportePagoPunitorios, FechaVencimiento, FechaUltimoPago, TipoCuotaID, 
                  CantidadCuotas, ValorBonificacion, Deuda
FROM     dbo.Cuota
WHERE  (Deuda < 0)
ORDER BY CreditoID, CuotaID

GO
/****** Object:  Table [dbo].[NotasCD]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NotasCD](
	[EmpresaID] [int] NOT NULL,
	[ComercioID] [int] NOT NULL,
	[CreditoID] [int] NOT NULL,
	[CuotaID] [int] NOT NULL,
	[CobranzaID] [int] NOT NULL,
	[NotaCDID] [int] NOT NULL,
	[TipoNota] [nvarchar](max) NULL,
	[Importe] [decimal](18, 2) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Documento] [int] NOT NULL,
	[TipoDocumentoID] [nvarchar](max) NULL,
	[Detalle] [nvarchar](max) NULL,
	[GestionID] [int] NOT NULL,
	[UsuarioID] [int] NOT NULL,
	[PcComer] [nvarchar](max) NULL,
	[Notas] [nvarchar](30) NULL,
 CONSTRAINT [PK_dbo.NotasCD] PRIMARY KEY CLUSTERED 
(
	[EmpresaID] ASC,
	[ComercioID] ASC,
	[CreditoID] ASC,
	[CuotaID] ASC,
	[CobranzaID] ASC,
	[NotaCDID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[NotaCD]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[NotaCD]
AS
SELECT        EmpresaID, ComercioID, CreditoID, CuotaID, CobranzaID, NotaCDID, TipoNota, Importe, Fecha, Documento, TipoDocumentoID, Detalle, GestionID, UsuarioID, PcComer, Notas
FROM            dbo.NotasCD

GO
/****** Object:  Table [dbo].[Refinanciacion]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Refinanciacion](
	[EmpresaID] [int] NOT NULL,
	[ComercioID] [int] NOT NULL,
	[CreditoID] [int] NOT NULL,
	[RefinanciacionID] [int] NOT NULL,
	[Documento] [int] NOT NULL,
	[TipoDocumentoID] [nvarchar](128) NOT NULL,
	[ValorNominal] [decimal](19, 2) NOT NULL,
	[ValorCuota] [decimal](19, 2) NOT NULL,
	[ValorAdelanto] [decimal](18, 2) NOT NULL,
	[FechaSolicitud] [datetime2](7) NOT NULL,
	[Interes] [decimal](19, 2) NOT NULL,
	[CantidadCuotas] [int] NOT NULL,
	[UsuarioID] [int] NOT NULL,
	[PcComer] [nvarchar](max) NULL,
	[EstadoID] [int] NOT NULL,
	[FechaCreacion] [datetime] NULL,
	[FechaComerAnula] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_dbo.Refinanciacion] PRIMARY KEY CLUSTERED 
(
	[EmpresaID] ASC,
	[ComercioID] ASC,
	[CreditoID] ASC,
	[RefinanciacionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[Refi]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Refi]
AS
SELECT        EmpresaID, ComercioID, CreditoID, RefinanciacionID, Documento, TipoDocumentoID, ValorNominal, ValorCuota, ValorAdelanto, FechaSolicitud, Interes, CantidadCuotas, UsuarioID, PcComer, EstadoID, 
                         FechaCreacion, FechaComerAnula
FROM            dbo.Refinanciacion

GO
/****** Object:  Table [dbo].[RefinanciacionCuota]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RefinanciacionCuota](
	[EmpresaID] [int] NOT NULL,
	[ComercioID] [int] NOT NULL,
	[CreditoID] [int] NOT NULL,
	[RefinanciacionID] [int] NOT NULL,
	[RefinanciacionCuotaID] [int] NOT NULL,
	[Documento] [int] NOT NULL,
	[TipoDocumentoID] [nvarchar](128) NOT NULL,
	[CantidadCuotas] [int] NOT NULL,
	[Importe] [decimal](19, 2) NOT NULL,
	[ImportePago] [decimal](19, 2) NOT NULL,
	[ImportePagoPunitorios] [decimal](19, 2) NOT NULL,
	[FechaVencimiento] [datetime2](7) NOT NULL,
	[FechaUltimoPago] [datetime2](7) NULL,
	[Deuda]  AS ([Importe]-[ImportePago]),
 CONSTRAINT [PK_dbo.RefinanciacionCuota] PRIMARY KEY CLUSTERED 
(
	[EmpresaID] ASC,
	[ComercioID] ASC,
	[CreditoID] ASC,
	[RefinanciacionID] ASC,
	[RefinanciacionCuotaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[RefinanciacionCuotas]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[RefinanciacionCuotas]
AS
SELECT        EmpresaID, ComercioID, CreditoID, RefinanciacionID, RefinanciacionCuotaID, Documento, TipoDocumentoID, CantidadCuotas, Importe, ImportePago, ImportePagoPunitorios, FechaVencimiento, 
                         FechaUltimoPago
FROM            dbo.RefinanciacionCuota

GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Autorizacion]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Autorizacion](
	[EmpresaID] [int] NOT NULL,
	[ComercioID] [int] NOT NULL,
	[AutorizacionID] [bigint] NOT NULL,
	[SolicitudFondoID] [bigint] NULL,
	[EstadoID] [int] NULL,
	[Motivo] [nvarchar](max) NULL,
	[Fecha] [datetime2](7) NULL,
	[PersonaID] [int] NULL,
	[EmpresaNombre] [nvarchar](max) NULL,
	[ConceptoFondosNombre] [nvarchar](max) NULL,
	[TipoSolicitudNombre] [nvarchar](max) NULL,
	[ComercioNombreNum] [nvarchar](max) NULL,
	[OrdenDePagoID] [bigint] NOT NULL,
	[SolicitudFondoFechaPago] [datetime2](7) NOT NULL,
	[ChequeNumCheque] [nvarchar](max) NULL,
	[CuentaBancaria] [nvarchar](max) NULL,
	[CuentaContable] [nvarchar](max) NULL,
	[Importe] [decimal](18, 2) NOT NULL,
	[Observaciones] [nvarchar](max) NULL,
	[NumCajaImpCont] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Autorizacion] PRIMARY KEY CLUSTERED 
(
	[EmpresaID] ASC,
	[ComercioID] ASC,
	[AutorizacionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AvisoDePago]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AvisoDePago](
	[EmpresaID] [int] NOT NULL,
	[ComercioID] [int] NOT NULL,
	[AvisoDePagoID] [int] NOT NULL,
	[FechaPagoAviso] [datetime] NOT NULL,
	[Importe] [decimal](18, 2) NOT NULL,
	[Retencion] [decimal](18, 2) NOT NULL,
	[Comision] [decimal](18, 2) NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[Pagado] [decimal](18, 2) NOT NULL,
	[FechaPagado] [datetime] NOT NULL,
	[CantSolicitudes] [int] NOT NULL,
	[FechaActualizacion] [datetime] NOT NULL,
	[Notas] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AvisoDePago] PRIMARY KEY CLUSTERED 
(
	[EmpresaID] ASC,
	[ComercioID] ASC,
	[AvisoDePagoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Banco]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Banco](
	[BancoID] [int] NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Banco] PRIMARY KEY CLUSTERED 
(
	[BancoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cap]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cap](
	[EmpresaID] [int] NOT NULL,
	[ComercioID] [int] NOT NULL,
	[CapID] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime2](7) NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[Notas] [nvarchar](max) NULL,
	[SolicitudFondoID] [bigint] NULL,
	[Pagado] [decimal](18, 2) NOT NULL,
	[Finalizado] [bit] NOT NULL,
	[EstadoID] [int] NOT NULL,
	[Saldo] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_dbo.Cap] PRIMARY KEY CLUSTERED 
(
	[EmpresaID] ASC,
	[ComercioID] ASC,
	[CapID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CapDetalle]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CapDetalle](
	[EmpresaID] [int] NOT NULL,
	[ComercioID] [int] NOT NULL,
	[CapID] [int] NOT NULL,
	[CapDetalleID] [int] IDENTITY(1,1) NOT NULL,
	[FechaVencimiento] [datetime2](7) NOT NULL,
	[Importe] [decimal](18, 2) NOT NULL,
	[Detalle] [nvarchar](max) NULL,
	[ImportePago] [decimal](18, 2) NOT NULL,
	[Finalizado] [bit] NOT NULL,
	[PendientePago] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_dbo.CapDetalle] PRIMARY KEY CLUSTERED 
(
	[EmpresaID] ASC,
	[ComercioID] ASC,
	[CapID] ASC,
	[CapDetalleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cargo]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cargo](
	[CargoId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
	[SueldoBasico] [decimal](18, 2) NULL,
 CONSTRAINT [PK_dbo.Cargo] PRIMARY KEY CLUSTERED 
(
	[CargoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cheque]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cheque](
	[EmpresaID] [int] NOT NULL,
	[CuentaBancariaID] [int] NOT NULL,
	[ChequeraID] [nvarchar](128) NOT NULL,
	[ChequeID] [nvarchar](128) NOT NULL,
	[Monto] [decimal](18, 2) NULL,
	[TipoChequeID] [int] NULL,
	[EstadoID] [int] NULL,
 CONSTRAINT [PK_dbo.Cheque] PRIMARY KEY CLUSTERED 
(
	[EmpresaID] ASC,
	[CuentaBancariaID] ASC,
	[ChequeraID] ASC,
	[ChequeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Chequera]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chequera](
	[EmpresaID] [int] NOT NULL,
	[CuentaBancariaID] [int] NOT NULL,
	[ChequeraID] [nvarchar](128) NOT NULL,
	[NumTalonario] [nvarchar](max) NULL,
	[NumDesde] [nvarchar](max) NULL,
	[NumHasta] [nvarchar](max) NULL,
	[NumProx] [nvarchar](max) NULL,
	[FechaAlta] [datetime] NULL,
	[EstadoID] [int] NULL,
 CONSTRAINT [PK_dbo.Chequera] PRIMARY KEY CLUSTERED 
(
	[EmpresaID] ASC,
	[CuentaBancariaID] ASC,
	[ChequeraID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClaseCuentaBancaria]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClaseCuentaBancaria](
	[ClaseCuentaBancariaID] [int] NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.ClaseCuentaBancaria] PRIMARY KEY CLUSTERED 
(
	[ClaseCuentaBancariaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClaseDato]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClaseDato](
	[ClaseDatoID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.ClaseDato] PRIMARY KEY CLUSTERED 
(
	[ClaseDatoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClaseMovimiento]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClaseMovimiento](
	[ClaseMovimientoID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
	[Discriminator] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.ClaseMovimiento] PRIMARY KEY CLUSTERED 
(
	[ClaseMovimientoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Documento] [int] NOT NULL,
	[TipoDocumentoID] [nvarchar](128) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Apellido] [nvarchar](max) NULL,
	[ProfesionID] [nvarchar](128) NULL,
	[EmpresaLaboral] [nvarchar](max) NULL,
	[Sueldo] [decimal](18, 2) NULL,
	[Legajo] [nvarchar](max) NULL,
	[FechaNacimiento] [datetime2](7) NULL,
	[SexoID] [nvarchar](128) NULL,
	[FechaAlta] [datetime2](7) NOT NULL,
	[TipoComoConocioID] [nvarchar](128) NULL,
	[Puntaje] [decimal](18, 2) NULL,
	[Tarjeta] [bit] NULL,
	[FechaAltaTarjeta] [datetime2](7) NULL,
	[FechaVencimientoTarjeta] [datetime2](7) NULL,
	[FechaModificacion] [datetime2](7) NULL,
	[UsuarioModificacionID] [int] NULL,
	[EstadoID] [int] NOT NULL,
	[NombreCompleto] [nvarchar](max) NULL,
	[Zona] [nvarchar](max) NULL,
	[Cod1] [nvarchar](max) NULL,
	[Cod2] [nvarchar](max) NULL,
	[Cuit] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Cliente] PRIMARY KEY CLUSTERED 
(
	[Documento] ASC,
	[TipoDocumentoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comercio]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comercio](
	[EmpresaID] [int] NOT NULL,
	[ComercioID] [int] NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
	[Domicilio] [nvarchar](max) NULL,
	[Barrio] [nvarchar](max) NULL,
	[TipoComercioID] [int] NULL,
	[LocalidadID] [int] NULL,
	[ProvinciaID] [int] NULL,
	[PaisId] [int] NULL,
	[Telefono1] [nvarchar](max) NULL,
	[Telefono2] [nvarchar](max) NULL,
	[Recorrido] [int] NULL,
	[Cuit] [nvarchar](max) NULL,
	[Mail1] [nvarchar](max) NULL,
	[Mail2] [nvarchar](max) NULL,
	[CodPromo] [nvarchar](max) NULL,
	[PorPromo] [decimal](18, 2) NULL,
	[PagaBanco] [bit] NULL,
	[Venci] [int] NULL,
	[Corte] [int] NULL,
	[Habilitado] [bit] NULL,
	[Por30] [decimal](19, 4) NULL,
	[Por30M] [decimal](19, 4) NULL,
	[Clave] [nvarchar](max) NULL,
	[Compu] [bit] NULL,
	[Fanta] [nvarchar](max) NULL,
	[Categoria] [nvarchar](max) NULL,
	[Tolerancia] [int] NULL,
	[NumCredito] [int] NULL,
	[NumCliente] [int] NULL,
	[NumRendi] [int] NULL,
	[FechaIngreso] [datetime] NULL,
	[FechaPRendi] [datetime] NULL,
	[Contacto1ID] [int] NULL,
	[Contacto2ID] [int] NULL,
	[Titular1ID] [int] NULL,
	[Titular2ID] [int] NULL,
	[Rubro] [nvarchar](max) NULL,
	[CanLoc] [int] NULL,
	[CanPer] [int] NULL,
	[CanVid] [int] NULL,
	[CtaDep] [nvarchar](max) NULL,
	[ForPag] [nvarchar](max) NULL,
	[OrdCheq] [nvarchar](max) NULL,
	[PerFinan] [nvarchar](max) NULL,
	[LlevaGar] [int] NULL,
	[Notas] [nvarchar](max) NULL,
	[Cuenta] [int] NULL,
	[CredPri] [decimal](18, 2) NULL,
	[CredSeg] [decimal](18, 2) NULL,
	[Consolid] [int] NULL,
	[Trab] [bit] NULL,
	[Refinancia] [bit] NULL,
	[IntRef] [decimal](18, 2) NULL,
	[IntAde] [decimal](18, 2) NULL,
	[IntArr] [decimal](18, 2) NULL,
	[PorSueldo] [decimal](18, 2) NULL,
	[Llp] [bit] NULL,
	[Pm] [bit] NULL,
	[ImpCi] [decimal](18, 2) NULL,
	[FechaCi] [datetime] NULL,
	[ImpCiVta] [decimal](18, 2) NULL,
	[CiVtaFecha] [datetime] NULL,
	[Principal] [bit] NOT NULL,
	[PuedeCobrar] [bit] NOT NULL,
	[Contacto1_PersonaID] [int] NULL,
	[Contacto2_PersonaID] [int] NULL,
	[Titular1_PersonaID] [int] NULL,
	[Titular2_PersonaID] [int] NULL,
	[CantCuoArr] [int] NULL,
	[Actualiza] [bit] NULL,
	[ToleranciaBoni] [int] NULL,
 CONSTRAINT [PK_dbo.Comercio] PRIMARY KEY CLUSTERED 
(
	[EmpresaID] ASC,
	[ComercioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConceptoFondos]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConceptoFondos](
	[ConceptoFondosID] [int] NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
	[MedioDePagoID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.ConceptoFondos] PRIMARY KEY CLUSTERED 
(
	[ConceptoFondosID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConceptoGastos]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConceptoGastos](
	[ConceptoGastosID] [int] NOT NULL,
	[ConceptoGastosIDRemoto] [int] NULL,
	[Nombre] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
	[EstadoID] [int] NOT NULL,
	[Nivel] [int] NULL,
	[NivelFinal] [bit] NOT NULL,
	[ConceptoGastoPadreID] [int] NULL,
 CONSTRAINT [PK_dbo.ConceptoGastos] PRIMARY KEY CLUSTERED 
(
	[ConceptoGastosID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConceptoGastosDepartamento]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConceptoGastosDepartamento](
	[ConceptoGastosDepartamentoID] [int] IDENTITY(1,1) NOT NULL,
	[ConceptoGastosID] [int] NULL,
	[DepartamentoID] [int] NULL,
	[presupuesto] [int] NOT NULL,
	[EstadoID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.ConceptoGastosDepartamento] PRIMARY KEY CLUSTERED 
(
	[ConceptoGastosDepartamentoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConceptoGastosProveedor]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConceptoGastosProveedor](
	[ConceptoGastosProveedorID] [int] IDENTITY(1,1) NOT NULL,
	[ConceptoGastosID] [int] NULL,
	[ProveedorID] [int] NULL,
	[ProveedorSucursalID] [int] NULL,
	[Periodicidad] [int] NULL,
	[EstadoID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.ConceptoGastosProveedor] PRIMARY KEY CLUSTERED 
(
	[ConceptoGastosProveedorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CreditoAval]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CreditoAval](
	[CreditoAvalID] [int] IDENTITY(1,1) NOT NULL,
	[CreditoID] [int] NOT NULL,
	[ComercioID] [int] NOT NULL,
	[EmpresaID] [int] NOT NULL,
	[TipoAvalID] [int] NOT NULL,
	[UsuarioID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.CreditoAval] PRIMARY KEY CLUSTERED 
(
	[CreditoAvalID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CuentaBancaria]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CuentaBancaria](
	[EmpresaID] [int] NOT NULL,
	[CuentaBancariaID] [int] NOT NULL,
	[NumCuenta] [nvarchar](max) NULL,
	[Cbu] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
	[Notas] [nvarchar](max) NULL,
	[FechaAlta] [datetime] NULL,
	[ComercioID] [int] NULL,
	[ClaseCuentaBancariaID] [int] NULL,
	[TipoCuentaBancariaID] [int] NULL,
	[SucursalBancoID] [int] NOT NULL,
	[BancoID] [int] NOT NULL,
	[MonedaID] [int] NULL,
	[EmiteCheque] [bit] NOT NULL,
	[CuentaContable] [nvarchar](max) NULL,
	[EstadoID] [int] NULL,
	[PersonaID] [int] NULL,
	[prov_id] [int] NULL,
	[provsuc_id] [int] NULL,
	[Proveedor_ProveedorID] [int] NULL,
	[ProveedorSucursal_ProveedorSucursalID] [int] NULL,
	[DebitoDirecto] [bit] NOT NULL,
	[orden] [int] NOT NULL,
 CONSTRAINT [PK_dbo.CuentaBancaria] PRIMARY KEY CLUSTERED 
(
	[EmpresaID] ASC,
	[CuentaBancariaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CuentaBancariaCliente]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CuentaBancariaCliente](
	[Documento] [int] NOT NULL,
	[TipoDocumentoID] [nvarchar](128) NOT NULL,
	[NumCuentaBancaria] [nvarchar](128) NOT NULL,
	[CBU] [nvarchar](max) NULL,
	[Alias] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
	[Notas] [nvarchar](max) NULL,
	[FechaAlta] [datetime] NULL,
	[SucursalBancoID] [int] NULL,
	[BancoID] [int] NULL,
	[MonedaID] [int] NULL,
	[EstadoID] [int] NULL,
	[sCuentaBancaria] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.CuentaBancariaCliente] PRIMARY KEY CLUSTERED 
(
	[Documento] ASC,
	[TipoDocumentoID] ASC,
	[NumCuentaBancaria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CuentaCorrienteCorte]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CuentaCorrienteCorte](
	[EmpresaID] [int] NOT NULL,
	[ComercioID] [int] NOT NULL,
	[CuentaCorrienteCorteID] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Saldo] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_dbo.CuentaCorrienteCorte] PRIMARY KEY CLUSTERED 
(
	[EmpresaID] ASC,
	[ComercioID] ASC,
	[CuentaCorrienteCorteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departamento]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departamento](
	[DepartamentoID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
	[ConceptoFondos_ConceptoFondosID] [int] NULL,
 CONSTRAINT [PK_dbo.Departamento] PRIMARY KEY CLUSTERED 
(
	[DepartamentoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Domicilio]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Domicilio](
	[DomicilioID] [int] IDENTITY(1,1) NOT NULL,
	[Direccion] [nvarchar](max) NULL,
	[Numero] [nvarchar](max) NULL,
	[Piso] [nvarchar](max) NULL,
	[Departamento] [nvarchar](max) NULL,
	[Complemento] [nvarchar](max) NULL,
	[NotasDomicilio] [nvarchar](max) NULL,
	[LocalidadID] [int] NULL,
	[ProvinciaID] [int] NULL,
	[PaisId] [int] NULL,
	[ClaseDatoID] [int] NOT NULL,
	[EstadoID] [int] NOT NULL,
	[EmpresaID] [int] NULL,
	[ComercioID] [int] NULL,
	[Documento] [int] NOT NULL,
	[TipoDocumentoID] [nvarchar](128) NULL,
	[Fecha] [datetime2](7) NOT NULL,
	[UsuarioID] [int] NOT NULL,
	[PcComer] [nvarchar](max) NULL,
	[DomicilioCompleto] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Domicilio] PRIMARY KEY CLUSTERED 
(
	[DomicilioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[EmpleadoID] [int] IDENTITY(1,1) NOT NULL,
	[Legajo] [nvarchar](max) NULL,
	[Usuarioid] [int] NULL,
	[Domicilio] [nvarchar](max) NULL,
	[Sueldo] [decimal](18, 2) NULL,
	[Fotografia] [nvarchar](max) NULL,
	[Mail] [nvarchar](max) NULL,
	[Tel] [nvarchar](max) NULL,
	[DepartamentoID] [int] NULL,
	[EmpresaID] [int] NULL,
	[ComercioID] [int] NULL,
	[CargoID] [int] NULL,
	[EstadoId] [int] NULL,
	[PersonaID] [int] NULL,
	[TipoEmpleadoID] [int] NULL,
 CONSTRAINT [PK_dbo.Empleado] PRIMARY KEY CLUSTERED 
(
	[EmpleadoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empresa]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empresa](
	[EmpresaID] [int] NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
	[NombreBase] [nvarchar](max) NULL,
	[Mail] [nvarchar](max) NULL,
	[MailCont] [nvarchar](max) NULL,
	[MailNotificaciones] [nvarchar](max) NULL,
	[MailNotificacionesCont] [nvarchar](max) NULL,
	[ServidorCorreo] [nvarchar](max) NULL,
	[EmpresaDiminutivo] [nvarchar](max) NULL,
	[Cuit] [nvarchar](max) NULL,
	[IIBB] [nvarchar](max) NULL,
	[IA] [nvarchar](max) NULL,
	[Domicilio] [nvarchar](max) NULL,
	[Localidad] [nvarchar](max) NULL,
	[Provincia] [nvarchar](max) NULL,
	[CP] [nvarchar](max) NULL,
	[Telefono1] [nvarchar](max) NULL,
	[Telefono2] [nvarchar](max) NULL,
	[Telefono3] [nvarchar](max) NULL,
	[Telefonos] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Empresa] PRIMARY KEY CLUSTERED 
(
	[EmpresaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estado]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estado](
	[EstadoID] [int] NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
	[TipoEstadoID] [int] NULL,
	[est_color] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Estado] PRIMARY KEY CLUSTERED 
(
	[EstadoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstadoTransmision]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadoTransmision](
	[EstadoTransmisionID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.EstadoTransmision] PRIMARY KEY CLUSTERED 
(
	[EstadoTransmisionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FF]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FF](
	[EmpresaID] [int] NOT NULL,
	[ComercioID] [int] NOT NULL,
	[FFID] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime2](7) NOT NULL,
	[PendienteReposicionSemAnt] [decimal](18, 2) NOT NULL,
	[Remanente] [decimal](18, 2) NOT NULL,
	[TotalGastos] [decimal](18, 2) NOT NULL,
	[MontoFF] [decimal](18, 2) NOT NULL,
	[Repuesto] [decimal](18, 2) NOT NULL,
	[Notas] [nvarchar](max) NULL,
	[EstadoID] [int] NOT NULL,
	[AReponer] [decimal](18, 2) NOT NULL,
	[Pagado] [bit] NOT NULL,
	[SolicitudFondoID] [bigint] NULL,
 CONSTRAINT [PK_dbo.FF] PRIMARY KEY CLUSTERED 
(
	[EmpresaID] ASC,
	[ComercioID] ASC,
	[FFID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FFDetalle]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FFDetalle](
	[EmpresaID] [int] NOT NULL,
	[ComercioID] [int] NOT NULL,
	[FFID] [int] NOT NULL,
	[FFDetalleID] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime2](7) NOT NULL,
	[Importe] [decimal](18, 2) NOT NULL,
	[Detalle] [nvarchar](max) NULL,
	[ImportePago] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_dbo.FFDetalle] PRIMARY KEY CLUSTERED 
(
	[EmpresaID] ASC,
	[ComercioID] ASC,
	[FFID] ASC,
	[FFDetalleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gasto]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gasto](
	[EmpresaID] [int] NOT NULL,
	[ComercioID] [int] NOT NULL,
	[GastoID] [int] IDENTITY(1,1) NOT NULL,
	[SolicitudFondoID] [bigint] NULL,
	[Activo] [bit] NOT NULL,
	[Importe] [decimal](18, 2) NOT NULL,
	[Descripcion] [nvarchar](max) NULL,
	[DepartamentoID] [int] NULL,
	[ConceptoGastoID] [int] NULL,
	[ConceptoGastoProveedorID] [int] NULL,
	[ProveedorID] [int] NULL,
	[ProveedorSucursalID] [int] NULL,
	[Fecha] [datetime2](7) NOT NULL,
	[Pagado] [bit] NOT NULL,
	[EstadoID] [int] NULL,
 CONSTRAINT [PK_dbo.Gasto] PRIMARY KEY CLUSTERED 
(
	[EmpresaID] ASC,
	[ComercioID] ASC,
	[GastoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Localidad]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Localidad](
	[PaisId] [int] NOT NULL,
	[ProvinciaID] [int] NOT NULL,
	[LocalidadID] [int] NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
	[CodPostal] [nvarchar](max) NULL,
	[CodTel] [nvarchar](max) NULL,
	[X] [decimal](18, 2) NULL,
	[Y] [decimal](18, 2) NULL,
 CONSTRAINT [PK_dbo.Localidad] PRIMARY KEY CLUSTERED 
(
	[PaisId] ASC,
	[ProvinciaID] ASC,
	[LocalidadID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Log]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log](
	[LogID] [bigint] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime2](7) NOT NULL,
	[Usuario] [nvarchar](150) NULL,
	[Host] [nvarchar](150) NULL,
	[Mens] [nvarchar](max) NULL,
	[Tipo] [nvarchar](150) NULL,
 CONSTRAINT [PK_dbo.Log] PRIMARY KEY CLUSTERED 
(
	[LogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mail]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mail](
	[MailID] [int] IDENTITY(1,1) NOT NULL,
	[Direccion] [nvarchar](max) NULL,
	[ClaseDatoID] [int] NOT NULL,
	[EstadoID] [int] NOT NULL,
	[Documento] [int] NOT NULL,
	[TipoDocumentoID] [nvarchar](128) NOT NULL,
	[EmpresaID] [int] NULL,
	[ComercioID] [int] NULL,
	[Fecha] [datetime2](7) NOT NULL,
	[Nota] [nvarchar](max) NULL,
	[UsuarioID] [int] NOT NULL,
	[PcComer] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Mail] PRIMARY KEY CLUSTERED 
(
	[MailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MedioDePago]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedioDePago](
	[MedioDePagoID] [int] NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.MedioDePago] PRIMARY KEY CLUSTERED 
(
	[MedioDePagoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Moneda]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Moneda](
	[MonedaID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
	[PaisId] [int] NULL,
	[mon_simbolo] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Moneda] PRIMARY KEY CLUSTERED 
(
	[MonedaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nota]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nota](
	[NotaID] [int] IDENTITY(1,1) NOT NULL,
	[EmpresaID] [int] NOT NULL,
	[Documento] [int] NULL,
	[TipoDocumentoID] [nvarchar](128) NULL,
	[ComercioID] [int] NULL,
	[CreditoID] [int] NULL,
	[CuotaID] [int] NULL,
	[CobranzaID] [int] NULL,
	[Detalle] [nvarchar](max) NULL,
	[UsuarioID] [int] NULL,
	[Fecha] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_dbo.Nota] PRIMARY KEY CLUSTERED 
(
	[NotaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Operacion]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Operacion](
	[OperacionID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
	[Discriminator] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.Operacion] PRIMARY KEY CLUSTERED 
(
	[OperacionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrdenDePago]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdenDePago](
	[OrdenDePagoID] [int] IDENTITY(1,1) NOT NULL,
	[EmpresaID] [int] NULL,
	[Fecha] [datetime] NOT NULL,
	[fecha_pago] [datetime] NOT NULL,
	[importe] [decimal](18, 2) NOT NULL,
	[EstadoID] [int] NULL,
	[ConceptoFondosID] [int] NULL,
 CONSTRAINT [PK_dbo.OrdenDePago] PRIMARY KEY CLUSTERED 
(
	[OrdenDePagoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pago]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pago](
	[EmpresaID] [int] NOT NULL,
	[ComercioID] [int] NOT NULL,
	[PagoID] [int] IDENTITY(1,1) NOT NULL,
	[SolicitudFondoID] [bigint] NULL,
	[CapID] [int] NULL,
	[CapDetalleID] [int] NULL,
	[FFID] [int] NULL,
	[FFDetalleID] [int] NULL,
	[Fecha] [datetime2](7) NOT NULL,
	[Importe] [decimal](18, 2) NOT NULL,
	[EstadoID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Pago] PRIMARY KEY CLUSTERED 
(
	[EmpresaID] ASC,
	[ComercioID] ASC,
	[PagoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pais]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pais](
	[PaisID] [int] NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
	[CodIsoNumerico] [int] NULL,
	[CodIso2] [nvarchar](max) NULL,
	[CodIso3] [nvarchar](max) NULL,
	[DirImaBandera] [nvarchar](max) NULL,
	[CodTel] [nvarchar](max) NULL,
	[X] [decimal](18, 2) NULL,
	[Y] [decimal](18, 2) NULL,
 CONSTRAINT [PK_dbo.Pais] PRIMARY KEY CLUSTERED 
(
	[PaisID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Perfil]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Perfil](
	[PerfilID] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](max) NULL,
	[descripcion] [nvarchar](max) NULL,
	[creacion] [datetime] NOT NULL,
	[activo] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Perfil] PRIMARY KEY CLUSTERED 
(
	[PerfilID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PerfilesPermisos]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerfilesPermisos](
	[PerfilID] [int] NOT NULL,
	[PermisoID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.PerfilesPermisos] PRIMARY KEY CLUSTERED 
(
	[PerfilID] ASC,
	[PermisoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permiso]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permiso](
	[PermisoID] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](max) NULL,
	[descripcion] [nvarchar](max) NULL,
	[creacion] [datetime] NOT NULL,
	[activo] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Permiso] PRIMARY KEY CLUSTERED 
(
	[PermisoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[PersonaID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Apellido] [nvarchar](max) NULL,
	[Documento] [int] NULL,
	[Domicilio] [nvarchar](max) NULL,
	[Fotografia] [nvarchar](max) NULL,
	[LocalidadID] [int] NULL,
	[ProvinciaID] [int] NULL,
	[PaisID] [int] NULL,
	[Telefono1] [nvarchar](max) NULL,
	[Telefono2] [nvarchar](max) NULL,
	[Mail1] [nvarchar](max) NULL,
	[Mail2] [nvarchar](max) NULL,
	[Cel] [nvarchar](max) NULL,
	[Edad] [int] NULL,
	[FechaNacimiento] [datetime] NULL,
	[TiposDocumentoID] [nvarchar](max) NULL,
	[TiposDocumento_TipoDocumentoID] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.Persona] PRIMARY KEY CLUSTERED 
(
	[PersonaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlanesBonif]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlanesBonif](
	[PlanesBonifID] [nvarchar](128) NOT NULL,
	[PlanesTipoID] [nvarchar](20) NULL,
	[EmpresaID] [int] NOT NULL,
	[ComercioID] [int] NOT NULL,
	[TipoBoni] [nvarchar](2) NULL,
	[PorBoni] [decimal](18, 2) NOT NULL,
	[Cuotas_D] [int] NOT NULL,
	[Cuotas_H] [int] NOT NULL,
	[TipoCuota] [nvarchar](1) NULL,
	[nMora] [int] NOT NULL,
	[FechaAlta] [datetime] NOT NULL,
	[FechaVenci] [datetime] NOT NULL,
	[UsuarioID] [int] NOT NULL,
	[UsuarioPC] [nvarchar](30) NULL,
 CONSTRAINT [PK_dbo.PlanesBonif] PRIMARY KEY CLUSTERED 
(
	[PlanesBonifID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlanesDetalle]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlanesDetalle](
	[PlanesDetalleID] [int] IDENTITY(1,1) NOT NULL,
	[PlanesTipoID] [nvarchar](20) NULL,
	[EmpresaID] [int] NOT NULL,
	[ComercioID] [int] NOT NULL,
	[TipoCuota] [nvarchar](max) NULL,
	[Cuotas_D] [int] NOT NULL,
	[Cuotas_H] [int] NOT NULL,
	[SiCreditos] [bit] NOT NULL,
	[nCreditos_D] [int] NOT NULL,
	[nCreditos_H] [int] NOT NULL,
	[SiCancel] [bit] NOT NULL,
	[nCancel_D] [int] NOT NULL,
	[nCancel_H] [int] NOT NULL,
	[SiMora] [bit] NOT NULL,
	[nMora_D] [int] NOT NULL,
	[nMora_H] [int] NOT NULL,
	[SiValor] [bit] NOT NULL,
	[nValor_D] [int] NOT NULL,
	[nValor_H] [int] NOT NULL,
	[Monto_max] [decimal](18, 2) NOT NULL,
	[FechaAlta] [datetime] NOT NULL,
	[FechaVenci] [datetime] NOT NULL,
	[UsuarioID] [int] NOT NULL,
	[UsuarioPC] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.PlanesDetalle] PRIMARY KEY CLUSTERED 
(
	[PlanesDetalleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlanesParam]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlanesParam](
	[PlanesParamId] [int] NOT NULL,
	[Desde] [int] NOT NULL,
	[Hasta] [int] NOT NULL,
	[Valor] [int] NOT NULL,
	[Param1] [nvarchar](40) NULL,
	[Param2] [nvarchar](40) NULL,
	[Orden] [int] NOT NULL,
 CONSTRAINT [PK_dbo.PlanesParam] PRIMARY KEY CLUSTERED 
(
	[PlanesParamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlanesTipo]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlanesTipo](
	[PlanesTipoID] [nvarchar](20) NOT NULL,
	[EmpresaID] [int] NOT NULL,
	[ComercioID] [int] NOT NULL,
	[TipoAV] [nvarchar](1) NULL,
	[PuntoD] [decimal](18, 2) NOT NULL,
	[PuntoH] [decimal](18, 2) NOT NULL,
	[Inter] [decimal](18, 4) NOT NULL,
	[Inter_Incr] [decimal](18, 4) NOT NULL,
	[Gasto] [decimal](18, 2) NOT NULL,
	[Gasto_Incr] [decimal](18, 2) NOT NULL,
	[GastoFijo] [decimal](18, 2) NULL,
	[Comis] [decimal](18, 2) NOT NULL,
	[Comis_Incr] [decimal](18, 2) NOT NULL,
	[MontoMax] [decimal](18, 2) NOT NULL,
	[NroORden] [int] NOT NULL,
	[Notas] [nvarchar](40) NULL,
	[Corte] [int] NOT NULL,
	[TipoRetencionPlanID] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.PlanesTipo] PRIMARY KEY CLUSTERED 
(
	[PlanesTipoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlanesVenci]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlanesVenci](
	[PlanesVenciID] [nvarchar](128) NOT NULL,
	[PlanesTipoID] [nvarchar](20) NULL,
	[CambiaFecha] [bit] NOT NULL,
	[DiasPrimerCuota] [int] NOT NULL,
	[TipoVencimiento] [nvarchar](3) NULL,
	[VenciDia] [int] NOT NULL,
	[VenciCorte] [int] NOT NULL,
	[Corte1] [int] NOT NULL,
	[VenDia1] [int] NOT NULL,
	[Corte2] [int] NOT NULL,
	[Vendia2] [int] NOT NULL,
	[Vendia3] [int] NOT NULL,
	[FechaAlta] [datetime] NOT NULL,
	[FechaVenci] [datetime] NOT NULL,
	[UsuarioID] [int] NOT NULL,
	[UsuarioPC] [nvarchar](30) NULL,
 CONSTRAINT [PK_dbo.PlanesVenci] PRIMARY KEY CLUSTERED 
(
	[PlanesVenciID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profesion]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profesion](
	[ProfesionID] [nvarchar](128) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[ProfesionPadreID] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.Profesion] PRIMARY KEY CLUSTERED 
(
	[ProfesionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedor](
	[ProveedorID] [int] IDENTITY(1,1) NOT NULL,
	[ProveedorIDRemoto] [int] NULL,
	[NombreFantasia] [nvarchar](max) NULL,
	[RazonSocial] [nvarchar](max) NULL,
	[Cuit] [nvarchar](max) NULL,
	[IngresosBrutos] [nvarchar](max) NULL,
	[Domicilio] [nvarchar](max) NULL,
	[Telefono1] [nvarchar](max) NULL,
	[Telefono2] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
	[LocalidadID] [int] NULL,
	[ProvinciaID] [int] NULL,
	[PaisId] [int] NULL,
	[Cp] [nvarchar](max) NULL,
	[Fax] [nvarchar](max) NULL,
	[Mail1] [nvarchar](max) NULL,
	[Mail2] [nvarchar](max) NULL,
	[Mail3] [nvarchar](max) NULL,
	[Web1] [nvarchar](max) NULL,
	[Web2] [nvarchar](max) NULL,
	[Tel3] [nvarchar](max) NULL,
	[Web3] [nvarchar](max) NULL,
	[CodigoContable] [nvarchar](max) NULL,
	[EstadoID] [int] NOT NULL,
	[CondIva] [int] NULL,
	[FechaAlta] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_dbo.Proveedor] PRIMARY KEY CLUSTERED 
(
	[ProveedorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProveedorSucursal]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProveedorSucursal](
	[ProveedorSucursalID] [int] IDENTITY(1,1) NOT NULL,
	[ProveedorID] [int] NULL,
	[ProveedorSucursalIDRemoto] [int] NULL,
	[Nombre] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
	[Domicilio] [nvarchar](max) NULL,
	[LocalidadID] [int] NULL,
	[ProvinciaID] [int] NULL,
	[PaisID] [int] NULL,
	[Telefono1] [nvarchar](max) NULL,
	[Telefono2] [nvarchar](max) NULL,
	[Telefono3] [nvarchar](max) NULL,
	[Mail1] [nvarchar](max) NULL,
	[Mail2] [nvarchar](max) NULL,
	[Mail3] [nvarchar](max) NULL,
	[Fax] [nvarchar](max) NULL,
	[Web2] [nvarchar](max) NULL,
	[Web1] [nvarchar](max) NULL,
	[Web3] [nvarchar](max) NULL,
	[Cp] [nvarchar](max) NULL,
	[EstadoID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.ProveedorSucursal] PRIMARY KEY CLUSTERED 
(
	[ProveedorSucursalID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Provincia]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provincia](
	[PaisId] [int] NOT NULL,
	[ProvinciaID] [int] NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
	[CodIso] [nvarchar](max) NULL,
	[DirImaEscudo] [nvarchar](max) NULL,
	[CodTel] [nvarchar](max) NULL,
	[X] [decimal](18, 2) NULL,
	[Y] [decimal](18, 2) NULL,
 CONSTRAINT [PK_dbo.Provincia] PRIMARY KEY CLUSTERED 
(
	[PaisId] ASC,
	[ProvinciaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recibo]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recibo](
	[EmpresaID] [int] NOT NULL,
	[ComercioID] [int] NOT NULL,
	[ReciboID] [int] IDENTITY(1,1) NOT NULL,
	[ReciboIDRemoto] [int] NULL,
	[Fecha] [datetime2](7) NULL,
	[FechaIngreso] [datetime2](7) NULL,
	[Importe] [decimal](18, 2) NOT NULL,
	[Comprobante] [int] NOT NULL,
	[Notas] [nvarchar](max) NULL,
	[TipoMovimientoID] [int] NOT NULL,
	[TransferenciasDepositosEmpId] [int] NULL,
	[TransferenciasDepositosID] [bigint] NULL,
	[SolicitudFondoID] [bigint] NULL,
	[Imputado] [decimal](18, 2) NULL,
	[Migrado] [bit] NULL,
	[Conformado] [bit] NULL,
	[Host] [nvarchar](max) NULL,
	[UsuarioID] [int] NOT NULL,
	[EstadoID] [int] NOT NULL,
	[ComercioAdheridoComercioID] [int] NULL,
	[ComercioAdheridoEmpresaID] [int] NULL,
	[ReciboIDAnula] [int] NULL,
	[CobranzaID] [int] NULL,
	[CreditoID] [int] NULL,
	[CuotaID] [int] NULL,
 CONSTRAINT [PK_dbo.Recibo] PRIMARY KEY CLUSTERED 
(
	[EmpresaID] ASC,
	[ComercioID] ASC,
	[ReciboID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RefinanciacionCobranza]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RefinanciacionCobranza](
	[EmpresaID] [int] NOT NULL,
	[ComercioID] [int] NOT NULL,
	[CreditoID] [int] NOT NULL,
	[RefinanciacionID] [int] NOT NULL,
	[RefinanciacionCuotaID] [int] NOT NULL,
	[RefinanciacionCobranzaID] [int] NOT NULL,
	[Documento] [int] NOT NULL,
	[TipoDocumentoID] [nvarchar](128) NOT NULL,
	[ImportePago] [decimal](19, 2) NOT NULL,
	[ImportePagoPunitorios] [decimal](19, 2) NOT NULL,
	[PunitoriosCalc] [decimal](19, 2) NOT NULL,
	[FechaPago] [datetime2](7) NOT NULL,
	[FechaVencimiento] [datetime2](7) NOT NULL,
	[TipoPagoID] [nvarchar](128) NULL,
	[PagoRev] [bit] NOT NULL,
	[FechaRev] [datetime2](7) NULL,
	[RefinanciacionCobranzaIDRev] [int] NULL,
	[GestionID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.RefinanciacionCobranza] PRIMARY KEY CLUSTERED 
(
	[EmpresaID] ASC,
	[ComercioID] ASC,
	[CreditoID] ASC,
	[RefinanciacionID] ASC,
	[RefinanciacionCuotaID] ASC,
	[RefinanciacionCobranzaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sexo]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sexo](
	[SexoID] [nvarchar](128) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Sexo] PRIMARY KEY CLUSTERED 
(
	[SexoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SolicitudFondo]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SolicitudFondo](
	[EmpresaID] [int] NOT NULL,
	[ComercioID] [int] NOT NULL,
	[SolicitudFondoID] [bigint] IDENTITY(1,1) NOT NULL,
	[SolicitudFondoIDRemoto] [bigint] NULL,
	[FechaPago] [datetime2](7) NULL,
	[FechaPagoSF] [nvarchar](max) NULL,
	[FechaRealizacion] [datetime2](7) NULL,
	[Importe] [decimal](18, 2) NULL,
	[Motivo] [nvarchar](max) NULL,
	[LiquidacionID] [int] NULL,
	[FechaDispComienzo] [datetime2](7) NULL,
	[FechaDispFinal] [datetime2](7) NULL,
	[GeneradoPorComercioID] [int] NULL,
	[GeneradoPorDepartamentoID] [int] NULL,
	[MedioDePagoID] [int] NULL,
	[ConceptoFondosID] [int] NULL,
	[TransferenciasDepositosEmpId] [int] NULL,
	[TransferenciasDepositosID] [bigint] NULL,
	[ClaseCuentaBancariaID] [int] NULL,
	[CuentaBancariaID] [int] NULL,
	[NumChequera] [nvarchar](128) NULL,
	[NumCheque] [nvarchar](128) NULL,
	[EstadoID] [int] NULL,
	[MonedaID] [int] NULL,
	[OrdenDePago] [int] NULL,
	[TipoSolicitudID] [int] NULL,
	[FechaConfComercio] [datetime2](7) NULL,
	[EmpleadoConfComercio] [int] NULL,
	[notas] [nvarchar](max) NULL,
	[EmpleadoSolicitanteID] [int] NULL,
	[EmpleadoRealizadorID] [int] NULL,
	[CajaID] [int] NULL,
	[AvisoDePagoID] [int] NULL,
 CONSTRAINT [PK_dbo.SolicitudFondo] PRIMARY KEY CLUSTERED 
(
	[EmpresaID] ASC,
	[ComercioID] ASC,
	[SolicitudFondoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SolicitudFondoConceptoGastosProveedor]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SolicitudFondoConceptoGastosProveedor](
	[EmpresaID] [int] NOT NULL,
	[ComercioID] [int] NOT NULL,
	[SolicitudFondoID] [bigint] NOT NULL,
	[ConceptoGastosProveedorID] [int] NOT NULL,
	[Importe] [decimal](18, 2) NULL,
	[Detalle] [nvarchar](max) NULL,
	[sConceptoGastosProveedor] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.SolicitudFondoConceptoGastosProveedor] PRIMARY KEY CLUSTERED 
(
	[EmpresaID] ASC,
	[ComercioID] ASC,
	[SolicitudFondoID] ASC,
	[ConceptoGastosProveedorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SucursalBanco]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SucursalBanco](
	[BancoID] [int] NOT NULL,
	[SucursalBancoID] [int] NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
	[Domicilio] [nvarchar](max) NULL,
	[Numsuc] [nvarchar](max) NULL,
	[LocalidadID] [int] NULL,
	[ProvinciaID] [int] NULL,
	[PaisId] [int] NULL,
 CONSTRAINT [PK_dbo.SucursalBanco] PRIMARY KEY CLUSTERED 
(
	[BancoID] ASC,
	[SucursalBancoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Telefono]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Telefono](
	[TelefonoID] [int] IDENTITY(1,1) NOT NULL,
	[CodArea] [nvarchar](max) NULL,
	[Numero] [nvarchar](max) NULL,
	[esCelular] [bit] NULL,
	[EstadoID] [int] NOT NULL,
	[ClaseDatoID] [int] NOT NULL,
	[Documento] [int] NOT NULL,
	[TipoDocumentoID] [nvarchar](128) NULL,
	[EmpresaID] [int] NULL,
	[ComercioID] [int] NULL,
	[Fecha] [datetime2](7) NOT NULL,
	[Nota] [nvarchar](max) NULL,
	[UsuarioID] [int] NULL,
	[PcComer] [nvarchar](max) NULL,
	[TelefonoCompleto] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Telefono] PRIMARY KEY CLUSTERED 
(
	[TelefonoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoAnulacion]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoAnulacion](
	[TipoAnulacionID] [nvarchar](2) NOT NULL,
	[Descripcion] [nvarchar](max) NULL,
	[QueAnula] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.TipoAnulacion] PRIMARY KEY CLUSTERED 
(
	[TipoAnulacionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoAval]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoAval](
	[TipoAvalID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.TipoAval] PRIMARY KEY CLUSTERED 
(
	[TipoAvalID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoBonificacion]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoBonificacion](
	[TipoBonificacionID] [nvarchar](128) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.TipoBonificacion] PRIMARY KEY CLUSTERED 
(
	[TipoBonificacionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoCheque]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoCheque](
	[TipoChequeID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Descripcion] [int] NOT NULL,
 CONSTRAINT [PK_dbo.TipoCheque] PRIMARY KEY CLUSTERED 
(
	[TipoChequeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoComercio]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoComercio](
	[TipoComercioID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.TipoComercio] PRIMARY KEY CLUSTERED 
(
	[TipoComercioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoComoConocio]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoComoConocio](
	[TipoComoConocioID] [nvarchar](128) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.TipoComoConocio] PRIMARY KEY CLUSTERED 
(
	[TipoComoConocioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoCuentaBancaria]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoCuentaBancaria](
	[TipoCuentaBancariaID] [int] NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.TipoCuentaBancaria] PRIMARY KEY CLUSTERED 
(
	[TipoCuentaBancariaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoCuota]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoCuota](
	[TipoCuotaID] [nvarchar](128) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.TipoCuota] PRIMARY KEY CLUSTERED 
(
	[TipoCuotaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoDocumento]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoDocumento](
	[TipoDocumentoID] [nvarchar](128) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.TipoDocumento] PRIMARY KEY CLUSTERED 
(
	[TipoDocumentoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoEmpleado]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoEmpleado](
	[TipoEmpleadoID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.TipoEmpleado] PRIMARY KEY CLUSTERED 
(
	[TipoEmpleadoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoEstado]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoEstado](
	[TipoEstadoID] [int] NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.TipoEstado] PRIMARY KEY CLUSTERED 
(
	[TipoEstadoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoImagen]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoImagen](
	[TipoImagenID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Sufijo] [nvarchar](max) NULL,
	[Orden] [int] NOT NULL,
 CONSTRAINT [PK_dbo.TipoImagen] PRIMARY KEY CLUSTERED 
(
	[TipoImagenID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoImpresion]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoImpresion](
	[TipoImpresionID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Impresora] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.TipoImpresion] PRIMARY KEY CLUSTERED 
(
	[TipoImpresionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoMovimiento]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoMovimiento](
	[TipoMovimientoID] [int] NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
	[Cod] [nvarchar](max) NULL,
	[ClaseMovimientoID] [int] NOT NULL,
	[CodInter] [nvarchar](max) NULL,
	[TipoMovIDAnula] [int] NOT NULL,
 CONSTRAINT [PK_dbo.TipoMovimiento] PRIMARY KEY CLUSTERED 
(
	[TipoMovimientoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoPago]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoPago](
	[TipoPagoID] [nvarchar](128) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.TipoPago] PRIMARY KEY CLUSTERED 
(
	[TipoPagoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoRetencionPlan]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoRetencionPlan](
	[TipoRetencionPlanID] [nvarchar](128) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.TipoRetencionPlan] PRIMARY KEY CLUSTERED 
(
	[TipoRetencionPlanID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoSolicitud]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoSolicitud](
	[TipoSolicitudID] [int] NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.TipoSolicitud] PRIMARY KEY CLUSTERED 
(
	[TipoSolicitudID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoTransferenciaDeposito]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoTransferenciaDeposito](
	[TipoTransferenciaDepositoID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.TipoTransferenciaDeposito] PRIMARY KEY CLUSTERED 
(
	[TipoTransferenciaDepositoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransferenciasDepositos]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransferenciasDepositos](
	[EmpresaID] [int] NOT NULL,
	[TransferenciasDepositosID] [bigint] IDENTITY(1,1) NOT NULL,
	[TransferenciasDepositosIDRemoto] [bigint] NULL,
	[NumTransferencia] [nvarchar](max) NULL,
	[Importe] [decimal](18, 2) NULL,
	[Fecha] [datetime2](7) NULL,
	[Costo] [decimal](18, 2) NULL,
	[Notas] [nvarchar](max) NULL,
	[CuentaOrigenEmpresaID] [int] NULL,
	[CuentaOrigenCbID] [int] NULL,
	[CuentaDestinoEmpresaID] [int] NULL,
	[CuentaDestinoCbID] [int] NULL,
	[ChequeEmpID] [int] NULL,
	[ChequeCbID] [int] NULL,
	[ChequeNumChequera] [nvarchar](128) NULL,
	[ChequeNumCheque] [nvarchar](128) NULL,
	[MedioDePagoID] [int] NULL,
	[MonedaID] [int] NULL,
	[EmpleadoRegistradorEmpresaID] [int] NULL,
	[EmpleadoRegistradorPersonaID] [int] NULL,
	[ComercioEmpresaID] [int] NULL,
	[ComercioID] [int] NULL,
	[PersonaId] [int] NULL,
	[ProveedorSucursalID] [int] NULL,
	[ProveedorID] [int] NULL,
	[Host] [nvarchar](max) NULL,
	[UsuarioID] [int] NOT NULL,
	[TipoTransferenciaDepositoID] [int] NULL,
	[EstadoID] [int] NOT NULL,
	[ComercioEmpresa_EmpresaID] [int] NULL,
	[EmpleadoRegistrador_EmpleadoID] [int] NULL,
 CONSTRAINT [PK_dbo.TransferenciasDepositos] PRIMARY KEY CLUSTERED 
(
	[EmpresaID] ASC,
	[TransferenciasDepositosID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transmision]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transmision](
	[TransmisionID] [bigint] IDENTITY(1,1) NOT NULL,
	[OperacionID] [int] NOT NULL,
	[EstadoTransmisionID] [int] NOT NULL,
	[EmpresaID] [int] NOT NULL,
	[ComercioID] [int] NOT NULL,
	[EntidadID] [nvarchar](max) NULL,
	[EntidadID2] [nvarchar](max) NULL,
	[EntidadID3] [nvarchar](max) NULL,
	[EntidadID4] [nvarchar](max) NULL,
	[EntidadID5] [nvarchar](max) NULL,
	[EntidadID6] [nvarchar](max) NULL,
	[EntidadID7] [nvarchar](max) NULL,
	[Fecha] [datetime2](7) NOT NULL,
	[RutaApi] [nvarchar](max) NULL,
	[GrupoTransmision] [int] NULL,
	[CantTransmisiones] [int] NULL,
	[UltimaTransmision] [datetime] NULL,
 CONSTRAINT [PK_dbo.Transmision] PRIMARY KEY CLUSTERED 
(
	[TransmisionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[UsuarioID] [int] IDENTITY(1,1) NOT NULL,
	[usuario] [nvarchar](max) NULL,
	[nombre] [nvarchar](max) NULL,
	[apellido] [nvarchar](max) NULL,
	[pass] [nvarchar](max) NULL,
	[creacion] [datetime2](7) NOT NULL,
	[activo] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Usuario] PRIMARY KEY CLUSTERED 
(
	[UsuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuariosPerfiles]    Script Date: 29/3/2026 11:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuariosPerfiles](
	[UsuarioID] [int] NOT NULL,
	[PerfilID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.UsuariosPerfiles] PRIMARY KEY CLUSTERED 
(
	[UsuarioID] ASC,
	[PerfilID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_ComercioID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_ComercioID] ON [dbo].[Autorizacion]
(
	[EmpresaID] ASC,
	[ComercioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EstadoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EstadoID] ON [dbo].[Autorizacion]
(
	[EstadoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PersonaID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_PersonaID] ON [dbo].[Autorizacion]
(
	[PersonaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_ComercioID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_ComercioID] ON [dbo].[AvisoDePago]
(
	[EmpresaID] ASC,
	[ComercioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_ComercioID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_ComercioID] ON [dbo].[Cap]
(
	[EmpresaID] ASC,
	[ComercioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_ComercioID_SolicitudFondoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_ComercioID_SolicitudFondoID] ON [dbo].[Cap]
(
	[EmpresaID] ASC,
	[ComercioID] ASC,
	[SolicitudFondoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EstadoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EstadoID] ON [dbo].[Cap]
(
	[EstadoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_ComercioID_CapID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_ComercioID_CapID] ON [dbo].[CapDetalle]
(
	[EmpresaID] ASC,
	[ComercioID] ASC,
	[CapID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_EmpresaID_CuentaBancariaID_ChequeraID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_CuentaBancariaID_ChequeraID] ON [dbo].[Cheque]
(
	[EmpresaID] ASC,
	[CuentaBancariaID] ASC,
	[ChequeraID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EstadoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EstadoID] ON [dbo].[Cheque]
(
	[EstadoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TipoChequeID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_TipoChequeID] ON [dbo].[Cheque]
(
	[TipoChequeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_CuentaBancariaID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_CuentaBancariaID] ON [dbo].[Chequera]
(
	[EmpresaID] ASC,
	[CuentaBancariaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EstadoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EstadoID] ON [dbo].[Chequera]
(
	[EstadoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EstadoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EstadoID] ON [dbo].[Cliente]
(
	[EstadoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ProfesionID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_ProfesionID] ON [dbo].[Cliente]
(
	[ProfesionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_SexoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_SexoID] ON [dbo].[Cliente]
(
	[SexoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_TipoComoConocioID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_TipoComoConocioID] ON [dbo].[Cliente]
(
	[TipoComoConocioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_TipoDocumentoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_TipoDocumentoID] ON [dbo].[Cliente]
(
	[TipoDocumentoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UsuarioModificacionID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_UsuarioModificacionID] ON [dbo].[Cliente]
(
	[UsuarioModificacionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Documento_TipoDocumentoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_Documento_TipoDocumentoID] ON [dbo].[Cobranza]
(
	[Documento] ASC,
	[TipoDocumentoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_ComercioID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_ComercioID] ON [dbo].[Cobranza]
(
	[EmpresaID] ASC,
	[ComercioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_ComercioID_CreditoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_ComercioID_CreditoID] ON [dbo].[Cobranza]
(
	[EmpresaID] ASC,
	[ComercioID] ASC,
	[CreditoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_ComercioID_CreditoID_CuotaID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_ComercioID_CreditoID_CuotaID] ON [dbo].[Cobranza]
(
	[EmpresaID] ASC,
	[ComercioID] ASC,
	[CreditoID] ASC,
	[CuotaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_TipoBonificacionID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_TipoBonificacionID] ON [dbo].[Cobranza]
(
	[TipoBonificacionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_TipoPagoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_TipoPagoID] ON [dbo].[Cobranza]
(
	[TipoPagoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UsuarioID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_UsuarioID] ON [dbo].[Cobranza]
(
	[UsuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Contacto1_PersonaID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_Contacto1_PersonaID] ON [dbo].[Comercio]
(
	[Contacto1_PersonaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Contacto2_PersonaID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_Contacto2_PersonaID] ON [dbo].[Comercio]
(
	[Contacto2_PersonaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID] ON [dbo].[Comercio]
(
	[EmpresaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PaisId_ProvinciaID_LocalidadID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_PaisId_ProvinciaID_LocalidadID] ON [dbo].[Comercio]
(
	[PaisId] ASC,
	[ProvinciaID] ASC,
	[LocalidadID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TipoComercioID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_TipoComercioID] ON [dbo].[Comercio]
(
	[TipoComercioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Titular1_PersonaID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_Titular1_PersonaID] ON [dbo].[Comercio]
(
	[Titular1_PersonaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Titular2_PersonaID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_Titular2_PersonaID] ON [dbo].[Comercio]
(
	[Titular2_PersonaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_MedioDePagoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_MedioDePagoID] ON [dbo].[ConceptoFondos]
(
	[MedioDePagoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ConceptoGastoPadreID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_ConceptoGastoPadreID] ON [dbo].[ConceptoGastos]
(
	[ConceptoGastoPadreID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EstadoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EstadoID] ON [dbo].[ConceptoGastos]
(
	[EstadoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ConceptoGastosID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_ConceptoGastosID] ON [dbo].[ConceptoGastosDepartamento]
(
	[ConceptoGastosID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_DepartamentoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_DepartamentoID] ON [dbo].[ConceptoGastosDepartamento]
(
	[DepartamentoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EstadoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EstadoID] ON [dbo].[ConceptoGastosDepartamento]
(
	[EstadoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ConceptoGastosID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_ConceptoGastosID] ON [dbo].[ConceptoGastosProveedor]
(
	[ConceptoGastosID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EstadoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EstadoID] ON [dbo].[ConceptoGastosProveedor]
(
	[EstadoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProveedorID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_ProveedorID] ON [dbo].[ConceptoGastosProveedor]
(
	[ProveedorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProveedorSucursalID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_ProveedorSucursalID] ON [dbo].[ConceptoGastosProveedor]
(
	[ProveedorSucursalID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Adicional_TipoDocumentoIDAdi]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_Adicional_TipoDocumentoIDAdi] ON [dbo].[Credito]
(
	[Adicional] ASC,
	[TipoDocumentoIDAdi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Documento_TipoDocumentoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_Documento_TipoDocumentoID] ON [dbo].[Credito]
(
	[Documento] ASC,
	[TipoDocumentoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_AbogadoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_AbogadoID] ON [dbo].[Credito]
(
	[EmpresaID] ASC,
	[AbogadoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_ComercioID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_ComercioID] ON [dbo].[Credito]
(
	[EmpresaID] ASC,
	[ComercioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_ComercioID_AvisoDePagoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_ComercioID_AvisoDePagoID] ON [dbo].[Credito]
(
	[EmpresaID] ASC,
	[ComercioID] ASC,
	[AvisoDePagoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Garante1_TipoDocumentoIDG1]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_Garante1_TipoDocumentoIDG1] ON [dbo].[Credito]
(
	[Garante1] ASC,
	[TipoDocumentoIDG1] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Garante2_TipoDocumentoIDG2]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_Garante2_TipoDocumentoIDG2] ON [dbo].[Credito]
(
	[Garante2] ASC,
	[TipoDocumentoIDG2] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Garante3_TipoDocumentoIDG3]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_Garante3_TipoDocumentoIDG3] ON [dbo].[Credito]
(
	[Garante3] ASC,
	[TipoDocumentoIDG3] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_TipoBonificacionID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_TipoBonificacionID] ON [dbo].[Credito]
(
	[TipoBonificacionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_TipoCuotaID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_TipoCuotaID] ON [dbo].[Credito]
(
	[TipoCuotaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_usuarioAvalID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_usuarioAvalID] ON [dbo].[Credito]
(
	[usuarioAvalID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UsuarioID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_UsuarioID] ON [dbo].[Credito]
(
	[UsuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Documento_TipoDocumentoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_Documento_TipoDocumentoID] ON [dbo].[CreditoAnulado]
(
	[Documento] ASC,
	[TipoDocumentoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_ComercioID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_ComercioID] ON [dbo].[CreditoAnulado]
(
	[EmpresaID] ASC,
	[ComercioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_TipoAnulacionID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_TipoAnulacionID] ON [dbo].[CreditoAnulado]
(
	[TipoAnulacionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UsuarioID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_UsuarioID] ON [dbo].[CreditoAnulado]
(
	[UsuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_ComercioID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_ComercioID] ON [dbo].[CreditoAval]
(
	[EmpresaID] ASC,
	[ComercioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_ComercioID_CreditoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_ComercioID_CreditoID] ON [dbo].[CreditoAval]
(
	[EmpresaID] ASC,
	[ComercioID] ASC,
	[CreditoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TipoAvalID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_TipoAvalID] ON [dbo].[CreditoAval]
(
	[TipoAvalID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UsuarioID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_UsuarioID] ON [dbo].[CreditoAval]
(
	[UsuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_BancoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_BancoID] ON [dbo].[CuentaBancaria]
(
	[BancoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_BancoID_SucursalBancoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_BancoID_SucursalBancoID] ON [dbo].[CuentaBancaria]
(
	[BancoID] ASC,
	[SucursalBancoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClaseCuentaBancariaID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_ClaseCuentaBancariaID] ON [dbo].[CuentaBancaria]
(
	[ClaseCuentaBancariaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_ComercioID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_ComercioID] ON [dbo].[CuentaBancaria]
(
	[EmpresaID] ASC,
	[ComercioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EstadoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EstadoID] ON [dbo].[CuentaBancaria]
(
	[EstadoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_MonedaID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_MonedaID] ON [dbo].[CuentaBancaria]
(
	[MonedaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PersonaID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_PersonaID] ON [dbo].[CuentaBancaria]
(
	[PersonaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Proveedor_ProveedorID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_Proveedor_ProveedorID] ON [dbo].[CuentaBancaria]
(
	[Proveedor_ProveedorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProveedorSucursal_ProveedorSucursalID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_ProveedorSucursal_ProveedorSucursalID] ON [dbo].[CuentaBancaria]
(
	[ProveedorSucursal_ProveedorSucursalID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TipoCuentaBancariaID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_TipoCuentaBancariaID] ON [dbo].[CuentaBancaria]
(
	[TipoCuentaBancariaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_BancoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_BancoID] ON [dbo].[CuentaBancariaCliente]
(
	[BancoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_BancoID_SucursalBancoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_BancoID_SucursalBancoID] ON [dbo].[CuentaBancariaCliente]
(
	[BancoID] ASC,
	[SucursalBancoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Documento_TipoDocumentoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_Documento_TipoDocumentoID] ON [dbo].[CuentaBancariaCliente]
(
	[Documento] ASC,
	[TipoDocumentoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EstadoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EstadoID] ON [dbo].[CuentaBancariaCliente]
(
	[EstadoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_MonedaID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_MonedaID] ON [dbo].[CuentaBancariaCliente]
(
	[MonedaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_TipoDocumentoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_TipoDocumentoID] ON [dbo].[CuentaBancariaCliente]
(
	[TipoDocumentoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_ComercioID_CreditoID_CuotaID_CobranzaID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_ComercioID_CreditoID_CuotaID_CobranzaID] ON [dbo].[CuentaCorriente]
(
	[EmpresaID] ASC,
	[ComercioID] ASC,
	[CreditoID] ASC,
	[CuotaID] ASC,
	[CobranzaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_ComercioID_CreditoID_CuotaID_CobranzaID_NotaCDID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_ComercioID_CreditoID_CuotaID_CobranzaID_NotaCDID] ON [dbo].[CuentaCorriente]
(
	[EmpresaID] ASC,
	[ComercioID] ASC,
	[CreditoID] ASC,
	[CuotaID] ASC,
	[CobranzaID] ASC,
	[NotaCDID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_ComercioID_GastoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_ComercioID_GastoID] ON [dbo].[CuentaCorriente]
(
	[EmpresaID] ASC,
	[ComercioID] ASC,
	[GastoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_ComercioID_PagoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_ComercioID_PagoID] ON [dbo].[CuentaCorriente]
(
	[EmpresaID] ASC,
	[ComercioID] ASC,
	[PagoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_ComercioID_SolicitudFondoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_ComercioID_SolicitudFondoID] ON [dbo].[CuentaCorriente]
(
	[EmpresaID] ASC,
	[ComercioID] ASC,
	[SolicitudFondoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_GestionID_ReciboID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_GestionID_ReciboID] ON [dbo].[CuentaCorriente]
(
	[EmpresaID] ASC,
	[GestionID] ASC,
	[ReciboID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_TransferenciaDepositoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_TransferenciaDepositoID] ON [dbo].[CuentaCorriente]
(
	[EmpresaID] ASC,
	[TransferenciaDepositoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TipoMovimientoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_TipoMovimientoID] ON [dbo].[CuentaCorriente]
(
	[TipoMovimientoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Documento_TipoDocumentoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_Documento_TipoDocumentoID] ON [dbo].[Cuota]
(
	[Documento] ASC,
	[TipoDocumentoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_ComercioID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_ComercioID] ON [dbo].[Cuota]
(
	[EmpresaID] ASC,
	[ComercioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_ComercioID_CreditoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_ComercioID_CreditoID] ON [dbo].[Cuota]
(
	[EmpresaID] ASC,
	[ComercioID] ASC,
	[CreditoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_TipoCuotaID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_TipoCuotaID] ON [dbo].[Cuota]
(
	[TipoCuotaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ConceptoFondos_ConceptoFondosID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_ConceptoFondos_ConceptoFondosID] ON [dbo].[Departamento]
(
	[ConceptoFondos_ConceptoFondosID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClaseDatoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_ClaseDatoID] ON [dbo].[Domicilio]
(
	[ClaseDatoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Documento_TipoDocumentoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_Documento_TipoDocumentoID] ON [dbo].[Domicilio]
(
	[Documento] ASC,
	[TipoDocumentoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EstadoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EstadoID] ON [dbo].[Domicilio]
(
	[EstadoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PaisId_ProvinciaID_LocalidadID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_PaisId_ProvinciaID_LocalidadID] ON [dbo].[Domicilio]
(
	[PaisId] ASC,
	[ProvinciaID] ASC,
	[LocalidadID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UsuarioID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_UsuarioID] ON [dbo].[Domicilio]
(
	[UsuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CargoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_CargoID] ON [dbo].[Empleado]
(
	[CargoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_DepartamentoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_DepartamentoID] ON [dbo].[Empleado]
(
	[DepartamentoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_ComercioID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_ComercioID] ON [dbo].[Empleado]
(
	[EmpresaID] ASC,
	[ComercioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EstadoId]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EstadoId] ON [dbo].[Empleado]
(
	[EstadoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PersonaID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_PersonaID] ON [dbo].[Empleado]
(
	[PersonaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TipoEmpleadoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_TipoEmpleadoID] ON [dbo].[Empleado]
(
	[TipoEmpleadoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Usuarioid]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_Usuarioid] ON [dbo].[Empleado]
(
	[Usuarioid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TipoEstadoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_TipoEstadoID] ON [dbo].[Estado]
(
	[TipoEstadoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_ComercioID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_ComercioID] ON [dbo].[FF]
(
	[EmpresaID] ASC,
	[ComercioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_ComercioID_SolicitudFondoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_ComercioID_SolicitudFondoID] ON [dbo].[FF]
(
	[EmpresaID] ASC,
	[ComercioID] ASC,
	[SolicitudFondoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EstadoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EstadoID] ON [dbo].[FF]
(
	[EstadoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_ComercioID_FFID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_ComercioID_FFID] ON [dbo].[FFDetalle]
(
	[EmpresaID] ASC,
	[ComercioID] ASC,
	[FFID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ConceptoGastoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_ConceptoGastoID] ON [dbo].[Gasto]
(
	[ConceptoGastoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ConceptoGastoProveedorID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_ConceptoGastoProveedorID] ON [dbo].[Gasto]
(
	[ConceptoGastoProveedorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_DepartamentoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_DepartamentoID] ON [dbo].[Gasto]
(
	[DepartamentoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_ComercioID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_ComercioID] ON [dbo].[Gasto]
(
	[EmpresaID] ASC,
	[ComercioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_ComercioID_SolicitudFondoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_ComercioID_SolicitudFondoID] ON [dbo].[Gasto]
(
	[EmpresaID] ASC,
	[ComercioID] ASC,
	[SolicitudFondoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EstadoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EstadoID] ON [dbo].[Gasto]
(
	[EstadoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProveedorID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_ProveedorID] ON [dbo].[Gasto]
(
	[ProveedorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProveedorSucursalID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_ProveedorSucursalID] ON [dbo].[Gasto]
(
	[ProveedorSucursalID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PaisId_ProvinciaID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_PaisId_ProvinciaID] ON [dbo].[Localidad]
(
	[PaisId] ASC,
	[ProvinciaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClaseDatoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_ClaseDatoID] ON [dbo].[Mail]
(
	[ClaseDatoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Documento_TipoDocumentoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_Documento_TipoDocumentoID] ON [dbo].[Mail]
(
	[Documento] ASC,
	[TipoDocumentoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EstadoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EstadoID] ON [dbo].[Mail]
(
	[EstadoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UsuarioID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_UsuarioID] ON [dbo].[Mail]
(
	[UsuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PaisId]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_PaisId] ON [dbo].[Moneda]
(
	[PaisId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Documento_TipoDocumentoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_Documento_TipoDocumentoID] ON [dbo].[Nota]
(
	[Documento] ASC,
	[TipoDocumentoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_ComercioID_CreditoID_CuotaID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_ComercioID_CreditoID_CuotaID] ON [dbo].[Nota]
(
	[EmpresaID] ASC,
	[ComercioID] ASC,
	[CreditoID] ASC,
	[CuotaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_ComercioID_CreditoID_CuotaID_CobranzaID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_ComercioID_CreditoID_CuotaID_CobranzaID] ON [dbo].[Nota]
(
	[EmpresaID] ASC,
	[ComercioID] ASC,
	[CreditoID] ASC,
	[CuotaID] ASC,
	[CobranzaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UsuarioID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_UsuarioID] ON [dbo].[Nota]
(
	[UsuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_ComercioID_CreditoID_CuotaID_CobranzaID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_ComercioID_CreditoID_CuotaID_CobranzaID] ON [dbo].[NotasCD]
(
	[EmpresaID] ASC,
	[ComercioID] ASC,
	[CreditoID] ASC,
	[CuotaID] ASC,
	[CobranzaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UsuarioID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_UsuarioID] ON [dbo].[NotasCD]
(
	[UsuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ConceptoFondosID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_ConceptoFondosID] ON [dbo].[OrdenDePago]
(
	[ConceptoFondosID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID] ON [dbo].[OrdenDePago]
(
	[EmpresaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EstadoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EstadoID] ON [dbo].[OrdenDePago]
(
	[EstadoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_ComercioID_CapID_CapDetalleID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_ComercioID_CapID_CapDetalleID] ON [dbo].[Pago]
(
	[EmpresaID] ASC,
	[ComercioID] ASC,
	[CapID] ASC,
	[CapDetalleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_ComercioID_FFID_FFDetalleID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_ComercioID_FFID_FFDetalleID] ON [dbo].[Pago]
(
	[EmpresaID] ASC,
	[ComercioID] ASC,
	[FFID] ASC,
	[FFDetalleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_ComercioID_SolicitudFondoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_ComercioID_SolicitudFondoID] ON [dbo].[Pago]
(
	[EmpresaID] ASC,
	[ComercioID] ASC,
	[SolicitudFondoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EstadoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EstadoID] ON [dbo].[Pago]
(
	[EstadoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PerfilID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_PerfilID] ON [dbo].[PerfilesPermisos]
(
	[PerfilID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PermisoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_PermisoID] ON [dbo].[PerfilesPermisos]
(
	[PermisoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PaisID_ProvinciaID_LocalidadID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_PaisID_ProvinciaID_LocalidadID] ON [dbo].[Persona]
(
	[PaisID] ASC,
	[ProvinciaID] ASC,
	[LocalidadID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_TiposDocumento_TipoDocumentoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_TiposDocumento_TipoDocumentoID] ON [dbo].[Persona]
(
	[TiposDocumento_TipoDocumentoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_ComercioID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_ComercioID] ON [dbo].[PlanesBonif]
(
	[EmpresaID] ASC,
	[ComercioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_PlanesTipoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_PlanesTipoID] ON [dbo].[PlanesBonif]
(
	[PlanesTipoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UsuarioID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_UsuarioID] ON [dbo].[PlanesBonif]
(
	[UsuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_ComercioID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_ComercioID] ON [dbo].[PlanesDetalle]
(
	[EmpresaID] ASC,
	[ComercioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_PlanesTipoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_PlanesTipoID] ON [dbo].[PlanesDetalle]
(
	[PlanesTipoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UsuarioID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_UsuarioID] ON [dbo].[PlanesDetalle]
(
	[UsuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_ComercioID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_ComercioID] ON [dbo].[PlanesTipo]
(
	[EmpresaID] ASC,
	[ComercioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_TipoRetencionPlanID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_TipoRetencionPlanID] ON [dbo].[PlanesTipo]
(
	[TipoRetencionPlanID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_PlanesTipoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_PlanesTipoID] ON [dbo].[PlanesVenci]
(
	[PlanesTipoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UsuarioID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_UsuarioID] ON [dbo].[PlanesVenci]
(
	[UsuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ProfesionPadreID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_ProfesionPadreID] ON [dbo].[Profesion]
(
	[ProfesionPadreID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EstadoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EstadoID] ON [dbo].[Proveedor]
(
	[EstadoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PaisId_ProvinciaID_LocalidadID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_PaisId_ProvinciaID_LocalidadID] ON [dbo].[Proveedor]
(
	[PaisId] ASC,
	[ProvinciaID] ASC,
	[LocalidadID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EstadoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EstadoID] ON [dbo].[ProveedorSucursal]
(
	[EstadoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PaisID_ProvinciaID_LocalidadID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_PaisID_ProvinciaID_LocalidadID] ON [dbo].[ProveedorSucursal]
(
	[PaisID] ASC,
	[ProvinciaID] ASC,
	[LocalidadID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProveedorID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_ProveedorID] ON [dbo].[ProveedorSucursal]
(
	[ProveedorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PaisId]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_PaisId] ON [dbo].[Provincia]
(
	[PaisId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ComercioAdheridoEmpresaID_ComercioAdheridoComercioID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_ComercioAdheridoEmpresaID_ComercioAdheridoComercioID] ON [dbo].[Recibo]
(
	[ComercioAdheridoEmpresaID] ASC,
	[ComercioAdheridoComercioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_ComercioID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_ComercioID] ON [dbo].[Recibo]
(
	[EmpresaID] ASC,
	[ComercioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_ComercioID_SolicitudFondoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_ComercioID_SolicitudFondoID] ON [dbo].[Recibo]
(
	[EmpresaID] ASC,
	[ComercioID] ASC,
	[SolicitudFondoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_TransferenciasDepositosID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_TransferenciasDepositosID] ON [dbo].[Recibo]
(
	[EmpresaID] ASC,
	[TransferenciasDepositosID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EstadoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EstadoID] ON [dbo].[Recibo]
(
	[EstadoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TipoMovimientoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_TipoMovimientoID] ON [dbo].[Recibo]
(
	[TipoMovimientoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UsuarioID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_UsuarioID] ON [dbo].[Recibo]
(
	[UsuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Documento_TipoDocumentoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_Documento_TipoDocumentoID] ON [dbo].[Refinanciacion]
(
	[Documento] ASC,
	[TipoDocumentoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_ComercioID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_ComercioID] ON [dbo].[Refinanciacion]
(
	[EmpresaID] ASC,
	[ComercioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_ComercioID_CreditoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_ComercioID_CreditoID] ON [dbo].[Refinanciacion]
(
	[EmpresaID] ASC,
	[ComercioID] ASC,
	[CreditoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EstadoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EstadoID] ON [dbo].[Refinanciacion]
(
	[EstadoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UsuarioID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_UsuarioID] ON [dbo].[Refinanciacion]
(
	[UsuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Documento_TipoDocumentoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_Documento_TipoDocumentoID] ON [dbo].[RefinanciacionCobranza]
(
	[Documento] ASC,
	[TipoDocumentoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_ComercioID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_ComercioID] ON [dbo].[RefinanciacionCobranza]
(
	[EmpresaID] ASC,
	[ComercioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_ComercioID_CreditoID_RefinanciacionID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_ComercioID_CreditoID_RefinanciacionID] ON [dbo].[RefinanciacionCobranza]
(
	[EmpresaID] ASC,
	[ComercioID] ASC,
	[CreditoID] ASC,
	[RefinanciacionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_ComercioID_CreditoID_RefinanciacionID_RefinanciacionCuotaID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_ComercioID_CreditoID_RefinanciacionID_RefinanciacionCuotaID] ON [dbo].[RefinanciacionCobranza]
(
	[EmpresaID] ASC,
	[ComercioID] ASC,
	[CreditoID] ASC,
	[RefinanciacionID] ASC,
	[RefinanciacionCuotaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_TipoPagoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_TipoPagoID] ON [dbo].[RefinanciacionCobranza]
(
	[TipoPagoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Documento_TipoDocumentoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_Documento_TipoDocumentoID] ON [dbo].[RefinanciacionCuota]
(
	[Documento] ASC,
	[TipoDocumentoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_ComercioID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_ComercioID] ON [dbo].[RefinanciacionCuota]
(
	[EmpresaID] ASC,
	[ComercioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_ComercioID_CreditoID_RefinanciacionID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_ComercioID_CreditoID_RefinanciacionID] ON [dbo].[RefinanciacionCuota]
(
	[EmpresaID] ASC,
	[ComercioID] ASC,
	[CreditoID] ASC,
	[RefinanciacionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ConceptoFondosID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_ConceptoFondosID] ON [dbo].[SolicitudFondo]
(
	[ConceptoFondosID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpleadoRealizadorID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpleadoRealizadorID] ON [dbo].[SolicitudFondo]
(
	[EmpleadoRealizadorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpleadoSolicitanteID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpleadoSolicitanteID] ON [dbo].[SolicitudFondo]
(
	[EmpleadoSolicitanteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_ComercioID_AvisoDePagoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_ComercioID_AvisoDePagoID] ON [dbo].[SolicitudFondo]
(
	[EmpresaID] ASC,
	[ComercioID] ASC,
	[AvisoDePagoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_EmpresaID_CuentaBancariaID_NumChequera_NumCheque]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_CuentaBancariaID_NumChequera_NumCheque] ON [dbo].[SolicitudFondo]
(
	[EmpresaID] ASC,
	[CuentaBancariaID] ASC,
	[NumChequera] ASC,
	[NumCheque] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_TransferenciasDepositosID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_TransferenciasDepositosID] ON [dbo].[SolicitudFondo]
(
	[EmpresaID] ASC,
	[TransferenciasDepositosID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EstadoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EstadoID] ON [dbo].[SolicitudFondo]
(
	[EstadoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_GeneradoPorDepartamentoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_GeneradoPorDepartamentoID] ON [dbo].[SolicitudFondo]
(
	[GeneradoPorDepartamentoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_MedioDePagoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_MedioDePagoID] ON [dbo].[SolicitudFondo]
(
	[MedioDePagoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_MonedaID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_MonedaID] ON [dbo].[SolicitudFondo]
(
	[MonedaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TipoSolicitudID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_TipoSolicitudID] ON [dbo].[SolicitudFondo]
(
	[TipoSolicitudID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ConceptoGastosProveedorID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_ConceptoGastosProveedorID] ON [dbo].[SolicitudFondoConceptoGastosProveedor]
(
	[ConceptoGastosProveedorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_ComercioID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_ComercioID] ON [dbo].[SolicitudFondoConceptoGastosProveedor]
(
	[EmpresaID] ASC,
	[ComercioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_ComercioID_SolicitudFondoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_ComercioID_SolicitudFondoID] ON [dbo].[SolicitudFondoConceptoGastosProveedor]
(
	[EmpresaID] ASC,
	[ComercioID] ASC,
	[SolicitudFondoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_BancoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_BancoID] ON [dbo].[SucursalBanco]
(
	[BancoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PaisId_ProvinciaID_LocalidadID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_PaisId_ProvinciaID_LocalidadID] ON [dbo].[SucursalBanco]
(
	[PaisId] ASC,
	[ProvinciaID] ASC,
	[LocalidadID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClaseDatoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_ClaseDatoID] ON [dbo].[Telefono]
(
	[ClaseDatoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Documento_TipoDocumentoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_Documento_TipoDocumentoID] ON [dbo].[Telefono]
(
	[Documento] ASC,
	[TipoDocumentoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EstadoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EstadoID] ON [dbo].[Telefono]
(
	[EstadoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UsuarioID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_UsuarioID] ON [dbo].[Telefono]
(
	[UsuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClaseMovimientoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_ClaseMovimientoID] ON [dbo].[TipoMovimiento]
(
	[ClaseMovimientoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ChequeEmpID_ChequeCbID_ChequeNumChequera_ChequeNumCheque]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_ChequeEmpID_ChequeCbID_ChequeNumChequera_ChequeNumCheque] ON [dbo].[TransferenciasDepositos]
(
	[ChequeEmpID] ASC,
	[ChequeCbID] ASC,
	[ChequeNumChequera] ASC,
	[ChequeNumCheque] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ComercioEmpresa_EmpresaID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_ComercioEmpresa_EmpresaID] ON [dbo].[TransferenciasDepositos]
(
	[ComercioEmpresa_EmpresaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CuentaDestinoEmpresaID_CuentaDestinoCbID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_CuentaDestinoEmpresaID_CuentaDestinoCbID] ON [dbo].[TransferenciasDepositos]
(
	[CuentaDestinoEmpresaID] ASC,
	[CuentaDestinoCbID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CuentaOrigenEmpresaID_CuentaOrigenCbID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_CuentaOrigenEmpresaID_CuentaOrigenCbID] ON [dbo].[TransferenciasDepositos]
(
	[CuentaOrigenEmpresaID] ASC,
	[CuentaOrigenCbID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpleadoRegistrador_EmpleadoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpleadoRegistrador_EmpleadoID] ON [dbo].[TransferenciasDepositos]
(
	[EmpleadoRegistrador_EmpleadoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_ComercioID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_ComercioID] ON [dbo].[TransferenciasDepositos]
(
	[EmpresaID] ASC,
	[ComercioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EstadoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EstadoID] ON [dbo].[TransferenciasDepositos]
(
	[EstadoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_MedioDePagoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_MedioDePagoID] ON [dbo].[TransferenciasDepositos]
(
	[MedioDePagoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_MonedaID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_MonedaID] ON [dbo].[TransferenciasDepositos]
(
	[MonedaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PersonaId]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_PersonaId] ON [dbo].[TransferenciasDepositos]
(
	[PersonaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProveedorSucursalID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_ProveedorSucursalID] ON [dbo].[TransferenciasDepositos]
(
	[ProveedorSucursalID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TipoTransferenciaDepositoID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_TipoTransferenciaDepositoID] ON [dbo].[TransferenciasDepositos]
(
	[TipoTransferenciaDepositoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UsuarioID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_UsuarioID] ON [dbo].[TransferenciasDepositos]
(
	[UsuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpresaID_ComercioID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EmpresaID_ComercioID] ON [dbo].[Transmision]
(
	[EmpresaID] ASC,
	[ComercioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EstadoTransmisionID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_EstadoTransmisionID] ON [dbo].[Transmision]
(
	[EstadoTransmisionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OperacionID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_OperacionID] ON [dbo].[Transmision]
(
	[OperacionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PerfilID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_PerfilID] ON [dbo].[UsuariosPerfiles]
(
	[PerfilID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UsuarioID]    Script Date: 29/3/2026 11:28:52 ******/
CREATE NONCLUSTERED INDEX [IX_UsuarioID] ON [dbo].[UsuariosPerfiles]
(
	[UsuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Credito] ADD  DEFAULT ('1900-01-01T00:00:00.000') FOR [FechaDesdeDebito]
GO
ALTER TABLE [dbo].[Credito] ADD  DEFAULT ((0)) FOR [AdelantadaGastos]
GO
ALTER TABLE [dbo].[CuentaBancaria] ADD  DEFAULT ((0)) FOR [DebitoDirecto]
GO
ALTER TABLE [dbo].[CuentaBancaria] ADD  DEFAULT ((0)) FOR [orden]
GO
ALTER TABLE [dbo].[Autorizacion]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Autorizacion_dbo.Comercio_EmpresaID_ComercioID] FOREIGN KEY([EmpresaID], [ComercioID])
REFERENCES [dbo].[Comercio] ([EmpresaID], [ComercioID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Autorizacion] CHECK CONSTRAINT [FK_dbo.Autorizacion_dbo.Comercio_EmpresaID_ComercioID]
GO
ALTER TABLE [dbo].[Autorizacion]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Autorizacion_dbo.Empresa_EmpresaID] FOREIGN KEY([EmpresaID])
REFERENCES [dbo].[Empresa] ([EmpresaID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Autorizacion] CHECK CONSTRAINT [FK_dbo.Autorizacion_dbo.Empresa_EmpresaID]
GO
ALTER TABLE [dbo].[Autorizacion]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Autorizacion_dbo.Estado_EstadoID] FOREIGN KEY([EstadoID])
REFERENCES [dbo].[Estado] ([EstadoID])
GO
ALTER TABLE [dbo].[Autorizacion] CHECK CONSTRAINT [FK_dbo.Autorizacion_dbo.Estado_EstadoID]
GO
ALTER TABLE [dbo].[Autorizacion]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Autorizacion_dbo.Persona_PersonaID] FOREIGN KEY([PersonaID])
REFERENCES [dbo].[Persona] ([PersonaID])
GO
ALTER TABLE [dbo].[Autorizacion] CHECK CONSTRAINT [FK_dbo.Autorizacion_dbo.Persona_PersonaID]
GO
ALTER TABLE [dbo].[AvisoDePago]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AvisoDePago_dbo.Comercio_EmpresaID_ComercioID] FOREIGN KEY([EmpresaID], [ComercioID])
REFERENCES [dbo].[Comercio] ([EmpresaID], [ComercioID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AvisoDePago] CHECK CONSTRAINT [FK_dbo.AvisoDePago_dbo.Comercio_EmpresaID_ComercioID]
GO
ALTER TABLE [dbo].[AvisoDePago]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AvisoDePago_dbo.Empresa_EmpresaID] FOREIGN KEY([EmpresaID])
REFERENCES [dbo].[Empresa] ([EmpresaID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AvisoDePago] CHECK CONSTRAINT [FK_dbo.AvisoDePago_dbo.Empresa_EmpresaID]
GO
ALTER TABLE [dbo].[Cap]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Cap_dbo.Comercio_EmpresaID_ComercioID] FOREIGN KEY([EmpresaID], [ComercioID])
REFERENCES [dbo].[Comercio] ([EmpresaID], [ComercioID])
GO
ALTER TABLE [dbo].[Cap] CHECK CONSTRAINT [FK_dbo.Cap_dbo.Comercio_EmpresaID_ComercioID]
GO
ALTER TABLE [dbo].[Cap]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Cap_dbo.Empresa_EmpresaID] FOREIGN KEY([EmpresaID])
REFERENCES [dbo].[Empresa] ([EmpresaID])
GO
ALTER TABLE [dbo].[Cap] CHECK CONSTRAINT [FK_dbo.Cap_dbo.Empresa_EmpresaID]
GO
ALTER TABLE [dbo].[Cap]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Cap_dbo.Estado_EstadoID] FOREIGN KEY([EstadoID])
REFERENCES [dbo].[Estado] ([EstadoID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cap] CHECK CONSTRAINT [FK_dbo.Cap_dbo.Estado_EstadoID]
GO
ALTER TABLE [dbo].[Cap]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Cap_dbo.SolicitudFondo_EmpresaID_ComercioID_SolicitudFondoID] FOREIGN KEY([EmpresaID], [ComercioID], [SolicitudFondoID])
REFERENCES [dbo].[SolicitudFondo] ([EmpresaID], [ComercioID], [SolicitudFondoID])
GO
ALTER TABLE [dbo].[Cap] CHECK CONSTRAINT [FK_dbo.Cap_dbo.SolicitudFondo_EmpresaID_ComercioID_SolicitudFondoID]
GO
ALTER TABLE [dbo].[CapDetalle]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CapDetalle_dbo.Cap_EmpresaID_ComercioID_CapID] FOREIGN KEY([EmpresaID], [ComercioID], [CapID])
REFERENCES [dbo].[Cap] ([EmpresaID], [ComercioID], [CapID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CapDetalle] CHECK CONSTRAINT [FK_dbo.CapDetalle_dbo.Cap_EmpresaID_ComercioID_CapID]
GO
ALTER TABLE [dbo].[Cheque]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Cheque_dbo.Chequera_EmpresaID_CuentaBancariaID_ChequeraID] FOREIGN KEY([EmpresaID], [CuentaBancariaID], [ChequeraID])
REFERENCES [dbo].[Chequera] ([EmpresaID], [CuentaBancariaID], [ChequeraID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cheque] CHECK CONSTRAINT [FK_dbo.Cheque_dbo.Chequera_EmpresaID_CuentaBancariaID_ChequeraID]
GO
ALTER TABLE [dbo].[Cheque]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Cheque_dbo.Estado_EstadoID] FOREIGN KEY([EstadoID])
REFERENCES [dbo].[Estado] ([EstadoID])
GO
ALTER TABLE [dbo].[Cheque] CHECK CONSTRAINT [FK_dbo.Cheque_dbo.Estado_EstadoID]
GO
ALTER TABLE [dbo].[Cheque]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Cheque_dbo.TipoCheque_TipoChequeID] FOREIGN KEY([TipoChequeID])
REFERENCES [dbo].[TipoCheque] ([TipoChequeID])
GO
ALTER TABLE [dbo].[Cheque] CHECK CONSTRAINT [FK_dbo.Cheque_dbo.TipoCheque_TipoChequeID]
GO
ALTER TABLE [dbo].[Chequera]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Chequera_dbo.CuentaBancaria_EmpresaID_CuentaBancariaID] FOREIGN KEY([EmpresaID], [CuentaBancariaID])
REFERENCES [dbo].[CuentaBancaria] ([EmpresaID], [CuentaBancariaID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Chequera] CHECK CONSTRAINT [FK_dbo.Chequera_dbo.CuentaBancaria_EmpresaID_CuentaBancariaID]
GO
ALTER TABLE [dbo].[Chequera]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Chequera_dbo.Estado_EstadoID] FOREIGN KEY([EstadoID])
REFERENCES [dbo].[Estado] ([EstadoID])
GO
ALTER TABLE [dbo].[Chequera] CHECK CONSTRAINT [FK_dbo.Chequera_dbo.Estado_EstadoID]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Cliente_dbo.Estado_EstadoID] FOREIGN KEY([EstadoID])
REFERENCES [dbo].[Estado] ([EstadoID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_dbo.Cliente_dbo.Estado_EstadoID]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Cliente_dbo.Profesion_ProfesionID] FOREIGN KEY([ProfesionID])
REFERENCES [dbo].[Profesion] ([ProfesionID])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_dbo.Cliente_dbo.Profesion_ProfesionID]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Cliente_dbo.Sexo_SexoID] FOREIGN KEY([SexoID])
REFERENCES [dbo].[Sexo] ([SexoID])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_dbo.Cliente_dbo.Sexo_SexoID]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Cliente_dbo.TipoComoConocio_TipoComoConocioID] FOREIGN KEY([TipoComoConocioID])
REFERENCES [dbo].[TipoComoConocio] ([TipoComoConocioID])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_dbo.Cliente_dbo.TipoComoConocio_TipoComoConocioID]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Cliente_dbo.TipoDocumento_TipoDocumentoID] FOREIGN KEY([TipoDocumentoID])
REFERENCES [dbo].[TipoDocumento] ([TipoDocumentoID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_dbo.Cliente_dbo.TipoDocumento_TipoDocumentoID]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Cliente_dbo.Usuario_UsuarioModificacionID] FOREIGN KEY([UsuarioModificacionID])
REFERENCES [dbo].[Usuario] ([UsuarioID])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_dbo.Cliente_dbo.Usuario_UsuarioModificacionID]
GO
ALTER TABLE [dbo].[Cobranza]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Cobranza_dbo.Cliente_Documento_TipoDocumentoID] FOREIGN KEY([Documento], [TipoDocumentoID])
REFERENCES [dbo].[Cliente] ([Documento], [TipoDocumentoID])
GO
ALTER TABLE [dbo].[Cobranza] CHECK CONSTRAINT [FK_dbo.Cobranza_dbo.Cliente_Documento_TipoDocumentoID]
GO
ALTER TABLE [dbo].[Cobranza]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Cobranza_dbo.Comercio_EmpresaID_ComercioID] FOREIGN KEY([EmpresaID], [ComercioID])
REFERENCES [dbo].[Comercio] ([EmpresaID], [ComercioID])
GO
ALTER TABLE [dbo].[Cobranza] CHECK CONSTRAINT [FK_dbo.Cobranza_dbo.Comercio_EmpresaID_ComercioID]
GO
ALTER TABLE [dbo].[Cobranza]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Cobranza_dbo.Credito_EmpresaID_ComercioID_CreditoID] FOREIGN KEY([EmpresaID], [ComercioID], [CreditoID])
REFERENCES [dbo].[Credito] ([EmpresaID], [ComercioID], [CreditoID])
GO
ALTER TABLE [dbo].[Cobranza] CHECK CONSTRAINT [FK_dbo.Cobranza_dbo.Credito_EmpresaID_ComercioID_CreditoID]
GO
ALTER TABLE [dbo].[Cobranza]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Cobranza_dbo.Cuota_EmpresaID_ComercioID_CreditoID_CuotaID] FOREIGN KEY([EmpresaID], [ComercioID], [CreditoID], [CuotaID])
REFERENCES [dbo].[Cuota] ([EmpresaID], [ComercioID], [CreditoID], [CuotaID])
GO
ALTER TABLE [dbo].[Cobranza] CHECK CONSTRAINT [FK_dbo.Cobranza_dbo.Cuota_EmpresaID_ComercioID_CreditoID_CuotaID]
GO
ALTER TABLE [dbo].[Cobranza]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Cobranza_dbo.Empresa_EmpresaID] FOREIGN KEY([EmpresaID])
REFERENCES [dbo].[Empresa] ([EmpresaID])
GO
ALTER TABLE [dbo].[Cobranza] CHECK CONSTRAINT [FK_dbo.Cobranza_dbo.Empresa_EmpresaID]
GO
ALTER TABLE [dbo].[Cobranza]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Cobranza_dbo.TipoBonificacion_TipoBonificacionID] FOREIGN KEY([TipoBonificacionID])
REFERENCES [dbo].[TipoBonificacion] ([TipoBonificacionID])
GO
ALTER TABLE [dbo].[Cobranza] CHECK CONSTRAINT [FK_dbo.Cobranza_dbo.TipoBonificacion_TipoBonificacionID]
GO
ALTER TABLE [dbo].[Cobranza]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Cobranza_dbo.TipoPago_TipoPagoID] FOREIGN KEY([TipoPagoID])
REFERENCES [dbo].[TipoPago] ([TipoPagoID])
GO
ALTER TABLE [dbo].[Cobranza] CHECK CONSTRAINT [FK_dbo.Cobranza_dbo.TipoPago_TipoPagoID]
GO
ALTER TABLE [dbo].[Cobranza]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Cobranza_dbo.Usuario_UsuarioID] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuario] ([UsuarioID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cobranza] CHECK CONSTRAINT [FK_dbo.Cobranza_dbo.Usuario_UsuarioID]
GO
ALTER TABLE [dbo].[Comercio]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Comercio_dbo.Empresa_EmpresaID] FOREIGN KEY([EmpresaID])
REFERENCES [dbo].[Empresa] ([EmpresaID])
GO
ALTER TABLE [dbo].[Comercio] CHECK CONSTRAINT [FK_dbo.Comercio_dbo.Empresa_EmpresaID]
GO
ALTER TABLE [dbo].[Comercio]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Comercio_dbo.Localidad_PaisId_ProvinciaID_LocalidadID] FOREIGN KEY([PaisId], [ProvinciaID], [LocalidadID])
REFERENCES [dbo].[Localidad] ([PaisId], [ProvinciaID], [LocalidadID])
GO
ALTER TABLE [dbo].[Comercio] CHECK CONSTRAINT [FK_dbo.Comercio_dbo.Localidad_PaisId_ProvinciaID_LocalidadID]
GO
ALTER TABLE [dbo].[Comercio]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Comercio_dbo.Pais_PaisId] FOREIGN KEY([PaisId])
REFERENCES [dbo].[Pais] ([PaisID])
GO
ALTER TABLE [dbo].[Comercio] CHECK CONSTRAINT [FK_dbo.Comercio_dbo.Pais_PaisId]
GO
ALTER TABLE [dbo].[Comercio]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Comercio_dbo.Persona_Contacto1_PersonaID] FOREIGN KEY([Contacto1_PersonaID])
REFERENCES [dbo].[Persona] ([PersonaID])
GO
ALTER TABLE [dbo].[Comercio] CHECK CONSTRAINT [FK_dbo.Comercio_dbo.Persona_Contacto1_PersonaID]
GO
ALTER TABLE [dbo].[Comercio]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Comercio_dbo.Persona_Contacto2_PersonaID] FOREIGN KEY([Contacto2_PersonaID])
REFERENCES [dbo].[Persona] ([PersonaID])
GO
ALTER TABLE [dbo].[Comercio] CHECK CONSTRAINT [FK_dbo.Comercio_dbo.Persona_Contacto2_PersonaID]
GO
ALTER TABLE [dbo].[Comercio]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Comercio_dbo.Persona_Titular1_PersonaID] FOREIGN KEY([Titular1_PersonaID])
REFERENCES [dbo].[Persona] ([PersonaID])
GO
ALTER TABLE [dbo].[Comercio] CHECK CONSTRAINT [FK_dbo.Comercio_dbo.Persona_Titular1_PersonaID]
GO
ALTER TABLE [dbo].[Comercio]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Comercio_dbo.Persona_Titular2_PersonaID] FOREIGN KEY([Titular2_PersonaID])
REFERENCES [dbo].[Persona] ([PersonaID])
GO
ALTER TABLE [dbo].[Comercio] CHECK CONSTRAINT [FK_dbo.Comercio_dbo.Persona_Titular2_PersonaID]
GO
ALTER TABLE [dbo].[Comercio]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Comercio_dbo.Provincia_PaisId_ProvinciaID] FOREIGN KEY([PaisId], [ProvinciaID])
REFERENCES [dbo].[Provincia] ([PaisId], [ProvinciaID])
GO
ALTER TABLE [dbo].[Comercio] CHECK CONSTRAINT [FK_dbo.Comercio_dbo.Provincia_PaisId_ProvinciaID]
GO
ALTER TABLE [dbo].[Comercio]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Comercio_dbo.TipoComercio_TipoComercioID] FOREIGN KEY([TipoComercioID])
REFERENCES [dbo].[TipoComercio] ([TipoComercioID])
GO
ALTER TABLE [dbo].[Comercio] CHECK CONSTRAINT [FK_dbo.Comercio_dbo.TipoComercio_TipoComercioID]
GO
ALTER TABLE [dbo].[ConceptoFondos]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ConceptoFondos_dbo.MedioDePago_MedioDePagoID] FOREIGN KEY([MedioDePagoID])
REFERENCES [dbo].[MedioDePago] ([MedioDePagoID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ConceptoFondos] CHECK CONSTRAINT [FK_dbo.ConceptoFondos_dbo.MedioDePago_MedioDePagoID]
GO
ALTER TABLE [dbo].[ConceptoGastos]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ConceptoGastos_dbo.ConceptoGastos_ConceptoGastoPadreID] FOREIGN KEY([ConceptoGastoPadreID])
REFERENCES [dbo].[ConceptoGastos] ([ConceptoGastosID])
GO
ALTER TABLE [dbo].[ConceptoGastos] CHECK CONSTRAINT [FK_dbo.ConceptoGastos_dbo.ConceptoGastos_ConceptoGastoPadreID]
GO
ALTER TABLE [dbo].[ConceptoGastos]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ConceptoGastos_dbo.Estado_EstadoID] FOREIGN KEY([EstadoID])
REFERENCES [dbo].[Estado] ([EstadoID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ConceptoGastos] CHECK CONSTRAINT [FK_dbo.ConceptoGastos_dbo.Estado_EstadoID]
GO
ALTER TABLE [dbo].[ConceptoGastosDepartamento]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ConceptoGastosDepartamento_dbo.ConceptoGastos_ConceptoGastosID] FOREIGN KEY([ConceptoGastosID])
REFERENCES [dbo].[ConceptoGastos] ([ConceptoGastosID])
GO
ALTER TABLE [dbo].[ConceptoGastosDepartamento] CHECK CONSTRAINT [FK_dbo.ConceptoGastosDepartamento_dbo.ConceptoGastos_ConceptoGastosID]
GO
ALTER TABLE [dbo].[ConceptoGastosDepartamento]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ConceptoGastosDepartamento_dbo.Departamento_DepartamentoID] FOREIGN KEY([DepartamentoID])
REFERENCES [dbo].[Departamento] ([DepartamentoID])
GO
ALTER TABLE [dbo].[ConceptoGastosDepartamento] CHECK CONSTRAINT [FK_dbo.ConceptoGastosDepartamento_dbo.Departamento_DepartamentoID]
GO
ALTER TABLE [dbo].[ConceptoGastosDepartamento]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ConceptoGastosDepartamento_dbo.Estado_EstadoID] FOREIGN KEY([EstadoID])
REFERENCES [dbo].[Estado] ([EstadoID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ConceptoGastosDepartamento] CHECK CONSTRAINT [FK_dbo.ConceptoGastosDepartamento_dbo.Estado_EstadoID]
GO
ALTER TABLE [dbo].[ConceptoGastosProveedor]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ConceptoGastosProveedor_dbo.ConceptoGastos_ConceptoGastosID] FOREIGN KEY([ConceptoGastosID])
REFERENCES [dbo].[ConceptoGastos] ([ConceptoGastosID])
GO
ALTER TABLE [dbo].[ConceptoGastosProveedor] CHECK CONSTRAINT [FK_dbo.ConceptoGastosProveedor_dbo.ConceptoGastos_ConceptoGastosID]
GO
ALTER TABLE [dbo].[ConceptoGastosProveedor]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ConceptoGastosProveedor_dbo.Estado_EstadoID] FOREIGN KEY([EstadoID])
REFERENCES [dbo].[Estado] ([EstadoID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ConceptoGastosProveedor] CHECK CONSTRAINT [FK_dbo.ConceptoGastosProveedor_dbo.Estado_EstadoID]
GO
ALTER TABLE [dbo].[ConceptoGastosProveedor]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ConceptoGastosProveedor_dbo.Proveedor_ProveedorID] FOREIGN KEY([ProveedorID])
REFERENCES [dbo].[Proveedor] ([ProveedorID])
GO
ALTER TABLE [dbo].[ConceptoGastosProveedor] CHECK CONSTRAINT [FK_dbo.ConceptoGastosProveedor_dbo.Proveedor_ProveedorID]
GO
ALTER TABLE [dbo].[ConceptoGastosProveedor]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ConceptoGastosProveedor_dbo.ProveedorSucursal_ProveedorSucursalID] FOREIGN KEY([ProveedorSucursalID])
REFERENCES [dbo].[ProveedorSucursal] ([ProveedorSucursalID])
GO
ALTER TABLE [dbo].[ConceptoGastosProveedor] CHECK CONSTRAINT [FK_dbo.ConceptoGastosProveedor_dbo.ProveedorSucursal_ProveedorSucursalID]
GO
ALTER TABLE [dbo].[Credito]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Credito_dbo.AvisoDePago_EmpresaID_ComercioID_AvisoDePagoID] FOREIGN KEY([EmpresaID], [ComercioID], [AvisoDePagoID])
REFERENCES [dbo].[AvisoDePago] ([EmpresaID], [ComercioID], [AvisoDePagoID])
GO
ALTER TABLE [dbo].[Credito] CHECK CONSTRAINT [FK_dbo.Credito_dbo.AvisoDePago_EmpresaID_ComercioID_AvisoDePagoID]
GO
ALTER TABLE [dbo].[Credito]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Credito_dbo.Cliente_Adicional_TipoDocumentoIDAdi] FOREIGN KEY([Adicional], [TipoDocumentoIDAdi])
REFERENCES [dbo].[Cliente] ([Documento], [TipoDocumentoID])
GO
ALTER TABLE [dbo].[Credito] CHECK CONSTRAINT [FK_dbo.Credito_dbo.Cliente_Adicional_TipoDocumentoIDAdi]
GO
ALTER TABLE [dbo].[Credito]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Credito_dbo.Cliente_Documento_TipoDocumentoID] FOREIGN KEY([Documento], [TipoDocumentoID])
REFERENCES [dbo].[Cliente] ([Documento], [TipoDocumentoID])
GO
ALTER TABLE [dbo].[Credito] CHECK CONSTRAINT [FK_dbo.Credito_dbo.Cliente_Documento_TipoDocumentoID]
GO
ALTER TABLE [dbo].[Credito]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Credito_dbo.Cliente_Garante1_TipoDocumentoIDG1] FOREIGN KEY([Garante1], [TipoDocumentoIDG1])
REFERENCES [dbo].[Cliente] ([Documento], [TipoDocumentoID])
GO
ALTER TABLE [dbo].[Credito] CHECK CONSTRAINT [FK_dbo.Credito_dbo.Cliente_Garante1_TipoDocumentoIDG1]
GO
ALTER TABLE [dbo].[Credito]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Credito_dbo.Cliente_Garante2_TipoDocumentoIDG2] FOREIGN KEY([Garante2], [TipoDocumentoIDG2])
REFERENCES [dbo].[Cliente] ([Documento], [TipoDocumentoID])
GO
ALTER TABLE [dbo].[Credito] CHECK CONSTRAINT [FK_dbo.Credito_dbo.Cliente_Garante2_TipoDocumentoIDG2]
GO
ALTER TABLE [dbo].[Credito]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Credito_dbo.Cliente_Garante3_TipoDocumentoIDG3] FOREIGN KEY([Garante3], [TipoDocumentoIDG3])
REFERENCES [dbo].[Cliente] ([Documento], [TipoDocumentoID])
GO
ALTER TABLE [dbo].[Credito] CHECK CONSTRAINT [FK_dbo.Credito_dbo.Cliente_Garante3_TipoDocumentoIDG3]
GO
ALTER TABLE [dbo].[Credito]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Credito_dbo.Comercio_EmpresaID_AbogadoID] FOREIGN KEY([EmpresaID], [AbogadoID])
REFERENCES [dbo].[Comercio] ([EmpresaID], [ComercioID])
GO
ALTER TABLE [dbo].[Credito] CHECK CONSTRAINT [FK_dbo.Credito_dbo.Comercio_EmpresaID_AbogadoID]
GO
ALTER TABLE [dbo].[Credito]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Credito_dbo.Comercio_EmpresaID_ComercioID] FOREIGN KEY([EmpresaID], [ComercioID])
REFERENCES [dbo].[Comercio] ([EmpresaID], [ComercioID])
GO
ALTER TABLE [dbo].[Credito] CHECK CONSTRAINT [FK_dbo.Credito_dbo.Comercio_EmpresaID_ComercioID]
GO
ALTER TABLE [dbo].[Credito]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Credito_dbo.Empresa_EmpresaID] FOREIGN KEY([EmpresaID])
REFERENCES [dbo].[Empresa] ([EmpresaID])
GO
ALTER TABLE [dbo].[Credito] CHECK CONSTRAINT [FK_dbo.Credito_dbo.Empresa_EmpresaID]
GO
ALTER TABLE [dbo].[Credito]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Credito_dbo.TipoBonificacion_TipoBonificacionID] FOREIGN KEY([TipoBonificacionID])
REFERENCES [dbo].[TipoBonificacion] ([TipoBonificacionID])
GO
ALTER TABLE [dbo].[Credito] CHECK CONSTRAINT [FK_dbo.Credito_dbo.TipoBonificacion_TipoBonificacionID]
GO
ALTER TABLE [dbo].[Credito]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Credito_dbo.TipoCuota_TipoCuotaID] FOREIGN KEY([TipoCuotaID])
REFERENCES [dbo].[TipoCuota] ([TipoCuotaID])
GO
ALTER TABLE [dbo].[Credito] CHECK CONSTRAINT [FK_dbo.Credito_dbo.TipoCuota_TipoCuotaID]
GO
ALTER TABLE [dbo].[Credito]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Credito_dbo.Usuario_usuarioAvalID] FOREIGN KEY([usuarioAvalID])
REFERENCES [dbo].[Usuario] ([UsuarioID])
GO
ALTER TABLE [dbo].[Credito] CHECK CONSTRAINT [FK_dbo.Credito_dbo.Usuario_usuarioAvalID]
GO
ALTER TABLE [dbo].[Credito]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Credito_dbo.Usuario_UsuarioID] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuario] ([UsuarioID])
GO
ALTER TABLE [dbo].[Credito] CHECK CONSTRAINT [FK_dbo.Credito_dbo.Usuario_UsuarioID]
GO
ALTER TABLE [dbo].[CreditoAnulado]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CreditoAnulado_dbo.Cliente_Documento_TipoDocumentoID] FOREIGN KEY([Documento], [TipoDocumentoID])
REFERENCES [dbo].[Cliente] ([Documento], [TipoDocumentoID])
GO
ALTER TABLE [dbo].[CreditoAnulado] CHECK CONSTRAINT [FK_dbo.CreditoAnulado_dbo.Cliente_Documento_TipoDocumentoID]
GO
ALTER TABLE [dbo].[CreditoAnulado]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CreditoAnulado_dbo.Comercio_EmpresaID_ComercioID] FOREIGN KEY([EmpresaID], [ComercioID])
REFERENCES [dbo].[Comercio] ([EmpresaID], [ComercioID])
GO
ALTER TABLE [dbo].[CreditoAnulado] CHECK CONSTRAINT [FK_dbo.CreditoAnulado_dbo.Comercio_EmpresaID_ComercioID]
GO
ALTER TABLE [dbo].[CreditoAnulado]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CreditoAnulado_dbo.Empresa_EmpresaID] FOREIGN KEY([EmpresaID])
REFERENCES [dbo].[Empresa] ([EmpresaID])
GO
ALTER TABLE [dbo].[CreditoAnulado] CHECK CONSTRAINT [FK_dbo.CreditoAnulado_dbo.Empresa_EmpresaID]
GO
ALTER TABLE [dbo].[CreditoAnulado]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CreditoAnulado_dbo.TipoAnulacion_TipoAnulacionID] FOREIGN KEY([TipoAnulacionID])
REFERENCES [dbo].[TipoAnulacion] ([TipoAnulacionID])
GO
ALTER TABLE [dbo].[CreditoAnulado] CHECK CONSTRAINT [FK_dbo.CreditoAnulado_dbo.TipoAnulacion_TipoAnulacionID]
GO
ALTER TABLE [dbo].[CreditoAnulado]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CreditoAnulado_dbo.Usuario_UsuarioID] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuario] ([UsuarioID])
GO
ALTER TABLE [dbo].[CreditoAnulado] CHECK CONSTRAINT [FK_dbo.CreditoAnulado_dbo.Usuario_UsuarioID]
GO
ALTER TABLE [dbo].[CreditoAval]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CreditoAval_dbo.Comercio_EmpresaID_ComercioID] FOREIGN KEY([EmpresaID], [ComercioID])
REFERENCES [dbo].[Comercio] ([EmpresaID], [ComercioID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CreditoAval] CHECK CONSTRAINT [FK_dbo.CreditoAval_dbo.Comercio_EmpresaID_ComercioID]
GO
ALTER TABLE [dbo].[CreditoAval]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CreditoAval_dbo.Credito_EmpresaID_ComercioID_CreditoID] FOREIGN KEY([EmpresaID], [ComercioID], [CreditoID])
REFERENCES [dbo].[Credito] ([EmpresaID], [ComercioID], [CreditoID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CreditoAval] CHECK CONSTRAINT [FK_dbo.CreditoAval_dbo.Credito_EmpresaID_ComercioID_CreditoID]
GO
ALTER TABLE [dbo].[CreditoAval]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CreditoAval_dbo.Empresa_EmpresaID] FOREIGN KEY([EmpresaID])
REFERENCES [dbo].[Empresa] ([EmpresaID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CreditoAval] CHECK CONSTRAINT [FK_dbo.CreditoAval_dbo.Empresa_EmpresaID]
GO
ALTER TABLE [dbo].[CreditoAval]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CreditoAval_dbo.TipoAval_TipoAvalID] FOREIGN KEY([TipoAvalID])
REFERENCES [dbo].[TipoAval] ([TipoAvalID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CreditoAval] CHECK CONSTRAINT [FK_dbo.CreditoAval_dbo.TipoAval_TipoAvalID]
GO
ALTER TABLE [dbo].[CreditoAval]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CreditoAval_dbo.Usuario_UsuarioID] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuario] ([UsuarioID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CreditoAval] CHECK CONSTRAINT [FK_dbo.CreditoAval_dbo.Usuario_UsuarioID]
GO
ALTER TABLE [dbo].[CuentaBancaria]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CuentaBancaria_dbo.Banco_BancoID] FOREIGN KEY([BancoID])
REFERENCES [dbo].[Banco] ([BancoID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CuentaBancaria] CHECK CONSTRAINT [FK_dbo.CuentaBancaria_dbo.Banco_BancoID]
GO
ALTER TABLE [dbo].[CuentaBancaria]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CuentaBancaria_dbo.ClaseCuentaBancaria_ClaseCuentaBancariaID] FOREIGN KEY([ClaseCuentaBancariaID])
REFERENCES [dbo].[ClaseCuentaBancaria] ([ClaseCuentaBancariaID])
GO
ALTER TABLE [dbo].[CuentaBancaria] CHECK CONSTRAINT [FK_dbo.CuentaBancaria_dbo.ClaseCuentaBancaria_ClaseCuentaBancariaID]
GO
ALTER TABLE [dbo].[CuentaBancaria]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CuentaBancaria_dbo.Comercio_EmpresaID_ComercioID] FOREIGN KEY([EmpresaID], [ComercioID])
REFERENCES [dbo].[Comercio] ([EmpresaID], [ComercioID])
GO
ALTER TABLE [dbo].[CuentaBancaria] CHECK CONSTRAINT [FK_dbo.CuentaBancaria_dbo.Comercio_EmpresaID_ComercioID]
GO
ALTER TABLE [dbo].[CuentaBancaria]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CuentaBancaria_dbo.Empresa_EmpresaID] FOREIGN KEY([EmpresaID])
REFERENCES [dbo].[Empresa] ([EmpresaID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CuentaBancaria] CHECK CONSTRAINT [FK_dbo.CuentaBancaria_dbo.Empresa_EmpresaID]
GO
ALTER TABLE [dbo].[CuentaBancaria]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CuentaBancaria_dbo.Estado_EstadoID] FOREIGN KEY([EstadoID])
REFERENCES [dbo].[Estado] ([EstadoID])
GO
ALTER TABLE [dbo].[CuentaBancaria] CHECK CONSTRAINT [FK_dbo.CuentaBancaria_dbo.Estado_EstadoID]
GO
ALTER TABLE [dbo].[CuentaBancaria]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CuentaBancaria_dbo.Moneda_MonedaID] FOREIGN KEY([MonedaID])
REFERENCES [dbo].[Moneda] ([MonedaID])
GO
ALTER TABLE [dbo].[CuentaBancaria] CHECK CONSTRAINT [FK_dbo.CuentaBancaria_dbo.Moneda_MonedaID]
GO
ALTER TABLE [dbo].[CuentaBancaria]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CuentaBancaria_dbo.Persona_PersonaID] FOREIGN KEY([PersonaID])
REFERENCES [dbo].[Persona] ([PersonaID])
GO
ALTER TABLE [dbo].[CuentaBancaria] CHECK CONSTRAINT [FK_dbo.CuentaBancaria_dbo.Persona_PersonaID]
GO
ALTER TABLE [dbo].[CuentaBancaria]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CuentaBancaria_dbo.Proveedor_Proveedor_ProveedorID] FOREIGN KEY([Proveedor_ProveedorID])
REFERENCES [dbo].[Proveedor] ([ProveedorID])
GO
ALTER TABLE [dbo].[CuentaBancaria] CHECK CONSTRAINT [FK_dbo.CuentaBancaria_dbo.Proveedor_Proveedor_ProveedorID]
GO
ALTER TABLE [dbo].[CuentaBancaria]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CuentaBancaria_dbo.ProveedorSucursal_ProveedorSucursal_ProveedorSucursalID] FOREIGN KEY([ProveedorSucursal_ProveedorSucursalID])
REFERENCES [dbo].[ProveedorSucursal] ([ProveedorSucursalID])
GO
ALTER TABLE [dbo].[CuentaBancaria] CHECK CONSTRAINT [FK_dbo.CuentaBancaria_dbo.ProveedorSucursal_ProveedorSucursal_ProveedorSucursalID]
GO
ALTER TABLE [dbo].[CuentaBancaria]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CuentaBancaria_dbo.SucursalBanco_BancoID_SucursalBancoID] FOREIGN KEY([BancoID], [SucursalBancoID])
REFERENCES [dbo].[SucursalBanco] ([BancoID], [SucursalBancoID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CuentaBancaria] CHECK CONSTRAINT [FK_dbo.CuentaBancaria_dbo.SucursalBanco_BancoID_SucursalBancoID]
GO
ALTER TABLE [dbo].[CuentaBancaria]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CuentaBancaria_dbo.TipoCuentaBancaria_TipoCuentaBancariaID] FOREIGN KEY([TipoCuentaBancariaID])
REFERENCES [dbo].[TipoCuentaBancaria] ([TipoCuentaBancariaID])
GO
ALTER TABLE [dbo].[CuentaBancaria] CHECK CONSTRAINT [FK_dbo.CuentaBancaria_dbo.TipoCuentaBancaria_TipoCuentaBancariaID]
GO
ALTER TABLE [dbo].[CuentaBancariaCliente]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CuentaBancariaCliente_dbo.Banco_BancoID] FOREIGN KEY([BancoID])
REFERENCES [dbo].[Banco] ([BancoID])
GO
ALTER TABLE [dbo].[CuentaBancariaCliente] CHECK CONSTRAINT [FK_dbo.CuentaBancariaCliente_dbo.Banco_BancoID]
GO
ALTER TABLE [dbo].[CuentaBancariaCliente]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CuentaBancariaCliente_dbo.Cliente_Documento_TipoDocumentoID] FOREIGN KEY([Documento], [TipoDocumentoID])
REFERENCES [dbo].[Cliente] ([Documento], [TipoDocumentoID])
GO
ALTER TABLE [dbo].[CuentaBancariaCliente] CHECK CONSTRAINT [FK_dbo.CuentaBancariaCliente_dbo.Cliente_Documento_TipoDocumentoID]
GO
ALTER TABLE [dbo].[CuentaBancariaCliente]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CuentaBancariaCliente_dbo.Estado_EstadoID] FOREIGN KEY([EstadoID])
REFERENCES [dbo].[Estado] ([EstadoID])
GO
ALTER TABLE [dbo].[CuentaBancariaCliente] CHECK CONSTRAINT [FK_dbo.CuentaBancariaCliente_dbo.Estado_EstadoID]
GO
ALTER TABLE [dbo].[CuentaBancariaCliente]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CuentaBancariaCliente_dbo.Moneda_MonedaID] FOREIGN KEY([MonedaID])
REFERENCES [dbo].[Moneda] ([MonedaID])
GO
ALTER TABLE [dbo].[CuentaBancariaCliente] CHECK CONSTRAINT [FK_dbo.CuentaBancariaCliente_dbo.Moneda_MonedaID]
GO
ALTER TABLE [dbo].[CuentaBancariaCliente]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CuentaBancariaCliente_dbo.SucursalBanco_BancoID_SucursalBancoID] FOREIGN KEY([BancoID], [SucursalBancoID])
REFERENCES [dbo].[SucursalBanco] ([BancoID], [SucursalBancoID])
GO
ALTER TABLE [dbo].[CuentaBancariaCliente] CHECK CONSTRAINT [FK_dbo.CuentaBancariaCliente_dbo.SucursalBanco_BancoID_SucursalBancoID]
GO
ALTER TABLE [dbo].[CuentaBancariaCliente]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CuentaBancariaCliente_dbo.TipoDocumento_TipoDocumentoID] FOREIGN KEY([TipoDocumentoID])
REFERENCES [dbo].[TipoDocumento] ([TipoDocumentoID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CuentaBancariaCliente] CHECK CONSTRAINT [FK_dbo.CuentaBancariaCliente_dbo.TipoDocumento_TipoDocumentoID]
GO
ALTER TABLE [dbo].[CuentaCorriente]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CuentaCorriente_dbo.Cobranza_EmpresaID_ComercioID_CreditoID_CuotaID_CobranzaID] FOREIGN KEY([EmpresaID], [ComercioID], [CreditoID], [CuotaID], [CobranzaID])
REFERENCES [dbo].[Cobranza] ([EmpresaID], [ComercioID], [CreditoID], [CuotaID], [CobranzaID])
GO
ALTER TABLE [dbo].[CuentaCorriente] CHECK CONSTRAINT [FK_dbo.CuentaCorriente_dbo.Cobranza_EmpresaID_ComercioID_CreditoID_CuotaID_CobranzaID]
GO
ALTER TABLE [dbo].[CuentaCorriente]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CuentaCorriente_dbo.Comercio_EmpresaID_ComercioID] FOREIGN KEY([EmpresaID], [ComercioID])
REFERENCES [dbo].[Comercio] ([EmpresaID], [ComercioID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CuentaCorriente] CHECK CONSTRAINT [FK_dbo.CuentaCorriente_dbo.Comercio_EmpresaID_ComercioID]
GO
ALTER TABLE [dbo].[CuentaCorriente]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CuentaCorriente_dbo.Credito_EmpresaID_ComercioID_CreditoID] FOREIGN KEY([EmpresaID], [ComercioID], [CreditoID])
REFERENCES [dbo].[Credito] ([EmpresaID], [ComercioID], [CreditoID])
GO
ALTER TABLE [dbo].[CuentaCorriente] CHECK CONSTRAINT [FK_dbo.CuentaCorriente_dbo.Credito_EmpresaID_ComercioID_CreditoID]
GO
ALTER TABLE [dbo].[CuentaCorriente]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CuentaCorriente_dbo.Cuota_EmpresaID_ComercioID_CreditoID_CuotaID] FOREIGN KEY([EmpresaID], [ComercioID], [CreditoID], [CuotaID])
REFERENCES [dbo].[Cuota] ([EmpresaID], [ComercioID], [CreditoID], [CuotaID])
GO
ALTER TABLE [dbo].[CuentaCorriente] CHECK CONSTRAINT [FK_dbo.CuentaCorriente_dbo.Cuota_EmpresaID_ComercioID_CreditoID_CuotaID]
GO
ALTER TABLE [dbo].[CuentaCorriente]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CuentaCorriente_dbo.Empresa_EmpresaID] FOREIGN KEY([EmpresaID])
REFERENCES [dbo].[Empresa] ([EmpresaID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CuentaCorriente] CHECK CONSTRAINT [FK_dbo.CuentaCorriente_dbo.Empresa_EmpresaID]
GO
ALTER TABLE [dbo].[CuentaCorriente]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CuentaCorriente_dbo.Gasto_EmpresaID_ComercioID_GastoID] FOREIGN KEY([EmpresaID], [ComercioID], [GastoID])
REFERENCES [dbo].[Gasto] ([EmpresaID], [ComercioID], [GastoID])
GO
ALTER TABLE [dbo].[CuentaCorriente] CHECK CONSTRAINT [FK_dbo.CuentaCorriente_dbo.Gasto_EmpresaID_ComercioID_GastoID]
GO
ALTER TABLE [dbo].[CuentaCorriente]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CuentaCorriente_dbo.NotasCD_EmpresaID_ComercioID_CreditoID_CuotaID_CobranzaID_NotaCDID] FOREIGN KEY([EmpresaID], [ComercioID], [CreditoID], [CuotaID], [CobranzaID], [NotaCDID])
REFERENCES [dbo].[NotasCD] ([EmpresaID], [ComercioID], [CreditoID], [CuotaID], [CobranzaID], [NotaCDID])
GO
ALTER TABLE [dbo].[CuentaCorriente] CHECK CONSTRAINT [FK_dbo.CuentaCorriente_dbo.NotasCD_EmpresaID_ComercioID_CreditoID_CuotaID_CobranzaID_NotaCDID]
GO
ALTER TABLE [dbo].[CuentaCorriente]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CuentaCorriente_dbo.Pago_EmpresaID_ComercioID_PagoID] FOREIGN KEY([EmpresaID], [ComercioID], [PagoID])
REFERENCES [dbo].[Pago] ([EmpresaID], [ComercioID], [PagoID])
GO
ALTER TABLE [dbo].[CuentaCorriente] CHECK CONSTRAINT [FK_dbo.CuentaCorriente_dbo.Pago_EmpresaID_ComercioID_PagoID]
GO
ALTER TABLE [dbo].[CuentaCorriente]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CuentaCorriente_dbo.Recibo_EmpresaID_ComercioID_ReciboID] FOREIGN KEY([EmpresaID], [ComercioID], [ReciboID])
REFERENCES [dbo].[Recibo] ([EmpresaID], [ComercioID], [ReciboID])
GO
ALTER TABLE [dbo].[CuentaCorriente] CHECK CONSTRAINT [FK_dbo.CuentaCorriente_dbo.Recibo_EmpresaID_ComercioID_ReciboID]
GO
ALTER TABLE [dbo].[CuentaCorriente]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CuentaCorriente_dbo.SolicitudFondo_EmpresaID_ComercioID_SolicitudFondoID] FOREIGN KEY([EmpresaID], [ComercioID], [SolicitudFondoID])
REFERENCES [dbo].[SolicitudFondo] ([EmpresaID], [ComercioID], [SolicitudFondoID])
GO
ALTER TABLE [dbo].[CuentaCorriente] CHECK CONSTRAINT [FK_dbo.CuentaCorriente_dbo.SolicitudFondo_EmpresaID_ComercioID_SolicitudFondoID]
GO
ALTER TABLE [dbo].[CuentaCorriente]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CuentaCorriente_dbo.TipoMovimiento_TipoMovimientoID] FOREIGN KEY([TipoMovimientoID])
REFERENCES [dbo].[TipoMovimiento] ([TipoMovimientoID])
GO
ALTER TABLE [dbo].[CuentaCorriente] CHECK CONSTRAINT [FK_dbo.CuentaCorriente_dbo.TipoMovimiento_TipoMovimientoID]
GO
ALTER TABLE [dbo].[CuentaCorriente]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CuentaCorriente_dbo.TransferenciasDepositos_EmpresaID_TransferenciaDepositoID] FOREIGN KEY([EmpresaID], [TransferenciaDepositoID])
REFERENCES [dbo].[TransferenciasDepositos] ([EmpresaID], [TransferenciasDepositosID])
GO
ALTER TABLE [dbo].[CuentaCorriente] CHECK CONSTRAINT [FK_dbo.CuentaCorriente_dbo.TransferenciasDepositos_EmpresaID_TransferenciaDepositoID]
GO
ALTER TABLE [dbo].[Cuota]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Cuota_dbo.Cliente_Documento_TipoDocumentoID] FOREIGN KEY([Documento], [TipoDocumentoID])
REFERENCES [dbo].[Cliente] ([Documento], [TipoDocumentoID])
GO
ALTER TABLE [dbo].[Cuota] CHECK CONSTRAINT [FK_dbo.Cuota_dbo.Cliente_Documento_TipoDocumentoID]
GO
ALTER TABLE [dbo].[Cuota]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Cuota_dbo.Comercio_EmpresaID_ComercioID] FOREIGN KEY([EmpresaID], [ComercioID])
REFERENCES [dbo].[Comercio] ([EmpresaID], [ComercioID])
GO
ALTER TABLE [dbo].[Cuota] CHECK CONSTRAINT [FK_dbo.Cuota_dbo.Comercio_EmpresaID_ComercioID]
GO
ALTER TABLE [dbo].[Cuota]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Cuota_dbo.Credito_EmpresaID_ComercioID_CreditoID] FOREIGN KEY([EmpresaID], [ComercioID], [CreditoID])
REFERENCES [dbo].[Credito] ([EmpresaID], [ComercioID], [CreditoID])
GO
ALTER TABLE [dbo].[Cuota] CHECK CONSTRAINT [FK_dbo.Cuota_dbo.Credito_EmpresaID_ComercioID_CreditoID]
GO
ALTER TABLE [dbo].[Cuota]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Cuota_dbo.Empresa_EmpresaID] FOREIGN KEY([EmpresaID])
REFERENCES [dbo].[Empresa] ([EmpresaID])
GO
ALTER TABLE [dbo].[Cuota] CHECK CONSTRAINT [FK_dbo.Cuota_dbo.Empresa_EmpresaID]
GO
ALTER TABLE [dbo].[Cuota]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Cuota_dbo.TipoCuota_TipoCuotaID] FOREIGN KEY([TipoCuotaID])
REFERENCES [dbo].[TipoCuota] ([TipoCuotaID])
GO
ALTER TABLE [dbo].[Cuota] CHECK CONSTRAINT [FK_dbo.Cuota_dbo.TipoCuota_TipoCuotaID]
GO
ALTER TABLE [dbo].[Departamento]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Departamento_dbo.ConceptoFondos_ConceptoFondos_ConceptoFondosID] FOREIGN KEY([ConceptoFondos_ConceptoFondosID])
REFERENCES [dbo].[ConceptoFondos] ([ConceptoFondosID])
GO
ALTER TABLE [dbo].[Departamento] CHECK CONSTRAINT [FK_dbo.Departamento_dbo.ConceptoFondos_ConceptoFondos_ConceptoFondosID]
GO
ALTER TABLE [dbo].[Domicilio]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Domicilio_dbo.ClaseDato_ClaseDatoID] FOREIGN KEY([ClaseDatoID])
REFERENCES [dbo].[ClaseDato] ([ClaseDatoID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Domicilio] CHECK CONSTRAINT [FK_dbo.Domicilio_dbo.ClaseDato_ClaseDatoID]
GO
ALTER TABLE [dbo].[Domicilio]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Domicilio_dbo.Cliente_Documento_TipoDocumentoID] FOREIGN KEY([Documento], [TipoDocumentoID])
REFERENCES [dbo].[Cliente] ([Documento], [TipoDocumentoID])
GO
ALTER TABLE [dbo].[Domicilio] CHECK CONSTRAINT [FK_dbo.Domicilio_dbo.Cliente_Documento_TipoDocumentoID]
GO
ALTER TABLE [dbo].[Domicilio]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Domicilio_dbo.Estado_EstadoID] FOREIGN KEY([EstadoID])
REFERENCES [dbo].[Estado] ([EstadoID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Domicilio] CHECK CONSTRAINT [FK_dbo.Domicilio_dbo.Estado_EstadoID]
GO
ALTER TABLE [dbo].[Domicilio]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Domicilio_dbo.Localidad_PaisId_ProvinciaID_LocalidadID] FOREIGN KEY([PaisId], [ProvinciaID], [LocalidadID])
REFERENCES [dbo].[Localidad] ([PaisId], [ProvinciaID], [LocalidadID])
GO
ALTER TABLE [dbo].[Domicilio] CHECK CONSTRAINT [FK_dbo.Domicilio_dbo.Localidad_PaisId_ProvinciaID_LocalidadID]
GO
ALTER TABLE [dbo].[Domicilio]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Domicilio_dbo.Pais_PaisId] FOREIGN KEY([PaisId])
REFERENCES [dbo].[Pais] ([PaisID])
GO
ALTER TABLE [dbo].[Domicilio] CHECK CONSTRAINT [FK_dbo.Domicilio_dbo.Pais_PaisId]
GO
ALTER TABLE [dbo].[Domicilio]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Domicilio_dbo.Provincia_PaisId_ProvinciaID] FOREIGN KEY([PaisId], [ProvinciaID])
REFERENCES [dbo].[Provincia] ([PaisId], [ProvinciaID])
GO
ALTER TABLE [dbo].[Domicilio] CHECK CONSTRAINT [FK_dbo.Domicilio_dbo.Provincia_PaisId_ProvinciaID]
GO
ALTER TABLE [dbo].[Domicilio]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Domicilio_dbo.Usuario_UsuarioID] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuario] ([UsuarioID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Domicilio] CHECK CONSTRAINT [FK_dbo.Domicilio_dbo.Usuario_UsuarioID]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Empleado_dbo.Cargo_CargoID] FOREIGN KEY([CargoID])
REFERENCES [dbo].[Cargo] ([CargoId])
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [FK_dbo.Empleado_dbo.Cargo_CargoID]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Empleado_dbo.Comercio_EmpresaID_ComercioID] FOREIGN KEY([EmpresaID], [ComercioID])
REFERENCES [dbo].[Comercio] ([EmpresaID], [ComercioID])
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [FK_dbo.Empleado_dbo.Comercio_EmpresaID_ComercioID]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Empleado_dbo.Departamento_DepartamentoID] FOREIGN KEY([DepartamentoID])
REFERENCES [dbo].[Departamento] ([DepartamentoID])
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [FK_dbo.Empleado_dbo.Departamento_DepartamentoID]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Empleado_dbo.Empresa_EmpresaID] FOREIGN KEY([EmpresaID])
REFERENCES [dbo].[Empresa] ([EmpresaID])
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [FK_dbo.Empleado_dbo.Empresa_EmpresaID]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Empleado_dbo.Estado_EstadoId] FOREIGN KEY([EstadoId])
REFERENCES [dbo].[Estado] ([EstadoID])
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [FK_dbo.Empleado_dbo.Estado_EstadoId]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Empleado_dbo.Persona_PersonaID] FOREIGN KEY([PersonaID])
REFERENCES [dbo].[Persona] ([PersonaID])
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [FK_dbo.Empleado_dbo.Persona_PersonaID]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Empleado_dbo.TipoEmpleado_TipoEmpleadoID] FOREIGN KEY([TipoEmpleadoID])
REFERENCES [dbo].[TipoEmpleado] ([TipoEmpleadoID])
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [FK_dbo.Empleado_dbo.TipoEmpleado_TipoEmpleadoID]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Empleado_dbo.Usuario_Usuarioid] FOREIGN KEY([Usuarioid])
REFERENCES [dbo].[Usuario] ([UsuarioID])
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [FK_dbo.Empleado_dbo.Usuario_Usuarioid]
GO
ALTER TABLE [dbo].[Estado]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Estado_dbo.TipoEstado_TipoEstadoID] FOREIGN KEY([TipoEstadoID])
REFERENCES [dbo].[TipoEstado] ([TipoEstadoID])
GO
ALTER TABLE [dbo].[Estado] CHECK CONSTRAINT [FK_dbo.Estado_dbo.TipoEstado_TipoEstadoID]
GO
ALTER TABLE [dbo].[FF]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FF_dbo.Comercio_EmpresaID_ComercioID] FOREIGN KEY([EmpresaID], [ComercioID])
REFERENCES [dbo].[Comercio] ([EmpresaID], [ComercioID])
GO
ALTER TABLE [dbo].[FF] CHECK CONSTRAINT [FK_dbo.FF_dbo.Comercio_EmpresaID_ComercioID]
GO
ALTER TABLE [dbo].[FF]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FF_dbo.Empresa_EmpresaID] FOREIGN KEY([EmpresaID])
REFERENCES [dbo].[Empresa] ([EmpresaID])
GO
ALTER TABLE [dbo].[FF] CHECK CONSTRAINT [FK_dbo.FF_dbo.Empresa_EmpresaID]
GO
ALTER TABLE [dbo].[FF]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FF_dbo.Estado_EstadoID] FOREIGN KEY([EstadoID])
REFERENCES [dbo].[Estado] ([EstadoID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FF] CHECK CONSTRAINT [FK_dbo.FF_dbo.Estado_EstadoID]
GO
ALTER TABLE [dbo].[FF]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FF_dbo.SolicitudFondo_EmpresaID_ComercioID_SolicitudFondoID] FOREIGN KEY([EmpresaID], [ComercioID], [SolicitudFondoID])
REFERENCES [dbo].[SolicitudFondo] ([EmpresaID], [ComercioID], [SolicitudFondoID])
GO
ALTER TABLE [dbo].[FF] CHECK CONSTRAINT [FK_dbo.FF_dbo.SolicitudFondo_EmpresaID_ComercioID_SolicitudFondoID]
GO
ALTER TABLE [dbo].[FFDetalle]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FFDetalle_dbo.FF_EmpresaID_ComercioID_FFID] FOREIGN KEY([EmpresaID], [ComercioID], [FFID])
REFERENCES [dbo].[FF] ([EmpresaID], [ComercioID], [FFID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FFDetalle] CHECK CONSTRAINT [FK_dbo.FFDetalle_dbo.FF_EmpresaID_ComercioID_FFID]
GO
ALTER TABLE [dbo].[Gasto]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Gasto_dbo.Comercio_EmpresaID_ComercioID] FOREIGN KEY([EmpresaID], [ComercioID])
REFERENCES [dbo].[Comercio] ([EmpresaID], [ComercioID])
GO
ALTER TABLE [dbo].[Gasto] CHECK CONSTRAINT [FK_dbo.Gasto_dbo.Comercio_EmpresaID_ComercioID]
GO
ALTER TABLE [dbo].[Gasto]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Gasto_dbo.ConceptoGastos_ConceptoGastoID] FOREIGN KEY([ConceptoGastoID])
REFERENCES [dbo].[ConceptoGastos] ([ConceptoGastosID])
GO
ALTER TABLE [dbo].[Gasto] CHECK CONSTRAINT [FK_dbo.Gasto_dbo.ConceptoGastos_ConceptoGastoID]
GO
ALTER TABLE [dbo].[Gasto]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Gasto_dbo.ConceptoGastosProveedor_ConceptoGastoProveedorID] FOREIGN KEY([ConceptoGastoProveedorID])
REFERENCES [dbo].[ConceptoGastosProveedor] ([ConceptoGastosProveedorID])
GO
ALTER TABLE [dbo].[Gasto] CHECK CONSTRAINT [FK_dbo.Gasto_dbo.ConceptoGastosProveedor_ConceptoGastoProveedorID]
GO
ALTER TABLE [dbo].[Gasto]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Gasto_dbo.Departamento_DepartamentoID] FOREIGN KEY([DepartamentoID])
REFERENCES [dbo].[Departamento] ([DepartamentoID])
GO
ALTER TABLE [dbo].[Gasto] CHECK CONSTRAINT [FK_dbo.Gasto_dbo.Departamento_DepartamentoID]
GO
ALTER TABLE [dbo].[Gasto]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Gasto_dbo.Empresa_EmpresaID] FOREIGN KEY([EmpresaID])
REFERENCES [dbo].[Empresa] ([EmpresaID])
GO
ALTER TABLE [dbo].[Gasto] CHECK CONSTRAINT [FK_dbo.Gasto_dbo.Empresa_EmpresaID]
GO
ALTER TABLE [dbo].[Gasto]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Gasto_dbo.Estado_EstadoID] FOREIGN KEY([EstadoID])
REFERENCES [dbo].[Estado] ([EstadoID])
GO
ALTER TABLE [dbo].[Gasto] CHECK CONSTRAINT [FK_dbo.Gasto_dbo.Estado_EstadoID]
GO
ALTER TABLE [dbo].[Gasto]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Gasto_dbo.Proveedor_ProveedorID] FOREIGN KEY([ProveedorID])
REFERENCES [dbo].[Proveedor] ([ProveedorID])
GO
ALTER TABLE [dbo].[Gasto] CHECK CONSTRAINT [FK_dbo.Gasto_dbo.Proveedor_ProveedorID]
GO
ALTER TABLE [dbo].[Gasto]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Gasto_dbo.ProveedorSucursal_ProveedorSucursalID] FOREIGN KEY([ProveedorSucursalID])
REFERENCES [dbo].[ProveedorSucursal] ([ProveedorSucursalID])
GO
ALTER TABLE [dbo].[Gasto] CHECK CONSTRAINT [FK_dbo.Gasto_dbo.ProveedorSucursal_ProveedorSucursalID]
GO
ALTER TABLE [dbo].[Gasto]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Gasto_dbo.SolicitudFondo_EmpresaID_ComercioID_SolicitudFondoID] FOREIGN KEY([EmpresaID], [ComercioID], [SolicitudFondoID])
REFERENCES [dbo].[SolicitudFondo] ([EmpresaID], [ComercioID], [SolicitudFondoID])
GO
ALTER TABLE [dbo].[Gasto] CHECK CONSTRAINT [FK_dbo.Gasto_dbo.SolicitudFondo_EmpresaID_ComercioID_SolicitudFondoID]
GO
ALTER TABLE [dbo].[Localidad]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Localidad_dbo.Pais_PaisId] FOREIGN KEY([PaisId])
REFERENCES [dbo].[Pais] ([PaisID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Localidad] CHECK CONSTRAINT [FK_dbo.Localidad_dbo.Pais_PaisId]
GO
ALTER TABLE [dbo].[Localidad]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Localidad_dbo.Provincia_PaisId_ProvinciaID] FOREIGN KEY([PaisId], [ProvinciaID])
REFERENCES [dbo].[Provincia] ([PaisId], [ProvinciaID])
GO
ALTER TABLE [dbo].[Localidad] CHECK CONSTRAINT [FK_dbo.Localidad_dbo.Provincia_PaisId_ProvinciaID]
GO
ALTER TABLE [dbo].[Mail]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Mail_dbo.ClaseDato_ClaseDatoID] FOREIGN KEY([ClaseDatoID])
REFERENCES [dbo].[ClaseDato] ([ClaseDatoID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Mail] CHECK CONSTRAINT [FK_dbo.Mail_dbo.ClaseDato_ClaseDatoID]
GO
ALTER TABLE [dbo].[Mail]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Mail_dbo.Cliente_Documento_TipoDocumentoID] FOREIGN KEY([Documento], [TipoDocumentoID])
REFERENCES [dbo].[Cliente] ([Documento], [TipoDocumentoID])
GO
ALTER TABLE [dbo].[Mail] CHECK CONSTRAINT [FK_dbo.Mail_dbo.Cliente_Documento_TipoDocumentoID]
GO
ALTER TABLE [dbo].[Mail]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Mail_dbo.Estado_EstadoID] FOREIGN KEY([EstadoID])
REFERENCES [dbo].[Estado] ([EstadoID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Mail] CHECK CONSTRAINT [FK_dbo.Mail_dbo.Estado_EstadoID]
GO
ALTER TABLE [dbo].[Mail]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Mail_dbo.Usuario_UsuarioID] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuario] ([UsuarioID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Mail] CHECK CONSTRAINT [FK_dbo.Mail_dbo.Usuario_UsuarioID]
GO
ALTER TABLE [dbo].[Moneda]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Moneda_dbo.Pais_PaisId] FOREIGN KEY([PaisId])
REFERENCES [dbo].[Pais] ([PaisID])
GO
ALTER TABLE [dbo].[Moneda] CHECK CONSTRAINT [FK_dbo.Moneda_dbo.Pais_PaisId]
GO
ALTER TABLE [dbo].[Nota]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Nota_dbo.Cliente_Documento_TipoDocumentoID] FOREIGN KEY([Documento], [TipoDocumentoID])
REFERENCES [dbo].[Cliente] ([Documento], [TipoDocumentoID])
GO
ALTER TABLE [dbo].[Nota] CHECK CONSTRAINT [FK_dbo.Nota_dbo.Cliente_Documento_TipoDocumentoID]
GO
ALTER TABLE [dbo].[Nota]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Nota_dbo.Cobranza_EmpresaID_ComercioID_CreditoID_CuotaID_CobranzaID] FOREIGN KEY([EmpresaID], [ComercioID], [CreditoID], [CuotaID], [CobranzaID])
REFERENCES [dbo].[Cobranza] ([EmpresaID], [ComercioID], [CreditoID], [CuotaID], [CobranzaID])
GO
ALTER TABLE [dbo].[Nota] CHECK CONSTRAINT [FK_dbo.Nota_dbo.Cobranza_EmpresaID_ComercioID_CreditoID_CuotaID_CobranzaID]
GO
ALTER TABLE [dbo].[Nota]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Nota_dbo.Credito_EmpresaID_ComercioID_CreditoID] FOREIGN KEY([EmpresaID], [ComercioID], [CreditoID])
REFERENCES [dbo].[Credito] ([EmpresaID], [ComercioID], [CreditoID])
GO
ALTER TABLE [dbo].[Nota] CHECK CONSTRAINT [FK_dbo.Nota_dbo.Credito_EmpresaID_ComercioID_CreditoID]
GO
ALTER TABLE [dbo].[Nota]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Nota_dbo.Cuota_EmpresaID_ComercioID_CreditoID_CuotaID] FOREIGN KEY([EmpresaID], [ComercioID], [CreditoID], [CuotaID])
REFERENCES [dbo].[Cuota] ([EmpresaID], [ComercioID], [CreditoID], [CuotaID])
GO
ALTER TABLE [dbo].[Nota] CHECK CONSTRAINT [FK_dbo.Nota_dbo.Cuota_EmpresaID_ComercioID_CreditoID_CuotaID]
GO
ALTER TABLE [dbo].[Nota]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Nota_dbo.Usuario_UsuarioID] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuario] ([UsuarioID])
GO
ALTER TABLE [dbo].[Nota] CHECK CONSTRAINT [FK_dbo.Nota_dbo.Usuario_UsuarioID]
GO
ALTER TABLE [dbo].[NotasCD]  WITH CHECK ADD  CONSTRAINT [FK_dbo.NotasCD_dbo.Cobranza_EmpresaID_ComercioID_CreditoID_CuotaID_CobranzaID] FOREIGN KEY([EmpresaID], [ComercioID], [CreditoID], [CuotaID], [CobranzaID])
REFERENCES [dbo].[Cobranza] ([EmpresaID], [ComercioID], [CreditoID], [CuotaID], [CobranzaID])
GO
ALTER TABLE [dbo].[NotasCD] CHECK CONSTRAINT [FK_dbo.NotasCD_dbo.Cobranza_EmpresaID_ComercioID_CreditoID_CuotaID_CobranzaID]
GO
ALTER TABLE [dbo].[NotasCD]  WITH CHECK ADD  CONSTRAINT [FK_dbo.NotasCD_dbo.Usuario_UsuarioID] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuario] ([UsuarioID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NotasCD] CHECK CONSTRAINT [FK_dbo.NotasCD_dbo.Usuario_UsuarioID]
GO
ALTER TABLE [dbo].[OrdenDePago]  WITH CHECK ADD  CONSTRAINT [FK_dbo.OrdenDePago_dbo.ConceptoFondos_ConceptoFondosID] FOREIGN KEY([ConceptoFondosID])
REFERENCES [dbo].[ConceptoFondos] ([ConceptoFondosID])
GO
ALTER TABLE [dbo].[OrdenDePago] CHECK CONSTRAINT [FK_dbo.OrdenDePago_dbo.ConceptoFondos_ConceptoFondosID]
GO
ALTER TABLE [dbo].[OrdenDePago]  WITH CHECK ADD  CONSTRAINT [FK_dbo.OrdenDePago_dbo.Empresa_EmpresaID] FOREIGN KEY([EmpresaID])
REFERENCES [dbo].[Empresa] ([EmpresaID])
GO
ALTER TABLE [dbo].[OrdenDePago] CHECK CONSTRAINT [FK_dbo.OrdenDePago_dbo.Empresa_EmpresaID]
GO
ALTER TABLE [dbo].[OrdenDePago]  WITH CHECK ADD  CONSTRAINT [FK_dbo.OrdenDePago_dbo.Estado_EstadoID] FOREIGN KEY([EstadoID])
REFERENCES [dbo].[Estado] ([EstadoID])
GO
ALTER TABLE [dbo].[OrdenDePago] CHECK CONSTRAINT [FK_dbo.OrdenDePago_dbo.Estado_EstadoID]
GO
ALTER TABLE [dbo].[Pago]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Pago_dbo.CapDetalle_EmpresaID_ComercioID_CapID_CapDetalleID] FOREIGN KEY([EmpresaID], [ComercioID], [CapID], [CapDetalleID])
REFERENCES [dbo].[CapDetalle] ([EmpresaID], [ComercioID], [CapID], [CapDetalleID])
GO
ALTER TABLE [dbo].[Pago] CHECK CONSTRAINT [FK_dbo.Pago_dbo.CapDetalle_EmpresaID_ComercioID_CapID_CapDetalleID]
GO
ALTER TABLE [dbo].[Pago]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Pago_dbo.Comercio_EmpresaID_ComercioID] FOREIGN KEY([EmpresaID], [ComercioID])
REFERENCES [dbo].[Comercio] ([EmpresaID], [ComercioID])
GO
ALTER TABLE [dbo].[Pago] CHECK CONSTRAINT [FK_dbo.Pago_dbo.Comercio_EmpresaID_ComercioID]
GO
ALTER TABLE [dbo].[Pago]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Pago_dbo.Empresa_EmpresaID] FOREIGN KEY([EmpresaID])
REFERENCES [dbo].[Empresa] ([EmpresaID])
GO
ALTER TABLE [dbo].[Pago] CHECK CONSTRAINT [FK_dbo.Pago_dbo.Empresa_EmpresaID]
GO
ALTER TABLE [dbo].[Pago]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Pago_dbo.Estado_EstadoID] FOREIGN KEY([EstadoID])
REFERENCES [dbo].[Estado] ([EstadoID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Pago] CHECK CONSTRAINT [FK_dbo.Pago_dbo.Estado_EstadoID]
GO
ALTER TABLE [dbo].[Pago]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Pago_dbo.FFDetalle_EmpresaID_ComercioID_FFID_FFDetalleID] FOREIGN KEY([EmpresaID], [ComercioID], [FFID], [FFDetalleID])
REFERENCES [dbo].[FFDetalle] ([EmpresaID], [ComercioID], [FFID], [FFDetalleID])
GO
ALTER TABLE [dbo].[Pago] CHECK CONSTRAINT [FK_dbo.Pago_dbo.FFDetalle_EmpresaID_ComercioID_FFID_FFDetalleID]
GO
ALTER TABLE [dbo].[Pago]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Pago_dbo.SolicitudFondo_EmpresaID_ComercioID_SolicitudFondoID] FOREIGN KEY([EmpresaID], [ComercioID], [SolicitudFondoID])
REFERENCES [dbo].[SolicitudFondo] ([EmpresaID], [ComercioID], [SolicitudFondoID])
GO
ALTER TABLE [dbo].[Pago] CHECK CONSTRAINT [FK_dbo.Pago_dbo.SolicitudFondo_EmpresaID_ComercioID_SolicitudFondoID]
GO
ALTER TABLE [dbo].[PerfilesPermisos]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PerfilesPermisos_dbo.Perfil_PerfilID] FOREIGN KEY([PerfilID])
REFERENCES [dbo].[Perfil] ([PerfilID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PerfilesPermisos] CHECK CONSTRAINT [FK_dbo.PerfilesPermisos_dbo.Perfil_PerfilID]
GO
ALTER TABLE [dbo].[PerfilesPermisos]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PerfilesPermisos_dbo.Permiso_PermisoID] FOREIGN KEY([PermisoID])
REFERENCES [dbo].[Permiso] ([PermisoID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PerfilesPermisos] CHECK CONSTRAINT [FK_dbo.PerfilesPermisos_dbo.Permiso_PermisoID]
GO
ALTER TABLE [dbo].[Persona]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Persona_dbo.Localidad_PaisID_ProvinciaID_LocalidadID] FOREIGN KEY([PaisID], [ProvinciaID], [LocalidadID])
REFERENCES [dbo].[Localidad] ([PaisId], [ProvinciaID], [LocalidadID])
GO
ALTER TABLE [dbo].[Persona] CHECK CONSTRAINT [FK_dbo.Persona_dbo.Localidad_PaisID_ProvinciaID_LocalidadID]
GO
ALTER TABLE [dbo].[Persona]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Persona_dbo.Pais_PaisID] FOREIGN KEY([PaisID])
REFERENCES [dbo].[Pais] ([PaisID])
GO
ALTER TABLE [dbo].[Persona] CHECK CONSTRAINT [FK_dbo.Persona_dbo.Pais_PaisID]
GO
ALTER TABLE [dbo].[Persona]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Persona_dbo.Provincia_PaisID_ProvinciaID] FOREIGN KEY([PaisID], [ProvinciaID])
REFERENCES [dbo].[Provincia] ([PaisId], [ProvinciaID])
GO
ALTER TABLE [dbo].[Persona] CHECK CONSTRAINT [FK_dbo.Persona_dbo.Provincia_PaisID_ProvinciaID]
GO
ALTER TABLE [dbo].[Persona]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Persona_dbo.TipoDocumento_TiposDocumento_TipoDocumentoID] FOREIGN KEY([TiposDocumento_TipoDocumentoID])
REFERENCES [dbo].[TipoDocumento] ([TipoDocumentoID])
GO
ALTER TABLE [dbo].[Persona] CHECK CONSTRAINT [FK_dbo.Persona_dbo.TipoDocumento_TiposDocumento_TipoDocumentoID]
GO
ALTER TABLE [dbo].[PlanesBonif]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PlanesBonif_dbo.Comercio_EmpresaID_ComercioID] FOREIGN KEY([EmpresaID], [ComercioID])
REFERENCES [dbo].[Comercio] ([EmpresaID], [ComercioID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PlanesBonif] CHECK CONSTRAINT [FK_dbo.PlanesBonif_dbo.Comercio_EmpresaID_ComercioID]
GO
ALTER TABLE [dbo].[PlanesBonif]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PlanesBonif_dbo.Empresa_EmpresaID] FOREIGN KEY([EmpresaID])
REFERENCES [dbo].[Empresa] ([EmpresaID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PlanesBonif] CHECK CONSTRAINT [FK_dbo.PlanesBonif_dbo.Empresa_EmpresaID]
GO
ALTER TABLE [dbo].[PlanesBonif]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PlanesBonif_dbo.PlanesTipo_PlanesTipoID] FOREIGN KEY([PlanesTipoID])
REFERENCES [dbo].[PlanesTipo] ([PlanesTipoID])
GO
ALTER TABLE [dbo].[PlanesBonif] CHECK CONSTRAINT [FK_dbo.PlanesBonif_dbo.PlanesTipo_PlanesTipoID]
GO
ALTER TABLE [dbo].[PlanesBonif]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PlanesBonif_dbo.Usuario_UsuarioID] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuario] ([UsuarioID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PlanesBonif] CHECK CONSTRAINT [FK_dbo.PlanesBonif_dbo.Usuario_UsuarioID]
GO
ALTER TABLE [dbo].[PlanesDetalle]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PlanesDetalle_dbo.Comercio_EmpresaID_ComercioID] FOREIGN KEY([EmpresaID], [ComercioID])
REFERENCES [dbo].[Comercio] ([EmpresaID], [ComercioID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PlanesDetalle] CHECK CONSTRAINT [FK_dbo.PlanesDetalle_dbo.Comercio_EmpresaID_ComercioID]
GO
ALTER TABLE [dbo].[PlanesDetalle]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PlanesDetalle_dbo.Empresa_EmpresaID] FOREIGN KEY([EmpresaID])
REFERENCES [dbo].[Empresa] ([EmpresaID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PlanesDetalle] CHECK CONSTRAINT [FK_dbo.PlanesDetalle_dbo.Empresa_EmpresaID]
GO
ALTER TABLE [dbo].[PlanesDetalle]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PlanesDetalle_dbo.PlanesTipo_PlanesTipoID] FOREIGN KEY([PlanesTipoID])
REFERENCES [dbo].[PlanesTipo] ([PlanesTipoID])
GO
ALTER TABLE [dbo].[PlanesDetalle] CHECK CONSTRAINT [FK_dbo.PlanesDetalle_dbo.PlanesTipo_PlanesTipoID]
GO
ALTER TABLE [dbo].[PlanesDetalle]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PlanesDetalle_dbo.Usuario_UsuarioID] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuario] ([UsuarioID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PlanesDetalle] CHECK CONSTRAINT [FK_dbo.PlanesDetalle_dbo.Usuario_UsuarioID]
GO
ALTER TABLE [dbo].[PlanesTipo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PlanesTipo_dbo.Comercio_EmpresaID_ComercioID] FOREIGN KEY([EmpresaID], [ComercioID])
REFERENCES [dbo].[Comercio] ([EmpresaID], [ComercioID])
GO
ALTER TABLE [dbo].[PlanesTipo] CHECK CONSTRAINT [FK_dbo.PlanesTipo_dbo.Comercio_EmpresaID_ComercioID]
GO
ALTER TABLE [dbo].[PlanesTipo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PlanesTipo_dbo.Empresa_EmpresaID] FOREIGN KEY([EmpresaID])
REFERENCES [dbo].[Empresa] ([EmpresaID])
GO
ALTER TABLE [dbo].[PlanesTipo] CHECK CONSTRAINT [FK_dbo.PlanesTipo_dbo.Empresa_EmpresaID]
GO
ALTER TABLE [dbo].[PlanesTipo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PlanesTipo_dbo.TipoRetencionPlan_TipoRetencionPlanID] FOREIGN KEY([TipoRetencionPlanID])
REFERENCES [dbo].[TipoRetencionPlan] ([TipoRetencionPlanID])
GO
ALTER TABLE [dbo].[PlanesTipo] CHECK CONSTRAINT [FK_dbo.PlanesTipo_dbo.TipoRetencionPlan_TipoRetencionPlanID]
GO
ALTER TABLE [dbo].[PlanesVenci]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PlanesVenci_dbo.PlanesTipo_PlanesTipoID] FOREIGN KEY([PlanesTipoID])
REFERENCES [dbo].[PlanesTipo] ([PlanesTipoID])
GO
ALTER TABLE [dbo].[PlanesVenci] CHECK CONSTRAINT [FK_dbo.PlanesVenci_dbo.PlanesTipo_PlanesTipoID]
GO
ALTER TABLE [dbo].[PlanesVenci]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PlanesVenci_dbo.Usuario_UsuarioID] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuario] ([UsuarioID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PlanesVenci] CHECK CONSTRAINT [FK_dbo.PlanesVenci_dbo.Usuario_UsuarioID]
GO
ALTER TABLE [dbo].[Profesion]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Profesion_dbo.Profesion_ProfesionPadreID] FOREIGN KEY([ProfesionPadreID])
REFERENCES [dbo].[Profesion] ([ProfesionID])
GO
ALTER TABLE [dbo].[Profesion] CHECK CONSTRAINT [FK_dbo.Profesion_dbo.Profesion_ProfesionPadreID]
GO
ALTER TABLE [dbo].[Proveedor]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Proveedor_dbo.Estado_EstadoID] FOREIGN KEY([EstadoID])
REFERENCES [dbo].[Estado] ([EstadoID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Proveedor] CHECK CONSTRAINT [FK_dbo.Proveedor_dbo.Estado_EstadoID]
GO
ALTER TABLE [dbo].[Proveedor]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Proveedor_dbo.Localidad_PaisId_ProvinciaID_LocalidadID] FOREIGN KEY([PaisId], [ProvinciaID], [LocalidadID])
REFERENCES [dbo].[Localidad] ([PaisId], [ProvinciaID], [LocalidadID])
GO
ALTER TABLE [dbo].[Proveedor] CHECK CONSTRAINT [FK_dbo.Proveedor_dbo.Localidad_PaisId_ProvinciaID_LocalidadID]
GO
ALTER TABLE [dbo].[Proveedor]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Proveedor_dbo.Pais_PaisId] FOREIGN KEY([PaisId])
REFERENCES [dbo].[Pais] ([PaisID])
GO
ALTER TABLE [dbo].[Proveedor] CHECK CONSTRAINT [FK_dbo.Proveedor_dbo.Pais_PaisId]
GO
ALTER TABLE [dbo].[Proveedor]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Proveedor_dbo.Provincia_PaisId_ProvinciaID] FOREIGN KEY([PaisId], [ProvinciaID])
REFERENCES [dbo].[Provincia] ([PaisId], [ProvinciaID])
GO
ALTER TABLE [dbo].[Proveedor] CHECK CONSTRAINT [FK_dbo.Proveedor_dbo.Provincia_PaisId_ProvinciaID]
GO
ALTER TABLE [dbo].[ProveedorSucursal]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ProveedorSucursal_dbo.Estado_EstadoID] FOREIGN KEY([EstadoID])
REFERENCES [dbo].[Estado] ([EstadoID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProveedorSucursal] CHECK CONSTRAINT [FK_dbo.ProveedorSucursal_dbo.Estado_EstadoID]
GO
ALTER TABLE [dbo].[ProveedorSucursal]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ProveedorSucursal_dbo.Localidad_PaisID_ProvinciaID_LocalidadID] FOREIGN KEY([PaisID], [ProvinciaID], [LocalidadID])
REFERENCES [dbo].[Localidad] ([PaisId], [ProvinciaID], [LocalidadID])
GO
ALTER TABLE [dbo].[ProveedorSucursal] CHECK CONSTRAINT [FK_dbo.ProveedorSucursal_dbo.Localidad_PaisID_ProvinciaID_LocalidadID]
GO
ALTER TABLE [dbo].[ProveedorSucursal]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ProveedorSucursal_dbo.Pais_PaisID] FOREIGN KEY([PaisID])
REFERENCES [dbo].[Pais] ([PaisID])
GO
ALTER TABLE [dbo].[ProveedorSucursal] CHECK CONSTRAINT [FK_dbo.ProveedorSucursal_dbo.Pais_PaisID]
GO
ALTER TABLE [dbo].[ProveedorSucursal]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ProveedorSucursal_dbo.Proveedor_ProveedorID] FOREIGN KEY([ProveedorID])
REFERENCES [dbo].[Proveedor] ([ProveedorID])
GO
ALTER TABLE [dbo].[ProveedorSucursal] CHECK CONSTRAINT [FK_dbo.ProveedorSucursal_dbo.Proveedor_ProveedorID]
GO
ALTER TABLE [dbo].[ProveedorSucursal]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ProveedorSucursal_dbo.Provincia_PaisID_ProvinciaID] FOREIGN KEY([PaisID], [ProvinciaID])
REFERENCES [dbo].[Provincia] ([PaisId], [ProvinciaID])
GO
ALTER TABLE [dbo].[ProveedorSucursal] CHECK CONSTRAINT [FK_dbo.ProveedorSucursal_dbo.Provincia_PaisID_ProvinciaID]
GO
ALTER TABLE [dbo].[Provincia]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Provincia_dbo.Pais_PaisId] FOREIGN KEY([PaisId])
REFERENCES [dbo].[Pais] ([PaisID])
GO
ALTER TABLE [dbo].[Provincia] CHECK CONSTRAINT [FK_dbo.Provincia_dbo.Pais_PaisId]
GO
ALTER TABLE [dbo].[Recibo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Recibo_dbo.Comercio_ComercioAdheridoEmpresaID_ComercioAdheridoComercioID] FOREIGN KEY([ComercioAdheridoEmpresaID], [ComercioAdheridoComercioID])
REFERENCES [dbo].[Comercio] ([EmpresaID], [ComercioID])
GO
ALTER TABLE [dbo].[Recibo] CHECK CONSTRAINT [FK_dbo.Recibo_dbo.Comercio_ComercioAdheridoEmpresaID_ComercioAdheridoComercioID]
GO
ALTER TABLE [dbo].[Recibo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Recibo_dbo.Comercio_EmpresaID_ComercioID] FOREIGN KEY([EmpresaID], [ComercioID])
REFERENCES [dbo].[Comercio] ([EmpresaID], [ComercioID])
GO
ALTER TABLE [dbo].[Recibo] CHECK CONSTRAINT [FK_dbo.Recibo_dbo.Comercio_EmpresaID_ComercioID]
GO
ALTER TABLE [dbo].[Recibo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Recibo_dbo.Empresa_EmpresaID] FOREIGN KEY([EmpresaID])
REFERENCES [dbo].[Empresa] ([EmpresaID])
GO
ALTER TABLE [dbo].[Recibo] CHECK CONSTRAINT [FK_dbo.Recibo_dbo.Empresa_EmpresaID]
GO
ALTER TABLE [dbo].[Recibo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Recibo_dbo.Estado_EstadoID] FOREIGN KEY([EstadoID])
REFERENCES [dbo].[Estado] ([EstadoID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Recibo] CHECK CONSTRAINT [FK_dbo.Recibo_dbo.Estado_EstadoID]
GO
ALTER TABLE [dbo].[Recibo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Recibo_dbo.SolicitudFondo_EmpresaID_ComercioID_SolicitudFondoID] FOREIGN KEY([EmpresaID], [ComercioID], [SolicitudFondoID])
REFERENCES [dbo].[SolicitudFondo] ([EmpresaID], [ComercioID], [SolicitudFondoID])
GO
ALTER TABLE [dbo].[Recibo] CHECK CONSTRAINT [FK_dbo.Recibo_dbo.SolicitudFondo_EmpresaID_ComercioID_SolicitudFondoID]
GO
ALTER TABLE [dbo].[Recibo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Recibo_dbo.TipoMovimiento_TipoMovimientoID] FOREIGN KEY([TipoMovimientoID])
REFERENCES [dbo].[TipoMovimiento] ([TipoMovimientoID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Recibo] CHECK CONSTRAINT [FK_dbo.Recibo_dbo.TipoMovimiento_TipoMovimientoID]
GO
ALTER TABLE [dbo].[Recibo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Recibo_dbo.TransferenciasDepositos_EmpresaID_TransferenciasDepositosID] FOREIGN KEY([EmpresaID], [TransferenciasDepositosID])
REFERENCES [dbo].[TransferenciasDepositos] ([EmpresaID], [TransferenciasDepositosID])
GO
ALTER TABLE [dbo].[Recibo] CHECK CONSTRAINT [FK_dbo.Recibo_dbo.TransferenciasDepositos_EmpresaID_TransferenciasDepositosID]
GO
ALTER TABLE [dbo].[Recibo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Recibo_dbo.Usuario_UsuarioID] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuario] ([UsuarioID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Recibo] CHECK CONSTRAINT [FK_dbo.Recibo_dbo.Usuario_UsuarioID]
GO
ALTER TABLE [dbo].[Refinanciacion]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Refinanciacion_dbo.Cliente_Documento_TipoDocumentoID] FOREIGN KEY([Documento], [TipoDocumentoID])
REFERENCES [dbo].[Cliente] ([Documento], [TipoDocumentoID])
GO
ALTER TABLE [dbo].[Refinanciacion] CHECK CONSTRAINT [FK_dbo.Refinanciacion_dbo.Cliente_Documento_TipoDocumentoID]
GO
ALTER TABLE [dbo].[Refinanciacion]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Refinanciacion_dbo.Comercio_EmpresaID_ComercioID] FOREIGN KEY([EmpresaID], [ComercioID])
REFERENCES [dbo].[Comercio] ([EmpresaID], [ComercioID])
GO
ALTER TABLE [dbo].[Refinanciacion] CHECK CONSTRAINT [FK_dbo.Refinanciacion_dbo.Comercio_EmpresaID_ComercioID]
GO
ALTER TABLE [dbo].[Refinanciacion]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Refinanciacion_dbo.Credito_EmpresaID_ComercioID_CreditoID] FOREIGN KEY([EmpresaID], [ComercioID], [CreditoID])
REFERENCES [dbo].[Credito] ([EmpresaID], [ComercioID], [CreditoID])
GO
ALTER TABLE [dbo].[Refinanciacion] CHECK CONSTRAINT [FK_dbo.Refinanciacion_dbo.Credito_EmpresaID_ComercioID_CreditoID]
GO
ALTER TABLE [dbo].[Refinanciacion]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Refinanciacion_dbo.Empresa_EmpresaID] FOREIGN KEY([EmpresaID])
REFERENCES [dbo].[Empresa] ([EmpresaID])
GO
ALTER TABLE [dbo].[Refinanciacion] CHECK CONSTRAINT [FK_dbo.Refinanciacion_dbo.Empresa_EmpresaID]
GO
ALTER TABLE [dbo].[Refinanciacion]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Refinanciacion_dbo.Estado_EstadoID] FOREIGN KEY([EstadoID])
REFERENCES [dbo].[Estado] ([EstadoID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Refinanciacion] CHECK CONSTRAINT [FK_dbo.Refinanciacion_dbo.Estado_EstadoID]
GO
ALTER TABLE [dbo].[Refinanciacion]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Refinanciacion_dbo.Usuario_UsuarioID] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuario] ([UsuarioID])
GO
ALTER TABLE [dbo].[Refinanciacion] CHECK CONSTRAINT [FK_dbo.Refinanciacion_dbo.Usuario_UsuarioID]
GO
ALTER TABLE [dbo].[RefinanciacionCobranza]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RefinanciacionCobranza_dbo.Cliente_Documento_TipoDocumentoID] FOREIGN KEY([Documento], [TipoDocumentoID])
REFERENCES [dbo].[Cliente] ([Documento], [TipoDocumentoID])
GO
ALTER TABLE [dbo].[RefinanciacionCobranza] CHECK CONSTRAINT [FK_dbo.RefinanciacionCobranza_dbo.Cliente_Documento_TipoDocumentoID]
GO
ALTER TABLE [dbo].[RefinanciacionCobranza]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RefinanciacionCobranza_dbo.Comercio_EmpresaID_ComercioID] FOREIGN KEY([EmpresaID], [ComercioID])
REFERENCES [dbo].[Comercio] ([EmpresaID], [ComercioID])
GO
ALTER TABLE [dbo].[RefinanciacionCobranza] CHECK CONSTRAINT [FK_dbo.RefinanciacionCobranza_dbo.Comercio_EmpresaID_ComercioID]
GO
ALTER TABLE [dbo].[RefinanciacionCobranza]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RefinanciacionCobranza_dbo.Empresa_EmpresaID] FOREIGN KEY([EmpresaID])
REFERENCES [dbo].[Empresa] ([EmpresaID])
GO
ALTER TABLE [dbo].[RefinanciacionCobranza] CHECK CONSTRAINT [FK_dbo.RefinanciacionCobranza_dbo.Empresa_EmpresaID]
GO
ALTER TABLE [dbo].[RefinanciacionCobranza]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RefinanciacionCobranza_dbo.Refinanciacion_EmpresaID_ComercioID_CreditoID_RefinanciacionID] FOREIGN KEY([EmpresaID], [ComercioID], [CreditoID], [RefinanciacionID])
REFERENCES [dbo].[Refinanciacion] ([EmpresaID], [ComercioID], [CreditoID], [RefinanciacionID])
GO
ALTER TABLE [dbo].[RefinanciacionCobranza] CHECK CONSTRAINT [FK_dbo.RefinanciacionCobranza_dbo.Refinanciacion_EmpresaID_ComercioID_CreditoID_RefinanciacionID]
GO
ALTER TABLE [dbo].[RefinanciacionCobranza]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RefinanciacionCobranza_dbo.RefinanciacionCuota_EmpresaID_ComercioID_CreditoID_RefinanciacionID_RefinanciacionCuotaID] FOREIGN KEY([EmpresaID], [ComercioID], [CreditoID], [RefinanciacionID], [RefinanciacionCuotaID])
REFERENCES [dbo].[RefinanciacionCuota] ([EmpresaID], [ComercioID], [CreditoID], [RefinanciacionID], [RefinanciacionCuotaID])
GO
ALTER TABLE [dbo].[RefinanciacionCobranza] CHECK CONSTRAINT [FK_dbo.RefinanciacionCobranza_dbo.RefinanciacionCuota_EmpresaID_ComercioID_CreditoID_RefinanciacionID_RefinanciacionCuotaID]
GO
ALTER TABLE [dbo].[RefinanciacionCobranza]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RefinanciacionCobranza_dbo.TipoPago_TipoPagoID] FOREIGN KEY([TipoPagoID])
REFERENCES [dbo].[TipoPago] ([TipoPagoID])
GO
ALTER TABLE [dbo].[RefinanciacionCobranza] CHECK CONSTRAINT [FK_dbo.RefinanciacionCobranza_dbo.TipoPago_TipoPagoID]
GO
ALTER TABLE [dbo].[RefinanciacionCuota]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RefinanciacionCuota_dbo.Cliente_Documento_TipoDocumentoID] FOREIGN KEY([Documento], [TipoDocumentoID])
REFERENCES [dbo].[Cliente] ([Documento], [TipoDocumentoID])
GO
ALTER TABLE [dbo].[RefinanciacionCuota] CHECK CONSTRAINT [FK_dbo.RefinanciacionCuota_dbo.Cliente_Documento_TipoDocumentoID]
GO
ALTER TABLE [dbo].[RefinanciacionCuota]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RefinanciacionCuota_dbo.Comercio_EmpresaID_ComercioID] FOREIGN KEY([EmpresaID], [ComercioID])
REFERENCES [dbo].[Comercio] ([EmpresaID], [ComercioID])
GO
ALTER TABLE [dbo].[RefinanciacionCuota] CHECK CONSTRAINT [FK_dbo.RefinanciacionCuota_dbo.Comercio_EmpresaID_ComercioID]
GO
ALTER TABLE [dbo].[RefinanciacionCuota]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RefinanciacionCuota_dbo.Empresa_EmpresaID] FOREIGN KEY([EmpresaID])
REFERENCES [dbo].[Empresa] ([EmpresaID])
GO
ALTER TABLE [dbo].[RefinanciacionCuota] CHECK CONSTRAINT [FK_dbo.RefinanciacionCuota_dbo.Empresa_EmpresaID]
GO
ALTER TABLE [dbo].[RefinanciacionCuota]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RefinanciacionCuota_dbo.Refinanciacion_EmpresaID_ComercioID_CreditoID_RefinanciacionID] FOREIGN KEY([EmpresaID], [ComercioID], [CreditoID], [RefinanciacionID])
REFERENCES [dbo].[Refinanciacion] ([EmpresaID], [ComercioID], [CreditoID], [RefinanciacionID])
GO
ALTER TABLE [dbo].[RefinanciacionCuota] CHECK CONSTRAINT [FK_dbo.RefinanciacionCuota_dbo.Refinanciacion_EmpresaID_ComercioID_CreditoID_RefinanciacionID]
GO
ALTER TABLE [dbo].[SolicitudFondo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SolicitudFondo_dbo.AvisoDePago_EmpresaID_ComercioID_AvisoDePagoID] FOREIGN KEY([EmpresaID], [ComercioID], [AvisoDePagoID])
REFERENCES [dbo].[AvisoDePago] ([EmpresaID], [ComercioID], [AvisoDePagoID])
GO
ALTER TABLE [dbo].[SolicitudFondo] CHECK CONSTRAINT [FK_dbo.SolicitudFondo_dbo.AvisoDePago_EmpresaID_ComercioID_AvisoDePagoID]
GO
ALTER TABLE [dbo].[SolicitudFondo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SolicitudFondo_dbo.Cheque_EmpresaID_CuentaBancariaID_NumChequera_NumCheque] FOREIGN KEY([EmpresaID], [CuentaBancariaID], [NumChequera], [NumCheque])
REFERENCES [dbo].[Cheque] ([EmpresaID], [CuentaBancariaID], [ChequeraID], [ChequeID])
GO
ALTER TABLE [dbo].[SolicitudFondo] CHECK CONSTRAINT [FK_dbo.SolicitudFondo_dbo.Cheque_EmpresaID_CuentaBancariaID_NumChequera_NumCheque]
GO
ALTER TABLE [dbo].[SolicitudFondo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SolicitudFondo_dbo.Comercio_EmpresaID_ComercioID] FOREIGN KEY([EmpresaID], [ComercioID])
REFERENCES [dbo].[Comercio] ([EmpresaID], [ComercioID])
GO
ALTER TABLE [dbo].[SolicitudFondo] CHECK CONSTRAINT [FK_dbo.SolicitudFondo_dbo.Comercio_EmpresaID_ComercioID]
GO
ALTER TABLE [dbo].[SolicitudFondo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SolicitudFondo_dbo.ConceptoFondos_ConceptoFondosID] FOREIGN KEY([ConceptoFondosID])
REFERENCES [dbo].[ConceptoFondos] ([ConceptoFondosID])
GO
ALTER TABLE [dbo].[SolicitudFondo] CHECK CONSTRAINT [FK_dbo.SolicitudFondo_dbo.ConceptoFondos_ConceptoFondosID]
GO
ALTER TABLE [dbo].[SolicitudFondo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SolicitudFondo_dbo.Departamento_GeneradoPorDepartamentoID] FOREIGN KEY([GeneradoPorDepartamentoID])
REFERENCES [dbo].[Departamento] ([DepartamentoID])
GO
ALTER TABLE [dbo].[SolicitudFondo] CHECK CONSTRAINT [FK_dbo.SolicitudFondo_dbo.Departamento_GeneradoPorDepartamentoID]
GO
ALTER TABLE [dbo].[SolicitudFondo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SolicitudFondo_dbo.Empleado_EmpleadoRealizadorID] FOREIGN KEY([EmpleadoRealizadorID])
REFERENCES [dbo].[Empleado] ([EmpleadoID])
GO
ALTER TABLE [dbo].[SolicitudFondo] CHECK CONSTRAINT [FK_dbo.SolicitudFondo_dbo.Empleado_EmpleadoRealizadorID]
GO
ALTER TABLE [dbo].[SolicitudFondo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SolicitudFondo_dbo.Empleado_EmpleadoSolicitanteID] FOREIGN KEY([EmpleadoSolicitanteID])
REFERENCES [dbo].[Empleado] ([EmpleadoID])
GO
ALTER TABLE [dbo].[SolicitudFondo] CHECK CONSTRAINT [FK_dbo.SolicitudFondo_dbo.Empleado_EmpleadoSolicitanteID]
GO
ALTER TABLE [dbo].[SolicitudFondo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SolicitudFondo_dbo.Empresa_EmpresaID] FOREIGN KEY([EmpresaID])
REFERENCES [dbo].[Empresa] ([EmpresaID])
GO
ALTER TABLE [dbo].[SolicitudFondo] CHECK CONSTRAINT [FK_dbo.SolicitudFondo_dbo.Empresa_EmpresaID]
GO
ALTER TABLE [dbo].[SolicitudFondo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SolicitudFondo_dbo.Estado_EstadoID] FOREIGN KEY([EstadoID])
REFERENCES [dbo].[Estado] ([EstadoID])
GO
ALTER TABLE [dbo].[SolicitudFondo] CHECK CONSTRAINT [FK_dbo.SolicitudFondo_dbo.Estado_EstadoID]
GO
ALTER TABLE [dbo].[SolicitudFondo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SolicitudFondo_dbo.MedioDePago_MedioDePagoID] FOREIGN KEY([MedioDePagoID])
REFERENCES [dbo].[MedioDePago] ([MedioDePagoID])
GO
ALTER TABLE [dbo].[SolicitudFondo] CHECK CONSTRAINT [FK_dbo.SolicitudFondo_dbo.MedioDePago_MedioDePagoID]
GO
ALTER TABLE [dbo].[SolicitudFondo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SolicitudFondo_dbo.Moneda_MonedaID] FOREIGN KEY([MonedaID])
REFERENCES [dbo].[Moneda] ([MonedaID])
GO
ALTER TABLE [dbo].[SolicitudFondo] CHECK CONSTRAINT [FK_dbo.SolicitudFondo_dbo.Moneda_MonedaID]
GO
ALTER TABLE [dbo].[SolicitudFondo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SolicitudFondo_dbo.TipoSolicitud_TipoSolicitudID] FOREIGN KEY([TipoSolicitudID])
REFERENCES [dbo].[TipoSolicitud] ([TipoSolicitudID])
GO
ALTER TABLE [dbo].[SolicitudFondo] CHECK CONSTRAINT [FK_dbo.SolicitudFondo_dbo.TipoSolicitud_TipoSolicitudID]
GO
ALTER TABLE [dbo].[SolicitudFondo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SolicitudFondo_dbo.TransferenciasDepositos_EmpresaID_TransferenciasDepositosID] FOREIGN KEY([EmpresaID], [TransferenciasDepositosID])
REFERENCES [dbo].[TransferenciasDepositos] ([EmpresaID], [TransferenciasDepositosID])
GO
ALTER TABLE [dbo].[SolicitudFondo] CHECK CONSTRAINT [FK_dbo.SolicitudFondo_dbo.TransferenciasDepositos_EmpresaID_TransferenciasDepositosID]
GO
ALTER TABLE [dbo].[SolicitudFondoConceptoGastosProveedor]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SolicitudFondoConceptoGastosProveedor_dbo.Comercio_EmpresaID_ComercioID] FOREIGN KEY([EmpresaID], [ComercioID])
REFERENCES [dbo].[Comercio] ([EmpresaID], [ComercioID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SolicitudFondoConceptoGastosProveedor] CHECK CONSTRAINT [FK_dbo.SolicitudFondoConceptoGastosProveedor_dbo.Comercio_EmpresaID_ComercioID]
GO
ALTER TABLE [dbo].[SolicitudFondoConceptoGastosProveedor]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SolicitudFondoConceptoGastosProveedor_dbo.ConceptoGastosProveedor_ConceptoGastosProveedorID] FOREIGN KEY([ConceptoGastosProveedorID])
REFERENCES [dbo].[ConceptoGastosProveedor] ([ConceptoGastosProveedorID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SolicitudFondoConceptoGastosProveedor] CHECK CONSTRAINT [FK_dbo.SolicitudFondoConceptoGastosProveedor_dbo.ConceptoGastosProveedor_ConceptoGastosProveedorID]
GO
ALTER TABLE [dbo].[SolicitudFondoConceptoGastosProveedor]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SolicitudFondoConceptoGastosProveedor_dbo.Empresa_EmpresaID] FOREIGN KEY([EmpresaID])
REFERENCES [dbo].[Empresa] ([EmpresaID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SolicitudFondoConceptoGastosProveedor] CHECK CONSTRAINT [FK_dbo.SolicitudFondoConceptoGastosProveedor_dbo.Empresa_EmpresaID]
GO
ALTER TABLE [dbo].[SolicitudFondoConceptoGastosProveedor]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SolicitudFondoConceptoGastosProveedor_dbo.SolicitudFondo_EmpresaID_ComercioID_SolicitudFondoID] FOREIGN KEY([EmpresaID], [ComercioID], [SolicitudFondoID])
REFERENCES [dbo].[SolicitudFondo] ([EmpresaID], [ComercioID], [SolicitudFondoID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SolicitudFondoConceptoGastosProveedor] CHECK CONSTRAINT [FK_dbo.SolicitudFondoConceptoGastosProveedor_dbo.SolicitudFondo_EmpresaID_ComercioID_SolicitudFondoID]
GO
ALTER TABLE [dbo].[SucursalBanco]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SucursalBanco_dbo.Banco_BancoID] FOREIGN KEY([BancoID])
REFERENCES [dbo].[Banco] ([BancoID])
GO
ALTER TABLE [dbo].[SucursalBanco] CHECK CONSTRAINT [FK_dbo.SucursalBanco_dbo.Banco_BancoID]
GO
ALTER TABLE [dbo].[SucursalBanco]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SucursalBanco_dbo.Localidad_PaisId_ProvinciaID_LocalidadID] FOREIGN KEY([PaisId], [ProvinciaID], [LocalidadID])
REFERENCES [dbo].[Localidad] ([PaisId], [ProvinciaID], [LocalidadID])
GO
ALTER TABLE [dbo].[SucursalBanco] CHECK CONSTRAINT [FK_dbo.SucursalBanco_dbo.Localidad_PaisId_ProvinciaID_LocalidadID]
GO
ALTER TABLE [dbo].[SucursalBanco]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SucursalBanco_dbo.Pais_PaisId] FOREIGN KEY([PaisId])
REFERENCES [dbo].[Pais] ([PaisID])
GO
ALTER TABLE [dbo].[SucursalBanco] CHECK CONSTRAINT [FK_dbo.SucursalBanco_dbo.Pais_PaisId]
GO
ALTER TABLE [dbo].[SucursalBanco]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SucursalBanco_dbo.Provincia_PaisId_ProvinciaID] FOREIGN KEY([PaisId], [ProvinciaID])
REFERENCES [dbo].[Provincia] ([PaisId], [ProvinciaID])
GO
ALTER TABLE [dbo].[SucursalBanco] CHECK CONSTRAINT [FK_dbo.SucursalBanco_dbo.Provincia_PaisId_ProvinciaID]
GO
ALTER TABLE [dbo].[Telefono]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Telefono_dbo.ClaseDato_ClaseDatoID] FOREIGN KEY([ClaseDatoID])
REFERENCES [dbo].[ClaseDato] ([ClaseDatoID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Telefono] CHECK CONSTRAINT [FK_dbo.Telefono_dbo.ClaseDato_ClaseDatoID]
GO
ALTER TABLE [dbo].[Telefono]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Telefono_dbo.Cliente_Documento_TipoDocumentoID] FOREIGN KEY([Documento], [TipoDocumentoID])
REFERENCES [dbo].[Cliente] ([Documento], [TipoDocumentoID])
GO
ALTER TABLE [dbo].[Telefono] CHECK CONSTRAINT [FK_dbo.Telefono_dbo.Cliente_Documento_TipoDocumentoID]
GO
ALTER TABLE [dbo].[Telefono]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Telefono_dbo.Estado_EstadoID] FOREIGN KEY([EstadoID])
REFERENCES [dbo].[Estado] ([EstadoID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Telefono] CHECK CONSTRAINT [FK_dbo.Telefono_dbo.Estado_EstadoID]
GO
ALTER TABLE [dbo].[Telefono]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Telefono_dbo.Usuario_UsuarioID] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuario] ([UsuarioID])
GO
ALTER TABLE [dbo].[Telefono] CHECK CONSTRAINT [FK_dbo.Telefono_dbo.Usuario_UsuarioID]
GO
ALTER TABLE [dbo].[TipoMovimiento]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TipoMovimiento_dbo.ClaseMovimiento_ClaseMovimientoID] FOREIGN KEY([ClaseMovimientoID])
REFERENCES [dbo].[ClaseMovimiento] ([ClaseMovimientoID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TipoMovimiento] CHECK CONSTRAINT [FK_dbo.TipoMovimiento_dbo.ClaseMovimiento_ClaseMovimientoID]
GO
ALTER TABLE [dbo].[TransferenciasDepositos]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TransferenciasDepositos_dbo.Cheque_ChequeEmpID_ChequeCbID_ChequeNumChequera_ChequeNumCheque] FOREIGN KEY([ChequeEmpID], [ChequeCbID], [ChequeNumChequera], [ChequeNumCheque])
REFERENCES [dbo].[Cheque] ([EmpresaID], [CuentaBancariaID], [ChequeraID], [ChequeID])
GO
ALTER TABLE [dbo].[TransferenciasDepositos] CHECK CONSTRAINT [FK_dbo.TransferenciasDepositos_dbo.Cheque_ChequeEmpID_ChequeCbID_ChequeNumChequera_ChequeNumCheque]
GO
ALTER TABLE [dbo].[TransferenciasDepositos]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TransferenciasDepositos_dbo.Comercio_EmpresaID_ComercioID] FOREIGN KEY([EmpresaID], [ComercioID])
REFERENCES [dbo].[Comercio] ([EmpresaID], [ComercioID])
GO
ALTER TABLE [dbo].[TransferenciasDepositos] CHECK CONSTRAINT [FK_dbo.TransferenciasDepositos_dbo.Comercio_EmpresaID_ComercioID]
GO
ALTER TABLE [dbo].[TransferenciasDepositos]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TransferenciasDepositos_dbo.CuentaBancaria_CuentaDestinoEmpresaID_CuentaDestinoCbID] FOREIGN KEY([CuentaDestinoEmpresaID], [CuentaDestinoCbID])
REFERENCES [dbo].[CuentaBancaria] ([EmpresaID], [CuentaBancariaID])
GO
ALTER TABLE [dbo].[TransferenciasDepositos] CHECK CONSTRAINT [FK_dbo.TransferenciasDepositos_dbo.CuentaBancaria_CuentaDestinoEmpresaID_CuentaDestinoCbID]
GO
ALTER TABLE [dbo].[TransferenciasDepositos]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TransferenciasDepositos_dbo.CuentaBancaria_CuentaOrigenEmpresaID_CuentaOrigenCbID] FOREIGN KEY([CuentaOrigenEmpresaID], [CuentaOrigenCbID])
REFERENCES [dbo].[CuentaBancaria] ([EmpresaID], [CuentaBancariaID])
GO
ALTER TABLE [dbo].[TransferenciasDepositos] CHECK CONSTRAINT [FK_dbo.TransferenciasDepositos_dbo.CuentaBancaria_CuentaOrigenEmpresaID_CuentaOrigenCbID]
GO
ALTER TABLE [dbo].[TransferenciasDepositos]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TransferenciasDepositos_dbo.Empleado_EmpleadoRegistrador_EmpleadoID] FOREIGN KEY([EmpleadoRegistrador_EmpleadoID])
REFERENCES [dbo].[Empleado] ([EmpleadoID])
GO
ALTER TABLE [dbo].[TransferenciasDepositos] CHECK CONSTRAINT [FK_dbo.TransferenciasDepositos_dbo.Empleado_EmpleadoRegistrador_EmpleadoID]
GO
ALTER TABLE [dbo].[TransferenciasDepositos]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TransferenciasDepositos_dbo.Empresa_ComercioEmpresa_EmpresaID] FOREIGN KEY([ComercioEmpresa_EmpresaID])
REFERENCES [dbo].[Empresa] ([EmpresaID])
GO
ALTER TABLE [dbo].[TransferenciasDepositos] CHECK CONSTRAINT [FK_dbo.TransferenciasDepositos_dbo.Empresa_ComercioEmpresa_EmpresaID]
GO
ALTER TABLE [dbo].[TransferenciasDepositos]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TransferenciasDepositos_dbo.Empresa_EmpresaID] FOREIGN KEY([EmpresaID])
REFERENCES [dbo].[Empresa] ([EmpresaID])
GO
ALTER TABLE [dbo].[TransferenciasDepositos] CHECK CONSTRAINT [FK_dbo.TransferenciasDepositos_dbo.Empresa_EmpresaID]
GO
ALTER TABLE [dbo].[TransferenciasDepositos]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TransferenciasDepositos_dbo.Estado_EstadoID] FOREIGN KEY([EstadoID])
REFERENCES [dbo].[Estado] ([EstadoID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TransferenciasDepositos] CHECK CONSTRAINT [FK_dbo.TransferenciasDepositos_dbo.Estado_EstadoID]
GO
ALTER TABLE [dbo].[TransferenciasDepositos]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TransferenciasDepositos_dbo.MedioDePago_MedioDePagoID] FOREIGN KEY([MedioDePagoID])
REFERENCES [dbo].[MedioDePago] ([MedioDePagoID])
GO
ALTER TABLE [dbo].[TransferenciasDepositos] CHECK CONSTRAINT [FK_dbo.TransferenciasDepositos_dbo.MedioDePago_MedioDePagoID]
GO
ALTER TABLE [dbo].[TransferenciasDepositos]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TransferenciasDepositos_dbo.Moneda_MonedaID] FOREIGN KEY([MonedaID])
REFERENCES [dbo].[Moneda] ([MonedaID])
GO
ALTER TABLE [dbo].[TransferenciasDepositos] CHECK CONSTRAINT [FK_dbo.TransferenciasDepositos_dbo.Moneda_MonedaID]
GO
ALTER TABLE [dbo].[TransferenciasDepositos]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TransferenciasDepositos_dbo.Persona_PersonaId] FOREIGN KEY([PersonaId])
REFERENCES [dbo].[Persona] ([PersonaID])
GO
ALTER TABLE [dbo].[TransferenciasDepositos] CHECK CONSTRAINT [FK_dbo.TransferenciasDepositos_dbo.Persona_PersonaId]
GO
ALTER TABLE [dbo].[TransferenciasDepositos]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TransferenciasDepositos_dbo.ProveedorSucursal_ProveedorSucursalID] FOREIGN KEY([ProveedorSucursalID])
REFERENCES [dbo].[ProveedorSucursal] ([ProveedorSucursalID])
GO
ALTER TABLE [dbo].[TransferenciasDepositos] CHECK CONSTRAINT [FK_dbo.TransferenciasDepositos_dbo.ProveedorSucursal_ProveedorSucursalID]
GO
ALTER TABLE [dbo].[TransferenciasDepositos]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TransferenciasDepositos_dbo.TipoTransferenciaDeposito_TipoTransferenciaDepositoID] FOREIGN KEY([TipoTransferenciaDepositoID])
REFERENCES [dbo].[TipoTransferenciaDeposito] ([TipoTransferenciaDepositoID])
GO
ALTER TABLE [dbo].[TransferenciasDepositos] CHECK CONSTRAINT [FK_dbo.TransferenciasDepositos_dbo.TipoTransferenciaDeposito_TipoTransferenciaDepositoID]
GO
ALTER TABLE [dbo].[TransferenciasDepositos]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TransferenciasDepositos_dbo.Usuario_UsuarioID] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuario] ([UsuarioID])
GO
ALTER TABLE [dbo].[TransferenciasDepositos] CHECK CONSTRAINT [FK_dbo.TransferenciasDepositos_dbo.Usuario_UsuarioID]
GO
ALTER TABLE [dbo].[Transmision]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Transmision_dbo.Comercio_EmpresaID_ComercioID] FOREIGN KEY([EmpresaID], [ComercioID])
REFERENCES [dbo].[Comercio] ([EmpresaID], [ComercioID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Transmision] CHECK CONSTRAINT [FK_dbo.Transmision_dbo.Comercio_EmpresaID_ComercioID]
GO
ALTER TABLE [dbo].[Transmision]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Transmision_dbo.Empresa_EmpresaID] FOREIGN KEY([EmpresaID])
REFERENCES [dbo].[Empresa] ([EmpresaID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Transmision] CHECK CONSTRAINT [FK_dbo.Transmision_dbo.Empresa_EmpresaID]
GO
ALTER TABLE [dbo].[Transmision]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Transmision_dbo.EstadoTransmision_EstadoTransmisionID] FOREIGN KEY([EstadoTransmisionID])
REFERENCES [dbo].[EstadoTransmision] ([EstadoTransmisionID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Transmision] CHECK CONSTRAINT [FK_dbo.Transmision_dbo.EstadoTransmision_EstadoTransmisionID]
GO
ALTER TABLE [dbo].[Transmision]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Transmision_dbo.Operacion_OperacionID] FOREIGN KEY([OperacionID])
REFERENCES [dbo].[Operacion] ([OperacionID])
GO
ALTER TABLE [dbo].[Transmision] CHECK CONSTRAINT [FK_dbo.Transmision_dbo.Operacion_OperacionID]
GO
ALTER TABLE [dbo].[UsuariosPerfiles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UsuariosPerfiles_dbo.Perfil_PerfilID] FOREIGN KEY([PerfilID])
REFERENCES [dbo].[Perfil] ([PerfilID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UsuariosPerfiles] CHECK CONSTRAINT [FK_dbo.UsuariosPerfiles_dbo.Perfil_PerfilID]
GO
ALTER TABLE [dbo].[UsuariosPerfiles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UsuariosPerfiles_dbo.Usuario_UsuarioID] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuario] ([UsuarioID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UsuariosPerfiles] CHECK CONSTRAINT [FK_dbo.UsuariosPerfiles_dbo.Usuario_UsuarioID]
GO
/****** Object:  StoredProcedure [dbo].[ACobrar]    Script Date: 29/3/2026 11:28:52 ******/
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
/****** Object:  StoredProcedure [dbo].[ActualizarCreditoABonificado]    Script Date: 29/3/2026 11:28:52 ******/
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
/****** Object:  StoredProcedure [dbo].[CobradoDelMes]    Script Date: 29/3/2026 11:28:52 ******/
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
/****** Object:  StoredProcedure [dbo].[CobradoEnElMes]    Script Date: 29/3/2026 11:28:52 ******/
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
/****** Object:  StoredProcedure [dbo].[MI_RegistrosPorFila]    Script Date: 29/3/2026 11:28:52 ******/
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
/****** Object:  StoredProcedure [dbo].[ObtenerCreditosYTasa]    Script Date: 29/3/2026 11:28:52 ******/
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
/****** Object:  StoredProcedure [dbo].[Planes_ActualizarFechaVencimiento]    Script Date: 29/3/2026 11:28:52 ******/
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
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[55] 4[7] 2[21] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "CuentaCorriente"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 259
               Right = 256
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'cc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'cc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[55] 4[7] 2[21] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Cobranza"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 267
               Right = 266
            End
            DisplayFlags = 280
            TopColumn = 17
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Cobranzas'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Cobranzas'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[54] 4[8] 2[21] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Credito"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 286
               Right = 262
            End
            DisplayFlags = 280
            TopColumn = 41
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Creditos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Creditos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "CreditoAnulado_1"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 262
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'CreditosAnulados'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'CreditosAnulados'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Cuota"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 296
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Cuotas_mayor_pago'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Cuotas_mayor_pago'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[21] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "NotasCD"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 247
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'NotaCD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'NotaCD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Refinanciacion"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 247
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Refi'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Refi'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "RefinanciacionCuota"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 250
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'RefinanciacionCuotas'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'RefinanciacionCuotas'
GO
USE [master]
GO
ALTER DATABASE [ComercioPru4002] SET  READ_WRITE 
GO
