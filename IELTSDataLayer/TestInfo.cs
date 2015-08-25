//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IELTSDataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class TestInfo
    {
        public TestInfo()
        {
            this.AddressInfoes = new HashSet<AddressInfo>();
        }
    
        public decimal TestInfoID { get; set; }
        public string ReceiptNumber { get; set; }
        public Nullable<decimal> StudentID { get; set; }
        public Nullable<decimal> OfficeUseID { get; set; }
        public Nullable<System.DateTime> PreferredTestDate { get; set; }
        public Nullable<System.DateTime> SecondaryTestDate { get; set; }
        public string TestCityLocation { get; set; }
        public string TestModule { get; set; }
        public string TestReason { get; set; }
        public Nullable<bool> ResultCopyTo { get; set; }
        public Nullable<byte> Status { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDateTime { get; set; }
    
        public virtual ICollection<AddressInfo> AddressInfoes { get; set; }
        public virtual OfficeUse OfficeUse { get; set; }
        public virtual StudentInfo StudentInfo { get; set; }
    }
}
