create database MiniWareBD
go
use MiniWareBD
go
create table Usuario
(
	Id int identity primary key,
	Nombre varchar(30),
	ApPaterno varchar(30),
	ApMaterno varchar(30),
	Username varchar(30),
	Password varchar(50),
	Celular bigint not null,
	Correo varchar(100),
	Grado int not null,
	Grupo varchar(1) not null
	)

go

create table MensajeGeneral
(
Id int primary key identity,
Descripcion text,
De varchar(100),
fechaCreacion datetime,
fechaCierre datetime,
)

go

create table MensajePersonal
(
Id int primary key identity,
IdMensajeGeneral int,
IdUsuario int,
Visto bit,
foreign key (IdMensajeGeneral) references MensajeGeneral,
foreign key (IdUsuario) references Usuario
)