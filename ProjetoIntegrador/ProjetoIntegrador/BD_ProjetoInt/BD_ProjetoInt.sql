Create database ProjetoInt;
       
Use ProjetoInt;

create table tb_usuario(
	Id int not null primary key auto_increment,
    Nome varchar(30),
    Cpf varchar(30),
    senha varchar(25)
);

create table tb_Fossil(
	Id int not null primary key auto_increment,
    Nome_Fossil varchar(100) not null,
    Regiao varchar(250),
    fotoFossil varchar(250),
    DescricaoFossil varchar(250)
    
);

create table tb_Fossil_Favorito(
	Id_Fav int not null primary key auto_increment,
    Fossil_id int,
    constraint fk_favfossil_Id foreign key (Fossil_Id) 
    references tb_Fossil (Id) 
    on update cascade on delete no action
    
);
