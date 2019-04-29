CREATE TABLE Customers
(
CustomerId bigInt NOT NULL IDENTITY(1, 1) PRIMARY KEY,
CustomerName varchar(30) NOT NULL,
Email varchar(25) NOT NULL,
MobileNumber bigInt NOT NULL,
CONSTRAINT chk_CustomerIdNumerics CHECK (CustomerId between 0 and 9999999999),
CONSTRAINT chk_MobileNumberNumerics CHECK (MobileNumber between 0 and 9999999999)
);
GO

INSERT INTO Customers (CustomerName, Email, MobileNumber) 
VALUES ('Nick Jonas', 'jonas@gmail.com', 0443541111)

INSERT INTO Customers (CustomerName, Email, MobileNumber) 
VALUES ('Thomas Anderson', 'anderson@gmail.com', 0443541112)

INSERT INTO Customers (CustomerName, Email, MobileNumber) 
VALUES ('Stephen Jonas', 'jonas@gmail.com', 0443541113)

INSERT INTO Customers (CustomerName, Email, MobileNumber) 
VALUES ('Annet Johnson', 'johnson@gmail.com', 0443541115)
GO

CREATE TABLE Transactions
(
TransactionId bigInt NOT NULL IDENTITY(1, 1) PRIMARY KEY,
TransactionDate DateTime NOT NULL,
Amount decimal(18,2) NOT NULL,
CurrencyCode varchar(3) NOT NULL,
Status varchar(15) NOT NULL,
CustomerId bigInt NOT NULL,
CONSTRAINT FK_TransactionCustomer FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId) ON DELETE CASCADE,
CONSTRAINT chk_Status CHECK (Status IN ('Success', 'Failed', 'Canceled'))
);
GO

INSERT INTO Transactions (TransactionDate, Amount, CurrencyCode, Status, CustomerId) 
VALUES (GETDATE(), 300, 'USD', 'Success', (SELECT TOP(1) CustomerId FROM Customers WHERE CustomerName = 'Nick Jonas'))

INSERT INTO Transactions (TransactionDate, Amount, CurrencyCode, Status, CustomerId) 
VALUES (GETDATE(), 10000, 'USD', 'Success', (SELECT TOP(1) CustomerId FROM Customers WHERE CustomerName = 'Nick Jonas'))

INSERT INTO Transactions (TransactionDate, Amount, CurrencyCode, Status, CustomerId) 
VALUES (GETDATE(), 10, 'EUR', 'Success', (SELECT TOP(1) CustomerId FROM Customers WHERE CustomerName = 'Thomas Anderson'))

INSERT INTO Transactions (TransactionDate, Amount, CurrencyCode, Status, CustomerId) 
VALUES (GETDATE(), 5000, 'USD', 'Success', (SELECT TOP(1) CustomerId FROM Customers WHERE CustomerName = 'Stephen Jonas'))

INSERT INTO Transactions (TransactionDate, Amount, CurrencyCode, Status, CustomerId) 
VALUES (GETDATE(), 100000, 'USD', 'Success', (SELECT TOP(1) CustomerId FROM Customers WHERE CustomerName = 'Stephen Jonas'))

INSERT INTO Transactions (TransactionDate, Amount, CurrencyCode, Status, CustomerId) 
VALUES (GETDATE(), 1, 'USD', 'Success', (SELECT TOP(1) CustomerId FROM Customers WHERE CustomerName = 'Stephen Jonas'))
GO