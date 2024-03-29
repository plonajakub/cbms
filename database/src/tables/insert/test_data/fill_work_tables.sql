INSERT INTO FundsPacks (DepartmentID, CategoryID, Sum, State)
VALUES (1, 5, 2000.00, 'add'),
       (1, 6, 3000.00, 'add'),
       (2, 2, 123.00, 'fin'),
       (2, 4, 1230.00, 'add'),
       (3, 11, 233.00, 'add'),
       (3, 10, 10000.00, 'add'),
       (4, 4, 3223.00, 'add'),
       (4, 6, 223.00, 'fin'),
       (5, 4, 1222.00, 'fin'),
       (5, 7, 2103.00, 'fin');

INSERT INTO Invoices (BusinessPartnerID, FoundsPackID, DepartmentID, Number, IssueDate, Type)
VALUES (1, NULL, 1, 1, '2019-01-03', 'in'),
       (2, NULL, 2, 2, '2019-02-02', 'in'),
       (3, 7, 4, 3, '2019-03-02', 'in'),
       (3, 3, 4, 4, '2019-04-04', 'in'),
       (3, 2, 5, 5, '2019-05-15', 'in'),
       (4, NULL, 1, 6, '2019-06-03', 'in'),
       (4, NULL, 2, 7, '2019-07-05', 'in'),
       (5, 2, 1, 8, '2019-03-02', 'in'),
       (5, 3, 1, 9, '2019-03-02', 'out'),
       (5, 2, 2, 10, '2019-06-04', 'in'),
       (5, 10, 3, 11, '2019-09-15', 'out');

INSERT INTO InvoiceProducts (InvoiceID, ProductID, Quantity, Price)
VALUES (1, 31, 10, 60.43),
       (1, 25, 6, 123.00),
       (2, 23, 40, 11.00),
       (2, 25, 300, 2.02),
       (3, 18, 30, 21.00),
       (3, 19, 10, 60.43),
       (4, 3, 6, 123.02),
       (4, 6, 60, 11.00),
       (5, 3, 300, 2.00),
       (6, 7, 30, 21.54),
       (6, 21, 10, 60.43),
       (7, 3, 6, 123.00),
       (8, 5, 12, 11.24),
       (8, 16, 20, 2.00),
       (9, 27, 4, 21.00),
       (10, 28, 21, 60.43),
       (11, 2, 3, 123.00),
       (11, 19, 60, 11.02),
       (11, 10, 25, 2.05),
       (11, 3, 23, 21.00);

INSERT INTO History (InvoiceID, PaymentDate)
VALUES (1, '2019-01-03'),
       (2, '2019-02-01'),
       (3, '2019-03-02'),
       (4, '2019-04-04'),
       (5, '2019-05-15'),
       (6, '2019-06-03'),
       (7, '2019-07-05');

INSERT INTO Pending (InvoiceID, PaymentDeadline)
VALUES (8, '2020-01-04'),
       (9, '2020-01-13'),
       (10, '2019-01-06'),
       (11, '2019-01-09');
GO