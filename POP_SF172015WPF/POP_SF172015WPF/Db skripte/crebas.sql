CREATE DATABASE SalonNamestaja
GO
USE SalonNamestaja
GO

CREATE TABLE TipNamestaja (

	Id INT PRIMARY KEY IDENTITY(1, 1),
	Naziv VARCHAR(80),
	Obrisan BIT
)
GO


CREATE TABLE Namestaj (

	Id INT PRIMARY KEY IDENTITY(1, 1),
	TipNamestajaId INT not null,
	AkcijaId INT not null,
	Naziv VARCHAR(100),
	Cena INT not null,
	Raspolozivost INT,
	Obrisan BIT,	
	
)
GO

CREATE TABLE Akcija (

	Id INT PRIMARY KEY IDENTITY(1, 1),
	Popust INT not null,
	DatumPocetka DATE,
	DatumZavrsetka DATE,
	Obrisan BIT
)
GO


CREATE TABLE Korisnici (

	Id INT PRIMARY KEY IDENTITY(1, 1),
	KorIme VARCHAR(20),
	Lozinka VARCHAR(100),
	Ime VARCHAR(20),
	Prezime VARCHAR(100),
	TipKorisnika VARCHAR(20),
	Obrisan BIT

)
GO


CREATE TABLE Racuni (

	Id INT PRIMARY KEY IDENTITY(1, 1),
	Kupac VARCHAR(100),
	BrojRacuna INT not null,
	UkupnaCena INT not null,
	DatumProdaje DATE,
	UslugaId INT not null, 
	Obrisan BIT
)
GO

CREATE TABLE DodatneUsluge (

	Id INT PRIMARY KEY IDENTITY(1, 1),
	Naziv VARCHAR(30),
	Cena INT not null,
	Obrisan BIT
)
GO