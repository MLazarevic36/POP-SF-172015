CREATE TABLE TipNamestaja (

	Id INT PRIMARY KEY IDENTITY(1, 1),
	Naziv VARCHAR(80),
	Obrisan BIT
)
GO

CREATE TABLE Namestaj (

	Id INT PRIMARY KEY IDENTITY(1, 1),
	TipNamestajaId INT,
	AkcijaId INT,
	Naziv VARCHAR(100),
	Cena NUMERIC(9,2),
	Raspolozivost INT,
	Obrisan BIT,
	FOREIGN KEY (TipNamestajaId) REFERENCES TipNamestaja(Id)	
	
)