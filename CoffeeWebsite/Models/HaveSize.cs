//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CoffeeWebsite.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class HaveSize
    {
        public int HaveSizeID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public Nullable<int> ProductSizeID { get; set; }
        public Nullable<decimal> Prices { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual ProductSize ProductSize { get; set; }
    }
}