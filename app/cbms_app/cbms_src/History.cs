//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CbmsSrc
{
    using System;
    using System.Collections.Generic;
    
    public partial class History
    {
        public int InvoiceID { get; set; }
        public System.DateTime PaymentDate { get; set; }
    
        public virtual Invoice Invoice { get; set; }

        public string PaymentDateString
        {
            get
            {
                return PaymentDate.Year.ToString() + "-" + PaymentDate.Month.ToString() + "-" +
                       PaymentDate.Day.ToString();
            }
            private set { }
        }
    }
}
