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
    
    public partial class Vet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vet()
        {
            this.Pet_Visit = new HashSet<Pet_Visit>();
        }
    
        public decimal IDVet { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Id_Number { get; set; }
        public string License { get; set; }
        public string Address { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pet_Visit> Pet_Visit { get; set; }
    }
}