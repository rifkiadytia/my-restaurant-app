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
    
    public partial class PositionMaster
    {
        public PositionMaster()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
            this.UserInfoes = new HashSet<UserInfo>();
        }
    
        public long PositionID { get; set; }
        public string PositionName { get; set; }
        public int PositionLevel { get; set; }
    
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<UserInfo> UserInfoes { get; set; }
    }
}