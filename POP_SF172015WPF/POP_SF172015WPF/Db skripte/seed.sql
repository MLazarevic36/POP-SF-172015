INSERT INTO TipNamestaja(Naziv, Obrisan) VALUES ('Krevet', 0);
INSERT INTO TipNamestaja(Naziv, Obrisan) VALUES ('Polica', 0);
INSERT INTO TipNamestaja(Naziv, Obrisan) VALUES ('Kauc', 0);

INSERT INTO Namestaj(TipNamestajaId, AkcijaId, Naziv, Cena, Raspolozivost, Obrisan)
VALUES (1, 2, 'Bracni krevet', 133.5, 36, 0);
INSERT INTO Namestaj(TipNamestajaId, AkcijaId, Naziv, Cena, Raspolozivost, Obrisan)
VALUES (2, 1, 'Polica za knjige', 299.5, 12, 0);
INSERT INTO Namestaj(TipNamestajaId, AkcijaId, Naziv, Cena, Raspolozivost, Obrisan)
VALUES (3, 2, 'Ugaoni kauc', 323.5, 16, 0);

INSERT INTO Akcija(Popust, DatumPocetka, DatumZavrsetka, Obrisan) VALUES (15, '2018-3-2', '2018-6-2', 0);
INSERT INTO Akcija(Popust, DatumPocetka, DatumZavrsetka, Obrisan) VALUES (20, '2018-4-6', '2018-7-6', 0);
INSERT INTO Akcija(Popust, DatumPocetka, DatumZavrsetka, Obrisan) VALUES (18, '2018-8-7', '2018-11-7', 0);


INSERT INTO Korisnici(KorIme, Lozinka, Ime, Prezime, TipKorisnika, Obrisan)
VALUES ('abc', '123', 'Gordon', 'Ramsay', 'ADMIN', 0);
INSERT INTO Korisnici(KorIme, Lozinka, Ime, Prezime, TipKorisnika, Obrisan)
VALUES ('abcd', '1234', 'Alex', 'Jones', 'PRODAVAC', 0);
INSERT INTO Korisnici(KorIme, Lozinka, Ime, Prezime, TipKorisnika, Obrisan)
VALUES ('fgh', '789', 'Tesa', 'Tesanovic', 'ADMIN', 0);