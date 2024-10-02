use master
go
IF NOT EXISTS(SELECT name FROM master.dbo.sysdatabases WHERE NAME = 'DBPRUEBAS')
CREATE DATABASE DBPRUEBAS
GO 

USE DBPRUEBAS
GO

if not exists (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'CATEDORIA')
create table CATEDORIA(
IdCategoria int primary key identity(1,1),
Categoria varchar(60),
Descripcion varchar(250),
Estado bit Default 1,
FechaRegistro datetime default getdate()
)
go

if not exists (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'MODELO')
create table MODELO(
idModelo int primary key identity(1,1),
Nombre varchar(50),
Estado bit,
FechaRegistro datetime default getdate()
)
go

select * from MODELO

INSERT INTO MODELO (Nombre, Estado)
VALUES 
    ('pequeño', 1),
    ('grande', 1);
