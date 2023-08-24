CREATE DATABASE Filmes
USE Filmes

CREATE TABLE Genero
(
	IdGenero INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(50) NOT NULL
)

CREATE TABLE Filme
(
	IdFilme INT PRIMARY KEY IDENTITY,
	IdGenero INT FOREIGN KEY REFERENCES Genero(IdGenero) NOT NULL,
	Titulo VARCHAR(50) NOT NULL
)

INSERT INTO Genero (Nome)
VALUES
('Com�dia'),
('A��o'),
('Misterio')

INSERT INTO Filme (IdGenero, Titulo)
VALUES
(2,'Miss�o Impossivel'),
(3, 'Enola Holmes')

SELECT * FROM Genero
SELECT * FROM Filme

DROP DATABASE Filmes