-- PROCEDURES --

--cadastro de cliente
create procedure cadCli
(
	@nome varchar(50), @documento varchar(20), @cep varchar(10), --insert pessoas
	@endereco varchar(50), @razao_social varchar(50), @nome_fantasia varchar(50) --insert clientes
)
as
begin
	begin try
		begin tran
			insert into Pessoas values(@nome, @documento, @cep)
			insert into Clientes values(@@IDENTITY, @endereco, @razao_social, @nome_fantasia)
		commit
		return 0
	end try
	begin catch
		rollback
		return 1
	end catch
end
go

--teste
/*
exec cadCli 'Teste', '12345678900', '15110000', 'Rua Teste nr teste','teste ltda mei','teste'
go

select * from Pessoas
select * from Clientes
go
*/

-- DBCC CheckIdent ('Pessoas', RESEED, 0)

--cadastro de colaborador
create procedure cadColab
(
	@nome varchar(50), @documento varchar(20), @cep varchar(10), --insert pessoas
	@salario money, @funcao varchar(50) --insert colaboradores
)
as
begin
	begin try
		begin tran
			insert into Pessoas values(@nome, @documento, @cep)
			insert into Colaboradores values(@@IDENTITY, @salario, @funcao)
		commit
		return 0
	end try
	begin catch
		rollback
		return 1
	end catch
end
go

/*
exec cadColab 'Teste', '9461764300','15040420',1500.00,'teste'
go

select * from Pessoas
select * from Colaboradores
go
*/

--cadastro de produto
create procedure cadProd (@categoria varchar(20), @descricao varchar(20) )
as
begin
	begin try
		begin tran
			insert into Produtos values(@categoria, @descricao)
		commit
		return 0
	end try
	begin catch
		rollback
		return 1
	end catch
end
go

/*
exec cadProd 'Teste','teste'
go

select * from Produtos
go
*/

--cadastro de orçamentos
create procedure cadOrc 
(
	@situacao varchar(10), @valor_total money, @valor_frete money, @data_entrega varchar(10), @forma_pgto varchar(20), @prazo_pgto varchar(20),
	@cod_cliente int, @cod_colab int
)
as
begin
	begin try
		begin tran
			insert into Orcamentos values (@situacao, @valor_total, @valor_frete, @data_entrega, @forma_pgto, @prazo_pgto, @cod_cliente, @cod_colab)
		commit
		return 0
	end try
	begin catch
		rollback
		return 1
	end catch
end
go

/*
exec cadOrc 'pendente', 1500.00, 35.00, '01/01/2020', 'boleto', '30/60' , 1, 2
go

select * from Orcamentos
go
*/