DELETE
FROM History
WHERE InvoiceID != 0;

DISABLE TRIGGER delete_pending ON Pending;

DELETE
FROM Pending
WHERE InvoiceID != 0;

ENABLE TRIGGER delete_pending ON Pending;

DELETE
FROM InvoiceProducts
WHERE InvoiceID != 0;

DELETE
FROM Invoices
WHERE ID != 0;

DELETE
FROM FundsPacks
WHERE ID != 0;

DBCC CHECKIDENT ('FundsPacks', RESEED, 0);

DBCC CHECKIDENT ('Invoices', RESEED, 0);

GO
