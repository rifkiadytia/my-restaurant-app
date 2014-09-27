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
    [MetadataType(typeof(RoleMetadata))]
    public partial class Role
    {
        public bool IsSelected { get; set; }
        
        public class RoleMetadata
        {
            public long RoleID { get; set; }
            [Required]
            public string RoleName { get; set; }
            public string RoleDescription { get; set; }
        }
    }

}