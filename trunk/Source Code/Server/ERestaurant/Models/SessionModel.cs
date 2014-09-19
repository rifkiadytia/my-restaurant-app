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
    [MetadataType(typeof(SessionMetadata))]
    public partial class Role
    {
        public class SessionMetadata
        {
            [Required]
            public string sessionname { get; set; }

            [Required]
            public int sessionlevel { get; set; }

            public string sessionbelongto { get; set; }
        }
    }
}