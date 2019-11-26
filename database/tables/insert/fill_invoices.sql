INSERT INTO Invoices (BusinessPartnerID, FoundsPackID, DepartmentID, Number, IssueDate, Type)
VALUES (1, NULL, 1, 1, GETDATE(), 'outcoming'),
       (2, NULL, 2, 2, GETDATE(), 'outcoming'),
       (3, NULL, 3, 3, GETDATE(), 'incoming');