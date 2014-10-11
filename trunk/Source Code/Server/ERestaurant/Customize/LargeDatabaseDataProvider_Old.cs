using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERestaurant.Models;

namespace ERestaurant.Customize
{
    
    using DevExpress.Web.ASPxEditors;
    using DevExpress.Web.Mvc;

    public static class LargeDatabaseDataProvider_Old
    {
        const string LargeDatabaseDataContextKey = "RestaurantDataContext";

        public static RestaurantDataContext  DB
        {
            get
            {
                if (HttpContext.Current.Items[LargeDatabaseDataContextKey] == null)
                    HttpContext.Current.Items[LargeDatabaseDataContextKey] = new RestaurantDataContext();
                return (RestaurantDataContext)HttpContext.Current.Items[LargeDatabaseDataContextKey];
            }
        }

        public static IQueryable<UserInfo> RegisterUser { get { return DB.UserInfos; } }

        public static object GetPersonsRange(ListEditItemsRequestedByFilterConditionEventArgs args)
        {
            var skip = args.BeginIndex;
            var take = args.EndIndex - args.BeginIndex + 1;
            return (from person in DB.UserInfos
                    where (person.Username + " " + person.Mobile + " " + person.Address).StartsWith(args.Filter)
                    orderby person.Username
                    select person
                    ).Skip(skip).Take(take);
        }
        public static object GetPersonByID(ListEditItemRequestedByValueEventArgs args)
        {
            int id;
            if (args.Value == null || !int.TryParse(args.Value.ToString(), out id))
                return null;
            return DB.UserInfos.Where(p => p.ID == id).Take(1);
        }
    }
}