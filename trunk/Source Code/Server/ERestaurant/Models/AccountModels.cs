using ERestaurant.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ERestaurant.Models {
        public class UsersContext : DbContext {
        public UsersContext()
            : base("DefaultConnection") {
        }
        public DbSet<UserProfile> UserProfiles { get; set; }
    }
    [Table("UserProfile")]
    public class UserProfile {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
    

    public class ChangePasswordModel {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [System.ComponentModel.DataAnnotations.Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        bool? rememberMe;
        [Display(Name = "Remember me?")]
        public bool? RememberMe {
            get { return rememberMe ?? false; }
            set { rememberMe = value; }
        }
    }

    public class RegisterModel {
        public int UserId { get; set; }
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }
        public string PositionName { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Image { get; set; }
        public DateTime? DOB { get; set; }
       
        [Required]
        public long Position { get; set; }
        public int ReportingTo { get; set; }
        [Required]
        public bool Gender { get; set; }
       
        public string Password { get; set; }
       
    }
    public class Gender
    {
        public bool GenderValue { get; set; }
        public string GenderName { get; set; }
    }
}