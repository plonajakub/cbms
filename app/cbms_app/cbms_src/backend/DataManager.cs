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

        public static CbmsMainDbEntities Context => new CbmsMainDbEntities();

        public static void SaveToDb(CbmsMainDbEntities context) => context.SaveChanges();


        public void AddInvoice(CbmsMainDbEntities context, Invoice invoice)
        {
            context.Invoices.Add(invoice);
        }


        public void UpdateInvoice(CbmsMainDbEntities context, Invoice newInvoice)
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


        public void DeleteInvoice(CbmsMainDbEntities context, int invoiceID)
        {
            var invoiceToDelete = context.Invoices.First(i => i.ID == invoiceID);
            context.Invoices.Remove(invoiceToDelete);
        }


        public void AddInvoiceProduct(CbmsMainDbEntities context, InvoiceProduct invoiceProduct)
        {
            context.InvoiceProducts.Add(invoiceProduct);
        }


        public void UpdateInvoiceProduct(CbmsMainDbEntities context, InvoiceProduct newInvoiceProduct)
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


        public void DeleteInvoiceProduct(CbmsMainDbEntities context, int invoiceID, int productID)
        {
            var invoiceProductToDelete = context.InvoiceProducts
                .First(ip => ip.InvoiceID == invoiceID && ip.ProductID == productID);
            context.InvoiceProducts.Remove(invoiceProductToDelete);
        }
    }
}
