using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Future_Vet.Helper_Code.Objects
{
    //created an object class which will map my sample list data in order to populate the drop-down list.
    public class PetNamesObj
    {
        #region Properties  

        /// <summary>  
        /// Gets or sets country ID property.  
        /// </summary>  
        public int IDPet { get; set; }

        /// <summary>  
        /// Gets or sets country name property.  
        /// </summary>  
        public string Pet_Name { get; set; }

        #endregion
    }
}