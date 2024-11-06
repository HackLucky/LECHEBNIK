CREATE TABLE Order_details (
    id_order INT,
    id_medicine INT,
    quantity INT NOT NULL,
    price DECIMAL(10, 2) NOT NULL,
    PRIMARY KEY (id_order, id_medicine),
    FOREIGN KEY (id_order) REFERENCES Orders(id_order),
    FOREIGN KEY (id_medicine) REFERENCES Products(id_medicine)
);
