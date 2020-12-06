namespace UploadImage.Utils
{
    using ImageMagick;
    using System;

    public static class ValidateImage
    {
        public static bool ValidateSize(string path, string fileName)
        {
            try
            {
                string newPath = "C:/ApiC#/UploadImage/UploadImage/Files/ConvertedImages/" + fileName;
                int width = 796;
                int heigth = 1123;

                using (MagickImage oMagickImage = new MagickImage(path))
                {
                    int widthImage = oMagickImage.Width;
                    int heigthImage = oMagickImage.Height;

                    if (widthImage > width || heigthImage > heigth)
                    {
                        oMagickImage.Resize(width, heigth);
                    } 
                    else
                    {
                        oMagickImage.Resize(widthImage, heigthImage);
                    }
                    
                    oMagickImage.Write(newPath);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }            
        }

        public static bool ValidateHeaders(Microsoft.AspNetCore.Http.HttpRequest req)
        {
            try
            {
                bool resp = true;
                string token = req.Headers["Authorization"];
                string consumerId = req.Headers["ConsumerId"];

                if (consumerId != "12345" || token != "Bearer 12345")
                {
                    resp = false;
                }

                return resp;
            }
            catch (Exception)
            {
                return false;
            }            
        }

        public static bool ValidateExtension(string fileName)
        {
            bool resp = true;
            string ext = fileName.Substring(fileName.LastIndexOf('.') + 1).ToLower();

            if (ext != "jpg")
            {
                resp = false;
            }

            return resp;
        }
    }
}
