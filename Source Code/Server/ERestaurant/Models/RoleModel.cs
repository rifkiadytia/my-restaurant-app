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
        private bool m_isSelected = false;
        public bool IsSelected { get { return m_isSelected; } set { m_isSelected = value; } }
        public long UserId { get; set; }
        public class RoleMetadata
        {
            public long RoleID { get; set; }
            [Required]
            public string RoleName { get; set; }
            public string RoleDescription { get; set; }
        }
    }

    public class RoleModel
    {
        public List<Role> Roles { get; set; }
        public RegisterModel UserInfo { get; set; }
        public long UserId { get; set; }
    }

}