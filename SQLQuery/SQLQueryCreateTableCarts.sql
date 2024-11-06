CREATE TABLE Carts (
    id_cart INT PRIMARY KEY,
    id_customer INT,
    id_medicine INT,
    quantity INT NOT NULL,
    FOREIGN KEY (id_customer) REFERENCES Users(id_customer),
    FOREIGN KEY (id_medicine) REFERENCES Products(id_medicine)
);
