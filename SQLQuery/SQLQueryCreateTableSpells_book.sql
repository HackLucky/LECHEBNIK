CREATE TABLE Spells_book (
    id_spell INT IDENTITY(1,1) PRIMARY KEY,
    spells_name VARCHAR(100),
    effects TEXT,
    symptoms TEXT,
    cure TEXT
);