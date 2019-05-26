create database UsuariosDb
Go
Create table Usuarios
(
	UsuarioId int Primary key identity,
	Nombres varchar(30),
	Email varchar(25),
	NivelUsuario varchar(15),
	Usuario varchar(15),
	Clave varchar(16),
	FechaIngreso datetime
);

create table Cargos
(
	CargoId int primary key identity,
	Descripcion varchar(30)
)