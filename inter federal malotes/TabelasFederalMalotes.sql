create database FederalMalotes 
go

use FederalMalotes
go

create table Pessoas
(
	id int not null identity,
	nome varchar(50) not null,
	documento varchar(20) not null UNIQUE,
	cep varchar(10) not null,

	constraint pk_pessoa primary key (id)
)
go

create table Clientes
(
	cod_cliente int not null,
	endereco varchar(50) not null,
	razao_social varchar(50) not null,
	nome_fantasia varchar(50) not null,

	constraint fk_cliente foreign key(cod_cliente) references Pessoas(id),
	constraint pk_cliente primary key(cod_cliente)
)
go

create table Colaboradores
(
	cod_colab int not null,
	salario money not null,
	funcao varchar(50) not null,

	constraint fk_colab foreign key(cod_colab) references Pessoas(id),
	constraint pk_colab primary key(cod_colab)
)
go

create table Orcamentos
(
	num int not null identity,
	situacao varchar(10),
	valor_total money not null,
	valor_frete money not null,
	data_entrega varchar(10) not null,
	forma_pgto varchar(20) not null,
	prazo_pgto varchar(20) not null,
	cod_cliente int not null,
	cod_colab int not null,

	constraint fk_orc_cli foreign key(cod_cliente) references Clientes(cod_cliente),
	constraint fk_orc_colab foreign key(cod_colab) references Colaboradores(cod_colab),
	constraint pk_orc primary key(num)
)
go

create table Produtos
(
	id_prod int not null identity,
	descricao varchar(20) not null,
	categoria varchar(20) not null,
	preco	money,

	constraint pk_prod primary key(id_prod)
)
go

create table ItensDoOrcamento
(
	nr_orc int not null,
	id_prod int not null,
	qtde int not null,
	obs varchar(50),

	constraint fk_itens_orc foreign key(nr_orc) references Orcamentos(num),
	constraint fk_itens_prod foreign key(id_prod) references Produtos(id_prod),
	constraint pk_itens primary key (nr_orc, id_prod)
)
go