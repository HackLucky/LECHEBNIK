CREATE TABLE Users (
    id_customer INT IDENTITY(1,1) PRIMARY KEY,
    first_name VARCHAR(50),
    second_name VARCHAR(50),
    patronymic VARCHAR(50),
    phone_number VARCHAR(20),
    mail VARCHAR(100),
    password VARCHAR(100),
    recovery_code VARCHAR(100)
);