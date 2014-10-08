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
    [MetadataType(typeof(FoodCategoryMasterMetadata))]
    public partial class FoodCategoryMaster
    {
        public class FoodCategoryMasterMetadata
        {
            public long FoodCatID { get; set; }
            [Required]
            public string FoodCatName { get; set; }
        }
    }
}