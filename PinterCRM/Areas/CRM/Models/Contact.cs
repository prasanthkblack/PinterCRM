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
    
    public partial class Contact
    {
        public System.Guid Contact_ID { get; set; }
        public string Last_Name { get; set; }
        public string First_Name { get; set; }
        public Nullable<System.Guid> Contact_Owner_ID { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public string Lead_Source { get; set; }
        public string Industry { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Skype_ID { get; set; }
        public string Title { get; set; }
        public string Mailing_Street { get; set; }
        public string Mailing_City { get; set; }
        public string Mailing_State { get; set; }
        public string Date_of_Birth { get; set; }
        public Nullable<double> Mailing_Zip { get; set; }
        public string Twitter { get; set; }
        public string Description { get; set; }
    
        public virtual Account Account { get; set; }
    }
}