-- log_invoices
CREATE TRIGGER log_invoices
    ON Invoices
    AFTER INSERT, UPDATE, DELETE
    AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Invoices_log
    (OperationDate,
     OperationType,
     ID,
     BusinessPartnerID,
     FoundsPackID,
     DepartmentID,
     Number,
     IssueDate,
     Type)

    SELECT GETDATE(), 'INS', *
    FROM inserted
    UNION ALL
    SELECT GETDATE(), 'DEL', *
    FROM deleted
END

