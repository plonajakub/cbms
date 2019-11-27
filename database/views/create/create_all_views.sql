CREATE VIEW FullInvoices AS
SELECT BP.Name AS BusinessPartner,
       I.FoundsPackID,
       D.Name  AS Department,
       I.Number,
       I.Type,
       I.IssueDate,
       P.PaymentDeadline,
       H.PaymentDate
FROM Invoices I
         INNER JOIN BusinessPartners BP ON I.BusinessPartnerID = BP.ID
         INNER JOIN Departments D ON I.DepartmentID = D.ID
         LEFT OUTER JOIN Pending P ON I.ID = P.InvoiceID
         LEFT OUTER JOIN History H ON I.ID = H.InvoiceID;

CREATE VIEW Transactions AS
SELECT D.Name      AS Department,
       BP.Name     AS BusinessPartner,
       C.Name      AS Category,
       I.Type,
       I.IssueDate,
       P.PaymentDeadline,
       H.PaymentDate,
       PD.Name     AS ProductName,
       IP.Quantity AS ProductQuantity,
       IP.Price    AS ProductPrice
FROM InvoiceProducts IP
         INNER JOIN Invoices I ON IP.InvoiceID = I.ID
         INNER JOIN Products PD ON IP.ProductID = PD.ID
         INNER JOIN Departments D ON I.DepartmentID = D.ID
         INNER JOIN BusinessPartners BP ON I.BusinessPartnerID = BP.ID
         INNER JOIN Categories C ON PD.CategoryID = C.ID
         LEFT OUTER JOIN Pending P ON I.ID = P.InvoiceID
         LEFT OUTER JOIN History H ON I.ID = H.InvoiceID;

CREATE VIEW Investments AS
    SELECT D.Name AS Deparment,
           D.Manager,
           C.Name AS Category,
           FP.Sum,
           FP.State
FROM FundsPacks FP
INNER JOIN Categories C on FP.CategoryID = C.ID
INNER JOIN Departments D on FP.DepartmentID = D.ID;