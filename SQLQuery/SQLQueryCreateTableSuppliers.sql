CREATE TABLE Suppliers (
    id_supplier INT IDENTITY(1,1) PRIMARY KEY,
    suppliers_name VARCHAR(100),
    country VARCHAR(50),
    website VARCHAR(100),
    phone_number VARCHAR(20)
);