using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERestaurant.Util
{
    public class UploadFileUtil
    {
        public static string CreateNewName(string str)
        {
            return DateTime.Now.ToString("yyyyMMdd") + "_" + Guid.NewGuid().ToString() + str;
        }

    }
}