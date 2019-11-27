BEGIN
    IF((SELECT COUNT(*) FROM Products WHERE ID  IS NULL) != 0)
        PRINT 'Product.ID NOT NULL: TEST FAILED'

    IF((SELECT COUNT(*) FROM History WHERE InvoiceID  IS NULL) != 0)
        PRINT 'History.InvoiceID NOT NULL: TEST FAILED'

    IF((SELECT COUNT(*) FROM Pending WHERE InvoiceID  IS NULL) != 0)
        PRINT 'Pending.InvoiceID NOT NULL: TEST FAILED'

    IF((SELECT COUNT(*) FROM Invoices WHERE ID  IS NULL) != 0)
        PRINT 'Invoice.ID NOT NULL: TEST FAILED'

    IF((SELECT COUNT(*) FROM Departments WHERE ID  IS NULL) != 0)
        PRINT 'Departments.ID NOT NULL: TEST FAILED'

    IF((SELECT COUNT(*) FROM FundsPacks WHERE ID  IS NULL) != 0)
        PRINT 'FundsPack.ID NOT NULL: TEST FAILED'

    IF((SELECT COUNT(*) FROM InvoiceProducts WHERE InvoiceID  IS NULL) != 0)
        PRINT 'InvoiceProducts.InvoiceID NOT NULL: TEST FAILED'

    IF((SELECT COUNT(*) FROM InvoiceProducts WHERE ProductID  IS NULL) != 0)
        PRINT 'InvoiceProducts.ProductID NOT NULL: TEST FAILED'

    IF((SELECT COUNT(*) FROM BusinessPartners WHERE ID  IS NULL) != 0)
        PRINT 'BusinessPartners.ID NOT NULL: TEST FAILED'

    IF((SELECT COUNT(*) FROM Invoices_log WHERE ID  IS NULL) != 0)
        PRINT 'Invoices_log.ID NOT NULL: TEST FAILED'

    IF((SELECT COUNT(*) FROM Categories WHERE ID  IS NULL) != 0)
        PRINT 'Categories.ID NOT NULL: TEST FAILED'

END