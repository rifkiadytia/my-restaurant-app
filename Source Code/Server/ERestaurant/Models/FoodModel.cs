using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace ERestaurant.Models
{
    [MetadataType(typeof(FoodMetadata))]
    public partial class Food
    {
        public class FoodMetadata
        {
            [Required]
            public string foodname { get; set; }

            public string fooddes { get; set; }

            [Required]
            public int price { get; set; }

            public string image { get; set; }

            [Required]
            public int foodcatId { get; set; }

            public int finishingtime { get; set; }
        }
    }
}