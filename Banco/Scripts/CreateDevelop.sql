
-- tabela usuario
CREATE TABLE usuario (
	id int generated always as identity,
	nome varchar(64) NOT NULL,
	email varchar(128) NOT NULL,
	login varchar(128) NOT NULL,
	senha varchar(64) NOT NULL,
	data_cadastro timestamp NOT NULL,
	CONSTRAINT pk_usuario PRIMARY KEY (id),
	CONSTRAINT uq_usuario_email UNIQUE (email),
	CONSTRAINT uq_usuario_login UNIQUE (login)
);
-- tabela acao
CREATE TABLE acao (
	id int generated always as identity,
	controlador varchar(128) NOT NULL,
	rota varchar(128) NOT NULL,
	descricao varchar(128) NOT NULL,
	usuario_cadastro int NOT NULL,
	data_cadastro timestamp NOT NULL,
	CONSTRAINT pk_acao PRIMARY KEY (id)
);
-- tabela acao_usuario
CREATE TABLE acao_usuario (
	id_acao int NOT NULL,
	id_usuario int NOT NULL,
	CONSTRAINT pk_acao_usuario PRIMARY KEY (id_acao, id_usuario),
	CONSTRAINT fk_acao_usuario_acao FOREIGN KEY (id_acao) REFERENCES acao(id),
	CONSTRAINT fk_acao_usuario_usuario FOREIGN KEY (id_usuario) REFERENCES usuario(id)
);
-- tabela tarefa
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
