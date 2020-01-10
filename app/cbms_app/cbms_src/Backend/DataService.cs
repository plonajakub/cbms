﻿using System.Linq;


namespace CbmsSrc.Backend
{
    public class DataService
    {
        private readonly CbmsMainDbEntities _context;

        /// <summary>
        /// Provides current EF context.
        /// </summary>
        /// <remarks>
        /// Intended to be used only within DataService;
        /// do not call Dispose() on Context manually.
        /// </remarks>
        public static CbmsMainDbEntities Context => new CbmsMainDbEntities();


        /// <summary>
        /// Default instantiation of class DataService;
        /// use this as a first choice.
        /// </summary>
        public DataService()
        {
            _context = new CbmsMainDbEntities();
        }


        public DataService(CbmsMainDbEntities context)
        {
            _context = context;
        }


        /// <summary>
        /// Disposes _context.
        /// </summary>
        ~DataService()
        {
            _context.Dispose();
        }


        /// <summary>
        /// Saves changes to the database.
        /// </summary>
        /// <remarks>
        /// Must be called to save changes to the database; do it after executing
        /// set of operations on the DB.
        /// </remarks>
        public void SaveToDb() => _context.SaveChanges();


        public void AddInvoice(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="newInvoice">Copy of an existing entity to update with some fields changed</param>
        public void UpdateInvoice(Invoice newInvoice)
        {
            var oldInvoice = _context.Invoices.First(i => i.ID == newInvoice.ID);

            if (!oldInvoice.BusinessPartnerID.Equals(newInvoice.BusinessPartnerID))
            {
                oldInvoice.BusinessPartnerID = newInvoice.BusinessPartnerID;
            }

            if (!oldInvoice.FoundsPackID.Equals(newInvoice.FoundsPackID))
            {
                oldInvoice.FoundsPackID = newInvoice.FoundsPackID;
            }

            if (!oldInvoice.DepartmentID.Equals(newInvoice.DepartmentID))
            {
                oldInvoice.DepartmentID = newInvoice.DepartmentID;
            }

            if (!oldInvoice.Number.Equals(newInvoice.Number))
            {
                oldInvoice.Number = newInvoice.Number;
            }

            if (!oldInvoice.Type.Equals(newInvoice.Type))
            {
                oldInvoice.Type = newInvoice.Type;
            }

            if (!oldInvoice.IssueDate.Equals(newInvoice.IssueDate))
            {
                oldInvoice.IssueDate = newInvoice.IssueDate;
            }
        }


        public void AddInvoiceProduct(InvoiceProduct invoiceProduct)
        {
            _context.InvoiceProducts.Add(invoiceProduct);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="newInvoiceProduct">Copy of an existing entity to update with some fields changed</param>
        public void UpdateInvoiceProduct(InvoiceProduct newInvoiceProduct)
        {
            var oldInvoiceProduct = _context.InvoiceProducts
                    .First(ip =>
                        ip.InvoiceID == newInvoiceProduct.InvoiceID && ip.ProductID == newInvoiceProduct.ProductID);

            if (!oldInvoiceProduct.Quantity.Equals(newInvoiceProduct.Quantity))
            {
                oldInvoiceProduct.Quantity = newInvoiceProduct.Quantity;
            }

            if (!oldInvoiceProduct.Price.Equals(newInvoiceProduct.Price))
            {
                oldInvoiceProduct.Price = newInvoiceProduct.Price;
            }
        }


        public void DeleteInvoiceProduct(int invoiceID, int productID)
        {
            var invoiceProductToDelete = _context.InvoiceProducts
                .First(ip => ip.InvoiceID == invoiceID && ip.ProductID == productID);
            _context.InvoiceProducts.Remove(invoiceProductToDelete);
        }


        public void AddHistory(History history)
        {
            _context.Histories.Add(history);
        }


        public void AddPending(Pending pending)
        {
            _context.Pendings.Add(pending);
        }


        public void DeletePending(int invoiceID)
        {
            var pendingToDelete = _context.Pendings.First(p => p.InvoiceID == invoiceID);
            _context.Pendings.Remove(pendingToDelete);
        }


        public void AddFundsPack(FundsPack fundsPack)
        {
            _context.FundsPacks.Add(fundsPack);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newFundsPack">Copy of an existing entity to update with some fields changed</param>
        public void UpdateFundsPack(FundsPack newFundsPack)
        {
            var oldFundsPack = _context.FundsPacks.First(fp => fp.ID == newFundsPack.ID);

            if (!oldFundsPack.DepartmentID.Equals(newFundsPack.DepartmentID))
            {
                oldFundsPack.DepartmentID = newFundsPack.DepartmentID;
            }

            if (!oldFundsPack.CategoryID.Equals(newFundsPack.CategoryID))
            {
                oldFundsPack.CategoryID = newFundsPack.CategoryID;
            }

            if (!oldFundsPack.Sum.Equals(newFundsPack.Sum))
            {
                oldFundsPack.Sum = newFundsPack.Sum;
            }

            if (!oldFundsPack.State.Equals(newFundsPack.State))
            {
                oldFundsPack.State = newFundsPack.State;
            }
        }

    }
}