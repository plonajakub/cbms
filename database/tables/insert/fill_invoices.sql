INSERT INTO Invoices (BusinessPartnerID, FoundsPackID, DepartmentID, Number, IssueDate, Type)
VALUES (1, NULL, 1, 1, GETDATE(), 'out'),
       (2, NULL, 2, 2, GETDATE(), 'out'),
       (3, NULL, 3, 3, GETDATE(), 'in');