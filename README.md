# CarteiraDigitalAPI

Procedimento para instalacao
```
baixar a imagem do Postgres
Comando:
docker pull postgres
conferir se o download foi efetuado
Comando:
docker images
```

criar uma pasta com o nome database no diretório `/tmp/database`

banco de dados rodando em um container e gravando os dados na máquina.
```
docker run -p 5432:5432 -v /tmp/database:/var/lib/postgresql/data -e POSTGRES_PASSWORD=97661412 -d postgres

conferir se o container 
docker ps
```

Criar banco de dados
```
CREATE DATABASE CarteiraDigital;

comando criar tabelas
CREATE TABLE Role (
    Id SERIAL PRIMARY KEY,
    Nome VARCHAR(50) NOT NULL
);

//inserir grupos de usuario
INSERT INTO public."role"
(id, nome)
VALUES(nextval('role_id_seq'::regclass), 'admin');
INSERT INTO public."role"
(id, nome)
VALUES(nextval('role_id_seq'::regclass), 'usuario');


CREATE TABLE Cliente (
    Id SERIAL PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Sobrenome VARCHAR(100) NOT NULL,
    Email VARCHAR(150) UNIQUE NOT NULL,
    DataCadastro TIMESTAMP NOT NULL,
    Ativo BOOLEAN NOT NULL,
    PasswordHash VARCHAR(255),
    Slug VARCHAR(100),
    RolesId INT NOT NULL,
    CONSTRAINT fk_cliente_role FOREIGN KEY (RolesId) REFERENCES Role(Id) ON DELETE CASCADE
);

//inserindo usuario1
INSERT INTO public.cliente
(id, nome, sobrenome, email, datacadastro, ativo, passwordhash, slug, rolesid)
VALUES(nextval('cliente_id_seq'::regclass), 'usuario1', 'usuario1', 'usuario1@example.com', now(), true, '10000.K76uqIdRrcXKkzG/lvNz2g==.MboX+y82aSlJf2jCle4iZ2d5je2bQzNt+/a4xY807sY=', 'admin-example-com', 1);

INSERT INTO public.carteira
(id, numerocarteira, datacriacao, situacao, saldo, clienteid)
VALUES(nextval('carteira_id_seq'::regclass), '96523', now(), 'ativa', 9685.44, //pegar o id do usuario inserido acima);

//inserindo usuario2
INSERT INTO public.cliente
(id, nome, sobrenome, email, datacadastro, ativo, passwordhash, slug, rolesid)
VALUES(nextval('cliente_id_seq'::regclass), 'usuario2', 'usuario2', 'usuario2@example.com', now(), true, '10000.K76uqIdRrcXKkzG/lvNz2g==.MboX+y82aSlJf2jCle4iZ2d5je2bQzNt+/a4xY807sY=', 'admin-example-com', 1);

INSERT INTO public.carteira
(id, numerocarteira, datacriacao, situacao, saldo, clienteid)
VALUES(nextval('carteira_id_seq'::regclass), '96524', now(), 'ativa', 9685.44, //pegar o id do usuario inserido acima);

CREATE TABLE Carteira (
    Id SERIAL PRIMARY KEY,
    NumeroCarteira VARCHAR(50) NOT NULL,
    DataCriacao DATE NOT NULL,
    Situacao VARCHAR(20) NOT NULL,
    Saldo NUMERIC(15,2) NOT NULL,
    ClienteId INT NOT NULL,
    CONSTRAINT fk_carteira_cliente FOREIGN KEY (ClienteId) REFERENCES Cliente(Id) ON DELETE CASCADE
);

CREATE TABLE Transacao (
    Id SERIAL PRIMARY KEY,
    DataOperacao TIMESTAMP NOT NULL,
    TipoOperacao VARCHAR(50) NOT NULL,
    ValorOperacao NUMERIC(15,2) NOT NULL,
    CarteiraSacadoId INT NULL,
    CarteiraCedenteId INT NULL,
    CONSTRAINT fk_transacao_sacado FOREIGN KEY (CarteiraSacadoId) REFERENCES Carteira(Id) ON DELETE CASCADE,
    CONSTRAINT fk_transacao_cedente FOREIGN KEY (CarteiraCedenteId) REFERENCES Carteira(Id) ON DELETE CASCADE
);
```