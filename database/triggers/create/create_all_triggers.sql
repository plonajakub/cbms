-- log_invoices
CREATE TRIGGER log_invoices
    ON Invoices
    AFTER INSERT, UPDATE, DELETE
    AS
BEGIN
    DECLARE @operationID INT;
    SELECT @operationID = MAX(OperationID) FROM Invoices_log;
    IF @operationID IS NULL
        BEGIN
            SET @operationID = 0;
        END
    SET @operationID = @operationID + 1;

    SET NOCOUNT ON;

    INSERT INTO Invoices_log
    (OperationID,
     OperationDate,
     OperationType,
     InvoiceID,
     BusinessPartnerID,
     FoundsPackID,
     DepartmentID,
     Number,
     Type,
     IssueDate)

    SELECT @operationID, GETDATE(), 'INS', *
    FROM inserted
    UNION ALL
    SELECT @operationID, GETDATE(), 'DEL', *
    FROM deleted
END

