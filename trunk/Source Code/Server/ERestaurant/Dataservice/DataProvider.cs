using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERestaurant.Models;
namespace ERestaurant.Dataservice
{
    public class DataProvider
    {
        public static DataProvider dataProvider;
        public RestaurantDataContext context = DataConnection.Instance;
        private DataProvider()
        {
        }
        public List<Role> GetAllRole()
        {
            return context.Roles.ToList<Role>();
        }
        public List<Role> GetRoleByUser(long ID)
        {
            return context.Roles.ToList<Role>();
        }
        public static DataProvider GetInstance
        {
            get
            {
                if (dataProvider == null)
                {
                    dataProvider = new DataProvider();
                }
                return dataProvider;
            }
        }

        public IQueryable<PositionMaster> GetPostion()
        {
            return context.PositionMasters; 
        }
        public  IQueryable<Role> Roles { get { return context.Roles; } }
        public IQueryable<UserInfo> UserInfo { get { return context.UserInfos; } }
    }
}