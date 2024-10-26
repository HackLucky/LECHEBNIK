CREATE TABLE Diseases_book (
    id_disease INT IDENTITY(1,1) PRIMARY KEY,
    diseases_name VARCHAR(100),
    symptoms TEXT,
    cure TEXT
);