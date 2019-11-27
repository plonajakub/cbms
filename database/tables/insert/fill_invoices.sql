INSERT INTO Invoices (BusinessPartnerID, FoundsPackID, DepartmentID, Number, IssueDate, Type)
VALUES (1, NULL, 1, 1, GETDATE(), 'out'),
       (2, NULL, 2, 2, GETDATE(), 'out'),
       (3, 3, 1, 3, GETDATE(), 'in'),
       (3, 2, 2, 4, GETDATE(), 'in'),
       (3, 1, 3, 5, GETDATE(), 'out');