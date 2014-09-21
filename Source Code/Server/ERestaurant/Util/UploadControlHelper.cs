using DevExpress.Web.ASPxUploadControl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace ERestaurant.Util
{
    public class UploadControlHelper
    {
        public const string UploadDirectory = "~/Upload/images/";
        public const string ThumbnailFormat = "Thumbnail{0}{1}";

        public static readonly DevExpress.Web.ASPxUploadControl.ValidationSettings ValidationSettings = new DevExpress.Web.ASPxUploadControl.ValidationSettings
        {
            AllowedFileExtensions = new string[] { ".jpg", ".jpeg", ".jpe", ".gif" },
            MaxFileSize = 20971520
        };

        public static List<string> Files
        {
            get
            {
                UploadControlFilesStorage storage = HttpContext.Current.Session["Storage"] as UploadControlFilesStorage;
                if (storage != null)
                    return storage.Files;
                return new List<string>();
            }
        }
        public static int FileInputCount
        {
            get
            {
                UploadControlFilesStorage storage = HttpContext.Current.Session["Storage"] as UploadControlFilesStorage;
                if (storage != null)
                    return storage.FileInputCount;
                return 2;
            }
        }

        public static void AddImagesToCollection(UploadedFile[] files)
        {
            UploadControlFilesStorage storage = HttpContext.Current.Session["Storage"] as UploadControlFilesStorage;
            if (storage != null && files != null)
            {
                for (int i = 0; i < files.Length; i++)
                {
                    if (files[i].FileBytes.Length > 0 && files[i].IsValid)
                    {
                        if (!storage.Files.Contains(files[i].FileName))
                        {
                            string filePath = UploadDirectory + string.Format(ThumbnailFormat, storage.Files.Count, Path.GetExtension(files[i].FileName));
                            files[i].SaveAs(HttpContext.Current.Request.MapPath(filePath));
                            storage.Files.Add(files[i].FileName);
                        }
                    }
                }
                storage.FileInputCount = files.Length;
            }
        }
        public static void ClearImageCollection()
        {
            UploadControlFilesStorage storage = HttpContext.Current.Session["Storage"] as UploadControlFilesStorage;
            if (storage != null)
                storage.Files.Clear();
        }

        public static void ucCallbacks_FileUploadComplete(object sender, FileUploadCompleteEventArgs e)
        {
            if (e.UploadedFile.IsValid)
            {
                string resultFilePath = UploadDirectory + string.Format(ThumbnailFormat, "", Path.GetExtension(e.UploadedFile.FileName));
                using (Image original = Image.FromStream(e.UploadedFile.FileContent))
                using (Image thumbnail = PhotoUtils.Inscribe(original, 100))
                {
                    PhotoUtils.SaveToJpeg(thumbnail, HttpContext.Current.Request.MapPath(resultFilePath));
                }
                IUrlResolutionService urlResolver = sender as IUrlResolutionService;
                if (urlResolver != null)
                    e.CallbackData = urlResolver.ResolveClientUrl(resultFilePath) + "?refresh=" + Guid.NewGuid().ToString();
            }
        }
        public static void ucMultiSelection_FileUploadComplete(object sender, FileUploadCompleteEventArgs e)
        {
            string resultFilePath = UploadDirectory + e.UploadedFile.FileName;
            e.UploadedFile.SaveAs(HttpContext.Current.Request.MapPath(resultFilePath));

            UploadingUtils.RemoveFileWithDelay(e.UploadedFile.FileName, HttpContext.Current.Request.MapPath(resultFilePath), 5);

            IUrlResolutionService urlResolver = sender as IUrlResolutionService;
            if (urlResolver != null)
            {
                string file = string.Format("{0} ({1}) {2}KB", e.UploadedFile.FileName, e.UploadedFile.ContentType, e.UploadedFile.ContentLength / 1024);
                string url = urlResolver.ResolveClientUrl(resultFilePath);
                e.CallbackData = file + "|" + url;
            }
        }
    }

    public class UploadControlFilesStorage
    {
        List<string> files;

        public UploadControlFilesStorage()
        {
            this.files = new List<string>();
            FileInputCount = 2;
        }

        public int FileInputCount { get; set; }
        public List<string> Files { get { return files; } }
    }
}
