-- Check if date1 is after date2 --
CREATE FUNCTION isAfter(@date1 date, @date2 date) RETURNS bit
BEGIN
    IF (@date1 > @date2)
        RETURN 1
    RETURN 0
END
GO