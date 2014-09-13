using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace MVCInBuiltFeatures.Common
{
    public class ImageUtil
    {

        #region - Private Variables -
        private const string gif = "gif";
        private const string jpg = "jpg";
        private const string jpeg = "jpeg";
        private const string png = "png";
        private const string bmp = "bmp";
        private const string emf = "emf";
        private const string exif = "exif";
        private const string icon = "icon;ico";
        private const string tiff = "tiff";
        private const string wmf = "wmf";
        private Dictionary<string, object> imageFormatTypes;
        #endregion

        #region - Public Varibles -
        public const char DimensionDelimiter = 'x';
        public const string FileExtensionDelimiter = ".";
        #endregion

        public ImageUtil()
        {
            //create a dictionary with different file extensions and image formats
            imageFormatTypes = new Dictionary<string, object>();
            imageFormatTypes.Add(emf, ImageFormat.Emf);
            imageFormatTypes.Add(png, ImageFormat.Png);
            imageFormatTypes.Add(bmp, ImageFormat.Bmp);
            imageFormatTypes.Add(exif, ImageFormat.Exif);
            imageFormatTypes.Add(icon, ImageFormat.Icon);
            imageFormatTypes.Add(jpg, ImageFormat.Jpeg);
            imageFormatTypes.Add(jpeg, ImageFormat.Jpeg);
            imageFormatTypes.Add(tiff, ImageFormat.Tiff);
            imageFormatTypes.Add(wmf, ImageFormat.Wmf);
        }

        public void CompressImageUpload(HttpPostedFileBase f, string strNewFile)
        {
            string strFileName = f.FileName;
            MemoryStream memStream = ParseStream(f);
            ImageCodecInfo imageCodeInfo;
            imageCodeInfo = GetEncoder(GetImageFormatFromFileNameExtension(strFileName));
            ImageCompression(memStream, strNewFile, imageCodeInfo, 100L);
        }

        public void CreateThumbnail(HttpPostedFileBase f, string strNewFile, int height, int width)
        {
            string strFileName = f.FileName;
            MemoryStream memStream = ParseStream(f);
            ImageCodecInfo imageCodeInfo;
            imageCodeInfo = GetEncoder(GetImageFormatFromFileNameExtension(strFileName));
            ImageCompression(memStream, strNewFile, imageCodeInfo, 100L);
            Resize(strNewFile, height, width);
        }

        /// <summary>
        /// Use this method when need to re-size high quality image to a smaller high quality image, it overwrites existing image if it exists if dosent it creates
        /// </summary>
        /// <param name="imagePath"></param>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        private bool Resize(string imagePath, int height, int width)
        {

            Bitmap nImage = null;

            using (Image fullSizeImage = Image.FromFile(imagePath))
            {
                using (Bitmap originalImage = new Bitmap(fullSizeImage))
                {
                    nImage = new Bitmap(width, height);

                    using (Graphics processImage = Graphics.FromImage(nImage))
                    {

                        processImage.DrawImage(originalImage, 0, 0, width, height);
                    }
                }
            }

            if (OverWrite(imagePath, nImage))
                return true;

            return false;
        }

        /// <summary>
        /// Images the compression.
        /// </summary>
        /// 
        /// <param name="stream">The image path.</param>
        /// <param name="imageServerPath">The image server path.</param>
        /// <param name="imageCodeInfo">The image codec info.</param>
        /// <param name="imageQuality">The image quality.</param>
        /// <returns></returns>
        ///
        private bool ImageCompression(Stream stream, string imageServerPath, ImageCodecInfo imageCodeInfo, long imageQuality)
        {
            bool isSaved = false;

            try
            {

                Bitmap bitmapQuality = null;
                EncoderParameters encoderParameters;

                bitmapQuality = new Bitmap(stream);
                System.Drawing.Imaging.Encoder encoder = System.Drawing.Imaging.Encoder.Quality;
                encoderParameters = new EncoderParameters(1);
                EncoderParameter encoderParameter = new EncoderParameter(encoder, imageQuality);
                encoderParameters.Param[0] = encoderParameter;


                isSaved = SaveImage(imageServerPath, bitmapQuality, imageCodeInfo, encoderParameters);
            }
            catch (Exception)
            {

            }

            return isSaved;
        }

        /// <summary>
        /// Overwrites image that is currently placed
        /// </summary>
        /// <param name="imagePath">provide the physical full path of the image on the hard drive</param>
        /// <param name="bitmap">image resource that isloaded in to the memory</param>
        /// <returns></returns>
        private bool OverWrite(string imagePath, Bitmap bitmap)
        {
            bool isOverWriten = false;

            FileInfo imageFileInformation = new FileInfo(imagePath);

            if (imageFileInformation.Exists)
            {
                imageFileInformation.Delete();
            }

            if (bitmap != null)
            {
                bitmap.Save(imagePath, GetImageFormatFromFileNameExtension(imagePath));
                isOverWriten = true;
                bitmap.Dispose();
            }

            return isOverWriten;
        }

        /// <summary>
        /// Save image and also changes images quality
        /// </summary>
        /// <param name="imageServerPath">provide the physical full path of the image on the hard drive</param>
        /// <param name="bitmap">image resource that isloaded in to the memory</param>
        /// <returns></returns>
        public bool SaveImage(string imageServerPath, Bitmap bitmap, ImageCodecInfo imageCodeInfo, EncoderParameters encoderParameters)
        {
            bool isSaved = false;

            try
            {
                if (bitmap != null)
                {
                    bitmap.Save(imageServerPath, imageCodeInfo, encoderParameters);
                    isSaved = true;
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                bitmap.Dispose();
            }

            return isSaved;
        }


        /// <summary>
        /// Gets the image format from file name extension.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        private ImageFormat GetImageFormatFromFileNameExtension(string fileName)
        {
            ImageFormat imageFormat = null;

            try
            {
                //get the file and extension of the file
                FileInfo fileInfo = new FileInfo(fileName);
                string fileExtension = fileInfo.Extension.Replace(FileExtensionDelimiter, string.Empty).ToLower();

                imageFormat = (ImageFormat)imageFormatTypes[fileExtension];
            }
            catch (DirectoryNotFoundException)
            {
                //if key is not found then use jpeg as default compression
                imageFormat = ImageFormat.Jpeg;

            }

            return imageFormat;
        }

        /// <summary>
        /// Gets the encoder.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <returns></returns>
        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {

                    return codec;
                }
            }

            return null;
        }

        private MemoryStream ParseStream(HttpPostedFileBase f)
        {
            Stream stream = default(Stream);
            stream = f.InputStream;
            stream.Seek(0, SeekOrigin.Begin);
            byte[] uFile = new byte[stream.Length + 1];
            stream.Read(uFile, 0, Convert.ToInt32(stream.Length));
            return new MemoryStream(uFile);
        }
    }
}