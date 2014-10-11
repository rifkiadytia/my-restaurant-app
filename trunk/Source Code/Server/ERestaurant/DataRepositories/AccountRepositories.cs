using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERestaurant.Models;
using ERestaurant.Util;

namespace ERestaurant.DataRepositories
{
    public class AccountRepositories
    {
        private static RestaurantDataContext dataContext = Dataservice.DataConnection.Instance;

        public List<Role> GetAllRole()
        {
            return dataContext.Roles.ToList<Role>();
        }
        public Role GetRoleById(int id)
        {
            Role role = dataContext.Roles.Where(x => x.RoleID == id).FirstOrDefault();
            return role;
        }

        public bool CreateRole(Role role)
        {
            try
            {
                dataContext.Roles.InsertOnSubmit(role);
                dataContext.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateRole(Role r)
        {
            try
            {
                Role role = dataContext.Roles.Where(x => x.RoleID == r.RoleID).FirstOrDefault();
                role.RoleName = r.RoleName;
                role.RoleDescription = r.RoleDescription;
                dataContext.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool RemoveRoleFromUser(IEnumerable<Role> role, long userID)
        {
            try
            {
                foreach (var item in role)
                {
                    UserRole userRole = dataContext.UserRoles.Where(x => x.UserID == userID && x.RoleID == item.RoleID).FirstOrDefault();
                    dataContext.UserRoles.DeleteOnSubmit(userRole);
                }
                dataContext.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool IsValidUser(string userName, string password)
        {
            var query = dataContext.UserInfos.Where(x => x.Username == userName);
            if (query.Count() != 0)
            {
                string hashPassword = query.FirstOrDefault().Password;
                if (AuthorizationUtil.IsMatchPassword(password, hashPassword))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        public bool CreateUser(RegisterModel model)
        {
            try
            {
                string password="123456789";
                UserInfo userInfo = new UserInfo();
                userInfo.Usercode = GenerateCode.GenerateUserCode(model.Position);
                userInfo.Username = model.UserName;
                userInfo.Password = AuthorizationUtil.Encrypt(password);
                userInfo.IsFirstTime = true;
                userInfo.DOB = model.DOB;
                userInfo.Address = model.Address;
                userInfo.Mobile = model.Mobile;
                userInfo.PositionID = model.Position;
                userInfo.Gender = model.Gender;
                userInfo.ReportingTo = model.ReportingTo;
                dataContext.UserInfos.InsertOnSubmit(userInfo);
                dataContext.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateUser(RegisterModel model)
        {
            try
            {
                UserInfo userInfo = dataContext.UserInfos.Where(x => x.Username == model.UserName).FirstOrDefault();
                userInfo.Password = AuthorizationUtil.Encrypt(model.Password);
                userInfo.DOB = model.DOB;
                userInfo.Mobile = model.Mobile;
                userInfo.PositionID = model.Position;
                userInfo.Gender = model.Gender;
                userInfo.Address = model.Address;
                userInfo.ReportingTo = model.ReportingTo;
                dataContext.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool ResetUserPassword(long userId, string password)
        {
            try
            {
                UserInfo userInfo = dataContext.UserInfos.Where(x => x.ID == userId).FirstOrDefault();
                userInfo.Password = password;
                userInfo.IsFirstTime = true;
                dataContext.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateUserInGridModel(UserInfo model)
        {
            try
            {
                UserInfo userInfo = dataContext.UserInfos.Where(x => x.Username == model.Username).SingleOrDefault();
                userInfo.DOB = model.DOB;
                userInfo.Mobile = model.Mobile;
                //harcode
                userInfo.PositionID = model.PositionID.Value;
                userInfo.Image = model.Image;
                userInfo.Gender = model.Gender;
                userInfo.Address = model.Address;
                userInfo.ReportingTo = 0;
                dataContext.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public RegisterModel GetUserById(long id)
        {
            RegisterModel model = dataContext.UserInfos.Where(x => x.ID == id).Select(x => new RegisterModel
            {
                DOB = x.DOB,
                UserName = x.Username,
                Gender = x.Gender,
                Position = x.PositionID.Value,
                Image = x.Image

            }).FirstOrDefault();
            return model;
        }
       
        public bool DeleteUser(long id)
        {
            try
            {
                UserInfo user = dataContext.UserInfos.Where(x => x.ID == id).SingleOrDefault();
                dataContext.UserInfos.DeleteOnSubmit(user);
                dataContext.SubmitChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public bool DeleteRole(long id)
        {
            try
            {
                Role role = dataContext.Roles.Where(x => x.RoleID == id).SingleOrDefault();
                dataContext.Roles.DeleteOnSubmit(role);
                dataContext.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<PositionMaster> GetAllPosition()
        {
            List<PositionMaster> allPosition = dataContext.PositionMasters.ToList<PositionMaster>();
            return allPosition;
        }

        public List<RegisterModel> SearchUser(RegisterModel model)
        {
            var query = from user in dataContext.UserInfos
                        join postion in dataContext.PositionMasters on user.PositionID equals postion.PositionID
                        select new RegisterModel
                       {
                           UserName = user.Username,
                           DOB = user.DOB,
                           Address = user.Address,
                           Image = user.Image,
                           PositionName = postion.PositionName
                       };
            if (!string.IsNullOrEmpty(model.UserName))
            {
                query.Where(x => x.UserName.Contains(model.UserName));
            }
            if (!string.IsNullOrEmpty(model.PositionName))
            {
                query.Where(x => x.PositionName.Contains(model.PositionName));
            }
            return query.ToList<RegisterModel>();
        }
        public bool AssignRoleToUser(long userId, IEnumerable<Role> roles)
        {
            try
            {
                foreach (Role role in roles)
                {
                    UserRole usl = new UserRole();
                    usl.UserID = userId;
                    usl.RoleID = role.RoleID;
                    dataContext.UserRoles.InsertOnSubmit(usl);
                }
                dataContext.SubmitChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public List<Role> GetRoleAssignByUser(long userId)
        {
            var query = from role in dataContext.Roles
                        join userRole in dataContext.UserRoles on role.RoleID equals userRole.RoleID
                        join user in dataContext.UserInfos on userRole.UserID equals user.ID
                        where user.ID == userId
                        select role;

            if (query != null && query.Count() != 0)
            {
                return query.ToList();
            }
            return null;
        }
        public List<Role> GetRoleByUser(long userId)
        {
            var query = from role in dataContext.Roles
                        join userRole in dataContext.UserRoles on role.RoleID equals userRole.RoleID
                        join user in dataContext.UserInfos on userRole.UserID equals user.ID
                        where user.ID == userId
                        select role;
            List<Role> allRole = dataContext.Roles.ToList<Role>();

            if (query != null && query.Count() != 0)
            {
                List<Role> userRole = query.ToList<Role>();
                for(int i=0; i < allRole.Count; i++)
                {
                    for(int j=0 ;j <userRole.Count; j++)
                    {
                        if(allRole[i].RoleID == userRole[j].RoleID)
                        {
                            allRole[i].IsSelected  =true;
                            break;
                        }
                    }
                }
            }
           for (int i = 0; i < allRole.Count; i++)
            {
                allRole[i].UserId = userId;
            }
           return allRole;
        }

        public bool ChangePassword(ChangePasswordModel model)
        {
            try
            {
                UserInfo user = dataContext.UserInfos.Where(x => x.Username == model.UserName).SingleOrDefault();
                user.Password = model.NewPassword;
                user.IsFirstTime = false;
                dataContext.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}