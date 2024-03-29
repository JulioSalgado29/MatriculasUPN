USE [master]
GO
/****** Object:  Database [UniversidadUPN]    Script Date: 12/09/2022 16:52:03 ******/
CREATE DATABASE [UniversidadUPN]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UniversidadUPN', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\UniversidadUPN.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'UniversidadUPN_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\UniversidadUPN_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [UniversidadUPN] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UniversidadUPN].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UniversidadUPN] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UniversidadUPN] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UniversidadUPN] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UniversidadUPN] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UniversidadUPN] SET ARITHABORT OFF 
GO
ALTER DATABASE [UniversidadUPN] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UniversidadUPN] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UniversidadUPN] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UniversidadUPN] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UniversidadUPN] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UniversidadUPN] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UniversidadUPN] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UniversidadUPN] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UniversidadUPN] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UniversidadUPN] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UniversidadUPN] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UniversidadUPN] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UniversidadUPN] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UniversidadUPN] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UniversidadUPN] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UniversidadUPN] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UniversidadUPN] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UniversidadUPN] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [UniversidadUPN] SET  MULTI_USER 
GO
ALTER DATABASE [UniversidadUPN] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UniversidadUPN] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UniversidadUPN] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UniversidadUPN] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [UniversidadUPN] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [UniversidadUPN] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [UniversidadUPN] SET QUERY_STORE = OFF
GO
USE [UniversidadUPN]
GO
/****** Object:  Table [dbo].[Clase]    Script Date: 12/09/2022 16:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clase](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[code] [nvarchar](50) NULL,
	[location] [nvarchar](50) NULL,
	[teacher] [nvarchar](50) NULL,
	[idCurso] [int] NULL,
	[idPeriodo] [int] NULL,
	[ourBegin] [datetime] NULL,
	[ourFinal] [datetime] NULL,
 CONSTRAINT [PK_Clase] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[prueba]    Script Date: 12/09/2022 16:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[prueba]
as 
SELECT *,0 as status FROM CLASE
GO
/****** Object:  Table [dbo].[Carrera]    Script Date: 12/09/2022 16:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carrera](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Carrera] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Curso]    Script Date: 12/09/2022 16:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Curso](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[credit] [int] NULL,
	[idCarrera] [int] NULL,
 CONSTRAINT [PK_Curso] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estudiante]    Script Date: 12/09/2022 16:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estudiante](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[code] [nvarchar](50) NULL,
	[dateRegister] [datetime] NULL,
	[state] [bit] NULL,
	[name] [nvarchar](50) NULL,
	[lastname] [nvarchar](50) NULL,
	[age] [int] NULL,
	[idCarrera] [int] NULL,
 CONSTRAINT [PK_Estudiante] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoginLogs]    Script Date: 12/09/2022 16:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoginLogs](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idUsuario] [int] NULL,
	[fechaIngreso] [datetime] NULL,
 CONSTRAINT [PK_LoginLogs] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Matricula]    Script Date: 12/09/2022 16:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Matricula](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[code] [nvarchar](50) NULL,
	[dateCreation] [datetime] NULL,
	[dateUpdate] [datetime] NULL,
	[idEstudiante] [int] NULL,
	[idUsuario] [int] NULL,
 CONSTRAINT [PK_Matricula] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[idEstudiante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MatriculaDet]    Script Date: 12/09/2022 16:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MatriculaDet](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idClase] [int] NULL,
	[idMatricula] [int] NULL,
	[idPeriodo] [int] NULL,
 CONSTRAINT [PK_MatriculaDet] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MatriculaLogs]    Script Date: 12/09/2022 16:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MatriculaLogs](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idEstudiante] [int] NULL,
	[movimientoAgregacion] [int] NULL,
	[movimientoEliminacion] [int] NULL,
 CONSTRAINT [PK_MatriculaLogs] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Periodo]    Script Date: 12/09/2022 16:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Periodo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[age] [int] NULL,
	[type] [nvarchar](50) NULL,
 CONSTRAINT [PK_Periodo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 12/09/2022 16:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[email] [nvarchar](50) NULL,
	[username] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
	[attemps] [int] NULL,
	[name] [nvarchar](50) NULL,
	[lastname] [nvarchar](50) NULL,
	[age] [int] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Clase]  WITH CHECK ADD  CONSTRAINT [FK_Clase_Curso] FOREIGN KEY([idCurso])
REFERENCES [dbo].[Curso] ([id])
GO
ALTER TABLE [dbo].[Clase] CHECK CONSTRAINT [FK_Clase_Curso]
GO
ALTER TABLE [dbo].[Clase]  WITH CHECK ADD  CONSTRAINT [FK_Clase_Periodo] FOREIGN KEY([idPeriodo])
REFERENCES [dbo].[Periodo] ([id])
GO
ALTER TABLE [dbo].[Clase] CHECK CONSTRAINT [FK_Clase_Periodo]
GO
ALTER TABLE [dbo].[Curso]  WITH CHECK ADD  CONSTRAINT [FK_Curso_Carrera] FOREIGN KEY([idCarrera])
REFERENCES [dbo].[Carrera] ([id])
GO
ALTER TABLE [dbo].[Curso] CHECK CONSTRAINT [FK_Curso_Carrera]
GO
ALTER TABLE [dbo].[Estudiante]  WITH CHECK ADD  CONSTRAINT [FK_Estudiante_Carrera] FOREIGN KEY([idCarrera])
REFERENCES [dbo].[Carrera] ([id])
GO
ALTER TABLE [dbo].[Estudiante] CHECK CONSTRAINT [FK_Estudiante_Carrera]
GO
ALTER TABLE [dbo].[LoginLogs]  WITH CHECK ADD  CONSTRAINT [FK_LoginLogs_Usuario] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([id])
GO
ALTER TABLE [dbo].[LoginLogs] CHECK CONSTRAINT [FK_LoginLogs_Usuario]
GO
ALTER TABLE [dbo].[Matricula]  WITH CHECK ADD  CONSTRAINT [FK_Matricula_Estudiante] FOREIGN KEY([idEstudiante])
REFERENCES [dbo].[Estudiante] ([id])
GO
ALTER TABLE [dbo].[Matricula] CHECK CONSTRAINT [FK_Matricula_Estudiante]
GO
ALTER TABLE [dbo].[Matricula]  WITH CHECK ADD  CONSTRAINT [FK_Matricula_Usuario] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([id])
GO
ALTER TABLE [dbo].[Matricula] CHECK CONSTRAINT [FK_Matricula_Usuario]
GO
ALTER TABLE [dbo].[MatriculaDet]  WITH CHECK ADD  CONSTRAINT [FK_MatriculaDet_Clase] FOREIGN KEY([idClase])
REFERENCES [dbo].[Clase] ([id])
GO
ALTER TABLE [dbo].[MatriculaDet] CHECK CONSTRAINT [FK_MatriculaDet_Clase]
GO
ALTER TABLE [dbo].[MatriculaDet]  WITH CHECK ADD  CONSTRAINT [FK_MatriculaDet_Matricula] FOREIGN KEY([idMatricula])
REFERENCES [dbo].[Matricula] ([id])
GO
ALTER TABLE [dbo].[MatriculaDet] CHECK CONSTRAINT [FK_MatriculaDet_Matricula]
GO
ALTER TABLE [dbo].[MatriculaDet]  WITH CHECK ADD  CONSTRAINT [FK_MatriculaDet_Periodo] FOREIGN KEY([idPeriodo])
REFERENCES [dbo].[Periodo] ([id])
GO
ALTER TABLE [dbo].[MatriculaDet] CHECK CONSTRAINT [FK_MatriculaDet_Periodo]
GO
ALTER TABLE [dbo].[MatriculaLogs]  WITH CHECK ADD  CONSTRAINT [FK_MatriculaLogs_Estudiante] FOREIGN KEY([idEstudiante])
REFERENCES [dbo].[Estudiante] ([id])
GO
ALTER TABLE [dbo].[MatriculaLogs] CHECK CONSTRAINT [FK_MatriculaLogs_Estudiante]
GO
/****** Object:  StoredProcedure [dbo].[spActualizarMatricula]    Script Date: 12/09/2022 16:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spActualizarMatricula]
(@pmCode nvarchar(50), @pmDateUpdate datetime, @pmIdEstudiante int)
AS
BEGIN
UPDATE Matricula SET code = @pmCode, dateUpdate = @pmDateUpdate
WHERE idEstudiante = @pmIdEstudiante
SELECT * FROM Matricula where idEstudiante=@pmIdEstudiante
END
GO
/****** Object:  StoredProcedure [dbo].[spAgregarMovimiento]    Script Date: 12/09/2022 16:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spAgregarMovimiento]
(@pmIdEstudiante int)
AS
UPDATE MatriculaLogs SET movimientoAgregacion = movimientoAgregacion + 1
WHERE MatriculaLogs.idEstudiante = @pmIdEstudiante
GO
/****** Object:  StoredProcedure [dbo].[spAumentarIntentos]    Script Date: 12/09/2022 16:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure  [dbo].[spAumentarIntentos]
(@pmUsername nvarchar(50))
as
begin
update Usuario set 
       attemps  = attemps+1
	   where username=@pmUsername
end
GO
/****** Object:  StoredProcedure [dbo].[spBuscarClase]    Script Date: 12/09/2022 16:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spBuscarClase]
(@pmId int)
as
select * from Clase where id = @pmId
GO
/****** Object:  StoredProcedure [dbo].[spBuscarCurso]    Script Date: 12/09/2022 16:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spBuscarCurso]
(@pmId int)
as
select * from Curso where id = @pmId
GO
/****** Object:  StoredProcedure [dbo].[spBuscarEstudiante]    Script Date: 12/09/2022 16:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spBuscarEstudiante] 
(@pmId int)
as
select e.id,e.code,e.dateRegister,e.state, e.age, e.name, e.lastname, c.id as idCarrera, c.name as nameCarrera
from Estudiante e, Carrera c where e.idCarrera = c.id AND e.id=@pmId
GO
/****** Object:  StoredProcedure [dbo].[spBuscarMatriculaDet]    Script Date: 12/09/2022 16:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spBuscarMatriculaDet]
(@pmIdMatricula int)
as
select * from MatriculaDet where idMatricula = @pmIdMatricula
GO
/****** Object:  StoredProcedure [dbo].[spBuscarMatriculaLogs]    Script Date: 12/09/2022 16:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spBuscarMatriculaLogs]
(@pmIdEstudiante int)
as
select * from MatriculaLogs
where idEstudiante = @pmIdEstudiante
GO
/****** Object:  StoredProcedure [dbo].[spBuscarPeriodo]    Script Date: 12/09/2022 16:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spBuscarPeriodo]
(@pmId int)
as
select id, CONCAT(age, '-' ,type) as name from Periodo where id = @pmId
GO
/****** Object:  StoredProcedure [dbo].[spCrearMatricula]    Script Date: 12/09/2022 16:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spCrearMatricula]
(@pmCode nvarchar(50), @pmDateCreation datetime, @pmDateUpdate datetime, @pmIdEstudiante int, @pmIdUsuario int)
AS
BEGIN
INSERT INTO Matricula(code, dateCreation, dateUpdate, idEstudiante, idUsuario) 
VALUES(@pmCode, @pmDateCreation, @pmDateCreation, @pmIdEstudiante, @pmIdUsuario)
SELECT * FROM Matricula where idEstudiante=@pmIdEstudiante
END
GO
/****** Object:  StoredProcedure [dbo].[spCrearMatriculaDet]    Script Date: 12/09/2022 16:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spCrearMatriculaDet]
(@pmIdMatricula int, @pmIdClase int, @pmIdPeriodo int)
AS
BEGIN
INSERT INTO MatriculaDet(idMatricula, idClase, idPeriodo) 
VALUES(@pmIdMatricula, @pmIdClase, @pmIdPeriodo)
SELECT * FROM MatriculaDet where idMatricula=@pmIdMatricula AND idClase = @pmIdClase AND idPeriodo = @pmIdPeriodo 
END
GO
/****** Object:  StoredProcedure [dbo].[spCrearRegistroLog]    Script Date: 12/09/2022 16:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spCrearRegistroLog]
(@pmIdUsuario int, @pmFechaIngreso datetime)
AS
BEGIN
INSERT INTO LoginLogs(idUsuario, fechaIngreso) 
VALUES(@pmIdUsuario, @pmFechaIngreso)
END
GO
/****** Object:  StoredProcedure [dbo].[spEliminarClase]    Script Date: 12/09/2022 16:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spEliminarClase]
(@pmIdClase nvarchar(50), @pmIdMatricula nvarchar(50), @pmIdPeriodo nvarchar(50))
AS
DELETE FROM MatriculaDet
WHERE idClase = @pmIdClase AND idMatricula = @pmIdMatricula AND idPeriodo = @pmIdPeriodo
GO
/****** Object:  StoredProcedure [dbo].[spEliminarMovimiento]    Script Date: 12/09/2022 16:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spEliminarMovimiento]
(@pmIdEstudiante int)
AS
UPDATE MatriculaLogs SET movimientoEliminacion = movimientoEliminacion + 1
WHERE MatriculaLogs.idEstudiante = @pmIdEstudiante
GO
/****** Object:  StoredProcedure [dbo].[spListarClase]    Script Date: 12/09/2022 16:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spListarClase]
(@pmIdCurso int, @pmIdPeriodo int)
as
select * from Clase where idCurso = @pmIdCurso AND idPeriodo = @pmIdPeriodo
ORDER BY id ASC
GO
/****** Object:  StoredProcedure [dbo].[spListarClasesDelEstudiante]    Script Date: 12/09/2022 16:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spListarClasesDelEstudiante]
(@pmIdEstudiante int, @pmIdPeriodo int)
AS
select c.*, 1 as state from clase as c
inner join Matricula m on m.idEstudiante = @pmIdEstudiante
inner join MatriculaDet mD on mD.idMatricula = m.id
where c.id = mD.idClase AND @pmIdPeriodo = c.idPeriodo
ORDER BY id ASC
GO
/****** Object:  StoredProcedure [dbo].[spListarCurso]    Script Date: 12/09/2022 16:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spListarCurso]
(@pmIdCarrera int, @pmIdPeriodo int)
as
select DISTINCT cur.* from Curso as cur
inner join Clase cla on cla.idCurso = cur.id
where idCarrera = @pmIdCarrera AND cla.idPeriodo = @pmIdPeriodo
GO
/****** Object:  StoredProcedure [dbo].[spListarCursosDelEstudiante]    Script Date: 12/09/2022 16:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spListarCursosDelEstudiante]
(@pmIdEstudiante int, @pmIdPeriodo int)
AS
select curs.id, curs.name, curs.credit, curs.idCarrera from Curso as curs
inner join Matricula m on m.idEstudiante = @pmIdEstudiante
inner join MatriculaDet mD on mD.idMatricula = m.id
inner join Clase c on c.id= mD.idClase AND c.idPeriodo = @pmIdPeriodo
where curs.id = c.idCurso
GO
/****** Object:  StoredProcedure [dbo].[spListarEstudiante]    Script Date: 12/09/2022 16:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spListarEstudiante]
as
select e.id,e.code,e.dateRegister,e.state, e.age, e.name, e.lastname, c.id as idCarrera, c.name as nameCarrera
from Estudiante e, Carrera c where e.idCarrera = c.id
GO
/****** Object:  StoredProcedure [dbo].[spListarMatricula]    Script Date: 12/09/2022 16:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spListarMatricula]
as
select * from Matricula 
GO
/****** Object:  StoredProcedure [dbo].[spListarPeriodo]    Script Date: 12/09/2022 16:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spListarPeriodo]
as
select id, CONCAT(age, '-' ,type) as name from Periodo
GO
/****** Object:  StoredProcedure [dbo].[spReiniciarIntentos]    Script Date: 12/09/2022 16:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure  [dbo].[spReiniciarIntentos]
(@pmUsername nvarchar(50))
as
begin
update Usuario set 
       attemps  = 0
	   where username=@pmUsername
end
GO
/****** Object:  StoredProcedure [dbo].[spVerificarAcceso]    Script Date: 12/09/2022 16:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure  [dbo].[spVerificarAcceso]
(@pmUsername nvarchar(50),@pmPassword nvarchar(50))
as
begin
Select  id, email, attemps, age, name, lastname
        from Usuario 
		where username=@pmUsername AND password=@pmPassword
 end
GO
/****** Object:  StoredProcedure [dbo].[spVerificarCurso]    Script Date: 12/09/2022 16:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spVerificarCurso]
(@pmId int)
as
select * from Curso where id = @pmId
GO
/****** Object:  StoredProcedure [dbo].[spVerificarEstudiante]    Script Date: 12/09/2022 16:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spVerificarEstudiante]
(@pmId int)
as
select state from Estudiante where id = @pmId
GO
/****** Object:  StoredProcedure [dbo].[spVerificarIntentos]    Script Date: 12/09/2022 16:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spVerificarIntentos]
(@pmUsername nvarchar(50))
as
begin
SELECT attemps from Usuario where username=@pmUsername
end
GO
/****** Object:  StoredProcedure [dbo].[spVerificarMatricula]    Script Date: 12/09/2022 16:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spVerificarMatricula]
(@pmIdEstudiante int)
as
select * from Matricula where idEstudiante = @pmIdEstudiante
GO
/****** Object:  StoredProcedure [dbo].[spVerificarPeriodo]    Script Date: 12/09/2022 16:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spVerificarPeriodo]
(@pmId int)
as
select * from Periodo where id = @pmId
GO
USE [master]
GO
ALTER DATABASE [UniversidadUPN] SET  READ_WRITE 
GO
