CREATE TABLE HRBaza (
    ID varchar(10) NOT NULL PRIMARY KEY,
    UmowaTyp varchar(30) NOT NULL,
	UmowaStart date NOT NULL,
	UmowaKoniec date NOT NULL,
	UmowaStatus varchar(20) NOT NULL,
	Imie varchar(30) NOT NULL,
    DrugieImie varchar(30),
    Nazwisko varchar(30) NOT NULL,
	Pesel varchar(20) NOT NULL,
	TelefonKontaktowy varchar(20),
	PrywatnyEmail varchar(50),
	Manager varchar(10),
    Stanowisko varchar(90) NOT NULL,
    Departament varchar(30) NOT NULL,
	FOREIGN KEY (Manager) REFERENCES HRBaza(ID)
) 