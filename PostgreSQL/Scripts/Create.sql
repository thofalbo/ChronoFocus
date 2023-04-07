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
    constraint fk_departamento_vendedor foreign key(id_departamento)
    references departamento(id)
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
	tempo_tarefa timestamp NOT NULL,
	data_cadastro timestamp NOT NULL,
	constraint pk_tarefa primary key(id),
    constraint fk_usuario_tarefa foreign key(id_usuario)
    references usuario(id)
);
