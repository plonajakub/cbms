BEGIN
    DECLARE @date1 DATE, @date2 DATE
    SET @date1 = CONVERT(DATE, '27/11/2019', 103)
    SET @date2 = CONVERT(DATE, '28/11/2019', 103)

    IF (main.dbo.isAfter(@date1, @date2) = 1)
        PRINT 'isAfter: TEST FAILED'

    IF (main.dbo.invoiceExists(1, @date1) = 0)
        PRINT 'invoiceExists: TEST FAILED'

    IF (main.dbo.invoiceExists(1, @date2) = 1)
        PRINT 'invoiceExists: TEST FAILED'

    IF(main.dbo.areDatesIntegral(1) = 0)
        PRINT 'areDatesIntegral: TEST FAILED'
END
GO
