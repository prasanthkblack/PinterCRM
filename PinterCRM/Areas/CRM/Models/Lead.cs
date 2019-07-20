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
    
    public partial class Lead
    {
        public System.Guid Lead_ID { get; set; }
        public string Title { get; set; }
        public string Last_Name { get; set; }
        public string First_Name { get; set; }
        public Nullable<System.Guid> Lead_Owner_ID { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public string Lead_Source { get; set; }
        public string Industry { get; set; }
        public string Lead_Status { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Website { get; set; }
        public Nullable<double> No__of_Employees { get; set; }
        public Nullable<double> Annual_Revenue { get; set; }
        public string Skype_ID { get; set; }
        public string Salutation { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public Nullable<double> Zip_Code { get; set; }
        public string Twitter { get; set; }
        public string Description { get; set; }
    
        public virtual User User { get; set; }
    }
}