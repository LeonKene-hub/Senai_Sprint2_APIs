CREATE DATABASE inlock_games_dbFirst_manha
USE inlock_games_dbFirst_manha

CREATE TABLE Estudio
(
	IdEstudio UNIQUEIDENTIFIER PRIMARY KEY,
	Nome VARCHAR(100) NOT NULL
)

CREATE TABLE Jogo
(
	IdJogo UNIQUEIDENTIFIER PRIMARY KEY,
	IdEstudio UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Estudio(IdEstudio) NOT NULL,
	Nome VARCHAR(100) NOT NULL,
	Descricao VARCHAR(100) NOT NULL,
	DataLancamento DATE NOT NULL,
	Valor SMALLMONEY NOT NULL
)

CREATE TABLE TiposUsuario
(
	IdTipoUsuario UNIQUEIDENTIFIER PRIMARY KEY,
	Titulo VARCHAR(100) NOT NULL
)

CREATE TABLE Usuario
(
	IdUsuario UNIQUEIDENTIFIER PRIMARY KEY,
	IdTipoUsuario UNIQUEIDENTIFIER FOREIGN KEY REFERENCES TiposUsuario(IdTipoUsuario) NOT NULL,
	Email VARCHAR(100) NOT NULL,
	Senha VARCHAR(100) NOT NULL
)

INSERT INTO Estudio
VALUES (NEWID(),'SENAI'),(NEWID(),'SESI'),(NEWID(),'SEBRAI')

SELECT * FROM Estudio

INSERT INTO Jogo
VALUES(NEWID(),'29489E3A-2DB2-474E-B4D2-0F8C2FCA8C62','PING PONG','legal','1880-01-01',500),
	  (NEWID(),'29489E3A-2DB2-474E-B4D2-0F8C2FCA8C62','PEBOLIM','legal DEMAIS','1890-01-01',500)

SELECT * FROM Jogo

INSERT INTO TiposUsuario
VALUES(NEWID(),'adiministrador'),(NEWID(),'comum')

SELECT * FROM TiposUsuario

INSERT INTO Usuario
VALUES(NEWID(),'3181A390-1985-4FE5-B73E-514FD1D2DF6A','adm@adm.com','admin'),(NEWID(),'CB1DF5F5-2116-4C54-AD28-AF56FA7BD28F','comum@comum.com','comum')

SELECT * FROM Usuario