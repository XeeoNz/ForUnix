
create database UnixDB;

go

use UnixDB;

create table Gyartok(
Id int identity(1,1),
GyartoNev nvarchar(500) not null,
constraint PK_Gyartok primary key (Id)
);


create table Reszletek(
Id int identity(1,1),
Ajtok int not null,
Teljesitmeny int not null,
Ulesek int not null,
Evjarat int not null,
constraint PK_Reszletek primary key (Id)
);


create table Modellek(
Id int identity(1,1),
ModellNev nvarchar(500) not null,
GyartoId int not null,
ReszletekId int not null,
constraint PK_Modellek primary key (Id),
constraint FK_Modellek_Gyartok_GyartoId foreign key (GyartoId)
references Gyartok(Id),
constraint FK_Modellek_Reszletek_ReszletekId foreign key (ReszletekId)
references Reszletek(Id)
);

insert into Gyartok values ('Suzuki'), ('Honda'), ('BMW'), ('Bugatti');

insert into Reszletek
	values
		(2, 100, 2, 2000),
		(4, 150, 4, 2010),
		(2, 400, 4, 2015),
		(2, 1000, 2, 2005);

insert into Modellek
	values
		('Swift', 1, 1),
		('Accord', 2, 2),
		('i8', 3, 3),
		('Veyron', 4, 4);


