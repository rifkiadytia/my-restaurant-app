using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;

namespace ERestaurant.Util
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public class ValidateFileAttribute : ValidationAttribute
    {

        public string Extensions { get; set; }
        private int _maxSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxSize"></param>
        public ValidateFileAttribute(int maxSize)
        {
            _maxSize = maxSize;
        }

        private bool ValidExtensions(System.Drawing.Image img)
        {
            Boolean flag = false;
            foreach (var tmp in Extensions.Split('|').ToList())
            {
                switch (tmp.ToUpper().Trim())
                {
                    case "BMP":
                        flag = img.RawFormat.Equals(ImageFormat.Bmp);
                        break;
                    case "GIF":
                        flag = img.RawFormat.Equals(ImageFormat.Gif);
                        break;
                    case "JPG":
                        flag = img.RawFormat.Equals(ImageFormat.Jpeg);
                        break;
                    case "JPEG":
                        flag = img.RawFormat.Equals(ImageFormat.Jpeg);
                        break;
                    case "PNG":
                        flag = img.RawFormat.Equals(ImageFormat.Png);
                        break;
                    default:
                        break;
                }
                if (flag)
                {
                    break;
                }
            }
            return flag;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessage, Extensions, _maxSize);
        }

        public override bool IsValid(object value)
        {

            bool flag = true;
            try
            {
                HttpPostedFileBase file = value as HttpPostedFileBase;

                if (file == null)
                {
                    if (flag)
                    {
                        flag = true;
                    }
                }
                else
                {

                    if (file.ContentLength > _maxSize * 1024 * 1024)
                    {
                        flag = false;
                    }

                    using (var img = System.Drawing.Image.FromStream(file.InputStream))
                    {
                        if (flag)
                        {
                            flag = ValidExtensions(img);
                        }
                    }
                }

            }
            catch
            {
                flag = false;
            }
            return flag;
        }
    }
}