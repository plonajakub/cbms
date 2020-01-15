using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CbmsSrc.Backend.Exceptions;

namespace CbmsSrc.Backend
{
    public static class DBValidationService
    {
        public static bool ValidateAddInvoiceWithProducts(CbmsMainDbEntities context, Invoice invoice,
            List<InvoiceProduct> invoiceProducts)
        {
            if (!invoiceProducts.Any())
            {
                throw new DBLogicException("Faktura nie może posiadać pustej listy produktów.");
            }
            return true;
        }

        public static bool ValidateAddHistory(CbmsMainDbEntities context, History history)
        {
            if (context.Pendings.FirstOrDefault(p => p.InvoiceID == history.InvoiceID) != null)
            {
                throw new DBLogicException("Faktura istnieje w bazie jako przetwarzana.");
            }

            return true;
        }

        public static bool ValidateAddPending(CbmsMainDbEntities context, Pending pending)
        {
            if (context.Histories.FirstOrDefault(h => h.InvoiceID == pending.InvoiceID) != null)
            {
                throw new DBLogicException("Faktura istnieje w bazie jako zaksięgowana.");
            }

            return true;
        }

    }
}
