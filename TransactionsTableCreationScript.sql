CREATE TABLE Transactions
(
TransactionId bigInt NOT NULL IDENTITY(1, 1) PRIMARY KEY,
TransactionDate DateTime NOT NULL,
Amount decimal(18,2) NOT NULL,
CurrencyCode varchar(3) NOT NULL,
Status varchar(15) NOT NULL,
CustomerId bigInt NOT NULL,
CONSTRAINT FK_TransactionCustomer FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId),
CONSTRAINT chk_Status CHECK (Status IN ('Success', 'Failed', 'Canceled'))
);