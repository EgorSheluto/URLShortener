create database URLs;
use URLs;
create table URLInfo(
	id int auto_increment not null primary key,
    fullurl varchar(500) not null,
    shorturl varchar(100) not null,
    createdate date not null,
    amount int not null
);