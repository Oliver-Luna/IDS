
CREATE DATABASE MVCCRUD
USE MVCCRUD

CREATE TABLE Usuarios(
Id int identity(1,1) primary key,
Nombre varchar(50),
Fecha date,
Clave varchar(50)
)

--TRABAJO EN CLASE------
--Se crea nueva tabla--
CREATE TABLE Estudiante(
Id int identity(1,1) primary key,
Carnet varchar(20),
Nombre varchar(50),
Apellido varchar(50),
PrimerParcial int,
SegundoParcial int,
Sistematico int,
NotaFinal int
)


select * from Usuarios
select * from Estudiante