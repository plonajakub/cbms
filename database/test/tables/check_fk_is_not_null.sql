BEGIN
    IF((SELECT COUNT(*) FROM Invoices WHERE DepartmentID  IS NULL) != 0)
        PRINT 'Invoices.DepartmentID NOT NULL: TEST FAILED'
    
    IF((SELECT COUNT(*) FROM Invoices WHERE BusinessPartnerID  IS NULL) != 0)
        PRINT 'Invoices.BusinessPartnerID NOT NULL: TEST FAILED'
    
    IF((SELECT COUNT(*) FROM FundsPacks WHERE DepartmentID  IS NULL) != 0)
        PRINT 'FundsPacks.DepartmentID NOT NULL: TEST FAILED'
    
    IF((SELECT COUNT(*) FROM FundsPacks WHERE CategoryID  IS NULL) != 0)
        PRINT 'FundsPacks.CategoryID NOT NULL: TEST FAILED'
    
    IF((SELECT COUNT(*) FROM Products WHERE CategoryID  IS NULL) != 0)
        PRINT 'Products.CategoryID NOT NULL: TEST FAILED'
END