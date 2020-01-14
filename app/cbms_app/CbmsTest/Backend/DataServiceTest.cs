﻿using System;
using System.Data.Entity;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CbmsSrc.Backend;
using CbmsSrc;
using Moq;

namespace CbmsTest.Backend
{
    [TestClass]
    public class DataServiceTest
    {
        private DataService _dataService;

        [TestInitialize]
        public void ReinitializeDataService() => _dataService = new DataService();

        [TestMethod]
        public void Test_Mock_AddInvoice()
        {
            var mockSet = new Mock<DbSet<Invoice>>();

            var mockContext = new Mock<CbmsMainDbEntities>();
            mockContext.Setup(m => m.Invoices).Returns(mockSet.Object);

            var service = new DataService(mockContext.Object);
            service.AddInvoice(new Invoice()
            {
                BusinessPartnerID = 1,
                DepartmentID = 2,
                Number = 3,
                Type = InvoiceType.In,
                IssueDate = DateTime.Now
            });
            service.SaveToDb();

            mockSet.Verify(m => m.Add(It.IsAny<Invoice>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }


        [TestMethod]
        public void Test_GetAllProducts()
        {
            var allProducts = _dataService.GetAllProducts();
            Assert.IsNotNull(allProducts);
        }

        [TestMethod]
        public void Test_GetCurrentAccountBalance_AlternateCalculations()
        {
            var actualBalance = _dataService.GetCurrentAccountBalance();
            decimal expectedBalance = 0;

            var invoiceProductsAll = DataService.Context.InvoiceProducts.ToList();

            foreach (var invoiceProduct in invoiceProductsAll)
            {
                if (invoiceProduct.Invoice.History == null) 
                    continue;
                if (invoiceProduct.Invoice.Type == InvoiceType.In)
                {
                    expectedBalance += invoiceProduct.Quantity * invoiceProduct.Price;
                }
                else if (invoiceProduct.Invoice.Type == InvoiceType.Out)
                {
                    expectedBalance -= invoiceProduct.Quantity * invoiceProduct.Price;
                }
                else
                {
                    throw new Exception();
                }
            }

            Assert.AreEqual(expectedBalance, actualBalance);
            Assert.AreNotEqual(0, actualBalance);
        }
    }
}
