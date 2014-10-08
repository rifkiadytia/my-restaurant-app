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
    [MetadataType(typeof(FoodMasterMetadata))]
    public partial class FoodMaster
    {
        public class FoodMasterMetadata
        {
            public long FoodID { get; set; }

            [Required]
            public string FoodName { get; set; }

            public string FoodDescription { get; set; }

            [Required]
            public float Price { get; set; }

            public string Image { get; set; }
           
            [Required]
            public int FoodCatID { get; set; }

            public int FinishingTime { get; set; }
        }
    }
}