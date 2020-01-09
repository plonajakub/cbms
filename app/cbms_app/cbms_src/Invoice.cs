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
    
    public partial class Invoice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Invoice()
        {
            this.InvoiceProducts = new HashSet<InvoiceProduct>();
        }
    
        public int ID { get; set; }
        public int BusinessPartnerID { get; set; }
        public Nullable<int> FoundsPackID { get; set; }
        public int DepartmentID { get; set; }
        public int Number { get; set; }
        public string Type { get; set; }
        public System.DateTime IssueDate { get; set; }
    
        public virtual BusinessPartner BusinessPartner { get; set; }
        public virtual Department Department { get; set; }
        public virtual FundsPack FundsPack { get; set; }
        public virtual History History { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoiceProduct> InvoiceProducts { get; set; }
        public virtual Pending Pending { get; set; }
    }
}
