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
        public class RoleMetadata
        {
            [Required]
            public string RoleName { get; set; }
        }
    }

}