CREATE DATABASE AUpets;
USE AUpets;

CREATE TABLE Usuario 
(
	Id  			VARCHAR(300) NOT NULL PRIMARY KEY,
    Nome        	VARCHAR(40) NOT NULL ,
    Senha        	VARCHAR(200) NOT NULL,
    SenhaHash       VARCHAR(200) NOT NULL,
    Email       	VARCHAR(100) NOT NULL,
    Imagem       	VARCHAR(400),
    EAdmin          TINYINT(1) NOT NULL
);

CREATE TABLE Status 
(
	Id 				INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    Nome 			VARCHAR(100) NOT NULL
);


CREATE TABLE Especie 
(
	Id 				TINYINT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    Nome			VARCHAR(30) NOT NULL
);

CREATE TABLE Especializacao 
(
	Id 					SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    Nome				VARCHAR(255) NOT NULL
);

CREATE TABLE Atuacao 
(
	Id 					SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    Nome				VARCHAR(100) NOT NULL
);

CREATE TABLE Prestador 
(
	Id 					INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    RazaoSocial 		VARCHAR(255) NOT NULL,
    NomeFantasia 		VARCHAR(255) NOT NULL,
    TipoPessoa          CHAR(1) NOT NULL,
    CnpjCpf				VARCHAR(18) NOT NULL,
    Endereco 			VARCHAR(255) NOT NULL,
    Complemento			VARCHAR(255),
    Bairro 				VARCHAR(255) NOT NULL,
    Cidade 				VARCHAR(255) NOT NULL,
    Cep					VARCHAR(9),
    Numero				VARCHAR(6) NOT NULL,
    Atuacao				VARCHAR(100),
	Especializacao		VARCHAR(100) NOT NULL,
    Imagem				VARCHAR(400),
    UrlSite				VARCHAR(100),
    StatusId			INT UNSIGNED NOT NULL,
    UsuarioId           VARCHAR(300) NOT NULL,
	CONSTRAINT FK_Prestador_Status	FOREIGN KEY (StatusId)	
		REFERENCES Status(Id),
    CONSTRAINT FK_Prestador_Usuario FOREIGN KEY (UsuarioId)
        REFERENCES Usuario(Id)
);

CREATE TABLE Avaliacoes
(
	Id					INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
	ReviewText			VARCHAR(2000),
    ReviewDate			DATETIME NOT NULL,
    Image 				VARCHAR(400),
    Rating 				TINYINT UNSIGNED NOT NULL,
    UsuarioId			VARCHAR(300) NOT NULL,
    PrestadorId			INT UNSIGNED NOT NULL,
    CONSTRAINT FK_Avaliacoes_Usuario	FOREIGN KEY (UsuarioId)	
		REFERENCES Usuario(Id),
	 CONSTRAINT FK_Avaliacoes_Prestador	FOREIGN KEY (PrestadorId)	
		REFERENCES Prestador(Id)
);

CREATE TABLE EspecializacaoPrestador
(
	Descricao			VARCHAR(255),
    EspecieId			TINYINT UNSIGNED NOT NULL,
	PrestadorId			INT UNSIGNED NOT NULL,
    EspecializacaoId	SMALLINT UNSIGNED NOT NULL,
    PRIMARY KEY (PrestadorId, EspecializacaoId),
    CONSTRAINT FK_EspecializacaoPrestador_Especie FOREIGN KEY (EspecieId)	
		REFERENCES Especie(Id)
);

ALTER TABLE EspecializacaoPrestador ADD CONSTRAINT FK_EspecializacaoPrestador_Prestador
	FOREIGN KEY (PrestadorId) REFERENCES Prestador(Id);
    
ALTER TABLE EspecializacaoPrestador ADD CONSTRAINT FK_EspecializacaoPrestador_Especializacao
	FOREIGN KEY (EspecializacaoId) REFERENCES Especializacao(Id); 
    
CREATE TABLE AtuacaoPrestador 
(
		PrestadorId			INT UNSIGNED NOT NULL,
        AtuacaoId			SMALLINT UNSIGNED NOT NULL
);

ALTER TABLE AtuacaoPrestador ADD CONSTRAINT FK_AtuacaoPrestador_Prestador
	FOREIGN KEY (PrestadorId) REFERENCES Prestador(Id);
    
ALTER TABLE AtuacaoPrestador ADD CONSTRAINT FK_AtuacaoPrestador_Atuacao
	FOREIGN KEY (AtuacaoId) REFERENCES Atuacao(Id);

    












