using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CbmsSrc.Backend
{
    class ValidationService
    {
        public bool ValidateInvoiceBeforeInsert(CbmsMainDbEntities context, Invoice newInvoice)
        {
            return true;
        }
        public bool ValidateInvoiceBeforeUpdate(CbmsMainDbEntities context, Invoice newInvoice)
        {
            return true;
        }
    }
}
