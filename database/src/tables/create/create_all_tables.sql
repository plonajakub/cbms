-- SCRIPT: ALL DATABASE'S TABLES CREATION

-- BusinessPartners
CREATE TABLE BusinessPartners
(
    ID      INT IDENTITY (1, 1) PRIMARY KEY,
    Name    NVARCHAR(100) NOT NULL UNIQUE,
    Address NVARCHAR(100) NOT NULL
);


-- Departments
CREATE TABLE Departments
(
    ID      INT IDENTITY (1, 1) PRIMARY KEY,
    Name    NVARCHAR(50) NOT NULL UNIQUE,
    Manager NVARCHAR(50) NOT NULL DEFAULT ('Ochódzki Ryszard')
);

-- Categories
CREATE TABLE Categories
(
    ID   INT IDENTITY (1, 1) PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL UNIQUE
);

-- Products
CREATE TABLE Products
(
    ID         INT IDENTITY (1, 1) PRIMARY KEY,
    CategoryID INT          NOT NULL,
    Name       NVARCHAR(50) NOT NULL UNIQUE,

    FOREIGN KEY (CategoryID) REFERENCES Categories (ID)
);


-- FundsPacks
CREATE TABLE FundsPacks
(
    ID           INT IDENTITY (1, 1) PRIMARY KEY,
    DepartmentID INT        NOT NULL,
    CategoryID   INT        NOT NULL,
    Sum          MONEY      NOT NULL CHECK (sum > 0),
    State        VARCHAR(3) NOT NULL CHECK (state IN ('add', 'fin'))
        FOREIGN KEY (DepartmentID) REFERENCES Departments (ID),
    FOREIGN KEY (CategoryID) REFERENCES Categories (ID)
);


-- Invoices
CREATE TABLE Invoices
(
    ID                INT IDENTITY (1, 1) PRIMARY KEY,
    BusinessPartnerID INT        NOT NULL,
    FoundsPackID      INT,
    DepartmentID      INT        NOT NULL,
    Number            INT        NOT NULL CHECK (number > 0),
    Type              VARCHAR(3) NOT NULL CHECK (type IN ('in', 'out')),
    IssueDate         DATE       NOT NULL,

    FOREIGN KEY (BusinessPartnerID) REFERENCES BusinessPartners (ID),
    FOREIGN KEY (FoundsPackID) REFERENCES FundsPacks (ID),
    FOREIGN KEY (DepartmentID) REFERENCES Departments (ID)
);


-- History
CREATE TABLE History
(
    InvoiceID   INT PRIMARY KEY,
    PaymentDate DATE NOT NULL,

    FOREIGN KEY (InvoiceID) REFERENCES Invoices (ID)
);


-- Pending
CREATE TABLE Pending
(
    InvoiceID       INT PRIMARY KEY,
    PaymentDeadline DATE NOT NULL,

    FOREIGN KEY (InvoiceID) REFERENCES Invoices (ID)
);


-- InvoiceProducts
CREATE TABLE InvoiceProducts
(
    InvoiceID INT,
    ProductID INT,
    Quantity  INT   NOT NULL CHECK (quantity > 0),
    Price     MONEY NOT NULL CHECK (price >= 0),

    PRIMARY KEY (InvoiceID, ProductID),
    FOREIGN KEY (InvoiceID) REFERENCES Invoices (ID),
    FOREIGN KEY (ProductID) REFERENCES Products (ID)
);


--------------------------------------
------- Helper tables ----------------
--------------------------------------

-- Invoices_log
CREATE TABLE Invoices_log
(
    ID                INT IDENTITY (1, 1) PRIMARY KEY,
    OperationID       INT        NOT NULL CHECK (OperationID > 0),
    OperationDate     DATETIME2  NOT NULL,
    OperationType     CHAR(3) NOT NULL CHECK (OperationType IN ('INS', 'DEL')),

    InvoiceID         INT,
    BusinessPartnerID INT,
    FoundsPackID      INT,
    DepartmentID      INT,
    Number            INT,
    Type              VARCHAR(3),
    IssueDate         DATE
);