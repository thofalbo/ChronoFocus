-- Inserts for usuario table
INSERT INTO usuario (nome, email, login, senha, data_cadastro) 
VALUES
('Thomaz', 'thomazfalbo@outlook.com', 'Bakumito', '123', now()),
('Noaly', 'noalyfalbo@outlook.com', 'Noaly', '12345678', now());
-- Inserts for tarefa table
INSERT INTO tarefa (id_usuario, atividade, tipo_atividade, plataforma, tempo_tarefa, data_cadastro) 
VALUES
(1, 'Atividade 1', 'tipo-1', 'plataforma-1', '02:30:00', now()),
(1, 'Atividade 2', 'tipo-2', 'plataforma-2', '01:45:00', now()),
(2, 'Atividade 3', 'tipo-1', 'plataforma-1', '03:15:00', now()),
(2, 'Atividade 4', 'tipo-2', 'plataforma-2', '00:45:00', now());
-- Inserts for acao table
INSERT INTO acao (controlador, rota, descricao, usuario_cadastro, data_cadastro)
VALUES
('tarefa', '/tarefa/inicio', 'inicio', 1, now()),
('tarefa', '/tarefa/cadastrar', 'cadastrar', 1, now()),
('tarefa', '/tarefa/editar', 'editar', 1, now()),
('tarefa', '/tarefa/excluir', 'excluir', 1, now()),
('acao', '/acao/inicio', 'inicio', 1, now()),
('acao', '/acao/cadastrar', 'cadastrar', 1, now()),
('acao', '/acao/editar', 'editar', 1, now()),
('acao', '/acao/excluir', 'excluir', 1, now()),
('usuario', '/usuario/inicio', 'inicio', 1, now()),
('usuario', '/usuario/cadastrar', 'cadastrar', 1, now()),
('usuario', '/usuario/editar', 'editar', 1, now()),
('usuario', '/usuario/excluir', 'excluir', 1, now()),
('acao-usuario', '/acao-usuario/inicio', 'inicio', 1, now()),
('acao-usuario', '/acao-usuario/cadastrar', 'cadastrar', 1, now()),
('acao-usuario', '/acao-usuario/editar', 'editar', 1, now()),
('acao-usuario', '/acao-usuario/excluir', 'excluir', 1, now());
-- Inserts for acao_usuario table
INSERT INTO acao_usuario (id_acao, id_usuario)
SELECT 
	a.id AS id_acao,
	u.id AS id_usuario
FROM 
	acao a, usuario u
WHERE 
	NOT EXISTS (
		SELECT 
			1 
		FROM 
			acao_usuario au
		WHERE 
			au.id_acao = a.id AND 
			au.id_usuario = u.id
	)
ORDER BY 
	a.id, u.id;