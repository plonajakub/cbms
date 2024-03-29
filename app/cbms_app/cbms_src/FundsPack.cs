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
    
    public partial class FundsPack
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FundsPack()
        {
            this.Invoices = new HashSet<Invoice>();
        }
    
        public int ID { get; set; }
        public int DepartmentID { get; set; }
        public int CategoryID { get; set; }
        public decimal Sum { get; set; }
        public string State { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual Department Department { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invoice> Invoices { get; set; }

        public virtual string StateString
        {
            get
            {
                if (State.Equals("fin"))
                    return "Rozpatrzona";
                else
                {
                    return "Otwarta";
                }
            }
            private set { }
        }
    }
}
