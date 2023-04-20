INSERT INTO departamento (
    nome
) VALUES
('Administrativo'),
('Financeiro'),
('Pessoal'),
('Comercial'),
('Marketing'),
('Produção'),
('Jurídico');

INSERT INTO vendedor (
	id_departamento,
	nome,
	email,
	data_nascimento
) VALUES
	(1, 'Thomaz Falbo', 't@outlook.com', '1990-01-24 00:00:00'),
	(2, 'Nicolas Falbo', 'n@outlook.com', '2016-09-16 00:00:00'),
	(3, 'Sofia Falbo', 's@outlook.com', '2019-04-04 00:00:00'),
	(4, 'Noaly Falbo', 'no@outlook.com', '1993-01-31 00:00:00'),
	(5, 'Rubens Batista', 'r@hotmail.com', '1964-03-16 00:00:00'),
	(6, 'Bob Brown', 'bob@yahoo.com', '1950-12-30 00:00:00'),
	(7, 'Oliver Queen', 'oliver.queen@gmail.com.br', '1987-07-28 00:00:00');

INSERT INTO usuario (
	login,
	email,
	senha,
	data_cadastro
) VALUES
	('Bakumito', 'baku@msn.com.br', 'Senha#12' , now());

INSERT INTO tarefa (
	id_usuario,
	atividade,
	tipo_atividade,
	plataforma,
	tempo_tarefa,
	data_cadastro
) VALUES
	(1, 'Atividade1', null, null, '00:00:00', now());

	
insert into opcao
(rota)
values
('cadastrar'),
('excluir'),
('alterar'),
('visualizar');

insert into tela
(rota)
values
('usuario'),
('tarefa');