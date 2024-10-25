CREATE TABLE Products (
    id_medicine INT PRIMARY KEY,
    products_name VARCHAR(100),
    id_reason INT,
    id_taking INT,
    id_state INT,
    id_type INT,
    id_supplier INT,
    cost DECIMAL(10, 2),
    FOREIGN KEY (id_taking) REFERENCES Taking_types(id_taking),
    FOREIGN KEY (id_type) REFERENCES Products_type(id_type),
    FOREIGN KEY (id_supplier) REFERENCES Suppliers(id_supplier),
    FOREIGN KEY (id_state) REFERENCES Product_conditions_type(id_state)
);