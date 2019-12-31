-- CREATE USER --
CREATE USER app FOR LOGIN app
GO

-- GRANT PERMISSIONS --
-- Tables --
GRANT SELECT, INSERT, UPDATE ON Invoices TO app
GO

GRANT SELECT ON BusinessPartners TO app
GO

GRANT SELECT ON Products TO app
GO

GRANT SELECT ON Departments TO app
GO

GRANT SELECT, INSERT ON History TO app
GO

GRANT SELECT, INSERT, DELETE ON Pending TO app
GO

GRANT SELECT ON Categories TO app
GO

GRANT SELECT, INSERT, UPDATE ON FundsPacks TO app
GO

GRANT SELECT, INSERT, UPDATE, DELETE ON InvoiceProducts TO app
GO

-- Views --
GRANT SELECT ON FullInvoices TO app
GO

GRANT SELECT ON Investments TO app
GO

GRANT SELECT ON Transactions TO app
GO

-- Stored procedures --
GRANT EXECUTE ON areDatesIntegral TO app
GO

GRANT EXECUTE ON invoiceExists TO app
GO