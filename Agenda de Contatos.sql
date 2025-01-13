create database dbAgenda
default charset utf8mb4 
default collate utf8mb4_general_ci;

use agenda;

create table if not exists contatos (
id int not null auto_increment primary key,
nome varchar(50),
numero varchar(12) not null
)default char set utf8mb4;

select * from contatos;

alter table contatos
add column email varchar(100);

truncate contatos;

