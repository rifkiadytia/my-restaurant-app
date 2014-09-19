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
    [MetadataType(typeof(PositionMetadata))]
    public partial class Position
    {
        public class PositionMetadata
        {
            [Required]
            public string positionname { get; set; }

            [Required]
            public int positionlevel { get; set; }
        }
    }
}