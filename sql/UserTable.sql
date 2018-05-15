create table Users (
	UserID int identity(1,1) primary key,
	fname varchar(20) not null,
	lname varchar(20) not null,
	email varchar(50) not null,
	interests varbinary(max) not null
)

drop table users
