-- CREATE TYPE sale_status_enum AS ENUM ('Pending', 'Billed', 'Cancelled');

CREATE TABLE departamento (
	id smallint generated always as identity,
	nome varchar(64) NOT NULL,
	constraint pk_departamento primary key(id)
);

CREATE TABLE vendedor (
	id smallint generated always as identity,
	id_departamento smallint NOT NULL,
	nome varchar(64) NOT NULL,
	email varchar(256) NOT NULL,
	data_nascimento timestamp NOT NULL,
	constraint pk_vendedor primary key(id),
    constraint fk_departamento_vendedor foreign key(id_departamento)
    references departamento(id)
);
