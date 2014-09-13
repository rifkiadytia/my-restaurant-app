using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using PagedList;


namespace MVCInBuiltFeatures.Models
{
    public class UserFormView
    {
        public string Id { get; set; }
        public int? Page { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Position { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public IEnumerable<UserFormView> SearchResults { get; set; }
        public string SearchButton { get; set; }
    }
}