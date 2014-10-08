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
    [MetadataType(typeof(TableMasterMetadata))]
    public partial class TableMaster
    {
        public class TableMasterMetadata
        {
            public long TableID { get; set; }
            [Required]
            public string TableName { get; set; }

            [Required]
            public int SessionID { get; set; }

            public bool IsReserve { get; set; }

            public string Type { get; set; }

        }
        
    }
    public class TableLevel
    {
        public string TableValue { get; set; }
        public string TableDisplay { get; set; }
    }
}