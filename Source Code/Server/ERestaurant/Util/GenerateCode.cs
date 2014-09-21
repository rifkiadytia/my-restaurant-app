using ERestaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERestaurant.Util
{
    public class GenerateCode
    {
        private static RestaurantDataContext dataContext = Dataservice.DataConnection.Instance;
        private static string DELIMETER = "-";
        public static string GenerateUserCode(long pos)
        {
            string postionName = dataContext.PositionMasters.Where(x => x.PositionID ==pos).FirstOrDefault().PositionName;
            int countPos = dataContext.UserInfos.Where(x => x.PositionID == pos).Count();
            string subPosCode = postionName.Substring(0, 3).ToUpper();
            string codeAfterFormat = FormatCodeStr((countPos + 1).ToString());
            return subPosCode + DELIMETER + codeAfterFormat;
        }
        private static string FormatCodeStr(string code)
        {
            if(code.Length == 1)
            {
                code  = "00" + code;
            }
            else if(code.Length == 2)
            {
                code  = "0" + code;
            }
            return code;
        }
    }
}