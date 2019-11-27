BEGIN
    -- Check Invoice - History --
    IF ((SELECT Number FROM Invoices WHERE ID = 1)
        != (SELECT I.Number FROM History
            JOIN Invoices I on History.InvoiceID = I.ID
            WHERE I.ID = 1))
    PRINT 'Invoice - History: TEST FAILED'

    -- Check Invoice - Pending --
    IF ((SELECT Number FROM Invoices WHERE ID = 2)
        != (SELECT I.Number FROM Pending
            JOIN Invoices I on Pending.InvoiceID = I.ID
            WHERE I.ID = 2))
    PRINT 'Invoice - Pending: TEST FAILED'

        -- Check Invoice - Invoice Products --
    IF ((SELECT Number FROM Invoices WHERE ID = 1)
        != (SELECT DISTINCT I.Number FROM InvoiceProducts
            JOIN Invoices I on InvoiceProducts.InvoiceID = I.ID
            WHERE I.ID = 1))
    PRINT 'Invoice - InvoiceProducts: TEST FAILED'


    -- Check Invoice - Business Partners --
    IF ((SELECT Number FROM Invoices WHERE ID = 1)
        != (SELECT I.Number FROM BusinessPartners
            JOIN Invoices I on BusinessPartners.ID = I.BusinessPartnerID
            WHERE I.ID = 1))
    PRINT 'Invoice - BusinessPartners: TEST FAILED'


    -- Check Invoice - Departments --
    IF ((SELECT Number FROM Invoices WHERE ID = 1)
        != (SELECT I.Number FROM Departments
            JOIN Invoices I on Departments.ID = I.DepartmentID
            WHERE I.ID = 1))
    PRINT 'Invoice - Departments: TEST FAILED'


    -- Check Invoice - Funds Packs --
    IF ((SELECT Number FROM Invoices WHERE ID = 1)
        != (SELECT I.Number FROM FundsPacks
            JOIN Invoices I on FundsPacks.ID = I.FoundsPackID
            WHERE I.ID = 1))
    PRINT 'Invoice - FundsPacks: TEST FAILED'


    -- Check Funds Packs - Departments --

    IF ((SELECT Sum FROM FundsPacks WHERE ID = 1)
        != (SELECT FP.Sum FROM Departments
            JOIN FundsPacks FP on Departments.ID = FP.DepartmentID
            WHERE FP.ID = 1))
        PRINT 'FundsPacks - Departments: TEST FAILED'

    -- Check Funds Packs - Categories --

    IF ((SELECT Sum FROM FundsPacks WHERE ID = 1)
        != (SELECT FP.Sum FROM Categories
            JOIN FundsPacks FP on Categories.ID = FP.CategoryID
            WHERE FP.ID = 1))
        PRINT 'FundsPacks - Categories: TEST FAILED'

    -- Check Funds Packs - Categories --

    IF ((SELECT Name FROM Categories WHERE ID = 1)
        != (SELECT DISTINCT C.Name FROM Products
            JOIN Categories C on Products.CategoryID = C.ID
            WHERE C.ID = 1))
        PRINT 'Products - Categories: TEST FAILED'
END
GO
