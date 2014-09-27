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
    public partial class PositionMaster
    {
        public class PositionMetadata
        {
            public long PositionID { get; set; }
            public string PositionName { get; set; }
            public int PositionLevel { get; set; }
        }
    }
}