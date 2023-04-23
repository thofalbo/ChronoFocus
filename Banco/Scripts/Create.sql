-- CREATE TYPE sale_status_enum AS ENUM ('Pending', 'Billed', 'Cancelled');
CREATE TABLE departamento (
	id int generated always as identity,
	nome varchar(64) NOT NULL,
	constraint pk_departamento primary key(id)
);
CREATE TABLE vendedor (
	id int generated always as identity,
	id_departamento int NOT NULL,
	nome varchar(64) NOT NULL,
	email varchar(256) NOT NULL,
	data_nascimento timestamp NOT NULL,
	constraint pk_vendedor primary key(id),
	constraint fk_departamento_vendedor foreign key(id_departamento) references departamento(id)
);
CREATE TABLE usuario (
	id int generated always as identity,
	login varchar(64) NOT NULL,
	email varchar(256) NOT NULL,
	senha varchar(8) NOT NULL,
	data_cadastro timestamp NOT NULL,
	constraint pk_usuario primary key(id)
);
CREATE TABLE tarefa (
	id int generated always as identity,
	id_usuario int NOT NULL,
	atividade varchar(64) NOT NULL,
	tipo_atividade varchar(64),
	plataforma varchar(64),
	tempo_tarefa time NOT NULL,
	data_cadastro timestamp NOT NULL,
	constraint pk_tarefa primary key(id),
	constraint fk_usuario_tarefa foreign key(id_usuario) references usuario(id)
);
CREATE TABLE opcao (
	id int generated always as identity,
	rota varchar(64) NOT NULL,
	constraint pk_opcao primary key(id)
);
CREATE TABLE tela (
	id int generated always as identity,
	rota varchar(64) NOT NULL,
	constraint pk_tela primary key(id)
);
CREATE TABLE opcao_tela_usuario (
	id_opcao int NOT NULL,
	id_tela int NOT NULL,
	id_usuario int NOT NULL,
	constraint fk_opcao_opcao_tela_usuario foreign key(id_opcao) references opcao(id),
	constraint fk_tela_opcao_tela_usuario foreign key(id_tela) references tela(id),
	constraint fk_usuario_opcao_tela_usuario foreign key(id_usuario) references usuario(id)
);
-- tabela funcionario
CREATE TABLE funcionario (
	id int generated always as identity,
	nome varchar(64) NOT NULL,
	email varchar(128) NOT NULL,
	apelido varchar(128) NOT NULL,
	senha varchar(64) NOT NULL,
	data_cadastro timestamp NOT NULL,
	CONSTRAINT pk_funcionario PRIMARY KEY (id),
	CONSTRAINT uq_funcionario_email UNIQUE (email)
);
-- tabela controlador
CREATE TABLE controlador (
	id int generated always as identity,
	nome varchar(128) NOT NULL,
	CONSTRAINT pk_controlador PRIMARY KEY (id),
	CONSTRAINT uq_controlador_nome UNIQUE (nome)
);
-- tabela acao
CREATE TABLE acao (
	id int generated always as identity,
	nome varchar(255) NOT NULL,
	id_controlador int NOT NULL,
	CONSTRAINT pk_acao PRIMARY KEY (id),
	CONSTRAINT fk_acao_controlador FOREIGN KEY (id_controlador) REFERENCES controlador(id)
);
-- tabela permissao
CREATE TABLE permissao (
	id_funcionario int NOT NULL,
	id_controlador int NOT NULL,
	id_acao int NOT NULL,
	CONSTRAINT pk_permissao PRIMARY KEY(id_funcionario, id_controlador, id_acao),
	CONSTRAINT fk_permissao_usuario FOREIGN KEY (id_funcionario) REFERENCES funcionario(id),
	CONSTRAINT fk_permissao_controlador FOREIGN KEY (id_controlador) REFERENCES controlador(id),
	CONSTRAINT fk_permissao_acao FOREIGN KEY (id_acao) REFERENCES acao(id)
);