CREATE TABLE Payment_methods (
    id_method INT IDENTITY(1,1) PRIMARY KEY,
    methods_name VARCHAR(255),
    description TEXT
);