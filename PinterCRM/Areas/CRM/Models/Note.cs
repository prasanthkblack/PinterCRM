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
    
    public partial class Note
    {
        public System.Guid Note_ID { get; set; }
        public Nullable<System.Guid> Note_Owner_ID { get; set; }
        public string Note_Title { get; set; }
        public string Note_Content { get; set; }
        public Nullable<System.Guid> Parent_ID { get; set; }
        public Nullable<System.Guid> Created_by_ID { get; set; }
        public Nullable<System.Guid> Modified_by_ID { get; set; }
        public Nullable<System.DateTime> Created_Time { get; set; }
        public Nullable<System.DateTime> Modified_Time { get; set; }
        public string Description { get; set; }
    }
}