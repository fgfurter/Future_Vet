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
    
    public partial class Pet_Visit
    {
        public decimal IDVisit { get; set; }
        public Nullable<System.DateTime> VisitDate { get; set; }
        public Nullable<System.TimeSpan> VisitTime { get; set; }
        public Nullable<decimal> IDPet { get; set; }
        public Nullable<decimal> IDVet { get; set; }
        public string Summary { get; set; }
    
        public virtual Pet_Details Pet_Details { get; set; }
        public virtual Vet Vet { get; set; }
    }
}
