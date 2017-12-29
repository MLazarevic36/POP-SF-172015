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
	FOREIGN KEY (TipNamestajaId) REFERENCES TipNamestaja(Id),
	FOREIGN KEY (AkcijaId) REFERENCES Akcija(Id)	
	
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