//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace cbms_src
{
    using System;
    using System.Collections.Generic;
    
    public partial class Transaction
    {
        public string Department { get; set; }
        public string BusinessPartner { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public System.DateTime IssueDate { get; set; }
        public Nullable<System.DateTime> PaymentDeadline { get; set; }
        public Nullable<System.DateTime> PaymentDate { get; set; }
        public string ProductName { get; set; }
        public int ProductQuantity { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
