CREATE TABLE Customers
(
CustomerId bigInt NOT NULL IDENTITY(1, 1) PRIMARY KEY,
CustomerName varchar(30) NOT NULL,
Email varchar(25) NOT NULL,
MobileNumber bigInt NOT NULL,
CONSTRAINT chk_CustomerIdNumerics CHECK (CustomerId between 0 and 9999999999),
CONSTRAINT chk_MobileNumberNumerics CHECK (MobileNumber between 0 and 9999999999)
);