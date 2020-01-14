using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CbmsSrc.Backend.Exceptions;

namespace CbmsSrc.Backend
{
    public class DBValidationService
    {
        public static bool ValidateAddInvoiceWithProducts(CbmsMainDbEntities context, Invoice invoice,
            List<InvoiceProduct> invoiceProducts)
        {
            if (invoiceProducts.Any(invoiceProduct => invoiceProduct.InvoiceID != invoice.ID))
            {
                throw new DBLogicException("Not all products belong to the supplied invoice.");
            }

            return true;
        }

    }
}
