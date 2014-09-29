using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevOne.Security.Cryptography.BCrypt;
namespace ERestaurant.Util
{
    public class AuthorizationUtil
    {
        public static string Encrypt(String password)
        {
            string hashPassword = BCryptHelper.HashPassword(password, BCryptHelper.GenerateSalt());
            return hashPassword;
        }
        public static bool IsMatchPassword(string password, string hashPassword)
        {
            return BCryptHelper.CheckPassword(password, hashPassword);
        }
    }
}