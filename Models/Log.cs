//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Future_Vet.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Log
    {
        public decimal IDLog { get; set; }
        public System.DateTime Date { get; set; }
        public string Thread { get; set; }
        public string Level { get; set; }
        public string Logger { get; set; }
        public string Message { get; set; }
        public Nullable<decimal> IDUser { get; set; }
    
        public virtual User User { get; set; }
    }
}