using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERestaurant.Models;

namespace ERestaurant.DataRepositories
{
    public class AccountRepositories
    {
        private static RestaurantDataContext dataContext = Dataservice.DataConnection.Instance;

        public IEnumerable<Role> GetAllRole()
        {
            return dataContext.Roles.ToList();
        }

        public bool IsValidUser(string userName, string password)
        {
            var query = dataContext.UserInfos.Where(x => x.Username == userName && x.Password == password);
            if (query.Count() == 0)
            {
                return false;
            }
            return true;
        }
        public bool CreateUser(RegisterModel model)
        {
            try
            {
                UserInfo userInfo = new UserInfo();
                userInfo.Username = model.UserName;
                userInfo.Password = model.Password; 
                userInfo.DOB = model.DOB;
                userInfo.Mobile = model.Mobile;
                userInfo.PositionID = model.Position;
                userInfo.Image = model.Image;
                userInfo.Gender = model.Gender;
                userInfo.ReportingTo = model.ReportingTo;
                dataContext.UserInfos.InsertOnSubmit(userInfo);
                dataContext.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
         
    }
}