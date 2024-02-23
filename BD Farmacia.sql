USE [master]
GO
/****** Object:  Database [FARMACIA]    Script Date: 22/02/2024 14:31:23 ******/
CREATE DATABASE [FARMACIA]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FARMACIA', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.JEMMINSON\MSSQL\DATA\FARMACIA.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FARMACIA_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.JEMMINSON\MSSQL\DATA\FARMACIA_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [FARMACIA] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FARMACIA].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FARMACIA] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FARMACIA] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FARMACIA] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FARMACIA] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FARMACIA] SET ARITHABORT OFF 
GO
ALTER DATABASE [FARMACIA] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FARMACIA] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FARMACIA] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FARMACIA] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FARMACIA] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FARMACIA] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FARMACIA] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FARMACIA] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FARMACIA] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FARMACIA] SET  ENABLE_BROKER 
GO
ALTER DATABASE [FARMACIA] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FARMACIA] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FARMACIA] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FARMACIA] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FARMACIA] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FARMACIA] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FARMACIA] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FARMACIA] SET RECOVERY FULL 
GO
ALTER DATABASE [FARMACIA] SET  MULTI_USER 
GO
ALTER DATABASE [FARMACIA] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FARMACIA] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FARMACIA] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FARMACIA] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FARMACIA] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FARMACIA] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'FARMACIA', N'ON'
GO
ALTER DATABASE [FARMACIA] SET QUERY_STORE = OFF
GO
USE [FARMACIA]
GO
/****** Object:  Table [dbo].[cliente]    Script Date: 22/02/2024 14:31:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cliente](
	[idCliente] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [varchar](35) NULL,
	[Apellidos] [varchar](35) NULL,
	[Sexo] [varchar](2) NULL,
	[Dni] [varchar](10) NULL,
	[Telefono] [varchar](15) NULL,
	[Ruc] [varchar](20) NULL,
	[Email] [varchar](35) NULL,
	[Direccion] [varchar](50) NULL,
 CONSTRAINT [PK_cliente] PRIMARY KEY CLUSTERED 
(
	[idCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[compra]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[compra](
	[idCompra] [int] IDENTITY(1,1) NOT NULL,
	[Numero] [varchar](15) NULL,
	[Fecha] [datetime] NULL,
	[TipoPago] [varchar](30) NULL,
	[SubTotal] [decimal](8, 2) NULL,
	[Total] [decimal](8, 2) NULL,
	[Igv] [decimal](8, 2) NULL,
	[Estado] [varchar](10) NULL,
	[idProveedor] [int] NULL,
	[idEmpleado] [int] NULL,
	[idTipoComprobante] [int] NULL,
 CONSTRAINT [PK_compra] PRIMARY KEY CLUSTERED 
(
	[idCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[detallecompra]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detallecompra](
	[idDetalleCompra] [int] IDENTITY(1,1) NOT NULL,
	[idCompra] [int] NULL,
	[idProducto] [int] NULL,
	[Cantidad] [int] NULL,
	[Costo] [decimal](8, 2) NULL,
	[Importe] [decimal](8, 2) NULL,
 CONSTRAINT [PK_detallecompra] PRIMARY KEY CLUSTERED 
(
	[idDetalleCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[detalleventa]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalleventa](
	[idDetalleVenta] [int] IDENTITY(1,1) NOT NULL,
	[IdVenta] [int] NULL,
	[idProducto] [int] NULL,
	[Cantidad] [int] NULL,
	[Costo] [decimal](8, 2) NULL,
	[Precio] [decimal](8, 2) NULL,
	[Importe] [decimal](8, 2) NULL,
 CONSTRAINT [PK_detalleventa] PRIMARY KEY CLUSTERED 
(
	[idDetalleVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[empleado]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[empleado](
	[idEmpleado] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [varchar](35) NULL,
	[Apellidos] [varchar](35) NULL,
	[Especialidad] [varchar](30) NULL,
	[Sexo] [varchar](2) NULL,
	[Dni] [int] NULL,
	[Email] [varchar](30) NULL,
	[Telefono] [int] NULL,
	[Direccion] [varchar](35) NULL,
	[HoraIngreso] [varchar](15) NULL,
	[HoraSalida] [varchar](15) NULL,
	[Sueldo] [decimal](8, 2) NULL,
	[Estado] [varchar](10) NULL,
	[idUsuario] [int] NULL,
 CONSTRAINT [PK_empleado] PRIMARY KEY CLUSTERED 
(
	[idEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[laboratorio]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[laboratorio](
	[idLaboratorio] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](35) NULL,
	[Direccion] [varchar](35) NULL,
	[Telefono] [int] NULL,
	[Estado] [varchar](10) NULL,
 CONSTRAINT [PK_laboratorio] PRIMARY KEY CLUSTERED 
(
	[idLaboratorio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[presentacion]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[presentacion](
	[idPresentacion] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](35) NULL,
	[Estado] [varchar](30) NULL,
 CONSTRAINT [PK_presentacion] PRIMARY KEY CLUSTERED 
(
	[idPresentacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[producto]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[producto](
	[idProducto] [int] IDENTITY(1,1) NOT NULL,
	[Codigo_Barras] [varchar](13) NULL,
	[Descripcion] [varchar](35) NULL,
	[Concentracion] [varchar](30) NULL,
	[Stock] [decimal](8, 2) NULL,
	[Costo] [decimal](8, 2) NULL,
	[Precio_Venta] [decimal](8, 2) NULL,
	[RegistroSanitario] [varchar](20) NULL,
	[FechaVencimiento] [datetime] NULL,
	[Estado] [varchar](10) NULL,
	[idPresentacion] [int] NULL,
	[idLaboratorio] [int] NULL,
 CONSTRAINT [PK_producto] PRIMARY KEY CLUSTERED 
(
	[idProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[proveedor]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proveedor](
	[IdProveedor] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](35) NULL,
	[Dni] [varchar](11) NULL,
	[Ruc] [varchar](20) NULL,
	[Direccion] [varchar](35) NULL,
	[Email] [varchar](35) NULL,
	[Telefono] [varchar](20) NULL,
	[Banco] [varchar](35) NULL,
	[Cuenta] [varchar](35) NULL,
	[Estado] [varchar](10) NULL,
 CONSTRAINT [PK_proveedor] PRIMARY KEY CLUSTERED 
(
	[IdProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipocomprobante]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipocomprobante](
	[idTipoComprobante] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](35) NULL,
	[Estado] [varchar](10) NULL,
 CONSTRAINT [PK_tipocomprobante] PRIMARY KEY CLUSTERED 
(
	[idTipoComprobante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [varchar](35) NULL,
	[Apellidos] [varchar](35) NULL,
	[Dni] [int] NULL,
	[Email] [varchar](35) NULL,
	[Usuario] [varchar](30) NULL,
	[Contraseña] [varchar](30) NULL,
	[TipoUsuario] [varchar](20) NULL,
	[Estado] [varchar](10) NULL,
 CONSTRAINT [PK_usuario] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ventas]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ventas](
	[IdVenta] [int] IDENTITY(1,1) NOT NULL,
	[Serie] [varchar](10) NULL,
	[Numero] [varchar](20) NULL,
	[Fecha] [datetime] NULL,
	[VentaTotal] [decimal](8, 2) NULL,
	[Descuento] [decimal](8, 2) NULL,
	[SubTotal] [decimal](8, 2) NULL,
	[Igv] [decimal](8, 2) NULL,
	[Total] [decimal](8, 2) NULL,
	[Estado] [varchar](10) NULL,
	[idCliente] [int] NULL,
	[idEmpleado] [int] NULL,
	[idTipoComprobante] [int] NULL,
 CONSTRAINT [PK_ventas] PRIMARY KEY CLUSTERED 
(
	[IdVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[cliente] ON 

INSERT [dbo].[cliente] ([idCliente], [Nombres], [Apellidos], [Sexo], [Dni], [Telefono], [Ruc], [Email], [Direccion]) VALUES (1, N'Maria Jesus', N'BardalesTrigozo', N'F', N'33425619', N'987412350', N'10334256192', N'mariajesus@gmail.com', N'Jr. Las Americas 1520')
INSERT [dbo].[cliente] ([idCliente], [Nombres], [Apellidos], [Sexo], [Dni], [Telefono], [Ruc], [Email], [Direccion]) VALUES (2, N'Martin', N'Campos Correa', N'M', N'33156740', N'965410372', N'10331567402', N'martin_03@gmail.com', N'Av. Panama 120')
INSERT [dbo].[cliente] ([idCliente], [Nombres], [Apellidos], [Sexo], [Dni], [Telefono], [Ruc], [Email], [Direccion]) VALUES (3, N'Azucena Jesus', N'Salas Mazuelos', N'F', N'71902256', N'987412530', N'10719022564', N'azucenajesus@gmail.com', N'Jr. Coloquial 40')
INSERT [dbo].[cliente] ([idCliente], [Nombres], [Apellidos], [Sexo], [Dni], [Telefono], [Ruc], [Email], [Direccion]) VALUES (4, N'Pedro', N'Suarez Rosales', N'M', N'71328596', N'987415263', N'10713284594', N'pedor@gmail.com', N'Jr. Chachapoyas 130')
INSERT [dbo].[cliente] ([idCliente], [Nombres], [Apellidos], [Sexo], [Dni], [Telefono], [Ruc], [Email], [Direccion]) VALUES (5, N'Juana', N'Trigoso Bardales', N'F', N'71832691', N'942610387', N'10719022568', N'juana07@gmail.com', N'Jr. Camporredondo 30')
INSERT [dbo].[cliente] ([idCliente], [Nombres], [Apellidos], [Sexo], [Dni], [Telefono], [Ruc], [Email], [Direccion]) VALUES (6, N'Erick', N'Sanchez Gonzales', N'M', N'33425619', N'984120367', N'10334269856', N'Erick_@gmail.com', N'Jr. La verdad 1520')
INSERT [dbo].[cliente] ([idCliente], [Nombres], [Apellidos], [Sexo], [Dni], [Telefono], [Ruc], [Email], [Direccion]) VALUES (7, N'Daniel', N'Nuñez', N'M', N'71902257', N'984123650', N'10719022567', N'Daniel@gmail.com', N'Av. San Martin 120')
INSERT [dbo].[cliente] ([idCliente], [Nombres], [Apellidos], [Sexo], [Dni], [Telefono], [Ruc], [Email], [Direccion]) VALUES (8, N'Carlos', N'', N'M', N'71902258', N'', N'', N'carlos@hotmail.com', N'')
SET IDENTITY_INSERT [dbo].[cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[compra] ON 

INSERT [dbo].[compra] ([idCompra], [Numero], [Fecha], [TipoPago], [SubTotal], [Total], [Igv], [Estado], [idProveedor], [idEmpleado], [idTipoComprobante]) VALUES (2, N'1', CAST(N'2024-02-14T00:00:00.000' AS DateTime), N'', CAST(3.81 AS Decimal(8, 2)), CAST(4.50 AS Decimal(8, 2)), CAST(0.69 AS Decimal(8, 2)), N'Normal', 1, 1, 3)
INSERT [dbo].[compra] ([idCompra], [Numero], [Fecha], [TipoPago], [SubTotal], [Total], [Igv], [Estado], [idProveedor], [idEmpleado], [idTipoComprobante]) VALUES (3, N'3', CAST(N'2024-02-14T00:00:00.000' AS DateTime), N'', CAST(0.76 AS Decimal(8, 2)), CAST(0.90 AS Decimal(8, 2)), CAST(0.14 AS Decimal(8, 2)), N'Normal', 2, 1, 3)
INSERT [dbo].[compra] ([idCompra], [Numero], [Fecha], [TipoPago], [SubTotal], [Total], [Igv], [Estado], [idProveedor], [idEmpleado], [idTipoComprobante]) VALUES (4, N'4', CAST(N'2024-02-14T00:00:00.000' AS DateTime), N'', CAST(3.81 AS Decimal(8, 2)), CAST(4.50 AS Decimal(8, 2)), CAST(0.69 AS Decimal(8, 2)), N'Normal', 1, 1, 3)
INSERT [dbo].[compra] ([idCompra], [Numero], [Fecha], [TipoPago], [SubTotal], [Total], [Igv], [Estado], [idProveedor], [idEmpleado], [idTipoComprobante]) VALUES (5, N'5', CAST(N'2024-02-14T00:00:00.000' AS DateTime), N'', CAST(0.51 AS Decimal(8, 2)), CAST(0.60 AS Decimal(8, 2)), CAST(0.09 AS Decimal(8, 2)), N'Normal', 1, 1, 1)
INSERT [dbo].[compra] ([idCompra], [Numero], [Fecha], [TipoPago], [SubTotal], [Total], [Igv], [Estado], [idProveedor], [idEmpleado], [idTipoComprobante]) VALUES (7, N'6', CAST(N'2024-02-14T00:00:00.000' AS DateTime), N'', CAST(3.81 AS Decimal(8, 2)), CAST(4.50 AS Decimal(8, 2)), CAST(0.69 AS Decimal(8, 2)), N'Normal', 1, 1, 1)
INSERT [dbo].[compra] ([idCompra], [Numero], [Fecha], [TipoPago], [SubTotal], [Total], [Igv], [Estado], [idProveedor], [idEmpleado], [idTipoComprobante]) VALUES (8, N'8', CAST(N'2024-02-14T00:00:00.000' AS DateTime), N'', CAST(22.03 AS Decimal(8, 2)), CAST(26.00 AS Decimal(8, 2)), CAST(3.97 AS Decimal(8, 2)), N'Normal', 1, 1, 1)
INSERT [dbo].[compra] ([idCompra], [Numero], [Fecha], [TipoPago], [SubTotal], [Total], [Igv], [Estado], [idProveedor], [idEmpleado], [idTipoComprobante]) VALUES (9, N'9', CAST(N'2024-02-14T00:00:00.000' AS DateTime), N'', CAST(33.05 AS Decimal(8, 2)), CAST(39.00 AS Decimal(8, 2)), CAST(5.95 AS Decimal(8, 2)), N'Normal', 2, 1, 3)
INSERT [dbo].[compra] ([idCompra], [Numero], [Fecha], [TipoPago], [SubTotal], [Total], [Igv], [Estado], [idProveedor], [idEmpleado], [idTipoComprobante]) VALUES (11, N'10', CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'', CAST(27.46 AS Decimal(8, 2)), CAST(32.40 AS Decimal(8, 2)), CAST(4.94 AS Decimal(8, 2)), N'Normal', 1, 1, 3)
INSERT [dbo].[compra] ([idCompra], [Numero], [Fecha], [TipoPago], [SubTotal], [Total], [Igv], [Estado], [idProveedor], [idEmpleado], [idTipoComprobante]) VALUES (12, N'12', CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'', CAST(13.39 AS Decimal(8, 2)), CAST(15.80 AS Decimal(8, 2)), CAST(2.41 AS Decimal(8, 2)), N'Normal', 1, 1, 3)
INSERT [dbo].[compra] ([idCompra], [Numero], [Fecha], [TipoPago], [SubTotal], [Total], [Igv], [Estado], [idProveedor], [idEmpleado], [idTipoComprobante]) VALUES (13, N'13', CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'', CAST(22.03 AS Decimal(8, 2)), CAST(26.00 AS Decimal(8, 2)), CAST(3.97 AS Decimal(8, 2)), N'Normal', 2, 1, 1)
INSERT [dbo].[compra] ([idCompra], [Numero], [Fecha], [TipoPago], [SubTotal], [Total], [Igv], [Estado], [idProveedor], [idEmpleado], [idTipoComprobante]) VALUES (14, N'14', CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'', CAST(14.32 AS Decimal(8, 2)), CAST(16.90 AS Decimal(8, 2)), CAST(2.58 AS Decimal(8, 2)), N'Normal', 2, 1, 3)
INSERT [dbo].[compra] ([idCompra], [Numero], [Fecha], [TipoPago], [SubTotal], [Total], [Igv], [Estado], [idProveedor], [idEmpleado], [idTipoComprobante]) VALUES (1011, N'15', CAST(N'2024-02-16T00:00:00.000' AS DateTime), N'', CAST(22.03 AS Decimal(8, 2)), CAST(26.00 AS Decimal(8, 2)), CAST(3.97 AS Decimal(8, 2)), N'Normal', 2, 1, 3)
INSERT [dbo].[compra] ([idCompra], [Numero], [Fecha], [TipoPago], [SubTotal], [Total], [Igv], [Estado], [idProveedor], [idEmpleado], [idTipoComprobante]) VALUES (1012, N'1012', CAST(N'2024-02-16T00:00:00.000' AS DateTime), N'', CAST(33.05 AS Decimal(8, 2)), CAST(39.00 AS Decimal(8, 2)), CAST(5.95 AS Decimal(8, 2)), N'Normal', 2, 1, 1)
INSERT [dbo].[compra] ([idCompra], [Numero], [Fecha], [TipoPago], [SubTotal], [Total], [Igv], [Estado], [idProveedor], [idEmpleado], [idTipoComprobante]) VALUES (1013, N'1013', CAST(N'2024-02-17T00:00:00.000' AS DateTime), N'', CAST(17.71 AS Decimal(8, 2)), CAST(20.90 AS Decimal(8, 2)), CAST(3.19 AS Decimal(8, 2)), N'Normal', 1, 1, 3)
INSERT [dbo].[compra] ([idCompra], [Numero], [Fecha], [TipoPago], [SubTotal], [Total], [Igv], [Estado], [idProveedor], [idEmpleado], [idTipoComprobante]) VALUES (1014, N'1014', CAST(N'2024-02-19T00:00:00.000' AS DateTime), N'', CAST(33.05 AS Decimal(8, 2)), CAST(39.00 AS Decimal(8, 2)), CAST(5.95 AS Decimal(8, 2)), N'Normal', 2, 1, 3)
INSERT [dbo].[compra] ([idCompra], [Numero], [Fecha], [TipoPago], [SubTotal], [Total], [Igv], [Estado], [idProveedor], [idEmpleado], [idTipoComprobante]) VALUES (1016, N'1015', CAST(N'2024-02-19T00:00:00.000' AS DateTime), N'', CAST(44.07 AS Decimal(8, 2)), CAST(52.00 AS Decimal(8, 2)), CAST(7.93 AS Decimal(8, 2)), N'Normal', 2, 1, 3)
INSERT [dbo].[compra] ([idCompra], [Numero], [Fecha], [TipoPago], [SubTotal], [Total], [Igv], [Estado], [idProveedor], [idEmpleado], [idTipoComprobante]) VALUES (1017, N'1017', CAST(N'2024-02-19T00:00:00.000' AS DateTime), N'', CAST(55.08 AS Decimal(8, 2)), CAST(65.00 AS Decimal(8, 2)), CAST(9.91 AS Decimal(8, 2)), N'Normal', 2, 1, 1)
INSERT [dbo].[compra] ([idCompra], [Numero], [Fecha], [TipoPago], [SubTotal], [Total], [Igv], [Estado], [idProveedor], [idEmpleado], [idTipoComprobante]) VALUES (1018, N'1018', CAST(N'2024-02-19T00:00:00.000' AS DateTime), N'', CAST(11.44 AS Decimal(8, 2)), CAST(13.50 AS Decimal(8, 2)), CAST(2.06 AS Decimal(8, 2)), N'Normal', 1, 1, 3)
INSERT [dbo].[compra] ([idCompra], [Numero], [Fecha], [TipoPago], [SubTotal], [Total], [Igv], [Estado], [idProveedor], [idEmpleado], [idTipoComprobante]) VALUES (1019, N'1019', CAST(N'2024-02-19T00:00:00.000' AS DateTime), N'', CAST(3.81 AS Decimal(8, 2)), CAST(4.50 AS Decimal(8, 2)), CAST(0.69 AS Decimal(8, 2)), N'Normal', 2, 1, 3)
INSERT [dbo].[compra] ([idCompra], [Numero], [Fecha], [TipoPago], [SubTotal], [Total], [Igv], [Estado], [idProveedor], [idEmpleado], [idTipoComprobante]) VALUES (1020, N'1020', CAST(N'2024-02-19T00:00:00.000' AS DateTime), N'', CAST(8.14 AS Decimal(8, 2)), CAST(9.60 AS Decimal(8, 2)), CAST(1.47 AS Decimal(8, 2)), N'Normal', 1, 1, 3)
INSERT [dbo].[compra] ([idCompra], [Numero], [Fecha], [TipoPago], [SubTotal], [Total], [Igv], [Estado], [idProveedor], [idEmpleado], [idTipoComprobante]) VALUES (1021, N'1021', CAST(N'2024-02-19T00:00:00.000' AS DateTime), N'', CAST(28.81 AS Decimal(8, 2)), CAST(34.00 AS Decimal(8, 2)), CAST(5.19 AS Decimal(8, 2)), N'Normal', 2, 1, 1)
INSERT [dbo].[compra] ([idCompra], [Numero], [Fecha], [TipoPago], [SubTotal], [Total], [Igv], [Estado], [idProveedor], [idEmpleado], [idTipoComprobante]) VALUES (1022, N'1022', CAST(N'2024-02-21T15:33:21.000' AS DateTime), N'', CAST(16.00 AS Decimal(8, 2)), CAST(18.40 AS Decimal(8, 2)), CAST(2.40 AS Decimal(8, 2)), N'Normal', 2, 1, 1)
INSERT [dbo].[compra] ([idCompra], [Numero], [Fecha], [TipoPago], [SubTotal], [Total], [Igv], [Estado], [idProveedor], [idEmpleado], [idTipoComprobante]) VALUES (2022, N'1023', CAST(N'2024-02-22T14:23:13.000' AS DateTime), N'', CAST(3.00 AS Decimal(8, 2)), CAST(3.50 AS Decimal(8, 2)), CAST(0.50 AS Decimal(8, 2)), N'Normal', 2, 1, 3)
SET IDENTITY_INSERT [dbo].[compra] OFF
GO
SET IDENTITY_INSERT [dbo].[detallecompra] ON 

INSERT [dbo].[detallecompra] ([idDetalleCompra], [idCompra], [idProducto], [Cantidad], [Costo], [Importe]) VALUES (2, 3, 1, 3, CAST(0.30 AS Decimal(8, 2)), CAST(0.90 AS Decimal(8, 2)))
INSERT [dbo].[detallecompra] ([idDetalleCompra], [idCompra], [idProducto], [Cantidad], [Costo], [Importe]) VALUES (3, 4, 3, 3, CAST(1.50 AS Decimal(8, 2)), CAST(4.50 AS Decimal(8, 2)))
INSERT [dbo].[detallecompra] ([idDetalleCompra], [idCompra], [idProducto], [Cantidad], [Costo], [Importe]) VALUES (4, 5, 4, 2, CAST(0.30 AS Decimal(8, 2)), CAST(0.60 AS Decimal(8, 2)))
INSERT [dbo].[detallecompra] ([idDetalleCompra], [idCompra], [idProducto], [Cantidad], [Costo], [Importe]) VALUES (6, 8, 2, 2, CAST(13.00 AS Decimal(8, 2)), CAST(26.00 AS Decimal(8, 2)))
INSERT [dbo].[detallecompra] ([idDetalleCompra], [idCompra], [idProducto], [Cantidad], [Costo], [Importe]) VALUES (7, 9, 2, 3, CAST(13.00 AS Decimal(8, 2)), CAST(39.00 AS Decimal(8, 2)))
INSERT [dbo].[detallecompra] ([idDetalleCompra], [idCompra], [idProducto], [Cantidad], [Costo], [Importe]) VALUES (9, 12, 3, 2, CAST(1.50 AS Decimal(8, 2)), CAST(3.00 AS Decimal(8, 2)))
INSERT [dbo].[detallecompra] ([idDetalleCompra], [idCompra], [idProducto], [Cantidad], [Costo], [Importe]) VALUES (10, 12, 5, 4, CAST(3.20 AS Decimal(8, 2)), CAST(12.80 AS Decimal(8, 2)))
INSERT [dbo].[detallecompra] ([idDetalleCompra], [idCompra], [idProducto], [Cantidad], [Costo], [Importe]) VALUES (11, 13, 2, 2, CAST(13.00 AS Decimal(8, 2)), CAST(26.00 AS Decimal(8, 2)))
INSERT [dbo].[detallecompra] ([idDetalleCompra], [idCompra], [idProducto], [Cantidad], [Costo], [Importe]) VALUES (12, 14, 4, 3, CAST(0.30 AS Decimal(8, 2)), CAST(0.90 AS Decimal(8, 2)))
INSERT [dbo].[detallecompra] ([idDetalleCompra], [idCompra], [idProducto], [Cantidad], [Costo], [Importe]) VALUES (13, 14, 5, 5, CAST(3.20 AS Decimal(8, 2)), CAST(16.00 AS Decimal(8, 2)))
INSERT [dbo].[detallecompra] ([idDetalleCompra], [idCompra], [idProducto], [Cantidad], [Costo], [Importe]) VALUES (1009, 1012, 2, 3, CAST(13.00 AS Decimal(8, 2)), CAST(39.00 AS Decimal(8, 2)))
INSERT [dbo].[detallecompra] ([idDetalleCompra], [idCompra], [idProducto], [Cantidad], [Costo], [Importe]) VALUES (1010, 1013, 4, 3, CAST(0.30 AS Decimal(8, 2)), CAST(0.90 AS Decimal(8, 2)))
INSERT [dbo].[detallecompra] ([idDetalleCompra], [idCompra], [idProducto], [Cantidad], [Costo], [Importe]) VALUES (1011, 1013, 6, 5, CAST(4.00 AS Decimal(8, 2)), CAST(20.00 AS Decimal(8, 2)))
INSERT [dbo].[detallecompra] ([idDetalleCompra], [idCompra], [idProducto], [Cantidad], [Costo], [Importe]) VALUES (1012, 1014, 2, 3, CAST(13.00 AS Decimal(8, 2)), CAST(39.00 AS Decimal(8, 2)))
INSERT [dbo].[detallecompra] ([idDetalleCompra], [idCompra], [idProducto], [Cantidad], [Costo], [Importe]) VALUES (1014, 1017, 2, 5, CAST(13.00 AS Decimal(8, 2)), CAST(65.00 AS Decimal(8, 2)))
INSERT [dbo].[detallecompra] ([idDetalleCompra], [idCompra], [idProducto], [Cantidad], [Costo], [Importe]) VALUES (1015, 1018, 3, 9, CAST(1.50 AS Decimal(8, 2)), CAST(13.50 AS Decimal(8, 2)))
INSERT [dbo].[detallecompra] ([idDetalleCompra], [idCompra], [idProducto], [Cantidad], [Costo], [Importe]) VALUES (1016, 1019, 3, 3, CAST(1.50 AS Decimal(8, 2)), CAST(4.50 AS Decimal(8, 2)))
INSERT [dbo].[detallecompra] ([idDetalleCompra], [idCompra], [idProducto], [Cantidad], [Costo], [Importe]) VALUES (1017, 1020, 5, 3, CAST(3.20 AS Decimal(8, 2)), CAST(9.60 AS Decimal(8, 2)))
INSERT [dbo].[detallecompra] ([idDetalleCompra], [idCompra], [idProducto], [Cantidad], [Costo], [Importe]) VALUES (1018, 1021, 7, 4, CAST(8.50 AS Decimal(8, 2)), CAST(34.00 AS Decimal(8, 2)))
INSERT [dbo].[detallecompra] ([idDetalleCompra], [idCompra], [idProducto], [Cantidad], [Costo], [Importe]) VALUES (2012, 1022, 5, 5, CAST(3.20 AS Decimal(8, 2)), CAST(16.00 AS Decimal(8, 2)))
SET IDENTITY_INSERT [dbo].[detallecompra] OFF
GO
SET IDENTITY_INSERT [dbo].[detalleventa] ON 

INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (1, 1, 2, 2, CAST(13.00 AS Decimal(8, 2)), CAST(16.00 AS Decimal(8, 2)), CAST(32.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (2, 1, 2, 2, CAST(13.00 AS Decimal(8, 2)), CAST(16.00 AS Decimal(8, 2)), CAST(32.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (3, 1, 2, 3, CAST(13.00 AS Decimal(8, 2)), CAST(16.00 AS Decimal(8, 2)), CAST(48.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (4, 1, 2, 3, CAST(13.00 AS Decimal(8, 2)), CAST(16.00 AS Decimal(8, 2)), CAST(48.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (5, 1, 2, 3, CAST(13.00 AS Decimal(8, 2)), CAST(16.00 AS Decimal(8, 2)), CAST(48.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (6, 1, 2, 3, CAST(13.00 AS Decimal(8, 2)), CAST(16.00 AS Decimal(8, 2)), CAST(48.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (7, 1, 2, 2, CAST(13.00 AS Decimal(8, 2)), CAST(16.00 AS Decimal(8, 2)), CAST(32.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (8, 1, 2, 2, CAST(13.00 AS Decimal(8, 2)), CAST(16.00 AS Decimal(8, 2)), CAST(32.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (9, 1, 2, 3, CAST(13.00 AS Decimal(8, 2)), CAST(16.00 AS Decimal(8, 2)), CAST(48.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (10, 1, 2, 3, CAST(13.00 AS Decimal(8, 2)), CAST(16.00 AS Decimal(8, 2)), CAST(48.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (11, 8, 2, 2, CAST(13.00 AS Decimal(8, 2)), CAST(16.00 AS Decimal(8, 2)), CAST(32.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (12, 8, 2, 2, CAST(13.00 AS Decimal(8, 2)), CAST(16.00 AS Decimal(8, 2)), CAST(32.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (13, 8, 5, 7, CAST(3.20 AS Decimal(8, 2)), CAST(3.80 AS Decimal(8, 2)), CAST(26.60 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (14, 8, 5, 7, CAST(3.20 AS Decimal(8, 2)), CAST(3.80 AS Decimal(8, 2)), CAST(26.60 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (15, 8, 5, 7, CAST(3.20 AS Decimal(8, 2)), CAST(3.80 AS Decimal(8, 2)), CAST(26.60 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (16, 8, 5, 7, CAST(3.20 AS Decimal(8, 2)), CAST(3.80 AS Decimal(8, 2)), CAST(26.60 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (17, 8, 5, 7, CAST(3.20 AS Decimal(8, 2)), CAST(3.80 AS Decimal(8, 2)), CAST(26.60 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (18, 8, 5, 7, CAST(3.20 AS Decimal(8, 2)), CAST(3.80 AS Decimal(8, 2)), CAST(26.60 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (19, 12, 2, 3, CAST(13.00 AS Decimal(8, 2)), CAST(16.00 AS Decimal(8, 2)), CAST(48.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (20, 12, 2, 3, CAST(13.00 AS Decimal(8, 2)), CAST(16.00 AS Decimal(8, 2)), CAST(48.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (21, 12, 3, 2, CAST(1.50 AS Decimal(8, 2)), CAST(2.50 AS Decimal(8, 2)), CAST(5.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (22, 12, 3, 2, CAST(1.50 AS Decimal(8, 2)), CAST(2.50 AS Decimal(8, 2)), CAST(5.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (23, 13, 5, 3, CAST(3.20 AS Decimal(8, 2)), CAST(3.80 AS Decimal(8, 2)), CAST(11.40 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (24, 13, 5, 3, CAST(3.20 AS Decimal(8, 2)), CAST(3.80 AS Decimal(8, 2)), CAST(11.40 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (25, 13, 7, 3, CAST(8.50 AS Decimal(8, 2)), CAST(9.80 AS Decimal(8, 2)), CAST(29.40 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (26, 13, 7, 3, CAST(8.50 AS Decimal(8, 2)), CAST(9.80 AS Decimal(8, 2)), CAST(29.40 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (27, 14, 5, 4, CAST(3.20 AS Decimal(8, 2)), CAST(3.80 AS Decimal(8, 2)), CAST(15.20 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (28, 14, 5, 4, CAST(3.20 AS Decimal(8, 2)), CAST(3.80 AS Decimal(8, 2)), CAST(15.20 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (29, 14, 7, 2, CAST(8.50 AS Decimal(8, 2)), CAST(9.80 AS Decimal(8, 2)), CAST(19.60 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (30, 14, 7, 2, CAST(8.50 AS Decimal(8, 2)), CAST(9.80 AS Decimal(8, 2)), CAST(19.60 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (31, 15, 2, 3, CAST(13.00 AS Decimal(8, 2)), CAST(16.00 AS Decimal(8, 2)), CAST(48.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (32, 15, 2, 3, CAST(13.00 AS Decimal(8, 2)), CAST(16.00 AS Decimal(8, 2)), CAST(48.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (33, 16, 2, 3, CAST(13.00 AS Decimal(8, 2)), CAST(16.00 AS Decimal(8, 2)), CAST(48.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (34, 16, 2, 3, CAST(13.00 AS Decimal(8, 2)), CAST(16.00 AS Decimal(8, 2)), CAST(48.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (35, 17, 3, 2, CAST(1.50 AS Decimal(8, 2)), CAST(2.50 AS Decimal(8, 2)), CAST(5.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (36, 17, 3, 2, CAST(1.50 AS Decimal(8, 2)), CAST(2.50 AS Decimal(8, 2)), CAST(5.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (37, 17, 7, 3, CAST(8.50 AS Decimal(8, 2)), CAST(9.80 AS Decimal(8, 2)), CAST(29.40 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (38, 17, 7, 3, CAST(8.50 AS Decimal(8, 2)), CAST(9.80 AS Decimal(8, 2)), CAST(29.40 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (1019, 1014, 3, 3, CAST(1.50 AS Decimal(8, 2)), CAST(2.50 AS Decimal(8, 2)), CAST(7.50 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (1020, 1014, 3, 3, CAST(1.50 AS Decimal(8, 2)), CAST(2.50 AS Decimal(8, 2)), CAST(7.50 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (1021, 1016, 3, 2, CAST(1.50 AS Decimal(8, 2)), CAST(2.50 AS Decimal(8, 2)), CAST(5.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (1022, 1016, 3, 2, CAST(1.50 AS Decimal(8, 2)), CAST(2.50 AS Decimal(8, 2)), CAST(5.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (1023, 1016, 4, 3, CAST(0.30 AS Decimal(8, 2)), CAST(0.50 AS Decimal(8, 2)), CAST(1.50 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (1024, 1016, 4, 3, CAST(0.30 AS Decimal(8, 2)), CAST(0.50 AS Decimal(8, 2)), CAST(1.50 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (1025, 1018, 2, 3, CAST(13.00 AS Decimal(8, 2)), CAST(16.00 AS Decimal(8, 2)), CAST(48.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (1026, 1018, 2, 3, CAST(13.00 AS Decimal(8, 2)), CAST(16.00 AS Decimal(8, 2)), CAST(48.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (1027, 1019, 4, 4, CAST(0.30 AS Decimal(8, 2)), CAST(0.50 AS Decimal(8, 2)), CAST(2.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (1028, 1019, 4, 4, CAST(0.30 AS Decimal(8, 2)), CAST(0.50 AS Decimal(8, 2)), CAST(2.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (1029, 1020, 4, 4, CAST(0.30 AS Decimal(8, 2)), CAST(0.50 AS Decimal(8, 2)), CAST(2.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (1030, 1020, 4, 4, CAST(0.30 AS Decimal(8, 2)), CAST(0.50 AS Decimal(8, 2)), CAST(2.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (1031, 1021, 5, 4, CAST(3.20 AS Decimal(8, 2)), CAST(3.80 AS Decimal(8, 2)), CAST(15.20 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (1032, 1021, 5, 4, CAST(3.20 AS Decimal(8, 2)), CAST(3.80 AS Decimal(8, 2)), CAST(15.20 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (1033, 1021, 3, 5, CAST(1.50 AS Decimal(8, 2)), CAST(2.50 AS Decimal(8, 2)), CAST(12.50 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (1034, 1021, 3, 5, CAST(1.50 AS Decimal(8, 2)), CAST(2.50 AS Decimal(8, 2)), CAST(12.50 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (1035, 1022, 3, 3, CAST(1.50 AS Decimal(8, 2)), CAST(2.50 AS Decimal(8, 2)), CAST(46.52 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (1036, 1022, 3, 3, CAST(1.50 AS Decimal(8, 2)), CAST(2.50 AS Decimal(8, 2)), CAST(46.52 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (1037, 1022, 7, 4, CAST(8.50 AS Decimal(8, 2)), CAST(9.80 AS Decimal(8, 2)), CAST(46.52 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (1038, 1022, 7, 4, CAST(8.50 AS Decimal(8, 2)), CAST(9.80 AS Decimal(8, 2)), CAST(46.52 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (1039, 1023, 4, 3, CAST(0.30 AS Decimal(8, 2)), CAST(0.50 AS Decimal(8, 2)), CAST(16.52 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (1040, 1023, 4, 3, CAST(0.30 AS Decimal(8, 2)), CAST(0.50 AS Decimal(8, 2)), CAST(16.52 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (1041, 1023, 5, 4, CAST(3.20 AS Decimal(8, 2)), CAST(3.80 AS Decimal(8, 2)), CAST(16.52 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (1042, 1023, 5, 4, CAST(3.20 AS Decimal(8, 2)), CAST(3.80 AS Decimal(8, 2)), CAST(16.52 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (1043, 1024, 3, 4, CAST(1.50 AS Decimal(8, 2)), CAST(2.50 AS Decimal(8, 2)), CAST(10.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (1044, 1024, 3, 4, CAST(1.50 AS Decimal(8, 2)), CAST(2.50 AS Decimal(8, 2)), CAST(10.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (1045, 1024, 3, 4, CAST(1.50 AS Decimal(8, 2)), CAST(2.50 AS Decimal(8, 2)), CAST(10.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (1046, 1024, 3, 4, CAST(1.50 AS Decimal(8, 2)), CAST(2.50 AS Decimal(8, 2)), CAST(10.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (1047, 1025, 3, 3, CAST(1.50 AS Decimal(8, 2)), CAST(2.50 AS Decimal(8, 2)), CAST(7.50 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (1048, 1025, 3, 3, CAST(1.50 AS Decimal(8, 2)), CAST(2.50 AS Decimal(8, 2)), CAST(7.50 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (1049, 1025, 3, 3, CAST(1.50 AS Decimal(8, 2)), CAST(2.50 AS Decimal(8, 2)), CAST(7.50 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (1050, 1025, 3, 3, CAST(1.50 AS Decimal(8, 2)), CAST(2.50 AS Decimal(8, 2)), CAST(7.50 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (1051, 1025, 3, 3, CAST(1.50 AS Decimal(8, 2)), CAST(2.50 AS Decimal(8, 2)), CAST(7.50 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (1052, 1025, 3, 3, CAST(1.50 AS Decimal(8, 2)), CAST(2.50 AS Decimal(8, 2)), CAST(7.50 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (1053, 1026, 3, 3, CAST(1.50 AS Decimal(8, 2)), CAST(2.50 AS Decimal(8, 2)), CAST(7.50 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (1054, 1026, 3, 3, CAST(1.50 AS Decimal(8, 2)), CAST(2.50 AS Decimal(8, 2)), CAST(7.50 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (1055, 1026, 3, 3, CAST(1.50 AS Decimal(8, 2)), CAST(2.50 AS Decimal(8, 2)), CAST(7.50 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (1056, 1026, 3, 3, CAST(1.50 AS Decimal(8, 2)), CAST(2.50 AS Decimal(8, 2)), CAST(7.50 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (1057, 1026, 3, 3, CAST(1.50 AS Decimal(8, 2)), CAST(2.50 AS Decimal(8, 2)), CAST(7.50 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (1058, 1026, 3, 3, CAST(1.50 AS Decimal(8, 2)), CAST(2.50 AS Decimal(8, 2)), CAST(7.50 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (1059, 1027, 3, 3, CAST(1.50 AS Decimal(8, 2)), CAST(2.50 AS Decimal(8, 2)), CAST(7.50 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (1060, 1027, 3, 3, CAST(1.50 AS Decimal(8, 2)), CAST(2.50 AS Decimal(8, 2)), CAST(7.50 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (1061, 1027, 4, 5, CAST(0.30 AS Decimal(8, 2)), CAST(0.50 AS Decimal(8, 2)), CAST(2.50 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (1062, 1027, 4, 5, CAST(0.30 AS Decimal(8, 2)), CAST(0.50 AS Decimal(8, 2)), CAST(2.50 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (1063, 1028, 5, 7, CAST(3.20 AS Decimal(8, 2)), CAST(3.80 AS Decimal(8, 2)), CAST(26.60 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (1064, 1028, 5, 7, CAST(3.20 AS Decimal(8, 2)), CAST(3.80 AS Decimal(8, 2)), CAST(26.60 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (1065, 1029, 2, 4, CAST(13.00 AS Decimal(8, 2)), CAST(16.00 AS Decimal(8, 2)), CAST(64.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (1066, 1029, 2, 4, CAST(13.00 AS Decimal(8, 2)), CAST(16.00 AS Decimal(8, 2)), CAST(64.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (1067, 1030, 4, 3, CAST(0.30 AS Decimal(8, 2)), CAST(0.50 AS Decimal(8, 2)), CAST(1.50 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (1068, 1030, 4, 3, CAST(0.30 AS Decimal(8, 2)), CAST(0.50 AS Decimal(8, 2)), CAST(1.50 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (2036, 2023, 2, 3, CAST(13.00 AS Decimal(8, 2)), CAST(16.00 AS Decimal(8, 2)), CAST(48.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (2037, 2023, 2, 3, CAST(13.00 AS Decimal(8, 2)), CAST(16.00 AS Decimal(8, 2)), CAST(48.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (2038, 2023, 3, 4, CAST(1.50 AS Decimal(8, 2)), CAST(2.50 AS Decimal(8, 2)), CAST(10.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (2039, 2023, 3, 4, CAST(1.50 AS Decimal(8, 2)), CAST(2.50 AS Decimal(8, 2)), CAST(10.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (2040, 2024, 2, 4, CAST(13.00 AS Decimal(8, 2)), CAST(16.00 AS Decimal(8, 2)), CAST(64.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (2041, 2024, 2, 4, CAST(13.00 AS Decimal(8, 2)), CAST(16.00 AS Decimal(8, 2)), CAST(64.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (2042, 2025, 4, 4, CAST(0.30 AS Decimal(8, 2)), CAST(0.50 AS Decimal(8, 2)), CAST(2.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (2043, 2025, 4, 4, CAST(0.30 AS Decimal(8, 2)), CAST(0.50 AS Decimal(8, 2)), CAST(2.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (2044, 2026, 2, 2, CAST(13.00 AS Decimal(8, 2)), CAST(16.00 AS Decimal(8, 2)), CAST(32.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (2045, 2026, 2, 2, CAST(13.00 AS Decimal(8, 2)), CAST(16.00 AS Decimal(8, 2)), CAST(32.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (2046, 2026, 3, 4, CAST(1.50 AS Decimal(8, 2)), CAST(2.50 AS Decimal(8, 2)), CAST(10.00 AS Decimal(8, 2)))
GO
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (2047, 2026, 3, 4, CAST(1.50 AS Decimal(8, 2)), CAST(2.50 AS Decimal(8, 2)), CAST(10.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (2048, 2026, 5, 2, CAST(3.20 AS Decimal(8, 2)), CAST(3.80 AS Decimal(8, 2)), CAST(7.60 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (2049, 2026, 5, 2, CAST(3.20 AS Decimal(8, 2)), CAST(3.80 AS Decimal(8, 2)), CAST(7.60 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (2050, 2027, 2, 2, CAST(13.00 AS Decimal(8, 2)), CAST(16.00 AS Decimal(8, 2)), CAST(32.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (2051, 2027, 2, 2, CAST(13.00 AS Decimal(8, 2)), CAST(16.00 AS Decimal(8, 2)), CAST(32.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (2052, 2027, 3, 4, CAST(1.50 AS Decimal(8, 2)), CAST(2.50 AS Decimal(8, 2)), CAST(10.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (2053, 2027, 3, 4, CAST(1.50 AS Decimal(8, 2)), CAST(2.50 AS Decimal(8, 2)), CAST(10.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (2054, 2027, 5, 2, CAST(3.20 AS Decimal(8, 2)), CAST(3.80 AS Decimal(8, 2)), CAST(7.60 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (2055, 2027, 5, 2, CAST(3.20 AS Decimal(8, 2)), CAST(3.80 AS Decimal(8, 2)), CAST(7.60 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (2056, 2028, 2, 2, CAST(13.00 AS Decimal(8, 2)), CAST(16.00 AS Decimal(8, 2)), CAST(32.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (2057, 2028, 2, 2, CAST(13.00 AS Decimal(8, 2)), CAST(16.00 AS Decimal(8, 2)), CAST(32.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (2058, 2028, 3, 4, CAST(1.50 AS Decimal(8, 2)), CAST(2.50 AS Decimal(8, 2)), CAST(10.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (2059, 2028, 3, 4, CAST(1.50 AS Decimal(8, 2)), CAST(2.50 AS Decimal(8, 2)), CAST(10.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (2060, 2028, 5, 2, CAST(3.20 AS Decimal(8, 2)), CAST(3.80 AS Decimal(8, 2)), CAST(7.60 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (2061, 2028, 5, 2, CAST(3.20 AS Decimal(8, 2)), CAST(3.80 AS Decimal(8, 2)), CAST(7.60 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (2062, 2028, 6, 1, CAST(4.00 AS Decimal(8, 2)), CAST(4.80 AS Decimal(8, 2)), CAST(4.80 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (2063, 2028, 6, 1, CAST(4.00 AS Decimal(8, 2)), CAST(4.80 AS Decimal(8, 2)), CAST(4.80 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (3036, 3023, 3, 3, CAST(1.50 AS Decimal(8, 2)), CAST(2.50 AS Decimal(8, 2)), CAST(7.50 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (3037, 3023, 3, 3, CAST(1.50 AS Decimal(8, 2)), CAST(2.50 AS Decimal(8, 2)), CAST(7.50 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (3038, 3024, 3, 3, CAST(1.50 AS Decimal(8, 2)), CAST(2.50 AS Decimal(8, 2)), CAST(7.50 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (3039, 3024, 3, 3, CAST(1.50 AS Decimal(8, 2)), CAST(2.50 AS Decimal(8, 2)), CAST(7.50 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (3040, 3025, 6, 4, CAST(4.00 AS Decimal(8, 2)), CAST(4.80 AS Decimal(8, 2)), CAST(19.20 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (3041, 3025, 6, 4, CAST(4.00 AS Decimal(8, 2)), CAST(4.80 AS Decimal(8, 2)), CAST(19.20 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (3042, 3026, 7, 4, CAST(8.50 AS Decimal(8, 2)), CAST(9.80 AS Decimal(8, 2)), CAST(39.20 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (3043, 3026, 7, 4, CAST(8.50 AS Decimal(8, 2)), CAST(9.80 AS Decimal(8, 2)), CAST(39.20 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (3044, 3026, 4, 7, CAST(0.30 AS Decimal(8, 2)), CAST(0.50 AS Decimal(8, 2)), CAST(3.50 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (3045, 3026, 4, 7, CAST(0.30 AS Decimal(8, 2)), CAST(0.50 AS Decimal(8, 2)), CAST(3.50 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (3047, 3029, 7, 4, CAST(8.50 AS Decimal(8, 2)), CAST(9.80 AS Decimal(8, 2)), CAST(39.20 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (3048, 3029, 7, 4, CAST(8.50 AS Decimal(8, 2)), CAST(9.80 AS Decimal(8, 2)), CAST(39.20 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (3049, 3030, 6, 2, CAST(4.00 AS Decimal(8, 2)), CAST(4.80 AS Decimal(8, 2)), CAST(9.60 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (3050, 3030, 6, 2, CAST(4.00 AS Decimal(8, 2)), CAST(4.80 AS Decimal(8, 2)), CAST(9.60 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (3051, 3030, 2, 2, CAST(13.00 AS Decimal(8, 2)), CAST(16.00 AS Decimal(8, 2)), CAST(32.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (3052, 3030, 2, 2, CAST(13.00 AS Decimal(8, 2)), CAST(16.00 AS Decimal(8, 2)), CAST(32.00 AS Decimal(8, 2)))
SET IDENTITY_INSERT [dbo].[detalleventa] OFF
GO
SET IDENTITY_INSERT [dbo].[empleado] ON 

INSERT [dbo].[empleado] ([idEmpleado], [Nombres], [Apellidos], [Especialidad], [Sexo], [Dni], [Email], [Telefono], [Direccion], [HoraIngreso], [HoraSalida], [Sueldo], [Estado], [idUsuario]) VALUES (1, N'Franz Jensen', N'Loja Zelada', N'Administrador', N'M', 71902238, N'franzjensen03@gmail.com', 931405480, N'Av. Heroes del cenepa 1520', N'8:00 am', N'6:00 pm', CAST(2500.00 AS Decimal(8, 2)), N'Activo', 1)
INSERT [dbo].[empleado] ([idEmpleado], [Nombres], [Apellidos], [Especialidad], [Sexo], [Dni], [Email], [Telefono], [Direccion], [HoraIngreso], [HoraSalida], [Sueldo], [Estado], [idUsuario]) VALUES (2, N'Cristian Yover', N'Vasquez Nauca', N'Administrador', N'M', 71902265, N'yover@gmsil.com', 987412036, N'Av. Circunvalacion 220', N'8:00 am', N'6:00 pm', CAST(2500.00 AS Decimal(8, 2)), N'Activo', 2)
INSERT [dbo].[empleado] ([idEmpleado], [Nombres], [Apellidos], [Especialidad], [Sexo], [Dni], [Email], [Telefono], [Direccion], [HoraIngreso], [HoraSalida], [Sueldo], [Estado], [idUsuario]) VALUES (3, N'Maria', N'Camus Sanchez', N'Enfermera', N'F', 33428516, N'maria@gmail.com', 984162357, N'Jr. Las Bermudas 150', N'7:00 am', N'5:00 pm', CAST(1800.00 AS Decimal(8, 2)), N'Activo', NULL)
INSERT [dbo].[empleado] ([idEmpleado], [Nombres], [Apellidos], [Especialidad], [Sexo], [Dni], [Email], [Telefono], [Direccion], [HoraIngreso], [HoraSalida], [Sueldo], [Estado], [idUsuario]) VALUES (4, N'Juana', N'Mesones Portocarrero', N'Enfermera', N'F', 33451264, N'juana_32@hotmail.com', 942631057, N'Av. Circunvalacion 610', N'5:00 pm', N'10:00 pm', CAST(1500.00 AS Decimal(8, 2)), N'Activo', NULL)
INSERT [dbo].[empleado] ([idEmpleado], [Nombres], [Apellidos], [Especialidad], [Sexo], [Dni], [Email], [Telefono], [Direccion], [HoraIngreso], [HoraSalida], [Sueldo], [Estado], [idUsuario]) VALUES (5, N'Miriam Melissa', N'Tarazona Campos', N'Tecnica Enfermera', N'F', 334125697, N'melissa@hotmail.com', 945103782, N'Jr. Amazonas 152', N'8:00 am', N'6:00 pm', CAST(1500.00 AS Decimal(8, 2)), N'Inactivo', NULL)
SET IDENTITY_INSERT [dbo].[empleado] OFF
GO
SET IDENTITY_INSERT [dbo].[laboratorio] ON 

INSERT [dbo].[laboratorio] ([idLaboratorio], [Nombre], [Direccion], [Telefono], [Estado]) VALUES (1, N'PHARMA', N'Lambayeque', 985481300, N'Activo')
INSERT [dbo].[laboratorio] ([idLaboratorio], [Nombre], [Direccion], [Telefono], [Estado]) VALUES (2, N'ELIFARMA', N'Lima', 985733594, N'Activo')
INSERT [dbo].[laboratorio] ([idLaboratorio], [Nombre], [Direccion], [Telefono], [Estado]) VALUES (3, N'FARVET', N'Lima', 912475603, N'Activo')
INSERT [dbo].[laboratorio] ([idLaboratorio], [Nombre], [Direccion], [Telefono], [Estado]) VALUES (4, N'EXELTIS', N'Amazonas', 947203651, N'Activo')
INSERT [dbo].[laboratorio] ([idLaboratorio], [Nombre], [Direccion], [Telefono], [Estado]) VALUES (5, N'ELIFARMA', N'Amazonas', 417859632, N'Activo')
INSERT [dbo].[laboratorio] ([idLaboratorio], [Nombre], [Direccion], [Telefono], [Estado]) VALUES (6, N'GLENMARK', N'Cajamarca', 418759632, N'Inactivo')
INSERT [dbo].[laboratorio] ([idLaboratorio], [Nombre], [Direccion], [Telefono], [Estado]) VALUES (7, N'SANOFI', N'Cajamarca', 984231067, N'Activo')
INSERT [dbo].[laboratorio] ([idLaboratorio], [Nombre], [Direccion], [Telefono], [Estado]) VALUES (8, N'GLENTS', N'Arequipa', 987654321, N'Inactivo')
INSERT [dbo].[laboratorio] ([idLaboratorio], [Nombre], [Direccion], [Telefono], [Estado]) VALUES (9, N'Inkafarma', N'Bagua', 987451263, N'Inactivo')
SET IDENTITY_INSERT [dbo].[laboratorio] OFF
GO
SET IDENTITY_INSERT [dbo].[presentacion] ON 

INSERT [dbo].[presentacion] ([idPresentacion], [Descripcion], [Estado]) VALUES (1, N'Aerosol', N'Activo')
INSERT [dbo].[presentacion] ([idPresentacion], [Descripcion], [Estado]) VALUES (2, N'Capsula', N'Activo')
INSERT [dbo].[presentacion] ([idPresentacion], [Descripcion], [Estado]) VALUES (3, N'Colirio', N'Activo')
INSERT [dbo].[presentacion] ([idPresentacion], [Descripcion], [Estado]) VALUES (4, N'Concentración', N'Inactivo')
INSERT [dbo].[presentacion] ([idPresentacion], [Descripcion], [Estado]) VALUES (5, N'Crema', N'Activo')
INSERT [dbo].[presentacion] ([idPresentacion], [Descripcion], [Estado]) VALUES (6, N'Elixir', N'Activo')
INSERT [dbo].[presentacion] ([idPresentacion], [Descripcion], [Estado]) VALUES (7, N'Emulsion', N'Inactivo')
INSERT [dbo].[presentacion] ([idPresentacion], [Descripcion], [Estado]) VALUES (8, N'Enema', N'Activo')
INSERT [dbo].[presentacion] ([idPresentacion], [Descripcion], [Estado]) VALUES (9, N'Espuma', N'Activo')
INSERT [dbo].[presentacion] ([idPresentacion], [Descripcion], [Estado]) VALUES (10, N'Farmaco', N'Activo')
INSERT [dbo].[presentacion] ([idPresentacion], [Descripcion], [Estado]) VALUES (11, N'Gel', N'Activo')
INSERT [dbo].[presentacion] ([idPresentacion], [Descripcion], [Estado]) VALUES (12, N'Gragea', N'Activo')
INSERT [dbo].[presentacion] ([idPresentacion], [Descripcion], [Estado]) VALUES (13, N'Granulos', N'Activo')
INSERT [dbo].[presentacion] ([idPresentacion], [Descripcion], [Estado]) VALUES (14, N'Inyectable', N'Activo')
INSERT [dbo].[presentacion] ([idPresentacion], [Descripcion], [Estado]) VALUES (15, N'Jalea', N'Activo')
INSERT [dbo].[presentacion] ([idPresentacion], [Descripcion], [Estado]) VALUES (16, N'Jarabe', N'Activo')
INSERT [dbo].[presentacion] ([idPresentacion], [Descripcion], [Estado]) VALUES (17, N'Linimento', N'Activo')
INSERT [dbo].[presentacion] ([idPresentacion], [Descripcion], [Estado]) VALUES (18, N'Locion', N'Activo')
INSERT [dbo].[presentacion] ([idPresentacion], [Descripcion], [Estado]) VALUES (19, N'Medicamento', N'Activo')
INSERT [dbo].[presentacion] ([idPresentacion], [Descripcion], [Estado]) VALUES (20, N'Ovulo', N'Activo')
INSERT [dbo].[presentacion] ([idPresentacion], [Descripcion], [Estado]) VALUES (21, N'Pasta', N'Inactivo')
INSERT [dbo].[presentacion] ([idPresentacion], [Descripcion], [Estado]) VALUES (22, N'Polvo', N'Activo')
INSERT [dbo].[presentacion] ([idPresentacion], [Descripcion], [Estado]) VALUES (23, N'Pomada', N'Activo')
INSERT [dbo].[presentacion] ([idPresentacion], [Descripcion], [Estado]) VALUES (24, N'Solución', N'Activo')
INSERT [dbo].[presentacion] ([idPresentacion], [Descripcion], [Estado]) VALUES (25, N'Supositorio', N'Inactivo')
INSERT [dbo].[presentacion] ([idPresentacion], [Descripcion], [Estado]) VALUES (26, N'Suspensión', N'Activo')
INSERT [dbo].[presentacion] ([idPresentacion], [Descripcion], [Estado]) VALUES (27, N'Tableta', N'Activo')
SET IDENTITY_INSERT [dbo].[presentacion] OFF
GO
SET IDENTITY_INSERT [dbo].[producto] ON 

INSERT [dbo].[producto] ([idProducto], [Codigo_Barras], [Descripcion], [Concentracion], [Stock], [Costo], [Precio_Venta], [RegistroSanitario], [FechaVencimiento], [Estado], [idPresentacion], [idLaboratorio]) VALUES (1, N'354567687656', N'Ibuprofeno2', N'500 mg', CAST(90.00 AS Decimal(8, 2)), CAST(0.30 AS Decimal(8, 2)), CAST(0.50 AS Decimal(8, 2)), N'EN01867', CAST(N'2021-08-08T00:00:00.000' AS DateTime), N'Activo', 3, 2)
INSERT [dbo].[producto] ([idProducto], [Codigo_Barras], [Descripcion], [Concentracion], [Stock], [Costo], [Precio_Venta], [RegistroSanitario], [FechaVencimiento], [Estado], [idPresentacion], [idLaboratorio]) VALUES (2, N'876896644434', N'Hepabionta', N'10mg /30ml', CAST(90.00 AS Decimal(8, 2)), CAST(13.00 AS Decimal(8, 2)), CAST(16.00 AS Decimal(8, 2)), N'EN06374', CAST(N'2022-08-14T00:00:00.000' AS DateTime), N'Activo', 2, 4)
INSERT [dbo].[producto] ([idProducto], [Codigo_Barras], [Descripcion], [Concentracion], [Stock], [Costo], [Precio_Venta], [RegistroSanitario], [FechaVencimiento], [Estado], [idPresentacion], [idLaboratorio]) VALUES (3, N'787656546765', N'Apronax', N'500 mg', CAST(150.00 AS Decimal(8, 2)), CAST(1.50 AS Decimal(8, 2)), CAST(2.50 AS Decimal(8, 2)), N'EN01596', CAST(N'2021-08-08T00:00:00.000' AS DateTime), N'Activo', 5, 6)
INSERT [dbo].[producto] ([idProducto], [Codigo_Barras], [Descripcion], [Concentracion], [Stock], [Costo], [Precio_Venta], [RegistroSanitario], [FechaVencimiento], [Estado], [idPresentacion], [idLaboratorio]) VALUES (4, N'767545675434', N'Naproxeno', N'400 mg', CAST(180.00 AS Decimal(8, 2)), CAST(0.30 AS Decimal(8, 2)), CAST(0.50 AS Decimal(8, 2)), N'EE035471', CAST(N'2022-08-11T00:00:00.000' AS DateTime), N'Activo', 6, 8)
INSERT [dbo].[producto] ([idProducto], [Codigo_Barras], [Descripcion], [Concentracion], [Stock], [Costo], [Precio_Venta], [RegistroSanitario], [FechaVencimiento], [Estado], [idPresentacion], [idLaboratorio]) VALUES (5, N'667654344546', N'Tylenol', N'15 mg / 20ml', CAST(40.00 AS Decimal(8, 2)), CAST(3.20 AS Decimal(8, 2)), CAST(3.80 AS Decimal(8, 2)), N'EE03459', CAST(N'2021-08-29T00:00:00.000' AS DateTime), N'Inactivo', 5, 1)
INSERT [dbo].[producto] ([idProducto], [Codigo_Barras], [Descripcion], [Concentracion], [Stock], [Costo], [Precio_Venta], [RegistroSanitario], [FechaVencimiento], [Estado], [idPresentacion], [idLaboratorio]) VALUES (6, N'798765675679', N'Penicilina', N'500 mg', CAST(50.00 AS Decimal(8, 2)), CAST(4.00 AS Decimal(8, 2)), CAST(4.80 AS Decimal(8, 2)), N'EN03449', CAST(N'2021-08-05T00:00:00.000' AS DateTime), N'Activo', 4, 2)
INSERT [dbo].[producto] ([idProducto], [Codigo_Barras], [Descripcion], [Concentracion], [Stock], [Costo], [Precio_Venta], [RegistroSanitario], [FechaVencimiento], [Estado], [idPresentacion], [idLaboratorio]) VALUES (7, N'546687646575', N'Flexitol', N'1 %', CAST(20.00 AS Decimal(8, 2)), CAST(8.50 AS Decimal(8, 2)), CAST(9.80 AS Decimal(8, 2)), N'EE01298', CAST(N'2021-08-16T00:00:00.000' AS DateTime), N'Activo', 12, 9)
SET IDENTITY_INSERT [dbo].[producto] OFF
GO
SET IDENTITY_INSERT [dbo].[proveedor] ON 

INSERT [dbo].[proveedor] ([IdProveedor], [Nombre], [Dni], [Ruc], [Direccion], [Email], [Telefono], [Banco], [Cuenta], [Estado]) VALUES (1, N'JORGE RAUL CAMUS PILCO', N'33425689', N'10334256897', N'Jr.Amazonas', N'jorgeraul@hotmail.com', N'987612453', N'BCP', N'1032456759484', N'Activo')
INSERT [dbo].[proveedor] ([IdProveedor], [Nombre], [Dni], [Ruc], [Direccion], [Email], [Telefono], [Banco], [Cuenta], [Estado]) VALUES (2, N'ELIFARMA', N'', N'0933428595', N'Av. Heroes del cenepa 1520', N'', N'987412350', N'BCP', N'0126544949944884', N'Activo')
SET IDENTITY_INSERT [dbo].[proveedor] OFF
GO
SET IDENTITY_INSERT [dbo].[tipocomprobante] ON 

INSERT [dbo].[tipocomprobante] ([idTipoComprobante], [Descripcion], [Estado]) VALUES (1, N'Boleta', N'Inactivo')
INSERT [dbo].[tipocomprobante] ([idTipoComprobante], [Descripcion], [Estado]) VALUES (3, N'Factura', N'Activo')
SET IDENTITY_INSERT [dbo].[tipocomprobante] OFF
GO
SET IDENTITY_INSERT [dbo].[usuario] ON 

INSERT [dbo].[usuario] ([idUsuario], [Nombres], [Apellidos], [Dni], [Email], [Usuario], [Contraseña], [TipoUsuario], [Estado]) VALUES (1, N'Loja Zelada', N'Franz Jensen', 71902238, N'franz@gmail.com', N'Franz', N'franzjensen', N'Administrador', N'Activo')
INSERT [dbo].[usuario] ([idUsuario], [Nombres], [Apellidos], [Dni], [Email], [Usuario], [Contraseña], [TipoUsuario], [Estado]) VALUES (2, N'Cristian Yover', N'Vasquez Nauca', 33428316, N'cristianyover@gmail.com', N'user', N'1234', N'Vendedor', N'Activo')
INSERT [dbo].[usuario] ([idUsuario], [Nombres], [Apellidos], [Dni], [Email], [Usuario], [Contraseña], [TipoUsuario], [Estado]) VALUES (1002, N'Franz Jensen', N'Loja Zelada', 71902238, N'franzjensen03@gmail.com', N'jemminson', N'1234', N'Vendedor', N'Activo')
INSERT [dbo].[usuario] ([idUsuario], [Nombres], [Apellidos], [Dni], [Email], [Usuario], [Contraseña], [TipoUsuario], [Estado]) VALUES (1003, N'Juana', N'Mesones Portocarrero', 33451264, N'juana_32@hotmail.com', N'Darita', N'321', N'Administrador', N'Activo')
INSERT [dbo].[usuario] ([idUsuario], [Nombres], [Apellidos], [Dni], [Email], [Usuario], [Contraseña], [TipoUsuario], [Estado]) VALUES (1004, N'Paty', N'Gomex Vera', 33425691, N'paty@hotmail.com', N'Edyy', N'1234', N'Administrador', N'Activo')
SET IDENTITY_INSERT [dbo].[usuario] OFF
GO
SET IDENTITY_INSERT [dbo].[ventas] ON 

INSERT [dbo].[ventas] ([IdVenta], [Serie], [Numero], [Fecha], [VentaTotal], [Descuento], [SubTotal], [Igv], [Total], [Estado], [idCliente], [idEmpleado], [idTipoComprobante]) VALUES (1, N'001', N'C0000001', CAST(N'2024-02-14T00:00:00.000' AS DateTime), CAST(48.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(40.68 AS Decimal(8, 2)), CAST(7.32 AS Decimal(8, 2)), CAST(48.00 AS Decimal(8, 2)), N'Normal', 2, 1, 3)
INSERT [dbo].[ventas] ([IdVenta], [Serie], [Numero], [Fecha], [VentaTotal], [Descuento], [SubTotal], [Igv], [Total], [Estado], [idCliente], [idEmpleado], [idTipoComprobante]) VALUES (2, N'001', N'C0000001', CAST(N'2024-02-14T00:00:00.000' AS DateTime), CAST(1.50 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(1.27 AS Decimal(8, 2)), CAST(0.23 AS Decimal(8, 2)), CAST(1.50 AS Decimal(8, 2)), N'Normal', 3, 1, 1)
INSERT [dbo].[ventas] ([IdVenta], [Serie], [Numero], [Fecha], [VentaTotal], [Descuento], [SubTotal], [Igv], [Total], [Estado], [idCliente], [idEmpleado], [idTipoComprobante]) VALUES (3, N'001', N'0000001', CAST(N'2024-02-14T00:00:00.000' AS DateTime), CAST(32.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(27.12 AS Decimal(8, 2)), CAST(4.88 AS Decimal(8, 2)), CAST(32.00 AS Decimal(8, 2)), N'Normal', 2, 1, 1)
INSERT [dbo].[ventas] ([IdVenta], [Serie], [Numero], [Fecha], [VentaTotal], [Descuento], [SubTotal], [Igv], [Total], [Estado], [idCliente], [idEmpleado], [idTipoComprobante]) VALUES (4, N'001', N'0000001', CAST(N'2024-02-14T00:00:00.000' AS DateTime), CAST(48.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(40.68 AS Decimal(8, 2)), CAST(7.32 AS Decimal(8, 2)), CAST(48.00 AS Decimal(8, 2)), N'Normal', 3, 1, 3)
INSERT [dbo].[ventas] ([IdVenta], [Serie], [Numero], [Fecha], [VentaTotal], [Descuento], [SubTotal], [Igv], [Total], [Estado], [idCliente], [idEmpleado], [idTipoComprobante]) VALUES (5, N'001', N'0000001', CAST(N'2024-02-14T00:00:00.000' AS DateTime), CAST(48.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(40.68 AS Decimal(8, 2)), CAST(7.32 AS Decimal(8, 2)), CAST(48.00 AS Decimal(8, 2)), N'Normal', 4, 1, 1)
INSERT [dbo].[ventas] ([IdVenta], [Serie], [Numero], [Fecha], [VentaTotal], [Descuento], [SubTotal], [Igv], [Total], [Estado], [idCliente], [idEmpleado], [idTipoComprobante]) VALUES (6, N'001', N'0000001', CAST(N'2024-02-14T00:00:00.000' AS DateTime), CAST(32.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(27.12 AS Decimal(8, 2)), CAST(4.88 AS Decimal(8, 2)), CAST(32.00 AS Decimal(8, 2)), N'Normal', 2, 1, 3)
INSERT [dbo].[ventas] ([IdVenta], [Serie], [Numero], [Fecha], [VentaTotal], [Descuento], [SubTotal], [Igv], [Total], [Estado], [idCliente], [idEmpleado], [idTipoComprobante]) VALUES (7, N'001', N'0000001', CAST(N'2024-02-14T00:00:00.000' AS DateTime), CAST(48.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(40.68 AS Decimal(8, 2)), CAST(7.32 AS Decimal(8, 2)), CAST(48.00 AS Decimal(8, 2)), N'Normal', 1, 1, 3)
INSERT [dbo].[ventas] ([IdVenta], [Serie], [Numero], [Fecha], [VentaTotal], [Descuento], [SubTotal], [Igv], [Total], [Estado], [idCliente], [idEmpleado], [idTipoComprobante]) VALUES (8, N'001', N'8', CAST(N'2024-02-14T00:00:00.000' AS DateTime), CAST(32.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(27.12 AS Decimal(8, 2)), CAST(4.88 AS Decimal(8, 2)), CAST(32.00 AS Decimal(8, 2)), N'Normal', 3, 1, 3)
INSERT [dbo].[ventas] ([IdVenta], [Serie], [Numero], [Fecha], [VentaTotal], [Descuento], [SubTotal], [Igv], [Total], [Estado], [idCliente], [idEmpleado], [idTipoComprobante]) VALUES (9, N'001', N'8', CAST(N'2024-02-14T00:00:00.000' AS DateTime), CAST(26.60 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(22.54 AS Decimal(8, 2)), CAST(4.06 AS Decimal(8, 2)), CAST(26.60 AS Decimal(8, 2)), N'Normal', 6, 1, 3)
INSERT [dbo].[ventas] ([IdVenta], [Serie], [Numero], [Fecha], [VentaTotal], [Descuento], [SubTotal], [Igv], [Total], [Estado], [idCliente], [idEmpleado], [idTipoComprobante]) VALUES (10, N'001', N'8', CAST(N'2024-02-14T00:00:00.000' AS DateTime), CAST(26.60 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(22.54 AS Decimal(8, 2)), CAST(4.06 AS Decimal(8, 2)), CAST(26.60 AS Decimal(8, 2)), N'Normal', 6, 1, 3)
INSERT [dbo].[ventas] ([IdVenta], [Serie], [Numero], [Fecha], [VentaTotal], [Descuento], [SubTotal], [Igv], [Total], [Estado], [idCliente], [idEmpleado], [idTipoComprobante]) VALUES (11, N'001', N'8', CAST(N'2024-02-14T00:00:00.000' AS DateTime), CAST(26.60 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(22.54 AS Decimal(8, 2)), CAST(4.06 AS Decimal(8, 2)), CAST(26.60 AS Decimal(8, 2)), N'Normal', 3, 1, 3)
INSERT [dbo].[ventas] ([IdVenta], [Serie], [Numero], [Fecha], [VentaTotal], [Descuento], [SubTotal], [Igv], [Total], [Estado], [idCliente], [idEmpleado], [idTipoComprobante]) VALUES (12, N'001', N'12', CAST(N'2024-02-15T00:00:00.000' AS DateTime), CAST(53.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(44.92 AS Decimal(8, 2)), CAST(8.09 AS Decimal(8, 2)), CAST(53.00 AS Decimal(8, 2)), N'Normal', 2, 1, 3)
INSERT [dbo].[ventas] ([IdVenta], [Serie], [Numero], [Fecha], [VentaTotal], [Descuento], [SubTotal], [Igv], [Total], [Estado], [idCliente], [idEmpleado], [idTipoComprobante]) VALUES (13, N'001', N'13', CAST(N'2024-02-15T00:00:00.000' AS DateTime), CAST(40.80 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(34.58 AS Decimal(8, 2)), CAST(6.22 AS Decimal(8, 2)), CAST(40.80 AS Decimal(8, 2)), N'Normal', 3, 1, 3)
INSERT [dbo].[ventas] ([IdVenta], [Serie], [Numero], [Fecha], [VentaTotal], [Descuento], [SubTotal], [Igv], [Total], [Estado], [idCliente], [idEmpleado], [idTipoComprobante]) VALUES (14, N'001', N'14', CAST(N'2024-02-15T00:00:00.000' AS DateTime), CAST(34.80 AS Decimal(8, 2)), CAST(0.10 AS Decimal(8, 2)), CAST(29.41 AS Decimal(8, 2)), CAST(5.29 AS Decimal(8, 2)), CAST(34.70 AS Decimal(8, 2)), N'Normal', 2, 1, 1)
INSERT [dbo].[ventas] ([IdVenta], [Serie], [Numero], [Fecha], [VentaTotal], [Descuento], [SubTotal], [Igv], [Total], [Estado], [idCliente], [idEmpleado], [idTipoComprobante]) VALUES (15, N'001', N'15', CAST(N'2024-02-15T00:00:00.000' AS DateTime), CAST(48.00 AS Decimal(8, 2)), CAST(0.10 AS Decimal(8, 2)), CAST(40.59 AS Decimal(8, 2)), CAST(7.31 AS Decimal(8, 2)), CAST(47.90 AS Decimal(8, 2)), N'Normal', 1, 1, 3)
INSERT [dbo].[ventas] ([IdVenta], [Serie], [Numero], [Fecha], [VentaTotal], [Descuento], [SubTotal], [Igv], [Total], [Estado], [idCliente], [idEmpleado], [idTipoComprobante]) VALUES (16, N'001', N'16', CAST(N'2024-02-15T00:00:00.000' AS DateTime), CAST(48.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(40.68 AS Decimal(8, 2)), CAST(7.32 AS Decimal(8, 2)), CAST(48.00 AS Decimal(8, 2)), N'Normal', 3, 1, 3)
INSERT [dbo].[ventas] ([IdVenta], [Serie], [Numero], [Fecha], [VentaTotal], [Descuento], [SubTotal], [Igv], [Total], [Estado], [idCliente], [idEmpleado], [idTipoComprobante]) VALUES (17, N'001', N'17', CAST(N'2024-02-15T00:00:00.000' AS DateTime), CAST(34.40 AS Decimal(8, 2)), CAST(0.10 AS Decimal(8, 2)), CAST(29.07 AS Decimal(8, 2)), CAST(5.23 AS Decimal(8, 2)), CAST(34.30 AS Decimal(8, 2)), N'Normal', 3, 1, 3)
INSERT [dbo].[ventas] ([IdVenta], [Serie], [Numero], [Fecha], [VentaTotal], [Descuento], [SubTotal], [Igv], [Total], [Estado], [idCliente], [idEmpleado], [idTipoComprobante]) VALUES (1012, N'001', N'C000000018', CAST(N'2024-02-16T00:00:00.000' AS DateTime), CAST(48.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(40.68 AS Decimal(8, 2)), CAST(7.32 AS Decimal(8, 2)), CAST(48.00 AS Decimal(8, 2)), N'Normal', 2, 1, 3)
INSERT [dbo].[ventas] ([IdVenta], [Serie], [Numero], [Fecha], [VentaTotal], [Descuento], [SubTotal], [Igv], [Total], [Estado], [idCliente], [idEmpleado], [idTipoComprobante]) VALUES (1013, N'001', N'C00000001013', CAST(N'2024-02-16T00:00:00.000' AS DateTime), CAST(2.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(1.69 AS Decimal(8, 2)), CAST(0.30 AS Decimal(8, 2)), CAST(2.00 AS Decimal(8, 2)), N'Normal', 4, 1, 3)
INSERT [dbo].[ventas] ([IdVenta], [Serie], [Numero], [Fecha], [VentaTotal], [Descuento], [SubTotal], [Igv], [Total], [Estado], [idCliente], [idEmpleado], [idTipoComprobante]) VALUES (1014, N'001', N'0000001014', CAST(N'2024-02-16T00:00:00.000' AS DateTime), CAST(7.50 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(6.36 AS Decimal(8, 2)), CAST(1.14 AS Decimal(8, 2)), CAST(7.50 AS Decimal(8, 2)), N'Normal', 2, 1, 3)
INSERT [dbo].[ventas] ([IdVenta], [Serie], [Numero], [Fecha], [VentaTotal], [Descuento], [SubTotal], [Igv], [Total], [Estado], [idCliente], [idEmpleado], [idTipoComprobante]) VALUES (1015, N'001', N'C0000001015', CAST(N'2024-02-16T00:00:00.000' AS DateTime), CAST(11.40 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(9.66 AS Decimal(8, 2)), CAST(1.74 AS Decimal(8, 2)), CAST(11.40 AS Decimal(8, 2)), N'Normal', 2, 1, 3)
INSERT [dbo].[ventas] ([IdVenta], [Serie], [Numero], [Fecha], [VentaTotal], [Descuento], [SubTotal], [Igv], [Total], [Estado], [idCliente], [idEmpleado], [idTipoComprobante]) VALUES (1016, N'001', N'00000001016', CAST(N'2024-02-16T00:00:00.000' AS DateTime), CAST(5.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(4.24 AS Decimal(8, 2)), CAST(0.76 AS Decimal(8, 2)), CAST(5.00 AS Decimal(8, 2)), N'Normal', 5, 1, 3)
INSERT [dbo].[ventas] ([IdVenta], [Serie], [Numero], [Fecha], [VentaTotal], [Descuento], [SubTotal], [Igv], [Total], [Estado], [idCliente], [idEmpleado], [idTipoComprobante]) VALUES (1017, N'001', N'00000001016', CAST(N'2024-02-16T00:00:00.000' AS DateTime), CAST(1.50 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(1.27 AS Decimal(8, 2)), CAST(0.23 AS Decimal(8, 2)), CAST(1.50 AS Decimal(8, 2)), N'Normal', 3, 1, 1)
INSERT [dbo].[ventas] ([IdVenta], [Serie], [Numero], [Fecha], [VentaTotal], [Descuento], [SubTotal], [Igv], [Total], [Estado], [idCliente], [idEmpleado], [idTipoComprobante]) VALUES (1018, N'001', N'00000001018', CAST(N'2024-02-16T00:00:00.000' AS DateTime), CAST(48.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(40.68 AS Decimal(8, 2)), CAST(7.32 AS Decimal(8, 2)), CAST(48.00 AS Decimal(8, 2)), N'Normal', 2, 1, 3)
INSERT [dbo].[ventas] ([IdVenta], [Serie], [Numero], [Fecha], [VentaTotal], [Descuento], [SubTotal], [Igv], [Total], [Estado], [idCliente], [idEmpleado], [idTipoComprobante]) VALUES (1019, N'001', N'00000001019', CAST(N'2024-02-16T00:00:00.000' AS DateTime), CAST(2.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(1.69 AS Decimal(8, 2)), CAST(0.30 AS Decimal(8, 2)), CAST(2.00 AS Decimal(8, 2)), N'Normal', 2, 1, 3)
INSERT [dbo].[ventas] ([IdVenta], [Serie], [Numero], [Fecha], [VentaTotal], [Descuento], [SubTotal], [Igv], [Total], [Estado], [idCliente], [idEmpleado], [idTipoComprobante]) VALUES (1020, N'001', N'00000001020', CAST(N'2024-02-16T00:00:00.000' AS DateTime), CAST(2.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(1.69 AS Decimal(8, 2)), CAST(0.30 AS Decimal(8, 2)), CAST(2.00 AS Decimal(8, 2)), N'Normal', 3, 1, 3)
INSERT [dbo].[ventas] ([IdVenta], [Serie], [Numero], [Fecha], [VentaTotal], [Descuento], [SubTotal], [Igv], [Total], [Estado], [idCliente], [idEmpleado], [idTipoComprobante]) VALUES (1021, N'001', N'00000001021', CAST(N'2024-02-17T00:00:00.000' AS DateTime), CAST(27.70 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(23.47 AS Decimal(8, 2)), CAST(4.22 AS Decimal(8, 2)), CAST(27.70 AS Decimal(8, 2)), N'Normal', 3, 1, 3)
INSERT [dbo].[ventas] ([IdVenta], [Serie], [Numero], [Fecha], [VentaTotal], [Descuento], [SubTotal], [Igv], [Total], [Estado], [idCliente], [idEmpleado], [idTipoComprobante]) VALUES (1022, N'001', N'00000001022', CAST(N'2024-02-17T00:00:00.000' AS DateTime), CAST(46.70 AS Decimal(8, 2)), CAST(0.18 AS Decimal(8, 2)), CAST(39.42 AS Decimal(8, 2)), CAST(7.10 AS Decimal(8, 2)), CAST(46.52 AS Decimal(8, 2)), N'Normal', 3, 1, 3)
INSERT [dbo].[ventas] ([IdVenta], [Serie], [Numero], [Fecha], [VentaTotal], [Descuento], [SubTotal], [Igv], [Total], [Estado], [idCliente], [idEmpleado], [idTipoComprobante]) VALUES (1023, N'001', N'00000001023', CAST(N'2024-02-18T00:00:00.000' AS DateTime), CAST(16.70 AS Decimal(8, 2)), CAST(0.18 AS Decimal(8, 2)), CAST(14.00 AS Decimal(8, 2)), CAST(2.52 AS Decimal(8, 2)), CAST(16.52 AS Decimal(8, 2)), N'Normal', 2, 1, 3)
INSERT [dbo].[ventas] ([IdVenta], [Serie], [Numero], [Fecha], [VentaTotal], [Descuento], [SubTotal], [Igv], [Total], [Estado], [idCliente], [idEmpleado], [idTipoComprobante]) VALUES (1024, N'001', N'00000001024', CAST(N'2024-02-19T00:00:00.000' AS DateTime), CAST(20.00 AS Decimal(8, 2)), CAST(0.18 AS Decimal(8, 2)), CAST(16.80 AS Decimal(8, 2)), CAST(3.02 AS Decimal(8, 2)), CAST(19.82 AS Decimal(8, 2)), N'Normal', 3, 1, 3)
INSERT [dbo].[ventas] ([IdVenta], [Serie], [Numero], [Fecha], [VentaTotal], [Descuento], [SubTotal], [Igv], [Total], [Estado], [idCliente], [idEmpleado], [idTipoComprobante]) VALUES (1025, N'001', N'00000001025', CAST(N'2024-02-17T00:00:00.000' AS DateTime), CAST(22.50 AS Decimal(8, 2)), CAST(0.18 AS Decimal(8, 2)), CAST(18.92 AS Decimal(8, 2)), CAST(3.41 AS Decimal(8, 2)), CAST(22.32 AS Decimal(8, 2)), N'Normal', 3, 1, 3)
INSERT [dbo].[ventas] ([IdVenta], [Serie], [Numero], [Fecha], [VentaTotal], [Descuento], [SubTotal], [Igv], [Total], [Estado], [idCliente], [idEmpleado], [idTipoComprobante]) VALUES (1026, N'001', N'00000001026', CAST(N'2024-02-20T00:00:00.000' AS DateTime), CAST(22.50 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(19.07 AS Decimal(8, 2)), CAST(3.43 AS Decimal(8, 2)), CAST(22.50 AS Decimal(8, 2)), N'Normal', 3, 1, 3)
INSERT [dbo].[ventas] ([IdVenta], [Serie], [Numero], [Fecha], [VentaTotal], [Descuento], [SubTotal], [Igv], [Total], [Estado], [idCliente], [idEmpleado], [idTipoComprobante]) VALUES (1027, N'001', N'00000001027', CAST(N'2024-02-21T00:00:00.000' AS DateTime), CAST(10.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(8.47 AS Decimal(8, 2)), CAST(1.52 AS Decimal(8, 2)), CAST(10.00 AS Decimal(8, 2)), N'Normal', 3, 1, 3)
INSERT [dbo].[ventas] ([IdVenta], [Serie], [Numero], [Fecha], [VentaTotal], [Descuento], [SubTotal], [Igv], [Total], [Estado], [idCliente], [idEmpleado], [idTipoComprobante]) VALUES (1028, N'001', N'00000001028', CAST(N'2024-02-25T00:00:00.000' AS DateTime), CAST(26.60 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(22.54 AS Decimal(8, 2)), CAST(4.06 AS Decimal(8, 2)), CAST(26.60 AS Decimal(8, 2)), N'Normal', 5, 1, 3)
INSERT [dbo].[ventas] ([IdVenta], [Serie], [Numero], [Fecha], [VentaTotal], [Descuento], [SubTotal], [Igv], [Total], [Estado], [idCliente], [idEmpleado], [idTipoComprobante]) VALUES (1029, N'001', N'00000001029', CAST(N'2024-02-19T00:00:00.000' AS DateTime), CAST(64.00 AS Decimal(8, 2)), CAST(0.10 AS Decimal(8, 2)), CAST(54.15 AS Decimal(8, 2)), CAST(9.75 AS Decimal(8, 2)), CAST(63.90 AS Decimal(8, 2)), N'Normal', 3, 1, 3)
INSERT [dbo].[ventas] ([IdVenta], [Serie], [Numero], [Fecha], [VentaTotal], [Descuento], [SubTotal], [Igv], [Total], [Estado], [idCliente], [idEmpleado], [idTipoComprobante]) VALUES (1030, N'001', N'00000001030', CAST(N'2024-02-19T00:00:00.000' AS DateTime), CAST(1.50 AS Decimal(8, 2)), CAST(0.10 AS Decimal(8, 2)), CAST(1.19 AS Decimal(8, 2)), CAST(0.21 AS Decimal(8, 2)), CAST(1.40 AS Decimal(8, 2)), N'Normal', 4, 1, 3)
INSERT [dbo].[ventas] ([IdVenta], [Serie], [Numero], [Fecha], [VentaTotal], [Descuento], [SubTotal], [Igv], [Total], [Estado], [idCliente], [idEmpleado], [idTipoComprobante]) VALUES (2022, N'001', N'00000001031', CAST(N'2024-02-19T00:00:00.000' AS DateTime), CAST(58.00 AS Decimal(8, 2)), CAST(2.00 AS Decimal(8, 2)), CAST(56.00 AS Decimal(8, 2)), CAST(8.00 AS Decimal(8, 2)), CAST(65.00 AS Decimal(8, 2)), N'Normal', 3, 1, 3)
INSERT [dbo].[ventas] ([IdVenta], [Serie], [Numero], [Fecha], [VentaTotal], [Descuento], [SubTotal], [Igv], [Total], [Estado], [idCliente], [idEmpleado], [idTipoComprobante]) VALUES (2023, N'001', N'00000002023', CAST(N'2024-02-19T00:00:00.000' AS DateTime), CAST(58.00 AS Decimal(8, 2)), CAST(2.00 AS Decimal(8, 2)), CAST(56.00 AS Decimal(8, 2)), CAST(8.00 AS Decimal(8, 2)), CAST(65.00 AS Decimal(8, 2)), N'Normal', 2, 1, 3)
INSERT [dbo].[ventas] ([IdVenta], [Serie], [Numero], [Fecha], [VentaTotal], [Descuento], [SubTotal], [Igv], [Total], [Estado], [idCliente], [idEmpleado], [idTipoComprobante]) VALUES (2024, N'001', N'00000002024', CAST(N'2024-02-19T00:00:00.000' AS DateTime), CAST(64.00 AS Decimal(8, 2)), CAST(4.00 AS Decimal(8, 2)), CAST(60.00 AS Decimal(8, 2)), CAST(9.00 AS Decimal(8, 2)), CAST(70.00 AS Decimal(8, 2)), N'Normal', 3, 1, 3)
INSERT [dbo].[ventas] ([IdVenta], [Serie], [Numero], [Fecha], [VentaTotal], [Descuento], [SubTotal], [Igv], [Total], [Estado], [idCliente], [idEmpleado], [idTipoComprobante]) VALUES (2025, N'001', N'00000002025', CAST(N'2024-02-19T00:00:00.000' AS DateTime), CAST(2.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(2.00 AS Decimal(8, 2)), CAST(0.30 AS Decimal(8, 2)), CAST(2.00 AS Decimal(8, 2)), N'Normal', 4, 1, 3)
INSERT [dbo].[ventas] ([IdVenta], [Serie], [Numero], [Fecha], [VentaTotal], [Descuento], [SubTotal], [Igv], [Total], [Estado], [idCliente], [idEmpleado], [idTipoComprobante]) VALUES (2026, N'001', N'00000002026', CAST(N'2024-02-19T00:00:00.000' AS DateTime), CAST(49.60 AS Decimal(8, 2)), CAST(2.00 AS Decimal(8, 2)), CAST(47.60 AS Decimal(8, 2)), CAST(7.10 AS Decimal(8, 2)), CAST(56.17 AS Decimal(8, 2)), N'Normal', 3, 1, 3)
INSERT [dbo].[ventas] ([IdVenta], [Serie], [Numero], [Fecha], [VentaTotal], [Descuento], [SubTotal], [Igv], [Total], [Estado], [idCliente], [idEmpleado], [idTipoComprobante]) VALUES (2027, N'001', N'00000002027', CAST(N'2024-02-19T00:00:00.000' AS DateTime), CAST(49.60 AS Decimal(8, 2)), CAST(2.00 AS Decimal(8, 2)), CAST(47.60 AS Decimal(8, 2)), CAST(7.10 AS Decimal(8, 2)), CAST(54.74 AS Decimal(8, 2)), N'Normal', 5, 1, 1)
INSERT [dbo].[ventas] ([IdVenta], [Serie], [Numero], [Fecha], [VentaTotal], [Descuento], [SubTotal], [Igv], [Total], [Estado], [idCliente], [idEmpleado], [idTipoComprobante]) VALUES (2028, N'001', N'00000002028', CAST(N'2024-02-19T00:00:00.000' AS DateTime), CAST(54.40 AS Decimal(8, 2)), CAST(2.00 AS Decimal(8, 2)), CAST(52.40 AS Decimal(8, 2)), CAST(7.90 AS Decimal(8, 2)), CAST(60.30 AS Decimal(8, 2)), N'Normal', 6, 1, 3)
INSERT [dbo].[ventas] ([IdVenta], [Serie], [Numero], [Fecha], [VentaTotal], [Descuento], [SubTotal], [Igv], [Total], [Estado], [idCliente], [idEmpleado], [idTipoComprobante]) VALUES (3022, N'001', N'00000002029', CAST(N'2024-02-21T00:00:00.000' AS DateTime), CAST(7.50 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(7.50 AS Decimal(8, 2)), CAST(1.10 AS Decimal(8, 2)), CAST(8.60 AS Decimal(8, 2)), N'Normal', 5, 1, 1)
INSERT [dbo].[ventas] ([IdVenta], [Serie], [Numero], [Fecha], [VentaTotal], [Descuento], [SubTotal], [Igv], [Total], [Estado], [idCliente], [idEmpleado], [idTipoComprobante]) VALUES (3023, N'001', N'00000003023', CAST(N'2024-02-21T00:00:00.000' AS DateTime), CAST(7.50 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(7.50 AS Decimal(8, 2)), CAST(1.10 AS Decimal(8, 2)), CAST(8.60 AS Decimal(8, 2)), N'Normal', 5, 1, 1)
INSERT [dbo].[ventas] ([IdVenta], [Serie], [Numero], [Fecha], [VentaTotal], [Descuento], [SubTotal], [Igv], [Total], [Estado], [idCliente], [idEmpleado], [idTipoComprobante]) VALUES (3024, N'001', N'00000003024', CAST(N'2024-02-21T00:00:00.000' AS DateTime), CAST(7.50 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(7.50 AS Decimal(8, 2)), CAST(1.10 AS Decimal(8, 2)), CAST(8.60 AS Decimal(8, 2)), N'Normal', 6, 1, 1)
INSERT [dbo].[ventas] ([IdVenta], [Serie], [Numero], [Fecha], [VentaTotal], [Descuento], [SubTotal], [Igv], [Total], [Estado], [idCliente], [idEmpleado], [idTipoComprobante]) VALUES (3025, N'001', N'00000003025', CAST(N'2024-02-21T15:49:45.000' AS DateTime), CAST(19.20 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(19.20 AS Decimal(8, 2)), CAST(2.90 AS Decimal(8, 2)), CAST(22.10 AS Decimal(8, 2)), N'Normal', 7, 1, 3)
INSERT [dbo].[ventas] ([IdVenta], [Serie], [Numero], [Fecha], [VentaTotal], [Descuento], [SubTotal], [Igv], [Total], [Estado], [idCliente], [idEmpleado], [idTipoComprobante]) VALUES (3026, N'001', N'00000003026', CAST(N'2024-02-21T16:37:04.000' AS DateTime), CAST(42.70 AS Decimal(8, 2)), CAST(2.00 AS Decimal(8, 2)), CAST(40.70 AS Decimal(8, 2)), CAST(6.10 AS Decimal(8, 2)), CAST(46.80 AS Decimal(8, 2)), N'Normal', 2, 1, 1)
INSERT [dbo].[ventas] ([IdVenta], [Serie], [Numero], [Fecha], [VentaTotal], [Descuento], [SubTotal], [Igv], [Total], [Estado], [idCliente], [idEmpleado], [idTipoComprobante]) VALUES (3028, N'001', N'00000003027', CAST(N'2024-02-21T16:57:51.000' AS DateTime), CAST(39.20 AS Decimal(8, 2)), CAST(2.00 AS Decimal(8, 2)), CAST(37.20 AS Decimal(8, 2)), CAST(5.60 AS Decimal(8, 2)), CAST(42.80 AS Decimal(8, 2)), N'Normal', 6, 1, 1)
INSERT [dbo].[ventas] ([IdVenta], [Serie], [Numero], [Fecha], [VentaTotal], [Descuento], [SubTotal], [Igv], [Total], [Estado], [idCliente], [idEmpleado], [idTipoComprobante]) VALUES (3029, N'001', N'00000003029', CAST(N'2024-02-21T16:58:30.000' AS DateTime), CAST(39.20 AS Decimal(8, 2)), CAST(2.00 AS Decimal(8, 2)), CAST(37.20 AS Decimal(8, 2)), CAST(5.60 AS Decimal(8, 2)), CAST(42.80 AS Decimal(8, 2)), N'Normal', 6, 1, 3)
INSERT [dbo].[ventas] ([IdVenta], [Serie], [Numero], [Fecha], [VentaTotal], [Descuento], [SubTotal], [Igv], [Total], [Estado], [idCliente], [idEmpleado], [idTipoComprobante]) VALUES (3030, N'001', N'00000003030', CAST(N'2024-02-21T20:14:50.000' AS DateTime), CAST(41.60 AS Decimal(8, 2)), CAST(2.00 AS Decimal(8, 2)), CAST(39.60 AS Decimal(8, 2)), CAST(5.90 AS Decimal(8, 2)), CAST(45.50 AS Decimal(8, 2)), N'Normal', 1, 1, 1)
SET IDENTITY_INSERT [dbo].[ventas] OFF
GO
ALTER TABLE [dbo].[compra]  WITH CHECK ADD  CONSTRAINT [FK_compra_empleado] FOREIGN KEY([idEmpleado])
REFERENCES [dbo].[empleado] ([idEmpleado])
GO
ALTER TABLE [dbo].[compra] CHECK CONSTRAINT [FK_compra_empleado]
GO
ALTER TABLE [dbo].[compra]  WITH CHECK ADD  CONSTRAINT [FK_compra_proveedor] FOREIGN KEY([idProveedor])
REFERENCES [dbo].[proveedor] ([IdProveedor])
GO
ALTER TABLE [dbo].[compra] CHECK CONSTRAINT [FK_compra_proveedor]
GO
ALTER TABLE [dbo].[compra]  WITH CHECK ADD  CONSTRAINT [FK_compra_tipocomprobante] FOREIGN KEY([idTipoComprobante])
REFERENCES [dbo].[tipocomprobante] ([idTipoComprobante])
GO
ALTER TABLE [dbo].[compra] CHECK CONSTRAINT [FK_compra_tipocomprobante]
GO
ALTER TABLE [dbo].[detallecompra]  WITH CHECK ADD  CONSTRAINT [FK_detallecompra_compra] FOREIGN KEY([idCompra])
REFERENCES [dbo].[compra] ([idCompra])
GO
ALTER TABLE [dbo].[detallecompra] CHECK CONSTRAINT [FK_detallecompra_compra]
GO
ALTER TABLE [dbo].[detallecompra]  WITH CHECK ADD  CONSTRAINT [FK_detallecompra_producto] FOREIGN KEY([idProducto])
REFERENCES [dbo].[producto] ([idProducto])
GO
ALTER TABLE [dbo].[detallecompra] CHECK CONSTRAINT [FK_detallecompra_producto]
GO
ALTER TABLE [dbo].[detalleventa]  WITH CHECK ADD  CONSTRAINT [FK_detalleventa_producto] FOREIGN KEY([idProducto])
REFERENCES [dbo].[producto] ([idProducto])
GO
ALTER TABLE [dbo].[detalleventa] CHECK CONSTRAINT [FK_detalleventa_producto]
GO
ALTER TABLE [dbo].[detalleventa]  WITH CHECK ADD  CONSTRAINT [FK_detalleventa_ventas] FOREIGN KEY([IdVenta])
REFERENCES [dbo].[ventas] ([IdVenta])
GO
ALTER TABLE [dbo].[detalleventa] CHECK CONSTRAINT [FK_detalleventa_ventas]
GO
ALTER TABLE [dbo].[empleado]  WITH CHECK ADD  CONSTRAINT [FK_empleado_usuario] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[empleado] CHECK CONSTRAINT [FK_empleado_usuario]
GO
ALTER TABLE [dbo].[producto]  WITH CHECK ADD  CONSTRAINT [FK_producto_laboratorio] FOREIGN KEY([idLaboratorio])
REFERENCES [dbo].[laboratorio] ([idLaboratorio])
GO
ALTER TABLE [dbo].[producto] CHECK CONSTRAINT [FK_producto_laboratorio]
GO
ALTER TABLE [dbo].[producto]  WITH CHECK ADD  CONSTRAINT [FK_producto_presentacion] FOREIGN KEY([idPresentacion])
REFERENCES [dbo].[presentacion] ([idPresentacion])
GO
ALTER TABLE [dbo].[producto] CHECK CONSTRAINT [FK_producto_presentacion]
GO
ALTER TABLE [dbo].[ventas]  WITH CHECK ADD  CONSTRAINT [FK_ventas_cliente] FOREIGN KEY([idCliente])
REFERENCES [dbo].[cliente] ([idCliente])
GO
ALTER TABLE [dbo].[ventas] CHECK CONSTRAINT [FK_ventas_cliente]
GO
ALTER TABLE [dbo].[ventas]  WITH CHECK ADD  CONSTRAINT [FK_ventas_empleado] FOREIGN KEY([idEmpleado])
REFERENCES [dbo].[empleado] ([idEmpleado])
GO
ALTER TABLE [dbo].[ventas] CHECK CONSTRAINT [FK_ventas_empleado]
GO
ALTER TABLE [dbo].[ventas]  WITH CHECK ADD  CONSTRAINT [FK_ventas_tipocomprobante] FOREIGN KEY([idTipoComprobante])
REFERENCES [dbo].[tipocomprobante] ([idTipoComprobante])
GO
ALTER TABLE [dbo].[ventas] CHECK CONSTRAINT [FK_ventas_tipocomprobante]
GO
/****** Object:  StoredProcedure [dbo].[ActualizarCompraEstado]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarCompraEstado]
    @idcompra INT,
    @estado VARCHAR(10)
AS
BEGIN
    UPDATE compra
    SET Estado = @estado
    WHERE idCompra = @idcompra;
END;
GO
/****** Object:  StoredProcedure [dbo].[ActualizarVentaEstado]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ActualizarVentaEstado]
  @idventa INT,
    @estado VARCHAR(10)
AS
BEGIN
    UPDATE ventas
    SET Estado = @estado
    WHERE IdVenta = @idventa;
END;
GO
/****** Object:  StoredProcedure [dbo].[listarProveedor]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[listarProveedor]
as
select *from proveedor order by Nombre asc
GO
/****** Object:  StoredProcedure [dbo].[listarUsuario]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[listarUsuario]
as
select *from usuario order by idUsuario asc
GO
/****** Object:  StoredProcedure [dbo].[ObtenerDatosPorRangoFecha1]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ObtenerDatosPorRangoFecha1]
    @FechaInicio DATETIME,
    @FechaFin DATETIME
AS
BEGIN
    SELECT
        c.idCompra,
        p.Nombre AS Proveedor,
        c.Fecha,
        e.Nombres AS Empleado,
        tc.Descripcion AS Comprobante,
        c.Numero,
        c.Estado,
        c.Total
    FROM
        compra c
    INNER JOIN
        proveedor p ON c.idProveedor = p.IdProveedor
    INNER JOIN
        empleado e ON c.idEmpleado = e.idEmpleado
    INNER JOIN
        tipocomprobante tc ON c.idTipoComprobante = tc.idTipoComprobante
    WHERE
        c.Fecha BETWEEN @FechaInicio AND @FechaFin
		 GROUP BY
        c.idCompra,
        p.Nombre,
        c.Fecha,
        e.Nombres,
        tc.Descripcion,
        c.Numero,
        c.Estado,
		c.Total;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_ReporteCompras]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_ReporteCompras](
 @fechainicio varchar(10),
 @fechafin varchar(10),
 @idproveedor int
 )
  as
 begin
SELECT        dbo.compra.Fecha, dbo.tipocomprobante.Descripcion AS TipoDocumento, dbo.compra.Numero AS NumeroDocumento, dbo.compra.Total, dbo.usuario.TipoUsuario AS UsuarioRegistro, 
                         dbo.proveedor.IdProveedor AS DocumentoProveedor, dbo.proveedor.Nombre AS RazonSocial, dbo.producto.Codigo_Barras, dbo.producto.Descripcion, dbo.producto.Concentracion, dbo.producto.Stock, dbo.detallecompra.Costo, 
                         dbo.detallecompra.Cantidad, dbo.detallecompra.Importe
FROM            dbo.compra INNER JOIN
                         dbo.tipocomprobante ON dbo.compra.idTipoComprobante = dbo.tipocomprobante.idTipoComprobante INNER JOIN
                         dbo.empleado ON dbo.compra.idEmpleado = dbo.empleado.idEmpleado INNER JOIN
                         dbo.proveedor ON dbo.compra.idProveedor = dbo.proveedor.IdProveedor INNER JOIN
                         dbo.detallecompra ON dbo.compra.idCompra = dbo.detallecompra.idCompra INNER JOIN
                         dbo.producto ON dbo.detallecompra.idProducto = dbo.producto.idProducto INNER JOIN
                         dbo.usuario ON dbo.empleado.idUsuario = dbo.usuario.idUsuario
WHERE 
    CONVERT(date, compra.Fecha) BETWEEN @fechainicio AND @fechafin
    AND (@idproveedor = 0 OR proveedor.IdProveedor = @idproveedor)
 end

GO
/****** Object:  StoredProcedure [dbo].[sp_ReporteVentas]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_ReporteVentas](
 @fechainicio varchar(10),
 @fechafin varchar(10)
 )
 as
 begin
SELECT        dbo.ventas.Fecha, dbo.tipocomprobante.Descripcion AS TipoDocumento, dbo.ventas.Numero AS NumeroDocumento, dbo.ventas.Total, dbo.usuario.TipoUsuario AS UsuarioRegistro, dbo.cliente.idCliente AS DocumentoCliente, 
                         dbo.cliente.Nombres AS [Nombre Cliente], dbo.producto.Codigo_Barras, dbo.producto.Descripcion, dbo.producto.Concentracion, dbo.detalleventa.Precio, dbo.detalleventa.Cantidad, dbo.detalleventa.Importe
FROM            dbo.ventas INNER JOIN
                         dbo.tipocomprobante ON dbo.ventas.idTipoComprobante = dbo.tipocomprobante.idTipoComprobante INNER JOIN
                         dbo.empleado ON dbo.ventas.idEmpleado = dbo.empleado.idEmpleado INNER JOIN
                         dbo.cliente ON dbo.ventas.idCliente = dbo.cliente.idCliente INNER JOIN
                         dbo.detalleventa ON dbo.ventas.IdVenta = dbo.detalleventa.IdVenta INNER JOIN
                         dbo.producto ON dbo.detalleventa.idProducto = dbo.producto.idProducto INNER JOIN
                         dbo.usuario ON dbo.empleado.idUsuario = dbo.usuario.idUsuario
WHERE CONVERT(date, dbo.ventas.Fecha, 103) BETWEEN CONVERT(date, @fechainicio, 103) AND CONVERT(date, @fechafin, 103)
end;
GO
/****** Object:  StoredProcedure [dbo].[UltimoIdCompra]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UltimoIdCompra]
AS
BEGIN
    SELECT MAX(idCompra) AS id FROM compra;
END;
GO
/****** Object:  StoredProcedure [dbo].[USP_buscarcliente_obtener]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Cliente_Obtener
Create procedure [dbo].[USP_buscarcliente_obtener]
as 
select idCliente as ID, Nombres, Apellidos,Dni,Ruc,Direccion
from cliente
GO
/****** Object:  StoredProcedure [dbo].[USP_buscarcliente1]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[USP_buscarcliente1]
@Busqueda varchar(100)
as 
begin
select idCliente as ID, Nombres, Apellidos,Dni,Ruc,Direccion
from cliente
WHERE dbo.cliente.idCliente like '%' +@Busqueda+ '%' or
	 dbo.cliente.Nombres like '%' +@Busqueda+ '%' or
	 dbo.cliente.Apellidos like '%' +@Busqueda+ '%' or
	 dbo.cliente.Dni like '%' +@Busqueda+ '%' or
	 dbo.cliente.Ruc like '%' +@Busqueda+ '%' or
	 dbo.cliente.Direccion like '%' +@Busqueda+ '%';
	 END;
GO
/****** Object:  StoredProcedure [dbo].[USP_buscarcomprobante_obtener]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[USP_buscarcomprobante_obtener]
as
SELECT        idTipoComprobante AS Id, Descripcion, Estado
FROM            dbo.tipocomprobante
GO
/****** Object:  StoredProcedure [dbo].[USP_buscarcomprobantecompra_obtener]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[USP_buscarcomprobantecompra_obtener]
as
SELECT        idTipoComprobante AS Id, Descripcion, Estado
FROM            dbo.tipocomprobante
GO
/****** Object:  StoredProcedure [dbo].[USP_buscarempleado_obtener]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[USP_buscarempleado_obtener]
as
SELECT        idEmpleado AS Id, Nombres, Apellidos, Dni, Email
FROM            dbo.empleado
GO
/****** Object:  StoredProcedure [dbo].[USP_buscarproductoscompras_obtener]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[USP_buscarproductoscompras_obtener]
as
SELECT dbo.producto.idProducto AS ID, dbo.producto.Codigo_Barras, dbo.presentacion.Descripcion AS Presentacion, dbo.producto.Descripcion, dbo.producto.Concentracion, dbo.producto.Stock, dbo.producto.Costo, dbo.producto.idPresentacion, dbo.producto.idLaboratorio
FROM   dbo.producto INNER JOIN
             dbo.presentacion ON dbo.producto.idPresentacion = dbo.presentacion.idPresentacion
GO
/****** Object:  StoredProcedure [dbo].[USP_buscarproductoscompras1]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[USP_buscarproductoscompras1]
@Busqueda varchar(100)
as
begin
SELECT dbo.producto.idProducto AS ID, dbo.producto.Codigo_Barras, dbo.presentacion.Descripcion AS Presentacion, dbo.producto.Descripcion, dbo.producto.Concentracion, dbo.producto.Stock, dbo.producto.Costo, dbo.producto.idPresentacion, dbo.producto.idLaboratorio
FROM   dbo.producto INNER JOIN
             dbo.presentacion ON dbo.producto.idPresentacion = dbo.presentacion.idPresentacion
 WHERE dbo.producto.idProducto like '%' +@Busqueda+ '%' or
	 dbo.producto.Codigo_Barras like '%' +@Busqueda+ '%' or
	 dbo.presentacion.Descripcion like '%' +@Busqueda+ '%' or
	 dbo.producto.Descripcion like '%' +@Busqueda+ '%' or
	 dbo.producto.Concentracion like '%' +@Busqueda+ '%' or
	 dbo.producto.Stock like '%' +@Busqueda+ '%' or
	 dbo.producto.Costo like '%' +@Busqueda+ '%';
	 END;
GO
/****** Object:  StoredProcedure [dbo].[USP_buscarproductosventas_obtener]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[USP_buscarproductosventas_obtener]
as
SELECT        dbo.producto.idProducto AS ID, dbo.producto.Codigo_Barras, dbo.presentacion.Descripcion AS Presentacion, dbo.producto.Descripcion, dbo.producto.Concentracion, dbo.producto.Stock, dbo.producto.Costo,dbo.producto.Precio_Venta as Venta, dbo.producto.idPresentacion, dbo.producto.idLaboratorio
FROM            dbo.producto INNER JOIN
                         dbo.presentacion ON dbo.producto.idPresentacion = dbo.presentacion.idPresentacion
GO
/****** Object:  StoredProcedure [dbo].[USP_buscarproductosventas1]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[USP_buscarproductosventas1]
@Busqueda varchar(100)
as
begin
SELECT        dbo.producto.idProducto AS ID, dbo.producto.Codigo_Barras, dbo.presentacion.Descripcion AS Presentacion, dbo.producto.Descripcion, dbo.producto.Concentracion, dbo.producto.Stock, dbo.producto.Costo,dbo.producto.Precio_Venta as Venta, dbo.producto.idPresentacion, dbo.producto.idLaboratorio
FROM            dbo.producto INNER JOIN
                         dbo.presentacion ON dbo.producto.idPresentacion = dbo.presentacion.idPresentacion
WHERE dbo.producto.idProducto like '%' +@Busqueda+ '%' or
	 dbo.producto.Codigo_Barras like '%' +@Busqueda+ '%' or
	 dbo.presentacion.Descripcion like '%' +@Busqueda+ '%' or
	 dbo.producto.Descripcion like '%' +@Busqueda+ '%' or
	 dbo.producto.Concentracion like '%' +@Busqueda+ '%' or
	 dbo.producto.Stock like '%' +@Busqueda+ '%';
	 END;
GO
/****** Object:  StoredProcedure [dbo].[USP_buscarproveedor_obtener]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[USP_buscarproveedor_obtener]
as
SELECT        IdProveedor AS Id, Nombre, Ruc
FROM            dbo.proveedor

	
GO
/****** Object:  StoredProcedure [dbo].[USP_buscarproveedor1]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[USP_buscarproveedor1]
@Busqueda varchar(100)
as
Begin
SELECT        IdProveedor AS Id, Nombre, Ruc
FROM            dbo.proveedor
 WHERE dbo.proveedor.IdProveedor like '%' +@Busqueda+ '%' or
	 dbo.proveedor.Nombre like '%' +@Busqueda+ '%' or
	 dbo.proveedor.Ruc like '%' +@Busqueda+ '%';
	 END;
GO
/****** Object:  StoredProcedure [dbo].[USP_Cliente_Buscar]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

---------------------------------------

---Cliente_Buscar
CREATE PROCEDURE [dbo].[USP_Cliente_Buscar]
  @Busqueda varchar (100)
AS
BEGIN
    SELECT idCliente as Codigo,Nombres,Apellidos,Sexo,Dni,Telefono,Ruc,Email,Direccion
    FROM cliente
    WHERE Nombres like '%' +@Busqueda+ '%' or
	     Apellidos like '%' +@Busqueda+ '%' or
	     Sexo like '%' +@Busqueda+ '%' or
	     Dni like '%' +@Busqueda+ '%' or
	    Telefono like '%' +@Busqueda+ '%' or
	    Ruc like '%' +@Busqueda+ '%' or
	 Email like '%' +@Busqueda+ '%' or
	 Direccion like '%' +@Busqueda+ '%';
END;
GO
/****** Object:  StoredProcedure [dbo].[USP_Cliente_Delete]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-----------------------------------

  --Cliente_Delete
CREATE procedure [dbo].[USP_Cliente_Delete]
  @idCliente int
  AS
BEGIN
	delete from cliente 
	where idCliente= @idCliente
END
GO
/****** Object:  StoredProcedure [dbo].[USP_Cliente_insert]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------------------

--Cliente_Insertar
CREATE procedure [dbo].[USP_Cliente_insert]  
(  
 @Nombres varchar (35),
 @Apellidos varchar(35),
 @Sexo varchar(2),
 @Dni  varchar(10),
 @Telefono varchar(15),
 @Ruc varchar(20),
 @Email varchar(35),
 @Direccion varchar(50)
 )  
 as  
 begin 
  
  insert into cliente(Nombres,Apellidos,Sexo,Dni,Telefono,Ruc,Email,Direccion)
  values (@Nombres,@Apellidos,@Sexo,@Dni,@Telefono,@Ruc,@Email,@Direccion)
 
end
GO
/****** Object:  StoredProcedure [dbo].[USP_Cliente_obtener]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Cliente_Obtener
CREATE procedure [dbo].[USP_Cliente_obtener]
as 
select idCliente as Codigo, Nombres, Apellidos,Sexo,Dni,Telefono,Ruc,Email,Direccion
from cliente
GO
/****** Object:  StoredProcedure [dbo].[USP_Cliente_Update]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------------------

--Cliente_Update
CREATE procedure [dbo].[USP_Cliente_Update]
 (
  @idCliente int,
  @Nombres varchar (35),
  @Apellidos varchar(35),
  @Sexo varchar(2),
  @Dni  varchar(10),
  @Telefono varchar(15),
  @Ruc varchar(20),
  @Email varchar(35),
  @Direccion varchar(50)
  )
as
begin

		update cliente set 
		Nombres = @Nombres,
		Apellidos=@Apellidos,
		Sexo=@Sexo,
		Dni=@Dni,
		Telefono=@Telefono,
		Ruc=@Ruc,
		Email=@Email,
		Direccion=@Direccion
		
		
		where idCliente = @idCliente


end
GO
/****** Object:  StoredProcedure [dbo].[USP_CodEmpleado]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[USP_CodEmpleado]
	-- Add the parameters for the stored procedure here
	@coduser int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select idEmpleado from empleado
where idUsuario=@coduser
END
GO
/****** Object:  StoredProcedure [dbo].[USP_Compra_Buscar]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

---------------------------------------

---Compra_Buscar
CREATE PROCEDURE [dbo].[USP_Compra_Buscar]
 @Busqueda varchar (100)
AS
BEGIN
    SELECT idCompra as Codigo,Numero,Fecha,TipoPago,SubTotal,Total,Igv,Estado,idProveedor as Proveedor,idEmpleado as Empleado,idTipoComprobante as Tipo_Comprobante
    FROM Compra
    WHERE Numero like '%' +@Busqueda+ '%' or
	      Fecha like '%' +@Busqueda+ '%' or
	     TipoPago like '%' +@Busqueda+ '%' or
	      SubTotal like '%' +@Busqueda+ '%' or
	     Total like '%' +@Busqueda+ '%' or
	     Igv like '%' +@Busqueda+ '%' or
	    Estado like '%' +@Busqueda+ '%' or
	    idProveedor like '%' +@Busqueda+ '%' or
	    idEmpleado like '%' +@Busqueda+ '%' or
	    idTipoComprobante like '%' +@Busqueda+ '%';
END;
GO
/****** Object:  StoredProcedure [dbo].[USP_Compra_Delete]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-----------------------------------

  --Compra_Delete
CREATE procedure [dbo].[USP_Compra_Delete]
  @idCompra int
  AS
BEGIN
	delete from Compra 
	where idCompra= @idCompra
END
GO
/****** Object:  StoredProcedure [dbo].[USP_Compra_insert]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------------------

--Compra_Insertar
CREATE procedure [dbo].[USP_Compra_insert]  
(  
 @Numero varchar (15),
 @Fecha datetime,
 @TipoPago varchar(30),
 @SubTotal decimal(8, 2),
 @Total decimal(8, 2),
 @Igv decimal(8, 2),
 @Estado varchar(10),
 @idProveedor int,
 @idEmpleado int,
 @idTipoComprobante int
 )  
 as  
 begin 
  
  insert into Compra(Numero,Fecha,TipoPago,SubTotal,Total,Igv,Estado,idProveedor,idEmpleado,idTipoComprobante)
  values (@Numero,@Fecha,@TipoPago,@SubTotal,@Total,@Igv,@Estado,@idProveedor,@idEmpleado,@idTipoComprobante)
 
end
GO
/****** Object:  StoredProcedure [dbo].[USP_Compra_obtener]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-----------------------------------------------------

--Compra_Obtener
CREATE procedure [dbo].[USP_Compra_obtener]
as
SELECT        dbo.compra.idCompra as Codigo, dbo.compra.Numero, dbo.compra.Fecha, dbo.compra.TipoPago, dbo.compra.SubTotal, dbo.compra.Total, dbo.compra.Igv, dbo.compra.Estado, dbo.compra.idProveedor as Proveedor, dbo.proveedor.Nombre, 
                         dbo.compra.idEmpleado as Empleado, dbo.empleado.Nombres, dbo.compra.idTipoComprobante as Tipo_Comprobante, dbo.tipocomprobante.Descripcion
FROM            dbo.compra INNER JOIN
                         dbo.proveedor ON dbo.compra.idProveedor = dbo.proveedor.IdProveedor INNER JOIN
                         dbo.empleado ON dbo.compra.idEmpleado = dbo.empleado.idEmpleado INNER JOIN
                         dbo.tipocomprobante ON dbo.compra.idTipoComprobante = dbo.tipocomprobante.idTipoComprobante
GO
/****** Object:  StoredProcedure [dbo].[USP_Compra_Update]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------------------

--Compra_Update
CREATE procedure [dbo].[USP_Compra_Update]
 (
 @idCompra int,
 @Numero varchar (15),
 @Fecha datetime,
 @TipoPago varchar(30),
 @SubTotal decimal(8, 2),
 @Total decimal(8, 2),
 @Igv decimal(8, 2),
 @Estado varchar(10),
 @idProveedor int,
 @idEmpleado int,
 @idTipoComprobante int
  )
as
begin

		update Compra set 
		Numero = @Numero,
		Fecha=@Fecha,
		TipoPago=@TipoPago,
		SubTotal=@SubTotal,
		Total=@Total,
		Igv=@Igv,
		Estado=@Estado,
		idProveedor=@idProveedor,
		idEmpleado=@idEmpleado,
		idTipoComprobante=@idTipoComprobante
		
		
		where idCompra = @idCompra


end
GO
/****** Object:  StoredProcedure [dbo].[USP_ConsultaClientes_obtener]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[USP_ConsultaClientes_obtener]
as
SELECT        idCliente AS Codigo, Nombres, Apellidos, Sexo, Dni, Telefono, Ruc, Email, Direccion
FROM            dbo.cliente
GO
/****** Object:  StoredProcedure [dbo].[USP_ConsultaCompra_obtener]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[USP_ConsultaCompra_obtener]
as
SELECT        idCompra AS Codigo, idProveedor AS Proveedor, Fecha, idEmpleado AS Empleado, idTipoComprobante AS Comprobante, Numero, Estado, Total
FROM            dbo.compra
GO
/****** Object:  StoredProcedure [dbo].[USP_ConsultaEmpleados_obtener]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[USP_ConsultaEmpleados_obtener]
as
SELECT        idEmpleado AS Codigo, Nombres, Apellidos, Especialidad, Sexo, Dni, Email, Telefono, Direccion, HoraIngreso AS Ingreso, HoraSalida AS Salida, Sueldo
FROM            dbo.empleado
GO
/****** Object:  StoredProcedure [dbo].[USP_ConsultaProductos_obtener]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[USP_ConsultaProductos_obtener]
as
SELECT        idProducto AS Codigo, idPresentacion AS Presentacion, Descripcion, Concentracion, Stock, Costo, Precio_Venta AS Venta, FechaVencimiento AS Vencimiento, RegistroSanitario AS Registro_Sanitario, 
                         idLaboratorio AS Laboratorio, Estado
FROM            dbo.producto
GO
/****** Object:  StoredProcedure [dbo].[USP_ConsultaProveedores_obtener]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[USP_ConsultaProveedores_obtener]
as
SELECT        IdProveedor AS Codigo, Nombre, Dni, Ruc, Direccion, Email, Telefono, Banco, Cuenta, Estado
FROM            dbo.proveedor
GO
/****** Object:  StoredProcedure [dbo].[USP_ConsultaVentas_obtener]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[USP_ConsultaVentas_obtener]
as
SELECT        IdVenta AS Codigo, idCliente AS Cliente, Fecha, idEmpleado AS Empleado, idTipoComprobante AS Documento, Serie, Numero, Estado, Total
FROM            dbo.ventas
GO
/****** Object:  StoredProcedure [dbo].[USP_detallecompra_Buscar]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

---------------------------------------

---detallecompra_Buscar
CREATE PROCEDURE [dbo].[USP_detallecompra_Buscar]
@Busqueda varchar(100)
AS
BEGIN
    SELECT idDetalleCompra as Codigo,idCompra as Compra,idProducto as Producto,Cantidad,Costo,Importe
    FROM detallecompra
    WHERE idCompra like '%' +@Busqueda+ '%' or
	      idProducto like '%' +@Busqueda+ '%' or
	      Cantidad like '%' +@Busqueda+ '%' or
	      Costo like '%' +@Busqueda+ '%' or
	     Importe like '%' +@Busqueda+ '%';
END;
GO
/****** Object:  StoredProcedure [dbo].[USP_detallecompra_Delete]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-----------------------------------

  --detallecompra_Delete
CREATE procedure [dbo].[USP_detallecompra_Delete]
  @idDetalleCompra int
  AS
BEGIN
	delete from detallecompra 
	where idDetalleCompra= @idDetalleCompra
END
GO
/****** Object:  StoredProcedure [dbo].[USP_detallecompra_insert]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------------------

--detallecompra_Insertar
CREATE procedure [dbo].[USP_detallecompra_insert]  
(  
 @idCompra int,
 @idProducto int,
 @Cantidad int,
 @Costo decimal(8, 2),
 @Importe decimal(8, 2)
 )  
 as  
 begin 
  
  insert into detallecompra(idCompra,idProducto,Cantidad,Costo,Importe )
  values (@idCompra,@idProducto,@Cantidad,@Costo,@Importe)
 
end
GO
/****** Object:  StoredProcedure [dbo].[USP_detallecompra_obtener]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-----------------------------------------------------

--detallecompra_Obtener
CREATE procedure [dbo].[USP_detallecompra_obtener]
as
SELECT       dbo.detallecompra.idDetalleCompra as Codigo, dbo.detallecompra.idCompra, dbo.detallecompra.idProducto, dbo.producto.Descripcion, dbo.detallecompra.Cantidad, dbo.detallecompra.Costo, dbo.detallecompra.Importe
FROM            dbo.detallecompra INNER JOIN
                         dbo.producto ON dbo.detallecompra.idProducto = dbo.producto.idProducto
GO
/****** Object:  StoredProcedure [dbo].[USP_detallecompra_Update]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------------------

--detallecompra_Update
CREATE procedure [dbo].[USP_detallecompra_Update]
 (
 @idDetalleCompra int,
 @idCompra int,
 @idProducto int,
 @Cantidad int,
 @Costo decimal(8, 2),
 @Importe decimal(8, 2)
  )
as
begin

		update detallecompra set 
		idCompra = @idCompra,
		idProducto = @idProducto,
		Cantidad=@Cantidad,
		Costo=@Costo,
		Importe=@Importe		
		
		where idDetalleCompra = @idDetalleCompra


end
GO
/****** Object:  StoredProcedure [dbo].[USP_detalleventa_Buscar]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

---------------------------------------

---detalleventa_Buscar
CREATE PROCEDURE [dbo].[USP_detalleventa_Buscar]
@Busqueda varchar(100)
AS
BEGIN
    SELECT idDetalleVenta as Codigo,IdVenta as Venta,idProducto as Producto,Cantidad,Costo,Precio,Importe
    FROM detalleventa
    WHERE 
	IdVenta like '%' +@Busqueda+ '%' or
    idProducto like '%' +@Busqueda+ '%' or
    Cantidad like '%' +@Busqueda+ '%' or
	Costo like '%' +@Busqueda+ '%' or
	Precio like '%' +@Busqueda+ '%' or
	Importe like '%' +@Busqueda+ '%';
END;
GO
/****** Object:  StoredProcedure [dbo].[USP_detalleventa_Delete]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-----------------------------------

  --detalleventa_Delete
CREATE procedure [dbo].[USP_detalleventa_Delete]
  @idDetalleVenta int
  AS
BEGIN
	delete from detalleventa 
	where idDetalleVenta= @idDetalleVenta
END
GO
/****** Object:  StoredProcedure [dbo].[USP_detalleventa_insert]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------------------

--detalleventa_Insertar
CREATE procedure [dbo].[USP_detalleventa_insert]  
(  
 @IdVenta int,
 @idProducto int,
 @Cantidad int,
 @Costo decimal(8, 2),
 @Precio decimal(8, 2),
 @Importe decimal(8, 2)
 )  
 as  
 begin 
  
  insert into detalleventa(IdVenta,idProducto,Cantidad,Costo,Precio,Importe )
  values (@IdVenta,@idProducto,@Cantidad,@Costo,@Precio,@Importe)
 
end
GO
/****** Object:  StoredProcedure [dbo].[USP_detalleventa_obtener]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-----------------------------------------------------

--detalleventa_Obtener
CREATE procedure [dbo].[USP_detalleventa_obtener]
as
SELECT       dbo.detalleventa.idDetalleVenta as Codigo, dbo.detalleventa.IdVenta as Venta, dbo.detalleventa.idProducto as Producto, dbo.producto.Descripcion, dbo.detalleventa.Cantidad, dbo.detalleventa.Costo, dbo.detalleventa.Precio, dbo.detalleventa.Importe
FROM            dbo.detalleventa INNER JOIN
                         dbo.producto ON dbo.detalleventa.idProducto = dbo.producto.idProducto
GO
/****** Object:  StoredProcedure [dbo].[USP_detalleventa_Update]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------------------

--detalleventa_Update
CREATE procedure [dbo].[USP_detalleventa_Update]
 (
 @idDetalleVenta int,
 @idVenta int,
 @idProducto int,
 @Cantidad int,
 @Costo decimal(8, 2),
 @Precio decimal(8, 2),
 @Importe decimal(8, 2)
  )
as
begin

		update detalleventa set 
		IdVenta = @idVenta,
		idProducto = @idProducto,
		Cantidad=@Cantidad,
		Costo=@Costo,
		Precio=@Precio,
		Importe=@Importe		
		
		where idDetalleVenta = @idDetalleVenta


end
GO
/****** Object:  StoredProcedure [dbo].[USP_empleado_Buscar]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

---------------------------------------

---empleado_Buscar
CREATE PROCEDURE [dbo].[USP_empleado_Buscar]
 @Busqueda varchar(100)
AS
BEGIN
    SELECT idEmpleado as Codigo, Nombres,Apellidos,Especialidad,Sexo,Dni,Email,Telefono,Direccion,HoraIngreso,HoraSalida,Sueldo,Estado
    FROM empleado
    WHERE Nombres like '%' +@Busqueda+ '%' or
	      Apellidos like '%' +@Busqueda+ '%' or
	      Especialidad like '%' +@Busqueda+ '%' or
	      Sexo like '%' +@Busqueda+ '%' or
	      Dni like '%' +@Busqueda+ '%' or
	     Email like '%' +@Busqueda+ '%' or
	     Telefono like '%' +@Busqueda+ '%' or
	     Direccion like '%' +@Busqueda+ '%' or
	     HoraIngreso like '%' +@Busqueda+ '%' or
	    HoraSalida like '%' +@Busqueda+ '%' or
	    Sueldo like '%' +@Busqueda+ '%' or
	    Estado like '%' +@Busqueda+ '%';
	   
END;
GO
/****** Object:  StoredProcedure [dbo].[USP_empleado_Delete]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-----------------------------------

  --empleado_Delete
CREATE procedure [dbo].[USP_empleado_Delete]
  @idEmpleado int
  AS
BEGIN
	delete from empleado 
	where idEmpleado= @idEmpleado
END
GO
/****** Object:  StoredProcedure [dbo].[USP_empleado_insert]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------------------

--empleado_Insertar
CREATE procedure [dbo].[USP_empleado_insert]  
(  
 @Nombres varchar(35),
 @Apellidos varchar(35),
 @Especialidad varchar(30),
 @Sexo varchar(2),
 @Dni int,
 @Email varchar(30),
 @Telefono int,
 @Direccion varchar(35),
 @HoraIngreso varchar(15),
 @HoraSalida varchar(15),
 @Sueldo decimal(8, 2),
 @Estado varchar(10),
 @idUsuario int
 )  
 as  
 begin 
  
  insert into empleado(Nombres,Apellidos,Especialidad,Sexo,Dni,Email,Telefono,Direccion,HoraIngreso,HoraSalida,Sueldo,Estado,idUsuario )
  values (@Nombres,@Apellidos,@Especialidad,@Sexo,@Dni,@Email,@Telefono,@Direccion,@HoraIngreso,@HoraSalida,@Sueldo,@Estado,@idUsuario)
 
end
GO
/****** Object:  StoredProcedure [dbo].[USP_empleado_obtener]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-----------------------------------------------------

--empleado_Obtener
CREATE procedure [dbo].[USP_empleado_obtener]
as
SELECT        dbo.empleado.idEmpleado as Codigo, dbo.empleado.Nombres, dbo.empleado.Apellidos, dbo.empleado.Especialidad, dbo.empleado.Sexo, dbo.empleado.Dni, dbo.empleado.Email, dbo.empleado.Telefono, dbo.empleado.Direccion, 
                         dbo.empleado.HoraIngreso, dbo.empleado.HoraSalida, dbo.empleado.Sueldo,Estado,idUsuario
FROM            dbo.empleado 

GO
/****** Object:  StoredProcedure [dbo].[USP_empleado_Update]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------------------

--empleado_Update
CREATE procedure [dbo].[USP_empleado_Update]
 (
 @idEmpleado int,
 @Nombres varchar(35),
 @Apellidos varchar(35),
 @Especialidad varchar(30),
 @Sexo varchar(2),
 @Dni int,
 @Email varchar(30),
 @Telefono int,
 @Direccion varchar(35),
 @HoraIngreso varchar(15),
 @HoraSalida varchar(15),
 @Sueldo decimal(8, 2),
 @Estado varchar(10),
 @idUsuario int
  )
as
begin

		update empleado set 
		Nombres = @Nombres,
		Apellidos=@Apellidos,
		Especialidad=@Especialidad,
		Sexo=@Sexo,
		Dni=@Dni,
		Email=@Email,
		Telefono=@Telefono,
		Direccion=@Direccion,
		HoraIngreso=@HoraIngreso,
		HoraSalida=@HoraSalida,
		Sueldo=@Sueldo,
		Estado=@Estado,
		idUsuario=@idUsuario
		
		where idEmpleado = @idEmpleado


end
GO
/****** Object:  StoredProcedure [dbo].[USP_GananciaCaja]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE procedure [dbo].[USP_GananciaCaja]
	-- Add the parameters for the stored procedure here
	@fechafin datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT        dbo.detalleventa.Cantidad, dbo.producto.Descripcion AS Producto, dbo.detalleventa.Precio, dbo.detalleventa.Importe AS SubTotal, dbo.ventas.Total AS TotalPagar, 
                         SUM(ROUND(dbo.detalleventa.Importe - dbo.detalleventa.Costo * dbo.detalleventa.Cantidad, 2)) AS Ganancia, dbo.ventas.Fecha
FROM            dbo.ventas INNER JOIN
                         dbo.detalleventa ON dbo.ventas.IdVenta = dbo.detalleventa.IdVenta INNER JOIN
                         dbo.producto ON dbo.detalleventa.idProducto = dbo.producto.idProducto
WHERE        (dbo.ventas.Fecha >= @fechafin)
GROUP BY dbo.detalleventa.Cantidad, dbo.detalleventa.idProducto, dbo.producto.Descripcion, dbo.detalleventa.Precio, dbo.detalleventa.Costo, dbo.detalleventa.Importe, dbo.ventas.Fecha, dbo.ventas.Total

END
GO
/****** Object:  StoredProcedure [dbo].[USP_GananciaTotalVenta]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_GananciaTotalVenta]
@fechaini datetime,
	@fechafin datetime
as
begin
SELECT dbo.producto.idProducto,
       dbo.producto.Descripcion AS Producto,
       dbo.presentacion.Descripcion AS Presentacion,
       dbo.detalleventa.Costo,
       dbo.detalleventa.Precio,
       dbo.detalleventa.Cantidad AS Cantidad,
       SUM(dbo.detalleventa.Importe) AS Total,
       SUM(ROUND((Importe - (dbo.detalleventa.Costo * dbo.detalleventa.Cantidad)), 2)) AS Ganancia
FROM ventas
INNER JOIN detalleventa ON dbo.ventas.IdVenta = dbo.detalleventa.IdVenta
INNER JOIN producto ON detalleventa.idProducto = producto.idProducto
INNER JOIN presentacion ON dbo.producto.idPresentacion = dbo.presentacion.idPresentacion
WHERE dbo.ventas.Fecha between @fechaini AND @fechafin -- Cambia esta fecha por el rango deseado
GROUP BY 
dbo.producto.IdProducto, 
dbo.producto.Descripcion, 
dbo.presentacion.Descripcion, 
dbo.detalleventa.Costo, 
dbo.detalleventa.Precio,
dbo.detalleventa.Cantidad

END;
GO
/****** Object:  StoredProcedure [dbo].[USP_laboratorio_Buscar]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

---------------------------------------

---laboratorio_Buscar
CREATE PROCEDURE [dbo].[USP_laboratorio_Buscar]
@Busqueda varchar(100)
AS
BEGIN
    SELECT  idLaboratorio as Codigo,Nombre,Direccion,Telefono,Estado
    FROM laboratorio
    WHERE Nombre like '%' +@Busqueda+ '%' or
	  Direccion like '%' +@Busqueda+ '%' or
	  Telefono like '%' +@Busqueda+ '%' or
	  Estado like '%' +@Busqueda+ '%';
END;
GO
/****** Object:  StoredProcedure [dbo].[USP_laboratorio_Delete]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-----------------------------------

  --laboratorio_Delete
CREATE procedure [dbo].[USP_laboratorio_Delete]
  @idLaboratorio int
  AS
BEGIN
	delete from laboratorio 
	where idLaboratorio= @idLaboratorio
END
GO
/****** Object:  StoredProcedure [dbo].[USP_laboratorio_insert]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------------------

--laboratorio_Insertar
CREATE procedure [dbo].[USP_laboratorio_insert]  
(  
 @Nombre varchar(35),
 @Direccion varchar(35),
 @Telefono int,
 @Estado varchar(10)
 )  
 as  
 begin 
  
  insert into laboratorio(Nombre,Direccion,Telefono,Estado)
  values (@Nombre,@Direccion,@Telefono,@Estado)
 
end
GO
/****** Object:  StoredProcedure [dbo].[USP_laboratorio_obtener]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-----------------------------------------------------

--laboratorio_Obtener
CREATE procedure [dbo].[USP_laboratorio_obtener]
as
SELECT        idLaboratorio as Codigo, Nombre, Direccion, Telefono, Estado
FROM            dbo.laboratorio
GO
/****** Object:  StoredProcedure [dbo].[USP_laboratorio_Update]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------------------

--laboratorio_Update
CREATE procedure [dbo].[USP_laboratorio_Update]
 (
 @idLaboratorio int,
 @Nombre varchar(35),
 @Direccion varchar(35),
 @Telefono int,
 @Estado varchar(10)
  )
as
begin

		update laboratorio set 
		Nombre = @Nombre,
		Direccion=@Direccion,
		Telefono=@Telefono,
		Estado=@Estado
		
		where idlaboratorio = @idlaboratorio


end
GO
/****** Object:  StoredProcedure [dbo].[USP_presentacion_Buscar]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

---------------------------------------

---presentacion_Buscar
CREATE PROCEDURE [dbo].[USP_presentacion_Buscar]
@Busqueda varchar(100)
AS
BEGIN
    SELECT idPresentacion as Codigo,Descripcion,Estado
    FROM presentacion
    WHERE Descripcion like '%' +@Busqueda+ '%' or
	  Estado like '%' +@Busqueda+ '%';
END;
GO
/****** Object:  StoredProcedure [dbo].[USP_presentacion_Delete]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-----------------------------------

  --presentacion_Delete
CREATE procedure [dbo].[USP_presentacion_Delete]
  @idPresentacion int
  AS
BEGIN
	delete from presentacion 
	where idPresentacion= @idPresentacion
END
GO
/****** Object:  StoredProcedure [dbo].[USP_presentacion_insert]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------------------

--presentacion_Insertar
CREATE procedure [dbo].[USP_presentacion_insert]  
(  
 @Descripcion varchar(35),
 @Estado varchar(30)
 )  
 as  
 begin 
  
  insert into presentacion(Descripcion,Estado)
  values (@Descripcion,@Estado)
 
end
GO
/****** Object:  StoredProcedure [dbo].[USP_presentacion_obtener]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-----------------------------------------------------

--presentacion_Obtener
CREATE procedure [dbo].[USP_presentacion_obtener]
as
SELECT        idPresentacion as Codigo, Descripcion, Estado
FROM            dbo.presentacion
GO
/****** Object:  StoredProcedure [dbo].[USP_presentacion_Update]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------------------

--presentacion_Update
CREATE procedure [dbo].[USP_presentacion_Update]
 (
 @idPresentacion int,
 @Descripcion varchar(35),
 @Estado varchar(30)
  )
as
begin

		update presentacion set 
		Descripcion = @Descripcion,
		Estado=@Estado
		
		where idPresentacion = @idPresentacion


end
GO
/****** Object:  StoredProcedure [dbo].[USP_producto_Buscar]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

---------------------------------------

---producto_Buscar
CREATE PROCEDURE [dbo].[USP_producto_Buscar]
@Busqueda varchar(100)
AS
BEGIN
SELECT        dbo.producto.idProducto as Codigo, dbo.producto.Codigo_Barras, dbo.presentacion.Descripcion AS presentacion, dbo.producto.Descripcion, dbo.producto.Concentracion, dbo.producto.Stock, dbo.producto.Costo, dbo.producto.Precio_Venta, 
                         dbo.producto.FechaVencimiento, dbo.producto.RegistroSanitario, dbo.laboratorio.Nombre AS Laboratorio, dbo.producto.Estado
FROM            dbo.producto INNER JOIN
                         dbo.presentacion ON dbo.producto.idPresentacion = dbo.presentacion.idPresentacion INNER JOIN
                         dbo.laboratorio ON dbo.producto.idLaboratorio = dbo.laboratorio.idLaboratorio
    WHERE dbo.producto.Codigo_Barras like '%' +@Busqueda+ '%' or
	 dbo.producto.Descripcion like '%' +@Busqueda+ '%' or
	 Concentracion like '%' +@Busqueda+ '%' or
	 Stock like '%' +@Busqueda+ '%' or
	 Costo like '%' +@Busqueda+ '%' or
	 Precio_Venta like '%' +@Busqueda+ '%' or
	 RegistroSanitario like '%' +@Busqueda+ '%' or
	 FechaVencimiento  like '%' +@Busqueda+ '%' or
	 dbo.producto.Estado like '%' +@Busqueda+ '%' or
	 dbo.presentacion.Descripcion like '%' +@Busqueda+ '%' or
	 dbo.laboratorio.Nombre like '%' +@Busqueda+ '%';
END;
GO
/****** Object:  StoredProcedure [dbo].[USP_producto_Delete]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-----------------------------------

  --producto_Delete
CREATE procedure [dbo].[USP_producto_Delete]
  @idProducto int
  AS
BEGIN
	delete from producto 
	where idProducto= @idProducto
END
GO
/****** Object:  StoredProcedure [dbo].[USP_producto_insert]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------------------

--producto_Insertar
CREATE procedure [dbo].[USP_producto_insert]  
(  
 @Codigo_Barras varchar(13),
 @Descripcion varchar(35),
 @Concentracion varchar(30),
 @Stock decimal(8, 2),
 @Costo decimal(8, 2),
 @Precio_Venta decimal(8, 2),
 @RegistroSanitario varchar(20),
 @FechaVencimiento datetime,
 @Estado varchar(10),
 @idPresentacion int,
 @idLaboratorio int
 )  
 as  
 begin 
  
  insert into producto(Codigo_Barras,Descripcion,Concentracion,Stock,Costo,Precio_Venta,RegistroSanitario,FechaVencimiento,Estado,idPresentacion,idLaboratorio)
  values (@Codigo_Barras,@Descripcion,@Concentracion,@Stock,@Costo,@Precio_Venta,@RegistroSanitario,@FechaVencimiento,@Estado,@idPresentacion,@idLaboratorio)
 
end
GO
/****** Object:  StoredProcedure [dbo].[USP_producto_obtener]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-----------------------------------------------------

--producto_Obtener
CREATE procedure [dbo].[USP_producto_obtener]
as
SELECT        dbo.producto.idProducto as Codigo,dbo.producto.Codigo_Barras, dbo.presentacion.Descripcion AS presentacion, dbo.producto.Descripcion, dbo.producto.Concentracion, dbo.producto.Stock, dbo.producto.Costo, dbo.producto.Precio_Venta, 
                         dbo.producto.FechaVencimiento, dbo.producto.RegistroSanitario, dbo.laboratorio.Nombre AS Laboratorio, dbo.producto.Estado
FROM            dbo.producto INNER JOIN
                         dbo.presentacion ON dbo.producto.idPresentacion = dbo.presentacion.idPresentacion INNER JOIN
                         dbo.laboratorio ON dbo.producto.idLaboratorio = dbo.laboratorio.idLaboratorio
GO
/****** Object:  StoredProcedure [dbo].[USP_producto_Update]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------------------

--producto_Update
CREATE procedure [dbo].[USP_producto_Update]
 (
 @idProducto int,
 @Codigo_Barras varchar(13),
 @Descripcion varchar(35),
 @Concentracion varchar(30),
 @Stock decimal(8, 2),
 @Costo decimal(8, 2),
 @Precio_Venta decimal(8, 2),
 @RegistroSanitario varchar(20),
 @FechaVencimiento datetime,
 @Estado varchar(10),
 @idPresentacion int,
 @idLaboratorio int
  )
as
begin

		update producto set 
		Codigo_Barras = @Codigo_Barras,
		Descripcion = @Descripcion,
		Concentracion=@Concentracion,
		Stock=@Stock,
		Costo=@Costo,
		Precio_Venta=@Precio_Venta,
		RegistroSanitario=@RegistroSanitario,
		FechaVencimiento=@FechaVencimiento,
		Estado=@Estado,
		idPresentacion=@idPresentacion,
		idLaboratorio=@idLaboratorio

		where idProducto = @idProducto


end
GO
/****** Object:  StoredProcedure [dbo].[USP_proveedor_Buscar]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

---------------------------------------

---proveedor_Buscar
CREATE PROCEDURE [dbo].[USP_proveedor_Buscar]
@Busqueda varchar(100)
AS
BEGIN
    SELECT IdProveedor as Codigo, Nombre,Dni,Ruc,Direccion,Email,Telefono,Banco,Cuenta,Estado
    FROM proveedor
    WHERE Nombre like '%' +@Busqueda+ '%' or
	 Dni like '%' +@Busqueda+ '%' or
	 Ruc like '%' +@Busqueda+ '%' or
	 Direccion like '%' +@Busqueda+ '%' or
	 Email like '%' +@Busqueda+ '%' or
	 Telefono like '%' +@Busqueda+ '%' or
	 Banco like '%' +@Busqueda+ '%' or
	 Cuenta like '%' +@Busqueda+ '%' or
	 Estado like '%' +@Busqueda+ '%';
END;
GO
/****** Object:  StoredProcedure [dbo].[USP_proveedor_Delete]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-----------------------------------

  --proveedor_Delete
CREATE procedure [dbo].[USP_proveedor_Delete]
  @idProveedor int
  AS
BEGIN
	delete from proveedor 
	where idProveedor= @idProveedor
END
GO
/****** Object:  StoredProcedure [dbo].[USP_proveedor_insert]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------------------

--proveedor_Insertar
CREATE procedure [dbo].[USP_proveedor_insert]  
(  
 @Nombre varchar(35),
 @Dni varchar(11),
 @Ruc varchar(20),
 @Direccion varchar(35),
 @Email varchar(35),
 @Telefono varchar(20),
 @Banco varchar(35),
 @Cuenta varchar(35),
 @Estado varchar(10)
 )  
 as  
 begin 
  
  insert into proveedor(Nombre,Dni,Ruc,Direccion,Email,Telefono,Banco,Cuenta,Estado)
  values (@Nombre,@Dni,@Ruc,@Direccion,@Email,@Telefono,@Banco,@Cuenta,@Estado)
 
end
GO
/****** Object:  StoredProcedure [dbo].[USP_proveedor_obtener]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-----------------------------------------------------

--proveedor_Obtener
CREATE procedure [dbo].[USP_proveedor_obtener]
as
SELECT        IdProveedor as codigo, Nombre, Dni, Ruc, Direccion, Email, Telefono, Banco, Cuenta, Estado
FROM            dbo.proveedor
GO
/****** Object:  StoredProcedure [dbo].[USP_proveedor_Update]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------------------

--proveedor_Update
CREATE procedure [dbo].[USP_proveedor_Update]
 (
 @idProveedor int,
 @Nombre varchar(35),
 @Dni varchar(11),
 @Ruc varchar(20),
 @Direccion varchar(35),
 @Email varchar(35),
 @Telefono varchar(20),
 @Banco varchar(35),
 @Cuenta varchar(35),
 @Estado varchar(10)
  )
as
begin

		update proveedor set 
		Nombre = @Nombre,
		Dni=@Dni,
		Ruc=@Ruc,
		Direccion=@Direccion,
		Email=@Email,
		Telefono=@Telefono,
		Banco=@Banco,
		Cuenta=@Cuenta,
		Estado=@Estado

		where idProveedor = @idProveedor


end
GO
/****** Object:  StoredProcedure [dbo].[USP_tipocomprobante_Buscar]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

---------------------------------------

---tipocomprobante_Buscar
CREATE PROCEDURE [dbo].[USP_tipocomprobante_Buscar]
@Busqueda varchar(100)
AS
BEGIN
    SELECT idTipoComprobante as TipoComprobante,Descripcion,Estado
    FROM tipocomprobante
    WHERE Descripcion like '%' +@Busqueda+ '%' or
	 Estado like '%' +@Busqueda+ '%';
END;
GO
/****** Object:  StoredProcedure [dbo].[USP_tipocomprobante_Delete]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-----------------------------------

  --tipocomprobante_Delete
CREATE procedure [dbo].[USP_tipocomprobante_Delete]
  @idTipocomprobante int
  AS
BEGIN
	delete from tipocomprobante 
	where idTipoComprobante= @idTipocomprobante
END
GO
/****** Object:  StoredProcedure [dbo].[USP_tipocomprobante_insert]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------------------

--tipocomprobante_Insertar
CREATE procedure [dbo].[USP_tipocomprobante_insert]  
(  
 @Descripcion varchar(35),
 @Estado varchar(10)
 )  
 as  
 begin 
  
  insert into tipocomprobante(Descripcion,Estado)
  values (@Descripcion,@Estado)
 
end
GO
/****** Object:  StoredProcedure [dbo].[USP_tipocomprobante_obtener]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-----------------------------------------------------

--tipocomprobante_Obtener
CREATE procedure [dbo].[USP_tipocomprobante_obtener]
as
SELECT        idTipoComprobante as Codigo, Descripcion, Estado
FROM            dbo.tipocomprobante
GO
/****** Object:  StoredProcedure [dbo].[USP_tipocomprobante_Update]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------------------

--tipocomprobante_Update
CREATE procedure [dbo].[USP_tipocomprobante_Update]
 (
 @idTipocomprobante int,
 @Descripcion varchar(35),
 @Estado varchar(10)
  )
as
begin

		update tipocomprobante set 
		Descripcion = @Descripcion,
		Estado=@Estado
		
		where idTipoComprobante = @idTipocomprobante


end
GO
/****** Object:  StoredProcedure [dbo].[USP_UltimoNumeroCliente]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_UltimoNumeroCliente]
AS
BEGIN
    SELECT MAX(IdVenta) AS codigo FROM ventas;
END;
GO
/****** Object:  StoredProcedure [dbo].[USP_UltimoNumeroCompra]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[USP_UltimoNumeroCompra] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT max(idCompra) as Codigo from compra
END

GO
/****** Object:  StoredProcedure [dbo].[USP_usuario_Buscar]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

---------------------------------------

---usuario_Buscar
CREATE PROCEDURE [dbo].[USP_usuario_Buscar]
@Busqueda varchar(100)
AS
BEGIN
    SELECT idUsuario as Codigo,Nombres,Apellidos,Dni,Email,Usuario,Contraseña,TipoUsuario,Estado
    FROM usuario
    WHERE Nombres like '%' +@Busqueda+ '%' or
	 Apellidos like '%' +@Busqueda+ '%' or
	 Dni like '%' +@Busqueda+ '%' or
	 Email like '%' +@Busqueda+ '%' or
	 Usuario like '%' +@Busqueda+ '%' or
	 Contraseña like '%' +@Busqueda+ '%' or
	 TipoUsuario like '%' +@Busqueda+ '%' or
	 Estado like '%' +@Busqueda+ '%';
END;
GO
/****** Object:  StoredProcedure [dbo].[USP_usuario_Delete]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-----------------------------------

  --usuario_Delete
CREATE procedure [dbo].[USP_usuario_Delete]
  @idUsuario int
  AS
BEGIN
	delete from usuario 
	where idUsuario= @idUsuario
END
GO
/****** Object:  StoredProcedure [dbo].[USP_usuario_insert]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------------------

--usuario_Insertar
CREATE procedure [dbo].[USP_usuario_insert]  
(  
 @Nombres varchar(35),
 @Apellidos varchar(35),
 @Dni int,
 @Email varchar(35),
 @Usuario varchar(30),
 @Contraseña varchar(30),
 @TipoUsuario varchar(20),
 @Estado varchar(10)
 )  
 as  
 begin 
  
  insert into usuario(Nombres,Apellidos,Dni,Email,Usuario,Contraseña,TipoUsuario,Estado)
  values (@Nombres,@Apellidos,@Dni,@Email,@Usuario,@Contraseña,@TipoUsuario,@Estado)
 
end
GO
/****** Object:  StoredProcedure [dbo].[USP_usuario_obtener]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-----------------------------------------------------

--usuario_Obtener
CREATE procedure [dbo].[USP_usuario_obtener]
as
SELECT        idUsuario as Codigo, Nombres, Apellidos, Dni, Email, Usuario, Contraseña, TipoUsuario, Estado
FROM            dbo.usuario
GO
/****** Object:  StoredProcedure [dbo].[USP_usuario_Update]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------------------

--usuario_Update
CREATE procedure [dbo].[USP_usuario_Update]
 (
 @idUsuario int,
 @Nombres varchar(35),
 @Apellidos varchar(35),
 @Dni int,
 @Email varchar(35),
 @Usuario varchar(30),
 @Contraseña varchar(30),
 @TipoUsuario varchar(20),
 @Estado varchar(10)
  )
as
begin

		update usuario set 
		Nombres = @Nombres,
		Apellidos=@Apellidos,
		Dni=@Dni,
		Email=@Email,
		Usuario=@Usuario,
		Contraseña=@Contraseña,
		TipoUsuario=@TipoUsuario,
		Estado=@Estado

		where idUsuario = @idUsuario


end
GO
/****** Object:  StoredProcedure [dbo].[USP_ventas_Buscar]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

---------------------------------------

---ventas_Buscar
CREATE PROCEDURE [dbo].[USP_ventas_Buscar]
@Busqueda varchar(100)
AS
BEGIN
    SELECT IdVenta as Codigo,Serie,Numero,Fecha,VentaTotal,Descuento,SubTotal,Igv,Total,Estado,idCliente as Cliente,idEmpleado as Empleado,idTipoComprobante as TipoComprobante
    FROM ventas
    WHERE Serie like '%' +@Busqueda+ '%' or
	 Numero like '%' +@Busqueda+ '%' or
	 Fecha like '%' +@Busqueda+ '%' or
	 VentaTotal like '%' +@Busqueda+ '%' or
	 Descuento like '%' +@Busqueda+ '%' or
	 SubTotal like '%' +@Busqueda+ '%' or
	 Igv like '%' +@Busqueda+ '%' or
	 Total like '%' +@Busqueda+ '%' or
	 Estado like '%' +@Busqueda+ '%' or
	 idCliente like '%' +@Busqueda+ '%' or
	 idEmpleado like '%' +@Busqueda+ '%' or
	 idTipoComprobante like '%' +@Busqueda+ '%';
END;
GO
/****** Object:  StoredProcedure [dbo].[USP_ventas_Delete]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-----------------------------------

  --ventas_Delete
CREATE procedure [dbo].[USP_ventas_Delete]
  @IdVenta int
  AS
BEGIN
	delete from ventas 
	where IdVenta= @IdVenta
END
GO
/****** Object:  StoredProcedure [dbo].[USP_ventas_insert]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------------------

--ventas_Insertar
CREATE procedure [dbo].[USP_ventas_insert]  
(  
 @Serie varchar(10),
 @Numero varchar(20),
 @Fecha datetime,
 @VentaTotal decimal(8, 2),
 @Descuento decimal(8, 2),
 @SubTotal decimal(8, 2),
 @Igv decimal(8, 2),
 @Total decimal(8, 2),
 @Estado varchar(10),
 @idCliente int,
 @idEmpleado int,
 @idTipoComprobante int
 )  
 as  
 begin 
  
  insert into ventas(Serie,Numero,Fecha,VentaTotal,Descuento,SubTotal,Igv,Total,Estado,idCliente,idEmpleado,idTipoComprobante)
  values (@Serie,@Numero,@Fecha,@VentaTotal,@Descuento,@SubTotal,@Igv,@Total,@Estado,@idCliente,@idEmpleado,@idTipoComprobante)
 
end
GO
/****** Object:  StoredProcedure [dbo].[USP_ventas_obtener]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-----------------------------------------------------

--ventas_Obtener
CREATE procedure [dbo].[USP_ventas_obtener]
as
SELECT        dbo.ventas.IdVenta as Codigo, dbo.ventas.Serie, dbo.ventas.Numero, dbo.ventas.Fecha, dbo.ventas.VentaTotal, dbo.ventas.Descuento, dbo.ventas.SubTotal, dbo.ventas.Igv, dbo.ventas.Total, dbo.ventas.Estado, dbo.ventas.idCliente as Cliente, 
                         dbo.cliente.Nombres, dbo.ventas.idEmpleado as Empleado, dbo.empleado.Nombres AS NombreEmpleado, dbo.ventas.idTipoComprobante as TipoComprobante, dbo.tipocomprobante.Descripcion
FROM            dbo.ventas INNER JOIN
                         dbo.cliente ON dbo.ventas.idCliente = dbo.cliente.idCliente INNER JOIN
                         dbo.empleado ON dbo.ventas.idEmpleado = dbo.empleado.idEmpleado INNER JOIN
                         dbo.tipocomprobante ON dbo.ventas.idTipoComprobante = dbo.tipocomprobante.idTipoComprobante
GO
/****** Object:  StoredProcedure [dbo].[USP_ventas_Update]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------------------

--ventas_Update
CREATE procedure [dbo].[USP_ventas_Update]
 (
 @IdVenta int,
 @Serie varchar(10),
 @Numero varchar(20),
 @Fecha datetime,
 @VentaTotal decimal(8, 2),
 @Descuento decimal(8, 2),
 @SubTotal decimal(8, 2),
 @Igv decimal(8, 2),
 @Total decimal(8, 2),
 @Estado varchar(10),
 @idCliente int,
 @idEmpleado int,
 @idTipoComprobante int
  )
as
begin

		update ventas set 
		Serie = @Serie,
		Numero=@Numero,
		Fecha=@Fecha,
		VentaTotal=@VentaTotal,
		Descuento=@Descuento,
		SubTotal=@SubTotal,
		Igv=@Igv,
		Total=@Total,
		Estado=@Estado

		where IdVenta = @IdVenta


end
GO
/****** Object:  StoredProcedure [dbo].[VentasPorFecha]    Script Date: 22/02/2024 14:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[VentasPorFecha]
 @FechaInicio DATETIME,
    @FechaFin DATETIME
AS
BEGIN
    SELECT v.IdVenta, CONCAT(c.Nombres, c.Apellidos) AS cliente, v.Fecha, CONCAT(e.Nombres, e.Apellidos) AS empleado, td.Descripcion AS tipocomprobante, v.Serie, v.Numero, v.Estado, v.Total 
    FROM ventas AS v
    INNER JOIN tipocomprobante AS td ON v.idTipoComprobante = td.idTipoComprobante
    INNER JOIN cliente AS c ON v.idCliente = c.idCliente
    INNER JOIN empleado AS e ON v.idEmpleado = e.idEmpleado
    WHERE v.Fecha >= @FechaInicio AND v.Fecha <= @FechaFin
    ORDER BY v.IdVenta DESC;
	END;
GO
USE [master]
GO
ALTER DATABASE [FARMACIA] SET  READ_WRITE 
GO
