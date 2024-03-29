//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PinterCRM.Areas.CRM.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Potential
    {
        public System.Guid Deal_ID { get; set; }
        public string Deal_Name { get; set; }
        public string Deal_Owner_ID { get; set; }
        public string Created_by_ID { get; set; }
        public string Modified_by_ID { get; set; }
        public Nullable<System.DateTime> Created_Time { get; set; }
        public Nullable<System.DateTime> Modified_Time { get; set; }
        public Nullable<double> Amount { get; set; }
        public Nullable<System.DateTime> Closing_Date { get; set; }
        public Nullable<System.Guid> Account_ID { get; set; }
        public string Type { get; set; }
        public string Stage { get; set; }
        public Nullable<double> Probability____ { get; set; }
        public Nullable<double> Sales_Cycle_Duration { get; set; }
        public Nullable<double> Overall_Sales_Duration { get; set; }
        public Nullable<double> Expected_Revenue { get; set; }
        public Nullable<System.Guid> Contact_ID { get; set; }
    
        public virtual Account Account { get; set; }
    }
}
