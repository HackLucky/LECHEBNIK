CREATE TABLE Orders (
    id_sale INT IDENTITY(1,1) PRIMARY KEY,
    id_customer INT,
    id_medicine INT,
    order_date DATE,
    quantity INT,
    final_price DECIMAL(10, 2),
    id_method INT,
    FOREIGN KEY (id_customer) REFERENCES Users(id_customer),
    FOREIGN KEY (id_medicine) REFERENCES Products(id_medicine),
    FOREIGN KEY (id_method) REFERENCES Payment_methods(id_method)
);