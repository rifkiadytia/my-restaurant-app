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
    [MetadataType(typeof(SessionMasterMetadata))]
    public partial class SessionMaster
    {
        public class SessionMasterMetadata
        {
            public long SessionID { get; set; }
            [Required]
            public string SessionName { get; set; }

            public int SessionLevel { get; set; }

            public long SessionBelongto { get; set; }
        }
    }
}