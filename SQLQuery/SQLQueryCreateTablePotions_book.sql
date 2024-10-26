CREATE TABLE Potions_book (
    id_potion INT IDENTITY(1,1) PRIMARY KEY,
    potions_name VARCHAR(100),
    effects TEXT,
    symptoms TEXT,
    cure TEXT
);