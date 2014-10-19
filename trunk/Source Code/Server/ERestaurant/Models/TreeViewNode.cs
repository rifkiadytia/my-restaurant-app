using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERestaurant.Models
{
    public class TreeViewNode
    {
        public long SessionID { get; set; }
        public string SessioName { get; set; }
        public long? SessionBelongTo { get; set; }
    }
}