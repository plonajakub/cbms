using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CbmsSrc.Backend
{
    public class DataManager
    {
        /// <summary>
        /// Provides current EF context.
        /// </summary>
        /// <remarks>Must be disposed.</remarks>
        public static CbmsMainDbEntities Context => new CbmsMainDbEntities();

        /// <summary>
        /// Saves changes to the database.
        /// </summary>
        /// <param name="context">EF current context</param>
        /// <remarks>
        /// Must be called to save changes to the database; do it after executing
        /// set of operations on the DB.
        /// </remarks>
        public static void SaveToDb(CbmsMainDbEntities context) => context.SaveChanges();


        public static void AddInvoice(CbmsMainDbEntities context, Invoice invoice)
        {
            context.Invoices.Add(invoice);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="newInvoice">Copy of an existing entity to update with some fields changed</param>
        public static void UpdateInvoice(CbmsMainDbEntities context, Invoice newInvoice)
        {
            var oldInvoice = context.Invoices.First(i => i.ID == newInvoice.ID);

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


        public static void DeleteInvoice(CbmsMainDbEntities context, int invoiceID)
        {
            var invoiceToDelete = context.Invoices.First(i => i.ID == invoiceID);
            context.Invoices.Remove(invoiceToDelete);
        }


        public static void AddInvoiceProduct(CbmsMainDbEntities context, InvoiceProduct invoiceProduct)
        {
            context.InvoiceProducts.Add(invoiceProduct);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="newInvoiceProduct">Copy of an existing entity to update with some fields changed</param>
        public static void UpdateInvoiceProduct(CbmsMainDbEntities context, InvoiceProduct newInvoiceProduct)
        {
            var oldInvoiceProduct = context.InvoiceProducts
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


        public static void DeleteInvoiceProduct(CbmsMainDbEntities context, int invoiceID, int productID)
        {
            var invoiceProductToDelete = context.InvoiceProducts
                .First(ip => ip.InvoiceID == invoiceID && ip.ProductID == productID);
            context.InvoiceProducts.Remove(invoiceProductToDelete);
        }
    }
}
