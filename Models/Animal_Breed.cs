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
    
    public partial class Animal_Breed
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Animal_Breed()
        {
            this.Pet_Details = new HashSet<Pet_Details>();
        }
    
        public decimal IDBreed { get; set; }
        public string Breed { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pet_Details> Pet_Details { get; set; }
    }
}
