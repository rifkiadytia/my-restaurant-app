//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ERestaurant.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FoodMaster
    {
        public FoodMaster()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }
    
        public long FoodID { get; set; }
        public string FoodName { get; set; }
        public string FoodDescription { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public long FoodCatID { get; set; }
        public int FinishingTime { get; set; }
    
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}