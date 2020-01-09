using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CbmsSrc.Backend
{
    public class DataManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="invoice">New Invoice object to insert into database</param>
        public void AddInvoice(Invoice invoice)
        {
            using (var ctx = new CbmsMainDbEntities())
            {
                ctx.Invoices.Add(invoice);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="newInvoice">Existing in database object with some properties modified</param>
        public void UpdateInvoice(Invoice newInvoice)
        {
            using (var ctx = new CbmsMainDbEntities())
            {
                var oldInvoice = ctx.Invoices.First(i => i.ID == newInvoice.ID);

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

                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="invoiceID">ID of existing in database invoice</param>
        public void DeleteInvoice(int invoiceID)
        {
            using (var ctx = new CbmsMainDbEntities())
            {
                var invoiceToDelete = ctx.Invoices.First(i => i.ID == invoiceID);
                ctx.Invoices.Remove(invoiceToDelete);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="invoiceProduct">New InvoiceProduct object to insert into database</param>
        public void AddInvoiceProduct(InvoiceProduct invoiceProduct)
        {
            using (var ctx = new CbmsMainDbEntities())
            {
                ctx.InvoiceProducts.Add(invoiceProduct);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newInvoiceProduct">Existing in database object with some properties modified</param>
        public void UpdateInvoiceProduct(InvoiceProduct newInvoiceProduct)
        {
            using (var ctx = new CbmsMainDbEntities())
            {
                var oldInvoiceProduct = ctx.InvoiceProducts
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

                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="invoiceID">ID of existing in database invoice (part of compound key)</param>
        /// <param name="productID">ID of existing in database product (part of compound key)</param>
        public void DeleteInvoiceProduct(int invoiceID, int productID)
        {
            using (var ctx = new CbmsMainDbEntities())
            {
                var invoiceProductToDelete = ctx.InvoiceProducts
                    .First(ip => ip.InvoiceID == invoiceID && ip.ProductID == productID);
                ctx.InvoiceProducts.Remove(invoiceProductToDelete);
                ctx.SaveChanges();
            }
        }
    }
}
