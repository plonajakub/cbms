-- Check if date1 is after date2
CREATE FUNCTION isAfter(@date1 DATE, @date2 DATE)
    RETURNS BIT
AS
BEGIN
    IF (@date1 > @date2)
        RETURN 1
    RETURN 0
END
GO

-- Check if invoice with given number and date exists
CREATE FUNCTION invoiceExists(@invoiceNumber INT, @invoiceDate DATE)
    RETURNS BIT
AS
BEGIN
    IF (EXISTS(SELECT ID
               FROM Invoices I
               WHERE I.Number = @invoiceNumber
                 AND I.IssueDate = @invoiceDate))
        RETURN 1
    RETURN 0
END
GO

-- Checks if invoice dates are integral
CREATE FUNCTION areDatesIntegral(@invoiceID INT)
    RETURNS BIT
AS
BEGIN
    DECLARE @iDate DATE, @pDate DATE, @hDate DATE

    SELECT @iDate = IssueDate
    FROM Invoices
    WHERE ID = @invoiceID;

    SELECT @pDate = PaymentDeadline
    FROM Pending
    WHERE InvoiceID = @invoiceID;

    SELECT @hDate = PaymentDate
    FROM History
    WHERE InvoiceID = @invoiceID;

    IF (@iDate IS NOT NULL AND @pDate IS NOT NULL AND @iDate > @pDate)
        RETURN 0
    IF (@iDate IS NOT NULL AND @hDate IS NOT NULL AND @iDate > @hDate)
        RETURN 0
    RETURN 1
END
GO