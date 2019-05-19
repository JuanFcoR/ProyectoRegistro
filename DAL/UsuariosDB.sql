create database UsuariosDb
Go
Create table Usuarios
(
	UsuarioId int Primary key identity,
	Nombres varchar(25),
	Email varchar(15),
	Usuario varchar(10),
	NivelUsuario varchar(10),
	Clave varchar(12),
	FechaIngreso datetime


);