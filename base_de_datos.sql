
create database Escuela;
use Escuela;

create table Carrera (id_carrera int not null primary key , carrera varchar(100) not null);

create table Alumno (id_alumno int not null primary key ,
                     nombre varchar (100) not null,
					 a_paterno varchar(100) not null,
					 a_materno varchar(100) not null,
					 edad int not null,
					 id_carrera int ,
					 constraint AlumnoFK foreign key (id_carrera) references Carrera(id_carrera));

create  table Person(Id int not null, Name varchar(100) ,Age int);


insert into Person values(1,'Jose',22);

insert into Carrera values(1,'Sitemas'),(2,'Quimica'),(3,'Electronica'),(4,'Ambiental');
insert into Alumno values(2,'Juan Jesus','Padron','Diaz',22,4);
update Alumno set id_carrera=1 where id_alumno=1;

select * from Alumno inner join Carrera on Alumno.id_carrera=Carrera.id_carrera

