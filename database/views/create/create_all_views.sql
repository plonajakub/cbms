CREATE VIEW FullInvoices AS
    SELECT I.BusinessPartnerID,
           I.FoundsPackID,
           I.DepartmentID,
           I.Number,
           I.Type,
           I.IssueDate,
           P.PaymentDeadline,
           H.PaymentDate
FROM Invoices I
    LEFT OUTER JOIN Pending P ON I.ID = P.InvoiceID
    LEFT OUTER JOIN History H ON I.ID = H.InvoiceID;