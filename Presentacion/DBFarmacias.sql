USE [master]
GO
/****** Object:  Database [FARMACIA]    Script Date: 23/02/2024 9:40:48 ******/
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
/****** Object:  Table [dbo].[cliente]    Script Date: 23/02/2024 9:40:48 ******/
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
/****** Object:  Table [dbo].[compra]    Script Date: 23/02/2024 9:40:48 ******/
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
/****** Object:  Table [dbo].[detallecompra]    Script Date: 23/02/2024 9:40:48 ******/
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
/****** Object:  Table [dbo].[detalleventa]    Script Date: 23/02/2024 9:40:48 ******/
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
/****** Object:  Table [dbo].[empleado]    Script Date: 23/02/2024 9:40:48 ******/
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
/****** Object:  Table [dbo].[laboratorio]    Script Date: 23/02/2024 9:40:48 ******/
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
/****** Object:  Table [dbo].[presentacion]    Script Date: 23/02/2024 9:40:48 ******/
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
/****** Object:  Table [dbo].[producto]    Script Date: 23/02/2024 9:40:48 ******/
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
	[FechaVencimiento] [date] NULL,
	[Estado] [varchar](10) NULL,
	[idPresentacion] [int] NULL,
	[idLaboratorio] [int] NULL,
 CONSTRAINT [PK_producto] PRIMARY KEY CLUSTERED 
(
	[idProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[proveedor]    Script Date: 23/02/2024 9:40:48 ******/
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
/****** Object:  Table [dbo].[tipocomprobante]    Script Date: 23/02/2024 9:40:48 ******/
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
/****** Object:  Table [dbo].[usuario]    Script Date: 23/02/2024 9:40:48 ******/
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
/****** Object:  Table [dbo].[ventas]    Script Date: 23/02/2024 9:40:48 ******/
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

INSERT [dbo].[cliente] ([idCliente], [Nombres], [Apellidos], [Sexo], [Dni], [Telefono], [Ruc], [Email], [Direccion]) VALUES (1, N'Juan', N'Perez', N'M', N'12345678', N'987654321', N'36554756534', N'juan@example.com', N'Av. Principal 123')
INSERT [dbo].[cliente] ([idCliente], [Nombres], [Apellidos], [Sexo], [Dni], [Telefono], [Ruc], [Email], [Direccion]) VALUES (2, N'Maria', N'Gomez', N'F', N'87654321', N'123456789', N'67654444233', N'maria@example.com', N'Calle Secundaria 456')
INSERT [dbo].[cliente] ([idCliente], [Nombres], [Apellidos], [Sexo], [Dni], [Telefono], [Ruc], [Email], [Direccion]) VALUES (3, N'Pedro', N'Diaz', N'M', N'98765432', N'789456123', N'65676534', N'pedro@example.com', N'Jr. Independencia 789')
INSERT [dbo].[cliente] ([idCliente], [Nombres], [Apellidos], [Sexo], [Dni], [Telefono], [Ruc], [Email], [Direccion]) VALUES (4, N'Ana', N'Lopez', N'F', N'45678901', N'456789123', NULL, N'ana@example.com', N'Av. Libertad 321')
INSERT [dbo].[cliente] ([idCliente], [Nombres], [Apellidos], [Sexo], [Dni], [Telefono], [Ruc], [Email], [Direccion]) VALUES (5, N'Carlos', N'Martinez', N'M', N'34567890', N'987123654', NULL, N'carlos@example.com', N'Calle Principal 789')
INSERT [dbo].[cliente] ([idCliente], [Nombres], [Apellidos], [Sexo], [Dni], [Telefono], [Ruc], [Email], [Direccion]) VALUES (6, N'Laura', N'Rodriguez', N'F', N'23456789', N'654321987', NULL, N'laura@example.com', N'Jr. Union 567')
INSERT [dbo].[cliente] ([idCliente], [Nombres], [Apellidos], [Sexo], [Dni], [Telefono], [Ruc], [Email], [Direccion]) VALUES (7, N'Jorge', N'Gonzalez', N'M', N'56789012', N'321987654', NULL, N'jorge@example.com', N'Av. Los Pinos 987')
INSERT [dbo].[cliente] ([idCliente], [Nombres], [Apellidos], [Sexo], [Dni], [Telefono], [Ruc], [Email], [Direccion]) VALUES (8, N'Sofia', N'Hernandez', N'F', N'67890123', N'147258369', NULL, N'sofia@example.com', N'Callejón de los Suspiros 123')
INSERT [dbo].[cliente] ([idCliente], [Nombres], [Apellidos], [Sexo], [Dni], [Telefono], [Ruc], [Email], [Direccion]) VALUES (9, N'Diego', N'Sanchez', N'M', N'78901234', N'258369147', NULL, N'diego@example.com', N'Pasaje Flores 456')
INSERT [dbo].[cliente] ([idCliente], [Nombres], [Apellidos], [Sexo], [Dni], [Telefono], [Ruc], [Email], [Direccion]) VALUES (10, N'Elena', N'Perez', N'F', N'89012345', N'369147258', NULL, N'elena@example.com', N'Av. San Martin 369')
SET IDENTITY_INSERT [dbo].[cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[compra] ON 

INSERT [dbo].[compra] ([idCompra], [Numero], [Fecha], [TipoPago], [SubTotal], [Total], [Igv], [Estado], [idProveedor], [idEmpleado], [idTipoComprobante]) VALUES (1, N'1', CAST(N'2024-02-22T20:19:44.000' AS DateTime), N'', CAST(43.00 AS Decimal(8, 2)), CAST(49.50 AS Decimal(8, 2)), CAST(6.50 AS Decimal(8, 2)), N'Normal', 2, 1, 2)
INSERT [dbo].[compra] ([idCompra], [Numero], [Fecha], [TipoPago], [SubTotal], [Total], [Igv], [Estado], [idProveedor], [idEmpleado], [idTipoComprobante]) VALUES (2, N'2', CAST(N'2024-02-22T20:24:52.000' AS DateTime), N'', CAST(20.00 AS Decimal(8, 2)), CAST(23.00 AS Decimal(8, 2)), CAST(3.00 AS Decimal(8, 2)), N'Normal', 5, 1, 1)
INSERT [dbo].[compra] ([idCompra], [Numero], [Fecha], [TipoPago], [SubTotal], [Total], [Igv], [Estado], [idProveedor], [idEmpleado], [idTipoComprobante]) VALUES (3, N'3', CAST(N'2024-02-22T20:30:37.000' AS DateTime), N'', CAST(46.00 AS Decimal(8, 2)), CAST(52.90 AS Decimal(8, 2)), CAST(6.90 AS Decimal(8, 2)), N'Normal', 3, 1, 2)
INSERT [dbo].[compra] ([idCompra], [Numero], [Fecha], [TipoPago], [SubTotal], [Total], [Igv], [Estado], [idProveedor], [idEmpleado], [idTipoComprobante]) VALUES (4, N'4', CAST(N'2024-02-23T08:03:47.000' AS DateTime), N'', CAST(28.40 AS Decimal(8, 2)), CAST(32.70 AS Decimal(8, 2)), CAST(4.30 AS Decimal(8, 2)), N'Normal', 3, 1, 2)
SET IDENTITY_INSERT [dbo].[compra] OFF
GO
SET IDENTITY_INSERT [dbo].[detallecompra] ON 

INSERT [dbo].[detallecompra] ([idDetalleCompra], [idCompra], [idProducto], [Cantidad], [Costo], [Importe]) VALUES (1, 1, 3, 4, CAST(4.50 AS Decimal(8, 2)), CAST(18.00 AS Decimal(8, 2)))
INSERT [dbo].[detallecompra] ([idDetalleCompra], [idCompra], [idProducto], [Cantidad], [Costo], [Importe]) VALUES (2, 1, 4, 5, CAST(5.00 AS Decimal(8, 2)), CAST(25.00 AS Decimal(8, 2)))
INSERT [dbo].[detallecompra] ([idDetalleCompra], [idCompra], [idProducto], [Cantidad], [Costo], [Importe]) VALUES (3, 2, 4, 4, CAST(5.00 AS Decimal(8, 2)), CAST(20.00 AS Decimal(8, 2)))
INSERT [dbo].[detallecompra] ([idDetalleCompra], [idCompra], [idProducto], [Cantidad], [Costo], [Importe]) VALUES (4, 3, 3, 3, CAST(4.50 AS Decimal(8, 2)), CAST(13.50 AS Decimal(8, 2)))
INSERT [dbo].[detallecompra] ([idDetalleCompra], [idCompra], [idProducto], [Cantidad], [Costo], [Importe]) VALUES (5, 3, 5, 5, CAST(6.50 AS Decimal(8, 2)), CAST(32.50 AS Decimal(8, 2)))
INSERT [dbo].[detallecompra] ([idDetalleCompra], [idCompra], [idProducto], [Cantidad], [Costo], [Importe]) VALUES (6, 4, 4, 4, CAST(5.00 AS Decimal(8, 2)), CAST(20.00 AS Decimal(8, 2)))
INSERT [dbo].[detallecompra] ([idDetalleCompra], [idCompra], [idProducto], [Cantidad], [Costo], [Importe]) VALUES (7, 4, 9, 3, CAST(2.80 AS Decimal(8, 2)), CAST(8.40 AS Decimal(8, 2)))
SET IDENTITY_INSERT [dbo].[detallecompra] OFF
GO
SET IDENTITY_INSERT [dbo].[detalleventa] ON 

INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (1, 1, 2, 4, CAST(3.00 AS Decimal(8, 2)), CAST(6.00 AS Decimal(8, 2)), CAST(24.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (2, 1, 2, 4, CAST(3.00 AS Decimal(8, 2)), CAST(6.00 AS Decimal(8, 2)), CAST(24.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (3, 1, 4, 6, CAST(5.00 AS Decimal(8, 2)), CAST(10.00 AS Decimal(8, 2)), CAST(60.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (4, 1, 4, 6, CAST(5.00 AS Decimal(8, 2)), CAST(10.00 AS Decimal(8, 2)), CAST(60.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (5, 2, 4, 3, CAST(5.00 AS Decimal(8, 2)), CAST(10.00 AS Decimal(8, 2)), CAST(30.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (6, 2, 4, 3, CAST(5.00 AS Decimal(8, 2)), CAST(10.00 AS Decimal(8, 2)), CAST(30.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (7, 2, 6, 2, CAST(7.80 AS Decimal(8, 2)), CAST(14.00 AS Decimal(8, 2)), CAST(28.00 AS Decimal(8, 2)))
INSERT [dbo].[detalleventa] ([idDetalleVenta], [IdVenta], [idProducto], [Cantidad], [Costo], [Precio], [Importe]) VALUES (8, 2, 6, 2, CAST(7.80 AS Decimal(8, 2)), CAST(14.00 AS Decimal(8, 2)), CAST(28.00 AS Decimal(8, 2)))
SET IDENTITY_INSERT [dbo].[detalleventa] OFF
GO
SET IDENTITY_INSERT [dbo].[empleado] ON 

INSERT [dbo].[empleado] ([idEmpleado], [Nombres], [Apellidos], [Especialidad], [Sexo], [Dni], [Email], [Telefono], [Direccion], [HoraIngreso], [HoraSalida], [Sueldo], [Estado], [idUsuario]) VALUES (1, N'Luis', N'Gonzalez', N'Farmacéutico', N'M', 12345678, N'luis@example.com', 987654321, N'Av. Principal 123', N'08:00', N'17:00', CAST(2500.00 AS Decimal(8, 2)), N'Activo', 1)
INSERT [dbo].[empleado] ([idEmpleado], [Nombres], [Apellidos], [Especialidad], [Sexo], [Dni], [Email], [Telefono], [Direccion], [HoraIngreso], [HoraSalida], [Sueldo], [Estado], [idUsuario]) VALUES (2, N'Ana', N'Martinez', N'Enfermera', N'F', 23456789, N'ana@example.com', 789456123, N'Calle Secundaria 456', N'07:30', N'16:30', CAST(2000.00 AS Decimal(8, 2)), N'Activo', NULL)
INSERT [dbo].[empleado] ([idEmpleado], [Nombres], [Apellidos], [Especialidad], [Sexo], [Dni], [Email], [Telefono], [Direccion], [HoraIngreso], [HoraSalida], [Sueldo], [Estado], [idUsuario]) VALUES (3, N'Carlos', N'Hernandez', N'Cajero', N'M', 34567890, N'carlos@example.com', 654321987, N'Jr. Independencia 789', N'09:00', N'18:00', CAST(1800.00 AS Decimal(8, 2)), N'Activo', NULL)
INSERT [dbo].[empleado] ([idEmpleado], [Nombres], [Apellidos], [Especialidad], [Sexo], [Dni], [Email], [Telefono], [Direccion], [HoraIngreso], [HoraSalida], [Sueldo], [Estado], [idUsuario]) VALUES (4, N'Laura', N'Gomez', N'Farmacéutico', N'F', 45678901, N'laura@example.com', 987123654, N'Av. Libertad 321', N'08:30', N'17:30', CAST(2600.00 AS Decimal(8, 2)), N'Activo', NULL)
INSERT [dbo].[empleado] ([idEmpleado], [Nombres], [Apellidos], [Especialidad], [Sexo], [Dni], [Email], [Telefono], [Direccion], [HoraIngreso], [HoraSalida], [Sueldo], [Estado], [idUsuario]) VALUES (5, N'Jorge', N'Lopez', N'Asistente de Ventas', N'M', 56789012, N'jorge@example.com', 456789123, N'Calle Principal 789', N'10:00', N'19:00', CAST(1700.00 AS Decimal(8, 2)), N'Activo', NULL)
INSERT [dbo].[empleado] ([idEmpleado], [Nombres], [Apellidos], [Especialidad], [Sexo], [Dni], [Email], [Telefono], [Direccion], [HoraIngreso], [HoraSalida], [Sueldo], [Estado], [idUsuario]) VALUES (6, N'Sofia', N'Rodriguez', N'Asistente de Almacén', N'F', 67890123, N'sofia@example.com', 321987654, N'Jr. Union 567', N'08:00', N'17:00', CAST(1800.00 AS Decimal(8, 2)), N'Activo', NULL)
INSERT [dbo].[empleado] ([idEmpleado], [Nombres], [Apellidos], [Especialidad], [Sexo], [Dni], [Email], [Telefono], [Direccion], [HoraIngreso], [HoraSalida], [Sueldo], [Estado], [idUsuario]) VALUES (7, N'Diego', N'Gonzalez', N'Enfermero', N'M', 78901234, N'diego@example.com', 147258369, N'Av. Los Pinos 987', N'07:00', N'16:00', CAST(2000.00 AS Decimal(8, 2)), N'Activo', NULL)
INSERT [dbo].[empleado] ([idEmpleado], [Nombres], [Apellidos], [Especialidad], [Sexo], [Dni], [Email], [Telefono], [Direccion], [HoraIngreso], [HoraSalida], [Sueldo], [Estado], [idUsuario]) VALUES (8, N'Elena', N'Sanchez', N'Recepcionista', N'F', 89012345, N'elena@example.com', 258369147, N'Callejón de los Suspiros 123', N'09:30', N'18:30', CAST(1900.00 AS Decimal(8, 2)), N'Activo', NULL)
INSERT [dbo].[empleado] ([idEmpleado], [Nombres], [Apellidos], [Especialidad], [Sexo], [Dni], [Email], [Telefono], [Direccion], [HoraIngreso], [HoraSalida], [Sueldo], [Estado], [idUsuario]) VALUES (9, N'Mario', N'Perez', N'Asistente Administrativo', N'M', 90123456, N'mario@example.com', 369147258, N'Pasaje Flores 456', N'08:00', N'17:00', CAST(2000.00 AS Decimal(8, 2)), N'Activo', NULL)
INSERT [dbo].[empleado] ([idEmpleado], [Nombres], [Apellidos], [Especialidad], [Sexo], [Dni], [Email], [Telefono], [Direccion], [HoraIngreso], [HoraSalida], [Sueldo], [Estado], [idUsuario]) VALUES (10, N'Carmen', N'Gutierrez', N'Farmacéutico', N'F', 98765432, N'carmen@example.com', 852369741, N'Av. San Martin 369', N'08:00', N'17:00', CAST(2500.00 AS Decimal(8, 2)), N'Activo', NULL)
SET IDENTITY_INSERT [dbo].[empleado] OFF
GO
SET IDENTITY_INSERT [dbo].[laboratorio] ON 

INSERT [dbo].[laboratorio] ([idLaboratorio], [Nombre], [Direccion], [Telefono], [Estado]) VALUES (1, N'Laboratorio ABC', N'Av. Principal 123', 987654321, N'Activo')
INSERT [dbo].[laboratorio] ([idLaboratorio], [Nombre], [Direccion], [Telefono], [Estado]) VALUES (2, N'Laboratorio XYZ', N'Calle Secundaria 456', 789456123, N'Activo')
INSERT [dbo].[laboratorio] ([idLaboratorio], [Nombre], [Direccion], [Telefono], [Estado]) VALUES (3, N'Laboratorio DEF', N'Jr. Independencia 789', 654321987, N'Activo')
INSERT [dbo].[laboratorio] ([idLaboratorio], [Nombre], [Direccion], [Telefono], [Estado]) VALUES (4, N'Laboratorio GHI', N'Av. Libertad 321', 987123654, N'Activo')
INSERT [dbo].[laboratorio] ([idLaboratorio], [Nombre], [Direccion], [Telefono], [Estado]) VALUES (5, N'Laboratorio JKL', N'Calle Principal 789', 456789123, N'Activo')
INSERT [dbo].[laboratorio] ([idLaboratorio], [Nombre], [Direccion], [Telefono], [Estado]) VALUES (6, N'Laboratorio MNO', N'Jr. Union 567', 321987654, N'Activo')
INSERT [dbo].[laboratorio] ([idLaboratorio], [Nombre], [Direccion], [Telefono], [Estado]) VALUES (7, N'Laboratorio PQR', N'Av. Los Pinos 987', 147258369, N'Activo')
INSERT [dbo].[laboratorio] ([idLaboratorio], [Nombre], [Direccion], [Telefono], [Estado]) VALUES (8, N'Laboratorio STU', N'Callejón de los Suspiros 123', 258369147, N'Activo')
INSERT [dbo].[laboratorio] ([idLaboratorio], [Nombre], [Direccion], [Telefono], [Estado]) VALUES (9, N'Laboratorio VWX', N'Pasaje Flores 456', 369147258, N'Activo')
INSERT [dbo].[laboratorio] ([idLaboratorio], [Nombre], [Direccion], [Telefono], [Estado]) VALUES (10, N'Laboratorio YZA', N'Av. San Martin 369', 852369741, N'Activo')
SET IDENTITY_INSERT [dbo].[laboratorio] OFF
GO
SET IDENTITY_INSERT [dbo].[presentacion] ON 

INSERT [dbo].[presentacion] ([idPresentacion], [Descripcion], [Estado]) VALUES (1, N'Tableta', N'Activo')
INSERT [dbo].[presentacion] ([idPresentacion], [Descripcion], [Estado]) VALUES (2, N'Cápsula', N'Activo')
INSERT [dbo].[presentacion] ([idPresentacion], [Descripcion], [Estado]) VALUES (3, N'Jarabe', N'Activo')
INSERT [dbo].[presentacion] ([idPresentacion], [Descripcion], [Estado]) VALUES (4, N'Ampolla', N'Activo')
INSERT [dbo].[presentacion] ([idPresentacion], [Descripcion], [Estado]) VALUES (5, N'Crema', N'Activo')
INSERT [dbo].[presentacion] ([idPresentacion], [Descripcion], [Estado]) VALUES (6, N'Gel', N'Activo')
INSERT [dbo].[presentacion] ([idPresentacion], [Descripcion], [Estado]) VALUES (7, N'Suspensión', N'Activo')
INSERT [dbo].[presentacion] ([idPresentacion], [Descripcion], [Estado]) VALUES (8, N'Inyectable', N'Activo')
INSERT [dbo].[presentacion] ([idPresentacion], [Descripcion], [Estado]) VALUES (9, N'Gotas', N'Activo')
INSERT [dbo].[presentacion] ([idPresentacion], [Descripcion], [Estado]) VALUES (10, N'Supositorio', N'Activo')
SET IDENTITY_INSERT [dbo].[presentacion] OFF
GO
SET IDENTITY_INSERT [dbo].[producto] ON 

INSERT [dbo].[producto] ([idProducto], [Codigo_Barras], [Descripcion], [Concentracion], [Stock], [Costo], [Precio_Venta], [RegistroSanitario], [FechaVencimiento], [Estado], [idPresentacion], [idLaboratorio]) VALUES (1, N'1234567890123', N'Paracetamol', N'500 mg', CAST(100.00 AS Decimal(8, 2)), CAST(2.50 AS Decimal(8, 2)), CAST(5.00 AS Decimal(8, 2)), N'123456', CAST(N'2025-01-01' AS Date), N'Activo', 1, 1)
INSERT [dbo].[producto] ([idProducto], [Codigo_Barras], [Descripcion], [Concentracion], [Stock], [Costo], [Precio_Venta], [RegistroSanitario], [FechaVencimiento], [Estado], [idPresentacion], [idLaboratorio]) VALUES (2, N'2345678901234', N'Ibuprofeno', N'400 mg', CAST(80.00 AS Decimal(8, 2)), CAST(3.00 AS Decimal(8, 2)), CAST(6.00 AS Decimal(8, 2)), N'234567', CAST(N'2024-12-31' AS Date), N'Activo', 1, 2)
INSERT [dbo].[producto] ([idProducto], [Codigo_Barras], [Descripcion], [Concentracion], [Stock], [Costo], [Precio_Venta], [RegistroSanitario], [FechaVencimiento], [Estado], [idPresentacion], [idLaboratorio]) VALUES (3, N'3456789012345', N'Omeprazol', N'20 mg', CAST(120.00 AS Decimal(8, 2)), CAST(4.50 AS Decimal(8, 2)), CAST(8.00 AS Decimal(8, 2)), N'345678', CAST(N'2024-11-30' AS Date), N'Activo', 1, 3)
INSERT [dbo].[producto] ([idProducto], [Codigo_Barras], [Descripcion], [Concentracion], [Stock], [Costo], [Precio_Venta], [RegistroSanitario], [FechaVencimiento], [Estado], [idPresentacion], [idLaboratorio]) VALUES (4, N'4567890123456', N'Amoxicilina', N'500 mg', CAST(90.00 AS Decimal(8, 2)), CAST(5.00 AS Decimal(8, 2)), CAST(10.00 AS Decimal(8, 2)), N'456789', CAST(N'2024-10-31' AS Date), N'Activo', 1, 4)
INSERT [dbo].[producto] ([idProducto], [Codigo_Barras], [Descripcion], [Concentracion], [Stock], [Costo], [Precio_Venta], [RegistroSanitario], [FechaVencimiento], [Estado], [idPresentacion], [idLaboratorio]) VALUES (5, N'5678901234567', N'Diazepam', N'10 mg', CAST(70.00 AS Decimal(8, 2)), CAST(6.50 AS Decimal(8, 2)), CAST(12.00 AS Decimal(8, 2)), N'567890', CAST(N'2024-09-30' AS Date), N'Activo', 1, 5)
INSERT [dbo].[producto] ([idProducto], [Codigo_Barras], [Descripcion], [Concentracion], [Stock], [Costo], [Precio_Venta], [RegistroSanitario], [FechaVencimiento], [Estado], [idPresentacion], [idLaboratorio]) VALUES (6, N'6789012345678', N'Ciprofloxacino', N'500 mg', CAST(110.00 AS Decimal(8, 2)), CAST(7.80 AS Decimal(8, 2)), CAST(14.00 AS Decimal(8, 2)), N'678901', CAST(N'2024-08-31' AS Date), N'Activo', 1, 6)
INSERT [dbo].[producto] ([idProducto], [Codigo_Barras], [Descripcion], [Concentracion], [Stock], [Costo], [Precio_Venta], [RegistroSanitario], [FechaVencimiento], [Estado], [idPresentacion], [idLaboratorio]) VALUES (7, N'7890123456789', N'Clonazepam', N'2 mg', CAST(60.00 AS Decimal(8, 2)), CAST(8.75 AS Decimal(8, 2)), CAST(16.00 AS Decimal(8, 2)), N'789012', CAST(N'2024-07-31' AS Date), N'Activo', 1, 7)
INSERT [dbo].[producto] ([idProducto], [Codigo_Barras], [Descripcion], [Concentracion], [Stock], [Costo], [Precio_Venta], [RegistroSanitario], [FechaVencimiento], [Estado], [idPresentacion], [idLaboratorio]) VALUES (8, N'8901234567890', N'Dipirona', N'500 mg', CAST(100.00 AS Decimal(8, 2)), CAST(3.20 AS Decimal(8, 2)), CAST(6.00 AS Decimal(8, 2)), N'890123', CAST(N'2024-06-30' AS Date), N'Activo', 1, 8)
INSERT [dbo].[producto] ([idProducto], [Codigo_Barras], [Descripcion], [Concentracion], [Stock], [Costo], [Precio_Venta], [RegistroSanitario], [FechaVencimiento], [Estado], [idPresentacion], [idLaboratorio]) VALUES (9, N'9012345678901', N'Furosemida', N'40 mg', CAST(75.00 AS Decimal(8, 2)), CAST(2.80 AS Decimal(8, 2)), CAST(5.50 AS Decimal(8, 2)), N'901234', CAST(N'2024-05-31' AS Date), N'Activo', 1, 9)
INSERT [dbo].[producto] ([idProducto], [Codigo_Barras], [Descripcion], [Concentracion], [Stock], [Costo], [Precio_Venta], [RegistroSanitario], [FechaVencimiento], [Estado], [idPresentacion], [idLaboratorio]) VALUES (10, N'0123456789012', N'Loratadina', N'10 mg', CAST(85.00 AS Decimal(8, 2)), CAST(4.20 AS Decimal(8, 2)), CAST(8.50 AS Decimal(8, 2)), N'012345', CAST(N'2024-04-30' AS Date), N'Activo', 1, 10)
SET IDENTITY_INSERT [dbo].[producto] OFF
GO
SET IDENTITY_INSERT [dbo].[proveedor] ON 

INSERT [dbo].[proveedor] ([IdProveedor], [Nombre], [Dni], [Ruc], [Direccion], [Email], [Telefono], [Banco], [Cuenta], [Estado]) VALUES (1, N'Distribuidora ABC', NULL, N'12345678901', N'Av. Principal 123', N'distribuidora@example.com', N'987654321', N'Banco X', N'1234567890123456', N'Activo')
INSERT [dbo].[proveedor] ([IdProveedor], [Nombre], [Dni], [Ruc], [Direccion], [Email], [Telefono], [Banco], [Cuenta], [Estado]) VALUES (2, N'Proveedor XYZ', NULL, N'23456789012', N'Calle Secundaria 456', N'proveedor@example.com', N'789456123', N'Banco Y', N'2345678901234567', N'Activo')
INSERT [dbo].[proveedor] ([IdProveedor], [Nombre], [Dni], [Ruc], [Direccion], [Email], [Telefono], [Banco], [Cuenta], [Estado]) VALUES (3, N'Importadora DEF', NULL, N'34567890123', N'Jr. Independencia 789', N'importadora@example.com', N'654321987', N'Banco Z', N'3456789012345678', N'Activo')
INSERT [dbo].[proveedor] ([IdProveedor], [Nombre], [Dni], [Ruc], [Direccion], [Email], [Telefono], [Banco], [Cuenta], [Estado]) VALUES (4, N'Mayorista GHI', NULL, N'45678901234', N'Av. Libertad 321', N'mayorista@example.com', N'987123654', N'Banco A', N'4567890123456789', N'Activo')
INSERT [dbo].[proveedor] ([IdProveedor], [Nombre], [Dni], [Ruc], [Direccion], [Email], [Telefono], [Banco], [Cuenta], [Estado]) VALUES (5, N'Farmaceutica JKL', NULL, N'56789012345', N'Calle Principal 789', N'farmaceutica@example.com', N'456789123', N'Banco B', N'5678901234567890', N'Activo')
INSERT [dbo].[proveedor] ([IdProveedor], [Nombre], [Dni], [Ruc], [Direccion], [Email], [Telefono], [Banco], [Cuenta], [Estado]) VALUES (6, N'Laboratorio MNO', NULL, N'67890123456', N'Jr. Union 567', N'laboratorio@example.com', N'321987654', N'Banco C', N'6789012345678901', N'Activo')
INSERT [dbo].[proveedor] ([IdProveedor], [Nombre], [Dni], [Ruc], [Direccion], [Email], [Telefono], [Banco], [Cuenta], [Estado]) VALUES (7, N'Proveedor PQR', NULL, N'78901234567', N'Av. Los Pinos 987', N'proveedor2@example.com', N'147258369', N'Banco D', N'7890123456789012', N'Activo')
INSERT [dbo].[proveedor] ([IdProveedor], [Nombre], [Dni], [Ruc], [Direccion], [Email], [Telefono], [Banco], [Cuenta], [Estado]) VALUES (8, N'Distribuidor STU', NULL, N'89012345678', N'Callejón de los Suspiros 123', N'distribuidor@example.com', N'258369147', N'Banco E', N'8901234567890123', N'Activo')
INSERT [dbo].[proveedor] ([IdProveedor], [Nombre], [Dni], [Ruc], [Direccion], [Email], [Telefono], [Banco], [Cuenta], [Estado]) VALUES (9, N'Mayorista VWX', NULL, N'90123456789', N'Pasaje Flores 456', N'mayorista2@example.com', N'369147258', N'Banco F', N'9012345678901234', N'Activo')
INSERT [dbo].[proveedor] ([IdProveedor], [Nombre], [Dni], [Ruc], [Direccion], [Email], [Telefono], [Banco], [Cuenta], [Estado]) VALUES (10, N'Farmaceutica YZA', NULL, N'01234567890', N'Av. San Martin 369', N'farmaceutica2@example.com', N'852369741', N'Banco G', N'0123456789012345', N'Activo')
SET IDENTITY_INSERT [dbo].[proveedor] OFF
GO
SET IDENTITY_INSERT [dbo].[tipocomprobante] ON 

INSERT [dbo].[tipocomprobante] ([idTipoComprobante], [Descripcion], [Estado]) VALUES (1, N'Boleta', N'Activo')
INSERT [dbo].[tipocomprobante] ([idTipoComprobante], [Descripcion], [Estado]) VALUES (2, N'Factura', N'Activo')
INSERT [dbo].[tipocomprobante] ([idTipoComprobante], [Descripcion], [Estado]) VALUES (3, N'Nota de Crédito', N'Activo')
INSERT [dbo].[tipocomprobante] ([idTipoComprobante], [Descripcion], [Estado]) VALUES (4, N'Recibo', N'Activo')
INSERT [dbo].[tipocomprobante] ([idTipoComprobante], [Descripcion], [Estado]) VALUES (5, N'Nota de Débito', N'Activo')
INSERT [dbo].[tipocomprobante] ([idTipoComprobante], [Descripcion], [Estado]) VALUES (6, N'Guía de Remisión', N'Activo')
INSERT [dbo].[tipocomprobante] ([idTipoComprobante], [Descripcion], [Estado]) VALUES (7, N'Comprobante de Pago', N'Activo')
INSERT [dbo].[tipocomprobante] ([idTipoComprobante], [Descripcion], [Estado]) VALUES (8, N'Ticket', N'Activo')
INSERT [dbo].[tipocomprobante] ([idTipoComprobante], [Descripcion], [Estado]) VALUES (9, N'Vale', N'Activo')
INSERT [dbo].[tipocomprobante] ([idTipoComprobante], [Descripcion], [Estado]) VALUES (10, N'Orden de Compra', N'Activo')
SET IDENTITY_INSERT [dbo].[tipocomprobante] OFF
GO
SET IDENTITY_INSERT [dbo].[usuario] ON 

INSERT [dbo].[usuario] ([idUsuario], [Nombres], [Apellidos], [Dni], [Email], [Usuario], [Contraseña], [TipoUsuario], [Estado]) VALUES (1, N'Admin', N'Admin', 12345678, N'admin@example.com', N'admin', N'admin123', N'Administrador', N'Activo')
INSERT [dbo].[usuario] ([idUsuario], [Nombres], [Apellidos], [Dni], [Email], [Usuario], [Contraseña], [TipoUsuario], [Estado]) VALUES (2, N'Supervisor', N'Supervisor', 23456789, N'supervisor@example.com', N'supervisor', N'supervisor123', N'Supervisor', N'Activo')
INSERT [dbo].[usuario] ([idUsuario], [Nombres], [Apellidos], [Dni], [Email], [Usuario], [Contraseña], [TipoUsuario], [Estado]) VALUES (3, N'Cajero', N'Cajero', 34567890, N'cajero@example.com', N'cajero', N'cajero123', N'Cajero', N'Activo')
INSERT [dbo].[usuario] ([idUsuario], [Nombres], [Apellidos], [Dni], [Email], [Usuario], [Contraseña], [TipoUsuario], [Estado]) VALUES (4, N'Vendedor', N'Vendedor', 45678901, N'vendedor@example.com', N'vendedor', N'vendedor123', N'Vendedor', N'Activo')
INSERT [dbo].[usuario] ([idUsuario], [Nombres], [Apellidos], [Dni], [Email], [Usuario], [Contraseña], [TipoUsuario], [Estado]) VALUES (5, N'Almacenero', N'Almacenero', 56789012, N'almacenero@example.com', N'almacenero', N'almacenero123', N'Almacenero', N'Activo')
INSERT [dbo].[usuario] ([idUsuario], [Nombres], [Apellidos], [Dni], [Email], [Usuario], [Contraseña], [TipoUsuario], [Estado]) VALUES (6, N'Recepcionista', N'Recepcionista', 67890123, N'recepcionista@example.com', N'recepcionista', N'recepcionista123', N'Recepcionista', N'Activo')
INSERT [dbo].[usuario] ([idUsuario], [Nombres], [Apellidos], [Dni], [Email], [Usuario], [Contraseña], [TipoUsuario], [Estado]) VALUES (7, N'Contador', N'Contador', 78901234, N'contador@example.com', N'contador', N'contador123', N'Contador', N'Activo')
INSERT [dbo].[usuario] ([idUsuario], [Nombres], [Apellidos], [Dni], [Email], [Usuario], [Contraseña], [TipoUsuario], [Estado]) VALUES (8, N'Asistente', N'Asistente', 89012345, N'asistente@example.com', N'asistente', N'asistente123', N'Asistente', N'Activo')
INSERT [dbo].[usuario] ([idUsuario], [Nombres], [Apellidos], [Dni], [Email], [Usuario], [Contraseña], [TipoUsuario], [Estado]) VALUES (9, N'Auditor', N'Auditor', 90123456, N'auditor@example.com', N'auditor', N'auditor123', N'Auditor', N'Activo')
INSERT [dbo].[usuario] ([idUsuario], [Nombres], [Apellidos], [Dni], [Email], [Usuario], [Contraseña], [TipoUsuario], [Estado]) VALUES (10, N'Gerente', N'Gerente', 12345678, N'gerente@example.com', N'gerente', N'gerente123', N'Gerente', N'Activo')
SET IDENTITY_INSERT [dbo].[usuario] OFF
GO
SET IDENTITY_INSERT [dbo].[ventas] ON 

INSERT [dbo].[ventas] ([IdVenta], [Serie], [Numero], [Fecha], [VentaTotal], [Descuento], [SubTotal], [Igv], [Total], [Estado], [idCliente], [idEmpleado], [idTipoComprobante]) VALUES (1, N'001', N'000001', CAST(N'2024-02-22T20:21:36.000' AS DateTime), CAST(84.00 AS Decimal(8, 2)), CAST(2.00 AS Decimal(8, 2)), CAST(82.00 AS Decimal(8, 2)), CAST(12.30 AS Decimal(8, 2)), CAST(94.30 AS Decimal(8, 2)), N'Normal', 1, 1, 1)
INSERT [dbo].[ventas] ([IdVenta], [Serie], [Numero], [Fecha], [VentaTotal], [Descuento], [SubTotal], [Igv], [Total], [Estado], [idCliente], [idEmpleado], [idTipoComprobante]) VALUES (2, N'001', N'000002', CAST(N'2024-02-23T08:04:39.000' AS DateTime), CAST(58.00 AS Decimal(8, 2)), CAST(2.00 AS Decimal(8, 2)), CAST(56.00 AS Decimal(8, 2)), CAST(8.40 AS Decimal(8, 2)), CAST(64.40 AS Decimal(8, 2)), N'Normal', 2, 1, 1)
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
/****** Object:  StoredProcedure [dbo].[ActualizarCompraEstado]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[ActualizarVentaEstado]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[listarProveedor]    Script Date: 23/02/2024 9:40:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[listarProveedor]
as
select *from proveedor order by Nombre asc
GO
/****** Object:  StoredProcedure [dbo].[listarUsuario]    Script Date: 23/02/2024 9:40:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[listarUsuario]
as
select *from usuario order by idUsuario asc
GO
/****** Object:  StoredProcedure [dbo].[ObtenerDatosPorRangoFecha1]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_ReporteCompras]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_ReporteVentas]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[UltimoIdCompra]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_buscarcliente_obtener]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_buscarcliente1]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_buscarcomprobante_obtener]    Script Date: 23/02/2024 9:40:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[USP_buscarcomprobante_obtener]
as
SELECT        idTipoComprobante AS Id, Descripcion, Estado
FROM            dbo.tipocomprobante
GO
/****** Object:  StoredProcedure [dbo].[USP_buscarcomprobantecompra_obtener]    Script Date: 23/02/2024 9:40:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[USP_buscarcomprobantecompra_obtener]
as
SELECT        idTipoComprobante AS Id, Descripcion, Estado
FROM            dbo.tipocomprobante
GO
/****** Object:  StoredProcedure [dbo].[USP_buscarempleado_obtener]    Script Date: 23/02/2024 9:40:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[USP_buscarempleado_obtener]
as
SELECT        idEmpleado AS Id, Nombres, Apellidos, Dni, Email
FROM            dbo.empleado
GO
/****** Object:  StoredProcedure [dbo].[USP_buscarproductoscompras_obtener]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_buscarproductoscompras1]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_buscarproductosventas_obtener]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_buscarproductosventas1]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_buscarproveedor_obtener]    Script Date: 23/02/2024 9:40:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[USP_buscarproveedor_obtener]
as
SELECT        IdProveedor AS Id, Nombre, Ruc
FROM            dbo.proveedor

	
GO
/****** Object:  StoredProcedure [dbo].[USP_buscarproveedor1]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_Cliente_Buscar]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_Cliente_Delete]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_Cliente_insert]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_Cliente_obtener]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_Cliente_Update]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_CodEmpleado]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_Compra_Buscar]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_Compra_Delete]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_Compra_insert]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_Compra_obtener]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_Compra_Update]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_ConsultaClientes_obtener]    Script Date: 23/02/2024 9:40:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[USP_ConsultaClientes_obtener]
as
SELECT        idCliente AS Codigo, Nombres, Apellidos, Sexo, Dni, Telefono, Ruc, Email, Direccion
FROM            dbo.cliente
GO
/****** Object:  StoredProcedure [dbo].[USP_ConsultaCompra_obtener]    Script Date: 23/02/2024 9:40:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[USP_ConsultaCompra_obtener]
as
SELECT        idCompra AS Codigo, idProveedor AS Proveedor, Fecha, idEmpleado AS Empleado, idTipoComprobante AS Comprobante, Numero, Estado, Total
FROM            dbo.compra
GO
/****** Object:  StoredProcedure [dbo].[USP_ConsultaEmpleados_obtener]    Script Date: 23/02/2024 9:40:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[USP_ConsultaEmpleados_obtener]
as
SELECT        idEmpleado AS Codigo, Nombres, Apellidos, Especialidad, Sexo, Dni, Email, Telefono, Direccion, HoraIngreso AS Ingreso, HoraSalida AS Salida, Sueldo
FROM            dbo.empleado
GO
/****** Object:  StoredProcedure [dbo].[USP_ConsultaProductos_obtener]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_ConsultaProveedores_obtener]    Script Date: 23/02/2024 9:40:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[USP_ConsultaProveedores_obtener]
as
SELECT        IdProveedor AS Codigo, Nombre, Dni, Ruc, Direccion, Email, Telefono, Banco, Cuenta, Estado
FROM            dbo.proveedor
GO
/****** Object:  StoredProcedure [dbo].[USP_ConsultaVentas_obtener]    Script Date: 23/02/2024 9:40:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[USP_ConsultaVentas_obtener]
as
SELECT        IdVenta AS Codigo, idCliente AS Cliente, Fecha, idEmpleado AS Empleado, idTipoComprobante AS Documento, Serie, Numero, Estado, Total
FROM            dbo.ventas
GO
/****** Object:  StoredProcedure [dbo].[USP_detallecompra_Buscar]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_detallecompra_Delete]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_detallecompra_insert]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_detallecompra_obtener]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_detallecompra_Update]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_detalleventa_Buscar]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_detalleventa_Delete]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_detalleventa_insert]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_detalleventa_obtener]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_detalleventa_Update]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_empleado_Buscar]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_empleado_Delete]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_empleado_insert]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_empleado_obtener]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_empleado_Update]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_GananciaCaja]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_GananciaTotalVenta]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_laboratorio_Buscar]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_laboratorio_Delete]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_laboratorio_insert]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_laboratorio_obtener]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_laboratorio_Update]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_presentacion_Buscar]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_presentacion_Delete]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_presentacion_insert]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_presentacion_obtener]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_presentacion_Update]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_producto_Buscar]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_producto_Delete]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_producto_insert]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_producto_obtener]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_producto_Update]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_proveedor_Buscar]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_proveedor_Delete]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_proveedor_insert]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_proveedor_obtener]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_proveedor_Update]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_tipocomprobante_Buscar]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_tipocomprobante_Delete]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_tipocomprobante_insert]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_tipocomprobante_obtener]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_tipocomprobante_Update]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_UltimoNumeroCliente]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_UltimoNumeroCompra]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_usuario_Buscar]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_usuario_Delete]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_usuario_insert]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_usuario_obtener]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_usuario_Update]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_ventas_Buscar]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_ventas_Delete]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_ventas_insert]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_ventas_obtener]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[USP_ventas_Update]    Script Date: 23/02/2024 9:40:49 ******/
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
/****** Object:  StoredProcedure [dbo].[VentasPorFecha]    Script Date: 23/02/2024 9:40:49 ******/
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
