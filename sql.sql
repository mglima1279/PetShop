create database dbPets;
go

use dbPets;
go

create table tb_tutor(
	id int primary key identity(1, 1) not null,
	"name" varchar(45) not null,
	"pet_name" varchar(45) not null
);
go

create table tb_service(
	id int primary key identity(1,1) not null,
	"desc" varchar(100) not null
);
go

create table tb_bookings(
	id int primary key identity(1,1) not null,
	"datetime" datetime not null,
	id_tutor int not null,
	foreign key (id_tutor) references tb_tutor(id),
	id_service int not null,
	foreign key (id_service) references tb_service(id)
);