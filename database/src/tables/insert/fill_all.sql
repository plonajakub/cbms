-- Categories --

INSERT INTO Categories (Name)
VALUES ('Food'),
       ('Drinks'),
       ('Entertainment'),
       ('Transport'),
       ('Recruitment'),
       ('Healthcare');

-- Products --

INSERT INTO Products (CategoryID, Name)
VALUES (1, 'Muffins'),
       (1, 'Pork'),
       (2, 'Coca-Cola'),
       (2, 'Botteled Water'),
       (3, 'Gasoline');

-- Departments --

INSERT INTO Departments (Name, Manager)
VALUES ('IT', 'Szymon Filipiak'),
       ('Accountancy', 'Jakub Plona'),
       ('Public Relations', DEFAULT);

-- Business Partners --

INSERT INTO BusinessPartners
    (Name, Address)
VALUES ('AFK', 'Wrocław, Plac Grunwaldzki 10'),
       ('DPD', 'Wrocław, Sienkiewicza 21'),
       ('Nokia', 'Warszawa, Aleja Jana Pawła II 4/2');

-- Funds Packs --

INSERT INTO FundsPacks (DepartmentID, CategoryID, Sum, State)
VALUES (1,5,2000.00,'add'),
       (1,2,123.00,'fin'),
       (2,1,333.00,'add'),
       (3,4,3223.00,'add'),
       (2,4,1222.00,'fin');

-- Invoices --

INSERT INTO Invoices (BusinessPartnerID, FoundsPackID, DepartmentID, Number, IssueDate, Type)
VALUES (1, NULL, 1, 1, GETDATE(), 'out'),
       (2, NULL, 2, 2, GETDATE(), 'out'),
       (3, 3, 1, 3, GETDATE(), 'in'),
       (3, 2, 2, 4, GETDATE(), 'in'),
       (3, 1, 3, 5, GETDATE(), 'out');

-- Invoice Products --

INSERT INTO InvoiceProducts (InvoiceID, ProductID, Quantity, Price)
VALUES (1,1,199,44.43),
       (1,3,2,123.00),
       (3,2,12,11.00),
       (3,1,2,2.00),
       (2,1,23,21.00);

-- History --

INSERT INTO History (InvoiceID, PaymentDate)
VALUES (1, '12-04-2011');

-- Pending --

INSERT INTO Pending (InvoiceID, PaymentDeadline)
VALUES (2, '11-30-2019');