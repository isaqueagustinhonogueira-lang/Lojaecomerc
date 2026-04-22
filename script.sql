-- criando o banco de dados 
create database dbProjetoLoja;

-- usando o banco de dados 
use dbProjetoLoja;

-- criando as tabelas do banco de dados
create table tb_Usuario(
Id int primary key auto_increment,
Nome varchar(50) not null,
Email varchar(50) not null,
Senha varchar(250) not null, 
Nivel varchar(50) not null
);
-- consultando a tabela do bando de dados 
select * from tb_Usuario;
-- inserindo dados na tabela do banco de dados 
insert into tb_Usuario(Nome,Email, Senha, Nivel) Values
('Administrador','admin@email.com','123456','admin');