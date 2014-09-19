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
    [MetadataType(typeof(FoodCatMetadata))]
    public partial class FoodCat
    {
        public class FoodCatMetadata
        {
            [Required]
            public string FoodCatName { get; set; }
        }
    }
}