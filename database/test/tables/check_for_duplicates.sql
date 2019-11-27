BEGIN
    IF ((SELECT COUNT(*) FROM (SELECT ID, COUNT(*) as c
        FROM BusinessPartners
        GROUP BY ID
        HAVING COUNT(*) > 1) as I) != 0)
            PRINT 'DUPLICATE DETECTED'

    IF ((SELECT COUNT(*) FROM (SELECT ID, COUNT(*) as c
        FROM Categories
        GROUP BY ID
        HAVING COUNT(*) > 1) as I) != 0)
            PRINT 'DUPLICATE DETECTED'

    IF ((SELECT COUNT(*) FROM (SELECT ID, COUNT(*) as c
        FROM Departments
        GROUP BY ID
        HAVING COUNT(*) > 1) as I) != 0)
            PRINT 'DUPLICATE DETECTED'

    IF ((SELECT COUNT(*) FROM (SELECT ID, COUNT(*) as c
        FROM FundsPacks
        GROUP BY ID
        HAVING COUNT(*) > 1) as I) != 0)
            PRINT 'DUPLICATE DETECTED'

    IF ((SELECT COUNT(*) FROM (SELECT InvoiceID, COUNT(*) as c
        FROM History
        GROUP BY InvoiceID
        HAVING COUNT(*) > 1) as I) != 0)
            PRINT 'DUPLICATE DETECTED'

    IF ((SELECT COUNT(*) FROM (SELECT InvoiceID, ProductID, COUNT(*) as c
        FROM InvoiceProducts
        GROUP BY InvoiceID, ProductID
        HAVING COUNT(*) > 1) as I) != 0)
            PRINT 'DUPLICATE DETECTED'

    IF ((SELECT COUNT(*) FROM (SELECT ID, COUNT(*) as c
        FROM Invoices
        GROUP BY ID
        HAVING COUNT(*) > 1) as I) != 0)
            PRINT 'DUPLICATE DETECTED'

    IF ((SELECT COUNT(*) FROM (SELECT ID, COUNT(*) as c
        FROM Invoices_log
        GROUP BY ID
        HAVING COUNT(*) > 1) as I) != 0)
            PRINT 'DUPLICATE DETECTED'

    IF ((SELECT COUNT(*) FROM (SELECT InvoiceID, COUNT(*) as c
        FROM Pending
        GROUP BY InvoiceID
        HAVING COUNT(*) > 1) as I) != 0)
            PRINT 'DUPLICATE DETECTED'

    IF ((SELECT COUNT(*) FROM (SELECT ID, COUNT(*) as c
        FROM Products
        GROUP BY ID
        HAVING COUNT(*) > 1) as I) != 0)
            PRINT 'DUPLICATE DETECTED'

END