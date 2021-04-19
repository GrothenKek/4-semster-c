DROP TABLE IF EXISTS Pets;
DROP TABLE IF EXISTS Persons;

CREATE TABLE Persons (
    ID int NOT NULL PRIMARY KEY,
    Name      varchar(255) NOT NULL,
    Age       int,
    Weight    int,
    Score     int
);

INSERT INTO Persons VALUES (1,'Jeannette',  26,  72,  4);
INSERT INTO Persons VALUES (2,'Octavio',    45,  45,  0);
INSERT INTO Persons VALUES (3,'Claudio',    50,  20,  7);
INSERT INTO Persons VALUES (4,'Kristina',   85,  81, 10);
INSERT INTO Persons VALUES (5,'Krista',     10,  74,  2);
INSERT INTO Persons VALUES (6,'Eleanora',   71,   8,  6);
INSERT INTO Persons VALUES (7,'Jim',        70,  11,  3);
INSERT INTO Persons VALUES (8,'Wyatt',      15,  72,  6);
INSERT INTO Persons VALUES (9,'Vida',       41,  17,  6);
INSERT INTO Persons VALUES (10,'Margot',     85,  12,  0);
INSERT INTO Persons VALUES (11,'Mallory',    83,  63,  0);
INSERT INTO Persons VALUES (12,'Coy',        84,  79,  7);
INSERT INTO Persons VALUES (13,'Rolland',    19,  89,  6);
INSERT INTO Persons VALUES (14,'Fernando',   97,  89,  6);
INSERT INTO Persons VALUES (15,'Elvera',     47,  25,  1);
INSERT INTO Persons VALUES (16,'Lorette',    49,  23,  3);
INSERT INTO Persons VALUES (17,'Edison',     83, 100,  5);
INSERT INTO Persons VALUES (18,'Elden',      56,  99,  4);
INSERT INTO Persons VALUES (19,'Dell',       75,  14,  4);
INSERT INTO Persons VALUES (20,'Julio',      89,  89,  0);


CREATE TABLE Pets (
    ID int NOT NULL PRIMARY KEY,
    owner_id  int FOREIGN KEY REFERENCES Persons(ID) ON DELETE CASCADE,
    Name      varchar(255) NOT NULL,
    Age       int,
    Weight    int,
    Species   varchar(255) NOT NULL
);

INSERT INTO Pets VALUES (1, 3, 'Fido',      8, 32, 'Dog');
INSERT INTO Pets VALUES (2, 1, 'Rolf',      2, 15, 'Dog');
INSERT INTO Pets VALUES (3, 6, 'Cujo',     12, 61, 'Dog');
INSERT INTO Pets VALUES (4, 7, 'Garfield',  4, 23, 'Cat');
INSERT INTO Pets VALUES (5, 2, 'Pete',      9,  8, 'Cat');
INSERT INTO Pets VALUES (6,15, 'Cesar',     1,  4, 'Cat');
