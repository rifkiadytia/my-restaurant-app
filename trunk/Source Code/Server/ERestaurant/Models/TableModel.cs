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
    [MetadataType(typeof(TableMetadata))]
    public partial class Table
    {
        public class TableMetadata
        {
            [Required]
            public string tablename { get; set; }

            [Required]
            public int sessionID { get; set; }
        }
    }
}